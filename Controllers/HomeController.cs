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

        public HomeController(ILogger<HomeController> logger, EcommerceRepository repository)
        {
            _logger = logger;
            res = repository;
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

        




        public IActionResult ProductDetails(int id)
        {
            var result = res.GetProductById(id);
            return View(result);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
