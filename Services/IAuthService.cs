using HomeTravelAPI.ViewModels;

namespace HomeTravelAPI.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel model);
        Task<bool> Register(RegisterModel model);
    }
}
