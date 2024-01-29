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
    public class VendorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<IActionResult> GetVisitors()
        {
            var Visitors = await _unitOfWork.Visitors.GetAll();
            return Ok(Visitors);
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitor(int id)
        {
            var @Visitor = await _unitOfWork.Visitors.Get(q => q.Id == id);

            if (@Visitor == null)
            {
                return NotFound();
            }

            return Ok(@Visitor);
        }

        // PUT: api/Visitors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitor(int id, Visitor @Visitor)
        {
            if (id != @Visitor.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Visitors.Update(@Visitor);

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
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor @Visitor)
        {
            await _unitOfWork.Visitors.Insert(@Visitor);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVisitor", new { id = @Visitor.Id }, @Visitor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var @Visitor = await _unitOfWork.Visitors.Get(q => q.Id == id);
            if (@Visitor == null)
            {
                return NotFound();
            }

            await _unitOfWork.Visitors.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> VisitorExists(int id)
        {
            var @Visitor = await _unitOfWork.Visitors.Get(q => q.Id == id);
            return @Visitor != null;
        }
    }
}
