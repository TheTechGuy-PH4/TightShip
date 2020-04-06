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
    public class IndexModel : PageModel
    {
        private readonly TightShip.Data.TightShipContext _context;

        public IndexModel(TightShip.Data.TightShipContext context)
        {
            _context = context;
        }

        public IList<Models.Bills> Bills { get;set; }

        public async Task OnGetAsync()
        {
            Bills = await _context.Bills.ToListAsync();
        }
    }
}
