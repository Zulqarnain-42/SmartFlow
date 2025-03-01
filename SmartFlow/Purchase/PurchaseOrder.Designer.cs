using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    partial class PurchaseOrder
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
            this.newbtn = new System.Windows.Forms.Button();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.datelbl = new System.Windows.Forms.Label();
            this.supplierlbl = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addbtn = new System.Windows.Forms.Button();
            this.dgvpurchaseproducts = new System.Windows.Forms.DataGridView();
            this.srnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtycolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availabilitycolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdescriptioncolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthinmetercolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricepermetercolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatpercentagecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountpercentagecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discounttypecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.mfrlbl = new System.Windows.Forms.Label();
            this.mfrtxtbox = new System.Windows.Forms.TextBox();
            this.qtylbl = new System.Windows.Forms.Label();
            this.productnamelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.discounttypelbl = new System.Windows.Forms.Label();
            this.discountpercentagelbl = new System.Windows.Forms.Label();
            this.vatcodelbl = new System.Windows.Forms.Label();
            this.productdiscountlbl = new System.Windows.Forms.Label();
            this.productvatlbl = new System.Windows.Forms.Label();
            this.unitidlbl = new System.Windows.Forms.Label();
            this.unitnamelbl = new System.Windows.Forms.Label();
            this.totalcolumnlbl = new System.Windows.Forms.Label();
            this.lengthinmeterlbl = new System.Windows.Forms.Label();
            this.pricepermeterlbl = new System.Windows.Forms.Label();
            this.unitsalepricelbl = new System.Windows.Forms.Label();
            this.itemdescriptionlbl = new System.Windows.Forms.Label();
            this.companytxtbox = new System.Windows.Forms.TextBox();
            this.companylbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.productidlbl = new System.Windows.Forms.Label();
            this.selectsuppliertxtbox = new System.Windows.Forms.TextBox();
            this.codetxtbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.currencyconversionratelbl = new System.Windows.Forms.Label();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.invoicecodelbl = new System.Windows.Forms.Label();
            this.supplieridlbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.currencyidlbl = new System.Windows.Forms.Label();
            this.currencylbl = new System.Windows.Forms.Label();
            this.removevatchkbox = new System.Windows.Forms.CheckBox();
            this.nettotaltxtbox = new System.Windows.Forms.TextBox();
            this.totalvattxtbox = new System.Windows.Forms.TextBox();
            this.totaldiscounttxtbox = new System.Windows.Forms.TextBox();
            this.totaldiscountlbl = new System.Windows.Forms.Label();
            this.totalvatlbl = new System.Windows.Forms.Label();
            this.nettotallbl = new System.Windows.Forms.Label();
            this.addvatchkbox = new System.Windows.Forms.CheckBox();
            this.availabilitystatuslbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newbtn
            // 
            this.newbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.newbtn.Location = new System.Drawing.Point(1076, 568);
            this.newbtn.Margin = new System.Windows.Forms.Padding(2);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(118, 37);
            this.newbtn.TabIndex = 47;
            this.newbtn.Text = "NEW";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Enabled = false;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(91, 3);
            this.invoicenotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.ReadOnly = true;
            this.invoicenotxtbox.Size = new System.Drawing.Size(126, 27);
            this.invoicenotxtbox.TabIndex = 0;
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(218, 7);
            this.datelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(40, 18);
            this.datelbl.TabIndex = 4;
            this.datelbl.Text = "Date ";
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(9, 34);
            this.supplierlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(63, 18);
            this.supplierlbl.TabIndex = 1;
            this.supplierlbl.Text = "Supplier ";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(9, 171);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1308, 392);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.addbtn);
            this.tabPage1.Controls.Add(this.dgvpurchaseproducts);
            this.tabPage1.Controls.Add(this.qtytxtbox);
            this.tabPage1.Controls.Add(this.selectproducttxtbox);
            this.tabPage1.Controls.Add(this.mfrlbl);
            this.tabPage1.Controls.Add(this.mfrtxtbox);
            this.tabPage1.Controls.Add(this.qtylbl);
            this.tabPage1.Controls.Add(this.productnamelbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1300, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Product Detail";
            // 
            // addbtn
            // 
            this.addbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addbtn.Location = new System.Drawing.Point(1204, 28);
            this.addbtn.Margin = new System.Windows.Forms.Padding(2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(84, 26);
            this.addbtn.TabIndex = 3;
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
            this.dgvpurchaseproducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvpurchaseproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchaseproducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srnocolumn,
            this.codecolumn,
            this.productid,
            this.productnamecolumn,
            this.qtycolumn,
            this.availabilitycolumn,
            this.unitidcolumn,
            this.unitname,
            this.pricecolumn,
            this.vatcolumn,
            this.discountcolumn,
            this.totalcolumn,
            this.warehouseidcolumn,
            this.itemdescriptioncolumn,
            this.lengthinmetercolumn,
            this.pricepermetercolumn,
            this.vatpercentagecolumn,
            this.discountpercentagecolumn,
            this.discounttypecolumn});
            this.dgvpurchaseproducts.ContextMenuStrip = this.contextMenuStrip;
            this.dgvpurchaseproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvpurchaseproducts.Location = new System.Drawing.Point(4, 59);
            this.dgvpurchaseproducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvpurchaseproducts.MultiSelect = false;
            this.dgvpurchaseproducts.Name = "dgvpurchaseproducts";
            this.dgvpurchaseproducts.ReadOnly = true;
            this.dgvpurchaseproducts.RowHeadersVisible = false;
            this.dgvpurchaseproducts.RowHeadersWidth = 51;
            this.dgvpurchaseproducts.RowTemplate.Height = 24;
            this.dgvpurchaseproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpurchaseproducts.Size = new System.Drawing.Size(1293, 299);
            this.dgvpurchaseproducts.TabIndex = 1;
            this.dgvpurchaseproducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvpurchaseproducts_CellFormatting);
            this.dgvpurchaseproducts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpurchaseproducts_CellValueChanged);
            this.dgvpurchaseproducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvpurchaseproducts_RowsAdded);
            this.dgvpurchaseproducts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvpurchaseproducts_RowsRemoved);
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
            // codecolumn
            // 
            this.codecolumn.HeaderText = "MFR";
            this.codecolumn.MinimumWidth = 6;
            this.codecolumn.Name = "codecolumn";
            this.codecolumn.ReadOnly = true;
            this.codecolumn.Width = 125;
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
            // availabilitycolumn
            // 
            this.availabilitycolumn.HeaderText = "AVAIL";
            this.availabilitycolumn.Name = "availabilitycolumn";
            this.availabilitycolumn.ReadOnly = true;
            this.availabilitycolumn.Visible = false;
            // 
            // unitidcolumn
            // 
            this.unitidcolumn.HeaderText = "unitid";
            this.unitidcolumn.MinimumWidth = 6;
            this.unitidcolumn.Name = "unitidcolumn";
            this.unitidcolumn.ReadOnly = true;
            this.unitidcolumn.Visible = false;
            this.unitidcolumn.Width = 125;
            // 
            // unitname
            // 
            this.unitname.HeaderText = "UNIT";
            this.unitname.MinimumWidth = 6;
            this.unitname.Name = "unitname";
            this.unitname.ReadOnly = true;
            this.unitname.Width = 125;
            // 
            // pricecolumn
            // 
            this.pricecolumn.HeaderText = "Price";
            this.pricecolumn.MinimumWidth = 6;
            this.pricecolumn.Name = "pricecolumn";
            this.pricecolumn.ReadOnly = true;
            this.pricecolumn.Width = 125;
            // 
            // vatcolumn
            // 
            this.vatcolumn.HeaderText = "VAT";
            this.vatcolumn.MinimumWidth = 6;
            this.vatcolumn.Name = "vatcolumn";
            this.vatcolumn.ReadOnly = true;
            this.vatcolumn.Width = 125;
            // 
            // discountcolumn
            // 
            this.discountcolumn.HeaderText = "DISS";
            this.discountcolumn.Name = "discountcolumn";
            this.discountcolumn.ReadOnly = true;
            // 
            // totalcolumn
            // 
            this.totalcolumn.HeaderText = "Total";
            this.totalcolumn.MinimumWidth = 6;
            this.totalcolumn.Name = "totalcolumn";
            this.totalcolumn.ReadOnly = true;
            this.totalcolumn.Width = 125;
            // 
            // warehouseidcolumn
            // 
            this.warehouseidcolumn.HeaderText = "warehouseidcolumn";
            this.warehouseidcolumn.Name = "warehouseidcolumn";
            this.warehouseidcolumn.ReadOnly = true;
            this.warehouseidcolumn.Visible = false;
            // 
            // itemdescriptioncolumn
            // 
            this.itemdescriptioncolumn.HeaderText = "itemdescription";
            this.itemdescriptioncolumn.MinimumWidth = 6;
            this.itemdescriptioncolumn.Name = "itemdescriptioncolumn";
            this.itemdescriptioncolumn.ReadOnly = true;
            this.itemdescriptioncolumn.Visible = false;
            this.itemdescriptioncolumn.Width = 125;
            // 
            // lengthinmetercolumn
            // 
            this.lengthinmetercolumn.HeaderText = "lengthinmeter";
            this.lengthinmetercolumn.MinimumWidth = 6;
            this.lengthinmetercolumn.Name = "lengthinmetercolumn";
            this.lengthinmetercolumn.ReadOnly = true;
            this.lengthinmetercolumn.Visible = false;
            this.lengthinmetercolumn.Width = 125;
            // 
            // pricepermetercolumn
            // 
            this.pricepermetercolumn.HeaderText = "pricepermeter";
            this.pricepermetercolumn.MinimumWidth = 6;
            this.pricepermetercolumn.Name = "pricepermetercolumn";
            this.pricepermetercolumn.ReadOnly = true;
            this.pricepermetercolumn.Visible = false;
            this.pricepermetercolumn.Width = 125;
            // 
            // vatpercentagecolumn
            // 
            this.vatpercentagecolumn.HeaderText = "vatpercentagecolumn";
            this.vatpercentagecolumn.Name = "vatpercentagecolumn";
            this.vatpercentagecolumn.ReadOnly = true;
            this.vatpercentagecolumn.Visible = false;
            // 
            // discountpercentagecolumn
            // 
            this.discountpercentagecolumn.HeaderText = "discountpercentagecolumn";
            this.discountpercentagecolumn.Name = "discountpercentagecolumn";
            this.discountpercentagecolumn.ReadOnly = true;
            this.discountpercentagecolumn.Visible = false;
            // 
            // discounttypecolumn
            // 
            this.discounttypecolumn.HeaderText = "discounttypecolumn";
            this.discounttypecolumn.Name = "discounttypecolumn";
            this.discounttypecolumn.ReadOnly = true;
            this.discounttypecolumn.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F);
            this.qtytxtbox.Location = new System.Drawing.Point(459, 29);
            this.qtytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(116, 27);
            this.qtytxtbox.TabIndex = 2;
            this.qtytxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtytxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtytxtbox_KeyPress);
            this.qtytxtbox.Leave += new System.EventHandler(this.qtytxtbox_Leave);
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(151, 29);
            this.selectproducttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(304, 27);
            this.selectproducttxtbox.TabIndex = 1;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // mfrlbl
            // 
            this.mfrlbl.AutoSize = true;
            this.mfrlbl.Location = new System.Drawing.Point(10, 7);
            this.mfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mfrlbl.Name = "mfrlbl";
            this.mfrlbl.Size = new System.Drawing.Size(35, 18);
            this.mfrlbl.TabIndex = 0;
            this.mfrlbl.Text = "MFR";
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mfrtxtbox.Enabled = false;
            this.mfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfrtxtbox.Location = new System.Drawing.Point(10, 29);
            this.mfrtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.ReadOnly = true;
            this.mfrtxtbox.Size = new System.Drawing.Size(136, 27);
            this.mfrtxtbox.TabIndex = 0;
            // 
            // qtylbl
            // 
            this.qtylbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qtylbl.AutoSize = true;
            this.qtylbl.Location = new System.Drawing.Point(456, 7);
            this.qtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qtylbl.Name = "qtylbl";
            this.qtylbl.Size = new System.Drawing.Size(32, 18);
            this.qtylbl.TabIndex = 4;
            this.qtylbl.Text = "QTY";
            // 
            // productnamelbl
            // 
            this.productnamelbl.AutoSize = true;
            this.productnamelbl.Location = new System.Drawing.Point(151, 7);
            this.productnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productnamelbl.Name = "productnamelbl";
            this.productnamelbl.Size = new System.Drawing.Size(96, 18);
            this.productnamelbl.TabIndex = 2;
            this.productnamelbl.Text = "Product Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.discounttypelbl);
            this.panel2.Controls.Add(this.discountpercentagelbl);
            this.panel2.Controls.Add(this.vatcodelbl);
            this.panel2.Controls.Add(this.productdiscountlbl);
            this.panel2.Controls.Add(this.productvatlbl);
            this.panel2.Controls.Add(this.unitidlbl);
            this.panel2.Controls.Add(this.unitnamelbl);
            this.panel2.Controls.Add(this.totalcolumnlbl);
            this.panel2.Controls.Add(this.lengthinmeterlbl);
            this.panel2.Controls.Add(this.pricepermeterlbl);
            this.panel2.Controls.Add(this.unitsalepricelbl);
            this.panel2.Controls.Add(this.itemdescriptionlbl);
            this.panel2.Controls.Add(this.companytxtbox);
            this.panel2.Controls.Add(this.companylbl);
            this.panel2.Controls.Add(this.invoicedatetxtbox);
            this.panel2.Controls.Add(this.productidlbl);
            this.panel2.Controls.Add(this.selectsuppliertxtbox);
            this.panel2.Controls.Add(this.codetxtbox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.datelbl);
            this.panel2.Controls.Add(this.invoicenotxtbox);
            this.panel2.Controls.Add(this.supplierlbl);
            this.panel2.Controls.Add(this.invoicenolbl);
            this.panel2.Location = new System.Drawing.Point(9, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 128);
            this.panel2.TabIndex = 45;
            // 
            // discounttypelbl
            // 
            this.discounttypelbl.AutoSize = true;
            this.discounttypelbl.Location = new System.Drawing.Point(360, 109);
            this.discounttypelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discounttypelbl.Name = "discounttypelbl";
            this.discounttypelbl.Size = new System.Drawing.Size(77, 13);
            this.discounttypelbl.TabIndex = 169;
            this.discounttypelbl.Text = "discounttypelbl";
            this.discounttypelbl.Visible = false;
            // 
            // discountpercentagelbl
            // 
            this.discountpercentagelbl.AutoSize = true;
            this.discountpercentagelbl.Location = new System.Drawing.Point(245, 109);
            this.discountpercentagelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discountpercentagelbl.Name = "discountpercentagelbl";
            this.discountpercentagelbl.Size = new System.Drawing.Size(111, 13);
            this.discountpercentagelbl.TabIndex = 168;
            this.discountpercentagelbl.Text = "discountpercentagelbl";
            this.discountpercentagelbl.Visible = false;
            // 
            // vatcodelbl
            // 
            this.vatcodelbl.AutoSize = true;
            this.vatcodelbl.Location = new System.Drawing.Point(185, 109);
            this.vatcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vatcodelbl.Name = "vatcodelbl";
            this.vatcodelbl.Size = new System.Drawing.Size(56, 13);
            this.vatcodelbl.TabIndex = 167;
            this.vatcodelbl.Text = "vatcodelbl";
            this.vatcodelbl.Visible = false;
            // 
            // productdiscountlbl
            // 
            this.productdiscountlbl.AutoSize = true;
            this.productdiscountlbl.Location = new System.Drawing.Point(88, 109);
            this.productdiscountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productdiscountlbl.Name = "productdiscountlbl";
            this.productdiscountlbl.Size = new System.Drawing.Size(93, 13);
            this.productdiscountlbl.TabIndex = 166;
            this.productdiscountlbl.Text = "productdiscountlbl";
            this.productdiscountlbl.Visible = false;
            // 
            // productvatlbl
            // 
            this.productvatlbl.AutoSize = true;
            this.productvatlbl.Location = new System.Drawing.Point(862, 61);
            this.productvatlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productvatlbl.Name = "productvatlbl";
            this.productvatlbl.Size = new System.Drawing.Size(68, 13);
            this.productvatlbl.TabIndex = 159;
            this.productvatlbl.Text = "productvatlbl";
            this.productvatlbl.Visible = false;
            // 
            // unitidlbl
            // 
            this.unitidlbl.AutoSize = true;
            this.unitidlbl.Location = new System.Drawing.Point(746, 93);
            this.unitidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitidlbl.Name = "unitidlbl";
            this.unitidlbl.Size = new System.Drawing.Size(42, 13);
            this.unitidlbl.TabIndex = 158;
            this.unitidlbl.Text = "unitidlbl";
            this.unitidlbl.Visible = false;
            // 
            // unitnamelbl
            // 
            this.unitnamelbl.AutoSize = true;
            this.unitnamelbl.Location = new System.Drawing.Point(746, 80);
            this.unitnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitnamelbl.Name = "unitnamelbl";
            this.unitnamelbl.Size = new System.Drawing.Size(60, 13);
            this.unitnamelbl.TabIndex = 157;
            this.unitnamelbl.Text = "unitnamelbl";
            this.unitnamelbl.Visible = false;
            // 
            // totalcolumnlbl
            // 
            this.totalcolumnlbl.AutoSize = true;
            this.totalcolumnlbl.Location = new System.Drawing.Point(745, 67);
            this.totalcolumnlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalcolumnlbl.Name = "totalcolumnlbl";
            this.totalcolumnlbl.Size = new System.Drawing.Size(71, 13);
            this.totalcolumnlbl.TabIndex = 156;
            this.totalcolumnlbl.Text = "totalcolumnlbl";
            this.totalcolumnlbl.Visible = false;
            // 
            // lengthinmeterlbl
            // 
            this.lengthinmeterlbl.AutoSize = true;
            this.lengthinmeterlbl.Location = new System.Drawing.Point(746, 54);
            this.lengthinmeterlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lengthinmeterlbl.Name = "lengthinmeterlbl";
            this.lengthinmeterlbl.Size = new System.Drawing.Size(80, 13);
            this.lengthinmeterlbl.TabIndex = 155;
            this.lengthinmeterlbl.Text = "lengthinmeterlbl";
            this.lengthinmeterlbl.Visible = false;
            // 
            // pricepermeterlbl
            // 
            this.pricepermeterlbl.AutoSize = true;
            this.pricepermeterlbl.Location = new System.Drawing.Point(746, 41);
            this.pricepermeterlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pricepermeterlbl.Name = "pricepermeterlbl";
            this.pricepermeterlbl.Size = new System.Drawing.Size(81, 13);
            this.pricepermeterlbl.TabIndex = 154;
            this.pricepermeterlbl.Text = "pricepermeterlbl";
            this.pricepermeterlbl.Visible = false;
            // 
            // unitsalepricelbl
            // 
            this.unitsalepricelbl.AutoSize = true;
            this.unitsalepricelbl.Location = new System.Drawing.Point(746, 24);
            this.unitsalepricelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitsalepricelbl.Name = "unitsalepricelbl";
            this.unitsalepricelbl.Size = new System.Drawing.Size(76, 13);
            this.unitsalepricelbl.TabIndex = 153;
            this.unitsalepricelbl.Text = "unitsalepricelbl";
            this.unitsalepricelbl.Visible = false;
            // 
            // itemdescriptionlbl
            // 
            this.itemdescriptionlbl.AutoSize = true;
            this.itemdescriptionlbl.Location = new System.Drawing.Point(745, 7);
            this.itemdescriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.itemdescriptionlbl.Name = "itemdescriptionlbl";
            this.itemdescriptionlbl.Size = new System.Drawing.Size(87, 13);
            this.itemdescriptionlbl.TabIndex = 152;
            this.itemdescriptionlbl.Text = "itemdescriptionlbl";
            this.itemdescriptionlbl.Visible = false;
            // 
            // companytxtbox
            // 
            this.companytxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.companytxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.companytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.companytxtbox.Enabled = false;
            this.companytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companytxtbox.Location = new System.Drawing.Point(91, 80);
            this.companytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.companytxtbox.Name = "companytxtbox";
            this.companytxtbox.Size = new System.Drawing.Size(650, 27);
            this.companytxtbox.TabIndex = 4;
            // 
            // companylbl
            // 
            this.companylbl.AutoSize = true;
            this.companylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companylbl.Location = new System.Drawing.Point(10, 83);
            this.companylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.companylbl.Name = "companylbl";
            this.companylbl.Size = new System.Drawing.Size(66, 18);
            this.companylbl.TabIndex = 150;
            this.companylbl.Text = "Company";
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(297, 3);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(445, 27);
            this.invoicedatetxtbox.TabIndex = 1;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(862, 21);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(51, 13);
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
            this.selectsuppliertxtbox.Location = new System.Drawing.Point(221, 34);
            this.selectsuppliertxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectsuppliertxtbox.Name = "selectsuppliertxtbox";
            this.selectsuppliertxtbox.Size = new System.Drawing.Size(520, 27);
            this.selectsuppliertxtbox.TabIndex = 3;
            this.selectsuppliertxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectsuppliertxtbox_MouseClick);
            this.selectsuppliertxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectsuppliertxtbox_KeyDown);
            // 
            // codetxtbox
            // 
            this.codetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codetxtbox.Enabled = false;
            this.codetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codetxtbox.Location = new System.Drawing.Point(92, 34);
            this.codetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.codetxtbox.Name = "codetxtbox";
            this.codetxtbox.ReadOnly = true;
            this.codetxtbox.Size = new System.Drawing.Size(126, 27);
            this.codetxtbox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(8, 7);
            this.invoicenolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(77, 18);
            this.invoicenolbl.TabIndex = 0;
            this.invoicenolbl.Text = "Inovice No ";
            // 
            // currencyconversionratelbl
            // 
            this.currencyconversionratelbl.AutoSize = true;
            this.currencyconversionratelbl.Location = new System.Drawing.Point(132, 582);
            this.currencyconversionratelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencyconversionratelbl.Name = "currencyconversionratelbl";
            this.currencyconversionratelbl.Size = new System.Drawing.Size(128, 13);
            this.currencyconversionratelbl.TabIndex = 163;
            this.currencyconversionratelbl.Text = "currencyconversionratelbl";
            this.currencyconversionratelbl.Visible = false;
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Location = new System.Drawing.Point(264, 582);
            this.currencynamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(84, 13);
            this.currencynamelbl.TabIndex = 165;
            this.currencynamelbl.Text = "currencynamelbl";
            this.currencynamelbl.Visible = false;
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Location = new System.Drawing.Point(439, 582);
            this.currencysymbollbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(90, 13);
            this.currencysymbollbl.TabIndex = 163;
            this.currencysymbollbl.Text = "currencysymbollbl";
            this.currencysymbollbl.Visible = false;
            // 
            // invoicecodelbl
            // 
            this.invoicecodelbl.AutoSize = true;
            this.invoicecodelbl.Location = new System.Drawing.Point(658, 582);
            this.invoicecodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.invoicecodelbl.Name = "invoicecodelbl";
            this.invoicecodelbl.Size = new System.Drawing.Size(75, 13);
            this.invoicecodelbl.TabIndex = 114;
            this.invoicecodelbl.Text = "invoicecodelbl";
            this.invoicecodelbl.Visible = false;
            // 
            // supplieridlbl
            // 
            this.supplieridlbl.AutoSize = true;
            this.supplieridlbl.Location = new System.Drawing.Point(603, 582);
            this.supplieridlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.supplieridlbl.Name = "supplieridlbl";
            this.supplieridlbl.Size = new System.Drawing.Size(51, 13);
            this.supplieridlbl.TabIndex = 68;
            this.supplieridlbl.Text = "supplierid";
            this.supplieridlbl.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.savebtn.Location = new System.Drawing.Point(1198, 568);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(118, 37);
            this.savebtn.TabIndex = 46;
            this.savebtn.Text = "SAVE && PRINT";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 37);
            this.panel1.TabIndex = 51;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1326, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "PURCHASE ORDER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currencyidlbl
            // 
            this.currencyidlbl.AutoSize = true;
            this.currencyidlbl.Location = new System.Drawing.Point(533, 582);
            this.currencyidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencyidlbl.Name = "currencyidlbl";
            this.currencyidlbl.Size = new System.Drawing.Size(66, 13);
            this.currencyidlbl.TabIndex = 166;
            this.currencyidlbl.Text = "currencyidlbl";
            this.currencyidlbl.Visible = false;
            // 
            // currencylbl
            // 
            this.currencylbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencylbl.AutoSize = true;
            this.currencylbl.Location = new System.Drawing.Point(951, 159);
            this.currencylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencylbl.Name = "currencylbl";
            this.currencylbl.Size = new System.Drawing.Size(98, 13);
            this.currencylbl.TabIndex = 165;
            this.currencylbl.Text = "CURRENCY : AED";
            // 
            // removevatchkbox
            // 
            this.removevatchkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removevatchkbox.AutoSize = true;
            this.removevatchkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removevatchkbox.Location = new System.Drawing.Point(1188, 155);
            this.removevatchkbox.Margin = new System.Windows.Forms.Padding(2);
            this.removevatchkbox.Name = "removevatchkbox";
            this.removevatchkbox.Size = new System.Drawing.Size(127, 21);
            this.removevatchkbox.TabIndex = 164;
            this.removevatchkbox.Text = "REMOVE VAT";
            this.removevatchkbox.UseVisualStyleBackColor = true;
            // 
            // nettotaltxtbox
            // 
            this.nettotaltxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nettotaltxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nettotaltxtbox.Enabled = false;
            this.nettotaltxtbox.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nettotaltxtbox.Location = new System.Drawing.Point(1033, 39);
            this.nettotaltxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.nettotaltxtbox.Name = "nettotaltxtbox";
            this.nettotaltxtbox.ReadOnly = true;
            this.nettotaltxtbox.Size = new System.Drawing.Size(284, 56);
            this.nettotaltxtbox.TabIndex = 163;
            this.nettotaltxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalvattxtbox
            // 
            this.totalvattxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalvattxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalvattxtbox.Enabled = false;
            this.totalvattxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalvattxtbox.Location = new System.Drawing.Point(1033, 97);
            this.totalvattxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.totalvattxtbox.Name = "totalvattxtbox";
            this.totalvattxtbox.ReadOnly = true;
            this.totalvattxtbox.Size = new System.Drawing.Size(284, 27);
            this.totalvattxtbox.TabIndex = 162;
            this.totalvattxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totaldiscounttxtbox
            // 
            this.totaldiscounttxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldiscounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totaldiscounttxtbox.Enabled = false;
            this.totaldiscounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldiscounttxtbox.Location = new System.Drawing.Point(1033, 124);
            this.totaldiscounttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.totaldiscounttxtbox.Name = "totaldiscounttxtbox";
            this.totaldiscounttxtbox.ReadOnly = true;
            this.totaldiscounttxtbox.Size = new System.Drawing.Size(284, 27);
            this.totaldiscounttxtbox.TabIndex = 161;
            this.totaldiscounttxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totaldiscountlbl
            // 
            this.totaldiscountlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldiscountlbl.AutoSize = true;
            this.totaldiscountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldiscountlbl.Location = new System.Drawing.Point(951, 132);
            this.totaldiscountlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totaldiscountlbl.Name = "totaldiscountlbl";
            this.totaldiscountlbl.Size = new System.Drawing.Size(80, 13);
            this.totaldiscountlbl.TabIndex = 160;
            this.totaldiscountlbl.Text = "TOTAL DISS";
            // 
            // totalvatlbl
            // 
            this.totalvatlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalvatlbl.AutoSize = true;
            this.totalvatlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalvatlbl.Location = new System.Drawing.Point(951, 105);
            this.totalvatlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalvatlbl.Name = "totalvatlbl";
            this.totalvatlbl.Size = new System.Drawing.Size(75, 13);
            this.totalvatlbl.TabIndex = 159;
            this.totalvatlbl.Text = "TOTAL VAT";
            // 
            // nettotallbl
            // 
            this.nettotallbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nettotallbl.AutoSize = true;
            this.nettotallbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nettotallbl.Location = new System.Drawing.Point(951, 59);
            this.nettotallbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nettotallbl.Name = "nettotallbl";
            this.nettotallbl.Size = new System.Drawing.Size(73, 18);
            this.nettotallbl.TabIndex = 158;
            this.nettotallbl.Text = "NET TOTAL";
            // 
            // addvatchkbox
            // 
            this.addvatchkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addvatchkbox.AutoSize = true;
            this.addvatchkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addvatchkbox.Location = new System.Drawing.Point(898, 577);
            this.addvatchkbox.Margin = new System.Windows.Forms.Padding(2);
            this.addvatchkbox.Name = "addvatchkbox";
            this.addvatchkbox.Size = new System.Drawing.Size(133, 21);
            this.addvatchkbox.TabIndex = 167;
            this.addvatchkbox.Text = "ADD VAT (5%)";
            this.addvatchkbox.UseVisualStyleBackColor = true;
            this.addvatchkbox.Visible = false;
            // 
            // availabilitystatuslbl
            // 
            this.availabilitystatuslbl.AutoSize = true;
            this.availabilitystatuslbl.Location = new System.Drawing.Point(737, 582);
            this.availabilitystatuslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.availabilitystatuslbl.Name = "availabilitystatuslbl";
            this.availabilitystatuslbl.Size = new System.Drawing.Size(93, 13);
            this.availabilitystatuslbl.TabIndex = 168;
            this.availabilitystatuslbl.Text = "availabilitystatuslbl";
            this.availabilitystatuslbl.Visible = false;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(352, 581);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 169;
            this.warehouseidlbl.Text = "warehouseidlbl";
            this.warehouseidlbl.Visible = false;
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1326, 609);
            this.Controls.Add(this.warehouseidlbl);
            this.Controls.Add(this.availabilitystatuslbl);
            this.Controls.Add(this.addvatchkbox);
            this.Controls.Add(this.currencyidlbl);
            this.Controls.Add(this.currencylbl);
            this.Controls.Add(this.removevatchkbox);
            this.Controls.Add(this.currencysymbollbl);
            this.Controls.Add(this.currencynamelbl);
            this.Controls.Add(this.currencyconversionratelbl);
            this.Controls.Add(this.nettotaltxtbox);
            this.Controls.Add(this.totalvattxtbox);
            this.Controls.Add(this.totaldiscounttxtbox);
            this.Controls.Add(this.totaldiscountlbl);
            this.Controls.Add(this.totalvatlbl);
            this.Controls.Add(this.nettotallbl);
            this.Controls.Add(this.invoicecodelbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.supplieridlbl);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.savebtn);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE ORDER INVOICE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseOrderInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseOrderInvoice_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.Label supplierlbl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvpurchaseproducts;
        private System.Windows.Forms.Label qtylbl;
        private System.Windows.Forms.Label productnamelbl;
        private System.Windows.Forms.TextBox mfrtxtbox;
        private System.Windows.Forms.Label mfrlbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox codetxtbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private TextBox selectproducttxtbox;
        private TextBox selectsuppliertxtbox;
        private Label productidlbl;
        private Label supplieridlbl;
        private MaskedTextBox invoicedatetxtbox;
        private TextBox qtytxtbox;
        private Button addbtn;
        private Label invoicecodelbl;
        private TextBox companytxtbox;
        private Label companylbl;
        private Label pricepermeterlbl;
        private Label unitsalepricelbl;
        private Label itemdescriptionlbl;
        private Label unitidlbl;
        private Label unitnamelbl;
        private Label totalcolumnlbl;
        private Label lengthinmeterlbl;
        private Label productvatlbl;
        private Label currencynamelbl;
        private Label currencysymbollbl;
        private Label currencyconversionratelbl;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem eDITToolStripMenuItem;
        private Label currencyidlbl;
        private Label currencylbl;
        private CheckBox removevatchkbox;
        private TextBox nettotaltxtbox;
        private TextBox totalvattxtbox;
        private TextBox totaldiscounttxtbox;
        private Label totaldiscountlbl;
        private Label totalvatlbl;
        private Label nettotallbl;
        private Label productdiscountlbl;
        private Label vatcodelbl;
        private Label discountpercentagelbl;
        private Label discounttypelbl;
        private CheckBox addvatchkbox;
        private DataGridViewTextBoxColumn srnocolumn;
        private DataGridViewTextBoxColumn codecolumn;
        private DataGridViewTextBoxColumn productid;
        private DataGridViewTextBoxColumn productnamecolumn;
        private DataGridViewTextBoxColumn qtycolumn;
        private DataGridViewTextBoxColumn availabilitycolumn;
        private DataGridViewTextBoxColumn unitidcolumn;
        private DataGridViewTextBoxColumn unitname;
        private DataGridViewTextBoxColumn pricecolumn;
        private DataGridViewTextBoxColumn vatcolumn;
        private DataGridViewTextBoxColumn discountcolumn;
        private DataGridViewTextBoxColumn totalcolumn;
        private DataGridViewTextBoxColumn warehouseidcolumn;
        private DataGridViewTextBoxColumn itemdescriptioncolumn;
        private DataGridViewTextBoxColumn lengthinmetercolumn;
        private DataGridViewTextBoxColumn pricepermetercolumn;
        private DataGridViewTextBoxColumn vatpercentagecolumn;
        private DataGridViewTextBoxColumn discountpercentagecolumn;
        private DataGridViewTextBoxColumn discounttypecolumn;
        private Label availabilitystatuslbl;
        private Label warehouseidlbl;
    }
}