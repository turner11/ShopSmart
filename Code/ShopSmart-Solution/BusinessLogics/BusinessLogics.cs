using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ShopSmart.Dal;


namespace ShopSmart.Bl
{
    /// <summary>
    /// Handles All logics related to Shop lists
    /// </summary>
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
        {
            //Initializing the DAL
            this._db = new DataBase();
            //we will have to detect and save changes manually
            
        }


        /// <summary>
        /// Sorts the specified shop list.
        /// </summary>
        /// <param name="shoppingList">The shopping list.</param>
        public static void SortShopList(ShopList shoppingList)
        {
            
            
            //if we got a null, there is nothing for us to do
            if (shoppingList != null)
            {
                //the ordered items in
                IOrderedEnumerable<ShoplistItem> orderedItems = shoppingList.ShoplistItems.OrderBy(item => item.Product.Category.Id);
                shoppingList.ShoplistItems = orderedItems.ToList<ShoplistItem>();
                

            }
           
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
        /// <returns>list containg products</returns>
        public List<Product> GetAllProducts()
        {
            IEnumerable<Product> dbProducts = this._db.GetAllProducts() ?? (IEnumerable<Product>)new List<Product>();
            List<Product> products = dbProducts.ToList<Product>();
            return products;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>list containg products</returns>
        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> dbCategories = this._db.GetAllCategories() ?? (IEnumerable<Category>)new List<Category>();
            List<Category> categories = dbCategories.ToList<Category>();
            return categories;
        } 
        #endregion
    }
}
