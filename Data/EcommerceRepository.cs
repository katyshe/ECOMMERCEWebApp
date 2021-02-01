using ECOMMERCEWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Data
{
    // this class will be responsible for Managment Data, send request to DB by DBServerConnection 
    public class EcommerceRepository
    {
        private readonly DBServerConnection Econtext;
        public EcommerceRepository(DBServerConnection context)
        {
            Econtext = context;
        }

        public IList<Product> GetAllProducts()
        {
            var products = Econtext.Products;                   

            return products.ToList();

        }

        /// <summary>
        /// get all the product under specific Gategory 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IList<Product> GetProductsByCategory (string category)
        {
            var products = Econtext.Products.
                           Where(p => p.Category == category);

            return products.ToList();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IList<Product> GetProductsBySize(string size)
        {
            var products = Econtext.Products.
                           Where(p => p.Size == size);

            return products.ToList();

        }


        public Product GetProductById(int id)
        {
            var prod = Econtext.Products.SingleOrDefault(p => p.Id == id);
                          
            return prod;
        }

      

      


     

       


      
    }
}
