using Bogus;
using TramsDataApi.DatabaseModels;

namespace Dfe.Academies.Tests.Common.Seeders;

public class LegacyTramsDbContextSeeder
{
    public static void Seed(LegacyTramsDbContext legacyTramsDbContext)
    {
        var urns = Enumerable.Range(1, 10);

        foreach (var urn in urns)
        {
            var establishment = new Faker<Establishment>()
                .RuleFor(e => e.Urn, urn)
                .RuleFor(e => e.Ukprn,
                    (urn * 100).ToString()) // Lets just seed some bigger number for a 'random' URN
                .RuleFor(e => e.TrustsCode, (urn*5).ToString())
                .Generate();
            legacyTramsDbContext.Establishment.AddRange(establishment);
            
            var group = new Faker<Group>()
                .RuleFor(g => g.Ukprn, urn.ToString())
                .RuleFor(g => g.GroupUid, (urn*5).ToString())
                .Generate();
            var trust = new Faker<Trust>()
                .RuleFor(t => t.TrustRef, (urn*5).ToString())
                .RuleFor(t => t.Rid, f => f.Random.Int().ToString())
                .Generate();
            legacyTramsDbContext.Group.AddRange(group);
            legacyTramsDbContext.Trust.AddRange(trust);
        }
        legacyTramsDbContext.SaveChanges();
    }

}