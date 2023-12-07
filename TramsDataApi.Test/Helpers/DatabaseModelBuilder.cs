﻿using AutoFixture;
using Dfe.Academies.Domain.Trust;

namespace TramsDataApi.Test.Helpers
{
    public static class DatabaseModelBuilder
    {
        private static readonly Fixture _fixture = new Fixture();

        public static Trust BuildTrust()
        {
            var result = _fixture.Create<Trust>();
            result.TrustStatus = "Open";
            result.TrustsTypeId = 30;
            result.TrustType = null;
            result.TrustStatusId = null;
            result.RegionId = null;
            result.TrustBandingId = null;
            result.CurrentSingleListGrouping = result.CurrentSingleListGrouping.Substring(0, 19);
            result.FollowUpLetterSent = result.CurrentSingleListGrouping.Substring(0, 19);
            result.PrioritisedForReview = result.PrioritisedForReview.Substring(0, 19);
            result.RID = result.RID.Substring(0, 10);

            return result;
        }
    }
}
