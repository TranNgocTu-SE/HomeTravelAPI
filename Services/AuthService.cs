using HomeTravelAPI.Entities;
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

        public Task<string> GenerateTokenString(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(LoginModel model)
        {
            string tokenString = null;
            var AppUser = await _userManager.FindByNameAsync(model.UserName);
            if (AppUser is null)
            {
                return null;
            }
            var result = await _userManager.CheckPasswordAsync(AppUser, model.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(AppUser);
                var claims = new[]
                {
                new Claim("Email",AppUser.Email),
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
            var identityUser = new AppUser { UserName = model.UserName, Email = model.Email };

            var result = await _userManager.CreateAsync(identityUser, model.Password);
            return result.Succeeded;
        }
    }
}
