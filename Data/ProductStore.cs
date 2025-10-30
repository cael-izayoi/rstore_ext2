using Rstore_ext.Models;

namespace Rstore_ext.Data
{
    public static class ProductStore
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 65000, Category = "Электроника", Stock = 10 },
            new Product { Id = 2, Name = "Смартфон", Price = 55000, Category = "Электроника", Stock = 25 },
            new Product { Id = 3, Name = "Кофеварка", Price = 12000, Category = "Бытовая техника", Stock = 8 },
            new Product { Id = 4, Name = "Наушники", Price = 8000, Category = "Аксессуары", Stock = 40 },
            new Product { Id = 5, Name = "Мышка", Price = 3000, Category = "Периферия", Stock = 60 }
        };

        public static void Add(Product product)
        {
            product.Id = Products.Count > 0 ? Products.Max(p => p.Id) + 1 : 1;
            Products.Add(product);
        }

        public static Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);

        public static void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Category = product.Category;
                existing.Stock = product.Stock;
            }
        }

        public static void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
                Products.Remove(existing);
        }
    }
}
