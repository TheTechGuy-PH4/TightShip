using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TightShip.Models
{
    public class Bills
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public string BillTitle { get; set; }

        public double Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

    }
}
