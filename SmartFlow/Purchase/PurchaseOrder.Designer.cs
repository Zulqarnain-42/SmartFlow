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
            this.mfrcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtycolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdescriptioncolummn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricepermetercolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthinmetercolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.mfrlbl = new System.Windows.Forms.Label();
            this.mfrtxtbox = new System.Windows.Forms.TextBox();
            this.qtylbl = new System.Windows.Forms.Label();
            this.productnamelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currencyconversionratelbl = new System.Windows.Forms.Label();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencystringlbl = new System.Windows.Forms.Label();
            this.productvatlbl = new System.Windows.Forms.Label();
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.unitidlbl = new System.Windows.Forms.Label();
            this.unitnamelbl = new System.Windows.Forms.Label();
            this.totalcolumnlbl = new System.Windows.Forms.Label();
            this.lengthinmeterlbl = new System.Windows.Forms.Label();
            this.pricepermeterlbl = new System.Windows.Forms.Label();
            this.unitsalepricelbl = new System.Windows.Forms.Label();
            this.itemdescriptionlbl = new System.Windows.Forms.Label();
            this.companytxtbox = new System.Windows.Forms.TextBox();
            this.companylbl = new System.Windows.Forms.Label();
            this.invoicecodelbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.supplieridlbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.selectsuppliertxtbox = new System.Windows.Forms.TextBox();
            this.codetxtbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.nettotallbl = new System.Windows.Forms.Label();
            this.nettotaltxtbox = new System.Windows.Forms.TextBox();
            this.removevatchkbox = new System.Windows.Forms.CheckBox();
            this.totalvattxtbox = new System.Windows.Forms.TextBox();
            this.totalvatlbl = new System.Windows.Forms.Label();
            this.currencyidlbl = new System.Windows.Forms.Label();
            this.currencylbl = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseproducts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // newbtn
            // 
            this.newbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.newbtn.Location = new System.Drawing.Point(1434, 699);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(158, 46);
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
            this.invoicenotxtbox.Location = new System.Drawing.Point(121, 4);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.ReadOnly = true;
            this.invoicenotxtbox.Size = new System.Drawing.Size(167, 32);
            this.invoicenotxtbox.TabIndex = 0;
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(291, 9);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(50, 23);
            this.datelbl.TabIndex = 4;
            this.datelbl.Text = "Date ";
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(12, 42);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(77, 23);
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
            this.tabControl1.Location = new System.Drawing.Point(12, 211);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1744, 482);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1736, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Product Detail";
            // 
            // addbtn
            // 
            this.addbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addbtn.Location = new System.Drawing.Point(1605, 35);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(112, 32);
            this.addbtn.TabIndex = 31;
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
            this.mfrcolumn,
            this.productidcolumn,
            this.productnamecolumn,
            this.qtycolumn,
            this.unitidcolumn,
            this.unitnamecolumn,
            this.pricecolumn,
            this.vatcolumn,
            this.totalcolumn,
            this.itemdescriptioncolummn,
            this.pricepermetercolumn,
            this.lengthinmetercolumn});
            this.dgvpurchaseproducts.ContextMenuStrip = this.contextMenuStrip;
            this.dgvpurchaseproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvpurchaseproducts.Location = new System.Drawing.Point(6, 73);
            this.dgvpurchaseproducts.Name = "dgvpurchaseproducts";
            this.dgvpurchaseproducts.ReadOnly = true;
            this.dgvpurchaseproducts.RowHeadersVisible = false;
            this.dgvpurchaseproducts.RowHeadersWidth = 51;
            this.dgvpurchaseproducts.RowTemplate.Height = 24;
            this.dgvpurchaseproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpurchaseproducts.Size = new System.Drawing.Size(1724, 368);
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
            // mfrcolumn
            // 
            this.mfrcolumn.HeaderText = "MFR";
            this.mfrcolumn.MinimumWidth = 6;
            this.mfrcolumn.Name = "mfrcolumn";
            this.mfrcolumn.ReadOnly = true;
            this.mfrcolumn.Width = 125;
            // 
            // productidcolumn
            // 
            this.productidcolumn.HeaderText = "ID";
            this.productidcolumn.MinimumWidth = 6;
            this.productidcolumn.Name = "productidcolumn";
            this.productidcolumn.ReadOnly = true;
            this.productidcolumn.Visible = false;
            this.productidcolumn.Width = 125;
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
            // unitidcolumn
            // 
            this.unitidcolumn.HeaderText = "unitid";
            this.unitidcolumn.MinimumWidth = 6;
            this.unitidcolumn.Name = "unitidcolumn";
            this.unitidcolumn.ReadOnly = true;
            this.unitidcolumn.Visible = false;
            this.unitidcolumn.Width = 125;
            // 
            // unitnamecolumn
            // 
            this.unitnamecolumn.HeaderText = "UNIT";
            this.unitnamecolumn.MinimumWidth = 6;
            this.unitnamecolumn.Name = "unitnamecolumn";
            this.unitnamecolumn.ReadOnly = true;
            this.unitnamecolumn.Width = 125;
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
            // totalcolumn
            // 
            this.totalcolumn.HeaderText = "Total";
            this.totalcolumn.MinimumWidth = 6;
            this.totalcolumn.Name = "totalcolumn";
            this.totalcolumn.ReadOnly = true;
            this.totalcolumn.Width = 125;
            // 
            // itemdescriptioncolummn
            // 
            this.itemdescriptioncolummn.HeaderText = "itemdescription";
            this.itemdescriptioncolummn.MinimumWidth = 6;
            this.itemdescriptioncolummn.Name = "itemdescriptioncolummn";
            this.itemdescriptioncolummn.ReadOnly = true;
            this.itemdescriptioncolummn.Visible = false;
            this.itemdescriptioncolummn.Width = 125;
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
            // lengthinmetercolumn
            // 
            this.lengthinmetercolumn.HeaderText = "lengthinmeter";
            this.lengthinmetercolumn.MinimumWidth = 6;
            this.lengthinmetercolumn.Name = "lengthinmetercolumn";
            this.lengthinmetercolumn.ReadOnly = true;
            this.lengthinmetercolumn.Visible = false;
            this.lengthinmetercolumn.Width = 125;
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F);
            this.qtytxtbox.Location = new System.Drawing.Point(612, 36);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(154, 32);
            this.qtytxtbox.TabIndex = 29;
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
            this.selectproducttxtbox.Location = new System.Drawing.Point(201, 36);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.ReadOnly = true;
            this.selectproducttxtbox.Size = new System.Drawing.Size(405, 32);
            this.selectproducttxtbox.TabIndex = 0;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // mfrlbl
            // 
            this.mfrlbl.AutoSize = true;
            this.mfrlbl.Location = new System.Drawing.Point(13, 9);
            this.mfrlbl.Name = "mfrlbl";
            this.mfrlbl.Size = new System.Drawing.Size(45, 23);
            this.mfrlbl.TabIndex = 0;
            this.mfrlbl.Text = "MFR";
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mfrtxtbox.Enabled = false;
            this.mfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfrtxtbox.Location = new System.Drawing.Point(14, 36);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.ReadOnly = true;
            this.mfrtxtbox.Size = new System.Drawing.Size(181, 32);
            this.mfrtxtbox.TabIndex = 4;
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
            // productnamelbl
            // 
            this.productnamelbl.AutoSize = true;
            this.productnamelbl.Location = new System.Drawing.Point(201, 9);
            this.productnamelbl.Name = "productnamelbl";
            this.productnamelbl.Size = new System.Drawing.Size(120, 23);
            this.productnamelbl.TabIndex = 2;
            this.productnamelbl.Text = "Product Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.currencyconversionratelbl);
            this.panel2.Controls.Add(this.currencynamelbl);
            this.panel2.Controls.Add(this.currencystringlbl);
            this.panel2.Controls.Add(this.productvatlbl);
            this.panel2.Controls.Add(this.currencysymbollbl);
            this.panel2.Controls.Add(this.unitidlbl);
            this.panel2.Controls.Add(this.unitnamelbl);
            this.panel2.Controls.Add(this.totalcolumnlbl);
            this.panel2.Controls.Add(this.lengthinmeterlbl);
            this.panel2.Controls.Add(this.pricepermeterlbl);
            this.panel2.Controls.Add(this.unitsalepricelbl);
            this.panel2.Controls.Add(this.itemdescriptionlbl);
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
            this.panel2.Location = new System.Drawing.Point(12, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1251, 157);
            this.panel2.TabIndex = 45;
            // 
            // currencyconversionratelbl
            // 
            this.currencyconversionratelbl.AutoSize = true;
            this.currencyconversionratelbl.Location = new System.Drawing.Point(803, 134);
            this.currencyconversionratelbl.Name = "currencyconversionratelbl";
            this.currencyconversionratelbl.Size = new System.Drawing.Size(161, 16);
            this.currencyconversionratelbl.TabIndex = 163;
            this.currencyconversionratelbl.Text = "currencyconversionratelbl";
            this.currencyconversionratelbl.Visible = false;
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Location = new System.Drawing.Point(999, 132);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(106, 16);
            this.currencynamelbl.TabIndex = 165;
            this.currencynamelbl.Text = "currencynamelbl";
            this.currencynamelbl.Visible = false;
            // 
            // currencystringlbl
            // 
            this.currencystringlbl.AutoSize = true;
            this.currencystringlbl.Location = new System.Drawing.Point(1129, 120);
            this.currencystringlbl.Name = "currencystringlbl";
            this.currencystringlbl.Size = new System.Drawing.Size(104, 16);
            this.currencystringlbl.TabIndex = 164;
            this.currencystringlbl.Text = "currencystringlbl";
            this.currencystringlbl.Visible = false;
            // 
            // productvatlbl
            // 
            this.productvatlbl.AutoSize = true;
            this.productvatlbl.Location = new System.Drawing.Point(1150, 75);
            this.productvatlbl.Name = "productvatlbl";
            this.productvatlbl.Size = new System.Drawing.Size(84, 16);
            this.productvatlbl.TabIndex = 159;
            this.productvatlbl.Text = "productvatlbl";
            this.productvatlbl.Visible = false;
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Location = new System.Drawing.Point(1129, 99);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(116, 16);
            this.currencysymbollbl.TabIndex = 163;
            this.currencysymbollbl.Text = "currencysymbollbl";
            this.currencysymbollbl.Visible = false;
            // 
            // unitidlbl
            // 
            this.unitidlbl.AutoSize = true;
            this.unitidlbl.Location = new System.Drawing.Point(994, 115);
            this.unitidlbl.Name = "unitidlbl";
            this.unitidlbl.Size = new System.Drawing.Size(52, 16);
            this.unitidlbl.TabIndex = 158;
            this.unitidlbl.Text = "unitidlbl";
            this.unitidlbl.Visible = false;
            // 
            // unitnamelbl
            // 
            this.unitnamelbl.AutoSize = true;
            this.unitnamelbl.Location = new System.Drawing.Point(994, 99);
            this.unitnamelbl.Name = "unitnamelbl";
            this.unitnamelbl.Size = new System.Drawing.Size(75, 16);
            this.unitnamelbl.TabIndex = 157;
            this.unitnamelbl.Text = "unitnamelbl";
            this.unitnamelbl.Visible = false;
            // 
            // totalcolumnlbl
            // 
            this.totalcolumnlbl.AutoSize = true;
            this.totalcolumnlbl.Location = new System.Drawing.Point(993, 82);
            this.totalcolumnlbl.Name = "totalcolumnlbl";
            this.totalcolumnlbl.Size = new System.Drawing.Size(89, 16);
            this.totalcolumnlbl.TabIndex = 156;
            this.totalcolumnlbl.Text = "totalcolumnlbl";
            this.totalcolumnlbl.Visible = false;
            // 
            // lengthinmeterlbl
            // 
            this.lengthinmeterlbl.AutoSize = true;
            this.lengthinmeterlbl.Location = new System.Drawing.Point(994, 66);
            this.lengthinmeterlbl.Name = "lengthinmeterlbl";
            this.lengthinmeterlbl.Size = new System.Drawing.Size(101, 16);
            this.lengthinmeterlbl.TabIndex = 155;
            this.lengthinmeterlbl.Text = "lengthinmeterlbl";
            this.lengthinmeterlbl.Visible = false;
            // 
            // pricepermeterlbl
            // 
            this.pricepermeterlbl.AutoSize = true;
            this.pricepermeterlbl.Location = new System.Drawing.Point(994, 50);
            this.pricepermeterlbl.Name = "pricepermeterlbl";
            this.pricepermeterlbl.Size = new System.Drawing.Size(105, 16);
            this.pricepermeterlbl.TabIndex = 154;
            this.pricepermeterlbl.Text = "pricepermeterlbl";
            this.pricepermeterlbl.Visible = false;
            // 
            // unitsalepricelbl
            // 
            this.unitsalepricelbl.AutoSize = true;
            this.unitsalepricelbl.Location = new System.Drawing.Point(994, 29);
            this.unitsalepricelbl.Name = "unitsalepricelbl";
            this.unitsalepricelbl.Size = new System.Drawing.Size(97, 16);
            this.unitsalepricelbl.TabIndex = 153;
            this.unitsalepricelbl.Text = "unitsalepricelbl";
            this.unitsalepricelbl.Visible = false;
            // 
            // itemdescriptionlbl
            // 
            this.itemdescriptionlbl.AutoSize = true;
            this.itemdescriptionlbl.Location = new System.Drawing.Point(993, 9);
            this.itemdescriptionlbl.Name = "itemdescriptionlbl";
            this.itemdescriptionlbl.Size = new System.Drawing.Size(112, 16);
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
            this.companytxtbox.Location = new System.Drawing.Point(121, 99);
            this.companytxtbox.Name = "companytxtbox";
            this.companytxtbox.Size = new System.Drawing.Size(866, 32);
            this.companytxtbox.TabIndex = 151;
            // 
            // companylbl
            // 
            this.companylbl.AutoSize = true;
            this.companylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companylbl.Location = new System.Drawing.Point(14, 102);
            this.companylbl.Name = "companylbl";
            this.companylbl.Size = new System.Drawing.Size(83, 23);
            this.companylbl.TabIndex = 150;
            this.companylbl.Text = "Company";
            // 
            // invoicecodelbl
            // 
            this.invoicecodelbl.AutoSize = true;
            this.invoicecodelbl.Location = new System.Drawing.Point(1150, 53);
            this.invoicecodelbl.Name = "invoicecodelbl";
            this.invoicecodelbl.Size = new System.Drawing.Size(95, 16);
            this.invoicecodelbl.TabIndex = 114;
            this.invoicecodelbl.Text = "invoicecodelbl";
            this.invoicecodelbl.Visible = false;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(396, 4);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(591, 32);
            this.invoicedatetxtbox.TabIndex = 113;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // supplieridlbl
            // 
            this.supplieridlbl.AutoSize = true;
            this.supplieridlbl.Location = new System.Drawing.Point(1150, 4);
            this.supplieridlbl.Name = "supplieridlbl";
            this.supplieridlbl.Size = new System.Drawing.Size(66, 16);
            this.supplieridlbl.TabIndex = 68;
            this.supplieridlbl.Text = "supplierid";
            this.supplieridlbl.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(1150, 26);
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
            this.selectsuppliertxtbox.Location = new System.Drawing.Point(295, 42);
            this.selectsuppliertxtbox.Name = "selectsuppliertxtbox";
            this.selectsuppliertxtbox.ReadOnly = true;
            this.selectsuppliertxtbox.Size = new System.Drawing.Size(693, 32);
            this.selectsuppliertxtbox.TabIndex = 2;
            this.selectsuppliertxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectsuppliertxtbox_MouseClick);
            this.selectsuppliertxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectsuppliertxtbox_KeyDown);
            // 
            // codetxtbox
            // 
            this.codetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codetxtbox.Enabled = false;
            this.codetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codetxtbox.Location = new System.Drawing.Point(122, 42);
            this.codetxtbox.Name = "codetxtbox";
            this.codetxtbox.ReadOnly = true;
            this.codetxtbox.Size = new System.Drawing.Size(167, 32);
            this.codetxtbox.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(11, 9);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(96, 23);
            this.invoicenolbl.TabIndex = 0;
            this.invoicenolbl.Text = "Inovice No ";
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
            this.savebtn.Location = new System.Drawing.Point(1598, 699);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(158, 46);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1768, 45);
            this.panel1.TabIndex = 51;
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
            this.headinglbl.Text = "PURCHASE ORDER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nettotallbl
            // 
            this.nettotallbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nettotallbl.AutoSize = true;
            this.nettotallbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nettotallbl.Location = new System.Drawing.Point(1268, 70);
            this.nettotallbl.Name = "nettotallbl";
            this.nettotallbl.Size = new System.Drawing.Size(94, 23);
            this.nettotallbl.TabIndex = 128;
            this.nettotallbl.Text = "NET TOTAL";
            // 
            // nettotaltxtbox
            // 
            this.nettotaltxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nettotaltxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nettotaltxtbox.Enabled = false;
            this.nettotaltxtbox.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nettotaltxtbox.Location = new System.Drawing.Point(1378, 48);
            this.nettotaltxtbox.Name = "nettotaltxtbox";
            this.nettotaltxtbox.ReadOnly = true;
            this.nettotaltxtbox.Size = new System.Drawing.Size(378, 69);
            this.nettotaltxtbox.TabIndex = 149;
            this.nettotaltxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // removevatchkbox
            // 
            this.removevatchkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removevatchkbox.AutoSize = true;
            this.removevatchkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removevatchkbox.Location = new System.Drawing.Point(1378, 160);
            this.removevatchkbox.Name = "removevatchkbox";
            this.removevatchkbox.Size = new System.Drawing.Size(150, 24);
            this.removevatchkbox.TabIndex = 155;
            this.removevatchkbox.Text = "REMOVE VAT";
            this.removevatchkbox.UseVisualStyleBackColor = true;
            this.removevatchkbox.CheckedChanged += new System.EventHandler(this.removevatchkbox_CheckedChanged);
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
            this.totalvattxtbox.ReadOnly = true;
            this.totalvattxtbox.Size = new System.Drawing.Size(378, 32);
            this.totalvattxtbox.TabIndex = 157;
            this.totalvattxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalvatlbl
            // 
            this.totalvatlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalvatlbl.AutoSize = true;
            this.totalvatlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalvatlbl.Location = new System.Drawing.Point(1269, 132);
            this.totalvatlbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.totalvatlbl.Name = "totalvatlbl";
            this.totalvatlbl.Size = new System.Drawing.Size(90, 16);
            this.totalvatlbl.TabIndex = 156;
            this.totalvatlbl.Text = "TOTAL VAT";
            // 
            // currencyidlbl
            // 
            this.currencyidlbl.AutoSize = true;
            this.currencyidlbl.Location = new System.Drawing.Point(1639, 180);
            this.currencyidlbl.Name = "currencyidlbl";
            this.currencyidlbl.Size = new System.Drawing.Size(83, 16);
            this.currencyidlbl.TabIndex = 162;
            this.currencyidlbl.Text = "currencyidlbl";
            this.currencyidlbl.Visible = false;
            // 
            // currencylbl
            // 
            this.currencylbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencylbl.AutoSize = true;
            this.currencylbl.Location = new System.Drawing.Point(1636, 160);
            this.currencylbl.Name = "currencylbl";
            this.currencylbl.Size = new System.Drawing.Size(120, 16);
            this.currencylbl.TabIndex = 161;
            this.currencylbl.Text = "CURRENCY : AED";
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
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1768, 750);
            this.Controls.Add(this.currencyidlbl);
            this.Controls.Add(this.currencylbl);
            this.Controls.Add(this.totalvattxtbox);
            this.Controls.Add(this.totalvatlbl);
            this.Controls.Add(this.removevatchkbox);
            this.Controls.Add(this.nettotaltxtbox);
            this.Controls.Add(this.nettotallbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.savebtn);
            this.KeyPreview = true;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
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
        private Label nettotallbl;
        private TextBox qtytxtbox;
        private TextBox nettotaltxtbox;
        private Button addbtn;
        private Label invoicecodelbl;
        private TextBox companytxtbox;
        private Label companylbl;
        private CheckBox removevatchkbox;
        private Label pricepermeterlbl;
        private Label unitsalepricelbl;
        private Label itemdescriptionlbl;
        private Label unitidlbl;
        private Label unitnamelbl;
        private Label totalcolumnlbl;
        private Label lengthinmeterlbl;
        private Label productvatlbl;
        private TextBox totalvattxtbox;
        private Label totalvatlbl;
        private Label currencynamelbl;
        private Label currencystringlbl;
        private Label currencysymbollbl;
        private Label currencyidlbl;
        private Label currencylbl;
        private Label currencyconversionratelbl;
        private DataGridViewTextBoxColumn srnocolumn;
        private DataGridViewTextBoxColumn mfrcolumn;
        private DataGridViewTextBoxColumn productidcolumn;
        private DataGridViewTextBoxColumn productnamecolumn;
        private DataGridViewTextBoxColumn qtycolumn;
        private DataGridViewTextBoxColumn unitidcolumn;
        private DataGridViewTextBoxColumn unitnamecolumn;
        private DataGridViewTextBoxColumn pricecolumn;
        private DataGridViewTextBoxColumn vatcolumn;
        private DataGridViewTextBoxColumn totalcolumn;
        private DataGridViewTextBoxColumn itemdescriptioncolummn;
        private DataGridViewTextBoxColumn pricepermetercolumn;
        private DataGridViewTextBoxColumn lengthinmetercolumn;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem eDITToolStripMenuItem;
    }
}