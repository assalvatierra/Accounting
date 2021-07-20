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

namespace WebOAS.Pages.fsSubaccounts
{
    public class EditModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public EditModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["fsAccountId"] = new SelectList(_context.fsAccounts, "Id", "Id");
           ViewData["fsEntityId"] = new SelectList(_context.fsEntities, "Id", "Id");
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

            _context.Attach(fsSubAccnt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fsSubAccntExists(fsSubAccnt.Id))
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

        private bool fsSubAccntExists(int id)
        {
            return _context.fsSubAccnts.Any(e => e.Id == id);
        }
    }
}
