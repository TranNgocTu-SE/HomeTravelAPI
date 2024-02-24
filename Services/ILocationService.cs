using HomeTravelAPI.ViewModels;

namespace HomeTravelAPI.Services
{
    public interface ILocationService
    {
        public Task<List<LocationViewModel>> GetAll(LocationRequestViewModel locationRequestViewModel, int totalTourist);
    }
}
