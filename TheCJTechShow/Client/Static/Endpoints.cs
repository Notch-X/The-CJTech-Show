using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCJTechShow.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string EventsEndpoint = $"{Prefix}/events";
        public static readonly string OrganizersEndpoint = $"{Prefix}/organizers";
        public static readonly string VendorsEndpoint = $"{Prefix}/vendors";
        public static readonly string VisitorsEndpoint = $"{Prefix}/visitors";
        public static readonly string SponsorsEndpoint = $"{Prefix}/sponsors";
        
    }
}
