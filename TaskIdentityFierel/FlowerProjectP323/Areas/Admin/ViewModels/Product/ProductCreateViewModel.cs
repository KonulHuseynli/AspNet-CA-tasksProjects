
using Microsoft.AspNetCore.Mvc.Rendering;
using static FlowerProjectP323.Models.Product;

namespace FlowerProjectP323.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public string Weight { get; set; }
        public string Dimenesion { get; set; }

        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public ProductStatus Status { get; set; }

        public IFormFile MainPhotoName { get; set; }


        public List<IFormFile> ProductPhotos { get; set; }
    }
}
