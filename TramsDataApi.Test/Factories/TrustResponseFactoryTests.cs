using System.Collections.Generic;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class TrustResponseFactoryTests
    {
        [Fact]
        public void TrustResponseFactory_CreatesTrustResponse_FromAGroup()
        {
            var group = GenerateGroup();
            
            var ifdDataResponse = new IFDDataResponse();
            var giasDataResponse = new GIASDataResponse
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                GroupContactAddress = new AddressResponse
                {
                    Street = group.GroupContactStreet,
                    AdditionalLine = group.GroupContactAddress3,
                    Locality = group.GroupContactLocality,
                    Town = group.GroupContactTown,
                    County = group.GroupContactCounty,
                    Postcode = group.GroupContactPostcode
                },
                Ukprn = group.Ukprn
            };
            var academyResponses = new List<AcademyResponse>();
            var expected = new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};

            var result = TrustResponseFactory.Create(group);
            expected.Should().BeEquivalentTo(result);
        }
    
        private Group GenerateGroup()
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
                Ukprn = "ukprn",
                IncorporatedOnOpenDate = "01/01/1970",
                OpenDate = "01/01/1970"
            };
        }
    }
}