using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        /// The language key at request 
        /// </summary>
        const string REQUEST_LANGUAGE_KEY = "lang";
        /// <summary>
        /// The language key at session 
        /// </summary>
        const string SESSION_LANGUAGE_KEY = REQUEST_LANGUAGE_KEY;
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

        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request[REQUEST_LANGUAGE_KEY]))
            {

                Session[SESSION_LANGUAGE_KEY] = Request[REQUEST_LANGUAGE_KEY];
            }
            string lang = Convert.ToString(Session[SESSION_LANGUAGE_KEY]);
            string culture = string.Empty;
            /* // In case, if you want to set vietnamese as default language, then removing this comment
            if(lang.ToLower().CompareTo("vi") == 0 ||string.IsNullOrEmpty(culture))
            {               
				culture = "vi-VN";
            }
             */
            if (lang.ToLower().CompareTo("en") == 0 || string.IsNullOrEmpty(culture))
            {
                culture = "en-US";
            }
            else if (lang.ToLower().CompareTo("he") == 0)
            {
                culture = "he";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
    }

        
    
}