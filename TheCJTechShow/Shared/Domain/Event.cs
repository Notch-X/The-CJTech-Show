using TheCJTechShow.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheCJTechShow.Shared.Domain
{
    public class Event :BaseDomainModel
    {
            public string EventName { get; set; }
            public string EventDuration { get; set; }
            public string EventLocation { get; set; }
            public string EventDescription { get; set; }
            public string EventTicketPrice { get; set; }
            public string EventContactInformation { get; set; }

     
        public int OrganizerID { get; set; }
        


     }
    }
