namespace KarimaCollection.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }          // Link to Product
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }       // optional product image
        public int Quantity { get; set; }
    }
}
