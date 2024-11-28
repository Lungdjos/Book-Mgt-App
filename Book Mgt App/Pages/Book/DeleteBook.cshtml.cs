using Book_Mgt_App.Data;
using Book_Mgt_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_Mgt_App.Pages.Book
{
    public class DeleteBookModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteBookModel(AppDbContext context)
        {
            _context = context;
        }

        public Books Books { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return RedirectToPage("./Index");
            }

            // get the book then delete it
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Books = book;
                return Page();
            } 
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return Page();
            }

            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return Page();
            }
            else
            {
                Books = book;
                _context.Books.Remove(Books);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
