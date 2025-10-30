namespace Rstore_ext.Models
{
    public class Product
    {
        public int Id { get; set; }                  // ID товара
        public string Name { get; set; } = string.Empty; // Название
        public decimal Price { get; set; }           // Цена
        public string Category { get; set; } = string.Empty; // Категория
        public int Stock { get; set; }               // Количество на складе
    }
}
