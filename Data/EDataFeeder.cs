using ECOMMERCEWebApp.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Data
{
    public class EDataFeeder
    {
        private readonly DBServerConnection Econtext;
        private readonly IWebHostEnvironment _hosting;
        public EDataFeeder(DBServerConnection context, IWebHostEnvironment hosting )
        {
            Econtext = context;
            _hosting = hosting;
        }

        public void Feed()
        {
            //fill products DB, in case it's empty 
            if (!Econtext.Products.Any())
            {
                var folderDetails = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var JSON = System.IO.File.ReadAllText(folderDetails);
                var products = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Product>>(JSON);
                Econtext.Products.AddRange(products);

                Econtext.SaveChanges();
            }
        }


    }
}
