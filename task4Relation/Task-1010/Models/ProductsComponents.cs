namespace Task_1010.Models
{
    public class ProductsComponents
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
        public Products Product { get; set; }
        
    }
}
