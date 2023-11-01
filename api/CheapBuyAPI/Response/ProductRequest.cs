namespace CheapBuyAPI.Response
{
    public class ProductRequest
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
    }
}
