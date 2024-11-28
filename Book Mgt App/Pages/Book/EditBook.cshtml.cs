using Book_Mgt_App.Data;
using Book_Mgt_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_Mgt_App.Pages.Book
{
    public class EditBookModel : PageModel
    {
        private AppDbContext _context;

        // constructor
        public EditBookModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Books Books { get; set; } = default;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            // getting the book by id from the db
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


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(Books);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }

}
