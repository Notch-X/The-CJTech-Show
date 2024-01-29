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
    public class OrganizerSeedConfiguration : IEntityTypeConfiguration<Organizer>
    {

        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasData(

new Organizer
{
    OrganizerID = 1,
    OrganizerName = "Christopher Ray",
    OrganizerContactNumber = "99661234",
    OrganizerPosition = "Overall Manager",
    OrganizerEmail = "ChristopherRay321@gmail.com",
    OrganizerPassword = "ChristopherRay123@",
    VendorID = 1
},
new Organizer
{
    OrganizerID = 2,
    OrganizerName = "Chua Rei Jet",
    OrganizerContactNumber = "98343264",
    OrganizerPosition = "Overall Supervisor",
    OrganizerEmail = "Chuareijet2003@gmail.com",
    OrganizerPassword = "Chuareijet2003",
    VendorID = 2
}
);
        }
    }
}