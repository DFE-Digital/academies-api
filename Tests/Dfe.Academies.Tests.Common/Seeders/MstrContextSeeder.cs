using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Infrastructure;

namespace Dfe.Academies.Tests.Common.Seeders
{
    public class MstrContextSeeder
    {
        public static void Seed(MstrContext mstrContext)
        {
            if (!mstrContext.Trusts.Any() && !mstrContext.Establishments.Any() &&
             !mstrContext.EducationEstablishmentTrusts.Any() && !mstrContext.GovernanceRoleTypes.Any() &&
             !mstrContext.EducationEstablishmentGovernances.Any())
            {

                // Populate Trust
                var trust1 = new Trust
                {
                    SK = 1,
                    Name = "Trust A",
                    TrustTypeId = mstrContext.TrustTypes.FirstOrDefault()?.SK,
                    GroupUID = "G1",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System",
                    UKPRN = "12345678",
                    GroupID = "TR00024"
                };
                var trust2 = new Trust
                {
                    SK = 2,
                    Name = "Trust B",
                    TrustTypeId = mstrContext.TrustTypes.FirstOrDefault()?.SK,
                    GroupUID = "G2",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System",
                    UKPRN = "87654321",
                    GroupID = "TR00025"
                };
                mstrContext.Trusts.AddRange(trust1, trust2);

                // Populate Establishment
                var establishment1 = new Establishment
                {
                    SK = 1,
                    URN = 22,
                    EstablishmentName = "School A",
                    LocalAuthorityId = mstrContext.LocalAuthorities.FirstOrDefault()?.SK,
                    EstablishmentTypeId = mstrContext.EstablishmentTypes.FirstOrDefault()?.SK,
                    Latitude = 54.9784,
                    Longitude = -1.6174,
                    MainPhone = "01234567890",
                    Email = "schoolA@example.com",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ParliamentaryConstituency = "Test Constituency 1"
                };
                var establishment2 = new Establishment
                {
                    SK = 2,
                    URN = 33,
                    EstablishmentName = "School B",
                    LocalAuthorityId = mstrContext.LocalAuthorities.FirstOrDefault()?.SK,
                    EstablishmentTypeId = mstrContext.EstablishmentTypes.FirstOrDefault()?.SK,
                    Latitude = 50.3763,
                    Longitude = -4.1427,
                    MainPhone = "09876543210",
                    Email = "schoolB@example.com",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ParliamentaryConstituency = "Test Constituency 2"
                };
                mstrContext.Establishments.AddRange(establishment1, establishment2);

                // Populate EducationEstablishmentTrust
                var educationEstablishmentTrust1 = new EducationEstablishmentTrust
                {
                    SK = 1,
                    EducationEstablishmentId = (int)establishment1.SK,
                    TrustId = (int)trust1.SK,
                };
                var educationEstablishmentTrust2 = new EducationEstablishmentTrust
                {
                    SK = 2,
                    EducationEstablishmentId = (int)establishment2.SK,
                    TrustId = (int)trust2.SK,

                };
                mstrContext.EducationEstablishmentTrusts.AddRange(educationEstablishmentTrust1, educationEstablishmentTrust2);

                // Populate GovernanceRoleType
                var governanceRoleType1 = new GovernanceRoleType
                { SK = 1, Name = "Chair of Governors", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                var governanceRoleType2 = new GovernanceRoleType
                { SK = 2, Name = "Vice Chair of Governors", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                var governanceRoleType3 = new GovernanceRoleType
                { SK = 3, Name = "Trustee", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                mstrContext.GovernanceRoleTypes.AddRange(governanceRoleType1, governanceRoleType2, governanceRoleType3);

                // Populate EducationEstablishmentGovernance
                var governance1 = new EducationEstablishmentGovernance
                {
                    SK = 1,
                    EducationEstablishmentId = establishment1.SK,
                    GovernanceRoleTypeId = governanceRoleType1.SK,
                    GID = "GID1",
                    Title = "Mr.",
                    Forename1 = "John",
                    Surname = "Doe",
                    Email = "johndoe@example.com",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System"
                };
                var governance3 = new EducationEstablishmentGovernance
                {
                    SK = 3,
                    EducationEstablishmentId = establishment1.SK,
                    GovernanceRoleTypeId = governanceRoleType2.SK,
                    GID = "GID2",
                    Title = "Ms.",
                    Forename1 = "Anna",
                    Surname = "Smith",
                    Email = "annasmith@example.com",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System"
                };
                mstrContext.EducationEstablishmentGovernances.AddRange(governance1, governance3);

                // Populate TrustGovernance
                var trustGovernance1 = new TrustGovernance
                {
                    SK = 1,
                    TrustId = trust2.SK,
                    GovernanceRoleTypeId = governanceRoleType3.SK,
                    GID = "GID1",
                    Title = "Mr.",
                    Forename1 = "John",
                    Surname = "Wood",
                    Email = "johnWood@example.com",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System"
                };
                var trustGovernance2 = new TrustGovernance
                {
                    SK = 2,
                    TrustId = trust2.SK,
                    GovernanceRoleTypeId = governanceRoleType3.SK,
                    GID = "GID1",
                    Title = "Mr.",
                    Forename1 = "Joe",
                    Surname = "Wood",
                    Email = "joeWood@example.com",
                    Modified = DateTime.UtcNow,
                    ModifiedBy = "System"
                };
                mstrContext.TrustGovernances.AddRange(trustGovernance1, trustGovernance2);

                // Save changes
                mstrContext.SaveChanges();
            }
        }
    }
}
