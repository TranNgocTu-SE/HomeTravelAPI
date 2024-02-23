using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;

namespace HomeTravelAPI.Services
{
    public interface IHomeStayService
    {
        Task<List<HomeStay>> GetAll();
        Task<int> Create(CreateHomeStayModel model);

        Task<UpdateHomeStayModel> Update(UpdateHomeStayModel model);

        Task<int> Delete(int homeStayId);

        Task<HomeStay> GetById(int homeStayId);
    }
}
