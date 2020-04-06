using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TightShip.Data;
using TightShip.Models;

namespace TightShip.Pages.Bills
{
    public class DeleteModel : PageModel
    {
        private readonly TightShip.Data.TightShipContext _context;

        public DeleteModel(TightShip.Data.TightShipContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bills = await _context.Bills.FindAsync(id);

            if (Bills != null)
            {
                _context.Bills.Remove(Bills);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
