using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsAccounts
{
    public class CreateModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public CreateModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["fsAccntCategoryId"] = new SelectList(_context.Set<fsAccntCategory>(), "Id", "Id");
        ViewData["fsEntityId"] = new SelectList(_context.Set<fsEntity>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public fsAccount fsAccount { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.fsAccount.Add(fsAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
