using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public static class TrustResponseFactory
    {
        public static TrustResponse Create(Group group)
        {
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
            return new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};
        }
    }
}