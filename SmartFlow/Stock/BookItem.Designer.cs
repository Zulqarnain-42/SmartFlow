namespace SmartFlow.Stock
{
    partial class BookItem
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
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.startdatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addrowbtn = new System.Windows.Forms.Button();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.mfrtxtbox = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.bookitemidlbl = new System.Windows.Forms.Label();
            this.bookinglocationlbl = new System.Windows.Forms.Label();
            this.bookinglocationtxtbox = new System.Windows.Forms.TextBox();
            this.selectwarehouselbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.enddatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.enddatelbl = new System.Windows.Forms.Label();
            this.startdatelbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.importantnotestxtbox = new System.Windows.Forms.RichTextBox();
            this.importantnoteslbl = new System.Windows.Forms.Label();
            this.dgvbookingitem = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbookingitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 37);
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
            this.headinglbl.Size = new System.Drawing.Size(972, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "BOOKING OF ITEMS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(9, 12);
            this.invoicenolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(83, 18);
            this.invoicenolbl.TabIndex = 1;
            this.invoicenolbl.Text = "INVOICE NO";
            this.invoicenolbl.Visible = false;
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.invoicenotxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.invoicenotxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(122, 8);
            this.invoicenotxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(270, 27);
            this.invoicenotxtbox.TabIndex = 2;
            this.invoicenotxtbox.Visible = false;
            // 
            // startdatetxtbox
            // 
            this.startdatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startdatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatetxtbox.Location = new System.Drawing.Point(122, 38);
            this.startdatetxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.startdatetxtbox.Mask = "00/00/0000";
            this.startdatetxtbox.Name = "startdatetxtbox";
            this.startdatetxtbox.Size = new System.Drawing.Size(270, 27);
            this.startdatetxtbox.TabIndex = 117;
            this.startdatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addrowbtn);
            this.panel2.Controls.Add(this.warehouseidlbl);
            this.panel2.Controls.Add(this.mfrtxtbox);
            this.panel2.Controls.Add(this.productidlbl);
            this.panel2.Controls.Add(this.selectproducttxtbox);
            this.panel2.Controls.Add(this.selectproductlbl);
            this.panel2.Controls.Add(this.bookitemidlbl);
            this.panel2.Controls.Add(this.bookinglocationlbl);
            this.panel2.Controls.Add(this.bookinglocationtxtbox);
            this.panel2.Controls.Add(this.selectwarehouselbl);
            this.panel2.Controls.Add(this.selectwarehousetxtbox);
            this.panel2.Controls.Add(this.searchbtn);
            this.panel2.Controls.Add(this.enddatetxtbox);
            this.panel2.Controls.Add(this.enddatelbl);
            this.panel2.Controls.Add(this.startdatelbl);
            this.panel2.Controls.Add(this.invoicenolbl);
            this.panel2.Controls.Add(this.startdatetxtbox);
            this.panel2.Controls.Add(this.invoicenotxtbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 144);
            this.panel2.TabIndex = 118;
            // 
            // addrowbtn
            // 
            this.addrowbtn.Location = new System.Drawing.Point(865, 103);
            this.addrowbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addrowbtn.Name = "addrowbtn";
            this.addrowbtn.Size = new System.Drawing.Size(98, 36);
            this.addrowbtn.TabIndex = 132;
            this.addrowbtn.Text = "ADD PRODUCT";
            this.addrowbtn.UseVisualStyleBackColor = true;
            this.addrowbtn.Click += new System.EventHandler(this.addrowbtn_Click);
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(636, 101);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 131;
            this.warehouseidlbl.Text = "warehouseidlbl";
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.AutoSize = true;
            this.mfrtxtbox.Location = new System.Drawing.Point(416, 98);
            this.mfrtxtbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.Size = new System.Drawing.Size(49, 13);
            this.mfrtxtbox.TabIndex = 130;
            this.mfrtxtbox.Text = "mfrtxtbox";
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(416, 82);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(61, 13);
            this.productidlbl.TabIndex = 129;
            this.productidlbl.Text = "productidlbl";
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(122, 100);
            this.selectproducttxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(270, 27);
            this.selectproducttxtbox.TabIndex = 128;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            // 
            // selectproductlbl
            // 
            this.selectproductlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectproductlbl.AutoSize = true;
            this.selectproductlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproductlbl.Location = new System.Drawing.Point(9, 103);
            this.selectproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(112, 18);
            this.selectproductlbl.TabIndex = 127;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // bookitemidlbl
            // 
            this.bookitemidlbl.AutoSize = true;
            this.bookitemidlbl.Location = new System.Drawing.Point(634, 15);
            this.bookitemidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookitemidlbl.Name = "bookitemidlbl";
            this.bookitemidlbl.Size = new System.Drawing.Size(68, 13);
            this.bookitemidlbl.TabIndex = 126;
            this.bookitemidlbl.Text = "bookitemidlbl";
            // 
            // bookinglocationlbl
            // 
            this.bookinglocationlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookinglocationlbl.AutoSize = true;
            this.bookinglocationlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookinglocationlbl.Location = new System.Drawing.Point(493, 73);
            this.bookinglocationlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookinglocationlbl.Name = "bookinglocationlbl";
            this.bookinglocationlbl.Size = new System.Drawing.Size(133, 18);
            this.bookinglocationlbl.TabIndex = 124;
            this.bookinglocationlbl.Text = "BOOKING LOCATION";
            this.bookinglocationlbl.Visible = false;
            // 
            // bookinglocationtxtbox
            // 
            this.bookinglocationtxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookinglocationtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bookinglocationtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.bookinglocationtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookinglocationtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookinglocationtxtbox.Location = new System.Drawing.Point(636, 69);
            this.bookinglocationtxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bookinglocationtxtbox.Name = "bookinglocationtxtbox";
            this.bookinglocationtxtbox.Size = new System.Drawing.Size(270, 27);
            this.bookinglocationtxtbox.TabIndex = 125;
            this.bookinglocationtxtbox.Visible = false;
            // 
            // selectwarehouselbl
            // 
            this.selectwarehouselbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectwarehouselbl.AutoSize = true;
            this.selectwarehouselbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehouselbl.Location = new System.Drawing.Point(493, 42);
            this.selectwarehouselbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectwarehouselbl.Name = "selectwarehouselbl";
            this.selectwarehouselbl.Size = new System.Drawing.Size(86, 18);
            this.selectwarehouselbl.TabIndex = 122;
            this.selectwarehouselbl.Text = "WAREHOUSE";
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectwarehousetxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousetxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(636, 38);
            this.selectwarehousetxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(270, 27);
            this.selectwarehousetxtbox.TabIndex = 123;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // searchbtn
            // 
            this.searchbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchbtn.Location = new System.Drawing.Point(396, 8);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(93, 21);
            this.searchbtn.TabIndex = 121;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Visible = false;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // enddatetxtbox
            // 
            this.enddatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enddatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatetxtbox.Location = new System.Drawing.Point(122, 69);
            this.enddatetxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.enddatetxtbox.Mask = "00/00/0000";
            this.enddatetxtbox.Name = "enddatetxtbox";
            this.enddatetxtbox.Size = new System.Drawing.Size(270, 27);
            this.enddatetxtbox.TabIndex = 120;
            this.enddatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // enddatelbl
            // 
            this.enddatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatelbl.AutoSize = true;
            this.enddatelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatelbl.Location = new System.Drawing.Point(9, 73);
            this.enddatelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.enddatelbl.Name = "enddatelbl";
            this.enddatelbl.Size = new System.Drawing.Size(68, 18);
            this.enddatelbl.TabIndex = 119;
            this.enddatelbl.Text = "END DATE";
            // 
            // startdatelbl
            // 
            this.startdatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatelbl.AutoSize = true;
            this.startdatelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatelbl.Location = new System.Drawing.Point(9, 42);
            this.startdatelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startdatelbl.Name = "startdatelbl";
            this.startdatelbl.Size = new System.Drawing.Size(79, 18);
            this.startdatelbl.TabIndex = 118;
            this.startdatelbl.Text = "START DATE";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.importantnotestxtbox);
            this.panel3.Controls.Add(this.importantnoteslbl);
            this.panel3.Controls.Add(this.dgvbookingitem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 181);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 435);
            this.panel3.TabIndex = 119;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(742, 388);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(221, 37);
            this.closebtn.TabIndex = 40;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(742, 347);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(221, 37);
            this.savebtn.TabIndex = 39;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // importantnotestxtbox
            // 
            this.importantnotestxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importantnotestxtbox.Location = new System.Drawing.Point(742, 27);
            this.importantnotestxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importantnotestxtbox.Name = "importantnotestxtbox";
            this.importantnotestxtbox.Size = new System.Drawing.Size(222, 241);
            this.importantnotestxtbox.TabIndex = 2;
            this.importantnotestxtbox.Text = "";
            // 
            // importantnoteslbl
            // 
            this.importantnoteslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importantnoteslbl.AutoSize = true;
            this.importantnoteslbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importantnoteslbl.Location = new System.Drawing.Point(739, 6);
            this.importantnoteslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.importantnoteslbl.Name = "importantnoteslbl";
            this.importantnoteslbl.Size = new System.Drawing.Size(126, 18);
            this.importantnoteslbl.TabIndex = 1;
            this.importantnoteslbl.Text = "IMPORTANT NOTES";
            // 
            // dgvbookingitem
            // 
            this.dgvbookingitem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvbookingitem.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvbookingitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbookingitem.Location = new System.Drawing.Point(2, 0);
            this.dgvbookingitem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvbookingitem.Name = "dgvbookingitem";
            this.dgvbookingitem.RowHeadersWidth = 51;
            this.dgvbookingitem.RowTemplate.Height = 24;
            this.dgvbookingitem.Size = new System.Drawing.Size(731, 432);
            this.dgvbookingitem.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BookItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(972, 616);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BookItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOOK AN ITEM";
            this.Load += new System.EventHandler(this.BookItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BookItem_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbookingitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.MaskedTextBox startdatetxtbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox enddatetxtbox;
        private System.Windows.Forms.Label enddatelbl;
        private System.Windows.Forms.Label startdatelbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvbookingitem;
        private System.Windows.Forms.RichTextBox importantnotestxtbox;
        private System.Windows.Forms.Label importantnoteslbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label selectwarehouselbl;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label bookinglocationlbl;
        private System.Windows.Forms.TextBox bookinglocationtxtbox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label bookitemidlbl;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Label selectproductlbl;
        private System.Windows.Forms.Label mfrtxtbox;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Button addrowbtn;
    }
}