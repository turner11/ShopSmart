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

        //POST: /CreateList/DisplayList
        [HttpPost]
        public ActionResult PostListIndex(string listIndex)
        {
            bool success = true;
            int id;
            if (int.TryParse(listIndex, out id))
            {
                this._CurrentShopList =
                this._logics.GetArchivedLists(this._Customer).Where(l => l.Id == id).FirstOrDefault();

                success = this._CurrentShopList != null;
            }
            else
            {
                success = false;
            }

            var result = new { Success = success ? "True" : "False", Message = success ? "Success" : "Failure" };

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}