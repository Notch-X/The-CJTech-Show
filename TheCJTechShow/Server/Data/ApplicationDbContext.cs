using TheCJTechShow.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TheCJTechShow.Server.Configurations.Entities;
using TheCJTechShow.Server.Models;
using TheCJTechShow.Shared.Domain;

namespace TheCJTechShow.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new VisitorSeedConfiguration());
            builder.ApplyConfiguration(new OrganizerSeedConfiguration());
            builder.ApplyConfiguration(new VendorSeedConfiguration());
            builder.ApplyConfiguration(new SponsorSeedConfiguration());
            builder.ApplyConfiguration(new EventSeedConfiguration());



        }
    }
}
