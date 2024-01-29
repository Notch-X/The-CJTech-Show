using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TheCJTechShow.Server.Data;
using TheCJTechShow.Server.IRepository;
using TheCJTechShow.Server.Models;
using TheCJTechShow.Shared.Domain;

namespace TheCJTechShow.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private IGenericRepository<Event> _events;
        public IGenericRepository<Event> Events => _events ??= new GenericRepository<Event>(_context);

        private IGenericRepository<Visitor> _visitors;
        public IGenericRepository<Visitor> Visitors => _visitors ??= new GenericRepository<Visitor>(_context);

        private IGenericRepository<Organizer> _organizers;
        public IGenericRepository<Organizer> Organizers => _organizers ??= new GenericRepository<Organizer>(_context);

        private IGenericRepository<Vendor> _vendors;
        public IGenericRepository<Vendor> Vendors => _vendors ??= new GenericRepository<Vendor>(_context);

        private IGenericRepository<Sponsor> _sponsors;
        public IGenericRepository<Sponsor> Sponsors => _sponsors ??= new GenericRepository<Sponsor>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified || q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                var entity = (BaseDomainModel)entry.Entity;
                entity.DateUpdated = DateTime.Now;
                entity.UpdatedBy = user;

                if (entry.State == EntityState.Added)
                {
                    entity.DateCreated = DateTime.Now;
                    entity.CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
