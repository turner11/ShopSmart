using ShopSmart.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ShopSmart.Web.MVC.Controllers
{
    public class BaseController:Controller
    {
        protected SmartShopLogics _logics
        {
            get
            {
                return HttpContext.Application[SessionKeys.LOGICS] as SmartShopLogics;
            }
        }
    }
}
