using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Domain.Constituencies
{
    public class Constituency
    {
        public ConstituencyId ConstituencyId { get; private set; }
        public MemberId MemberId { get; private set; }
        public string ConstituencyName { get; private set; }
        public NameDetails NameDetails { get; private set; }
        public DateTime LastRefresh { get; private set; }
        public DateOnly? EndDate { get; private set; }

        public Constituency() { }

        public virtual MemberContactDetails MemberContactDetails { get; private set; }

        public Constituency(
            ConstituencyId constituencyId,
            MemberId memberId,
            string constituencyName,
            NameDetails nameDetails,
            DateTime lastRefresh,
            DateOnly? endDate,
            MemberContactDetails memberContactDetails)
        {
            ConstituencyId = constituencyId ?? throw new ArgumentNullException(nameof(constituencyId));
            MemberId = memberId ?? throw new ArgumentNullException(nameof(memberId));
            ConstituencyName = constituencyName;
            NameDetails = nameDetails ?? throw new ArgumentNullException(nameof(nameDetails));
            LastRefresh = lastRefresh;
            EndDate = endDate;
            MemberContactDetails = memberContactDetails;
        }
    }
}
