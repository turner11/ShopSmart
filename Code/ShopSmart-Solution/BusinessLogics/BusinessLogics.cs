using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Services;
using ShopSmart.Dal;


namespace ShopSmart.Bl
{
    /// <summary>
    /// Handles All logics related to Shop lists
    /// </summary>   
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BusinessLogics:IDisposable
    {

        /// <summary>
        /// The data base that we are working against
        /// </summary>
        DataBase _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogics"/> class.
        /// </summary>
        public BusinessLogics()
            : this(new DataBase())
        {
           
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogics"/> class.
        /// </summary>
        /// <param name="db">The database object.</param>
        public BusinessLogics(DataBase db)
        {
            //Initializing the DAL
            this._db = db;
        }

        /// <summary>
        /// The web service for getting a sorted list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>a sorted list</returns>
        [WebMethod]
        public ShopList GetSortedList(ShopList list)
        {
            this.SortShopList(list);
            return list;
        }

        /// <summary>
        /// Sorts the specified shop list.
        /// </summary>
        /// <param name="shoppingList">The shopping list.</param>
        private void SortShopList(ShopList shoppingList)
        {
            Array items = shoppingList.ShoplistItems.ToArray<ShoplistItem>();
            Array.Sort(items);
            shoppingList.ShoplistItems = (ICollection<ShoplistItem>)items;            
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this._db.Dispose();
            }
            catch (Exception ex)
            {
                ex.ToString();
                //nothing to do here
                //TODO: Add log
            }
        }

        //TODO: Make this generic
        #region Get items from DB
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>list of products</returns>
        public List<Product> GetAllProducts()
        {
            IEnumerable<Product> dbProducts = this._db.GetAllProducts() ?? (IEnumerable<Product>)new List<Product>();
            List<Product> products = dbProducts.ToList<Product>();
            return products;
        }

        //TODO: Make this generic
        /// <summary>
        /// Gets all SuperMarkets.
        /// </summary>
        /// <returns>list of SuperMarkets</returns>
        public List<Supermarket> GetAllSuperMarkets()
        {
            IEnumerable<Supermarket> dbSupermarket = this._db.GetAllSuperMarkets() ?? (IEnumerable<Supermarket>)new List<Supermarket>();
            List<Supermarket> supers = dbSupermarket.ToList<Supermarket>();
            return supers;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>list of products</returns>
        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> dbCategories = this._db.GetAllCategories() ?? (IEnumerable<Category>)new List<Category>();
            List<Category> categories = dbCategories.ToList<Category>();
            return categories; 
        } 
        #endregion

    }
}
