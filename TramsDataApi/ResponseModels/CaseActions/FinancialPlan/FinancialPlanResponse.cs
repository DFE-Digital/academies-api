﻿using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Enums;

namespace TramsDataApi.ResponseModels.CaseActions.FinancialPlan
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class FinancialPlanResponse
    {
        public long Id { get; set; }
        public int CaseUrn { get; set; }
        public string Name { get; set; }
        public long? StatusId { get; set; }
        public DateTime? DatePlanRequested { get; set; }
        public DateTime? DateViablePlanReceived { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string Notes { get; set; }

        public FinancialPlanStatus Status { get; set; }
    }
}