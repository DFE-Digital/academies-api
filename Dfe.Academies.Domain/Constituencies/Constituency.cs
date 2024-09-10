using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Domain.Constituencies
{
    public class Constituency
    {
        public ConstituencyId ConstituencyId { get; private set; }
        public MemberId MemberId { get; private set; }
        public string ConstituencyName { get; private set; }
        public string NameList { get; private set; }
        public string NameDisplayAs { get; private set; }
        public string NameFullTitle { get; private set; }
        public DateTime LastRefresh { get; private set; }
        public DateOnly? EndDate { get; private set; }

        public Constituency() { }

        public virtual MemberContactDetails MemberContactDetails { get; private set; }

        public Constituency(
            ConstituencyId constituencyId,
            MemberId memberId,
            string constituencyName,
            string nameList,
            string nameDisplayAs,
            string nameFullTitle,
            DateTime lastRefresh,
            DateOnly? endDate,
            MemberContactDetails memberContactDetails)
        {
            if (string.IsNullOrEmpty(constituencyName)) throw new ArgumentNullException(nameof(constituencyName));
            if (string.IsNullOrEmpty(nameDisplayAs)) throw new ArgumentNullException(nameof(nameDisplayAs));

            ConstituencyId = constituencyId;
            MemberId = memberId;
            ConstituencyName = constituencyName;
            NameList = nameList;
            NameDisplayAs = nameDisplayAs;
            NameFullTitle = nameFullTitle;
            LastRefresh = lastRefresh;
            EndDate = endDate;
            MemberContactDetails = memberContactDetails;
        }
    }
}
