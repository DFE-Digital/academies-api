using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
	public class ProjectFilterParameters
	{
		public List<string> Statuses { get; set; }
		public List<string> AssignedUsers { get; set; }
	}
}
