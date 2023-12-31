﻿namespace CheapBuyAPI.Response
{
    public class ProductResponse
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public int BrandId { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
    }
}
