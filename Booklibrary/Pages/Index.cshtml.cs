using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Booklibrary.Model;

namespace Booklibrary.Pages
{
    public class IndexModel : PageModel
    {


        private readonly Booklibrary.Model.BookLibraryContext _context;

        public IndexModel(Booklibrary.Model.BookLibraryContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string SearchTerm { get; set; }
        [BindProperty]
        public IList<Book> Book { get; set; }

       
        public async Task<IActionResult> OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Attributes)
                .Include(b => b.Author)
                .Include(b => b.Categories).ToListAsync();
            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Book = await _context.Books
                .Include(b => b.Attributes)
                .Include(b => b.Author)
                .Include(b => b.Categories).
                Where(p => p.BookName.ToLower().Contains(SearchTerm.ToLower())).ToListAsync();
                return Page();
            }
            return RedirectToPage("/Index");

        }
        public IActionResult OnPostByCategory()
        {
            Book = _context.Books.
                 Include(b => b.Attributes)
                .Include(b => b.Author)
                .Include(b => b.Categories).OrderBy(b => b.Categories.Genre).ToList();
            return Page();
        }

        public IActionResult OnPostByPrice()
        {
            Book = _context.Books.
                 Include(b => b.Categories)
                .Include(b => b.Author)
                .Include(b => b.Attributes).OrderBy(b => b.Attributes.Price).ToList();
            return Page();
        }
        public IActionResult OnPostByAuthor()
        {
            Book = _context.Books.
                 Include(b => b.Categories)
                .Include(b => b.Attributes)
                .Include(b => b.Author).OrderBy(b => b.Author.AuthorsName).ToList();
            return Page();
        }
    }
}
