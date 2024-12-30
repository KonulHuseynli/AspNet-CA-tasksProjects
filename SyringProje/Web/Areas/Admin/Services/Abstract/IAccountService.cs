using WebApp.ViewModels.Account;

namespace WebApp.Services.Abstract
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AccountRegisterVM model);
        Task<bool>LoginAsync(AccountLoginVM model);
    }
}
