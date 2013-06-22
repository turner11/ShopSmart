using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopSmart.Dal;

namespace ShopSmart.Client
{
    /// <summary>
    /// A form for manipulating a Product (crerating / editing)
    /// </summary>
    internal partial class ProductForm : Form
    {
        #region Data members

        /// <summary>
        /// Gets the super market of the category.
        /// </summary>
        /// <value>
        /// The super market.
        /// </value>
        Supermarket _superMarket;
        
        Product _product;
        /// <summary>
        /// The product this instance is for
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public Product Product
        {
            get { return _product; }
            private set
            {
                this._product = value;
                this.SetProductFileds(this._product);
            }
        }

        
        IEnumerable<Category> _categories;
        /// <summary>
        /// The available categories for products
        /// </summary>
        private IEnumerable<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                this.BindCategories(this._categories);
            }
        }

      

        #endregion

        #region C'tors
        /// <summary>
        /// Gets a ceeate product form instance.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        internal static ProductForm GetCreateProductInstance(IEnumerable<Category> categories, Supermarket superMarket)
        {
            return new ProductForm(null, categories, superMarket);
        }

        /// <summary>
        /// Gets an edit product form instance.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        internal static ProductForm GetEditProductInstance(Product product, IEnumerable<Category> categories,  Supermarket superMarket)
        {
            return new ProductForm(product, categories, superMarket);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProdcutForm"/> class.
        /// </summary>
        private ProductForm(Product product, IEnumerable<Category> categories, Supermarket superMarket)
        {
            InitializeComponent();
            
            this._superMarket = superMarket;
            this.Categories = categories;
            this.Product = product;
            
           

        } 
        #endregion

        #region Private functions


        /// <summary>
        /// Sets the product fileds to match argument <see cref="Product"/>.
        /// </summary>
        /// <param name="product">The product.</param>
        private void SetProductFileds(Product product)
        {
            if (product != null)
            {
                this.txbProductName.Text = product.ProductName;
                this.nupPrice.Value = product.Price ?? 0 ;
                this.cmbCategory.SelectedItem = product.Category;
            }
            else
            {
                this.txbProductName.Text = String.Empty;
                this.nupPrice.Value = 0;
            }
        }

        /// <summary>
        /// Binds the categories combobox  to argument enumerable.
        /// </summary>
        /// <param name="categoris">The categoris.</param>
        private void BindCategories(IEnumerable<Category> categoris)
        {
           
            if (categoris != null)
            {
                BindingList<Category> bindedCategories = new BindingList<Category>();
                foreach (Category category in categoris)
                {
                    bindedCategories.Add(category);
                }

                this.cmbCategory.DataSource = bindedCategories;
            }
        }

        /// <summary>
        /// Validates the product fields contains valid data for product.
        /// </summary>
        /// <returns></returns>
        private bool ValidateProductFields()
        {
            bool valid = true;
            valid &= !String.IsNullOrWhiteSpace(this.txbProductName.Text);
            valid &= this.nupPrice.Value >= 0;
            valid &= (this.cmbCategory.SelectedItem as Category) != null;
            return valid;

        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            bool validated = this.ValidateProductFields();
            if (validated)
            {
                //in case we are dealing with new
                this._product = this._product ?? new Product();
                this._product.ProductName = this.txbProductName.Text;
                this._product.Price = this.nupPrice.Value;
                this._product.Category = this.cmbCategory.SelectedItem as Category;
                this._product.CategoryID = this._product.Category.Id;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "המידע שהוזן אינו תקין");
            }

        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Product = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        } 
        #endregion

        /// <summary>
        /// Handles the Click event of the btnEditCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            CategoryForm frmCategories = CategoryForm.GetEditCategoryInstance(this.cmbCategory.SelectedItem as Category, this._superMarket);
            frmCategories.ShowDialog(this);
            this.DialogResult = DialogResult.None; //this is for preventing form from closing unexpectedly
            
            if (frmCategories.DialogResult == DialogResult.OK)
            {
                //refreshing...
                this.BindCategories(this._categories);
            }

        }

        private void btnEditComercials_Click(object sender, EventArgs e)
        {
            EditCommercials frmCommercials = new EditCommercials(this._product);
            frmCommercials.ShowDialog();
        }
    }
}
