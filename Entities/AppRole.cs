using Microsoft.AspNetCore.Identity;

namespace HomeTravelAPI.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string Status { get; set; }
    }
}
