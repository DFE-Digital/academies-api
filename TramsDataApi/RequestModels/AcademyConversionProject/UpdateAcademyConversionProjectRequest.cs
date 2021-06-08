using System;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class UpdateAcademyConversionProjectRequest
    {
        public long Id { get; set; }

        public string RationaleForProject { get; set; }
        public string RationaleForSponsor { get; set; }
    }
}
