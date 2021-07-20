using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsSubaccounts
{
    public class IndexModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public IndexModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<fsSubAccnt> fsSubAccnt { get;set; }

        public async Task OnGetAsync()
        {
            fsSubAccnt = await _context.fsSubAccnts
                .Include(f => f.fsAccount)
                .Include(f => f.fsEntity).ToListAsync();
        }
    }
}
