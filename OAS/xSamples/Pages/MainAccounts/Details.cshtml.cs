using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OAS.Models;
using xSamples.Data;

namespace xSamples.Pages.MainAccounts
{
    public class DetailsModel : PageModel
    {
        private readonly xSamples.Data.xSamplesContext _context;

        public DetailsModel(xSamples.Data.xSamplesContext context)
        {
            _context = context;
        }

        public fsAccount fsAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            fsAccount = await _context.fsAccount
                .Include(f => f.fsAccntCategory)
                .Include(f => f.fsEntity).FirstOrDefaultAsync(m => m.Id == id);

            if (fsAccount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
