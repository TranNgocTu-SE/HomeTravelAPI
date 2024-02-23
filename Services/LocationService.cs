using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public async Task<List<LocationViewModel>> GetAll(LocationRequestViewModel locationRequestViewModel)
        {
            var filter = _mapper.Map<LocationRequestViewModel,LocationViewModel>(locationRequestViewModel);

            var responde = _context.Locations.Include(x => x.HomeStay).ProjectTo<LocationViewModel>(_mapper.ConfigurationProvider).DynamicFilter(filter).ToList();

            return responde;
        }
    }
}
