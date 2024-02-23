using AutoMapper;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;

namespace HomeTravelAPI.Mapping
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<LocationRequestViewModel, LocationViewModel>().ReverseMap();
            CreateMap<LocationRequestViewModel, Location>().ReverseMap();
            CreateMap<LocationViewModel, Location>().ReverseMap();
        }
    }
}
