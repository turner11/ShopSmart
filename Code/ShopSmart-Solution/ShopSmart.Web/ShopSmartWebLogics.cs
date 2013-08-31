using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using ShopSmart.Dal;
using System.Web.Script.Serialization;

namespace ShopSmart.Web
{
    internal static class ShopSmartWebLogics
    {
        #region Constants
        /// <summary>
        /// The products cache key
        /// </summary>
        internal const string PRODUCTS_KEY = "products";
        /// <summary>
        /// The supermarkets cache key
        /// </summary>
        internal const string SUPERMARKETS_KEY = "supermarkets";
        /// <summary>
        /// The categories cache key
        /// </summary>
        internal const string CATEGORIES_KEY = "categories";
        #endregion

        #region Data members

        /// <summary>
        /// The cache lock object
        /// </summary>
        static object cacheLock;
        /// <summary>
        /// The shop smart logics
        /// </summary>
        internal static readonly ShopSmart.Bl.SmartShopLogics SmLogics;

        /// <summary>
        /// Gets the <see cref="T:System.Web.Caching.Cache" /> object associated with the application in which the page resides.
        /// </summary>
        /// <returns>The <see cref="T:System.Web.Caching.Cache" /> associated with the page's application.</returns>
        internal static System.Web.Caching.Cache Cache
        {
            get
            {   
                return (System.Web.HttpContext.Current == null) ?
                    System.Web.HttpRuntime.Cache :
                    System.Web.HttpContext.Current.Cache;
            }
        }

        /// <summary>
        /// Gets the Supermarkets list.
        /// </summary>
        internal static List<Supermarket> SuperMarkets
        {
            get
            {
                lock (cacheLock)
                {
                    return ShopSmartWebLogics.Cache.Get(ShopSmartWebLogics.SUPERMARKETS_KEY) as List<Supermarket>;
                }
            }
        }

        /// <summary>
        /// Gets the Category list.
        /// </summary>
        internal static List<Category> Categories
        {
            get
            {
                lock (cacheLock)
                {
                    return ShopSmartWebLogics.Cache.Get(ShopSmartWebLogics.CATEGORIES_KEY) as List<Category>;
                }
            }
        }

        /// <summary>
        /// Gets the products list.
        /// </summary>
        internal static List<Product> Products
        {

            get
            {
                lock (cacheLock)
                {
                    return ShopSmartWebLogics.Cache.Get(ShopSmartWebLogics.PRODUCTS_KEY) as List<Product>;
                }
            }
        }

        #endregion

        #region C'tors
        /// <summary>
        /// Initializes the <see cref="PageBase"/> class.
        /// </summary>
        static ShopSmartWebLogics()
        {
            ShopSmartWebLogics.cacheLock = new object();
            ShopSmartWebLogics.SmLogics = new Bl.SmartShopLogics();
        } 
        #endregion

       

        #region String to table

        internal static string GetProductsAsJson(int superMarketId)
        {
            List<Product> products = ShopSmartWebLogics.Products;
            //DataTable dt = new DataTable();

            //dt.Columns.Add("col1");
            //dt.Columns.Add("col2");
            //dt.Columns.Add("col3");
            //dt.Rows.Add(new object[] { "a", "b", "c" });
            //dt.Rows.Add(new object[] { "d", "e", "f" });

            //string json = GetJsonFromProducts(products);


            //Use anonymus types to display only what we want...
            var flatProducts = products.Select(p => new
                                {
                                    ProductId = p.Id,
                                    ProductName = p.ProductName,
                                    CategoryId = p.CategoryID,
                                    CategoryName = p.Category.Name,
                                    Price = p.Price ?? 0,
                                }
           );

            var json = new JavaScriptSerializer().Serialize(flatProducts);

            return json;
        }

        private static string GetJsonFromProducts(List<Product> products)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            string template = "ProductId:{0}, ProductName:'{1}', CategoryId:{2}, CategoryName:'{3}', Price:{4}";
            foreach (Product p in products)
            {
                sb.Append("{");
                sb.Append(String.Format(template, p.Id, p.ProductName, p.CategoryID, p.Category.Name, p.Price ?? 0));
                sb.Append("},");
                if (products.IndexOf(p) > 3)
                {
                    break;
                }
            }
                        //removing last comma
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return sb.ToString();
        }

       
        #endregion
    }
}