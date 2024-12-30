

using System.ComponentModel.DataAnnotations;

namespace FlowerProjectP323.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product must be declared!"), MinLength(3, ErrorMessage = "Product name length must be minimum 3 character!")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Weight { get; set; }
        public string Dimenesion { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductStatus Status { get; set; }
        public string MainPhotoName { get; set; }
        public ICollection<ProductPhoto>? ProductPhotos { get; set; }
        public enum ProductStatus
        {
            New,
            Sale,
            Sold
        }

    }

}