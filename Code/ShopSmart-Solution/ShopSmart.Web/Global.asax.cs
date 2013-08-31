using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using ShopSmart.Web;

namespace ShopSmart.Web
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //getting items from database
            List<ShopSmart.Dal.Product> products = ShopSmartWebLogics.SmLogics.GetAllProducts();
            List<ShopSmart.Dal.Product> supermarkets = ShopSmartWebLogics.SmLogics.GetAllProducts();
            List<ShopSmart.Dal.Category> categories = ShopSmartWebLogics.SmLogics.GetAllCategories();
           
            //Caching DB items
            ShopSmartWebLogics.Cache.Insert(ShopSmartWebLogics.PRODUCTS_KEY, products);
            ShopSmartWebLogics.Cache.Insert(ShopSmartWebLogics.SUPERMARKETS_KEY, supermarkets);
            ShopSmartWebLogics.Cache.Insert(ShopSmartWebLogics.CATEGORIES_KEY, categories);

            //TODO: add dependencies and exparations
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            

        }
    }
}
