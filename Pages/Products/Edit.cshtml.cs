using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rstore_ext.Data;
using Rstore_ext.Models;

namespace Rstore_ext.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = ProductStore.GetById(id);
            if (Product == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                var existing = ProductStore.GetById(Product!.Id);
                if (existing == null)
                    return NotFound();

                if (Product.Price < 1000)
                {
                    TempData["Error"] = "Цена не может быть меньше 1000!";
                    return Page();
                }

                ProductStore.Update(Product);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                throw ex; // try-catch №2 (по заданию)
            }
        }
    }
}
