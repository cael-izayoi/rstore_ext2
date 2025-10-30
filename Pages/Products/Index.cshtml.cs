using Microsoft.AspNetCore.Mvc.RazorPages;
using Rstore_ext.Data;
using Rstore_ext.Models;
using System.Collections.Generic;

namespace Rstore_ext.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            Products = ProductStore.GetAll();
        }
    }
}
