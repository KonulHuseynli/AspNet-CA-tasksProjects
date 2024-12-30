using Microsoft.AspNetCore.Mvc;
using Web.Attributes;
using Web.Services.Abstract;
using Web.ViewModels.Account;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [OnlyAnonymous]

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterVM model)
        {

            var isSucceeded = await _accountService.RegisterAsync(model);

            if (isSucceeded) return RedirectToAction("login");

            return View(model);
        }

        [OnlyAnonymous]

        [HttpGet]

        public  IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginVM model)
        {
            var isSucceeded = await _accountService.LoginAsync(model);
            if (isSucceeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                else
                    return RedirectToAction("index", "home");
            }
            return View(model);

        }


        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();


            return RedirectToAction(nameof(Login));

        }

    }
}
