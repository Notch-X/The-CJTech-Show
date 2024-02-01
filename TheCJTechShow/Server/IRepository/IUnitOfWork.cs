using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TheCJTechShow.Server.IRepository;
using TheCJTechShow.Shared.Domain;

namespace TheCJTechShow.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Event> Events { get; }
        IGenericRepository<Visitor> Visitors { get; }
        IGenericRepository<Vendor> Vendors { get; }
        IGenericRepository<Sponsor> Sponsors { get; }
        IGenericRepository<Organizer> Organizers { get; }
    }
}
