using System;
using System.Collections.Generic;
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
        ShopSmartEntities _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogics"/> class.
        /// </summary>
        public BusinessLogics()
        {
            //Initializing the DAL
            this._db = new ShopSmartEntities();
            //we will have to detect and save changes manually
            this._db.Configuration.AutoDetectChangesEnabled = false;
            this._db.Configuration.LazyLoadingEnabled = true;
            this._db.Configuration.ProxyCreationEnabled= true;
            this._db.Configuration.ValidateOnSaveEnabled= true;
        }


        /// <summary>
        /// Sorts the specified shop list.
        /// </summary>
        /// <param name="shoppingList">The shopping list.</param>
        private void SortShopList(ShopList shoppingList)
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
    }
}
