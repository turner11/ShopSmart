using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmart.Web.MVC.Controllers
{
    public class CreateListController : BaseController
    {
        //
        // GET: /CreateList/
        public ActionResult Index()
        {

            var settings = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ShopSmartEntities"];

            //var con = new System.Data.SqlClient.SqlConnection();
            var shopListCandidatesItems = this._logics.GetAllShoplistCandidates();
            return View(shopListCandidatesItems); 
        }
        //GET: /CreateList/DisplayList
        public ActionResult DisplayList()
        {
            return RedirectToAction("Index","DisplayList");
            return View();
        }
     
        
    }
}
