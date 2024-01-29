using TheCJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCJTechShow.Shared.Domain
{
    public class Event : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Duration { get; set; }
        public double? TicketPrice { get; set; }
        public string? Location { get; set; }
        public string? ContactNo { get; set; }
    }
}
