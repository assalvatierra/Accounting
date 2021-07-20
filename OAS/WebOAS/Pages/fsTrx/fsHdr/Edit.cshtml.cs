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

namespace WebOAS.Pages.fsTrx.fsHdr
{
    public class EditModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public EditModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public fsTrxHdr fsTrxHdr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            fsTrxHdr = await _context.fsTrxHdrs
                .Include(f => f.fsEntity)
                .Include(f => f.fsTrxStatus).FirstOrDefaultAsync(m => m.Id == id);

            if (fsTrxHdr == null)
            {
                return NotFound();
            }
           ViewData["fsEntityId"] = new SelectList(_context.fsEntities, "Id", "Id");
           ViewData["fsTrxStatusId"] = new SelectList(_context.fsTrxStatus, "Id", "Id");
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

            _context.Attach(fsTrxHdr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fsTrxHdrExists(fsTrxHdr.Id))
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

        private bool fsTrxHdrExists(int id)
        {
            return _context.fsTrxHdrs.Any(e => e.Id == id);
        }
    }
}
