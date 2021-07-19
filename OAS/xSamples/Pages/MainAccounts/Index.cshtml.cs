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
    public class IndexModel : PageModel
    {
        private readonly xSamples.Data.xSamplesContext _context;

        public IndexModel(xSamples.Data.xSamplesContext context)
        {
            _context = context;
        }

        public IList<fsAccount> fsAccount { get;set; }

        public async Task OnGetAsync()
        {
            fsAccount = await _context.fsAccount
                .Include(f => f.fsAccntCategory)
                .Include(f => f.fsEntity).ToListAsync();
        }
    }
}
