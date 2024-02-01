using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCJTechShow.Server.Data;
using TheCJTechShow.Shared.Domain;
using TheCJTechShow.Server.IRepository;

namespace TheCJTechShow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactored
        //public EventsController(ApplicationDbContext context)
        public EventsController(IUnitOfWork unitOfWork)
        {
            //refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Events
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        public async Task<IActionResult> GetEvents()
        {
            //refactored
            //return await _context.Events.ToListAsync();
            var eventModel = await _unitOfWork.Events.GetAll();
            return Ok(eventModel);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Event>> GetEvent(int id)
        public async Task<IActionResult> GetEvent(int id)
        {
            //refactored
            //var @event = await _context.Events.FindAsync(id);
            var eventModel = await _unitOfWork.Events.Get(q => q.ID == id);

            if (eventModel == null)
            {
                return NotFound();
            }

            //refactored
            return Ok(eventModel);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event eventModel)
        {
            if (id != eventModel.ID)
            {
                return BadRequest();
            }

            //refactored
            //_context.Entry(@event).State = EntityState.Modified;
            _unitOfWork.Events.Update(eventModel);

            try
            {
                //refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //refactored
                //if (!EventExists(id))
                if (!await EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event eventModel)
        {
            //refactored
            //_context.Events.Add(@event);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Events.Insert(eventModel);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetEvent", new { id = eventModel.ID }, eventModel);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            //refactored
            //var @event = await _context.Events.FindAsync(id);
            var eventModel = await _unitOfWork.Events.Get(q => q.ID == id);
            if (eventModel == null)
            {
                return NotFound();
            }
            //refactored
            //_context.Events.Remove(@event);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Events.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //refactored
        //private bool EventExists(int id)
        private async Task<bool> EventExists(int id)
        {
            //refactored
            //return _context.Events.Any(e => e.Id == id);
            var eventModel = await _unitOfWork.Events.Get(q => q.ID == id);
            return eventModel != null;
        }
    }
}