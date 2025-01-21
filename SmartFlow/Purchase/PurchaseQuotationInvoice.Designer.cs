namespace SmartFlow.Purchase
{
    partial class PurchaseQuotationInvoice
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
            this.components = new System.ComponentModel.Container();
            this.label8 = new System.Windows.Forms.Label();
            this.datelbl = new System.Windows.Forms.Label();
            this.newbtn = new System.Windows.Forms.Button();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.supplierlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.companytxtbox = new System.Windows.Forms.TextBox();
            this.companylbl = new System.Windows.Forms.Label();
            this.invoicecodelbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.supplieridlbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.selectsuppliertxtbox = new System.Windows.Forms.TextBox();
            this.codetxtbox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addbtn = new System.Windows.Forms.Button();
            this.dgvpurchaseproducts = new System.Windows.Forms.DataGridView();
            this.srnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mfrcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtycolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.qtylbl = new System.Windows.Forms.Label();
            this.mfrlbl = new System.Windows.Forms.Label();
            this.productnamelbl = new System.Windows.Forms.Label();
            this.mfrtxtbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(291, 15);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(50, 23);
            this.datelbl.TabIndex = 4;
            this.datelbl.Text = "Date ";
            // 
            // newbtn
            // 
            this.newbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.newbtn.Location = new System.Drawing.Point(1434, 697);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(158, 46);
            this.newbtn.TabIndex = 1;
            this.newbtn.Text = "NEW";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Enabled = false;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(118, 10);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.ReadOnly = true;
            this.invoicenotxtbox.Size = new System.Drawing.Size(167, 32);
            this.invoicenotxtbox.TabIndex = 0;
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(11, 52);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(77, 23);
            this.supplierlbl.TabIndex = 1;
            this.supplierlbl.Text = "Supplier ";
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.savebtn.Location = new System.Drawing.Point(1598, 697);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(158, 46);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE && PRINT";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(11, 15);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(96, 23);
            this.invoicenolbl.TabIndex = 0;
            this.invoicenolbl.Text = "Inovice No ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.companytxtbox);
            this.panel2.Controls.Add(this.companylbl);
            this.panel2.Controls.Add(this.invoicecodelbl);
            this.panel2.Controls.Add(this.invoicedatetxtbox);
            this.panel2.Controls.Add(this.supplieridlbl);
            this.panel2.Controls.Add(this.productidlbl);
            this.panel2.Controls.Add(this.selectsuppliertxtbox);
            this.panel2.Controls.Add(this.codetxtbox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.datelbl);
            this.panel2.Controls.Add(this.invoicenotxtbox);
            this.panel2.Controls.Add(this.supplierlbl);
            this.panel2.Controls.Add(this.invoicenolbl);
            this.panel2.Location = new System.Drawing.Point(12, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1251, 165);
            this.panel2.TabIndex = 29;
            // 
            // companytxtbox
            // 
            this.companytxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.companytxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.companytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.companytxtbox.Enabled = false;
            this.companytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companytxtbox.Location = new System.Drawing.Point(118, 108);
            this.companytxtbox.Name = "companytxtbox";
            this.companytxtbox.Size = new System.Drawing.Size(866, 32);
            this.companytxtbox.TabIndex = 71;
            // 
            // companylbl
            // 
            this.companylbl.AutoSize = true;
            this.companylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companylbl.Location = new System.Drawing.Point(11, 111);
            this.companylbl.Name = "companylbl";
            this.companylbl.Size = new System.Drawing.Size(83, 23);
            this.companylbl.TabIndex = 70;
            this.companylbl.Text = "Company";
            // 
            // invoicecodelbl
            // 
            this.invoicecodelbl.AutoSize = true;
            this.invoicecodelbl.Location = new System.Drawing.Point(1153, 10);
            this.invoicecodelbl.Name = "invoicecodelbl";
            this.invoicecodelbl.Size = new System.Drawing.Size(95, 16);
            this.invoicecodelbl.TabIndex = 69;
            this.invoicecodelbl.Text = "invoicecodelbl";
            this.invoicecodelbl.Visible = false;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(359, 10);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(625, 32);
            this.invoicedatetxtbox.TabIndex = 0;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // supplieridlbl
            // 
            this.supplieridlbl.AutoSize = true;
            this.supplieridlbl.Location = new System.Drawing.Point(1287, 108);
            this.supplieridlbl.Name = "supplieridlbl";
            this.supplieridlbl.Size = new System.Drawing.Size(66, 16);
            this.supplieridlbl.TabIndex = 68;
            this.supplieridlbl.Text = "supplierid";
            this.supplieridlbl.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(1153, 26);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(63, 16);
            this.productidlbl.TabIndex = 67;
            this.productidlbl.Text = "productid";
            this.productidlbl.Visible = false;
            // 
            // selectsuppliertxtbox
            // 
            this.selectsuppliertxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectsuppliertxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectsuppliertxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectsuppliertxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectsuppliertxtbox.Location = new System.Drawing.Point(284, 48);
            this.selectsuppliertxtbox.Name = "selectsuppliertxtbox";
            this.selectsuppliertxtbox.ReadOnly = true;
            this.selectsuppliertxtbox.Size = new System.Drawing.Size(700, 32);
            this.selectsuppliertxtbox.TabIndex = 2;
            this.selectsuppliertxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectsuppliertxtbox_MouseClick);
            this.selectsuppliertxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectsuppliertxtbox_KeyDown);
            // 
            // codetxtbox
            // 
            this.codetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codetxtbox.Enabled = false;
            this.codetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codetxtbox.Location = new System.Drawing.Point(118, 48);
            this.codetxtbox.Name = "codetxtbox";
            this.codetxtbox.ReadOnly = true;
            this.codetxtbox.Size = new System.Drawing.Size(167, 32);
            this.codetxtbox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 222);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1744, 469);
            this.tabControl1.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.addbtn);
            this.tabPage1.Controls.Add(this.dgvpurchaseproducts);
            this.tabPage1.Controls.Add(this.qtytxtbox);
            this.tabPage1.Controls.Add(this.selectproducttxtbox);
            this.tabPage1.Controls.Add(this.qtylbl);
            this.tabPage1.Controls.Add(this.mfrlbl);
            this.tabPage1.Controls.Add(this.productnamelbl);
            this.tabPage1.Controls.Add(this.mfrtxtbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1736, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Product Detail";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // addbtn
            // 
            this.addbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addbtn.Location = new System.Drawing.Point(1605, 37);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(112, 32);
            this.addbtn.TabIndex = 7;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // dgvpurchaseproducts
            // 
            this.dgvpurchaseproducts.AllowDrop = true;
            this.dgvpurchaseproducts.AllowUserToAddRows = false;
            this.dgvpurchaseproducts.AllowUserToDeleteRows = false;
            this.dgvpurchaseproducts.AllowUserToResizeColumns = false;
            this.dgvpurchaseproducts.AllowUserToResizeRows = false;
            this.dgvpurchaseproducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvpurchaseproducts.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvpurchaseproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchaseproducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srnocolumn,
            this.mfrcolumn,
            this.productid,
            this.productnamecolumn,
            this.qtycolumn});
            this.dgvpurchaseproducts.ContextMenuStrip = this.contextMenuStrip;
            this.dgvpurchaseproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvpurchaseproducts.Location = new System.Drawing.Point(6, 75);
            this.dgvpurchaseproducts.Name = "dgvpurchaseproducts";
            this.dgvpurchaseproducts.ReadOnly = true;
            this.dgvpurchaseproducts.RowHeadersVisible = false;
            this.dgvpurchaseproducts.RowHeadersWidth = 51;
            this.dgvpurchaseproducts.RowTemplate.Height = 24;
            this.dgvpurchaseproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpurchaseproducts.Size = new System.Drawing.Size(1724, 353);
            this.dgvpurchaseproducts.TabIndex = 1;
            this.dgvpurchaseproducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvpurchaseproducts_CellFormatting);
            this.dgvpurchaseproducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvpurchasequotationproduct_KeyDown);
            // 
            // srnocolumn
            // 
            this.srnocolumn.HeaderText = "#";
            this.srnocolumn.MinimumWidth = 6;
            this.srnocolumn.Name = "srnocolumn";
            this.srnocolumn.ReadOnly = true;
            this.srnocolumn.Width = 40;
            // 
            // mfrcolumn
            // 
            this.mfrcolumn.HeaderText = "MFR";
            this.mfrcolumn.MinimumWidth = 6;
            this.mfrcolumn.Name = "mfrcolumn";
            this.mfrcolumn.ReadOnly = true;
            this.mfrcolumn.Width = 125;
            // 
            // productid
            // 
            this.productid.HeaderText = "ID";
            this.productid.MinimumWidth = 6;
            this.productid.Name = "productid";
            this.productid.ReadOnly = true;
            this.productid.Visible = false;
            this.productid.Width = 125;
            // 
            // productnamecolumn
            // 
            this.productnamecolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productnamecolumn.HeaderText = "Product Name";
            this.productnamecolumn.MinimumWidth = 6;
            this.productnamecolumn.Name = "productnamecolumn";
            this.productnamecolumn.ReadOnly = true;
            // 
            // qtycolumn
            // 
            this.qtycolumn.HeaderText = "Qty";
            this.qtycolumn.MinimumWidth = 6;
            this.qtycolumn.Name = "qtycolumn";
            this.qtycolumn.ReadOnly = true;
            this.qtycolumn.Width = 125;
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F);
            this.qtytxtbox.Location = new System.Drawing.Point(612, 37);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(154, 32);
            this.qtytxtbox.TabIndex = 6;
            this.qtytxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtytxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtytxtbox_KeyPress);
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(201, 37);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.ReadOnly = true;
            this.selectproducttxtbox.Size = new System.Drawing.Size(405, 32);
            this.selectproducttxtbox.TabIndex = 1;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // qtylbl
            // 
            this.qtylbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qtylbl.AutoSize = true;
            this.qtylbl.Location = new System.Drawing.Point(608, 9);
            this.qtylbl.Name = "qtylbl";
            this.qtylbl.Size = new System.Drawing.Size(41, 23);
            this.qtylbl.TabIndex = 4;
            this.qtylbl.Text = "QTY";
            // 
            // mfrlbl
            // 
            this.mfrlbl.AutoSize = true;
            this.mfrlbl.Location = new System.Drawing.Point(14, 9);
            this.mfrlbl.Name = "mfrlbl";
            this.mfrlbl.Size = new System.Drawing.Size(45, 23);
            this.mfrlbl.TabIndex = 0;
            this.mfrlbl.Text = "MFR";
            // 
            // productnamelbl
            // 
            this.productnamelbl.AutoSize = true;
            this.productnamelbl.Location = new System.Drawing.Point(201, 9);
            this.productnamelbl.Name = "productnamelbl";
            this.productnamelbl.Size = new System.Drawing.Size(120, 23);
            this.productnamelbl.TabIndex = 2;
            this.productnamelbl.Text = "Product Name";
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mfrtxtbox.Enabled = false;
            this.mfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfrtxtbox.Location = new System.Drawing.Point(14, 37);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.ReadOnly = true;
            this.mfrtxtbox.Size = new System.Drawing.Size(181, 32);
            this.mfrtxtbox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1768, 45);
            this.panel1.TabIndex = 39;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1768, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "PURCHASE QUOTATION INVOICE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(211, 56);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // PurchaseQuotationInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1768, 750);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "PurchaseQuotationInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE QUOTATION INVOICE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseQuotationInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseQuotationInvoice_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label supplierlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvpurchaseproducts;
        private System.Windows.Forms.Label productnamelbl;
        private System.Windows.Forms.TextBox mfrtxtbox;
        private System.Windows.Forms.Label mfrlbl;
        private System.Windows.Forms.Label qtylbl;
        private System.Windows.Forms.TextBox codetxtbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.TextBox selectsuppliertxtbox;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Label supplieridlbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Label invoicecodelbl;
        private System.Windows.Forms.TextBox companytxtbox;
        private System.Windows.Forms.Label companylbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnocolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mfrcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnamecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtycolumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
    }
}