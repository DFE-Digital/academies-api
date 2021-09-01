using System.Collections.Generic;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class GetAllAcademyConversionProjectsRequest
    {
        public int Count { get; set; }
        public List<string> State { get; set; }
    }
}
