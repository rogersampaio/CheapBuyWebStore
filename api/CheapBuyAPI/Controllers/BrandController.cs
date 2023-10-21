using CheapBuyAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CheapBuyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private readonly ICheapBuyDbContext _context;

    public BrandController(ICheapBuyDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBrands")]
    public List<BrandDto> GetAll()
    {
        var brands = from brand in _context.Brands
                       select new BrandDto
                       {
                           Id = brand.Id,
                           Name = brand.Name,
                       };

        return brands.ToList();
    }
}
