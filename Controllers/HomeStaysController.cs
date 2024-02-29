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
            var homeStay = await _homeStayService.GetById(id);

            if (homeStay == null)
            {
                return NotFound();
            }

            return Ok(new APIResult(Status: 200, Message: "Success", Data: homeStay));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHomeStay(int id,[FromBody]CreateHomeStayModel home)
        {
            var homestay = await _context.HomeStays.FirstOrDefaultAsync(x => x.HomeStayId == id);

            if (homestay == null)
            {
                return BadRequest("Not Found");
            }
            homestay.HomeStayName = home.HomeStayName;
            homestay.Description = home.Description;
            homestay.Acreage = home.Acreage;
            homestay.TotalCapacity = home.TotalCapacity;
            _context.HomeStays.Update(homestay);
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status: 200, Message: "Updated success"));
        }

        [HttpPost]
        public async Task<ActionResult<HomeStay>> PostHomeStay(CreateHomeStayModel homeStay)
        {
            var rerult = await _homeStayService.Create(homeStay);
            if(rerult == 0)
            {
                return BadRequest("Created Faile");
            }
            return Ok(new APIResult(Status : 200, Message : "Created success",Data: new { id = rerult}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeStay(int id)
        {
            var result = await _homeStayService.Delete(id);
            if (result == 0)
            {
                return NotFound(new APIResult(Status: 404, Message: "Not found homestay"));
            }
            return Ok(new APIResult(Status: 200, Message: "Success"));
        }
    }
}
