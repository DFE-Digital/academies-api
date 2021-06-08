using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class TrustSummaryResponseFactory
    {
        public static TrustSummaryResponse Create(GroupLink groupLink, IList<Establishment> establishments)
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

        public static TrustSummaryResponse Create(Group group, IList<Establishment> establishments)
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
                Establishments = establishments.Select(EstablishmentSummaryResponseFactory.Create).ToList()
            };
        }
    }
}