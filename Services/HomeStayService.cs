using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HomeTravelAPI.Services
{
    public class HomeStayService : IHomeStayService
    {
        private readonly HomeTravelDbContext _context;

        public HomeStayService(HomeTravelDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CreateHomeStayModel model)
        {
            var homestay = new HomeStay
            {
                HomeStayId = model.HomeStayId,
                HomeStayName = model.HomeStayName,
                Description = model.Description,
                Acreage = model.Acreage,
                TotalCapacity = model.TotalCapacity,
            };
            var result = await _context.HomeStays.AddAsync(homestay);
            await _context.SaveChangesAsync();
            return homestay.HomeStayId;
        }

       

      
        public async Task<int> Delete(int homeStayId)
        {
            var homestay = await _context.HomeStays.FindAsync(homeStayId);
            if (homestay == null)
            {
                return 0;
            }
            homestay.IsDeleted = true;
            _context.Update(homestay);
            await _context.SaveChangesAsync();
            return homestay.HomeStayId;
        }

        public async Task<List<HomeStay>> GetAll()
        {
            var homestays = await _context.HomeStays.Include(x => x.Location).Include(x => x.Policy)
                .Include(x => x.ImageHomes).Include(x => x.Services).Include(x => x.Rooms)
                .ToListAsync();

            return homestays;
        }

        public async Task<HomeStay> GetById(int homeStayId)
        {
            var homestay = await _context.HomeStays.FindAsync(homeStayId);
            if (homestay == null)
            {
                return null;
            }
            return homestay;
        }

        public Task<UpdateHomeStayModel> Update(UpdateHomeStayModel model)
        {
            throw new NotImplementedException();
        }

    /*    public async Task<(DateTime? RentalStartDate, DateTime? RentalEndDate)> GetBookingDatesForRoom(int RoomId)
        {
            var booking = await _context.Bookings
                .Where(b => b.RoomId == RoomId && (b.Status == "đang được đặt" || b.Status == "đang ở"))
                .OrderByDescending(b => b.RentalStartDate)
                .FirstOrDefaultAsync();

            if (booking != null)
            {
                return (booking.RentalStartDate, booking.RentalEndDate);
            }
            else
            {
                return (null, null);
            }
        }*/
    }
}
