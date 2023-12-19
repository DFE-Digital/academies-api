using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Test.Fixtures;
using TramsDataApi.Test.Helpers;
using Xunit;

namespace TramsDataApi.Test.Integration.V4
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class GenerateDataTests
    {
        private readonly ApiTestFixture _apiFixture;

        public GenerateDataTests(ApiTestFixture fixture)
        {
            _apiFixture = fixture;
        }

        [Fact(Skip = "Generate data for performance testing on an adhoc basis")]
        public void GenerateTrustData()
        {
            using var context = _apiFixture.GetMstrContext();
            context.ChangeTracker.AutoDetectChangesEnabled = false;

            for (var idx = 0; idx < 4000; idx++)
            {
                CreateDataSet(context);
            }
        }

        private static TrustDataSet CreateDataSet(MstrContext context)
        {
            var trust = DatabaseModelBuilder.BuildTrust();
            context.Add(trust);
            context.SaveChanges();

            var establishments = new List<EstablishmentDataSet>();

            for (var idx = 0; idx < 3; idx++)
            {
                var establishment = DatabaseModelBuilder.BuildEstablishment();
                var ifdPipeline = DatabaseModelBuilder.BuildIfdPipeline();
                ifdPipeline.GeneralDetailsUrn = establishment.PK_GIAS_URN;

                var establishmentDataSet = new EstablishmentDataSet()
                {
                    Establishment = establishment,
                    IfdPipeline = ifdPipeline
                };

                context.Establishments.Add(establishment);
                context.IfdPipelines.Add(ifdPipeline);

                establishments.Add(establishmentDataSet);
            }

            context.SaveChanges();

            var trustToEstablishmentLinks = LinkTrustToEstablishments(trust, establishments.Select(d => d.Establishment).ToList());

            context.EducationEstablishmentTrusts.AddRange(trustToEstablishmentLinks);

            context.SaveChanges();

            var result = new TrustDataSet()
            {
                Trust = trust,
                Establishments = establishments
            };

            return result;
        }

        private static List<EducationEstablishmentTrust> LinkTrustToEstablishments(Trust trust, List<Establishment> establishments)
        {
            var result = new List<EducationEstablishmentTrust>();

            establishments.ForEach(establishment =>
            {
                var educationEstablishmentTrust = new EducationEstablishmentTrust()
                {
                    TrustId = (int)trust.SK,
                    EducationEstablishmentId = (int)establishment.SK
                };

                result.Add(educationEstablishmentTrust);
            });

            return result;
        }
    }
}
