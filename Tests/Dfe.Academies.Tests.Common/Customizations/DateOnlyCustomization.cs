using AutoFixture;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class DateOnlyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<DateOnly>(composer =>
                composer.FromFactory(() =>
                    DateOnly.FromDateTime(fixture.Create<DateTime>())));
        }
    }
}
