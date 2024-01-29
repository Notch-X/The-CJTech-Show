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
    public class VendorSeedConfiguration : IEntityTypeConfiguration<Vendor>
    {

        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasData(

new Vendor
{
    ID = 1,
    VendorName = "Derrick Choo",
    VendorContactDetails = "96961234",
    BoothNumber = 1,
    VendorDescription = "BNM Technology Pte Ltd, Leading IT product sales",
    Products = "Graphics Cards, Headsets,Microphones,keyboards",
    SocialMedia = "BNM_Tech",
    VisitorID =1
},
new Vendor
{
    ID = 2,
    VendorName = "Darius Yeo",
    VendorContactDetails = "94532356",
    BoothNumber = 2,
    VendorDescription = "AIChatGPT Technology Pte Ltd, Leading CHATGPT seller",
    Products = "CHATGPT",
    SocialMedia = "CHATGPT_AIKING",
    VisitorID = 2
}
);
        }
    }
}