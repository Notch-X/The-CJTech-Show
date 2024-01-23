using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CJTechShow.Shared.Domain
{
    public class Organizer : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }

    }
}
