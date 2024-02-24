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
    public class RoomsController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;

        public RoomsController(HomeTravelDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(new APIResult(Status: 200, Message: "Success",Data:room));
        }

        // PUT: api/Rooms/5
        [HttpPut]
        public async Task<IActionResult> PutRoom(int roomId, CreateRoomModel room)
        {
            var r = await _context.Rooms.FindAsync(roomId);
            if (r == null)
            {
                return NotFound();
            }

            r.RoomName = room.RoomName;
            r.NumberOfBeds = room.NumberOfBeds;
            r.NumberOfPeople = room.NumberOfPeople;
            r.Length = room.Length;
            r.Width = room.Width;
            r.Price = room.Price;
            r.Description = room.Description;
            r.Status = room.Status;

            _context.Rooms.Update(r);
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status: 200, Message: "Updated success"));
        }

        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(int homeStayId,CreateRoomModel room)
        {
           var homestay = await _context.HomeStays.FindAsync(homeStayId);
            if(homestay == null)
            {
                return NotFound();
            }
            var r = new Room
            {
                RoomName = room.RoomName,
                NumberOfBeds = room.NumberOfBeds,
                NumberOfPeople = room.NumberOfPeople,
                Length = room.Length,
                Width = room.Width,
                Price = room.Price,
                Description = room.Description,
                Status = room.Status,
                HomeStayId = homestay.HomeStayId
            };
            await _context.Rooms.AddAsync(r);
            await _context.SaveChangesAsync();

            return Ok(new APIResult(Status: 200, Message: "Created success"));
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return Ok(new APIResult(Status:200,Message:"Deleted success"));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
