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
        private readonly IImageService _imageService;

        public AppUsersController(HomeTravelDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signManager, IHostEnvironment environment, IImageService imageService)
        {
            _context = context;
            _userManager = userManager;
            _signManager = signManager;
            _environment = environment;
            _imageService = imageService;
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
            var appUser = await _userManager.FindByIdAsync(id.ToString());

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,UpdateUserModel appUser)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound();
            }

            var role = await _userManager.GetRolesAsync(user);

            if (role[0].Equals("Tourist"))
            {
                var tourist = await _userManager.FindByIdAsync(id.ToString()) as Tourist;
                tourist.UserName = (string.IsNullOrEmpty(appUser.UserName) ? tourist.UserName : appUser.UserName);
                tourist.FirstName = (string.IsNullOrEmpty(appUser.FirstName) ? tourist.FirstName : appUser.FirstName);
                tourist.LastName = (string.IsNullOrEmpty(appUser.LastName) ? tourist.LastName : appUser.LastName); 
                tourist.Email = (string.IsNullOrEmpty(appUser.Email) ? tourist.Email : appUser.Email);
                tourist.PhoneNumber = (string.IsNullOrEmpty(appUser.Phone) ? tourist.PhoneNumber : appUser.Phone);
                tourist.Gender = (string.IsNullOrEmpty(appUser.Gender) ? tourist.Gender : appUser.Gender);
                tourist.CartNumber = (string.IsNullOrEmpty(appUser.CardNumber) ? tourist.CartNumber : appUser.CardNumber);
                tourist.NameOnCart = (string.IsNullOrEmpty(appUser.NameOnCard) ? tourist.NameOnCart : appUser.NameOnCard);
                tourist.SecurityCode = (string.IsNullOrEmpty(appUser.SecurityCode) ? tourist.SecurityCode : appUser.SecurityCode);
                await _userManager.UpdateAsync(tourist); 
            }
            else if (role[0].Equals("Owner"))
            {
                var owner = await _userManager.FindByIdAsync(id.ToString()) as Owner;
                owner.UserName = appUser.UserName;
                owner.FirstName = appUser.FirstName;
                owner.LastName = appUser.LastName;
                owner.Email = appUser.Email;
                owner.PhoneNumber = appUser.Phone;
                owner.Gender = appUser.Gender;
                owner.NameBank = appUser.NameBank;
                owner.NumberBank = appUser.NumberBank;
                owner.AccountName = appUser.AccountName;
                await _userManager.UpdateAsync(owner);
            } 
            else if (role[0].Equals("Admin"))
                {
                    user.UserName = appUser.UserName;
                    user.FirstName = appUser.FirstName;
                    user.LastName = appUser.LastName;
                    user.Email = appUser.Email;
                    user.PhoneNumber = appUser.Phone;
                    user.Gender = appUser.Gender;
                    await _userManager.UpdateAsync(user);
                }
            else
            {
                return BadRequest(new APIResult(Status: 500, Message: "Faile"));
            }

            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        [HttpPut("UpdateImage/{id}")]
        public async Task<IActionResult> UpdateImage(int id, IFormFile image)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            user.Avatar = _imageService.UploadImageToAzure(image);
            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status: 200, Message: "Success"));
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
        public async Task<ActionResult<AppUser>> PostAppUser(CreateUserModel user)
        {
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
                    Avatar = _imageService.UploadImageToAzure(user.Avatar)
                };
                await _userManager.CreateAsync(tourist, user.Password);
                
                await _userManager.AddToRoleAsync(tourist, user.RoleName);
            };
            if (user.RoleName.Equals("Admin"))
            {
                var u = new AppUser
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.Phone,
                    Gender = user.Gender,
                    Avatar = _imageService.UploadImageToAzure(user.Avatar)
                };
                await _userManager.CreateAsync(u, user.Password);
                await _userManager.AddToRoleAsync(u, user.RoleName);
            };

            if (user.RoleName.Equals("Owner")){
                var owner = new Owner
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
                    Avatar = _imageService.UploadImageToAzure(user.Avatar)
                };
                await _userManager.CreateAsync(owner, user.Password);
                await _userManager.AddToRoleAsync(owner, user.RoleName);
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
            IList<string> role = await _userManager.GetRolesAsync(user);
            return Ok(new APIResult(Status:200,Message:"Success",Data:user));
        }
    }
}
