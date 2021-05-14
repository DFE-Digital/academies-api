using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class TrustListItemResponseFactory
    {
        public static TrustListItemResponse Create(GroupLink groupLink, IList<Establishment> establishments)
        {
            if (groupLink == null)
            {
                return null;
            }
            
            return new TrustListItemResponse
            {
                Urn = groupLink.Urn,
                GroupName = groupLink.GroupName,
                CompaniesHouseNumber = groupLink.CompaniesHouseNumber,
                Establishments = establishments.Select(EstablishmentListItemResponseFactory.Create).ToList()
            };
        }
    }
}