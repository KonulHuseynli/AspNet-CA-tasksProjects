using System.ComponentModel.DataAnnotations;

namespace FlowerProjectP323.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category must be declared!"), MinLength(3, ErrorMessage = "Category name length must be minimum 3 character!")]
        public string Title { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
