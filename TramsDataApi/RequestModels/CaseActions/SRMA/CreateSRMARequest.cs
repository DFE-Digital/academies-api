using System;
using System.ComponentModel.DataAnnotations;
using TramsDataApi.Enums;

namespace TramsDataApi.RequestModels.CaseActions.SRMA
{
    public class CreateSRMARequest
    {
		[Required]
		public int Id { get; set; }
		[Required]
        public int CaseId { get; set; }
        public DateTime DateOffered { get; set; }
		public DateTime? DateAccepted { get; set; }
		public DateTime? DateReportSentToTrust { get; set; }
		public DateTime? DateVisitStart { get; set; }
		public DateTime? DateVisitEnd { get; set; }
		public SRMAStatus Status { get; set; }
		public string Notes { get; set; }
		public SRMAReasonOffered? Reason { get; set; }
	}
}
