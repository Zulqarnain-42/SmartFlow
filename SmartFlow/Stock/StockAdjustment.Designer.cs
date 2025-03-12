namespace SmartFlow.Stock
{
    partial class StockAdjustment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addchkbox = new System.Windows.Forms.CheckBox();
            this.selectitemqtytxtbox = new System.Windows.Forms.TextBox();
            this.openboxproductqtylbl = new System.Windows.Forms.Label();
            this.selectwarehousefromtxtbox = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.qtytextbox = new System.Windows.Forms.TextBox();
            this.qtylbl = new System.Windows.Forms.Label();
            this.openboxproducttxtbox = new System.Windows.Forms.TextBox();
            this.addedproductmfrtxtbox = new System.Windows.Forms.TextBox();
            this.remainingboxproductlbl = new System.Windows.Forms.Label();
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.warehousefromlbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectedproductmfrlbl = new System.Windows.Forms.Label();
            this.minusitempricelbl = new System.Windows.Forms.Label();
            this.minusitemproductmfrlbl = new System.Windows.Forms.Label();
            this.minusitembarcodelbl = new System.Windows.Forms.Label();
            this.minusitemupclbl = new System.Windows.Forms.Label();
            this.minusitemnamelbl = new System.Windows.Forms.Label();
            this.minusitemidlbl = new System.Windows.Forms.Label();
            this.selecteditembarcodelbl = new System.Windows.Forms.Label();
            this.selecteditemupclbl = new System.Windows.Forms.Label();
            this.selecteditemnamelbl = new System.Windows.Forms.Label();
            this.selecteditemidlbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.dgvproducts = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.selecteditempricelbl = new System.Windows.Forms.Label();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productupc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 37);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1196, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "STOCK ADJUSTMENT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addchkbox);
            this.panel2.Controls.Add(this.selectitemqtytxtbox);
            this.panel2.Controls.Add(this.openboxproductqtylbl);
            this.panel2.Controls.Add(this.selectwarehousefromtxtbox);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.qtytextbox);
            this.panel2.Controls.Add(this.qtylbl);
            this.panel2.Controls.Add(this.openboxproducttxtbox);
            this.panel2.Controls.Add(this.addedproductmfrtxtbox);
            this.panel2.Controls.Add(this.remainingboxproductlbl);
            this.panel2.Controls.Add(this.selectproductlbl);
            this.panel2.Controls.Add(this.warehousefromlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 104);
            this.panel2.TabIndex = 2;
            // 
            // addchkbox
            // 
            this.addchkbox.AutoSize = true;
            this.addchkbox.Location = new System.Drawing.Point(477, 73);
            this.addchkbox.Name = "addchkbox";
            this.addchkbox.Size = new System.Drawing.Size(137, 17);
            this.addchkbox.TabIndex = 36;
            this.addchkbox.Text = "ADD SELECTED ITEM";
            this.addchkbox.UseVisualStyleBackColor = true;
            // 
            // selectitemqtytxtbox
            // 
            this.selectitemqtytxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectitemqtytxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectitemqtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectitemqtytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectitemqtytxtbox.Location = new System.Drawing.Point(190, 67);
            this.selectitemqtytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectitemqtytxtbox.Name = "selectitemqtytxtbox";
            this.selectitemqtytxtbox.Size = new System.Drawing.Size(270, 27);
            this.selectitemqtytxtbox.TabIndex = 34;
            // 
            // openboxproductqtylbl
            // 
            this.openboxproductqtylbl.AutoSize = true;
            this.openboxproductqtylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openboxproductqtylbl.Location = new System.Drawing.Point(8, 71);
            this.openboxproductqtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductqtylbl.Name = "openboxproductqtylbl";
            this.openboxproductqtylbl.Size = new System.Drawing.Size(133, 18);
            this.openboxproductqtylbl.TabIndex = 35;
            this.openboxproductqtylbl.Text = "PRODUCT QUANTITY";
            // 
            // selectwarehousefromtxtbox
            // 
            this.selectwarehousefromtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousefromtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousefromtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousefromtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousefromtxtbox.Location = new System.Drawing.Point(190, 5);
            this.selectwarehousefromtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectwarehousefromtxtbox.Name = "selectwarehousefromtxtbox";
            this.selectwarehousefromtxtbox.Size = new System.Drawing.Size(270, 27);
            this.selectwarehousefromtxtbox.TabIndex = 0;
            this.selectwarehousefromtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousefromtxtbox_MouseClick);
            // 
            // addbtn
            // 
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.Location = new System.Drawing.Point(1101, 5);
            this.addbtn.Margin = new System.Windows.Forms.Padding(2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(79, 57);
            this.addbtn.TabIndex = 4;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // qtytextbox
            // 
            this.qtytextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytextbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtytextbox.Location = new System.Drawing.Point(807, 36);
            this.qtytextbox.Margin = new System.Windows.Forms.Padding(2);
            this.qtytextbox.Name = "qtytextbox";
            this.qtytextbox.Size = new System.Drawing.Size(270, 27);
            this.qtytextbox.TabIndex = 3;
            // 
            // qtylbl
            // 
            this.qtylbl.AutoSize = true;
            this.qtylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtylbl.Location = new System.Drawing.Point(538, 40);
            this.qtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qtylbl.Name = "qtylbl";
            this.qtylbl.Size = new System.Drawing.Size(189, 18);
            this.qtylbl.TabIndex = 33;
            this.qtylbl.Text = "ADDED QUANTITY IN THE BOX";
            // 
            // openboxproducttxtbox
            // 
            this.openboxproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.openboxproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.openboxproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openboxproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openboxproducttxtbox.Location = new System.Drawing.Point(190, 36);
            this.openboxproducttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.openboxproducttxtbox.Name = "openboxproducttxtbox";
            this.openboxproducttxtbox.Size = new System.Drawing.Size(270, 27);
            this.openboxproducttxtbox.TabIndex = 1;
            this.openboxproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openboxproducttxtbox_MouseClick);
            // 
            // addedproductmfrtxtbox
            // 
            this.addedproductmfrtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addedproductmfrtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.addedproductmfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addedproductmfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addedproductmfrtxtbox.Location = new System.Drawing.Point(807, 5);
            this.addedproductmfrtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.addedproductmfrtxtbox.Name = "addedproductmfrtxtbox";
            this.addedproductmfrtxtbox.Size = new System.Drawing.Size(270, 27);
            this.addedproductmfrtxtbox.TabIndex = 2;
            this.addedproductmfrtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addedproductmfrtxtbox_MouseClick);
            // 
            // remainingboxproductlbl
            // 
            this.remainingboxproductlbl.AutoSize = true;
            this.remainingboxproductlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingboxproductlbl.Location = new System.Drawing.Point(538, 9);
            this.remainingboxproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.remainingboxproductlbl.Name = "remainingboxproductlbl";
            this.remainingboxproductlbl.Size = new System.Drawing.Size(222, 18);
            this.remainingboxproductlbl.TabIndex = 23;
            this.remainingboxproductlbl.Text = "ADDED IN THE BOX PRODUCTS MFR";
            // 
            // selectproductlbl
            // 
            this.selectproductlbl.AutoSize = true;
            this.selectproductlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproductlbl.Location = new System.Drawing.Point(8, 40);
            this.selectproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(112, 18);
            this.selectproductlbl.TabIndex = 21;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // warehousefromlbl
            // 
            this.warehousefromlbl.AutoSize = true;
            this.warehousefromlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehousefromlbl.Location = new System.Drawing.Point(8, 9);
            this.warehousefromlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehousefromlbl.Name = "warehousefromlbl";
            this.warehousefromlbl.Size = new System.Drawing.Size(126, 18);
            this.warehousefromlbl.TabIndex = 17;
            this.warehousefromlbl.Text = "WAREHOUSE FROM";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.selecteditempricelbl);
            this.panel3.Controls.Add(this.invoicenolbl);
            this.panel3.Controls.Add(this.selectedproductmfrlbl);
            this.panel3.Controls.Add(this.minusitempricelbl);
            this.panel3.Controls.Add(this.minusitemproductmfrlbl);
            this.panel3.Controls.Add(this.minusitembarcodelbl);
            this.panel3.Controls.Add(this.minusitemupclbl);
            this.panel3.Controls.Add(this.minusitemnamelbl);
            this.panel3.Controls.Add(this.minusitemidlbl);
            this.panel3.Controls.Add(this.selecteditembarcodelbl);
            this.panel3.Controls.Add(this.selecteditemupclbl);
            this.panel3.Controls.Add(this.selecteditemnamelbl);
            this.panel3.Controls.Add(this.selecteditemidlbl);
            this.panel3.Controls.Add(this.warehouseidlbl);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.descriptionlbl);
            this.panel3.Controls.Add(this.dgvproducts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 141);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1196, 485);
            this.panel3.TabIndex = 3;
            // 
            // selectedproductmfrlbl
            // 
            this.selectedproductmfrlbl.AutoSize = true;
            this.selectedproductmfrlbl.Location = new System.Drawing.Point(972, 249);
            this.selectedproductmfrlbl.Name = "selectedproductmfrlbl";
            this.selectedproductmfrlbl.Size = new System.Drawing.Size(107, 13);
            this.selectedproductmfrlbl.TabIndex = 50;
            this.selectedproductmfrlbl.Text = "selectedproductmfrlbl";
            this.selectedproductmfrlbl.Visible = false;
            // 
            // minusitempricelbl
            // 
            this.minusitempricelbl.AutoSize = true;
            this.minusitempricelbl.Location = new System.Drawing.Point(972, 314);
            this.minusitempricelbl.Name = "minusitempricelbl";
            this.minusitempricelbl.Size = new System.Drawing.Size(86, 13);
            this.minusitempricelbl.TabIndex = 49;
            this.minusitempricelbl.Text = "minusitempricelbl";
            this.minusitempricelbl.Visible = false;
            // 
            // minusitemproductmfrlbl
            // 
            this.minusitemproductmfrlbl.AutoSize = true;
            this.minusitemproductmfrlbl.Location = new System.Drawing.Point(972, 379);
            this.minusitemproductmfrlbl.Name = "minusitemproductmfrlbl";
            this.minusitemproductmfrlbl.Size = new System.Drawing.Size(113, 13);
            this.minusitemproductmfrlbl.TabIndex = 48;
            this.minusitemproductmfrlbl.Text = "minusitemproductmfrlbl";
            this.minusitemproductmfrlbl.Visible = false;
            // 
            // minusitembarcodelbl
            // 
            this.minusitembarcodelbl.AutoSize = true;
            this.minusitembarcodelbl.Location = new System.Drawing.Point(972, 366);
            this.minusitembarcodelbl.Name = "minusitembarcodelbl";
            this.minusitembarcodelbl.Size = new System.Drawing.Size(102, 13);
            this.minusitembarcodelbl.TabIndex = 47;
            this.minusitembarcodelbl.Text = "minusitembarcodelbl";
            this.minusitembarcodelbl.Visible = false;
            // 
            // minusitemupclbl
            // 
            this.minusitemupclbl.AutoSize = true;
            this.minusitemupclbl.Location = new System.Drawing.Point(972, 353);
            this.minusitemupclbl.Name = "minusitemupclbl";
            this.minusitemupclbl.Size = new System.Drawing.Size(81, 13);
            this.minusitemupclbl.TabIndex = 46;
            this.minusitemupclbl.Text = "minusitemupclbl";
            this.minusitemupclbl.Visible = false;
            // 
            // minusitemnamelbl
            // 
            this.minusitemnamelbl.AutoSize = true;
            this.minusitemnamelbl.Location = new System.Drawing.Point(972, 340);
            this.minusitemnamelbl.Name = "minusitemnamelbl";
            this.minusitemnamelbl.Size = new System.Drawing.Size(89, 13);
            this.minusitemnamelbl.TabIndex = 45;
            this.minusitemnamelbl.Text = "minusitemnamelbl";
            this.minusitemnamelbl.Visible = false;
            // 
            // minusitemidlbl
            // 
            this.minusitemidlbl.AutoSize = true;
            this.minusitemidlbl.Location = new System.Drawing.Point(972, 327);
            this.minusitemidlbl.Name = "minusitemidlbl";
            this.minusitemidlbl.Size = new System.Drawing.Size(71, 13);
            this.minusitemidlbl.TabIndex = 44;
            this.minusitemidlbl.Text = "minusitemidlbl";
            this.minusitemidlbl.Visible = false;
            // 
            // selecteditembarcodelbl
            // 
            this.selecteditembarcodelbl.AutoSize = true;
            this.selecteditembarcodelbl.Location = new System.Drawing.Point(969, 301);
            this.selecteditembarcodelbl.Name = "selecteditembarcodelbl";
            this.selecteditembarcodelbl.Size = new System.Drawing.Size(115, 13);
            this.selecteditembarcodelbl.TabIndex = 43;
            this.selecteditembarcodelbl.Text = "selecteditembarcodelbl";
            this.selecteditembarcodelbl.Visible = false;
            // 
            // selecteditemupclbl
            // 
            this.selecteditemupclbl.AutoSize = true;
            this.selecteditemupclbl.Location = new System.Drawing.Point(969, 288);
            this.selecteditemupclbl.Name = "selecteditemupclbl";
            this.selecteditemupclbl.Size = new System.Drawing.Size(94, 13);
            this.selecteditemupclbl.TabIndex = 42;
            this.selecteditemupclbl.Text = "selecteditemupclbl";
            this.selecteditemupclbl.Visible = false;
            // 
            // selecteditemnamelbl
            // 
            this.selecteditemnamelbl.AutoSize = true;
            this.selecteditemnamelbl.Location = new System.Drawing.Point(969, 275);
            this.selecteditemnamelbl.Name = "selecteditemnamelbl";
            this.selecteditemnamelbl.Size = new System.Drawing.Size(102, 13);
            this.selecteditemnamelbl.TabIndex = 41;
            this.selecteditemnamelbl.Text = "selecteditemnamelbl";
            this.selecteditemnamelbl.Visible = false;
            // 
            // selecteditemidlbl
            // 
            this.selecteditemidlbl.AutoSize = true;
            this.selecteditemidlbl.Location = new System.Drawing.Point(969, 262);
            this.selecteditemidlbl.Name = "selecteditemidlbl";
            this.selecteditemidlbl.Size = new System.Drawing.Size(84, 13);
            this.selecteditemidlbl.TabIndex = 40;
            this.selecteditemidlbl.Text = "selecteditemidlbl";
            this.selecteditemidlbl.Visible = false;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(969, 234);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 39;
            this.warehouseidlbl.Text = "warehouseidlbl";
            this.warehouseidlbl.Visible = false;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(969, 445);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(218, 37);
            this.closebtn.TabIndex = 38;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(969, 404);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(218, 37);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(969, 27);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(219, 201);
            this.descriptiontxtbox.TabIndex = 0;
            this.descriptiontxtbox.Text = "";
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(966, 6);
            this.descriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(90, 18);
            this.descriptionlbl.TabIndex = 13;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // dgvproducts
            // 
            this.dgvproducts.AllowUserToAddRows = false;
            this.dgvproducts.AllowUserToDeleteRows = false;
            this.dgvproducts.AllowUserToResizeColumns = false;
            this.dgvproducts.AllowUserToResizeRows = false;
            this.dgvproducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvproducts.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productid,
            this.productmfr,
            this.productname,
            this.productupc,
            this.productprice,
            this.productbarcode,
            this.productqty});
            this.dgvproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvproducts.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvproducts.Location = new System.Drawing.Point(3, 0);
            this.dgvproducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvproducts.Name = "dgvproducts";
            this.dgvproducts.RowHeadersVisible = false;
            this.dgvproducts.RowHeadersWidth = 51;
            this.dgvproducts.RowTemplate.Height = 24;
            this.dgvproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvproducts.Size = new System.Drawing.Size(959, 482);
            this.dgvproducts.TabIndex = 1;
            this.dgvproducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvproducts_KeyDown);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Location = new System.Drawing.Point(1072, 234);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(63, 13);
            this.invoicenolbl.TabIndex = 51;
            this.invoicenolbl.Text = "invoicenolbl";
            this.invoicenolbl.Visible = false;
            // 
            // selecteditempricelbl
            // 
            this.selecteditempricelbl.AutoSize = true;
            this.selecteditempricelbl.Location = new System.Drawing.Point(1085, 249);
            this.selecteditempricelbl.Name = "selecteditempricelbl";
            this.selecteditempricelbl.Size = new System.Drawing.Size(99, 13);
            this.selecteditempricelbl.TabIndex = 52;
            this.selecteditempricelbl.Text = "selecteditempricelbl";
            this.selecteditempricelbl.Visible = false;
            // 
            // productid
            // 
            this.productid.HeaderText = "ID";
            this.productid.MinimumWidth = 6;
            this.productid.Name = "productid";
            this.productid.Width = 125;
            // 
            // productmfr
            // 
            this.productmfr.HeaderText = "MFR";
            this.productmfr.Name = "productmfr";
            // 
            // productname
            // 
            this.productname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productname.HeaderText = "TITLE";
            this.productname.MinimumWidth = 6;
            this.productname.Name = "productname";
            // 
            // productupc
            // 
            this.productupc.HeaderText = "UPC";
            this.productupc.MinimumWidth = 6;
            this.productupc.Name = "productupc";
            this.productupc.Width = 125;
            // 
            // productprice
            // 
            this.productprice.HeaderText = "PRICE";
            this.productprice.MinimumWidth = 6;
            this.productprice.Name = "productprice";
            this.productprice.Width = 125;
            // 
            // productbarcode
            // 
            this.productbarcode.HeaderText = "BARCODE";
            this.productbarcode.MinimumWidth = 6;
            this.productbarcode.Name = "productbarcode";
            this.productbarcode.Width = 125;
            // 
            // productqty
            // 
            this.productqty.HeaderText = "QUANTITY";
            this.productqty.MinimumWidth = 6;
            this.productqty.Name = "productqty";
            this.productqty.Width = 125;
            // 
            // StockAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StockAdjustment";
            this.Text = "STOCK ADJUSTMENT";
            this.Load += new System.EventHandler(this.StockAdjustment_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox selectitemqtytxtbox;
        private System.Windows.Forms.Label openboxproductqtylbl;
        private System.Windows.Forms.TextBox selectwarehousefromtxtbox;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox qtytextbox;
        private System.Windows.Forms.Label qtylbl;
        private System.Windows.Forms.TextBox openboxproducttxtbox;
        private System.Windows.Forms.TextBox addedproductmfrtxtbox;
        private System.Windows.Forms.Label remainingboxproductlbl;
        private System.Windows.Forms.Label selectproductlbl;
        private System.Windows.Forms.Label warehousefromlbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.DataGridView dgvproducts;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Label selecteditembarcodelbl;
        private System.Windows.Forms.Label selecteditemupclbl;
        private System.Windows.Forms.Label selecteditemnamelbl;
        private System.Windows.Forms.Label selecteditemidlbl;
        private System.Windows.Forms.CheckBox addchkbox;
        private System.Windows.Forms.Label minusitembarcodelbl;
        private System.Windows.Forms.Label minusitemupclbl;
        private System.Windows.Forms.Label minusitemnamelbl;
        private System.Windows.Forms.Label minusitemidlbl;
        private System.Windows.Forms.Label minusitemproductmfrlbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label minusitempricelbl;
        private System.Windows.Forms.Label selectedproductmfrlbl;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.Label selecteditempricelbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn productupc;
        private System.Windows.Forms.DataGridViewTextBoxColumn productprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn productbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productqty;
    }
}