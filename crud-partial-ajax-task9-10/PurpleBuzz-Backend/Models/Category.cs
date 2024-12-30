using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_Backend.Models
{
    public class Category
    {
        public Category()
        {
            CategoryComponents=new List<CategoryComponent>();
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage ="Title can't be null"), MinLength(3,ErrorMessage = "Title must contain 3 letter at least")]
        
        public string Title { get; set; }
        
        public ICollection<CategoryComponent> CategoryComponents { get; set; }

    }
}
