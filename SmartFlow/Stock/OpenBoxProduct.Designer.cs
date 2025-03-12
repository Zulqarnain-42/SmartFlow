namespace SmartFlow.Stock
{
    partial class OpenBoxProduct
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
            this.openboxqtytxtbox = new System.Windows.Forms.TextBox();
            this.openboxproductqtylbl = new System.Windows.Forms.Label();
            this.selectwarehousefromtxtbox = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.qtytextbox = new System.Windows.Forms.TextBox();
            this.qtylbl = new System.Windows.Forms.Label();
            this.openboxproducttxtbox = new System.Windows.Forms.TextBox();
            this.remainingproductmfrtxtbox = new System.Windows.Forms.TextBox();
            this.remainingboxproductlbl = new System.Windows.Forms.Label();
            this.selectopenproductlbl = new System.Windows.Forms.Label();
            this.warehousefromlbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.productbarcodelbl = new System.Windows.Forms.Label();
            this.productupclbl = new System.Windows.Forms.Label();
            this.productnamelbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.openboxproductidlbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openboxprodmfrlbl = new System.Windows.Forms.Label();
            this.productmfrlbl = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.openboxproductpricelbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.openboxproductbarcodelbl = new System.Windows.Forms.Label();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.openboxproductupclbl = new System.Windows.Forms.Label();
            this.openboxproductnamelbl = new System.Windows.Forms.Label();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.openboxprodidlbl = new System.Windows.Forms.Label();
            this.dgvproducts = new System.Windows.Forms.DataGridView();
            this.productpricelbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 37);
            this.panel1.TabIndex = 0;
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
            this.headinglbl.Size = new System.Drawing.Size(1118, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "OPEN BOX PRODUCTS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.openboxqtytxtbox);
            this.panel2.Controls.Add(this.openboxproductqtylbl);
            this.panel2.Controls.Add(this.selectwarehousefromtxtbox);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.qtytextbox);
            this.panel2.Controls.Add(this.qtylbl);
            this.panel2.Controls.Add(this.openboxproducttxtbox);
            this.panel2.Controls.Add(this.remainingproductmfrtxtbox);
            this.panel2.Controls.Add(this.remainingboxproductlbl);
            this.panel2.Controls.Add(this.selectopenproductlbl);
            this.panel2.Controls.Add(this.warehousefromlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 104);
            this.panel2.TabIndex = 1;
            // 
            // openboxqtytxtbox
            // 
            this.openboxqtytxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.openboxqtytxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.openboxqtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openboxqtytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openboxqtytxtbox.Location = new System.Drawing.Point(190, 67);
            this.openboxqtytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.openboxqtytxtbox.Name = "openboxqtytxtbox";
            this.openboxqtytxtbox.Size = new System.Drawing.Size(270, 27);
            this.openboxqtytxtbox.TabIndex = 34;
            // 
            // openboxproductqtylbl
            // 
            this.openboxproductqtylbl.AutoSize = true;
            this.openboxproductqtylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openboxproductqtylbl.Location = new System.Drawing.Point(8, 71);
            this.openboxproductqtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductqtylbl.Name = "openboxproductqtylbl";
            this.openboxproductqtylbl.Size = new System.Drawing.Size(138, 18);
            this.openboxproductqtylbl.TabIndex = 35;
            this.openboxproductqtylbl.Text = "OPEN BOX QUANTITY";
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
            this.addbtn.Location = new System.Drawing.Point(1028, 5);
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
            this.qtytextbox.Location = new System.Drawing.Point(734, 36);
            this.qtytextbox.Margin = new System.Windows.Forms.Padding(2);
            this.qtytextbox.Name = "qtytextbox";
            this.qtytextbox.Size = new System.Drawing.Size(270, 27);
            this.qtytextbox.TabIndex = 3;
            // 
            // qtylbl
            // 
            this.qtylbl.AutoSize = true;
            this.qtylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtylbl.Location = new System.Drawing.Point(465, 40);
            this.qtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qtylbl.Name = "qtylbl";
            this.qtylbl.Size = new System.Drawing.Size(219, 18);
            this.qtylbl.TabIndex = 33;
            this.qtylbl.Text = "REMAINING QUANTITY IN THE BOX";
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
            // remainingproductmfrtxtbox
            // 
            this.remainingproductmfrtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.remainingproductmfrtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.remainingproductmfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remainingproductmfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingproductmfrtxtbox.Location = new System.Drawing.Point(734, 5);
            this.remainingproductmfrtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.remainingproductmfrtxtbox.Name = "remainingproductmfrtxtbox";
            this.remainingproductmfrtxtbox.Size = new System.Drawing.Size(270, 27);
            this.remainingproductmfrtxtbox.TabIndex = 2;
            this.remainingproductmfrtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.remainingproductmfrtxtbox_MouseClick);
            // 
            // remainingboxproductlbl
            // 
            this.remainingboxproductlbl.AutoSize = true;
            this.remainingboxproductlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingboxproductlbl.Location = new System.Drawing.Point(465, 9);
            this.remainingboxproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.remainingboxproductlbl.Name = "remainingboxproductlbl";
            this.remainingboxproductlbl.Size = new System.Drawing.Size(252, 18);
            this.remainingboxproductlbl.TabIndex = 23;
            this.remainingboxproductlbl.Text = "REMAINING IN THE BOX PRODUCTS MFR";
            // 
            // selectopenproductlbl
            // 
            this.selectopenproductlbl.AutoSize = true;
            this.selectopenproductlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectopenproductlbl.Location = new System.Drawing.Point(8, 40);
            this.selectopenproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectopenproductlbl.Name = "selectopenproductlbl";
            this.selectopenproductlbl.Size = new System.Drawing.Size(179, 18);
            this.selectopenproductlbl.TabIndex = 21;
            this.selectopenproductlbl.Text = "SELECT OPEN BOX PRODUCT";
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
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(1040, 236);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(67, 13);
            this.warehouseidlbl.TabIndex = 35;
            this.warehouseidlbl.Text = "warehouseid";
            this.warehouseidlbl.Visible = false;
            // 
            // productbarcodelbl
            // 
            this.productbarcodelbl.AutoSize = true;
            this.productbarcodelbl.Location = new System.Drawing.Point(1024, 355);
            this.productbarcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productbarcodelbl.Name = "productbarcodelbl";
            this.productbarcodelbl.Size = new System.Drawing.Size(82, 13);
            this.productbarcodelbl.TabIndex = 30;
            this.productbarcodelbl.Text = "productbarcode";
            this.productbarcodelbl.Visible = false;
            // 
            // productupclbl
            // 
            this.productupclbl.AutoSize = true;
            this.productupclbl.Location = new System.Drawing.Point(1045, 368);
            this.productupclbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productupclbl.Name = "productupclbl";
            this.productupclbl.Size = new System.Drawing.Size(61, 13);
            this.productupclbl.TabIndex = 29;
            this.productupclbl.Text = "productupc";
            this.productupclbl.Visible = false;
            // 
            // productnamelbl
            // 
            this.productnamelbl.AutoSize = true;
            this.productnamelbl.Location = new System.Drawing.Point(1037, 381);
            this.productnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productnamelbl.Name = "productnamelbl";
            this.productnamelbl.Size = new System.Drawing.Size(69, 13);
            this.productnamelbl.TabIndex = 28;
            this.productnamelbl.Text = "productname";
            this.productnamelbl.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(888, 381);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(51, 13);
            this.productidlbl.TabIndex = 27;
            this.productidlbl.Text = "productid";
            this.productidlbl.Visible = false;
            // 
            // openboxproductidlbl
            // 
            this.openboxproductidlbl.AutoSize = true;
            this.openboxproductidlbl.Location = new System.Drawing.Point(888, 368);
            this.openboxproductidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductidlbl.Name = "openboxproductidlbl";
            this.openboxproductidlbl.Size = new System.Drawing.Size(92, 13);
            this.openboxproductidlbl.TabIndex = 25;
            this.openboxproductidlbl.Text = "openboxproductid";
            this.openboxproductidlbl.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.openboxprodmfrlbl);
            this.panel3.Controls.Add(this.productmfrlbl);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.warehouseidlbl);
            this.panel3.Controls.Add(this.openboxproductpricelbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.openboxproductbarcodelbl);
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.openboxproductupclbl);
            this.panel3.Controls.Add(this.openboxproductnamelbl);
            this.panel3.Controls.Add(this.descriptionlbl);
            this.panel3.Controls.Add(this.openboxprodidlbl);
            this.panel3.Controls.Add(this.dgvproducts);
            this.panel3.Controls.Add(this.productnamelbl);
            this.panel3.Controls.Add(this.openboxproductidlbl);
            this.panel3.Controls.Add(this.productpricelbl);
            this.panel3.Controls.Add(this.productidlbl);
            this.panel3.Controls.Add(this.productbarcodelbl);
            this.panel3.Controls.Add(this.productupclbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 141);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 487);
            this.panel3.TabIndex = 2;
            // 
            // openboxprodmfrlbl
            // 
            this.openboxprodmfrlbl.AutoSize = true;
            this.openboxprodmfrlbl.Location = new System.Drawing.Point(1013, 299);
            this.openboxprodmfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxprodmfrlbl.Name = "openboxprodmfrlbl";
            this.openboxprodmfrlbl.Size = new System.Drawing.Size(93, 13);
            this.openboxprodmfrlbl.TabIndex = 40;
            this.openboxprodmfrlbl.Text = "openboxprodmfrlbl";
            this.openboxprodmfrlbl.Visible = false;
            // 
            // productmfrlbl
            // 
            this.productmfrlbl.AutoSize = true;
            this.productmfrlbl.Location = new System.Drawing.Point(1039, 266);
            this.productmfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productmfrlbl.Name = "productmfrlbl";
            this.productmfrlbl.Size = new System.Drawing.Size(67, 13);
            this.productmfrlbl.TabIndex = 39;
            this.productmfrlbl.Text = "productmfrlbl";
            this.productmfrlbl.Visible = false;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(891, 447);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(218, 37);
            this.closebtn.TabIndex = 38;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // openboxproductpricelbl
            // 
            this.openboxproductpricelbl.AutoSize = true;
            this.openboxproductpricelbl.Location = new System.Drawing.Point(999, 283);
            this.openboxproductpricelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductpricelbl.Name = "openboxproductpricelbl";
            this.openboxproductpricelbl.Size = new System.Drawing.Size(107, 13);
            this.openboxproductpricelbl.TabIndex = 37;
            this.openboxproductpricelbl.Text = "openboxproductprice";
            this.openboxproductpricelbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(891, 406);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(218, 37);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // openboxproductbarcodelbl
            // 
            this.openboxproductbarcodelbl.AutoSize = true;
            this.openboxproductbarcodelbl.Location = new System.Drawing.Point(888, 355);
            this.openboxproductbarcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductbarcodelbl.Name = "openboxproductbarcodelbl";
            this.openboxproductbarcodelbl.Size = new System.Drawing.Size(123, 13);
            this.openboxproductbarcodelbl.TabIndex = 36;
            this.openboxproductbarcodelbl.Text = "openboxproductbarcode";
            this.openboxproductbarcodelbl.Visible = false;
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(891, 27);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(219, 203);
            this.descriptiontxtbox.TabIndex = 0;
            this.descriptiontxtbox.Text = "";
            // 
            // openboxproductupclbl
            // 
            this.openboxproductupclbl.AutoSize = true;
            this.openboxproductupclbl.Location = new System.Drawing.Point(1004, 316);
            this.openboxproductupclbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductupclbl.Name = "openboxproductupclbl";
            this.openboxproductupclbl.Size = new System.Drawing.Size(102, 13);
            this.openboxproductupclbl.TabIndex = 35;
            this.openboxproductupclbl.Text = "openboxproductupc";
            this.openboxproductupclbl.Visible = false;
            // 
            // openboxproductnamelbl
            // 
            this.openboxproductnamelbl.AutoSize = true;
            this.openboxproductnamelbl.Location = new System.Drawing.Point(996, 329);
            this.openboxproductnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxproductnamelbl.Name = "openboxproductnamelbl";
            this.openboxproductnamelbl.Size = new System.Drawing.Size(110, 13);
            this.openboxproductnamelbl.TabIndex = 34;
            this.openboxproductnamelbl.Text = "openboxproductname";
            this.openboxproductnamelbl.Visible = false;
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(888, 6);
            this.descriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(90, 18);
            this.descriptionlbl.TabIndex = 13;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // openboxprodidlbl
            // 
            this.openboxprodidlbl.AutoSize = true;
            this.openboxprodidlbl.Location = new System.Drawing.Point(1019, 342);
            this.openboxprodidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openboxprodidlbl.Name = "openboxprodidlbl";
            this.openboxprodidlbl.Size = new System.Drawing.Size(87, 13);
            this.openboxprodidlbl.TabIndex = 33;
            this.openboxprodidlbl.Text = "openboxprodidlbl";
            this.openboxprodidlbl.Visible = false;
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
            this.dgvproducts.Location = new System.Drawing.Point(2, 0);
            this.dgvproducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvproducts.Name = "dgvproducts";
            this.dgvproducts.RowHeadersVisible = false;
            this.dgvproducts.RowHeadersWidth = 51;
            this.dgvproducts.RowTemplate.Height = 24;
            this.dgvproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvproducts.Size = new System.Drawing.Size(882, 484);
            this.dgvproducts.TabIndex = 1;
            this.dgvproducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvproducts_KeyDown);
            // 
            // productpricelbl
            // 
            this.productpricelbl.AutoSize = true;
            this.productpricelbl.Location = new System.Drawing.Point(1040, 249);
            this.productpricelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productpricelbl.Name = "productpricelbl";
            this.productpricelbl.Size = new System.Drawing.Size(66, 13);
            this.productpricelbl.TabIndex = 31;
            this.productpricelbl.Text = "productprice";
            this.productpricelbl.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
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
            // OpenBoxProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1118, 628);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OpenBoxProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPEN BOX PRODUCTS";
            this.Load += new System.EventHandler(this.OpenBoxProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenBoxProduct_KeyDown);
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
        private System.Windows.Forms.Label selectopenproductlbl;
        private System.Windows.Forms.Label warehousefromlbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvproducts;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.Label remainingboxproductlbl;
        private System.Windows.Forms.Label openboxproductidlbl;
        private System.Windows.Forms.TextBox remainingproductmfrtxtbox;
        private System.Windows.Forms.Label productbarcodelbl;
        private System.Windows.Forms.Label productupclbl;
        private System.Windows.Forms.Label productnamelbl;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label productpricelbl;
        private System.Windows.Forms.Label openboxproductpricelbl;
        private System.Windows.Forms.Label openboxproductbarcodelbl;
        private System.Windows.Forms.Label openboxproductupclbl;
        private System.Windows.Forms.Label openboxproductnamelbl;
        private System.Windows.Forms.Label openboxprodidlbl;
        private System.Windows.Forms.TextBox openboxproducttxtbox;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox qtytextbox;
        private System.Windows.Forms.Label qtylbl;
        private System.Windows.Forms.TextBox selectwarehousefromtxtbox;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.TextBox openboxqtytxtbox;
        private System.Windows.Forms.Label openboxproductqtylbl;
        private System.Windows.Forms.Label productmfrlbl;
        private System.Windows.Forms.Label openboxprodmfrlbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn productupc;
        private System.Windows.Forms.DataGridViewTextBoxColumn productprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn productbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productqty;
    }
}