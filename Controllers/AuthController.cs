﻿using HomeTravelAPI.Common;
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
        private readonly IMailService _mailService;

        public AuthController(IAuthService authService, UserManager<AppUser> userManager, IMailService mailService)
        {
            _authService = authService;
            _userManager = userManager;
            _mailService = mailService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model, string roleName = "Tourist")
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (await _authService.Register(model,roleName))
            {
                return Ok(new APIResult(Status: 200, Message: "Success"));
            }
            return BadRequest(ModelState);
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

            await _mailService.SendMail(user.Email,"Login success");
            var account = new {Id = user.Id,UserName=user.UserName,FirstName=user.FirstName,LastName=user.LastName,Email=user.Email,Phone=user.PhoneNumber,Status=user.Status,Token = token};
            return Ok( new APIResult(Status: 200,Message:"Login success",Data : account));
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return BadRequest("Not Found User");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Auth", new { token, email = user.Email }, Request.Scheme);
            var message = "Confirm link:" + link;
            await _mailService.SendMail(user.Email,message);
            return Ok(new APIResult(Status: 200, Message: "Open email and confirm"));

        }
    }
}
