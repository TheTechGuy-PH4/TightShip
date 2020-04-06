using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TightShip.Models;

namespace TightShip.Data
{
    public class TightShipContext : DbContext
    {
        public TightShipContext (DbContextOptions<TightShipContext> options)
            : base(options)
        {
        }

        public DbSet<TightShip.Models.Bills> Bills { get; set; }
    }
}
