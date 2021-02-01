using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Data.Entities
{
    public class SubOrder
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public Product Product { get; set; }

        public int productId { get; set; }

        public decimal productprice { get; set; }

        public decimal Totalprice { get; set; }

        public string OrderId { get; set; }
       
    }
}
