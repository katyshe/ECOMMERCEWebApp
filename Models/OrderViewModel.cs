using ECOMMERCEWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }

        public decimal OrderTotal { get; set; }


    }
}
