namespace SmartFlow
{
    partial class PurchaseReturnInvoice
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mfrtxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvpurchaseproducts = new System.Windows.Forms.DataGridView();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.purchasetypetxtbox = new System.Windows.Forms.TextBox();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.purchasetypelbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.selectsuppliertxtbox = new System.Windows.Forms.TextBox();
            this.purchasenotxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.suppliercodetxtbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.narationtxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datelbl = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.supplierlbl = new System.Windows.Forms.Label();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.closebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.totaldiscountlbl = new System.Windows.Forms.Label();
            this.totalvatlbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.purchasetypeidlbl = new System.Windows.Forms.Label();
            this.supplieridlbl = new System.Windows.Forms.Label();
            this.currencyidlbl = new System.Windows.Forms.Label();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.currencyconversionratelbl = new System.Windows.Forms.Label();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.pricetxtbox = new System.Windows.Forms.TextBox();
            this.totaldiscounttxtbox = new System.Windows.Forms.TextBox();
            this.totalvattxtbox = new System.Windows.Forms.TextBox();
            this.nettotaltxtbox = new System.Windows.Forms.TextBox();
            this.mfrcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdescriptioncolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemconditioncolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtycolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicespecialnotelbl = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 187);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1755, 496);
            this.tabControl1.TabIndex = 56;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pricetxtbox);
            this.tabPage1.Controls.Add(this.qtytxtbox);
            this.tabPage1.Controls.Add(this.selectproducttxtbox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.mfrtxtbox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dgvpurchaseproducts);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1747, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Product Detail";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(202, 38);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(405, 32);
            this.selectproducttxtbox.TabIndex = 27;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            this.selectproducttxtbox.Leave += new System.EventHandler(this.selectproducttxtbox_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1583, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1425, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "QTY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Product Name";
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mfrtxtbox.Enabled = false;
            this.mfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfrtxtbox.Location = new System.Drawing.Point(15, 38);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.Size = new System.Drawing.Size(181, 32);
            this.mfrtxtbox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "MFR";
            // 
            // dgvpurchaseproducts
            // 
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
            this.mfrcolumn,
            this.itemdescriptioncolumn,
            this.itemconditioncolumn,
            this.productid,
            this.productnamecolumn,
            this.qtycolumn,
            this.unitidcolumn,
            this.unitnamecolumn,
            this.pricecolumn,
            this.vatcolumn,
            this.discountcolumn,
            this.totalcolumn});
            this.dgvpurchaseproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvpurchaseproducts.Enabled = false;
            this.dgvpurchaseproducts.Location = new System.Drawing.Point(4, 100);
            this.dgvpurchaseproducts.Name = "dgvpurchaseproducts";
            this.dgvpurchaseproducts.RowHeadersVisible = false;
            this.dgvpurchaseproducts.RowHeadersWidth = 51;
            this.dgvpurchaseproducts.RowTemplate.Height = 24;
            this.dgvpurchaseproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpurchaseproducts.Size = new System.Drawing.Size(1737, 355);
            this.dgvpurchaseproducts.TabIndex = 1;
            this.dgvpurchaseproducts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpurchaseproducts_CellValueChanged);
            this.dgvpurchaseproducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvpurchaseproducts_RowsAdded);
            this.dgvpurchaseproducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvpurchasequotationproduct_KeyDown);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.savebtn.Location = new System.Drawing.Point(1604, 689);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(158, 46);
            this.savebtn.TabIndex = 52;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.invoicespecialnotelbl);
            this.panel2.Controls.Add(this.currencyconversionratelbl);
            this.panel2.Controls.Add(this.currencysymbollbl);
            this.panel2.Controls.Add(this.currencynamelbl);
            this.panel2.Controls.Add(this.currencyidlbl);
            this.panel2.Controls.Add(this.supplieridlbl);
            this.panel2.Controls.Add(this.purchasetypeidlbl);
            this.panel2.Controls.Add(this.purchasetypetxtbox);
            this.panel2.Controls.Add(this.invoicedatetxtbox);
            this.panel2.Controls.Add(this.purchasetypelbl);
            this.panel2.Controls.Add(this.productidlbl);
            this.panel2.Controls.Add(this.selectsuppliertxtbox);
            this.panel2.Controls.Add(this.purchasenotxtbox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.suppliercodetxtbox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.narationtxtbox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.datelbl);
            this.panel2.Controls.Add(this.invoicenotxtbox);
            this.panel2.Controls.Add(this.supplierlbl);
            this.panel2.Controls.Add(this.invoicenolbl);
            this.panel2.Location = new System.Drawing.Point(11, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1252, 133);
            this.panel2.TabIndex = 51;
            // 
            // purchasetypetxtbox
            // 
            this.purchasetypetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.purchasetypetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasetypetxtbox.Location = new System.Drawing.Point(957, 3);
            this.purchasetypetxtbox.Name = "purchasetypetxtbox";
            this.purchasetypetxtbox.Size = new System.Drawing.Size(167, 32);
            this.purchasetypetxtbox.TabIndex = 117;
            this.purchasetypetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.purchasetypetxtbox_MouseClick);
            this.purchasetypetxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.purchasetypetxtbox_KeyDown);
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(347, 3);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(187, 32);
            this.invoicedatetxtbox.TabIndex = 115;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // purchasetypelbl
            // 
            this.purchasetypelbl.AutoSize = true;
            this.purchasetypelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasetypelbl.Location = new System.Drawing.Point(830, 8);
            this.purchasetypelbl.Name = "purchasetypelbl";
            this.purchasetypelbl.Size = new System.Drawing.Size(121, 23);
            this.purchasetypelbl.TabIndex = 116;
            this.purchasetypelbl.Text = "Purchase Type";
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(1135, 110);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(63, 16);
            this.productidlbl.TabIndex = 68;
            this.productidlbl.Text = "productid";
            this.productidlbl.Visible = false;
            // 
            // selectsuppliertxtbox
            // 
            this.selectsuppliertxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectsuppliertxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectsuppliertxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectsuppliertxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectsuppliertxtbox.Location = new System.Drawing.Point(291, 36);
            this.selectsuppliertxtbox.Name = "selectsuppliertxtbox";
            this.selectsuppliertxtbox.Size = new System.Drawing.Size(833, 32);
            this.selectsuppliertxtbox.TabIndex = 66;
            this.selectsuppliertxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectsuppliertxtbox_MouseClick);
            this.selectsuppliertxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectsuppliertxtbox_KeyDown);
            this.selectsuppliertxtbox.Leave += new System.EventHandler(this.selectsuppliertxtbox_Leave);
            // 
            // purchasenotxtbox
            // 
            this.purchasenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.purchasenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasenotxtbox.Location = new System.Drawing.Point(657, 3);
            this.purchasenotxtbox.Name = "purchasenotxtbox";
            this.purchasenotxtbox.Size = new System.Drawing.Size(167, 32);
            this.purchasenotxtbox.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(540, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 62;
            this.label2.Text = "Purchase No ";
            // 
            // suppliercodetxtbox
            // 
            this.suppliercodetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.suppliercodetxtbox.Enabled = false;
            this.suppliercodetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliercodetxtbox.Location = new System.Drawing.Point(118, 36);
            this.suppliercodetxtbox.Name = "suppliercodetxtbox";
            this.suppliercodetxtbox.Size = new System.Drawing.Size(167, 32);
            this.suppliercodetxtbox.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // narationtxtbox
            // 
            this.narationtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.narationtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.narationtxtbox.Location = new System.Drawing.Point(118, 94);
            this.narationtxtbox.Name = "narationtxtbox";
            this.narationtxtbox.Size = new System.Drawing.Size(1006, 32);
            this.narationtxtbox.TabIndex = 17;
            this.narationtxtbox.Leave += new System.EventHandler(this.narationtxtbox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Narration ";
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(291, 8);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(50, 23);
            this.datelbl.TabIndex = 4;
            this.datelbl.Text = "Date ";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Enabled = false;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(118, 3);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(167, 32);
            this.invoicenotxtbox.TabIndex = 2;
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(11, 41);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(77, 23);
            this.supplierlbl.TabIndex = 1;
            this.supplierlbl.Text = "Supplier ";
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(11, 8);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(96, 23);
            this.invoicenolbl.TabIndex = 0;
            this.invoicenolbl.Text = "Inovice No ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.closebtn.Location = new System.Drawing.Point(1440, 689);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(158, 46);
            this.closebtn.TabIndex = 55;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1768, 45);
            this.panel1.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1768, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "PURCHASE RETURN INVOICE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totaldiscountlbl
            // 
            this.totaldiscountlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldiscountlbl.AutoSize = true;
            this.totaldiscountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldiscountlbl.Location = new System.Drawing.Point(1269, 163);
            this.totaldiscountlbl.Name = "totaldiscountlbl";
            this.totaldiscountlbl.Size = new System.Drawing.Size(95, 16);
            this.totaldiscountlbl.TabIndex = 151;
            this.totaldiscountlbl.Text = "TOTAL DISS";
            this.totaldiscountlbl.Visible = false;
            // 
            // totalvatlbl
            // 
            this.totalvatlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalvatlbl.AutoSize = true;
            this.totalvatlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalvatlbl.Location = new System.Drawing.Point(1269, 129);
            this.totalvatlbl.Name = "totalvatlbl";
            this.totalvatlbl.Size = new System.Drawing.Size(90, 16);
            this.totalvatlbl.TabIndex = 147;
            this.totalvatlbl.Text = "TOTAL VAT";
            this.totalvatlbl.Visible = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1268, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 23);
            this.label14.TabIndex = 146;
            this.label14.Text = "NET TOTAL";
            // 
            // purchasetypeidlbl
            // 
            this.purchasetypeidlbl.AutoSize = true;
            this.purchasetypeidlbl.Location = new System.Drawing.Point(1135, 3);
            this.purchasetypeidlbl.Name = "purchasetypeidlbl";
            this.purchasetypeidlbl.Size = new System.Drawing.Size(114, 16);
            this.purchasetypeidlbl.TabIndex = 118;
            this.purchasetypeidlbl.Text = "purchasetypeidlbl";
            this.purchasetypeidlbl.Visible = false;
            // 
            // supplieridlbl
            // 
            this.supplieridlbl.AutoSize = true;
            this.supplieridlbl.Location = new System.Drawing.Point(1138, 23);
            this.supplieridlbl.Name = "supplieridlbl";
            this.supplieridlbl.Size = new System.Drawing.Size(80, 16);
            this.supplieridlbl.TabIndex = 119;
            this.supplieridlbl.Text = "supplieridlbl";
            this.supplieridlbl.Visible = false;
            // 
            // currencyidlbl
            // 
            this.currencyidlbl.AutoSize = true;
            this.currencyidlbl.Location = new System.Drawing.Point(1135, 44);
            this.currencyidlbl.Name = "currencyidlbl";
            this.currencyidlbl.Size = new System.Drawing.Size(83, 16);
            this.currencyidlbl.TabIndex = 120;
            this.currencyidlbl.Text = "currencyidlbl";
            this.currencyidlbl.Visible = false;
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Location = new System.Drawing.Point(1135, 63);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(106, 16);
            this.currencynamelbl.TabIndex = 121;
            this.currencynamelbl.Text = "currencynamelbl";
            this.currencynamelbl.Visible = false;
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Location = new System.Drawing.Point(1135, 81);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(116, 16);
            this.currencysymbollbl.TabIndex = 122;
            this.currencysymbollbl.Text = "currencysymbollbl";
            this.currencysymbollbl.Visible = false;
            // 
            // currencyconversionratelbl
            // 
            this.currencyconversionratelbl.AutoSize = true;
            this.currencyconversionratelbl.Location = new System.Drawing.Point(1138, 94);
            this.currencyconversionratelbl.Name = "currencyconversionratelbl";
            this.currencyconversionratelbl.Size = new System.Drawing.Size(161, 16);
            this.currencyconversionratelbl.TabIndex = 123;
            this.currencyconversionratelbl.Text = "currencyconversionratelbl";
            this.currencyconversionratelbl.Visible = false;
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F);
            this.qtytxtbox.Location = new System.Drawing.Point(1427, 38);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(154, 32);
            this.qtytxtbox.TabIndex = 34;
            this.qtytxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pricetxtbox
            // 
            this.pricetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pricetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pricetxtbox.Font = new System.Drawing.Font("Calibri", 12F);
            this.pricetxtbox.Location = new System.Drawing.Point(1587, 38);
            this.pricetxtbox.Name = "pricetxtbox";
            this.pricetxtbox.Size = new System.Drawing.Size(154, 32);
            this.pricetxtbox.TabIndex = 38;
            this.pricetxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pricetxtbox.Leave += new System.EventHandler(this.pricetxtbox_Leave);
            // 
            // totaldiscounttxtbox
            // 
            this.totaldiscounttxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldiscounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totaldiscounttxtbox.Enabled = false;
            this.totaldiscounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldiscounttxtbox.Location = new System.Drawing.Point(1378, 155);
            this.totaldiscounttxtbox.Name = "totaldiscounttxtbox";
            this.totaldiscounttxtbox.Size = new System.Drawing.Size(378, 32);
            this.totaldiscounttxtbox.TabIndex = 152;
            this.totaldiscounttxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totaldiscounttxtbox.Visible = false;
            // 
            // totalvattxtbox
            // 
            this.totalvattxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalvattxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalvattxtbox.Enabled = false;
            this.totalvattxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalvattxtbox.Location = new System.Drawing.Point(1378, 122);
            this.totalvattxtbox.Name = "totalvattxtbox";
            this.totalvattxtbox.Size = new System.Drawing.Size(378, 32);
            this.totalvattxtbox.TabIndex = 153;
            this.totalvattxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalvattxtbox.Visible = false;
            // 
            // nettotaltxtbox
            // 
            this.nettotaltxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nettotaltxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nettotaltxtbox.Enabled = false;
            this.nettotaltxtbox.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nettotaltxtbox.Location = new System.Drawing.Point(1378, 51);
            this.nettotaltxtbox.Name = "nettotaltxtbox";
            this.nettotaltxtbox.Size = new System.Drawing.Size(378, 69);
            this.nettotaltxtbox.TabIndex = 154;
            this.nettotaltxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mfrcolumn
            // 
            this.mfrcolumn.HeaderText = "MFR";
            this.mfrcolumn.MinimumWidth = 6;
            this.mfrcolumn.Name = "mfrcolumn";
            this.mfrcolumn.Width = 125;
            // 
            // itemdescriptioncolumn
            // 
            this.itemdescriptioncolumn.HeaderText = "itemdescription";
            this.itemdescriptioncolumn.MinimumWidth = 6;
            this.itemdescriptioncolumn.Name = "itemdescriptioncolumn";
            this.itemdescriptioncolumn.Visible = false;
            this.itemdescriptioncolumn.Width = 125;
            // 
            // itemconditioncolumn
            // 
            this.itemconditioncolumn.HeaderText = "Condition";
            this.itemconditioncolumn.MinimumWidth = 6;
            this.itemconditioncolumn.Name = "itemconditioncolumn";
            this.itemconditioncolumn.Visible = false;
            this.itemconditioncolumn.Width = 125;
            // 
            // productid
            // 
            this.productid.HeaderText = "ID";
            this.productid.MinimumWidth = 6;
            this.productid.Name = "productid";
            this.productid.Visible = false;
            this.productid.Width = 125;
            // 
            // productnamecolumn
            // 
            this.productnamecolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productnamecolumn.HeaderText = "Product Name";
            this.productnamecolumn.MinimumWidth = 6;
            this.productnamecolumn.Name = "productnamecolumn";
            // 
            // qtycolumn
            // 
            this.qtycolumn.HeaderText = "Qty";
            this.qtycolumn.MinimumWidth = 6;
            this.qtycolumn.Name = "qtycolumn";
            this.qtycolumn.Width = 125;
            // 
            // unitidcolumn
            // 
            this.unitidcolumn.HeaderText = "unitid";
            this.unitidcolumn.MinimumWidth = 6;
            this.unitidcolumn.Name = "unitidcolumn";
            this.unitidcolumn.Visible = false;
            this.unitidcolumn.Width = 125;
            // 
            // unitnamecolumn
            // 
            this.unitnamecolumn.HeaderText = "Unit";
            this.unitnamecolumn.MinimumWidth = 6;
            this.unitnamecolumn.Name = "unitnamecolumn";
            this.unitnamecolumn.Width = 125;
            // 
            // pricecolumn
            // 
            this.pricecolumn.HeaderText = "Price";
            this.pricecolumn.MinimumWidth = 6;
            this.pricecolumn.Name = "pricecolumn";
            this.pricecolumn.Width = 125;
            // 
            // vatcolumn
            // 
            this.vatcolumn.HeaderText = "VAT";
            this.vatcolumn.MinimumWidth = 6;
            this.vatcolumn.Name = "vatcolumn";
            this.vatcolumn.Width = 125;
            // 
            // discountcolumn
            // 
            this.discountcolumn.HeaderText = "Discount";
            this.discountcolumn.MinimumWidth = 6;
            this.discountcolumn.Name = "discountcolumn";
            this.discountcolumn.Width = 125;
            // 
            // totalcolumn
            // 
            this.totalcolumn.HeaderText = "Total";
            this.totalcolumn.MinimumWidth = 6;
            this.totalcolumn.Name = "totalcolumn";
            this.totalcolumn.Width = 125;
            // 
            // invoicespecialnotelbl
            // 
            this.invoicespecialnotelbl.AutoSize = true;
            this.invoicespecialnotelbl.Location = new System.Drawing.Point(990, 74);
            this.invoicespecialnotelbl.Name = "invoicespecialnotelbl";
            this.invoicespecialnotelbl.Size = new System.Drawing.Size(134, 16);
            this.invoicespecialnotelbl.TabIndex = 124;
            this.invoicespecialnotelbl.Text = "invoicespecialnotelbl";
            this.invoicespecialnotelbl.Visible = false;
            // 
            // PurchaseReturnInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1768, 767);
            this.Controls.Add(this.nettotaltxtbox);
            this.Controls.Add(this.totalvattxtbox);
            this.Controls.Add(this.totaldiscounttxtbox);
            this.Controls.Add(this.totaldiscountlbl);
            this.Controls.Add(this.totalvatlbl);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.closebtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseReturnInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Return Invoice - Future Art Broadcast Trading LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PurchaseReturnInvoice_FormClosing);
            this.Load += new System.EventHandler(this.PurchaseReturnInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseReturnInvoice_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvpurchaseproducts;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox suppliercodetxtbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox narationtxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label supplierlbl;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.TextBox purchasenotxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox selectsuppliertxtbox;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mfrtxtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Label totaldiscountlbl;
        private System.Windows.Forms.Label totalvatlbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox purchasetypetxtbox;
        private System.Windows.Forms.Label purchasetypelbl;
        private System.Windows.Forms.Label purchasetypeidlbl;
        private System.Windows.Forms.Label supplieridlbl;
        private System.Windows.Forms.Label currencyconversionratelbl;
        private System.Windows.Forms.Label currencysymbollbl;
        private System.Windows.Forms.Label currencynamelbl;
        private System.Windows.Forms.Label currencyidlbl;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.TextBox pricetxtbox;
        private System.Windows.Forms.TextBox totaldiscounttxtbox;
        private System.Windows.Forms.TextBox totalvattxtbox;
        private System.Windows.Forms.TextBox nettotaltxtbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn mfrcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemdescriptioncolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemconditioncolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnamecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtycolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitnamecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalcolumn;
        private System.Windows.Forms.Label invoicespecialnotelbl;
    }
}