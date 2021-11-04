using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class TrustSummaryResponseFactory
    {
        public static TrustSummaryResponse Create(GroupLink groupLink, IEnumerable<Establishment> establishments)
        {
            if (groupLink == null)
            {
                return null;
            }
            
            return new TrustSummaryResponse
            {
                Urn = groupLink.Urn,
                GroupName = groupLink.GroupName,
                CompaniesHouseNumber = groupLink.CompaniesHouseNumber,
                Establishments = establishments.Select(EstablishmentSummaryResponseFactory.Create).ToList()
            };
        }

        public static TrustSummaryResponse Create(Group group, IEnumerable<Establishment> establishments, Trust trust)
        {
            if (group == null)
            {
                return null;
            }
            
            return new TrustSummaryResponse
            {
                Ukprn = group.Ukprn,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                TrustType = trust?.TrustsTrustType,
                TrustAddress = new AddressResponse
                {
                    Street = trust?.TrustContactDetailsTrustAddressLine1,
                    AdditionalLine = trust?.TrustContactDetailsTrustAddressLine2,
                    Locality = trust?.TrustContactDetailsTrustAddressLine3,
                    Town = trust?.TrustContactDetailsTrustTown,
                    County = trust?.TrustContactDetailsTrustCounty,
                    Postcode = trust?.TrustContactDetailsTrustPostcode
                },
                Establishments = establishments.Select(EstablishmentSummaryResponseFactory.Create).ToList()
            };
        }
    }
}