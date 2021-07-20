﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public DetailsModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public fsSubAccnt fsSubAccnt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            fsSubAccnt = await _context.fsSubAccnts
                .Include(f => f.fsAccount)
                .Include(f => f.fsEntity).FirstOrDefaultAsync(m => m.Id == id);

            if (fsSubAccnt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
