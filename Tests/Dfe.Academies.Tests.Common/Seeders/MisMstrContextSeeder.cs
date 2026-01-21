using Bogus;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Infrastructure;

namespace Dfe.Academies.Tests.Common.Seeders;

public class MisMstrContextSeeder
{
    public static void Seed(MisMstrContext misMstrContext)
    {
        if (!misMstrContext.Establishments.Any() && !misMstrContext.FurtherEducationEstablishments.Any())
        {
            var urns = Enumerable.Range(1, 10);

            foreach (var urn in urns)
            {
                var establishments = new Faker<MisEstablishment>()
                    .RuleFor(e => e.Urn, urn)
                    .Generate();
                misMstrContext.Establishments.AddRange(establishments);
                
                var furtherEducationEstablishmentFaker = new Faker<FurtherEducationEstablishment>();
                var furtherEducationEstablishments =
                    furtherEducationEstablishmentFaker.RuleFor(x => x.ProviderUrn, urn)
                        .Generate();
                misMstrContext.FurtherEducationEstablishments.AddRange(furtherEducationEstablishments);

                var mockReportCards = new Faker<ReportCardFullInspection>()
                    .RuleFor(e => e.Urn, urn)
                    .Generate();
                misMstrContext.ReportCardsFullInspection.AddRange(mockReportCards); 
            }
        }

        misMstrContext.SaveChanges();
    }
}