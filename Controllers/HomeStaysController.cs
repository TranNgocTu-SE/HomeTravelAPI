using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.Services;
using HomeTravelAPI.ViewModels;
using HomeTravelAPI.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeStaysController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;
        private readonly IHomeStayService _homeStayService;

        public HomeStaysController(HomeTravelDbContext context, IHomeStayService homeStayService)
        {
            _context = context;
            _homeStayService = homeStayService;
        }


        // GET: api/HomeStays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeStay>>> GetAllHomeStays()
        {
            var result = await _homeStayService.GetAll();
            if (result == null)
            {
                return BadRequest("Error server");
            }
            return Ok(new APIResult(Status:200,Message:"Success",Data:result));
        }

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

        [HttpPost]
        public async Task<ActionResult<HomeStay>> PostHomeStay(CreateHomeStayModel homeStay)
        {
            await _homeStayService.Create(homeStay);
            return Ok(new APIResult(Status : 201, Message : "Created success" ));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeStay(int id)
        {
            var result = await _homeStayService.Delete(id);
            if (result == 0)
                return NotFound(new APIResult(Status: 404, Message: "Not found homestay"));
            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        private bool HomeStayExists(int id)
        {
            return _context.HomeStays.Any(e => e.HomeStayId == id);
        }
    }
}
