using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.Establishment
{
    public class EducationEstablishmentTrust
    {
        public int SK { get; set; } 

        // Foreign keys
        public int FK_Trust { get; set; }
        public int FK_EducationEstablishment { get; set; }

        // Navigation properties        
        public virtual Domain.Trust.Trust Trust { get; set; }
        public virtual Establishment Establishment { get; set; }
    }

}
