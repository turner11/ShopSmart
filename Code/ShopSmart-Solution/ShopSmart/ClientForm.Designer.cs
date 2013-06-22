namespace ShopSmart.Client
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpShoppingList = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gvProducts = new System.Windows.Forms.DataGridView();
            this.chbCheckAll = new System.Windows.Forms.CheckBox();
            this.tlpCategories = new System.Windows.Forms.TableLayoutPanel();
            this.rdbShowEditorControls = new System.Windows.Forms.RadioButton();
            this.rdbShowUserControls = new System.Windows.Forms.RadioButton();
            this.cblCategories = new System.Windows.Forms.CheckedListBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txbFilter = new System.Windows.Forms.TextBox();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tlbSettings = new System.Windows.Forms.TableLayoutPanel();
            this.lblSuperMarkets = new System.Windows.Forms.Label();
            this.cmbSuperMarkets = new System.Windows.Forms.ComboBox();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGetArchivedLists = new System.Windows.Forms.ToolStripButton();
            this.psCommercials = new ShopSmart.Client.PictureSlider();
            this.clmToBuy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcMain.SuspendLayout();
            this.tpShoppingList.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.tlpCategories.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tlbSettings.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psCommercials)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpShoppingList);
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.Location = new System.Drawing.Point(0, 30);
            this.tcMain.Name = "tcMain";
            this.tcMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tcMain.RightToLeftLayout = true;
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(691, 478);
            this.tcMain.TabIndex = 0;
            // 
            // tpShoppingList
            // 
            this.tpShoppingList.Controls.Add(this.tlpMain);
            this.tpShoppingList.Location = new System.Drawing.Point(4, 25);
            this.tpShoppingList.Name = "tpShoppingList";
            this.tpShoppingList.Padding = new System.Windows.Forms.Padding(3);
            this.tpShoppingList.Size = new System.Drawing.Size(683, 449);
            this.tpShoppingList.TabIndex = 0;
            this.tpShoppingList.Text = "רשימת קניות";
            this.tpShoppingList.UseVisualStyleBackColor = true;
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.29247F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.70753F));
            this.tlpMain.Controls.Add(this.gvProducts, 1, 1);
            this.tlpMain.Controls.Add(this.chbCheckAll, 0, 0);
            this.tlpMain.Controls.Add(this.tlpCategories, 0, 1);
            this.tlpMain.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(677, 443);
            this.tlpMain.TabIndex = 0;
            // 
            // gvProducts
            // 
            this.gvProducts.AllowUserToAddRows = false;
            this.gvProducts.AllowUserToDeleteRows = false;
            this.gvProducts.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gvProducts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmToBuy,
            this.clmQuantity});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProducts.Location = new System.Drawing.Point(3, 53);
            this.gvProducts.MultiSelect = false;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.RowTemplate.Height = 24;
            this.gvProducts.Size = new System.Drawing.Size(493, 410);
            this.gvProducts.TabIndex = 0;
            this.gvProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProducts_CellEndEdit);
            this.gvProducts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvProducts_EditingControlShowing);
            this.gvProducts.SelectionChanged += new System.EventHandler(this.gvProducts_SelectionChanged);
            // 
            // chbCheckAll
            // 
            this.chbCheckAll.AutoSize = true;
            this.chbCheckAll.Checked = true;
            this.chbCheckAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCheckAll.Location = new System.Drawing.Point(597, 3);
            this.chbCheckAll.Name = "chbCheckAll";
            this.chbCheckAll.Size = new System.Drawing.Size(77, 21);
            this.chbCheckAll.TabIndex = 3;
            this.chbCheckAll.Text = "סמן הכל";
            this.chbCheckAll.UseVisualStyleBackColor = true;
            this.chbCheckAll.CheckedChanged += new System.EventHandler(this.chbCheckAll_CheckedChanged);
            // 
            // tlpCategories
            // 
            this.tlpCategories.ColumnCount = 1;
            this.tlpCategories.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCategories.Controls.Add(this.rdbShowEditorControls, 0, 2);
            this.tlpCategories.Controls.Add(this.rdbShowUserControls, 0, 1);
            this.tlpCategories.Controls.Add(this.cblCategories, 0, 0);
            this.tlpCategories.Controls.Add(this.btnSort, 0, 6);
            this.tlpCategories.Controls.Add(this.btnEditProduct, 0, 4);
            this.tlpCategories.Controls.Add(this.btnDeleteProduct, 0, 5);
            this.tlpCategories.Controls.Add(this.btnNewProduct, 0, 3);
            this.tlpCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCategories.Location = new System.Drawing.Point(502, 53);
            this.tlpCategories.Name = "tlpCategories";
            this.tlpCategories.RowCount = 7;
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCategories.Size = new System.Drawing.Size(172, 410);
            this.tlpCategories.TabIndex = 4;
            // 
            // rdbShowEditorControls
            // 
            this.rdbShowEditorControls.AutoSize = true;
            this.rdbShowEditorControls.Location = new System.Drawing.Point(42, 261);
            this.rdbShowEditorControls.Name = "rdbShowEditorControls";
            this.rdbShowEditorControls.Size = new System.Drawing.Size(127, 21);
            this.rdbShowEditorControls.TabIndex = 8;
            this.rdbShowEditorControls.TabStop = true;
            this.rdbShowEditorControls.Text = "הראה ממשק עורך";
            this.rdbShowEditorControls.UseVisualStyleBackColor = true;
            this.rdbShowEditorControls.CheckedChanged += new System.EventHandler(this.rdbControls_CheckedChanged);
            // 
            // rdbShowUserControls
            // 
            this.rdbShowUserControls.AutoSize = true;
            this.rdbShowUserControls.Location = new System.Drawing.Point(26, 234);
            this.rdbShowUserControls.Name = "rdbShowUserControls";
            this.rdbShowUserControls.Size = new System.Drawing.Size(143, 21);
            this.rdbShowUserControls.TabIndex = 7;
            this.rdbShowUserControls.TabStop = true;
            this.rdbShowUserControls.Text = "הראה ממשק משתמש";
            this.rdbShowUserControls.UseVisualStyleBackColor = true;
            this.rdbShowUserControls.CheckedChanged += new System.EventHandler(this.rdbControls_CheckedChanged);
            // 
            // cblCategories
            // 
            this.cblCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblCategories.FormattingEnabled = true;
            this.cblCategories.Location = new System.Drawing.Point(3, 3);
            this.cblCategories.Name = "cblCategories";
            this.cblCategories.Size = new System.Drawing.Size(166, 225);
            this.cblCategories.TabIndex = 2;
            this.cblCategories.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblCategories_ItemCheck);
            // 
            // btnSort
            // 
            this.btnSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSort.Location = new System.Drawing.Point(3, 383);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(166, 24);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "מיין רשימה";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditProduct.Location = new System.Drawing.Point(3, 323);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(166, 24);
            this.btnEditProduct.TabIndex = 4;
            this.btnEditProduct.Text = "ערוך...";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Visible = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteProduct.Location = new System.Drawing.Point(3, 353);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(166, 24);
            this.btnDeleteProduct.TabIndex = 4;
            this.btnDeleteProduct.Text = "מחק";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Visible = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewProduct.Location = new System.Drawing.Point(3, 288);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(166, 29);
            this.btnNewProduct.TabIndex = 4;
            this.btnNewProduct.Text = "חדש...";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Visible = false;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txbFilter);
            this.flowLayoutPanel1.Controls.Add(this.psCommercials);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(493, 44);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // txbFilter
            // 
            this.txbFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbFilter.BackColor = System.Drawing.SystemColors.Info;
            this.txbFilter.Location = new System.Drawing.Point(284, 12);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(206, 22);
            this.txbFilter.TabIndex = 1;
            this.txbFilter.TextChanged += new System.EventHandler(this.txbFilter_TextChanged);
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.tlbSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 25);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(683, 449);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "הגדרות";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tlbSettings
            // 
            this.tlbSettings.ColumnCount = 2;
            this.tlbSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlbSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlbSettings.Controls.Add(this.lblSuperMarkets, 0, 0);
            this.tlbSettings.Controls.Add(this.cmbSuperMarkets, 1, 0);
            this.tlbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlbSettings.Location = new System.Drawing.Point(3, 3);
            this.tlbSettings.Name = "tlbSettings";
            this.tlbSettings.RowCount = 2;
            this.tlbSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlbSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbSettings.Size = new System.Drawing.Size(677, 443);
            this.tlbSettings.TabIndex = 0;
            // 
            // lblSuperMarkets
            // 
            this.lblSuperMarkets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSuperMarkets.AutoSize = true;
            this.lblSuperMarkets.Location = new System.Drawing.Point(594, 11);
            this.lblSuperMarkets.Name = "lblSuperMarkets";
            this.lblSuperMarkets.Size = new System.Drawing.Size(66, 17);
            this.lblSuperMarkets.TabIndex = 0;
            this.lblSuperMarkets.Text = "סופרמרקט";
            // 
            // cmbSuperMarkets
            // 
            this.cmbSuperMarkets.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSuperMarkets.FormattingEnabled = true;
            this.cmbSuperMarkets.Location = new System.Drawing.Point(404, 7);
            this.cmbSuperMarkets.Name = "cmbSuperMarkets";
            this.cmbSuperMarkets.Size = new System.Drawing.Size(170, 24);
            this.cmbSuperMarkets.TabIndex = 1;
            this.cmbSuperMarkets.SelectedIndexChanged += new System.EventHandler(this.cmbSuperMarkets_SelectedIndexChanged);
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOptions,
            this.tsGetArchivedLists});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(691, 27);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // tsOptions
            // 
            this.tsOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLogin,
            this.tsRegister});
            this.tsOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsOptions.Image")));
            this.tsOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(145, 24);
            this.tsOptions.Text = "משתמשים רשומים";
            // 
            // tsLogin
            // 
            this.tsLogin.Name = "tsLogin";
            this.tsLogin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.tsLogin.Size = new System.Drawing.Size(176, 24);
            this.tsLogin.Text = "כניסה...";
            this.tsLogin.Click += new System.EventHandler(this.tsLogin_Click);
            // 
            // tsRegister
            // 
            this.tsRegister.Name = "tsRegister";
            this.tsRegister.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsRegister.Size = new System.Drawing.Size(176, 24);
            this.tsRegister.Text = "יצירה...";
            this.tsRegister.Click += new System.EventHandler(this.tsRegister_Click);
            // 
            // tsGetArchivedLists
            // 
            this.tsGetArchivedLists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsGetArchivedLists.Image = ((System.Drawing.Image)(resources.GetObject("tsGetArchivedLists.Image")));
            this.tsGetArchivedLists.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGetArchivedLists.Name = "tsGetArchivedLists";
            this.tsGetArchivedLists.Size = new System.Drawing.Size(164, 24);
            this.tsGetArchivedLists.Text = "טען רשימות שמורות...";
            this.tsGetArchivedLists.Click += new System.EventHandler(this.tsGetArchivedLists_Click);
            // 
            // psCommercials
            // 
            this.psCommercials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.psCommercials.ErrorImage = null;
            this.psCommercials.Image = global::ShopSmart.Client.Properties.Resources.ShopSmart_Logo;
            this.psCommercials.InitialImage = global::ShopSmart.Client.Properties.Resources.ShopSmart_Logo;
            this.psCommercials.Location = new System.Drawing.Point(15, 3);
            this.psCommercials.Name = "psCommercials";
            this.psCommercials.Size = new System.Drawing.Size(263, 41);
            this.psCommercials.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.psCommercials.SlideInterval = 2147483647;
            this.psCommercials.TabIndex = 2;
            this.psCommercials.TabStop = false;
            // 
            // clmToBuy
            // 
            this.clmToBuy.Frozen = true;
            this.clmToBuy.HeaderText = "לקנות?";
            this.clmToBuy.Name = "clmToBuy";
            this.clmToBuy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmToBuy.Width = 73;
            // 
            // clmQuantity
            // 
            this.clmQuantity.Frozen = true;
            this.clmQuantity.HeaderText = "כמות";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.Width = 60;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 509);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Shop-Smart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcMain.ResumeLayout(false);
            this.tpShoppingList.ResumeLayout(false);
            this.tpShoppingList.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            this.tlpCategories.ResumeLayout(false);
            this.tlpCategories.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tlbSettings.ResumeLayout(false);
            this.tlbSettings.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.psCommercials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpShoppingList;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.DataGridView gvProducts;
        private System.Windows.Forms.TextBox txbFilter;
        private System.Windows.Forms.CheckedListBox cblCategories;
        private System.Windows.Forms.CheckBox chbCheckAll;
        private System.Windows.Forms.TableLayoutPanel tlpCategories;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.TableLayoutPanel tlbSettings;
        private System.Windows.Forms.Label lblSuperMarkets;
        private System.Windows.Forms.ComboBox cmbSuperMarkets;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton tsOptions;
        private System.Windows.Forms.ToolStripMenuItem tsLogin;
        private System.Windows.Forms.ToolStripMenuItem tsRegister;
        private System.Windows.Forms.RadioButton rdbShowEditorControls;
        private System.Windows.Forms.RadioButton rdbShowUserControls;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.ToolStripButton tsGetArchivedLists;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private PictureSlider psCommercials;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmToBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
    }
}

