using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.ValueObjects
{
    public record NameDetails(string NameListAs, string NameDisplayAs, string NameFullTitle) : IStronglyTypedId;
}