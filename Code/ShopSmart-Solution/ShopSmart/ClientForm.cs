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
using ShopSmart.Dal; //TODO: Find way to remove this reference!
using ShopSmart.Common;
using System.Diagnostics;
using System.IO;
using Log;
using System.Collections.ObjectModel;

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
        readonly SmartShopLogics _logicsService;
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
                if (this._currentUser != null)
                {
                    this.Text = this.CurrentUser.UserName;
                    
                }
                else
                {
                    this.Text = "משתמש לא רשום";
                }

                this.MatchGuiToUserType();

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

        /// <summary>
        /// Gets the _selected super market in the super market conmbo box.
        /// </summary>
        /// <value>
        /// The _selected super market.
        /// </value>
        private Supermarket _selectedSuperMarket
        {
            get { return this.cmbSuperMarkets.SelectedItem as Supermarket; }

        }




        #endregion

        #region C'tors
        
        public ClientForm()
        {
            InitializeComponent();
            this._logicsService = new SmartShopLogics();
            this.GetDbItems();
            this.BindSuperMarkets();
            this.BindCategories();
            this.BindProducts();
            this.SetAllCategoriesdCheckState(true);
            this.MatchGuiToUserType();
            



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

            DataTable dtProducts = this.GetTableFromProductsList(this._products);

            this.gvProducts.DataSource = dtProducts;

            // setting headers and column visibility
            foreach (DataGridViewColumn col in this.gvProducts.Columns)
            {
                DataColumn dataCol = dtProducts.Columns[col.Name];
                //we need to check because we have some unbound columns
                if (dataCol != null)
                {
                    col.HeaderText = dataCol.Caption;
                }
                
            }

           
            Logger.Log("Binded products grid view");
        }

        /// <summary>
        /// Gets the table from products list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>a datatable containg information in list</returns>
        private DataTable GetTableFromProductsList(IEnumerable<Product> list)
        {
            DataTable dt = ClientForm.BuildProductsTableStructure();
            dt.TableName = "Products";
            this.PopulateFormattedTable(dt, list);


            return dt;
        }

        /// <summary>
        /// Populates the formatted table.
        /// </summary>
        /// <param name="dt">The structured table.</param>
        /// <param name="list">The list.</param>
        private void PopulateFormattedTable(DataTable dt, IEnumerable<Product> list)
        {
            foreach (Product product in list)
            {
                DataRow currRow = dt.NewRow();
                currRow[DataTableConstans.COL_NAME_ID] =product.Id ;
                currRow[DataTableConstans.COL_NAME_PRODUCTNAME] =product.ProductName ;
                currRow[DataTableConstans.COL_NAME_NOTES] ="" ;//this is not product notes, but notes for shopping item
                currRow[DataTableConstans.COL_NAME_PRICE] =product.Price ;
                currRow[DataTableConstans.COL_NAME_CATEGORY] =product.Category.Name ;
                currRow[DataTableConstans.COL_NAME_CATEGORYID] =product.CategoryID ;
                currRow[DataTableConstans.COL_NAME_CATEGORYOBJECT] = product.Category;
                currRow[DataTableConstans.COL_NAME_PRODUCT] = product;

                CategorySort catSort = product.Category.CategorySorts.FirstOrDefault(cs => this._selectedSuperMarket != null
                                                                        && cs.SupermarketId == this._selectedSuperMarket.Id);
                currRow[DataTableConstans.COL_NAME_CATEGORY_SORT_VALUE] = catSort != null? catSort.SortValue : 0;
                    

                dt.Rows.Add(currRow);
            }
        }

        /// <summary>
        /// Builds the products table structure.
        /// </summary>
        /// <returns></returns>
        private static DataTable BuildProductsTableStructure()
        {
            DataTable dt = new DataTable();

            /*Id*/
            DataColumn colId = new DataColumn(DataTableConstans.COL_NAME_ID, typeof (int));
            dt.Columns.Add(colId);

            /*Product name*/
            DataColumn colProductName = new DataColumn(DataTableConstans.COL_NAME_PRODUCTNAME, typeof (string));
            dt.Columns.Add(colProductName);
            

            /*notes*/
            DataColumn colNotes = new DataColumn(DataTableConstans.COL_NAME_NOTES, typeof (string));
            dt.Columns.Add(colNotes);

            /*Price*/
            DataColumn colPrice = new DataColumn(DataTableConstans.COL_NAME_PRICE, typeof (double));
            dt.Columns.Add(colPrice);


            /*Category (name)*/
            DataColumn colCategory = new DataColumn(DataTableConstans.COL_NAME_CATEGORY, typeof (string));
            dt.Columns.Add(colCategory);


            /*Category Id*/
            DataColumn colCategoryId = new DataColumn(DataTableConstans.COL_NAME_CATEGORYID, typeof (int));
            dt.Columns.Add(colCategoryId);

            /*Category Id*/
            DataColumn colCategorySortValue = new DataColumn(DataTableConstans.COL_NAME_CATEGORY_SORT_VALUE, typeof(int));
            dt.Columns.Add(colCategorySortValue);
            

            /*Product*/
            DataColumn colCategoryObject = new DataColumn(DataTableConstans.COL_NAME_CATEGORYOBJECT, typeof(Category));
            dt.Columns.Add(colCategoryObject);

            /*Product*/
            DataColumn colProduct = new DataColumn(DataTableConstans.COL_NAME_PRODUCT, typeof(Product));
            dt.Columns.Add(colProduct);

            /*Setting headers*/
            foreach (DataColumn column in dt.Columns)
            {
                if (DataTableConstans.ColHeaderByName.ContainsKey(column.ColumnName))
                {
                    column.Caption = DataTableConstans.ColHeaderByName[column.ColumnName];
                }
            }


            return dt;
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
        /// <param name="userType">Type of the user.</param>
        private void MatchGuiToUserType()
        {
            //if user is not logged in, we will treat him as lowest level of permissions
            var userType = this.CurrentUserType ?? UserTypes.User;
            bool showEditControls = false;
            switch (userType)
            {
                case UserTypes.Admininstrator:
                    showEditControls = true;
                    break;
                case UserTypes.Editor:
                    showEditControls = true;
                    break;
                case UserTypes.User:
                    showEditControls = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (showEditControls)
            {
               this.rdbShowEditorControls.Show();
               this.rdbShowUserControls.Show();
            }
            else
            {
                this.rdbShowEditorControls.Hide();
                this.rdbShowUserControls.Hide();

            }

            #region Set column visibility and editibility
            //if products are bound, setting column visibility
            var dtProducts = this.gvProducts.DataSource as DataTable;
            if (dtProducts != null)
            {

                foreach (DataGridViewColumn col in this.gvProducts.Columns)
                {
                    DataColumn dataCol = dtProducts.Columns[col.Name];
                    //we need to check because we have some unbound columns
                    if (dataCol != null)
                    {
                        if (DataTableConstans.ColAvailabilityForUserType.ContainsKey(dataCol.ColumnName))
                        {
                            /*Visibility*/
                            bool visibilityState =
                                DataTableConstans.ColAvailabilityForUserType[dataCol.ColumnName].Contains(userType);
                            col.Visible = visibilityState;
                            
                            /*Editabillity*/
                            bool setEditable = DataTableConstans.ColEditebilityForUserType[dataCol.ColumnName].Contains(userType);
                            col.ReadOnly = !setEditable;

                        }
                    }
                }
            } 
            #endregion
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
            if (category != null )
            {
                //getting all rows that contains products with the category weare dealing with   

                string categoryColName = DataTableConstans.COL_NAME_CATEGORYOBJECT;
                
                IEnumerable<DataGridViewRow> enumeratedRows =
                    this.gvProducts.Rows.Cast<DataGridViewRow>().Where(row => (row.Cells[categoryColName].Value as Category) != null
                                                                     && (row.Cells[categoryColName].Value as Category).guid == category.guid);

                List<DataGridViewRow> relevantRows = enumeratedRows.ToList();

                //setting visibility
                bool showRows = e.NewValue == CheckState.Checked;

                bindingContext.SuspendBinding();
                this.gvProducts.SuspendLayout();

                //relevantRows.ForEach(row => row.Visible = showRows);
                foreach (DataGridViewRow currRow in relevantRows)
                {
                    currRow.Visible = showRows;
                }

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
                this.ShowUserChangedMessage(this.CurrentUser,String.Empty);
            }
        }

        /// <summary>
        /// Handles the Click event of the tsRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
                this.ShowUserChangedMessage(this.CurrentUser, message);
            }
        }

        /// <summary>
        /// Shows a message about who is current user.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="message">The message.</param>
        private void ShowUserChangedMessage(Customer customer, string message)
        {
            string msg;
            if (customer == null)
            {

                msg = String.Format("כניסת משתמש רשום נכשלה:{0}{1}", Environment.NewLine, message);
            }
            else
            {
                msg = String.Format("כניסת משתמש רשום הצליחה עבור {0}", customer.UserName);
            }
            MessageBox.Show(msg);
        }

        /// <summary>
        /// Handles the TextChanged event of the txbFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txbFilter_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbSuperMarkets control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbSuperMarkets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if supermarket has changed, we need to re bind the products because thier sort depends on supermarkert
            this.BindProducts();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdbControls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdbControls_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (rdb != null && rdb.Checked)
            {
                if (rdb.Name == this.rdbShowEditorControls.Name)
                {
                    this.btnUpdate.Show();
                    this.btnSend.Hide();
                }
                else if (rdb.Name == this.rdbShowUserControls.Name)
                {
                    this.btnUpdate.Hide();
                    this.btnSend.Show();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<Product> products = this.GetEditedProducts();
        }

        /// <summary>
        /// Gets the products that where edited .
        /// </summary>
        /// <returns>the list of edited products</returns>
        private List<Product> GetEditedProducts()
        {
            List<Product> products = new List<Product>();

            DataTable data = this.gvProducts.DataSource as DataTable;
            if (data != null)
            {
                DataTable changes = data.GetChanges();
                foreach (DataRow row in changes.Rows)
                {
                    Product currProd = row[DataTableConstans.COL_NAME_PRODUCT] as Product;
                    
                }
            }

            foreach (DataGridViewRow row in this.gvProducts.rows)
            {
                Product currProd = row[DataTableConstans.COL_NAME_PRODUCT] as Product;

            }
            

            return products;
        }
        #endregion

        #region Sub classes
        /// <summary>
        /// holds constants for column names and header text
        /// </summary>
        private static class DataTableConstans
        {
            #region "By column names" Dictionaries

            /// <summary>
            /// A dictionary that holds columns header text by their name
            /// </summary>
            public static readonly Dictionary<string, string> ColHeaderByName;
            /// <summary>
            /// A dictionary that holds a key for column name, and a value for the users this column should be available for
            /// </summary>
            public static readonly Dictionary<string, IReadOnlyCollection<UserTypes>> ColAvailabilityForUserType;

            /// <summary>
            /// A dictionary that holds a key for column name, and a value for the users That are allowed to edit the key column
            /// </summary>
            public static readonly Dictionary<string, IReadOnlyCollection<UserTypes>> ColEditebilityForUserType;
 
	        #endregion

            #region Constants
            public const string COL_NAME_ID = "Id";

            public const string COL_NAME_PRODUCTNAME = "ProductName";

            public const string COL_NAME_NOTES = "Notes";

            public const string COL_NAME_PRICE = "Price";

            public const string COL_NAME_CATEGORY = "Category";

            public const string COL_NAME_CATEGORYID = "CategoryId";

            public const string COL_NAME_CATEGORYOBJECT = "CategoryObject";

            public const string COL_NAME_CATEGORY_SORT_VALUE = "CategorySortValue"; 

            public const string COL_NAME_PRODUCT = "ProductObject"; 
            #endregion

            static DataTableConstans()
            {
                DataTableConstans.ColHeaderByName = new Dictionary<string, string>
                    {
                       #region Populate
		                 {DataTableConstans.COL_NAME_ID, "Id"},
                        {DataTableConstans.COL_NAME_PRODUCTNAME, "מוצר"},
                        {DataTableConstans.COL_NAME_NOTES, "הערות"},
                        {DataTableConstans.COL_NAME_PRICE, "מחיר"},
                        {DataTableConstans.COL_NAME_CATEGORY, "קטגוריה"},
                        {DataTableConstans.COL_NAME_CATEGORYID, "CategoryId"},
                        {DataTableConstans.COL_NAME_CATEGORYOBJECT, "Category Object"},
                        {DataTableConstans.COL_NAME_CATEGORY_SORT_VALUE, "Catgory Sort Value"},
                        {DataTableConstans.COL_NAME_PRODUCT, "Product Object"} 
	                    #endregion
                    };

                ReadOnlyCollection<UserTypes> allUsers = Enum.GetValues(typeof(UserTypes)).Cast<UserTypes>().ToList().AsReadOnly();
                    //allUsers.AddRange(Enum.GetValues(typeof(UserTypes)).Cast<UserTypes>().ToList().AsReadOnly());
                ReadOnlyCollection<UserTypes> noUsers = new List<UserTypes>(0).AsReadOnly();
                ReadOnlyCollection<UserTypes> editros = new List<UserTypes>() { UserTypes.Admininstrator, UserTypes.Editor }.AsReadOnly();
                ReadOnlyCollection<UserTypes> admin = new List<UserTypes>() { UserTypes.Admininstrator }.AsReadOnly();

                DataTableConstans.ColAvailabilityForUserType = new Dictionary<string, IReadOnlyCollection<UserTypes>>
                    {
                       #region Populate
		                {DataTableConstans.COL_NAME_ID,  noUsers},
                        {DataTableConstans.COL_NAME_PRODUCTNAME, allUsers},
                        {DataTableConstans.COL_NAME_NOTES, allUsers},
                        {DataTableConstans.COL_NAME_PRICE, allUsers},
                        {DataTableConstans.COL_NAME_CATEGORY, allUsers},
                        {DataTableConstans.COL_NAME_CATEGORYID, noUsers},
                        {DataTableConstans.COL_NAME_CATEGORYOBJECT, noUsers},
                        {DataTableConstans.COL_NAME_CATEGORY_SORT_VALUE, admin} ,
                        {DataTableConstans.COL_NAME_PRODUCT, noUsers} 
	                    #endregion
                    };

                DataTableConstans.ColEditebilityForUserType = new Dictionary<string, IReadOnlyCollection<UserTypes>>
                    {
                       #region Populate
		                {DataTableConstans.COL_NAME_ID,  noUsers},
                        {DataTableConstans.COL_NAME_PRODUCTNAME, admin},
                        {DataTableConstans.COL_NAME_NOTES, allUsers},
                        {DataTableConstans.COL_NAME_PRICE, editros},
                        {DataTableConstans.COL_NAME_CATEGORY, editros},
                        {DataTableConstans.COL_NAME_CATEGORYID, noUsers},
                        {DataTableConstans.COL_NAME_CATEGORYOBJECT, noUsers},
                        {DataTableConstans.COL_NAME_CATEGORY_SORT_VALUE, editros} ,
                        {DataTableConstans.COL_NAME_PRODUCT, noUsers} 
	                    #endregion
                    };
            }

        }
        #endregion

       

    }

  
}
