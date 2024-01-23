using CJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCJTechShow.Shared.Domain
{
    public class Vendor: BaseDomainModel
    {
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailAddress { get; set; }
        public string? BoothNo { get; set; }
        public int EventID { get; set; }
        public virtual Event? Event { get; set; }
    }
}
