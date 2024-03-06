using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Contracts.V4.Trusts;
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
    private static readonly Fixture _autoFixture = new Fixture();
    private readonly ApiTestFixture _apiFixture;

    private readonly string _apiUrlPrefix = "/v4";

    public IdentifiersV4IntegrationTests(ApiTestFixture fixture)
    {
        _apiFixture = fixture;
        _client = fixture.Client;
    }
    
    [Fact]
    public async Task Get_TrustIdentifiersByUkPrn_AndTrustExists_Returns_Ok()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        context.SaveChanges();

        var selectedTrust = trustData.First();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{selectedTrust.UKPRN}");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(1);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Fact]
    public async Task Get_TrustIdentifiersByUID_AndTrustExists_Returns_Ok()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        context.SaveChanges();

        var selectedTrust = trustData.First();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{selectedTrust.GroupUID}");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(1);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Fact]
    public async Task Get_TrustIdentifiersByGroupID_AndTrustExists_Returns_Ok()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallTrustSet();

        context.Trusts.AddRange(trustData);
        context.SaveChanges();

        var selectedTrust = trustData.First();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/{selectedTrust.GroupID}");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(1);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Fact]
    public async Task Get_TrustIdentifiersByUKPRN_AndDuplicateTrustsExists_Returns_Ok()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallDuplicateTrustSet(IdTypes.UKPRN);

        context.Trusts.AddRange(trustData);
        context.SaveChanges();

        var selectedTrust = trustData.First();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/UKPRN");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(3);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Fact]
    public async Task Get_TrustIdentifiersByGroupUID_AndDuplicateTrustsExists_Returns_Ok()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallDuplicateTrustSet(IdTypes.GroupUID);

        context.Trusts.AddRange(trustData);
        context.SaveChanges();

        var selectedTrust = trustData.First();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/GroupUID");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(3);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
    }
    
    [Fact]
    public async Task Get_TrustIdentifiersByGroupID_AndDuplicateTrustsExists_Returns_Ok()
    {
        using var context = _apiFixture.GetMstrContext();

        var trustData = BuildSmallDuplicateTrustSet(IdTypes.GroupID);

        context.Trusts.AddRange(trustData);
        context.SaveChanges();

        var selectedTrust = trustData.First();

        var trustResponse = await _client.GetAsync($"{_apiUrlPrefix}/identifier/GroupID");
        trustResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var trustContent = await trustResponse.Content.ReadFromJsonAsync<TrustIdentifiers[]>();
        trustContent.Length.Should().Be(3);
        AssertIdentifierResponse(trustContent.First(), selectedTrust);
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
    
    private enum IdTypes { GroupID, UKPRN, GroupUID } 
    
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
        actual.TR.Should().Be(expected.GroupID);
        actual.UKPRN.Should().Be(expected.UKPRN);
        actual.UID.Should().Be(expected.GroupUID);
    }
}
