using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Integration
{
    [Collection("Database")]
    public class TrustsIntegrationTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;

        public TrustsIntegrationTests(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            var scope = fixture.Services.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<TramsDbContext>();
            // Look into using transactions for tests
            //_dbContext.Database.BeginTransaction();
        }

        [Fact]
        public async Task ShouldReturnNull_WhenNoTrustsExist()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trust/mockukprn"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Should_Return_List_Of_Trusts()
        {
            var testData = GenerateTestData();
            _dbContext.Group.AddRange(testData);
            await _dbContext.SaveChangesAsync();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/trust/testukprn"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TrustResponse>(jsonString);
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(testData);
            
            _dbContext.Group.RemoveRange(testData);
            await _dbContext.SaveChangesAsync();
        }
        
        public void Dispose()
        { 
           // _dbContext.Database.RollbackTransaction();
           //_dbContext.Database.CurrentTransaction.Dispose();
        }

        private Group GenerateTestData()
        {
            return new Group
            {
                GroupUid = "1",
                GroupId = "1",
                GroupName = "Test Group",
                CompaniesHouseNumber = "011013254",
                GroupTypeCode = "5",
                GroupType = "FS",
                ClosedDate = "01/01/1970",
                GroupStatusCode = "45",
                GroupStatus = "CS",
                GroupContactStreet = "Street Name",
                GroupContactLocality = "Locality",
                GroupContactAddress3 = "Address 3",
                GroupContactTown = "Town Name",
                GroupContactCounty = "County Name",
                GroupContactPostcode = "P05 7CD",
                HeadOfGroupTitle = "Mx",
                HeadOfGroupFirstName = "First Name",
                HeadOfGroupLastName = "Last Name",
                Ukprn = "testukprn",
                IncorporatedOnOpenDate = "01/01/1970",
                OpenDate = "01/01/1970"
            };
        }
    }
}