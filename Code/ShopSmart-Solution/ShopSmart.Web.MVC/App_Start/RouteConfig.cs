﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopSmart.Web.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CreateList", action = "CreateList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DisplayList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DisplayList", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShopListHistory",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ShopListHistory", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
