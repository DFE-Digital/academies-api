using AutoFixture.Xunit2;

namespace Dfe.Academies.Tests.Common.Attributes
{
    public class InlineCustomAutoDataAttribute(object[] values, params Type[] customizations)
        : InlineAutoDataAttribute(new CustomAutoDataAttribute(customizations), values);
}
