using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.ValueObjects
{
    public class MemberId : ValueObject
    {
        public int Value { get; }

        public MemberId(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Member ID must be a positive integer.", nameof(value));
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

        public static implicit operator int(MemberId memberId)
        {
            return memberId.Value;
        }

        public static implicit operator MemberId(int value)
        {
            return new MemberId(value);
        }
    }
}
