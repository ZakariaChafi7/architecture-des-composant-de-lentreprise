using Artisanaux.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Artisanaux.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product>Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Espace de Rongement",
                Price = 1500,

                CategoryName = "Rongement",
                ImageURL = "https://artisanamf.blob.core.windows.net/artisana/1.jpeg"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = " Rongement",
                Price = 1600,

                CategoryName = "Rongement",
                ImageURL = "https://artisanamf.blob.core.windows.net/artisana/2.jpg"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = " Rongement simple",
                Price = 2600,

                CategoryName = "Rongement",
                ImageURL = "https://artisanamf.blob.core.windows.net/artisana/3.jpeg"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductName = " Rongement complex",
                Price = 600,

                CategoryName = "Rongement",
                ImageURL = "https://artisanamf.blob.core.windows.net/artisana/4.jpeg"

            });
        }
    }
}

