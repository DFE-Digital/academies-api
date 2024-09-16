using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace Dfe.Academies.Testing.Common.Customizations
{
    public class NSubstituteCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new AutoNSubstituteCustomization());
        }
    }
}
