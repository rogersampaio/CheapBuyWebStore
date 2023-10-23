using CheapBuyAPI.Response;
using CheapBuyDB.Interfaces;
using CheapBuyDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheapBuyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ICheapBuyRepository<Product> productRepository) : ControllerBase
{
    //private readonly ICheapBuyRepository<Product> _productRepository = productRepository;

    [HttpGet(Name = "GetProducts")]
    public List<ProductResponse> GetAll()
    {
        var products = from product in productRepository.Get(includeProperties: "Brand")
                       select new ProductResponse
                       {
                           ProductId = product.Id,
                           ProductName = product.Name,
                           Price = product.Price,
                           Brand = product?.Brand?.Name
                       };
        return products.ToList();
    }

    [HttpGet("{id}", Name = "Get by Id")]
    public ProductResponse? GetProductById(string id)
    {
        var result = from product in productRepository.Get(includeProperties: "Brand")
                     where product.Id == id
                     select new ProductResponse
                     {
                         ProductId = product.Id,
                         ProductName = product.Name,
                         Price = product.Price,
                         BrandId = product.BrandId
                     };
        return result.FirstOrDefault();
    }

    [HttpPost(Name = "PostProduct")]
    public void PostProduct(ProductRequest product)
    {
        var existingProduct = productRepository.GetById(product.ProductId);
        if (existingProduct != null)
        {
            throw new Exception("Product already exist");
        }
        else
        {
            productRepository.Add(new Product()
            {
                Id = product.ProductId,
                Name = product.ProductName,
                Price = product.Price,
                BrandId = product.BrandId
            });
            productRepository.SaveChanges();
        }
    }


    [HttpPut(Name = "PutProduct")]
    public void PutProduct(ProductRequest product)
    {
        var existingProduct = productRepository.GetById(product.ProductId);
        if (existingProduct != null)
        {
            existingProduct.Name = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.BrandId = product.BrandId;

            productRepository.Update(existingProduct);
            productRepository.SaveChanges();
        }
        else
        {
            throw new Exception("Product does not exist");
        }
    }

    [HttpDelete(Name = "DeleteProduct")]
    public void DeleteProduct(string productId)
    {
        var existingProduct = productRepository.GetById(productId);
        if (existingProduct == null)
        {
            throw new Exception("Product does not exist");
        }
        else
        {
            productRepository.Delete(existingProduct);
            productRepository.SaveChanges();
        }
    }
}
