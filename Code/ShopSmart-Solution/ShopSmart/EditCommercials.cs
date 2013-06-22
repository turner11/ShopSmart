using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopSmart.Dal;

namespace ShopSmart.Client
{
    public partial class EditCommercials : Form
    {
        const string CLMNAME_COMMERCIAL_OBJ = "CommercialObj";
        Product _prodcut;
        public EditCommercials(Product prodcut)
        {
            InitializeComponent();
            this._prodcut = prodcut;
            this.BindGridView();
        }


        /// <summary>
        /// Binds the grid view.
        /// </summary>
        private void BindGridView()
        {
            DataTable dt = new DataTable();

           const  string ClmName_Image = "Image";
           

            dt.Columns.Add(ClmName_Image, typeof(Image));
            dt.Columns.Add(CLMNAME_COMMERCIAL_OBJ, typeof(Commercial));            

            foreach (Commercial commercial in this._prodcut.Commercials)
            {
                DataRow row = dt.NewRow();

                row[ClmName_Image] = commercial.GetImage();
                row[CLMNAME_COMMERCIAL_OBJ] = commercial;

                dt.Rows.Add(row);
            }

            this.gvCommercials.DataSource = dt;
            this.gvCommercials.Columns[CLMNAME_COMMERCIAL_OBJ].Visible = false;
            this.gvCommercials.Columns[ClmName_Image].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.gvCommercials.RowTemplate.Height = 50;
            ((DataGridViewImageColumn)this.gvCommercials.Columns[ClmName_Image]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isRowSelected = this.gvCommercials.SelectedRows.Count > 0;
            if (isRowSelected)
            {
                Commercial com = this.gvCommercials.SelectedRows[0].Cells[CLMNAME_COMMERCIAL_OBJ].Value as Commercial;
                if (this._prodcut.Commercials.Contains(com))
                {
                    this._prodcut.Commercials.Remove(com);
                    this.BindGridView();
                    MessageBox.Show("הפרסומת הוסרה");

                }
                else
                {
                    MessageBox.Show("הפרסומת אינה משויכת למוצר");
                }

            }
            else
            {
                MessageBox.Show("Please select a row for seleting");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                List<Image> images = new List<Image>();
                int countFailed = 0;
                foreach (string fileName in ofd.FileNames)
                {
                    try
                    {
                        Image img = Image.FromFile(fileName);
                        images.Add(img);
                    }
                    catch (Exception)
                    {

                        countFailed++;
                    }
                }
                if (countFailed > 0)
                {
                    MessageBox.Show(String.Format("Failed to add {0} files", countFailed));
                }

                foreach (Image img in images)
                {
                    Commercial commercial = new Commercial();
                    commercial.SetImage(img);
                    this._prodcut.Commercials.Add(commercial);
                }

                this.BindGridView();


            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
