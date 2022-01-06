using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Booklibrary.Model;

namespace Booklibrary.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Booklibrary.Model.BookLibraryContext _context;

        public CreateModel(Booklibrary.Model.BookLibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AttributesId"] = new SelectList(_context.Attributes, "Id", "Id");
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id");
        ViewData["CategoriesId"] = new SelectList(_context.Categories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
