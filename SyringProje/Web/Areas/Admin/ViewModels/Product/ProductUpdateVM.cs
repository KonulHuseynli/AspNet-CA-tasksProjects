using Microsoft.AspNetCore.Mvc.Rendering;
using static Core.Constants.ProductStatus;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace WebApp.ViewModels.Product
{
    public class ProductUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public string Weight { get; set; }
        public string Dimenesion { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public IPStatus Status { get; set; }

        public IFormFile? MainPhoto { get; set; }

        public string? MainPhotoPath { get; set; }


    }
}
