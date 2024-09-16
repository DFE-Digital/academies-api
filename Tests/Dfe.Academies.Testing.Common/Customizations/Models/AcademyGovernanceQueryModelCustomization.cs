using AutoFixture;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Infrastructure.Models;

namespace Dfe.Academies.Testing.Common.Customizations.Models
{
    public class AcademyGovernanceQueryModelCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<AcademyGovernanceQueryModel>(composer => composer
                .FromFactory(() =>
                {
                    var establishmentGovernance = fixture.Create<EducationEstablishmentGovernance>();
                    var governanceRoleType = fixture.Create<GovernanceRoleType>();
                    var establishment = fixture.Create<Establishment>();

                    return new AcademyGovernanceQueryModel(establishmentGovernance, governanceRoleType, establishment);
                }));
        }
    }
}
