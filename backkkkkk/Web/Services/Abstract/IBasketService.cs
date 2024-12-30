using System.Threading.Tasks;
using Web.ViewModels.Basket;

namespace Web.Services.Abstract
{
    public interface IBasketService
    {

        Task<BasketIndexVM> GetAsync();

        Task<bool> Add(BasketAddVm model);
        Task<bool> DeleteBasketProduct(int productId);

        Task<bool> UpCount(int productId);
        Task<bool> DownCount(int productId);

        Task<bool> ClearBasketProduct();
    }
}
