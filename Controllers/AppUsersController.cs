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
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Firebase.Auth;

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
        public async Task<IActionResult> PutAppUser(int id, CreateUserModel appUser)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound();
            }

            var role = await _userManager.GetRolesAsync(user);

            if (role[0].Equals("Tourist"))
            {
                var updateUser = await _context.AppUsers.OfType<Tourist>().FirstOrDefaultAsync();
                updateUser.UserName = appUser.UserName;
                updateUser.FirstName = appUser.FirstName;
                updateUser.LastName = appUser.LastName;
                updateUser.Email = appUser.Email;
                updateUser.PhoneNumber = appUser.Phone;
                updateUser.Gender = appUser.Gender;
                updateUser.CartNumber = appUser.CardNumber;
                updateUser.NameOnCart = appUser.NameOnCard;
                updateUser.SecurityCode = appUser.SecurityCode;
                _context.AppUsers.Update(updateUser);
                await _context.SaveChangesAsync();
            }
            else if (role[0].Equals("Owner"))
            {
                var updateUser = await _context.AppUsers.OfType<Owner>().FirstOrDefaultAsync();
                updateUser.UserName = appUser.UserName;
                updateUser.FirstName = appUser.FirstName;
                updateUser.LastName = appUser.LastName;
                updateUser.Email = appUser.Email;
                updateUser.PhoneNumber = appUser.Phone;
                updateUser.Gender = appUser.Gender;
                updateUser.NameBank = appUser.NameBank;
                updateUser.NumberBank = appUser.NumberBank;
                updateUser.AccountName = appUser.AccountName;
                _context.AppUsers.Update(updateUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new APIResult(Status: 500, Message: "Faile"));
            }

            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        // POST: api/AppUsers
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(string roleName,CreateUserModel user,string password)
        {
            if (roleName.Equals("Tourist")){
                var tourist = new Tourist
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.Phone,
                    Gender = user.Gender,
                    CartNumber = user.CardNumber,
                    NameOnCart = user.NameOnCard,
                    SecurityCode = user.SecurityCode,
                };
                await _userManager.CreateAsync(tourist,password);
                await _userManager.AddToRoleAsync(tourist, roleName);
            };

            if (roleName.Equals("Owner")){
                var tourist = new Owner
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.Phone,
                    Gender = user.Gender,
                    NameBank = user.NameBank,
                    NumberBank = user.NumberBank,
                    AccountName = user.AccountName,
                };
                await _userManager.CreateAsync(tourist, password);
                await _userManager.AddToRoleAsync(tourist, roleName);
            };

            return Ok(new APIResult(Status: 200, Message: "Success"));
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
            return Ok(new APIResult(Status: 200, Message: "Deleted Success"));
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
