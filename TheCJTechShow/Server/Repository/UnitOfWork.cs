using TheCJTechShow.Server.Data;
using TheCJTechShow.Server.IRepository;
using TheCJTechShow.Server.Models;
using TheCJTechShow.Server.Repository;
using TheCJTechShow.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TheCJTechShow.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Event>? _events;
        private IGenericRepository<Vendor>? _vendors;
        private IGenericRepository<Organizer>? _organizers;
        private IGenericRepository<Visitor>? _visitors;
        private IGenericRepository<Sponsor>? _sponsors;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Event> Events
            => _events ??= new GenericRepository<Event>(_context);
        public IGenericRepository<Visitor> Visitors
            => _visitors ??= new GenericRepository<Visitor>(_context);
        public IGenericRepository<Vendor> Vendors
            => _vendors ??= new GenericRepository<Vendor>(_context);
        public IGenericRepository<Organizer> Organizers
            => _organizers ??= new GenericRepository<Organizer>(_context);
        public IGenericRepository<Sponsor> Sponsors
            => _sponsors ??= new GenericRepository<Sponsor>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            //foreach (var entry in entries)
          //  {
                //((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                //((BaseDomainModel)entry.Entity).UpdatedBy = user;
               // if (entry.State == EntityState.Added)
               // {
                 //   ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    //((BaseDomainModel)entry.Entity).CreatedBy = user;
               // }
          //  }

            await _context.SaveChangesAsync();
        }
    }
}