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

        
        //POST: /CreateList/DisplayList
        [HttpPost]
        public ActionResult PostList(string listAsJson)
        {
            this._CurrentShopList = Code.JsonToDalObject.GetShopList(listAsJson, this._Products,this._Customer,this.GetSuperMarket(""));           
            
            //var v = RedirectToAction("Index","DisplayList");
            bool success = this._CurrentShopList != null;
            var result=new { Success= success?"True": "False", Message= success? "Success" :"Failure"};
   
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
     
        
    }
}
