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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpShoppingList = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gvProducts = new System.Windows.Forms.DataGridView();
            this.clmToBuy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbFilter = new System.Windows.Forms.TextBox();
            this.chbCheckAll = new System.Windows.Forms.CheckBox();
            this.tlpCategories = new System.Windows.Forms.TableLayoutPanel();
            this.rdbShowEditorControls = new System.Windows.Forms.RadioButton();
            this.rdbShowUserControls = new System.Windows.Forms.RadioButton();
            this.cblCategories = new System.Windows.Forms.CheckedListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tlbSettings = new System.Windows.Forms.TableLayoutPanel();
            this.lblSuperMarkets = new System.Windows.Forms.Label();
            this.cmbSuperMarkets = new System.Windows.Forms.ComboBox();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain.SuspendLayout();
            this.tpShoppingList.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.tlpCategories.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tlbSettings.SuspendLayout();
            this._toolStrip.SuspendLayout();
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
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.Controls.Add(this.gvProducts, 1, 1);
            this.tlpMain.Controls.Add(this.txbFilter, 1, 0);
            this.tlpMain.Controls.Add(this.chbCheckAll, 0, 0);
            this.tlpMain.Controls.Add(this.tlpCategories, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(677, 443);
            this.tlpMain.TabIndex = 0;
            // 
            // gvProducts
            // 
            this.gvProducts.AllowUserToAddRows = false;
            this.gvProducts.AllowUserToDeleteRows = false;
            this.gvProducts.AllowUserToOrderColumns = true;
            this.gvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmToBuy,
            this.clmQuantity});
            this.gvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProducts.Location = new System.Drawing.Point(3, 33);
            this.gvProducts.MultiSelect = false;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.RowTemplate.Height = 24;
            this.gvProducts.Size = new System.Drawing.Size(468, 408);
            this.gvProducts.TabIndex = 0;
            this.gvProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProducts_CellEndEdit);
            this.gvProducts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvProducts_EditingControlShowing);
            // 
            // clmToBuy
            // 
            this.clmToBuy.Frozen = true;
            this.clmToBuy.HeaderText = "לקנות?";
            this.clmToBuy.Name = "clmToBuy";
            this.clmToBuy.Width = 54;
            // 
            // clmQuantity
            // 
            this.clmQuantity.Frozen = true;
            this.clmQuantity.HeaderText = "כמות";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.Width = 60;
            // 
            // txbFilter
            // 
            this.txbFilter.Location = new System.Drawing.Point(265, 3);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(206, 22);
            this.txbFilter.TabIndex = 1;
            this.txbFilter.TextChanged += new System.EventHandler(this.txbFilter_TextChanged);
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
            this.tlpCategories.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCategories.Controls.Add(this.rdbShowEditorControls, 0, 2);
            this.tlpCategories.Controls.Add(this.rdbShowUserControls, 0, 1);
            this.tlpCategories.Controls.Add(this.cblCategories, 0, 0);
            this.tlpCategories.Controls.Add(this.btnSend, 0, 4);
            this.tlpCategories.Controls.Add(this.btnUpdate, 0, 3);
            this.tlpCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCategories.Location = new System.Drawing.Point(477, 33);
            this.tlpCategories.Name = "tlpCategories";
            this.tlpCategories.RowCount = 5;
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCategories.Size = new System.Drawing.Size(197, 408);
            this.tlpCategories.TabIndex = 4;
            // 
            // rdbShowEditorControls
            // 
            this.rdbShowEditorControls.AutoSize = true;
            this.rdbShowEditorControls.Location = new System.Drawing.Point(67, 324);
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
            this.rdbShowUserControls.Location = new System.Drawing.Point(51, 297);
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
            this.cblCategories.Size = new System.Drawing.Size(191, 288);
            this.cblCategories.TabIndex = 2;
            this.cblCategories.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblCategories_ItemCheck);
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Location = new System.Drawing.Point(3, 381);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(191, 24);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "שלח";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Location = new System.Drawing.Point(3, 351);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(191, 24);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "עדכן";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.tsOptions});
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
            this.tsLogin.Size = new System.Drawing.Size(118, 24);
            this.tsLogin.Text = "כניסה";
            this.tsLogin.Click += new System.EventHandler(this.tsLogin_Click);
            // 
            // tsRegister
            // 
            this.tsRegister.Name = "tsRegister";
            this.tsRegister.Size = new System.Drawing.Size(118, 24);
            this.tsRegister.Text = "יצירה";
            this.tsRegister.Click += new System.EventHandler(this.tsRegister_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 509);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.tcMain);
            this.Name = "ClientForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Shop-Smart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcMain.ResumeLayout(false);
            this.tpShoppingList.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            this.tlpCategories.ResumeLayout(false);
            this.tlpCategories.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tlbSettings.ResumeLayout(false);
            this.tlbSettings.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
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
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TableLayoutPanel tlbSettings;
        private System.Windows.Forms.Label lblSuperMarkets;
        private System.Windows.Forms.ComboBox cmbSuperMarkets;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmToBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton tsOptions;
        private System.Windows.Forms.ToolStripMenuItem tsLogin;
        private System.Windows.Forms.ToolStripMenuItem tsRegister;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RadioButton rdbShowEditorControls;
        private System.Windows.Forms.RadioButton rdbShowUserControls;
    }
}

