using TheCJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCJTechShow.Shared.Domain
{
    public class Sponsor: BaseDomainModel
    {
        public string SponsorName { get; set; }
        public string SponsorContactInfo { get; set; }

        public int EventID { get; set; }
        public virtual Event? Event { get; set; }


    }
}
