using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsTrx.fsHdr
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
        ViewData["fsEntityId"] = new SelectList(_context.fsEntities, "Id", "Id");
        ViewData["fsTrxStatusId"] = new SelectList(_context.fsTrxStatus, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public fsTrxHdr fsTrxHdr { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.fsTrxHdrs.Add(fsTrxHdr);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
