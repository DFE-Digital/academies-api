using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.ValueObjects;
using Dfe.Academies.Infrastructure;

namespace Dfe.Academies.Tests.Common.Seeders
{
    public class MopContextSeeder
    {
        public static void Seed(MopContext mopContext)
        {

            var memberContact1 = new MemberContactDetails(
                new MemberId(1),
                1,
                "test1@example.com",
                null
            );

            var memberContact2 = new MemberContactDetails(
                new MemberId(2),
                1,
                "test2@example.com",
                null
            );

            var constituency1 = new Constituency(
                new ConstituencyId(1),
                new MemberId(1),
                "Test Constituency 1",
                new NameDetails(
                    "Wood, John",
                    "John Wood",
                    "Mr. John Wood MP"
                ),
                DateTime.UtcNow,
                null,
                memberContact1
            );

            var constituency2 = new Constituency(
                new ConstituencyId(2),
                new MemberId(2),
                "Test Constituency 2",
                new NameDetails(
                    "Wood, Joe",
                    "Joe Wood",
                    "Mr. Joe Wood MP"
                ),
                DateTime.UtcNow,
                null,
                memberContact2
            );

            mopContext.Constituencies.Add(constituency1);
            mopContext.Constituencies.Add(constituency2);

            mopContext.SaveChanges();
        }
    }
}
