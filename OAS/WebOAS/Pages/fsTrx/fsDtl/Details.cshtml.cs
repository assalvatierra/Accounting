using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsTrx.fsDtl
{
    public class DetailsModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public DetailsModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
