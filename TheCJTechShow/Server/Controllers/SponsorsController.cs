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
    public class SponsorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SponsorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Sponsors
        [HttpGet]
        public async Task<IActionResult> GetSponsors()
        {
            var sponsors = await _unitOfWork.Sponsors.GetAll();
            return Ok(sponsors);
        }

        // GET: api/Sponsors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSponsor(int id)
        {
            var sponsor = await _unitOfWork.Sponsors.Get(q => q.Id == id);

            if (sponsor == null)
            {
                return NotFound();
            }

            return Ok(sponsor);
        }

        // PUT: api/Sponsors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSponsor(int id, Sponsor sponsor)
        {
            if (id != sponsor.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Sponsors.Update(sponsor);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SponsorExists(id))
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

        // POST: api/Sponsors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sponsor>> PostSponsor(Sponsor sponsor)
        {
            await _unitOfWork.Sponsors.Insert(sponsor);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSponsor", new { id = sponsor.Id }, sponsor);
        }

        // DELETE: api/Sponsors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSponsor(int id)
        {
            var sponsor = await _unitOfWork.Sponsors.Get(q => q.Id == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            await _unitOfWork.Sponsors.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> SponsorExists(int id)
        {
            var sponsor = await _unitOfWork.Sponsors.Get(q => q.Id == id);
            return sponsor != null;
        }
    }
}
