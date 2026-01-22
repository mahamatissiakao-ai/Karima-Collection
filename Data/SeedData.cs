using KarimaCollection.Models;
using KarimaCollection.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using KarimaCollection.Services; // ✅ <-- Add this one



public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        // ✅ Seed Categories
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

        // ✅ Seed Products
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
                    Description = "Confidence starts from Scent.",
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
                    Description = "Confidence starts from scent.",
                    Price = 85.00M,
                    ImageUrl = "/images/perfume2.jpeg",
                    CategoryId = perfumesCat.Id
                },
                new Product
                {
                    Name = "Sets",
                    Description = "Elegant handbag for every occasion.",
                    Price = 120.00M,
                    ImageUrl = "/images/product2.jpg",
                    CategoryId = bagsCat.Id
                },
                new Product
                {
                    Name = "Evening Gown",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product3.jpg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Evening Gown",
                    Description = "Stunning black gown with gold patterns.",
                    Price = 150.00M,
                    ImageUrl = "/images/product4.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Shoes",
                    Description = "Elegant pair for your evening.",
                    Price = 150.00M,
                    ImageUrl = "/images/product5.jpeg",
                    CategoryId = shoesCat.Id
                },
                new Product
                {
                    Name = "Evening Gown",
                    Description = "Stylish and modern design.",
                    Price = 150.00M,
                    ImageUrl = "/images/product6.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Abaya Set",
                    Description = "Classic modest wear.",
                    Price = 150.00M,
                    ImageUrl = "/images/product7.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Evening Dress",
                    Description = "Beautiful gold-accented gown.",
                    Price = 150.00M,
                    ImageUrl = "/images/product8.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Dress",
                    Description = "Gorgeous African-inspired outfit.",
                    Price = 150.00M,
                    ImageUrl = "/images/product9.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Sets",
                    Description = "Unique and fashionable set.",
                    Price = 150.00M,
                    ImageUrl = "/images/product10.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Tissue Material",
                    Description = "Elegant fabric for classy outfits.",
                    Price = 150.00M,
                    ImageUrl = "/images/product11.jpeg",
                    CategoryId = dressesCat.Id
                },
                new Product
                {
                    Name = "Abaya",
                    Description = "Luxury Abaya with premium fabric.",
                    Price = 150.00M,
                    ImageUrl = "/images/product12.jpeg",
                    CategoryId = dressesCat.Id
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        // ✅ Seed Admin (newly added)
        if (!context.Admins.Any())
        {
            var admin = new Admin
            {
                Username = "admin",
                PasswordHash = KarimaCollection.Services.AdminAuthService.HashPassword("23462")
            };
            context.Admins.Add(admin);
            context.SaveChanges();

            Console.WriteLine("✅ Default admin added: username = admin, password = 23462");
        }
    }
}
