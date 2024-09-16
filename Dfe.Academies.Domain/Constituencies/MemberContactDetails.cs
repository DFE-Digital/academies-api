using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Domain.Constituencies
{
#pragma warning disable CS8618

    public class MemberContactDetails
    {
        public MemberId MemberId { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public int TypeId { get; private set; }

        private MemberContactDetails() { }

        public MemberContactDetails(
            MemberId memberId,
            int typeId,
            string? email = null,
            string? phone = null)
        {
            if (memberId == null) throw new ArgumentNullException(nameof(memberId));
            if (typeId <= 0) throw new ArgumentException("TypeId must be positive", nameof(typeId));

            MemberId = memberId;
            TypeId = typeId;
            Email = email;
            Phone = phone;
        }
    }
#pragma warning restore CS8618

}
