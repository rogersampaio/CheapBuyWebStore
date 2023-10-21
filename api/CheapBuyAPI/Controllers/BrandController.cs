using CheapBuyAPI.Response;
using CheapBuyAPI.Interfaces;
using CheapBuyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheapBuyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController(ICheapBuyRepository<Brand> brandRepository) : ControllerBase
{
    private readonly ICheapBuyRepository<Brand> _brandRepository = brandRepository;

    [HttpGet(Name = "GetBrands")]
    public List<BrandResponse> GetAll()
    {
        var brands = from brand in _brandRepository.Get()
                     select new BrandResponse
                     {
                         Id = brand.Id,
                         Name = brand.Name
                     };

        return brands.ToList();
    }
}
