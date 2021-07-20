using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsTrx.fsDtl
{
    public class EditModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public EditModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public fsTrxDetail fsTrxDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            fsTrxDetail = await _context.fsTrxDetails
                .Include(f => f.fsAccount)
                .Include(f => f.fsSubAccnt)
                .Include(f => f.fsTrxHdr).FirstOrDefaultAsync(m => m.Id == id);

            if (fsTrxDetail == null)
            {
                return NotFound();
            }
           ViewData["fsAccountId"] = new SelectList(_context.fsAccounts, "Id", "Id");
           ViewData["fsSubAccntId"] = new SelectList(_context.fsSubAccnts, "Id", "Id");
           ViewData["fsTrxHdrId"] = new SelectList(_context.fsTrxHdrs, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(fsTrxDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fsTrxDetailExists(fsTrxDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool fsTrxDetailExists(int id)
        {
            return _context.fsTrxDetails.Any(e => e.Id == id);
        }
    }
}
