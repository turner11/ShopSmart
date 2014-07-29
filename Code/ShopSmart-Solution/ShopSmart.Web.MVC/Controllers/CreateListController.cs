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

        
     
        //
        // GET: /CreateList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CreateList/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CreateList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CreateList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CreateList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CreateList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CreateList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
