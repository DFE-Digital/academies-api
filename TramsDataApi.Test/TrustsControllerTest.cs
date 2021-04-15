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
using Xunit;

namespace TramsDataApi.Test
{
    [Collection("Database")]
    public class TrustsControllerTest : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly TramsDbContext _dbContext;

        public TrustsControllerTest(TramsDataApiFactory fixture)
        {
            _client = fixture.CreateClient();
            _client.BaseAddress = new Uri("https://trams-api.com/");
            var scope = fixture.Services.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<TramsDbContext>();
            //_dbContext.Database.BeginTransaction();
        }

        [Fact]
        public async Task Should_Return_Empty_List_When_No_Trusts_Exist()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://trams-api.com/Trusts"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Group>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().Equal(new List<Group>());
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
                RequestUri = new Uri("https://trams-api.com/Trusts"),
                Headers = { 
                    { "ApiKey", "testing-api-key" }
                }
            };
            
            var response = await _client.SendAsync(httpRequestMessage);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Group>>(jsonString);
            
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

        private List<Group> GenerateTestData()
        {
            var group = new Group
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
                Ukprn = "ukprn",
                IncorporatedOnOpenDate = "01/01/1970",
                OpenDate = "01/01/1970"
            };
            return new List<Group> { group };
        }
    }
}