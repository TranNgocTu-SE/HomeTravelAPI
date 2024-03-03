using HomeTravelAPI.Entities;
using NTQ.Sdk.Core.Attributes;
using NTQ.Sdk.Core.ViewModels;

namespace HomeTravelAPI.ViewModels
{
    public class LocationViewModel : SortModel
    {
        public int LocationId { get; set; }
        
        public string? CityName { get; set; }
       
        public string? DistrictName { get; set; }
       
        public string? ProvinceName { get; set; }
        public string? StreetName { get; set; }
        public string? NumberHome { get; set; }
        //
        public int? HomeStayId { get; set; }
    }
}
