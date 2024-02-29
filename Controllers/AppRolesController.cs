using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using Microsoft.AspNetCore.Identity;
using HomeTravelAPI.ViewModels;
using HomeTravelAPI.Common;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRolesController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;
        private RoleManager<AppRole> _roleManager;

        public AppRolesController(HomeTravelDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }


        // GET: api/AppRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppRole>>> GetRole()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return Ok(new APIResult(Status:200,Message:"Success",Data:roles));
        }

        // GET: api/AppRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppRole>> GetAppRole(int id)
        {
            var appRole = await _context.Role.FindAsync(id);

            if (appRole == null)
            {
                return NotFound();
            }

            return appRole;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppRole(int id, AppRole appRole)
        {
            if (id != appRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(appRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppRoleExists(id))
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

        // POST: api/AppRoles
        [HttpPost]
        public async Task<ActionResult<AppRole>> PostAppRole(CreateRoleModel role)
        {
            if(await _roleManager.RoleExistsAsync(role.Name))
            {
                return BadRequest("Role existed");
            }
            await _roleManager.CreateAsync(new AppRole { Name = role.Name});
            return Ok(new APIResult(Status:200,Message:"Created success"));
        }

        // DELETE: api/AppRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppRole(int id)
        {
            var appRole = await _context.Role.FindAsync(id);
            if (appRole == null)
            {
                return NotFound();
            }

            _context.Role.Remove(appRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppRoleExists(int id)
        {
            return _context.Role.Any(e => e.Id == id);
        }
    }
}
