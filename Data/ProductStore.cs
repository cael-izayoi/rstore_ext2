using Rstore_ext.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rstore_ext.Data
{
    public static class ProductStore
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 70000 },
            new Product { Id = 2, Name = "Мышка", Price = 1500 }
        };

        public static List<Product> GetAll() => _products;

        public static Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public static void Add(Product product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public static void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public static void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _products.Remove(product);
        }
    }
}
