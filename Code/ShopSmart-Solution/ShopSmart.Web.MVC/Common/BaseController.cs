using ShopSmart.Bl;
using ShopSmart.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ShopSmart.Web.MVC.Controllers
{
    public class BaseController:Controller
    {
        /// <summary>
        /// The logics to use for model actions
        /// </summary>
        protected SmartShopLogics _logics
        {
            get
            {
                return HttpContext.Application[SessionKeys.LOGICS] as SmartShopLogics;
            }
        }

        /// <summary>
        /// The current shop list for the current session
        /// </summary>
        protected List<Product> _Products
        {
            get
            {
                if (Session[SessionKeys.Products]  == null)
                {
                    Session[SessionKeys.Products] = this._logics.GetAllProducts();
                }
                return Session[SessionKeys.Products] as List<Product>; 
            }
        }

        /// <summary>
        /// The current shop list for the current session
        /// </summary>
        protected ShopList _CurrentShopList
        {
            get { return Session[SessionKeys.JSON_LIST] as ShopList; }
            set { Session[SessionKeys.JSON_LIST] = value; }
        }

        protected Customer _Customer{
            get { return Session[SessionKeys.CUSTOMER] as Customer; }
            set { Session[SessionKeys.CUSTOMER] = value; }
        }

        protected List<Supermarket> _Markets{
            get
            {
                if (Session[SessionKeys.MARKETS] == null)
                {
                    Session[SessionKeys.MARKETS] = this._logics.GetAllSuperMarkets();
                }
                 return Session[SessionKeys.MARKETS] as List<Supermarket>; }
            set { Session[SessionKeys.MARKETS] = value; }
        }


        
             
    }
}
