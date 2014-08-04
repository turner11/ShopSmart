using Newtonsoft.Json.Linq;
using ShopSmart.Bl;
using ShopSmart.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmart.Web.MVC.Code
{
    public static class JsonToDalObject
    {
        static SmartShopLogics _logics;
        static SmartShopLogics Logics
        {
            get
            {
                if (_logics == null)
                {
                    _logics = HttpContext.Current.Application[SessionKeys.LOGICS] as SmartShopLogics;
                }
                return _logics;
            }
        }
        

        public static ShopList GetShopList(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jlistData = jObject["listData"];
            var a = jlistData["Id"];
            JToken jlistItems = jlistData.First;
            var AllItems = jlistItems.Children()[1];//.FirstOrDefault()["Id"];
            ShopList sl = new ShopList();
            var products = Logics.GetAllProducts();
            foreach (var item in AllItems)
            {
                var product = products.Where(p => p.Id.ToString() == item["Id"].ToString()).FirstOrDefault();
                int quatinity  = 1;
                int.TryParse(item["Quantity"].ToString(), out quatinity);

                sl.ShoplistItems.Add(new ShoplistItem()
                    {
                        Product = product,
                        ProductId 
                        Quantity = quatinity,
                        ShopList = sl,                        
                        
                        
                    });
            }
            //name = (string)jUser["name"];
            //teamname = (string)jUser["teamname"];
            //email = (string)jUser["email"];
            //players = jUser["players"].ToArray();
            return null;
             
        }
    }
}