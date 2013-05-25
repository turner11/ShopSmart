﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopSmart.Bl;
using ShopSmart.Dal; //TODO: Find way to remove this reference!
using ShopSmart.Common;
using System.Diagnostics;
using System.IO;
using Log;

namespace ShopSmart.Client
{
    /// <summary>
    /// The GUI for client side
    /// </summary>
    public partial class ClientForm : Form
    {
        #region Data Members

        //TODO: Replace with web service
        /// <summary>
        /// The logics handler object
        /// </summary>
        SmartShopLogics _logicsService;
        /// <summary>
        /// The products that are in database
        /// </summary>
        List<Product> _products;
        /// <summary>
        /// The categories that are in database
        /// </summary>
        List<Category> _categories;
        /// <summary>
        /// The super markets that are in database
        /// </summary>
        List<Supermarket> _superMarkets;

        Customer _currentUser;
        /// <summary>
        /// The current user that is logged in. null if none
        /// </summary>
        Customer CurrentUser
        {
            get { return this._currentUser; }
            set
            {
                this._currentUser = value;
                Logger.Log(String.Format("User was set to {0}", this._currentUser != null?this._currentUser.ToString() : "null"));
                this.MatchGuiToUserType(this.CurrentUserType);

            }
        }

        /// <summary>
        /// Gets the type of the current user, null if there is no current user.
        /// </summary>
        UserTypes? CurrentUserType
        {
            get
            {
                UserTypes? type = null;
                if (this.CurrentUser != null)
                {
                    type = this.CurrentUser.UserType;
                }
                return type;
            }
        }

        
        

        #endregion

        #region C'tors
        public ClientForm()
        {
            InitializeComponent();
            this._logicsService = new SmartShopLogics();
            this.GetDbItems();
            this.BindProducts();
            this.BindCategories();
            this.BindSuperMarkets();
            this.SetAllCategoriesdCheckState(true);



            //this.SetIcon();
        }



        #endregion

        #region Private functions
        /// <summary>
        /// Gets required Items from Database.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void GetDbItems()
        {
            this._products = this._logicsService.GetAllProducts();
            Logger.Log(String.Format("Got {0} products from logics", this._products.Count));
            this._categories = this._logicsService.GetAllCategories();
            Logger.Log(String.Format("Got {0} categories from logics", this._categories.Count));
            this._superMarkets = this._logicsService.GetAllSuperMarkets();
            Logger.Log(String.Format("Got {0} supermarkets from logics", this._superMarkets.Count));

        }

        /// <summary>
        /// Binds the products to grid view.
        /// </summary>
        private void BindProducts()
        {
            Logger.Log("Binding products grid view");
            // this.CreateShoppingData();
            this.gvProducts.DataSource = this._products;
            Logger.Log("Binded products grid view");
        }

        /// <summary>
        /// Binds the categories to list box.
        /// </summary>
        private void BindCategories()
        {
            Logger.Log("Binding categories");
            this.cblCategories.DataSource = this._categories;
            Logger.Log("Binded categories");
        }
        /// <summary>
        /// Binds the supermarkets to combobox.
        /// </summary>
        private void BindSuperMarkets()
        {
            Logger.Log("Binding supermarkets");
            this.cmbSuperMarkets.DataSource = this._superMarkets;
            this.cmbSuperMarkets.DisplayMember = "Name";
            //HACK: this is just for having by default a value that i got data for
            this.cmbSuperMarkets.SelectedItem = this.cmbSuperMarkets.Items[this.cmbSuperMarkets.Items.Count - 1];
            Logger.Log("Binded supermarkets");
        }

        /// <summary>
        /// Checks / un Checks the check boxes for all categories.
        /// </summary>
        /// <param name="isChecked">if set to <c>true</c> will check check boxes of all categories. 
        /// otherwise, will uncheck.</param>
        private void SetAllCategoriesdCheckState(bool isChecked)
        {
            Logger.Log(String.Format("Setting all categories to be {0}", isChecked ? "Checked" : "UnChecked"));
            for (int i = 0; i < this.cblCategories.Items.Count; i++)
            {
                this.cblCategories.SetItemChecked(i, isChecked);

            }
        }

        /// <summary>
        /// Gets a shopping based on data in GUI.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private ShopList GetShoppingListFromGui()
        {
            Logger.Log("Getting shopping list from gui");
            ShopList list = new ShopList();
            

            foreach (DataGridViewRow currRow in this.gvProducts.Rows)
            {
                bool toBuy = Convert.ToBoolean( currRow.Cells[this.clmToBuy.Index].Value);
                DataGridViewCell cllQuant = currRow.Cells[this.clmQuantity.Index];
                int quantity;
                if (toBuy && cllQuant.Value != null && int.TryParse(cllQuant.Value.ToString(),out quantity))
                {
                    ShoplistItem item = new ShoplistItem();
                    item.Product = (Product)currRow.DataBoundItem;
                    item.Quantity = quantity;
                    item.ShopList = list;
                    list.ShoplistItems.Add(item);
                }
            }


            Supermarket market = this.cmbSuperMarkets.SelectedItem as Supermarket;
            list.Supermarket = market;
            list.SuperMarketId = market.Id;
            Logger.Log(String.Format("got shopping list from gui: {0}", list.ToString()));
            return list;
        }

        /// <summary>
        /// Matches the GUI to specified user type.
        /// </summary>
        /// <param name="nullable">The nullable.</param>
        private void MatchGuiToUserType(UserTypes? userType)
        {
            if (userType.HasValue)
            {
                switch (userType.Value)
                {
                    case UserTypes.Admininstrator:
                        break;
                    case UserTypes.Editor:
                        break;
                    case UserTypes.User:
                        break;
                    default:
                        break;
                }
            }
        }

        

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the ItemCheck event of the cblCategories control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        void cblCategories_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //finding out which category we are talking about
            Category category = this.cblCategories.Items[e.Index] as Category;
            BindingManagerBase bindingContext = this.gvProducts.BindingContext[this.gvProducts.DataSource];
            if (category != null && bindingContext != null)
            {
                //getting all rows that contains products with the category weare dealing with   
                //TODO: use a parameter and not fixed "9"
                IEnumerable<DataGridViewRow> enumeratedRows =
                    this.gvProducts.Rows.Cast<DataGridViewRow>().Where(row => (row.Cells[9].Value as Category) != null
                                                                     && (row.Cells[9].Value as Category).guid == category.guid);

                List<DataGridViewRow> relevantRows = enumeratedRows.ToList();

                //setting visibility
                bool showRows = e.NewValue == CheckState.Checked;

                bindingContext.SuspendBinding();
                this.gvProducts.SuspendLayout();
                
                relevantRows.ForEach(row => row.Visible = showRows);

                this.gvProducts.ResumeLayout(true);
                bindingContext.ResumeBinding();

            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chbCheckAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            this.SetAllCategoriesdCheckState(this.chbCheckAll.Checked);
        }

        /// <summary>
        /// Handles the Click event of the btnSend control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            ShopList shoppingList = this.GetShoppingListFromGui();


            ShopList soretd = this._logicsService.GetSortedList(shoppingList);

            ClientForm.ExportListToExcel(soretd);
        }

        /// <summary>
        /// Exports the list to excel.
        /// </summary>
        /// <param name="shopList">The shop list.</param>
        private static void ExportListToExcel(ShopList shopList)
        {
            FileExporter.ExcelExporter exporter = new FileExporter.ExcelExporter();
            CarlosAg.ExcelXmlWriter.Workbook book = exporter.Generate(shopList);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "ShopList.xls";
            sfd.Filter = "Excel XML Documents (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                String filename = sfd.FileName;
                if (!filename.EndsWith("xls"))
                {
                    filename += "xls";
                }
                try
                {
                    book.Save(filename);

                    //File.Open(filename, FileMode.OpenOrCreate);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        /// <summary>
        /// Handles the CellEndEdit event of the gvProducts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void gvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.gvProducts.Rows[e.RowIndex];
            DataGridViewCell cllQuant = row.Cells[this.clmQuantity.Index];
            DataGridViewCheckBoxCell cllToBuy = row.Cells[this.clmToBuy.Index] as DataGridViewCheckBoxCell;

            if (e.ColumnIndex == this.clmQuantity.Index)
            {
                #region Remove to buy mark if quantity is 0
                
                object objQuant = cllQuant.Value;
                int quantity;
                if (objQuant != null && int.TryParse(objQuant.ToString(), out quantity))
                {
                   
                    if (cllToBuy != null)
                    {
                        cllToBuy.Value = quantity > 0;
                    }
                    else
                    {
                        Logger.Log("Could not find to-buy cell");
                    }
                } 
                #endregion
            }
            else if (e.ColumnIndex == this.clmToBuy.Index)
            {
                bool toBuy = Convert.ToBoolean(cllToBuy.Value) ;
                if (!toBuy)
                {
                    cllQuant.Value = String.Empty;
                }
                else if (String.IsNullOrEmpty(cllQuant.Value as string)|| int.Parse(cllQuant.Value.ToString()) == 0)
                {
                    //if was marked to buy, make sure there is a quantity
                    cllQuant.Value = 1;
                }
            }

        }

        /// <summary>
        /// Handles the EditingControlShowing event of the gvProducts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewEditingControlShowingEventArgs"/> instance containing the event data.</param>
        private void gvProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.gvProducts.CurrentCell.ColumnIndex == this.clmQuantity.Index)
            {
                //bind to the text box...
                TextBox cellTb = e.Control as TextBox;
                if (cellTb != null)
                {
                    cellTb.KeyPress += QuntityTextBox_TextChanged;
                }

            }
        }

        /// <summary>
        /// Handles the TextChanged event of the QuntityTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        void QuntityTextBox_TextChanged(object sender, KeyPressEventArgs e)
        {
            //Allow only digits
            if (!char.IsControl(e.KeyChar)
                   && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// Handles the Click event of the tsLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsLogin_Click(object sender, EventArgs e)
        {
            bool isCurrentUserAdmin = this.CurrentUserType.HasValue && this.CurrentUserType.Value == UserTypes.Admininstrator;
            LoginForm frmLogin = new LoginForm(LoginForm.LoginType.Login, isCurrentUserAdmin);
            if (frmLogin.ShowDialog(this) == DialogResult.OK)
            {
                /*Getting user by user name / password */
                this.CurrentUser = this._logicsService.AuthenticateUser(frmLogin.UserName, frmLogin.Password);
            }
        }

        private void tsRegister_Click(object sender, EventArgs e)
        {
            bool isCurrentUserAdmin = this.CurrentUserType.HasValue && this.CurrentUserType.Value == UserTypes.Admininstrator;
            LoginForm frmLogin = new LoginForm(LoginForm.LoginType.CreateNewUser, isCurrentUserAdmin);
            if (frmLogin.ShowDialog(this) == DialogResult.OK)
            {
                /*Creating user*/
                string message;
                this.CurrentUser = 
                    this._logicsService.CreateCustomer(frmLogin.UserName, frmLogin.Password, UserTypes.User,frmLogin.UserId, out message);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txbFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txbFilter_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

       

    }
}
