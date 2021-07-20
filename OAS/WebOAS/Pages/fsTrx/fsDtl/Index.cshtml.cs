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
    public class IndexModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public IndexModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<fsTrxDetail> fsTrxDetail { get;set; }

        public async Task OnGetAsync()
        {
            fsTrxDetail = await _context.fsTrxDetails
                .Include(f => f.fsAccount)
                .Include(f => f.fsSubAccnt)
                .Include(f => f.fsTrxHdr).ToListAsync();
        }
    }
}
