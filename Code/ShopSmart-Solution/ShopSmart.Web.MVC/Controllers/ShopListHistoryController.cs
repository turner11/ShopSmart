using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmart.Web.MVC.Controllers
{
    public class ShopListHistoryController : BaseController
    {
        //
        // GET: /ShopListHistory/
        public ActionResult Index()
        {
            if (this._Customer == null)
            {
                return RedirectToAction("Index", "CreateList");

            }
            else
            {
                var lists = this._logics.GetArchivedLists(this._Customer) ?? new List<ShopSmart.Dal.ShopList>();
                return View(lists);
            }
            
        }
	}
}