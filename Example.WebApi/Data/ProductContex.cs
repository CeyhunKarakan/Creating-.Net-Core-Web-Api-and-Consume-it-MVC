using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Data
{
    public class ProductContex : DbContext
    {
        public ProductContex(DbContextOptions<ProductContex> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new(){Id=1,Name="Electronics"},
                new(){Id=2,Name="Outfit"}
            });
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){Id=1, Name="TV", createdDate=DateTime.Now.AddDays(-3), Price=3000, Stock=50,CategoryId=1},
                new(){Id=2, Name="Table", createdDate=DateTime.Now.AddDays(-15), Price=1750, Stock=750,CategoryId=1},
                new(){Id=3, Name="Keyboard", createdDate=DateTime.Now.AddDays(-1), Price=100, Stock=125,CategoryId=1}
            }

            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
