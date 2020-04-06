using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TightShip.Data;
using TightShip.Models;

namespace TightShip.Pages.Bills
{
    public class EditModel : PageModel
    {
        private readonly TightShip.Data.TightShipContext _context;

        public EditModel(TightShip.Data.TightShipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Bills Bills { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bills = await _context.Bills.FirstOrDefaultAsync(m => m.ID == id);

            if (Bills == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillsExists(Bills.ID))
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

        private bool BillsExists(int id)
        {
            return _context.Bills.Any(e => e.ID == id);
        }
    }
}
