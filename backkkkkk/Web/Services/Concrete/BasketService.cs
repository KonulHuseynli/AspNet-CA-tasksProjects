using Core.Entities;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Services.Abstract;
using Web.ViewModels.Basket;

namespace Web.Services.Concrete
{
    public class BasketService:IBasketService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketProductRepository _basketProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public BasketService(IBasketRepository basketRepository,
            IBasketProductRepository basketProductRepository,
            IProductRepository productRepository,
            IActionContextAccessor actionContextAccessor,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _basketRepository = basketRepository;
            _basketProductRepository = basketProductRepository;
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<BasketIndexVM> GetAsync()
        {


            var basket = await _basketRepository.GetBasket(_httpContextAccessor.HttpContext.User);

            var model = new BasketIndexVM();

            if (basket == null) return model;

            foreach (var dbBasketProduct in basket.BasketProducts)
            {
                var basketProduct = new BasketProductVM
                {
                    Id = dbBasketProduct.Id,
                    Title = dbBasketProduct.Product.Title,
                    Quantity = dbBasketProduct.Quantity,
                    PhotoName = dbBasketProduct.Product.PhotoName,
                };
                model.BasketProducts.Add(basketProduct);
            }
            return model;
        }


        public async Task<bool> Add(BasketAddVm model)
        {
            if (!_modelState.IsValid) return false;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null) return false;

            var product = await _productRepository.GetAsync(model.Id);

            if (product == null) return false;

            var basket = await _basketRepository.GetBasket(_httpContextAccessor.HttpContext.User);

            if (basket == null)
            {
                basket = new Basket
                {
                    UserId = user.Id
                };

                await _basketRepository.CreateAsync(basket);

            }


            var basketProduct = await _basketProductRepository.GetBasketProduct(product.Id, basket.Id);
            if (basketProduct != null)
            {
                basketProduct.Quantity++;
                await _basketProductRepository.UpdateAsync(basketProduct);
            }
            else
            {
                basketProduct = new BasketProduct
                {
                    BasketId = basket.Id,
                    ProductId = product.Id,
                    Quantity = 1
                };


                await _basketProductRepository.CreateAsync(basketProduct);

            }
            return true;
        }

        public async Task<bool> DeleteBasketProduct(int productId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var basket = await _basketRepository.GetBasket(_httpContextAccessor.HttpContext.User);

            var basketProduct = await _basketProductRepository.GetAsync(productId);

            if (basketProduct == null) return false;

            var product = await _productRepository.GetProduct(basketProduct.ProductId);

            if (product == null) return false;

            await _basketProductRepository.DeleteAsync(basketProduct);

            return true;

        }

        public async Task<bool> UpCount(int productId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var basket = await _basketRepository.GetBasket(_httpContextAccessor.HttpContext.User);

            var basketProduct = await _basketProductRepository.GetAsync(productId);

            if (basketProduct == null) return false;

            var product = await _productRepository.GetProduct(basketProduct.ProductId);

            if (product == null) return false;

            basketProduct.Quantity++;

            await _basketProductRepository.UpdateAsync(basketProduct);

            return true;

        }

        public async Task<bool> DownCount(int productId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var basket = await _basketRepository.GetBasket(_httpContextAccessor.HttpContext.User);

            var basketProduct = await _basketProductRepository.GetAsync(productId);

            if (basketProduct == null) return false;

            var product = await _productRepository.GetProduct(basketProduct.ProductId);

            if (product == null) return false;


            if (basketProduct.Quantity > 1)
            {
                basketProduct.Quantity--;
            }

            await _basketProductRepository.UpdateAsync(basketProduct);

            return true;

        }

        public async Task<bool> ClearBasketProduct()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var basket = await _basketRepository.GetBasket(_httpContextAccessor.HttpContext.User);

            var basketProduct = await _basketProductRepository.GetAllBasketProduct(basket.Id);

            if (basketProduct == null) return false;


            foreach (var product in basketProduct)
            {
                await _basketProductRepository.DeleteAsync(product);
            }

            return true;

        }
    }
}
