using Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using static Core.Constants.ProductStatus;

namespace WebApp.ViewModels.Product
{
    public class ProductCreateVM
    {
        public ProductCreateVM()
        {
            ProductPhotos = new List<IFormFile>();
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public string Weight { get; set; }
        public string Dimenesion { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public ProductStatus Status { get; set; }

        public IFormFile MainPhoto{ get; set; }
        public List<IFormFile> ProductPhotos { get; set; }

    }
}
