using System;
using TramsDataApi.Enums;

namespace TramsDataApi.ResponseModels.CaseActions.SRMA
{
    public class CreateSRMAResponse
    {
		public int Id { get; set; }
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
