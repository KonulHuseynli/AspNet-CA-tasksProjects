using Core.Constants;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.Account;

namespace Web.Areas.Admin.Services.Concrete
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<User> _userManager; 
        private readonly SignInManager<User> _signInManager; 
        private readonly ModelStateDictionary _modelState;

        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager, IActionContextAccessor actionContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<bool> LoginAsync(AccountLoginVM model)
        {
            if (!_modelState.IsValid) return false;

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                _modelState.AddModelError(string.Empty, "Username or Password is false");
                return false;
            }
            if (!await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                _modelState.AddModelError(string.Empty, "Username or Password is false!");
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                _modelState.AddModelError(string.Empty, "Username or Password is false");
                return false;
            }

            return true;
        }
    }
}
