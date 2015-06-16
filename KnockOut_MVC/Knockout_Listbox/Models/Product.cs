using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }

        public Product(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        static List<Product> allProducts = new List<Product>
        {
            new Product(1, "Games Console", "Fun for all the family", 199.99m),
                new Product(2, "MP3 player", "Listen to your favourite tunes on the move", 99.99m),
                new Product(3, "Smart Phone", "Apps, apps, apps", 399.99m),
                new Product(4, "Digital Photo frame", "All your photos in one beautiful frame", 49.99m),
                new Product(5, "E-book reader", "Take your favourite books on the move with you", 149.99m),
                new Product(6, "DVD Box Set", "All of season one plus exclusive extras", 39.99m)
        };

        public static List<Product> GetAllProducts()
        {
            return allProducts;
        }
    }
}
