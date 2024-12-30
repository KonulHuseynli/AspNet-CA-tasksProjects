using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace FlowerProjectP323.ViewModel.Account
{
    public class AccountRegisterViewModel
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required ,MaxLength(100) ,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
      
        public string UserName { get; set; }
        [Required,MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(100), DataType(DataType.Password), Display(Name = "Confirm Password"), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
//autheriziytion register o biri login