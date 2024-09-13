using AutoFixture;

namespace Dfe.Academies.Testing.Common.Helpers
{
    public static class FixtureFactoryHelper
    {
        public static IFixture ConfigureFixtureFactory(Type[] customizations)
        {
            var fixture = new Fixture();

            foreach (var customizationType in customizations)
            {
                var customization = (ICustomization)Activator.CreateInstance(customizationType)!;
                fixture.Customize(customization);
            }

            return fixture;
        }
    }
}
