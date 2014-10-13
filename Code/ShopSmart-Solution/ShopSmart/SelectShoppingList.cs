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
    public partial class SelectShoppingList : Form
    {

        /// <summary>
        /// The header of column contains the list object
        /// </summary>
        const string DATA_HEADER = "Listobject";
        ShopList _selectedList;
        /// <summary>
        /// Gets the selected list.
        /// </summary>
        /// <value>
        /// The selected list.
        /// </value>
        public ShopList SelectedList
        {
            get { return _selectedList; }
            private set { _selectedList = value; }
        }

        /// <summary>
        /// The shopping lists that this form is based on
        /// </summary>
        private readonly List<ShopList> _shoppingLists;


        public SelectShoppingList(List<ShopList> shoppingLists)
        {
            InitializeComponent();
            this._shoppingLists = shoppingLists;
            this.BindGridView();
        }

        /// <summary>
        /// Binds the grid view to available shoplists.
        /// </summary>
        private void BindGridView()
        {
            DataTable dt = new DataTable();
            string textHeader = "רשימה";
            
            
            dt.Columns.Add(textHeader, typeof(string));
            dt.Columns.Add(SelectShoppingList.DATA_HEADER, typeof(ShopList));

            var orderredShoplists = this._shoppingLists.OrderByDescending(l => l.Date);
            //build data table
            foreach (ShopList currList in orderredShoplists)
            {
                DataRow currRow = dt.NewRow();
                
                currRow[textHeader] = currList.ToString();
                currRow[SelectShoppingList.DATA_HEADER] = currList;

                dt.Rows.Add(currRow);
            }
           

            this.gvShopLists.DataSource = dt;

            this.gvShopLists.Columns[SelectShoppingList.DATA_HEADER].Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Confirm();
        }

        private void Confirm()
        {
            this._selectedList = this.GetSelectedList() ;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Gets the selected list fromgridview.
        /// </summary>
        /// <returns></returns>
        private ShopList GetSelectedList()
        {
            ShopList retVal = null;

            bool isCell = this.gvShopLists.SelectedCells.Count > 0;
            if (isCell)
            {
                DataGridViewRow selectedRow = this.gvShopLists.Rows[this.gvShopLists.SelectedCells[0].RowIndex];
                retVal = selectedRow.Cells[SelectShoppingList.DATA_HEADER].Value as ShopList;
            }
            return retVal;

        }


        private void ghShopLists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Confirm();
        }

       
    }
}
