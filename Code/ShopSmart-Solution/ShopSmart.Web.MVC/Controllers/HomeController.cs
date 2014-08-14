using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmart.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Shop smart. The easy way to shop!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our contact details";

            return View();
        }
    }
}