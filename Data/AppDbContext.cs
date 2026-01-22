using KarimaCollection.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KarimaCollection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }

    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new[]
                {
                new Category { Name = "Dresses" },
                new Category { Name = "Bags" },
                new Category { Name = "Shoes" },
                new Category { Name = "Perfumes" },
                new Category { Name = "Accessories" }
            };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var dressesCat = context.Categories.First(c => c.Name == "Dresses");
                var bagsCat = context.Categories.First(c => c.Name == "Bags");
                var shoesCat = context.Categories.First(c => c.Name == "Shoes");
                var perfumesCat = context.Categories.First(c => c.Name == "Perfumes");
                var accessoriesCat = context.Categories.First(c => c.Name == "Accessories");




                var products = new[]
                {
                new Product
                {
                    Name = "Perfume",
                    Description = "Confidence sarts Scent.",
                    Price = 85.00M,
                    ImageUrl = "/images/product1.jpg",
                    CategoryId = perfumesCat.Id
                },
                 new Product
                {
                    Name = "Perfume",
                    Description = "Confidence starts from Scent.",
                    Price = 85.00M,
                    ImageUrl = "/images/dukhan.jpg",
                    CategoryId = perfumesCat.Id
                },
                  new Product
                {
                    Name = "Perfume",
                    Description = "Confidence starts scent.",
                    Price = 85.00M,
                    ImageUrl = "/image/perfume2.jpeg",
                    CategoryId = perfumesCat.Id
                },
                new Product
                {
                    Name = "Sets",
                    Description = "Elegant handbag for every occasion.",
                    Price = 120.00M,
                    ImageUrl = "/images/product2.jpg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Abaya",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product3.jpg",
                    CategoryId = dressesCat.Id
                },
                 new Product
                {
                    Name = "Crystals from Swarovski",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product4.jpeg",
                    CategoryId = dressesCat.Id
                },
                  new Product
                {
                    Name = "Heels",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product5.jpeg",
                    CategoryId = shoesCat.Id
                },
                   new Product
                {
                    Name = "Swarovski Guinea Brocade Lace",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product6.jpeg",
                    CategoryId = dressesCat.Id
                },
                    new Product
                {
                    Name = "Crystalized with Swarovski",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product7.jpeg",
                    CategoryId = dressesCat.Id
                },
                     new Product
                {
                    Name = "Kampala Free-Size Dress Fabric",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product8.jpeg",
                    CategoryId = dressesCat.Id
                },
                      new Product
                {
                    Name = "Kampala Flower Pattern Material",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product9.jpeg",
                    CategoryId = dressesCat.Id
                },
                       new Product
                {
                    Name = "Sets",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product10.jpeg",
                    CategoryId = dressesCat.Id
                },
                        new Product
                {
                    Name = "Tissue Materiel",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product11.jpeg",
                    CategoryId = dressesCat.Id
                },
                         new Product
                {
                    Name = "Abaya",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product12.jpeg",
                    CategoryId = dressesCat.Id
                }
            };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }

}
