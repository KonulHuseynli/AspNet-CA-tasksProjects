namespace front_to_back.Models
{
    public class CategoryComponent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string FilePath { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
