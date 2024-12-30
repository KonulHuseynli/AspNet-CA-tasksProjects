
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Account
{
    public class AccountLoginVM
    {
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
