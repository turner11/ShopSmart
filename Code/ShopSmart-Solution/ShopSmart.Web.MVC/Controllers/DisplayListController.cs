using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmart.Web.MVC.Controllers
{
    public class DisplayListController : BaseController
    {
        //
        // GET: /DisplayList/
        public ActionResult Index()
        {
            
            if (this._CurrentShopList == null)
            {
                return  RedirectToAction("Index","CreateList");
            }
            var view = View("DisplayList",this._CurrentShopList);
            return view;
        }
	}
}