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
            var ff = jlistItems.First.Next.Next["Id"];
            object id = null;
            foreach (var aa in jlistItems)
            {
                foreach (var bb in aa)
                {
                    
                    id = bb["Id"];
                    var cc = bb.ToString();

                }
                
            }
            //name = (string)jUser["name"];
            //teamname = (string)jUser["teamname"];
            //email = (string)jUser["email"];
            //players = jUser["players"].ToArray();
            return null;
             
        }
    }
}