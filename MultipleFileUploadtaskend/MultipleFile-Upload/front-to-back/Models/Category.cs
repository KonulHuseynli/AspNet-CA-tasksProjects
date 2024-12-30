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
        [Required(ErrorMessage ="Ad mutleq doldurumalidir"),MinLength(3,ErrorMessage ="Adin uzunluqu minimum 3 olmalidir")]
        public string Title { get; set; }
        public CategoryStatus Status { get; set; }
        public ICollection<CategoryComponent> CategoryComponents { get; set; }
    }

    public enum CategoryStatus
    {
        Sale,
        New,

    }
}
