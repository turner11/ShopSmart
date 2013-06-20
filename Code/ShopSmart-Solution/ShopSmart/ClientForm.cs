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
        /*Keys for keyboard shortcuts*/
        const Keys NEW_KEY = Keys.Control | Keys.N;
        const Keys EDIT_KEY = Keys.Control | Keys.E;
        const Keys DELETE_KEY = Keys.Control | Keys.D;
        const Keys SORT_KEY = Keys.Control | Keys.S;

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
            this.cblCategories.CheckOnClick = true;
            this._logicsService = new SmartShopLogics();
            this.RefreshData();
            this.SetAllCategoriesdCheckState(true);
            this.MatchGuiToUserType(this.CurrentUserType);
            this.rdbShowUserControls.Checked = true;
        }

        /// <summary>
        /// Refreshes the data.
        /// </summary>
        private void RefreshData()
        {
            this.GetDbItems();
            this.BindSuperMarkets();
            this.BindCategories();
            this.BindProducts();
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
            

            /*Category object*/
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
        /// Checks / un Checks the check boxes for all categories.
        /// </summary>
        /// <param name="isChecked">if set to <c>true</c> will check check boxes of all categories. 
        /// otherwise, will uncheck.</param>
        private void SetAllCategoriesdCheckState(bool isChecked)
        {
            Stopwatch sw = Stopwatch.StartNew();

            //we are unbinding and rebinding for avoiding massive unwanted calls.
            //In case we see this is no good, just use a flag in the event handler
            this.cblCategories.ItemCheck -= this.cblCategories_ItemCheck;

            Logger.Log(String.Format("Setting all categories to be {0}", isChecked ? "Checked" : "UnChecked"));
            for (int i = 0; i < this.cblCategories.Items.Count; i++)
            {
                this.cblCategories.SetItemChecked(i, isChecked);

            }
            this.FilterProducts();
            this.cblCategories.ItemCheck += this.cblCategories_ItemCheck;
            sw.Stop();
            Logger.Log(String.Format(">>>>>>Changing All rows took: {0}ms.", sw.Elapsed.TotalMilliseconds));
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
                    item.Product = (Product)currRow.Cells[DataTableConstans.COL_NAME_PRODUCT].Value;
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
        private void MatchGuiToUserType(UserTypes? userType)
        {
            //if user is not logged in, we will treat him as lowest level of permissions
            var affectiveUserType = this.CurrentUserType ?? UserTypes.User;
            bool showEditControls = false;
            switch (affectiveUserType)
            {
                case UserTypes.Admininstrator:
                case UserTypes.Editor:
                    showEditControls = true;
                    this.rdbShowEditorControls.Checked = true;
                    break;
                case UserTypes.User:
                    showEditControls = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Got an unknown user type");
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

            //Set column visibility and editibility
            this.SetColumnStateByUserType(affectiveUserType);
        }

        /// <summary>
        /// Sets the column visibility andEditability state by user type.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        private void SetColumnStateByUserType(UserTypes userType)
        {
            //if products are bound, setting column visibility
            DataTable dtProducts = this.GetProductsTableFromDataSource();
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
        }

        /// <summary>
        /// Filters the products by the checked cateories and filter text box.
        /// </summary>
        private void FilterProducts()
        {
            DataTable dtProducts = this.GetProductsTableFromDataSource();
            if (dtProducts != null)
            {
                List<string> filters = new List<string>();
                string categoriesFilter = this.GetFilterExpressionFromCategories();

                string nameFilter = String.Empty;
                if (!String.IsNullOrWhiteSpace(this.txbFilter.Text))
                {
                    nameFilter = String.Format("ProductName Like '%{0}%' ", txbFilter.Text);
                }
                filters.Add(categoriesFilter);
                filters.Add(nameFilter);

                filters = filters.Where(s => !String.IsNullOrWhiteSpace(s)).ToList();
                string fullFilter = String.Join(" AND ", filters);
                dtProducts.DefaultView.RowFilter = fullFilter;
            }
        }

        /// <summary>
        /// Gets the filter expression from categories checkboxlist.
        /// </summary>
        /// <returns></returns>
        private string GetFilterExpressionFromCategories()
        {
            string fltrExp = String.Empty;
            int filteredCount = 0;
            for (int i = 0; i < this.cblCategories.Items.Count; i++)
            {
                Category category = this.cblCategories.Items[i] as Category;
                Debug.Assert(category != null, "Checkboxlist had an item which was not a category!");
                if (!this.cblCategories.GetItemChecked(i))
                {
                    if (filteredCount > 0)
                    {
                        fltrExp += "AND ";
                    }
                    fltrExp += String.Format("{0} <> '{1}' ", DataTableConstans.COL_NAME_CATEGORY, category.Name);
                    filteredCount++;
                }
            }

            this.cblCategories.Items.ToString();
            return fltrExp.Trim();
        }

        /// <summary>
        /// Applies the updates from GUI to object that is held in the dta column.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ApplyUpdates(List<Product> products)
        {
            DataTable dtProducts =  this.GetProductsTableFromDataSource();

            
            List<string> ids = new List<string>();
            foreach (Product product in products)
            {
                ids.Add("'"+product.Id.ToString()+"'");
            }

            
            
            string filter = String.Format("Id IN ({0})",String.Join(", ",ids) );
            DataRow[] changedRows = dtProducts.Select(filter);

            foreach (DataRow row in changedRows)
            {
                Product prod = row[DataTableConstans.COL_NAME_PRODUCT] as Product;
                prod.ProductName = row[DataTableConstans.COL_NAME_PRODUCTNAME] as String;

                decimal price;
                bool priceparsed = decimal.TryParse(row[DataTableConstans.COL_NAME_PRICE].ToString(), out price);
                prod.Price = priceparsed ? price : prod.Price;
                    
               
            }

        }

        /// <summary>
        /// Gets the products table from data source.
        /// </summary>
        private DataTable GetProductsTableFromDataSource()
        {
            DataTable dtProducts = this.gvProducts.DataSource as DataTable;
            Debug.Assert(dtProducts != null, "Products datatabble was null!");
            return dtProducts;
        }

        /// <summary>
        /// Gets the products that where edited .
        /// </summary>
        /// <returns>the list of edited products</returns>
        private List<Product> GetEditedProducts()
        {
            List<Product> products = new List<Product>();

            //Adding products from rows that are marked as edited
            foreach (DataGridViewRow row in this.gvProducts.Rows)
            {
                object objEdited = row.Cells[this.clmDirty.Index].Value;
                bool isEdited = objEdited is bool && (bool)objEdited;
                if (isEdited)
                {
                    Product currProd = row.Cells[DataTableConstans.COL_NAME_PRODUCT].Value as Product;
                    Debug.Assert(currProd != null, "Could not get product from gridview row!");
                    products.Add(currProd);

                }
            }
            return products;
        }

        /// <summary>
        /// Saves the changes to database.
        /// </summary>
        /// <param name="errorMessage">The error message, in case an error has occured.</param>
        /// <returns>true upon success, false otherwise</returns>
        private bool SaveChanges()
        {
            string errorMessage;
            bool success= this._logicsService.SaveChanges(out errorMessage);
            MessageBox.Show(this, success ? "Changes saved" : "Failed to save changes.",
                           "Saving result",
                           MessageBoxButtons.OK,
                           success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            return success;
        }

        /// <summary>
        /// Gets the current row product.
        /// </summary>
        /// <returns></returns>
        private Product GetCurrentRowProduct()
        {
            Product retProd = null;

            if (this.gvProducts.CurrentCell != null && this.gvProducts.Rows .Count > this.gvProducts.CurrentCell.RowIndex)
            {
                DataGridViewRow row = this.gvProducts.Rows[this.gvProducts.CurrentCell.RowIndex];
                retProd = row.Cells[DataTableConstans.COL_NAME_PRODUCT].Value as Product;
            }

            return retProd;
        }


        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == ClientForm.EDIT_KEY)
            {
                this.EditProduct();
            }
            else if (keyData == ClientForm.DELETE_KEY)
            {
                this.DeleteProduct();
            }
            else if (keyData == ClientForm.NEW_KEY)
            {
                this.CreateNewProduct();
            }
            else if (keyData == ClientForm.SORT_KEY)
            {
                this.ExportSortedList();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Edits a product (using product form).
        /// </summary>
        private void EditProduct()
        {
            Product currentProduct = this.GetCurrentRowProduct();
            if (currentProduct != null)
            {
                ProductForm frmPrdct = ProductForm.GetEditProductInstance(currentProduct, this._categories, this._selectedSuperMarket);

                if (frmPrdct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string errorMsg;
                    bool success = this._logicsService.SaveChanges(out errorMsg);
                    if (!success)
                    {
                        MessageBox.Show(String.Format("Error Editing product:{0}{1}", Environment.NewLine, errorMsg));
                    }
                    else
                    {
                        //refreshing
                        this.RefreshData();

                    }


                }
            }
            else
            {
                MessageBox.Show("אנא בחר מוצר לעריכה");
            }
        }

        /// <summary>
        /// Deletes the product (using delete form).
        /// </summary>
        private void DeleteProduct()
        {
            Product currentProduct = this.GetCurrentRowProduct();
            if (currentProduct != null)
            {
                DialogResult rslt = MessageBox.Show(this,
                                                    String.Format("האם אתה בטוח שברצונך למחוק את {0}?", currentProduct.ProductName),
                                                    "",
                                                    MessageBoxButtons.OKCancel);
                if (rslt == System.Windows.Forms.DialogResult.OK)
                {

                    string errorMsg;
                    bool success = this._logicsService.DeleteProduct(currentProduct, out errorMsg);
                    if (!success)
                    {
                        MessageBox.Show(String.Format("Error deleting product:{0}{1}", Environment.NewLine, errorMsg));
                    }
                    else
                    {
                        //refreshing
                        this.RefreshData();
                    }


                }
            }
            else
            {
                MessageBox.Show("אנא בחר מוצר למחיקה");
            }
        }

        /// <summary>
        /// Creates the new product (using new product form).
        /// </summary>
        private void CreateNewProduct()
        {
            ProductForm frmPrdct = ProductForm.GetCreateProductInstance(this._categories, this._selectedSuperMarket);
            if (frmPrdct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Product newProduct = frmPrdct.Product;
                if (newProduct != null)
                {
                    string errorMsg;
                    bool success = this._logicsService.SaveProduct(newProduct, out errorMsg);
                    if (!success)
                    {
                        MessageBox.Show(String.Format("Error Adding product:{0}{1}", Environment.NewLine, errorMsg));
                    }
                    else
                    {
                        //refreshing
                        this.RefreshData();
                    }

                }
            }
        }

        /// <summary>
        /// Exports the sorted list.
        /// </summary>
        private void ExportSortedList()
        {
            ShopList shoppingList = this.GetShoppingListFromGui();


            ShopList soretd = this._logicsService.GetSortedList(shoppingList);

            ClientForm.ExportListToExcel(soretd);
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the ItemCheck event of the cblCategories control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs" /> instance containing the event data.</param>
        void cblCategories_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //running the method after the event has completed, and new value took place
            this.BeginInvoke(new MethodInvoker(FilterProducts), null);                      
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
        private void btnSort_Click(object sender, EventArgs e)
        {
            this.ExportSortedList();
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

                    using (Process prc = new Process())
                    {
                        Process.Start(filename);
                    }
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
            var cllToBuy = row.Cells[this.clmToBuy.Index] as DataGridViewCheckBoxCell;


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
                bool toBuy = cllToBuy != null && Convert.ToBoolean(cllToBuy.Value);
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
            else if (this.gvProducts.Columns[e.ColumnIndex].IsDataBound) //If we left a bound row, it meanse the row is dirty, should be marked as such
            {
                row.Cells[this.clmDirty.Index].Value = true;
            }

        }

        /// <summary>
        /// Handles the EditingControlShowing event of the gvProducts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewEditingControlShowingEventArgs"/> instance containing the event data.</param>
        private void gvProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int colIdx = this.gvProducts.CurrentCell.ColumnIndex;
            if (colIdx == this.clmQuantity.Index)
            {
                //bind to the text box...
                TextBox cellTb = e.Control as TextBox;
                if (cellTb != null)
                {
                    cellTb.KeyPress += QuntityTextBox_TextChanged;
                }

            }
            else if(colIdx == this.gvProducts.Columns[DataTableConstans.COL_NAME_CATEGORY].Index)
            {
                /*Editing category*/
                //bind to the text box...
                TextBox cellTb = e.Control as TextBox;
                cellTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                string[] categoryNames = this._categories.Select(c => c.Name).ToArray();
                cellTb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cellTb.AutoCompleteCustomSource.AddRange(categoryNames);
                
                if (cellTb != null)
                {
                    cellTb.Leave += this.CategoryNameTextBox_Leave;
                }

            }
        }

        /// <summary>
        /// Handles the Leave event of the CategoryNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CategoryNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb != null)
            {
                string[] existingCategories = new string[txb.AutoCompleteCustomSource.Count];
                txb.AutoCompleteCustomSource.CopyTo(existingCategories, 0);

                bool isCreatingNewCategory = existingCategories.Contains(txb.Name);
                if (isCreatingNewCategory)
                {
                    Category newCategory = new Category();
                    
                    //TODO: force to insert a sort value
                    //newCategory.CategorySorts
                    newCategory.Name = txb.Text;

                    Product product = this.gvProducts.CurrentRow.Cells[DataTableConstans.COL_NAME_PRODUCT].Value as Product;
                    product.Category = newCategory;

                   
                    
                    
                }
                else
                {
                    Category category = this.gvProducts.CurrentRow.Cells[DataTableConstans.COL_NAME_CATEGORYOBJECT].Value as Category;
                }
            }
             this.SaveChanges();
            //TODO: Save to DB and refresh
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
            this.FilterProducts();
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
                this.tlpMain.SuspendLayout();

                if (rdb.Name == this.rdbShowEditorControls.Name)
                {
                    this.btnEditProduct.Show();
                    this.btnDeleteProduct.Show();
                    this.btnNewProduct.Show();
                    this.btnSort.Hide();
                    this.SetColumnStateByUserType(this.CurrentUserType ?? UserTypes.User);
                }
                else if (rdb.Name == this.rdbShowUserControls.Name)
                {
                    this.btnEditProduct.Hide();
                    this.btnDeleteProduct.Hide();
                    this.btnNewProduct.Hide();
                    this.btnSort.Show();
                    this.SetColumnStateByUserType(UserTypes.User);
                }

                this.tlpMain.ResumeLayout(true);
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the gvProducts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gvProducts_SelectionChanged(object sender, EventArgs e)
        {
            bool enableEditButtons = this.gvProducts.CurrentCell != null;
            this.btnEditProduct.Enabled = enableEditButtons;
            this.btnDeleteProduct.Enabled = enableEditButtons;
        }

        /// <summary>
        /// Handles the Click event of the btnNewProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            this.CreateNewProduct();
        }

       

        /// <summary>
        /// Handles the Click event of the btnEditProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            this.EditProduct();
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

            this.DeleteProduct();
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
