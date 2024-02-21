using HomeTravelAPI.Entities;
using HomeTravelAPI.Services;
using HomeTravelAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManage,IAuthService authService)
        {
            _userManager = userManage;
            _authService = authService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (await _authService.Register(model))
            {
                return Ok("success");
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is null)
            {
                return NotFound();
            }
            var token = await _authService.Login(model, user);

            if (token is null)
            {
                return BadRequest("faile");
            }
            return Ok( new {user,token});
        }
    }
}
