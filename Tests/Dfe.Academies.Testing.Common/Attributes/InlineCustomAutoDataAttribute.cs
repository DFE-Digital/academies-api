using AutoFixture.Xunit2;

namespace Dfe.Academies.Testing.Common.Attributes
{
    public class InlineCustomAutoDataAttribute(object[] values, params Type[] customizations)
        : InlineAutoDataAttribute(new CustomAutoDataAttribute(customizations), values);
}
