using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeStaysController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;

        public HomeStaysController(HomeTravelDbContext context)
        {
            _context = context;
        }

        // GET: api/HomeStays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeStay>>> GetHomeStays()
        {
            if(_context.HomeStays == null)
            {
                return NotFound();
            }
            var homestays = await _context.HomeStays.Include("Service").ToListAsync();
            return Ok(homestays);
        }

        // GET: api/HomeStays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeStay>> GetHomeStay(int id)
        {
            var homeStay = await _context.HomeStays.FindAsync(id);

            if (homeStay == null)
            {
                return NotFound();
            }

            return homeStay;
        }

        // PUT: api/HomeStays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeStay(int id, HomeStay homeStay)
        {
            if (id != homeStay.HomeStayId)
            {
                return BadRequest();
            }

            _context.Entry(homeStay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeStayExists(id))
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

        // POST: api/HomeStays
        [HttpPost]
        public async Task<ActionResult<HomeStay>> PostHomeStay(HomeStay homeStay)
        {
            _context.HomeStays.Add(homeStay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeStay", new { id = homeStay.HomeStayId }, homeStay);
        }

        // DELETE: api/HomeStays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeStay(int id)
        {
            var homeStay = await _context.HomeStays.FindAsync(id);
            if (homeStay == null)
            {
                return NotFound();
            }

            _context.HomeStays.Remove(homeStay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeStayExists(int id)
        {
            return _context.HomeStays.Any(e => e.HomeStayId == id);
        }
    }
}
