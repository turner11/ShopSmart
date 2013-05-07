using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSmart.Dal
{
    /// <summary>
    /// Hanles access to Data base and data manipulation
    /// </summary>
    public class DataBase:IDisposable
    {
        
        /// <summary>
        /// The data base that we are working against
        /// </summary>
        ShopSmartEntities _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogics"/> class.
        /// </summary>
        public DataBase()
        {
            //Initializing the DAL
            this._db = new ShopSmartEntities();
            //we will have to detect and save changes manually
            this._db.Configuration.AutoDetectChangesEnabled = false;
            this._db.Configuration.LazyLoadingEnabled = true;
            this._db.Configuration.ProxyCreationEnabled= true;
            this._db.Configuration.ValidateOnSaveEnabled= true;
        }

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

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>DbSet of products</returns>
        public DbSet<Product> GetAllProducts()
        {
            return this._db.Products;
        }


        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>DbSet of products</returns>
        public IEnumerable<Category> GetAllCategories()
        {
            return this._db.Categories;
        }


        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>DbSet of products</returns>
        public IEnumerable<Supermarket> GetAllSuperMarkets()
        {
            return this._db.Supermarkets;
        }
    }
}
