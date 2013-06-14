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
    /// A form for manipulating a Category (crerating / editing)
    /// </summary>
    internal partial class CategoryForm : Form
    {
        #region Data members
        /// <summary>
        /// Gets the super market of the category.
        /// </summary>
        /// <value>
        /// The super market.
        /// </value>
        Supermarket _superMarket;

        Category _category;
        /// <summary>
        /// The category this instance is for
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public Category Category
        {
            get { return _category; }
            private set
            {
                this._category = value;
                this.SetCategoryFileds(this._category);
            }
        }

        /// <summary>
        /// Gets the sort. of category
        /// </summary>
        /// <value>
        /// The _sort.
        /// </value>
        CategorySort _sort
        {
            get
            {
                return this._category.GetSortBySuperMarket(this._superMarket);
            }
        }


        
        

      

        #endregion

        #region C'tors
        /// <summary>
        /// Gets a ceeate category form instance.
        /// </summary>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        internal static CategoryForm GetCreateCategoryInstance(Supermarket superMarket)
        {
            return new CategoryForm(null,superMarket);
        }

        /// <summary>
        /// Gets an edit category form instance.
        /// </summary>
        /// <param name="category">The Category.</param>
        /// <param name="categories">The categories.</param>
        /// <returns></returns>
        internal static CategoryForm GetEditCategoryInstance(Category category, Supermarket superMarket)
        {
            return new CategoryForm(category, superMarket);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProdcutForm"/> class.
        /// </summary>
        private CategoryForm(Category category, Supermarket superMarket)
        {
            InitializeComponent();
            this._superMarket = superMarket;
            this.Category = category ?? new CategoryNullObject(); 
        } 
        #endregion

        #region Private functions


        /// <summary>
        /// Sets the category fileds to match argument <see cref="Category"/>.
        /// </summary>
        /// <param name="category">The category.</param>
        private void SetCategoryFileds(Category category)
        {
            if (category != null)
            {
                this.txbCategoryName.Text = category.Name;
                CategorySort sort = category.GetSortBySuperMarket(this._superMarket);
                this.nupSortValue.Value = sort.SortValue;
            }
            else
            {
                this.txbCategoryName.Text = String.Empty;
                this.nupSortValue.Value = 0;
            }
        }


        /// <summary>
        /// Validates the category fields contains valid data for category.
        /// </summary>
        /// <returns></returns>
        private bool ValidateCategoryFields()
        {
            bool valid = true;
            valid &= !String.IsNullOrWhiteSpace(this.txbCategoryName.Text);
            valid &= this.nupSortValue.Value >= 0;
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
            bool validated = this.ValidateCategoryFields();
            if (validated)
            {
                //in case we are dealing with new
                this._category = this._category ?? new Category();

                
                this._category.Name = this.txbCategoryName.Text;
                this._category.GetSortBySuperMarket(this._superMarket).SortValue = (int)this.nupSortValue.Value;                
                

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
            this.Category = null;
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
            
        }
    }
}
