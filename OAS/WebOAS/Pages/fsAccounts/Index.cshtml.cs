using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OAS.Models;
using WebOAS.Data;

namespace WebOAS.Pages.fsAccounts
{
    public class IndexModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public IndexModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<fsAccount> fsAccount { get;set; }

        public async Task OnGetAsync()
        {
            fsAccount = await _context.fsAccounts
                .Include(f => f.fsAccntCategory)
                .Include(f => f.fsEntity).ToListAsync();
        }
    }
}
