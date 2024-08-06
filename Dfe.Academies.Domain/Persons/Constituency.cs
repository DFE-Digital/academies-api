using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.Persons
{
    public class Constituency
    {
        public int ConstituencyId { get; set; }
        public int MemberID { get; set; }
        public string ConstituencyName { get; set; }
        public string NameList { get; set; }
        public string NameDisplayAs { get; set; }
        public string NameFullTitle { get; set; }
        public DateTime LastRefresh { get; set; }
    }
}
