using System.Collections.Generic;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class GetAcademyConversionProjectsByStatusesRequest
    {
        public int Count { get; set; }
        public List<string> Statuses { get; set; }
    }
}