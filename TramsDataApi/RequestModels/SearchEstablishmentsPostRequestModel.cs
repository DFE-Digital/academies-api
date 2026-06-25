using System.Collections.Generic;

namespace TramsDataApi.RequestModels
{
    public class SearchEstablishmentsPostRequestModel
    {
        public string EstablishmentNameStartsWith { get; set; }
        public List<GroupType> GroupTypes { get; set; }
    }

    public enum GroupType
    {
        Unknown = 0,

        // Align these values with Establishment.EstablishmentGroupTypeId values
        Colleges = 1,
        Academies = 10,
        FreeSchools = 11,
        Universities = 2,
        IndependentSchools = 3,
        LocalAuthorityMaintainedSchools = 4,
        SpecialSchools = 5,
        OtherTypes = 9,
        OnlineProvider = 13
    }

}
