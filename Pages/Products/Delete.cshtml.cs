using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rstore_ext.Data;
using Rstore_ext.Models;

namespace Rstore_ext.Pages.Products
{
    public class DeleteModel : PageModel
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
                ProductStore.Delete(Product!.Id);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
