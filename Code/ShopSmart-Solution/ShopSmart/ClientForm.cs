using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopSmart.Bl;
using ShopSmart.Common;
using ShopSmart.Dal; //TODO: Find way to remove this reference!

namespace ShopSmart.Client
{
    /// <summary>
    /// The GUI for client side
    /// </summary>
    public partial class ClientForm : Form
    {

        //TODO: Replace with web service
        /// <summary>
        /// The logics handler object
        /// </summary>
        BusinessLogics _logics;

        /// <summary>
        /// The products that are in database
        /// </summary>
        List<Product> _products;
        /// <summary>
        /// The categories that are in database
        /// </summary>
        List<Category> _categories;

        public ClientForm()
        {
            InitializeComponent();
            this._logics = new BusinessLogics();
            this.GetDbItems();
            this.BindProducts();
            this.BindCategories();
            //this.SetIcon();
        }

        /// <summary>
        /// Gets required Items from Database.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void GetDbItems()
        {
            this._products= this._logics.GetAllProducts();
            this._categories = this._logics.GetAllCategories();
        }

        /// <summary>
        /// Binds the products to grid view.
        /// </summary>
        private void BindProducts()
        {
            this.gvProducts.DataSource = this._products;
        }

        /// <summary>
        /// Binds the categories to list box.
        /// </summary>
        private void BindCategories()
        {
            this.cblCategories.DataSource = this._categories;
        }

        private void SetIcon()
        {
            //System.Resources.ResourceManager resources =
            //                        new System.Resources.ResourceManager(typeof(Utils));

            //this.Icon = (Icon)resources.GetObject("Clock");
        }

        
    }
}
