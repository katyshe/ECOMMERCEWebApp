using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Data.Entities
{
    public class Order
    {
        private readonly DBServerConnection econtext;
        public string  Id { get; set; }

        public DateTime OrderDate { get; set; }

        public User User { get; set; }

        public List<SubOrder> Items { get; set; }

        private Order(DBServerConnection context)
        {
            econtext = context;
        }

        /// <summary>
        /// check if there is a session with open order, if not create a new one, its invoked when the user send a request
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static Order GetOrder(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<DBServerConnection>();

            if(session.GetString("OrderId") == null)
            {
                string orderId = Guid.NewGuid().ToString();
                session.SetString("OrderId", orderId);
                return  new Order(context)
                {
                    Id = orderId,
                    Items = new List<SubOrder>(),
                    OrderDate = DateTime.Now
                };
               
            }
            else
            {
                return  new Order(context) { Id = session.GetString("OrderId") };

            }
        }

        
        /// <summary>
        /// this method add new item to the order , by checking if the item product is already exsit 
        /// </summary>
        /// <param name="p"></param>
        public void AddToCart(Product p)
        {
            
            //check if the product is already selected 
            var subOrder =econtext.Items
                       .Where(i => i.Product.Id == p.Id && i.OrderId == Id).SingleOrDefault();

            if(subOrder == null)
            { 
                subOrder = new SubOrder();
                subOrder.Amount = 1;
                subOrder.Product = p;
                subOrder.productId = p.Id;

                subOrder.productprice = p.Price;
                subOrder.Totalprice = subOrder.productprice;
                subOrder.OrderId = Id;
                econtext.Items.Add(subOrder);

            }
            else
            {
                subOrder.Amount++;
                subOrder.Totalprice = subOrder.productprice * subOrder.Amount;
            }

            econtext.SaveChanges();
        }



        public List<SubOrder> GetOrderItems()
        {
            if(Items==null)
            {
                return Items = econtext.Items
                   .Where(I => I.OrderId == Id)
                   .ToList();
            }
            else
            {
                return Items.ToList();
            }
            
        }

        /// <summary>
        /// this function Calculates the items price for this order
        /// </summary>
        /// <returns></returns>
        public decimal GetOrderTotalPrice()
        {
            var total = econtext.Items
                        .Where(I => I.OrderId == Id)
                        .Select(I => I.Totalprice).Sum();

            return total;
        }

    }

}
