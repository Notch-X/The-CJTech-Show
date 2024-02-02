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
    public class VisitorSeedConfiguration : IEntityTypeConfiguration<Visitor>
    {

        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasData(
new Visitor
{
    ID = 1,
    VisitorName = "Mr Foo Ling Chen",
    VisitorContactNumber = "88843212",
    VisitorEmail = "FooLingChen123@gmail.com",
    VisitorCompany = "Tech Dynamic Pte Ltd"
}
);
        }
    }
}
