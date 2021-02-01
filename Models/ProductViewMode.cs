using ECOMMERCEWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Models
{
    public class ProductViewMode
    {

       public Product Product { get; set; }

        public List<Product> ProductswithSameCategory { get; set; }
    }
}
