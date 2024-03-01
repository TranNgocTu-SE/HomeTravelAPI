using System.ComponentModel.DataAnnotations;

namespace HomeTravelAPI.ViewModels
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string NameBank { get; set; }
        public string NumberBank { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
