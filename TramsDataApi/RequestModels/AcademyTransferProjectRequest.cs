using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.RequestModels
{
    public class AcademyTransferProjectRequest
    {
        public string OutgoingTrustUkprn { get; set; }
        public List<TransferringAcademiesRequest> TransferringAcademies { get; set; }
        public AcademyTransferProjectFeaturesRequest Features { get; set; }
        public AcademyTransferProjectDatesRequest Dates { get; set; }
        public AcademyTransferProjectBenefitsRequest Benefits { get; set; }
        public AcademyTransferProjectRationaleRequest Rationale { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        
    }
}