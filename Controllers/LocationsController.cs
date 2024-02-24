using HomeTravelAPI.Common;
using HomeTravelAPI.EF;
using HomeTravelAPI.Services;
using HomeTravelAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;
        private readonly IHomeStayService _homeStayService;
        private readonly ILocationService locationService;
        public LocationsController(HomeTravelDbContext context, IHomeStayService homeStayService, ILocationService locationService)
        {
            _context = context;
            _homeStayService = homeStayService;
            this.locationService = locationService;
        }
        [HttpGet("Location")]
        public async Task<ActionResult<IEnumerable<LocationViewModel>>> GetAllLocation([FromQuery] LocationRequestViewModel locationRequestViewModel)
        {
            var result = await locationService.GetAll(locationRequestViewModel, locationRequestViewModel.totalTourist);
            if (result == null)
            {
                return BadRequest("Error server");
            }
            return Ok(new APIResult(Status: 200, Message: "Success", Data: result));
        }
    }
}
