using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using HomeTravelAPI.Common;
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
        private readonly IHostEnvironment _environment;

        public AppUsersController(HomeTravelDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signManager, IHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _signManager = signManager;
            _environment = environment;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUsers()
        {
            var users = await _context.AppUsers.ToListAsync();
            return Ok(new APIResult(Status:200,Message:"Success",Data:users));
        }

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
                updateUser.Avatar = await SaveImage(appUser.Avatar);
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
                updateUser.Avatar = await SaveImage(appUser.Avatar);
                _context.AppUsers.Update(updateUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new APIResult(Status: 500, Message: "Faile"));
            }

            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        private async void SaveImages(List<IFormFile> files)
        {
            FileStream sm;
            string imageUrl = null;
            foreach(IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string path = Path.Combine(_environment.ContentRootPath, $"images", file.FileName);
                    using (sm = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(sm);
                    }
                    sm = System.IO.File.Open(path, FileMode.Open);
                    imageUrl = await UploadFile.Upload(sm, file.FileName);
                    new ImageHome
                    {
                        ImageURL = imageUrl
                    };
                    await _context.SaveChangesAsync();
                }
            }
            
        }
        private async Task<string> SaveImage(IFormFile file)
        {
            FileStream sm;
            string imageUrl = null;
            if (file.Length > 0)
            {
                string path = Path.Combine(_environment.ContentRootPath, $"images", file.FileName);
                using (sm = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(sm);
                }
                sm = System.IO.File.Open(path, FileMode.Open);
                imageUrl = await UploadFile.Upload(sm, file.FileName);

            }
            return imageUrl;
        }


        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser([FromForm]CreateUserModel user)
        {

            FileStream sm;
            string imageUrl = null;
              if (user.Avatar.Length > 0)
              {
                string path = Path.Combine(_environment.ContentRootPath, $"images", user.Avatar.FileName);
                using(sm = new FileStream(path, FileMode.Create))
                {
                    await user.Avatar.CopyToAsync(sm);
                }
                sm = System.IO.File.Open(path, FileMode.Open);
                imageUrl = await UploadFile.Upload(sm, user.Avatar.FileName);

              }
            if (user.RoleName.Equals("Tourist")){
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
                    Avatar = imageUrl
                };
                await _userManager.CreateAsync(tourist, user.Password);
                await _userManager.AddToRoleAsync(tourist, user.RoleName);
            };

            if (user.RoleName.Equals("Owner")){
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
                await _userManager.CreateAsync(tourist, user.Password);
                await _userManager.AddToRoleAsync(tourist, user.RoleName);
            };

            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

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
