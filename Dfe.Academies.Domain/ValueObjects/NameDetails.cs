using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.ValueObjects
{
    public class NameDetails : ValueObject
    {
        public string NameListAs { get; }
        public string NameDisplayAs { get; }
        public string NameFullTitle { get; }

        public NameDetails(string nameListAs, string nameDisplayAs, string nameFullTitle)
        {
            if (string.IsNullOrEmpty(nameListAs)) throw new ArgumentNullException(nameof(nameListAs));
            if (string.IsNullOrEmpty(nameDisplayAs)) throw new ArgumentNullException(nameof(nameDisplayAs));
            if (string.IsNullOrEmpty(nameFullTitle)) throw new ArgumentNullException(nameof(nameFullTitle));

            NameListAs = nameListAs;
            NameDisplayAs = nameDisplayAs;
            NameFullTitle = nameFullTitle;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NameListAs;
            yield return NameDisplayAs;
            yield return NameFullTitle;
        }
    }
}