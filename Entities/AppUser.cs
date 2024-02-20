using Microsoft.AspNetCore.Identity;

namespace HomeTravelAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string CartNumber { get; set; }
        public string NameOnCart { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }

        //

    }
}
