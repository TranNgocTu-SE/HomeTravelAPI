using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;

namespace HomeTravelAPI.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel model,AppUser user);
        Task<bool> Register(RegisterModel model);
    }
}
