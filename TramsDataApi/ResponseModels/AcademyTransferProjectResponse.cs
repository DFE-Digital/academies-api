using System;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels;

namespace TramsDataApi.ResponseModels
{
    public class AcademyTransferProjectResponse
    {
        public string ProjectUrn { get; set; }
        
        public string ProjectNumber { get; set; }
        public string OutgoingTrustUkprn { get; set; }
        public List<TransferringAcademiesResponse> TransferringAcademies { get; set; }
        public AcademyTransferProjectFeaturesResponse Features { get; set; }
        public AcademyTransferProjectDatesResponse Dates { get; set; }
        public AcademyTransferProjectBenefitsResponse Benefits { get; set; }
        public AcademyTransferProjectRationaleResponse Rationale { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        
    }
}