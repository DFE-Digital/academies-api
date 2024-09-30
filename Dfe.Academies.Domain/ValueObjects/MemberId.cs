using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.ValueObjects
{
    public record MemberId(int Value) : IStronglyTypedId;
}
