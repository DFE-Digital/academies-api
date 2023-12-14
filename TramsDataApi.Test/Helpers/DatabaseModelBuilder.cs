using AutoFixture;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;

namespace TramsDataApi.Test.Helpers
{
    public static class DatabaseModelBuilder
    {
        private static readonly Fixture _fixture = new Fixture();

        public static Trust BuildTrust()
        {
            var result = _fixture.Create<Trust>();
            result.SK = null;
            result.TrustStatus = "Open";
            result.TrustTypeId = 30;
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

        public static Establishment BuildEstablishment()
        {
            var result = _fixture.Create<Establishment>();
            result.SK = null;
            result.IfdPipeline = null;
            result.LocalAuthority = null;
            result.EstablishmentType = null;
            result.PK_GIAS_URN = _fixture.Create<int>().ToString();
            result.FK_EstablishmentType = 228;
            result.FK_LocalAuthority = 1;

            return result;
        }
    }
}
