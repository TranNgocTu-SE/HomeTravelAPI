﻿using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeTravelAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<AppUser> userManage, IConfiguration configuration)
        {
            _userManager = userManage;
            _configuration = configuration;
        }

       
        public async Task<string> Login(LoginModel model,AppUser user)
        {
            string tokenString = null;
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new[]
                {
                new Claim("Email",user.Email),
                new Claim("Name",model.UserName),
                new Claim("Role",string.Join(";",roles)),
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Token:Issuer"],
                    _configuration["Token:Audience"],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds
                    );

                tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            }

            return tokenString;
        }

        public async Task<bool> Register(RegisterModel model)
        {
            var identityUser = new AppUser { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName,Gender = model.Gender, Email = model.Email};

            var result = await _userManager.CreateAsync(identityUser, model.Password);
            return result.Succeeded;
        }
    }
}
