using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Account
{
    public class AccountRegisterVM
    {

        [EmailAddress]
        [Required, MaxLength(100), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }


        [Required, MaxLength(100)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(100), DataType(DataType.Password), Display(Name = "Confirm Password"), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
