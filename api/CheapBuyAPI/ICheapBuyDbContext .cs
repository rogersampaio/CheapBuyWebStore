using CheapBuyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CheapBuyAPI
{
    public interface ICheapBuyDbContext : IDisposable
    {
        DbSet<Product> Products { get; }
        DbSet<Brand> Brands { get; }
        void SaveChanges();
    }
}
