using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.RequestModels.CaseActions.NTI.NoticeToImprove
{
    public class PatchNoticeToImproveRequest
    {
        [Required]
        public long Id { get; set; }

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
