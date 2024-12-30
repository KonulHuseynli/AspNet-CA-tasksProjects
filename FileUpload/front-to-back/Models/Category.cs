using System.ComponentModel.DataAnnotations;

namespace front_to_back.Models
{
    public class Category
    {
        public Category()
        {
            CategoryComponents = new List<CategoryComponent>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlıq yerini mütləq doldur."), MinLength(5, ErrorMessage = "Başlığın minumum uzunluğu 5 olmalıdır")]
        public string Title { get; set; }
        public ICollection<CategoryComponent> CategoryComponents { get; set; }
    }
}
