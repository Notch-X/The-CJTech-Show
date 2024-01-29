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
    public class VisitorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<IActionResult> GetVisitors()
        {
            var visitors = await _unitOfWork.Visitors.GetAll();
            return Ok(visitors);
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitor(int id)
        {
            var visitor = await _unitOfWork.Visitors.Get(q => q.Id == id);

            if (visitor == null)
            {
                return NotFound();
            }

            return Ok(visitor);
        }

        // PUT: api/Visitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitor(int id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Visitors.Update(visitor);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VisitorExists(id))
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

        // POST: api/Visitors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            await _unitOfWork.Visitors.Insert(visitor);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVisitor", new { id = visitor.Id }, visitor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _unitOfWork.Visitors.Get(q => q.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            await _unitOfWork.Visitors.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> VisitorExists(int id)
        {
            var visitor = await _unitOfWork.Visitors.Get(q => q.Id == id);
            return visitor != null;
        }
    }
}
