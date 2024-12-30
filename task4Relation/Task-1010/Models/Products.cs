namespace Task_1010.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ProductsComponents> ProductComponents { get; set; }
    }
}
