using AutoFixture.Xunit2;
using Dfe.Academies.Testing.Common.Customizations;
using Dfe.Academies.Tests.Common.Customizations;
using Dfe.Academies.Tests.Common.Helpers;

namespace Dfe.Academies.Tests.Common.Attributes
{
    public class CustomAutoDataAttribute(params Type[] customizations)
        : AutoDataAttribute(() => FixtureFactoryHelper.ConfigureFixtureFactory(CombineCustomizations(customizations)))
    {
        private static Type[] CombineCustomizations(Type[] customizations)
        {
            var defaultCustomizations = new[] { typeof(NSubstituteCustomization) };
            return defaultCustomizations.Concat(customizations).ToArray();
        }
    }
}
