using ECOMMERCEWebApp.Data;
using ECOMMERCEWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;
using ECOMMERCEWebApp.Data.Entities;
using ECOMMERCEWebApp.Models;
using System.Web.Mvc;




namespace ECOMMERCEWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBServerConnection econtext;
        private readonly EcommerceRepository res;
        private readonly Order _order;

        public HomeController(ILogger<HomeController> logger, EcommerceRepository repository, Order order)
        {
            _logger = logger;
            res = repository;
            _order = order;
        }
        
        public IActionResult Index(string filter, string FilterType, int pageNumber=1)
        {
            //save the values of the filter 
            ViewBag.FilterType = FilterType;
            ViewBag.filter = filter;

            if (filter == null)
            {
                //get all the products from DB by the DBServerConnection 
                var result = res.GetAllProducts();
                //res.GetAllUser();
                return View(PagingHelper<Product>.CreatPagedLsit(result.ToList(), pageNumber, 20));
            }
            //check the filter type 
            else if(FilterType== "Gategory") 
            {
                var result = res.GetProductsByCategory(filter);
                return View(PagingHelper<Product>.CreatPagedLsit(result.ToList(), pageNumber, 20));
            }

            else
            {
                var result = res.GetProductsBySize(filter);
                return View(PagingHelper<Product>.CreatPagedLsit(result.ToList(), pageNumber, 20));
            }
            
        }


        public ViewResult CheckOut()
        {
            _order.Items= _order.GetOrderItems();

            var ordersummary = new OrderViewModel
            {
                Order = _order,
                OrderTotal = _order.GetOrderTotalPrice()
            };

            return View(ordersummary);
        }

        public RedirectToActionResult AddToCart (int prodId)
        {
            var prod = res.GetProductById(prodId);

            if(prod != null)
            {
                _order.AddToCart(prod);
            }

            return RedirectToAction("CheckOut");
        }


        public IActionResult ProductDetails(int id)
        {
            int i = 3;
            var prod = res.GetProductById(id);

            //get all products under same category 
            var result = res.GetProductsByCategory(prod.Category).ToList();

            Random rnd = new Random();
            List<Product> Randomproducts = new List<Product>();
            
            while(i > 0)
            {
                int index = rnd.Next(result.Count);
                Randomproducts.Add(result.ElementAt(index));
                i--;
            }
            var productSummary = new ProductViewMode
            {
                Product = prod,
                 ProductswithSameCategory = Randomproducts
            };


            return View(productSummary);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
