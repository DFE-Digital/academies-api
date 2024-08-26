using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Domain.Constituencies
{
    public class MemberContactDetails
    {
        public MemberId? MemberID { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int TypeId { get; set; }
    }
}
