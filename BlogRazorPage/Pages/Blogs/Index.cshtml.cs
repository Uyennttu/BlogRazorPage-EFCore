using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogRazorPage.Data;
using BlogRazorPage.Models;

namespace BlogRazorPage.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly BlogRazorPage.Data.BlogRazorPageContext _context;

        public IndexModel(BlogRazorPage.Data.BlogRazorPageContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Blog = await _context.Blog
                .Include(b => b.Author).ToListAsync();
        }
    }
}
