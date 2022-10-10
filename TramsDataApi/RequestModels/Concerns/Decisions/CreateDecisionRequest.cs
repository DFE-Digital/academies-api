using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;

namespace TramsDataApi.RequestModels.Concerns.Decisions
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class CreateDecisionRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "The ConcernsCaseUrn must be greater than zero")]
        public int ConcernsCaseUrn { get; set; }

        public Enums.Concerns.DecisionType[] DecisionTypes { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "The total amount requested must be zero or greater")]
        public decimal TotalAmountRequested { get; set; }

        [StringLength(Decision.MaxSupportingNotesLength)]
        public string SupportingNotes { get; set; }

        public DateTimeOffset ReceivedRequestDate { get; set; }

        [StringLength(Decision.MaxUrlLength)]
        public string SubmissionDocumentLink { get; set; }

        public bool? SubmissionRequired { get; set; }

        public bool? RetrospectiveApproval { get; set; }

        [StringLength(Decision.MaxCaseNumberLength)]
        public string CrmCaseNumber { get; set; }

        public bool IsValid()
        {
            return DecisionTypes.All(x => Enum.IsDefined(typeof(Enums.Concerns.DecisionType), x));
        }
    }
}