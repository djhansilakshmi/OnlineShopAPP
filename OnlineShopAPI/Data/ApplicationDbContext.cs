using Microsoft.EntityFrameworkCore;
using OnlineShopAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }

         public DbSet<Product> products { get; set; }

        //public DbSet<Price> price { get; set; }

        //public DbSet<Inventory> inventories { get; set; }

        public DbSet<Attributes> attributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now

                },
              new Category
              {
                  Id = 2,
                  Name = "MensShirts",
                  CreatedDate = DateTime.Now,
                  UpdatedDate = DateTime.Now
              });


            modelBuilder.Entity<Product>().HasData(
                       new
                       {
                           ProductId = 1,
                           Name = "Laptop",
                           Brand = "Brand Name",
                           Description = "Powerful and lightweight laptop for work and entertainment.",
                           CategoryID = 1,
                           Amount = 1299.99,
                           Currency = "USD",
                           InventoryTotal = 25,
                           InventoryAvailable = 20,
                           InventoryReserved = 5,                          
                           CreatedDate = DateTime.Now,
                           UpdatedDate = DateTime.Now

                       });

            modelBuilder.Entity<Attributes>().HasData(
                  new Attributes
                  {
                      ProductID = 1,
                      AttributeId = 1,
                      Name = "Color",
                      Value = "Silver"

                  },
                  new Attributes
                  {
                      ProductID = 1,
                      AttributeId = 2,
                      Name = "Processor",
                      Value = "Intel Core i7"

                  },
                  new Attributes
                  {
                      ProductID = 1,
                      AttributeId = 3,
                      Name = "Memory",
                      Value = "16GB"

                  },
                  new Attributes
                  {
                      ProductID = 1,
                      AttributeId = 4,
                      Name = "Storage",
                      Value = "512GB SSD"
                  }
           );



        }
    }
}
