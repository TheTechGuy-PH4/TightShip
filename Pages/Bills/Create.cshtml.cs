using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TightShip.Data;
using TightShip.Models;

namespace TightShip.Pages.Bills
{
    public class CreateModel : PageModel
    {
        private readonly TightShip.Data.TightShipContext _context;

        public CreateModel(TightShip.Data.TightShipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Bills Bills { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bills.Add(Bills);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
