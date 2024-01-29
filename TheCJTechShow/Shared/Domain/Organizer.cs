using TheCJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCJTechShow.Shared.Domain
{
    public class Organizer : BaseDomainModel
    {
        public int OrganizerID { get; set; }
        public string? OrganizerName { get; set; }
        public string? OrganizerContactNumber { get; set; }
        public string? OrganizerPosition { get; set; }
        public string? OrganizerEmail { get; set; }
        public string? OrganizerPassword { get; set; }
        public virtual Vendor? VendorID { get; set; }

        public static implicit operator Organizer(int v)
       {
            throw new NotImplementedException();
        }
    }
}
