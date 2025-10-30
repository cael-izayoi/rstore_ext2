using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rstore_ext.Data;
using Rstore_ext.Models;

namespace Rstore_ext.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new();

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();

                if (Product.Price < 1000)
                {
                    TempData["Error"] = "Цена не может быть меньше 1000!";
                    return Page();
                }

                ProductStore.Add(Product);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                throw ex; // (try-catch №1)
            }
        }
    }
}
