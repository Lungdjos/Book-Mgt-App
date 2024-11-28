using Book_Mgt_App.Data;
using Book_Mgt_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Mgt_App.Pages.Book
{
    public class CreateBookModel : PageModel
    {
        private AppDbContext _context;
        // constructor
        public CreateBookModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // creating the book property
        [BindProperty]
        public Books Book { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
