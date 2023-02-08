using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "Praesent scelerisque, magna vehicula sagittis ut non Phasellus commodo cursus pretium.",
                CategoryName = "Appetizer",
                ImageUrl = "https://salimmawlaa.blob.core.windows.net/mango/1.jpg"

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "Praesent scelerisque, mi sed ultriceem, laturpis, facilisis sed ligula ac, maximus malesuada",
                CategoryName = "Appetizer",
                ImageUrl = "https://salimmawlaa.blob.core.windows.net/mango/3.jpg"

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "Praesent scelerisqSed volutpat tellus lorem, lacinia tinciduellus commodo cursus pretium.",
                CategoryName = "Dessert",
                ImageUrl = "https://salimmawlaa.blob.core.windows.net/mango/4.jpg"

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pav Bhaji",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in loborti",
                CategoryName = "Entree",
                ImageUrl = "https://salimmawlaa.blob.core.windows.net/mango/5.jpg"

            });
        }

    } 
}
