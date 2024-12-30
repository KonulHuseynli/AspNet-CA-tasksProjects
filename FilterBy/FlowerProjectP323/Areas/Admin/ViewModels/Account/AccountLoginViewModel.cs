using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace FlowerProjectP323.Areas.Admin.ViewModels.Account
{
	public class AccountLoginViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required,DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
