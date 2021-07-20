using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsSubaccounts
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
        ViewData["fsAccountId"] = new SelectList(_context.fsAccounts, "Id", "Id");
        ViewData["fsEntityId"] = new SelectList(_context.fsEntities, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public fsSubAccnt fsSubAccnt { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.fsSubAccnts.Add(fsSubAccnt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
