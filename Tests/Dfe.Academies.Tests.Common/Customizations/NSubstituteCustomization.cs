using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class NSubstituteCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new AutoNSubstituteCustomization());
        }
    }
}
