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

      
        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            var Vendors = await _unitOfWork.Vendors.GetAll();
            return Ok(Vendors);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var @Vendor = await _unitOfWork.Vendors.Get(q => q.ID == id);

            if (@Vendor == null)
            {
                return NotFound();
            }

            return Ok(@Vendor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor @Vendor)
        {
            if (id != @Vendor.ID)
            {
                return BadRequest();
            }

            _unitOfWork.Vendors.Update(@Vendor);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VendorExists(id))
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
        public async Task<ActionResult<Vendor>> PostVendor(Vendor @Vendor)
        {
            await _unitOfWork.Vendors.Insert(@Vendor);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVisitor", new { id = @Vendor.ID}, @Vendor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var @Vendor = await _unitOfWork.Vendors.Get(q => q.ID == id);
            if (@Vendor == null)
            {
                return NotFound();
            }

            await _unitOfWork.Vendors.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> VendorExists(int id)
        {
            var @Vendor = await _unitOfWork.Vendors.Get(q => q.ID == id);
            return @Vendor != null;
        }
    }
}