using NTQ.Sdk.Core.Attributes;

namespace HomeTravelAPI.ViewModels
{
    public class LocationRequestViewModel
    {
        public string? CityName { get; set; }
        public string? DistrictName { get; set; }
        public string? ProvinceName { get; set; }
        public int TotalTourist { get; set; }
    }
}
