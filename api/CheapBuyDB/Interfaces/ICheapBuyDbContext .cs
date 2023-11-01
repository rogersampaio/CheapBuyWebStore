using CheapBuyDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CheapBuyDB.Interfaces
{
    public interface ICheapBuyDbContext : IDisposable
    {
        DbSet<Product> Products { get; }
        DbSet<Brand> Brands { get; }
        void SaveChanges();
    }
}
