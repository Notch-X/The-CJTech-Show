using TheCJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCJTechShow.Shared.Domain
{

    public class Vendor: BaseDomainModel
    { 
        public string? VendorName { get; set; }
        public string? VendorContactDetails { get; set; }
        public string? BoothNumber { get; set; }
        public string? VendorDescription { get; set; }
        public string? Products { get; set; }
        public string? SocialMedia { get; set; }


    }
}
