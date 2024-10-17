using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogRazorPage.Data;
using BlogRazorPage.Models;

namespace BlogRazorPage.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly BlogRazorPage.Data.BlogRazorPageContext _context;

        public CreateModel(BlogRazorPage.Data.BlogRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;

        public ICollection<Author> Authors { get; set; } = default!; // List of authors for dropdown

        public IActionResult OnGet()
        {
            // Fetch all authors from the database
            Authors = _context.Author.ToList();

            if (Authors == null || !Authors.Any())
            {
                ModelState.AddModelError(string.Empty, "No authors available. Please create an author first.");
                return Page();
            }

            // Bind the list of authors to ViewData for the dropdown
            ViewData["Authors"] = new SelectList(Authors, "Id", "Name");

            return Page();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Blog.AuthorId == null || Blog.AuthorId == 0)
            {
                // Re-fetch the authors to repopulate the dropdown in case of validation failure
                Authors = _context.Author.ToList();
                ViewData["Authors"] = new SelectList(Authors, "Id", "Name");
                ModelState.AddModelError("Blog.AuthorId", "Please select a valid author.");
                return Page();
            }

            _context.Blog.Add(Blog);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }



    }

}
