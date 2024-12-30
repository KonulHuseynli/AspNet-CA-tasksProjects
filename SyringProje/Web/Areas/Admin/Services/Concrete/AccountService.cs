using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Services.Abstract;
using WebApp.ViewModels.Account;

namespace WebApp.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ModelStateDictionary _modelState;

        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IActionContextAccessor actionContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<bool> LoginAsync(AccountLoginVM model)
        {
            if (!_modelState.IsValid) return false;
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                _modelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                _modelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return false;
            }
            return true;
        }

        public async Task<bool> RegisterAsync(AccountRegisterVM model)
        {
            if (!_modelState.IsValid) return false;
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _modelState.AddModelError(string.Empty, error.Description);
                }
                return false;
            }
            return true;

        }
    }
}
