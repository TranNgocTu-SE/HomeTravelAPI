using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.Utilities;

namespace HomeTravelAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly HomeTravelDbContext _context;
        private readonly IMapper _mapper;

        public LocationService(HomeTravelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<LocationViewModel>> GetAll(LocationRequestViewModel locationRequestViewModel, int totalTourist)
        {
            var filter = _mapper.Map<LocationRequestViewModel, LocationViewModel>(locationRequestViewModel);

            var query = _context.Locations.Include(l => l.HomeStay).AsQueryable();

            if (!string.IsNullOrEmpty(filter.CityName))
            {
                query = query.Where(l => l.CityName == filter.CityName);
            }
            if (!string.IsNullOrEmpty(filter.DistrictName))
            {
                query = query.Where(l => l.DistrictName == filter.DistrictName);
            }
            if (!string.IsNullOrEmpty(filter.ProvinceName))
            {
                query = query.Where(l => l.ProvinceName == filter.ProvinceName);
            }

            query = query.Where(l => l.HomeStay.TotalCapacity >= totalTourist);

            var response = await query.ProjectTo<LocationViewModel>(_mapper.ConfigurationProvider).ToListAsync();

            return response;
        }
    }
}
