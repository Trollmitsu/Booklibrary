﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Booklibrary.Model;

namespace Booklibrary.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Booklibrary.Model.BookLibraryContext _context;

        public DetailsModel(Booklibrary.Model.BookLibraryContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Attributes)
                .Include(b => b.Author)
                .Include(b => b.Categories).FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
