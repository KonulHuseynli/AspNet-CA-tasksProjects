using Web.ViewModels.Account;

namespace Web.Services.Abstract
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AccountRegisterVM model);

        Task<bool> LoginAsync(AccountLoginVM model);

        Task Logout();
    }
}
