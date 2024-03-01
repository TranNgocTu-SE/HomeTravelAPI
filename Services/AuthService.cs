using Firebase.Auth;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
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
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,model.UserName),
                new Claim(ClaimTypes.Role,string.Join(";",roles)),
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

        public async Task<bool> Register(RegisterModel model, string roleName)
        {
            if(roleName.Equals("Tourist"))
            {
                var tourist = new Tourist
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Gender = model.Gender,
                    Email = model.Email,
                    NameOnCart = model.NameOnCard,
                    CartNumber = model.CardNumber,
                    SecurityCode = model.SecurityCode,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await _userManager.CreateAsync(tourist, model.Password);
                await _userManager.AddToRoleAsync(tourist, roleName);
            }
            else if (roleName.Equals("Owner"))
            {
                var owner = new Owner
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Gender = model.Gender,
                    Email = model.Email,
                    NameBank = model.NameBank,
                    NumberBank = model.NumberBank,
                    AccountName = model.AccountName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await _userManager.CreateAsync(owner, model.Password);
                await _userManager.AddToRoleAsync(owner, roleName);
            }
           
            
            return true;
        }
    }
}
