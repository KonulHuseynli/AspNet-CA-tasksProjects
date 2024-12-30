using Web.Areas.Admin.ViewModels.Account;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(AccountLoginVM model);

    }
}
