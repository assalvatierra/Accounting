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
    public class IndexModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public IndexModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<fsTrxHdr> fsTrxHdr { get;set; }

        public async Task OnGetAsync()
        {
            fsTrxHdr = await _context.fsTrxHdrs
                .Include(f => f.fsEntity)
                .Include(f => f.fsTrxStatus).ToListAsync();
        }
    }
}
