using AutoFixture;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class OmitCircularReferenceCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
