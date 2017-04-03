using jQuery_AutoComplete_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap_AutoComplete_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            //NorthwindEntities entities = new NorthwindEntities();
            //var customers = (from customer in entities.Customers
            //                 where customer.ContactName.StartsWith(prefix)
            //                 select new
            //                 {
            //                     label = customer.ContactName,
            //                     val = customer.CustomerID
            //                 }).ToList();

            var customers = new List<CustomerModel>
            {
                new CustomerModel {
                    CustomerID = 1,
                    ContactName = "Gaurav"
                },
                new CustomerModel {
                    CustomerID = 2,
                    ContactName = "Sunny"
                },
                new CustomerModel {
                    CustomerID = 3,
                    ContactName = "Harjot"
                },

            };

            return Json(customers);
        }

        [HttpPost]
        public ActionResult Index(string CustomerName, string CustomerId)
        {
            ViewBag.Message = "CustomerName: " + CustomerName + " CustomerId: " + CustomerId;
            return View();
        }
    }
}