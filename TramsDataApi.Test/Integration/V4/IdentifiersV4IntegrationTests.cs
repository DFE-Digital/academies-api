using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
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
    
    [Theory]
    [InlineData(IdTypes.GroupID)]
    [InlineData(IdTypes.UKPRN)]
    [InlineData(IdTypes.GroupUID)]
    public async Task Get_TrustIdentifiers_AndTrustExists_Returns_Ok(IdTypes idType)
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var selectedTrust = trustData.First();

        var identifier = idType switch
        {
            IdTypes.GroupID => selectedTrust.GroupID,
            IdTypes.UKPRN => selectedTrust.UKPRN,
            IdTypes.GroupUID => selectedTrust.GroupUID,
            _ => throw new ArgumentOutOfRangeException(nameof(idType), idType, null)
        };

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{identifier}");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(1);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Theory]
    [InlineData(IdTypes.GroupID)]
    [InlineData(IdTypes.UKPRN)]
    [InlineData(IdTypes.GroupUID)]
    public async Task Get_TrustIdentifiers_AndDuplicateTrustsExists_Returns_Ok(IdTypes idType)
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallDuplicateTrustSet(idType);

        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var selectedTrust = trustData.First();
        
        var identifier = idType switch
        {
            IdTypes.GroupID => "GroupID",
            IdTypes.UKPRN => "UKPRN",
            IdTypes.GroupUID => "GroupUID",
            _ => throw new ArgumentOutOfRangeException(nameof(idType), idType, null)
        };

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{identifier}");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(3);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Fact]
    public async Task Get_TrustIdentifiers_AndTrustDoesNotExist_Returns_NotFound()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        await context.SaveChangesAsync();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/noTrustExists");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
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

    public enum IdTypes { GroupID, UKPRN, GroupUID } 
    
    private static List<Trust> BuildSmallDuplicateTrustSet(IdTypes id)
    {
        var result = new List<Trust>();

        for (var idx = 0; idx < 3; idx++)
        {
            var trust = DatabaseModelBuilder.BuildTrust();
            switch (id)
            {
                case IdTypes.GroupID:
                    trust.GroupID = "GroupID";
                    break;
                case IdTypes.UKPRN:
                    trust.UKPRN = "UKPRN";
                    break;
                case IdTypes.GroupUID:
                    trust.GroupUID = "GroupUID";
                    break;
            }

            result.Add(trust);
        }

        return result;
    }
    
    private static void AssertIdentifierResponse(TrustIdentifiers actual, Trust expected)
    {
        actual.TrustReference.Should().Be(expected.GroupID);
        actual.UKPRN.Should().Be(expected.UKPRN);
        actual.UID.Should().Be(expected.GroupUID);
    }
}
