using Book_Mgt_App.Data;
using Book_Mgt_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_Mgt_App.Pages.Book
{
    public class BookDetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public BookDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Books Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) 
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Book = book;
                return Page();
            }
        }
    }
}
