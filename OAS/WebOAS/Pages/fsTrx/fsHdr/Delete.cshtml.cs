using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsTrx.fsHdr
{
    public class DeleteModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public DeleteModel(WebOAS.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            fsTrxHdr = await _context.fsTrxHdrs.FindAsync(id);

            if (fsTrxHdr != null)
            {
                _context.fsTrxHdrs.Remove(fsTrxHdr);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
