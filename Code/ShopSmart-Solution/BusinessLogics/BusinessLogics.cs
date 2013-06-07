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
    public class SmartShopLogics:IDisposable
    {

        /// <summary>
        /// The data base that we are working against
        /// </summary>
        DataBase _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartShopLogics"/> class.
        /// </summary>
        public SmartShopLogics()
            : this(new DataBase())
        {
           
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartShopLogics"/> class.
        /// </summary>
        /// <param name="db">The database object.</param>
        public SmartShopLogics(DataBase db)
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
            List<Product> products = dbProducts.OrderBy(p=>p.ProductName).ToList<Product>();
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


        /// <summary>
        /// Authenticates a user by username and password.
        /// </summary>
        /// <param name="userName">the username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="ShopSmart.Dal.User"/> object that represents the authenticated user
        /// null if authentication failse</returns>
        public Customer AuthenticateUser(string userName, string password)
        {
            List<Customer> users = this._db.GetCustomers(userName, password, null);
            #region Assert single value
            System.Diagnostics.Debug.Assert(users.Count <= 1,
                                               String.Format("Unexpectedly got {0} users when filtering by:\n"
                                               + "Username: {1}\n"
                                               + "Password: {2}"
                                               , users.Count
                                               , userName
                                               , password)); 
            #endregion
            //we can return a value only if we get a sinle result
            return users.Count == 1? users[0] : null;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userName">userName.</param>
        /// <param name="password">The password.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="errorMessage">The out errorMessage in case of an error.</param>
        /// <returns>
        /// the user if created; null if failed to create
        /// </returns>
        public Customer CreateCustomer(string userName, string password, UserTypes userType, string customerId, out string errorMessage)
        {
            return this._db.CreateCustomer(userName, password, userType, customerId,out errorMessage);
        }

        /// <summary>
        /// Saves the specified products to database.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <param name="errorMessage">The error message in case an error occures.</param>
        /// <returns>true upon success, false otherwise</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Save(List<Product> products, out string errorMessage)
        {
            return this._db.Save(products, out errorMessage);
        }

        /// <summary>
        /// Saves the changes to database.
        /// </summary>
        /// <param name="errorMessage">The error message, in case an error has occured.</param>
        /// <returns>true upon success, false otherwise</returns>
        private bool SaveChanges(out string errorMessage)
        {
            return this._db.SaveChanges(out errorMessage);
        }
    }
}
