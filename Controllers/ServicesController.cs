using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using HomeTravelAPI.Common;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;

        public ServicesController(HomeTravelDbContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<List<Service>> GetService(int homeStayId)
        {
            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Service>> PostService(CreateServiceModel model)
        {
            var service = new Service
            {
                ServiceName = model.ServiceName,
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status:200,Message:"Created success"));
        }


        [HttpPost("homeStayService")]
        public async Task<ActionResult<Service>> CreateService(int homeStayId, List<CreateServiceModel> list)
        {
            var homeStay = await _context.HomeStays.FirstOrDefaultAsync(x => x.HomeStayId == homeStayId);
           
            if (homeStay == null)
            {
                return NotFound();
            }
            foreach(CreateServiceModel sv in list)
            {
                var s = new Service
                {
                    ServiceName = sv.ServiceName,
                };
            }
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status: 200, Message: "Success", Data: homeStay));
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}
