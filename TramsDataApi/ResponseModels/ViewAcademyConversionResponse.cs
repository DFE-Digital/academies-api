using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TramsDataApi.ResponseModels
{
    public class ViewAcademyConversionResponse
    {
        public string ViabilityIssue { get; set; }
        public string PFI { get; set; }
        public string PAN { get; set; }
        public string Deficit { get; set; }
    }
}
