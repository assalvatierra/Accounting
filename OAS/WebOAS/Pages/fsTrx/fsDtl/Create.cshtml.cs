using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsTrx.fsDtl
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
        ViewData["fsSubAccntId"] = new SelectList(_context.fsSubAccnts, "Id", "Id");
        ViewData["fsTrxHdrId"] = new SelectList(_context.fsTrxHdrs, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public fsTrxDetail fsTrxDetail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.fsTrxDetails.Add(fsTrxDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
