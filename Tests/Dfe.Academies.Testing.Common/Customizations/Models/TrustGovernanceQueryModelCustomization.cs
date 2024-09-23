using AutoFixture;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Infrastructure.Models;

namespace Dfe.Academies.Testing.Common.Customizations.Models
{
    public class TrustGovernanceQueryModelCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<TrustGovernanceQueryModel>(composer => composer
                .FromFactory(() =>
                {
                    var trust = fixture.Create<Trust>();
                    var governanceRoleType = fixture.Create<GovernanceRoleType>();
                    var trustGovernance = fixture.Create<TrustGovernance>();

                    return new TrustGovernanceQueryModel(trust, governanceRoleType, trustGovernance);
                }));
        }
    }
}
