using TheCJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCJTechShow.Shared.Domain
{
    public class Visitor : BaseDomainModel
    {
        public string? VisitorName { get; set; }
        public string? VisitorContactNumber { get; set; }
        public string? VisitorEmail { get; set; }
        public string? VisitorCompany { get; set; }
    }
}
