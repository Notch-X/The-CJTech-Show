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
    public class SponsorSeedConfiguration : IEntityTypeConfiguration<Sponsor>
    {

        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.HasData(

new Sponsor
{
    SponsorName = "Sukh Ma",
    SponsorContactInfo = "93939231",
    EventID = 1,
    OrganizerID = 1
},
new Sponsor
{
    SponsorName = "Bendover",
    SponsorContactInfo = "94942314",
    EventID = 2,
    OrganizerID = 2
}
);
        }
    }
}
