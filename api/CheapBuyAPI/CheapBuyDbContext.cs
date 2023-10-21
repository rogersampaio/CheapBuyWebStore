using CheapBuyAPI.Interfaces;
using CheapBuyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CheapBuyAPI
{
    public class CheapBuyDbContext(DbContextOptions<CheapBuyDbContext> options) : DbContext(options), ICheapBuyDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        /// <summary>
        /// Seed database with some data
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void SeedData(ModelBuilder modelBuilder)
        {
            Brand[] brands = {
                new() {
                    Id = 1,
                    Name = "Apple"
                },
                new() {
                    Id = 2,
                    Name = "HP"
                },
                new() {
                    Id = 3,
                    Name = "Dell"
                }
            };

            dynamic[] products = {
                new 
                {
                    Id = "1234434",
                    Name = "Iphone 6 64gb",
                    Price = (decimal)680,
                    BrandId = 1
                },
                new
                {
                    Id = "3232432",
                    Name = "Macbook pro 13'",
                    Price = (decimal)1200,
                    BrandId = 1
                },
                new
                {
                    Id = "323ew32",
                    Name = "ProBook 450 G6 15.6'",
                    Price = (decimal)615,
                    BrandId = 2
                }
            };

            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Product>().HasData(products);
        }

        void ICheapBuyDbContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}
