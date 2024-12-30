namespace FlowerProjectP323.ViewModel.Basket
{
    public class BasketListItemViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }
        public double Price { get; set; }
        public string? PhotoName { get; set; }
    }
}
