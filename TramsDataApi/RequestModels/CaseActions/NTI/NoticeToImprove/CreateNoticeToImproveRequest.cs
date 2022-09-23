using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.RequestModels.CaseActions.NTI.NoticeToImprove
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class CreateNoticeToImproveRequest
    {
		[Required]
        public int CaseUrn { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateStarted { get; set; }
        public string Notes { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public int? ClosedStatusId { get; set; }

        public ICollection<int> NoticeToImproveReasonsMapping { get; set; }
        public ICollection<int> NoticeToImproveConditionsMapping { get; set; }
    }
}
