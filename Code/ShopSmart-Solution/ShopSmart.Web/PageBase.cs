using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ShopSmart.Dal;

namespace ShopSmart.Web
{
    /// <summary>
    /// A base page with elements that all pages across site requires
    /// </summary>
    public class PageBase : Page
    {

        #region Data members
        /// <summary>
        /// Gets the Supermarkets list.
        /// </summary>
        protected List<Supermarket> _superMarkets
        {
            get { return ShopSmartWebLogics.SuperMarkets; }
        }

        /// <summary>
        /// Gets the Category list.
        /// </summary>
        protected List<Category> _categories
        {
            get { return ShopSmartWebLogics.Categories; }
        }

        /// <summary>
        /// Gets the products list.
        /// </summary>
        protected List<Product> _products
        {
            get { return ShopSmartWebLogics.Products; }
        } 
        #endregion

        
    }
}