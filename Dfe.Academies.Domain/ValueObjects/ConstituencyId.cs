using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.ValueObjects
{
    public class ConstituencyId : ValueObject
    {
        public int Value { get; }

        public ConstituencyId(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Constituency ID must be a positive integer.", nameof(value));
            }
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator int(ConstituencyId constituencyId)
        {
            return constituencyId.Value;
        }

        public static implicit operator ConstituencyId(int value)
        {
            return new ConstituencyId(value);
        }
    }
}
