﻿using System.Collections.Generic;

namespace TramsDataApi.RequestModels
{
    public class GetAllBaselineTrackerRequestByStatusesRequest
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public List<string> Statuses { get; set; }
    }
}
