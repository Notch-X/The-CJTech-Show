using TheCJTechShow.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace TheCJTechShow.Server.Configurations.Entities
{
    public class EventSeedConfiguration : IEntityTypeConfiguration<Event>
    {

        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(

new Event
{
    Id = 1,
    EventName = "IT Tech Show Suntec City",
    EventDuration = "96961234",
    EventLocation = "Suntec City, Postal code:039053",
    EventDescription = "IT Tech Show",
    EventTicketPrice = "Visitor:$100 ,Vendor:$80",
    EventContactInformation = "69691234",

},
new Event
{
    Id = 2,
    EventName = "IT Tech Show Expo",
    EventDuration = "10am-8pm",
    EventLocation = "Expo, Postal code:392012",
    EventDescription = "IT Tech Show",
    EventTicketPrice = "Visitor:$100 ,Vendor:$80",
    EventContactInformation = "69691234",

}
    );
        }
    }
}