﻿using AutoMapper;
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
        public async Task<List<LocationViewModel>> GetAll(LocationRequestViewModel locationRequestViewModel, PagingViewModel pagingViewModel)
        {
            var filter = _mapper.Map<LocationRequestViewModel, LocationViewModel>(locationRequestViewModel);
            filter.SortDirection = pagingViewModel.SortDirection;
            filter.SortProperty = pagingViewModel.SortProperty;
            IQueryable<Location> query;

            if(locationRequestViewModel.LocationField != null)
            {
                query = _context.Locations.Include(l => l.HomeStay).Where(x => x.CityName.Equals(locationRequestViewModel.LocationField)
         || x.DistrictName.Equals(locationRequestViewModel.LocationField)
         || x.ProvinceName.Equals(locationRequestViewModel.LocationField));
            }

            else query = _context.Locations.Include(l => l.HomeStay);

            query = query.Where(l => l.HomeStay.TotalCapacity >= locationRequestViewModel.TotalTourist);

            var response = await query.ProjectTo<LocationViewModel>(_mapper.ConfigurationProvider).DynamicSort(filter).PagingQueryable(pagingViewModel.Page, pagingViewModel.PageSize).Item2.ToListAsync();

            return response;
        }
    }
}
