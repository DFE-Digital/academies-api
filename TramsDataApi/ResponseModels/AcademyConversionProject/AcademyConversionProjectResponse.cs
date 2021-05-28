using System;
using System.Collections.Generic;

namespace TramsDataApi.ResponseModels.AcademyConversionProject
{
    public class AcademyConversionProjectResponse
	{
		public int Id { get; set; }
		public SchoolResponse School { get; set; }
		public TrustResponse Trust { get; set; }
		public DateTime? ApplicationReceivedDate { get; set; }
		public DateTime? AssignedDate { get; set; }
		public ProjectPhase Phase { get; set; }
		public IEnumerable<DocumentDetailsResponse> ProjectDocuments { get; set; }
	}
}
