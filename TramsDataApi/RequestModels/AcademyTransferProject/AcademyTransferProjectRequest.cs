using System.Collections.Generic;

namespace TramsDataApi.RequestModels.AcademyTransferProject
{
    public class AcademyTransferProjectRequest
    {
        public string OutgoingTrustUkprn { get; set; }
        public List<TransferringAcademiesRequest> TransferringAcademies { get; set; }
        public AcademyTransferProjectFeaturesRequest Features { get; set; }
        public AcademyTransferProjectDatesRequest Dates { get; set; }
        public AcademyTransferProjectBenefitsRequest Benefits { get; set; }
        public AcademyTransferProjectLegalRequirementsRequest LegalRequirements { get; set; }
        public AcademyTransferProjectRationaleRequest Rationale { get; set; }
        public AcademyTransferProjectGeneralInformationRequest GeneralInformation { get; set; }
        public AssignedUserRequest AssignedUser { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string ProjectReference { get; set; }

    }
}