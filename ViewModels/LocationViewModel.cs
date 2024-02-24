using HomeTravelAPI.Entities;
using NTQ.Sdk.Core.Attributes;

namespace HomeTravelAPI.ViewModels
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        [StringAttribute]
        public string? CityName { get; set; }
        [StringAttribute]
        public string? DistrictName { get; set; }
        [StringAttribute]
        public string? ProvinceName { get; set; }
        public string? StreeName { get; set; }
        public string? NumberHome { get; set; }
        //
        public int? HomeStayId { get; set; }
    }
}
