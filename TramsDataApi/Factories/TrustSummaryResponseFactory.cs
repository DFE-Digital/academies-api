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
    }
}