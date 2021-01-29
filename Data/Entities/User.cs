using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Data.Entities
{
    public class User  : IdentityUser
    {
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
