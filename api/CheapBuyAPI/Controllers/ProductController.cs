using CheapBuyAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CheapBuyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ICheapBuyDbContext _context;

    public ProductController(ICheapBuyDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetProducts")]
    public List<ProductDto> GetAll()
    {
        var products = from product in _context.Products
                       join brand in _context.Brands on product.BrandId equals brand.Id
                       select new ProductDto
                       {
                           ProductId = product.Id,
                           ProductName = product.Name,
                           Price = product.Price,
                           Brand = brand.Name
                       };

        return products.ToList();
    }

    [HttpGet("{id}", Name = "Get by Id")]
    public ProductDto? GetProductById(string id)
    {
        var result = from product in _context.Products
                     join brand in _context.Brands on product.BrandId equals brand.Id
                     where product.Id == id
                     select new ProductDto
                     {
                         ProductId = product.Id,
                         ProductName = product.Name,
                         Price = product.Price,
                         BrandId = brand.Id,
                         Brand = brand.Name
                     };

        return result.SingleOrDefault();
    }

    [HttpPost(Name = "PostProduct")]
    public void PostProduct(ProductDto product)
    {
        var products = from p in _context.Products
                       where p.Id == product.ProductId
                       select p;
        if (products?.Count() > 0)
        {
            throw new Exception("Product already exist");
        }
        else
        {
            _context.Products.Add(new Models.Product() {
                Id = product.ProductId,
                Name = product.ProductName, 
                Price = product.Price,
                BrandId = product.BrandId
            });
            _context.SaveChanges();
        }
    }


    [HttpPut(Name = "PutProduct")]
    public void PutProduct(ProductDto product)
    {
        var result = (from p in _context.Products
                       where p.Id == product.ProductId
                       select p).SingleOrDefault();
        if (result != null)
        {
            result.Name = product.ProductName;
            result.Price = product.Price;
            result.BrandId = product.BrandId;

            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Product does not exist");
        }
    }

    [HttpDelete(Name = "DeleteProduct")]
    public void DeleteProduct(string productId)
    {
        var productDb = (from p in _context.Products
                        where p.Id == productId
                        select p).SingleOrDefault();
        if (productDb == null)
        {
            throw new Exception("Product does not exist");
        }
        else
        {
            _context.Products.Remove(productDb);
            _context.SaveChanges();
        }
    }
}
