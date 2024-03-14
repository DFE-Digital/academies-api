using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Establishment;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
using TramsDataApi.Controllers.V4;
using TramsDataApi.Test.Fixtures;
using TramsDataApi.Test.Helpers;
using Xunit;

namespace TramsDataApi.Test.Integration.V4;

[Collection(ApiTestCollection.ApiTestCollectionName)]
public class IdentifiersV4IntegrationTests
{
    private readonly HttpClient _client;
    private readonly ApiTestFixture _apiFixture;

    private readonly string _apiUrlPrefix = "/v4";

    public IdentifiersV4IntegrationTests(ApiTestFixture fixture)
    {
        _apiFixture = fixture;
        _client = fixture.Client;
    }

    // TRUSTS

    [Theory]
    [InlineData(TrustIdTypes.GroupID)]
    [InlineData(TrustIdTypes.UKPRN)]
    [InlineData(TrustIdTypes.GroupUID)]
    public async Task Get_TrustIdentifiers_AndTrustExists_Returns_Ok(TrustIdTypes trustIdType)
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var selectedTrust = trustData.First();

        var identifier = trustIdType switch
        {
            TrustIdTypes.GroupID => selectedTrust.GroupID,
            TrustIdTypes.UKPRN => selectedTrust.UKPRN,
            TrustIdTypes.GroupUID => selectedTrust.GroupUID,
            _ => throw new ArgumentOutOfRangeException(nameof(trustIdType), trustIdType, null)
        };

        var response = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{identifier}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Identifiers>();
        var trusts = content.Trusts;
        trusts.Length.Should().Be(1);
        AssertTrustIdentifierResponse(trusts.First(), selectedTrust);
    }

    [Theory]
    [InlineData(TrustIdTypes.GroupID)]
    [InlineData(TrustIdTypes.UKPRN)]
    [InlineData(TrustIdTypes.GroupUID)]
    public async Task Get_TrustIdentifiers_AndDuplicateTrustsExists_Returns_Ok(TrustIdTypes trustIdType)
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallDuplicateTrustSet(trustIdType);

        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var identifier = trustIdType switch
        {
            TrustIdTypes.GroupID => "GroupID",
            TrustIdTypes.UKPRN => "UKPRN",
            TrustIdTypes.GroupUID => "GroupUID",
            _ => throw new ArgumentOutOfRangeException(nameof(trustIdType), trustIdType, null)
        };

        var response = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{identifier}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Identifiers>();
        var trusts = content.Trusts;
        trusts.Length.Should().Be(3);
        AssertTrustIdentifierResponse(trusts.First(), trustData.First());
        AssertTrustIdentifierResponse(trusts[1], trustData[1]);
        AssertTrustIdentifierResponse(trusts[2], trustData[2]);
    }

    [Theory]
    [InlineData(TrustIdTypes.GroupID)]
    [InlineData(TrustIdTypes.UKPRN)]
    [InlineData(TrustIdTypes.GroupUID)]
    public async Task Get_TrustIdentifiers_AndNoOtherIdentifiersExist_Returns_Ok(TrustIdTypes trustIdType)
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        var selectedTrust = trustData.First();

        // Group UID must be present so cannot be null
        string identifier;
        switch (trustIdType)
        {
            case TrustIdTypes.GroupID:
                identifier = selectedTrust.GroupID;
                selectedTrust.UKPRN = null;
                break;
            case TrustIdTypes.UKPRN:
                identifier = selectedTrust.UKPRN;
                selectedTrust.GroupID = null;
                break;
            case TrustIdTypes.GroupUID:
                identifier = selectedTrust.GroupUID;
                selectedTrust.GroupID = null;
                selectedTrust.UKPRN = null;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(trustIdType), trustIdType, null);
        }
        
        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var response = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{identifier}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Identifiers>();
        var trusts = content.Trusts;
        trusts.Length.Should().Be(1);
        AssertTrustIdentifierResponse(trusts.First(), selectedTrust);
    }

    [Fact]
    public async Task Get_TrustIdentifiers_AndTrustDoesNotExist_Returns_EmptyList()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var response = await _client.GetAsync($"{_apiUrlPrefix}/identifier/noTrustExists");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadFromJsonAsync<Identifiers>();
        var trusts = content.Trusts;
        trusts.Length.Should().Be(0);
    }

    // ESTABLISHMENTS

    [Theory]
    [InlineData(EstablishmentsIdTypes.URN)]
    [InlineData(EstablishmentsIdTypes.UKPRN)]
    [InlineData(EstablishmentsIdTypes.LAESTAB)]
    public async Task Get_EstablishmentIdentifiers_AndEstablishmentExists_Returns_Ok(EstablishmentsIdTypes idType)
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = CreateDataSet(context);

        var selectedEstablishment = trustData.Establishments.First().Establishment;
        var identifier = idType switch
        {
            EstablishmentsIdTypes.URN => $"{selectedEstablishment.URN}",
            EstablishmentsIdTypes.UKPRN => selectedEstablishment.UKPRN,
            EstablishmentsIdTypes.LAESTAB => $"{selectedEstablishment.LocalAuthority.Code}%2F{selectedEstablishment.EstablishmentNumber}",
            _ => throw new ArgumentOutOfRangeException(nameof(idType), idType, null)
        };

        var response = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{identifier}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Identifiers>();
        var establishments = content.Establishments;
        establishments.Length.Should().Be(1);
        AssertEstablishmentsIdentifierResponse(establishments.First(), selectedEstablishment);
    }

    private static List<Trust> BuildSmallTrustSet()
    {
        var result = new List<Trust>();

        for (var idx = 0; idx < 3; idx++)
        {
            var trust = DatabaseModelBuilder.BuildTrust();
            result.Add(trust);
        }

        return result;
    }

    public enum TrustIdTypes
    {
        GroupID,
        UKPRN,
        GroupUID
    }
    
    public enum EstablishmentsIdTypes
    {
        URN,
        UKPRN,
        LAESTAB
    }

    private static List<Trust> BuildSmallDuplicateTrustSet(TrustIdTypes trustId)
    {
        var result = new List<Trust>();

        for (var idx = 0; idx < 3; idx++)
        {
            var trust = DatabaseModelBuilder.BuildTrust();
            switch (trustId)
            {
                case TrustIdTypes.GroupID:
                    trust.GroupID = "GroupID";
                    break;
                case TrustIdTypes.UKPRN:
                    trust.UKPRN = "UKPRN";
                    break;
                case TrustIdTypes.GroupUID:
                    trust.GroupUID = "GroupUID";
                    break;
            }

            result.Add(trust);
        }

        return result;
    }

    private static TrustDataSet CreateDataSet(MstrContext context)
    {
        var trust = DatabaseModelBuilder.BuildTrust();
        context.Add(trust);
        context.SaveChanges();

        var establishments = new List<EstablishmentDataSet>();

        for (var idx = 0; idx < 3; idx++)
        {
            var establishment = DatabaseModelBuilder.BuildEstablishment();
            var ifdPipeline = DatabaseModelBuilder.BuildIfdPipeline();

            establishment.LocalAuthority = context.LocalAuthorities.First(la => la.SK % 3 == idx);
            ifdPipeline.GeneralDetailsUrn = establishment.PK_GIAS_URN;

            var establishmentDataSet = new EstablishmentDataSet()
            {
                Establishment = establishment,
                IfdPipeline = ifdPipeline
            };

            context.Establishments.Add(establishment);
            context.IfdPipelines.Add(ifdPipeline);

            establishments.Add(establishmentDataSet);
        }

        context.SaveChanges();

        var trustToEstablishmentLinks =
            LinkTrustToEstablishments(trust, establishments.Select(d => d.Establishment).ToList());

        context.EducationEstablishmentTrusts.AddRange(trustToEstablishmentLinks);

        context.SaveChanges();

        var result = new TrustDataSet()
        {
            Trust = trust,
            Establishments = establishments
        };

        return result;
    }

    private static List<EducationEstablishmentTrust> LinkTrustToEstablishments(Trust trust,
        List<Establishment> establishments)
    {
        var result = new List<EducationEstablishmentTrust>();

        establishments.ForEach(establishment =>
        {
            var educationEstablishmentTrust = new EducationEstablishmentTrust()
            {
                TrustId = (int)trust.SK,
                EducationEstablishmentId = (int)establishment.SK
            };

            result.Add(educationEstablishmentTrust);
        });

        return result;
    }

    private static void AssertTrustIdentifierResponse(TrustIdentifiers actual, Trust expected)
    {
        actual.TrustReference.Should().Be(expected.GroupID);
        actual.UKPRN.Should().Be(expected.UKPRN);
        actual.UID.Should().Be(expected.GroupUID);
    }
    
    private static void AssertEstablishmentsIdentifierResponse(EstablishmentIdentifiers actual, Establishment expected)
    {
        actual.URN.Should().Be(expected.URN.ToString());
        actual.UKPRN.Should().Be(expected.UKPRN);
        actual.LAESTAB.Should().Be($"{expected.LocalAuthority.Code}/{expected.EstablishmentNumber}");
    }
}