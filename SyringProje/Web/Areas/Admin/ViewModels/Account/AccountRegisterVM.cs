using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Account
{
    public class AccountRegisterVM
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(100), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserName { get; set; }
        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(100), DataType(DataType.Password), Display(Name = "Confirm Password"), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        
        public int Age { get; set; }
    }
}
