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
using System.Security;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authorization;
using HomeTravelAPI.Common;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;

        public AppUsersController(HomeTravelDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUsers()
        {
            var users = await _context.AppUsers.ToListAsync();
            return Ok(new APIResult(Status:200,Message:"Success",Data:users));
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

                await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsers
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());
            if (appUser == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Authorize]
        [HttpGet("currentUser")]
        public async Task<IActionResult> AppUserExists()
        {
            AppUser user= await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            return Ok(user);
        }
    }
}
