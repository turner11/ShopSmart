using Newtonsoft.Json.Linq;
using ShopSmart.Bl;
using ShopSmart.Dal;
using System;
using System.Collections;
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
        
        /// <summary>
        /// Gets a sorted shop list from JSON string in expected format
        /// </summary>
        /// <param name="json">the json string</param>
        /// <returns>the shoplist</returns>
        public static ShopList GetShopList(string json, List<Product> allProducts, Customer customer, Supermarket market)
        {
            JObject jObject = JObject.Parse(json);
            JToken jlistData = jObject["listData"];
            JToken jlistItems = jlistData["listItems"];//jlistData.First;
            var AllItems = jlistItems.Where(token => token.HasValues).ToList();//jlistItems.Children()[1];//.FirstOrDefault()["Id"];

            int temp;
            var tuplesStr =  
                AllItems.OfType<JObject>()
                .Cast<IDictionary<string, JToken>>() //easier to handle as dictionary
                .Where(i => i.ContainsKey("Id") && i["Id"] !=null && !String.IsNullOrWhiteSpace(i["Id"].ToString())) //make sure ID is available
                .Select(i => new Tuple<string, string>( i["Id"].ToString() , i.ContainsKey("Quantity") ? i["Quantity"].ToString() : "1"))//get tuple with ID / quantity                
                 .Where(t => int.TryParse(t.Item1, out temp) && int.TryParse(t.Item2, out temp))//parse to int
                 .ToList();//list is easier to debug


            var quantityByProductDic= new Dictionary<Product,int>();
            //add products to dictionary
            tuplesStr.ToList()
                .ForEach(t => quantityByProductDic.Add(allProducts.FirstOrDefault(p => p.Id == int.Parse(t.Item1)), int.Parse(t.Item2)));

            
            ShopList sl = Logics.GetShoppingList(quantityByProductDic, market, customer);

            
            return sl;
             
        }
    }
}