using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Domain.Constituencies
{
    public class Constituency
    {
        public ConstituencyId ConstituencyId { get; set; }
        public MemberId MemberID { get; set; }
        public string ConstituencyName { get; set; }
        public string NameList { get; set; }
        public string NameDisplayAs { get; set; }
        public string NameFullTitle { get; set; }
        public DateTime LastRefresh { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
