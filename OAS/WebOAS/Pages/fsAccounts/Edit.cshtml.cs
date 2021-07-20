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

namespace WebOAS.Pages.fsAccounts
{
    public class EditModel : PageModel
    {
        private readonly WebOAS.Data.ApplicationDbContext _context;

        public EditModel(WebOAS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["fsAccntCategoryId"] = new SelectList(_context.Set<fsAccntCategory>(), "Id", "Id");
           ViewData["fsEntityId"] = new SelectList(_context.Set<fsEntity>(), "Id", "Id");
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

            _context.Attach(fsAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fsAccountExists(fsAccount.Id))
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

        private bool fsAccountExists(int id)
        {
            return _context.fsAccount.Any(e => e.Id == id);
        }
    }
}
