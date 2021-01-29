using ECOMMERCEWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Data
{
    public class DBServerConnection :DbContext
    {
        /// <summary>
        /// To pass the connection string into the context, so when the context is being added its taking the connection string (options) that we declared in the startup
        /// </summary>
        /// <param name="options"> </param>
        public DBServerConnection(DbContextOptions<DBServerConnection> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
