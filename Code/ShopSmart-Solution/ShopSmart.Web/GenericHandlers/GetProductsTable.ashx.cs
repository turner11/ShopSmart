using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmart.Web
{
    /// <summary>
    /// Summary description for GetProductsTable
    /// </summary>
    public class GetProductsTable : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string[] parameters = context.Request.Params[0].Split(',');

            int superMarketId = 0;
            if (parameters.Length >0)
            {
                int.TryParse(parameters[0], out superMarketId);
                
            }

            string json = ShopSmartWebLogics.GetProductsAsJson(superMarketId);

            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}