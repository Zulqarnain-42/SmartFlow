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
            this.startdatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.bookitemqtylbl = new System.Windows.Forms.Label();
            this.bookinglocationcombo = new System.Windows.Forms.ComboBox();
            this.addrowbtn = new System.Windows.Forms.Button();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.bookinglocationlbl = new System.Windows.Forms.Label();
            this.selectwarehouselbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.enddatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.enddatelbl = new System.Windows.Forms.Label();
            this.startdatelbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.productmfrlbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.bookitemidlbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.productupclbl = new System.Windows.Forms.Label();
            this.productbarcodelbl = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.productpricelbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.importantnotestxtbox = new System.Windows.Forms.RichTextBox();
            this.importantnoteslbl = new System.Windows.Forms.Label();
            this.dgvbookingitem = new System.Windows.Forms.DataGridView();
            this.productidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfrcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producttitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productupc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 37);
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
            this.headinglbl.Size = new System.Drawing.Size(1009, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "BOOKING OF ITEMS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startdatetxtbox
            // 
            this.startdatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startdatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatetxtbox.Location = new System.Drawing.Point(122, 11);
            this.startdatetxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.startdatetxtbox.Mask = "00/00/0000";
            this.startdatetxtbox.Name = "startdatetxtbox";
            this.startdatetxtbox.Size = new System.Drawing.Size(270, 27);
            this.startdatetxtbox.TabIndex = 117;
            this.startdatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.qtytxtbox);
            this.panel2.Controls.Add(this.bookitemqtylbl);
            this.panel2.Controls.Add(this.bookinglocationcombo);
            this.panel2.Controls.Add(this.addrowbtn);
            this.panel2.Controls.Add(this.selectproducttxtbox);
            this.panel2.Controls.Add(this.selectproductlbl);
            this.panel2.Controls.Add(this.bookinglocationlbl);
            this.panel2.Controls.Add(this.selectwarehouselbl);
            this.panel2.Controls.Add(this.selectwarehousetxtbox);
            this.panel2.Controls.Add(this.enddatetxtbox);
            this.panel2.Controls.Add(this.enddatelbl);
            this.panel2.Controls.Add(this.startdatelbl);
            this.panel2.Controls.Add(this.startdatetxtbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 119);
            this.panel2.TabIndex = 118;
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.qtytxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.qtytxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtytxtbox.Location = new System.Drawing.Point(550, 74);
            this.qtytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(270, 27);
            this.qtytxtbox.TabIndex = 135;
            // 
            // bookitemqtylbl
            // 
            this.bookitemqtylbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookitemqtylbl.AutoSize = true;
            this.bookitemqtylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookitemqtylbl.Location = new System.Drawing.Point(407, 78);
            this.bookitemqtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookitemqtylbl.Name = "bookitemqtylbl";
            this.bookitemqtylbl.Size = new System.Drawing.Size(71, 18);
            this.bookitemqtylbl.TabIndex = 134;
            this.bookitemqtylbl.Text = "QUANTITY";
            // 
            // bookinglocationcombo
            // 
            this.bookinglocationcombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bookinglocationcombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.bookinglocationcombo.Font = new System.Drawing.Font("Calibri", 12F);
            this.bookinglocationcombo.FormattingEnabled = true;
            this.bookinglocationcombo.Location = new System.Drawing.Point(550, 42);
            this.bookinglocationcombo.Name = "bookinglocationcombo";
            this.bookinglocationcombo.Size = new System.Drawing.Size(270, 27);
            this.bookinglocationcombo.TabIndex = 133;
            // 
            // addrowbtn
            // 
            this.addrowbtn.Location = new System.Drawing.Point(824, 74);
            this.addrowbtn.Margin = new System.Windows.Forms.Padding(2);
            this.addrowbtn.Name = "addrowbtn";
            this.addrowbtn.Size = new System.Drawing.Size(98, 27);
            this.addrowbtn.TabIndex = 132;
            this.addrowbtn.Text = "ADD PRODUCT";
            this.addrowbtn.UseVisualStyleBackColor = true;
            this.addrowbtn.Click += new System.EventHandler(this.addrowbtn_Click);
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(122, 74);
            this.selectproducttxtbox.Margin = new System.Windows.Forms.Padding(2);
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
            this.selectproductlbl.Location = new System.Drawing.Point(9, 78);
            this.selectproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(112, 18);
            this.selectproductlbl.TabIndex = 127;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // bookinglocationlbl
            // 
            this.bookinglocationlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookinglocationlbl.AutoSize = true;
            this.bookinglocationlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookinglocationlbl.Location = new System.Drawing.Point(407, 46);
            this.bookinglocationlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookinglocationlbl.Name = "bookinglocationlbl";
            this.bookinglocationlbl.Size = new System.Drawing.Size(133, 18);
            this.bookinglocationlbl.TabIndex = 124;
            this.bookinglocationlbl.Text = "BOOKING LOCATION";
            // 
            // selectwarehouselbl
            // 
            this.selectwarehouselbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectwarehouselbl.AutoSize = true;
            this.selectwarehouselbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehouselbl.Location = new System.Drawing.Point(407, 15);
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
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(550, 11);
            this.selectwarehousetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(270, 27);
            this.selectwarehousetxtbox.TabIndex = 123;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            this.selectwarehousetxtbox.Leave += new System.EventHandler(this.selectwarehousetxtbox_Leave);
            // 
            // enddatetxtbox
            // 
            this.enddatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enddatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatetxtbox.Location = new System.Drawing.Point(122, 42);
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
            this.enddatelbl.Location = new System.Drawing.Point(9, 46);
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
            this.startdatelbl.Location = new System.Drawing.Point(9, 15);
            this.startdatelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startdatelbl.Name = "startdatelbl";
            this.startdatelbl.Size = new System.Drawing.Size(79, 18);
            this.startdatelbl.TabIndex = 118;
            this.startdatelbl.Text = "START DATE";
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(884, 278);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 131;
            this.warehouseidlbl.Text = "warehouseidlbl";
            // 
            // productmfrlbl
            // 
            this.productmfrlbl.AutoSize = true;
            this.productmfrlbl.Location = new System.Drawing.Point(786, 322);
            this.productmfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productmfrlbl.Name = "productmfrlbl";
            this.productmfrlbl.Size = new System.Drawing.Size(67, 13);
            this.productmfrlbl.TabIndex = 130;
            this.productmfrlbl.Text = "productmfrlbl";
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(786, 309);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(61, 13);
            this.productidlbl.TabIndex = 129;
            this.productidlbl.Text = "productidlbl";
            // 
            // bookitemidlbl
            // 
            this.bookitemidlbl.AutoSize = true;
            this.bookitemidlbl.Location = new System.Drawing.Point(884, 294);
            this.bookitemidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookitemidlbl.Name = "bookitemidlbl";
            this.bookitemidlbl.Size = new System.Drawing.Size(68, 13);
            this.bookitemidlbl.TabIndex = 126;
            this.bookitemidlbl.Text = "bookitemidlbl";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.productupclbl);
            this.panel3.Controls.Add(this.productbarcodelbl);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.productmfrlbl);
            this.panel3.Controls.Add(this.productpricelbl);
            this.panel3.Controls.Add(this.productidlbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.importantnotestxtbox);
            this.panel3.Controls.Add(this.importantnoteslbl);
            this.panel3.Controls.Add(this.dgvbookingitem);
            this.panel3.Controls.Add(this.warehouseidlbl);
            this.panel3.Controls.Add(this.bookitemidlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 156);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1009, 460);
            this.panel3.TabIndex = 119;
            // 
            // productupclbl
            // 
            this.productupclbl.AutoSize = true;
            this.productupclbl.Location = new System.Drawing.Point(786, 335);
            this.productupclbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productupclbl.Name = "productupclbl";
            this.productupclbl.Size = new System.Drawing.Size(71, 13);
            this.productupclbl.TabIndex = 134;
            this.productupclbl.Text = "productupclbl";
            // 
            // productbarcodelbl
            // 
            this.productbarcodelbl.AutoSize = true;
            this.productbarcodelbl.Location = new System.Drawing.Point(778, 294);
            this.productbarcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productbarcodelbl.Name = "productbarcodelbl";
            this.productbarcodelbl.Size = new System.Drawing.Size(92, 13);
            this.productbarcodelbl.TabIndex = 136;
            this.productbarcodelbl.Text = "productbarcodelbl";
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(779, 413);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(221, 37);
            this.closebtn.TabIndex = 40;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // productpricelbl
            // 
            this.productpricelbl.AutoSize = true;
            this.productpricelbl.Location = new System.Drawing.Point(774, 281);
            this.productpricelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productpricelbl.Name = "productpricelbl";
            this.productpricelbl.Size = new System.Drawing.Size(76, 13);
            this.productpricelbl.TabIndex = 135;
            this.productpricelbl.Text = "productpricelbl";
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(779, 372);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
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
            this.importantnotestxtbox.Location = new System.Drawing.Point(779, 27);
            this.importantnotestxtbox.Margin = new System.Windows.Forms.Padding(2);
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
            this.importantnoteslbl.Location = new System.Drawing.Point(776, 6);
            this.importantnoteslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.importantnoteslbl.Name = "importantnoteslbl";
            this.importantnoteslbl.Size = new System.Drawing.Size(126, 18);
            this.importantnoteslbl.TabIndex = 1;
            this.importantnoteslbl.Text = "IMPORTANT NOTES";
            // 
            // dgvbookingitem
            // 
            this.dgvbookingitem.AllowUserToAddRows = false;
            this.dgvbookingitem.AllowUserToDeleteRows = false;
            this.dgvbookingitem.AllowUserToResizeColumns = false;
            this.dgvbookingitem.AllowUserToResizeRows = false;
            this.dgvbookingitem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvbookingitem.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvbookingitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbookingitem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productidcolumn,
            this.productmfrcolumn,
            this.producttitle,
            this.productupc,
            this.productbarcode,
            this.productquantity});
            this.dgvbookingitem.Location = new System.Drawing.Point(2, 2);
            this.dgvbookingitem.Margin = new System.Windows.Forms.Padding(2);
            this.dgvbookingitem.Name = "dgvbookingitem";
            this.dgvbookingitem.RowHeadersVisible = false;
            this.dgvbookingitem.RowHeadersWidth = 51;
            this.dgvbookingitem.RowTemplate.Height = 24;
            this.dgvbookingitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbookingitem.Size = new System.Drawing.Size(768, 455);
            this.dgvbookingitem.TabIndex = 0;
            // 
            // productidcolumn
            // 
            this.productidcolumn.HeaderText = "ID";
            this.productidcolumn.Name = "productidcolumn";
            // 
            // productmfrcolumn
            // 
            this.productmfrcolumn.HeaderText = "MFR";
            this.productmfrcolumn.Name = "productmfrcolumn";
            // 
            // producttitle
            // 
            this.producttitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.producttitle.HeaderText = "TITLE";
            this.producttitle.Name = "producttitle";
            // 
            // productupc
            // 
            this.productupc.HeaderText = "UPC";
            this.productupc.Name = "productupc";
            // 
            // productbarcode
            // 
            this.productbarcode.HeaderText = "BARCODE";
            this.productbarcode.Name = "productbarcode";
            // 
            // productquantity
            // 
            this.productquantity.HeaderText = "QUANTITY";
            this.productquantity.Name = "productquantity";
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
            this.ClientSize = new System.Drawing.Size(1009, 616);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.MaskedTextBox startdatetxtbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox enddatetxtbox;
        private System.Windows.Forms.Label enddatelbl;
        private System.Windows.Forms.Label startdatelbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvbookingitem;
        private System.Windows.Forms.RichTextBox importantnotestxtbox;
        private System.Windows.Forms.Label importantnoteslbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label selectwarehouselbl;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label bookinglocationlbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label bookitemidlbl;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Label selectproductlbl;
        private System.Windows.Forms.Label productmfrlbl;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Button addrowbtn;
        private System.Windows.Forms.ComboBox bookinglocationcombo;
        private System.Windows.Forms.Label productpricelbl;
        private System.Windows.Forms.Label productupclbl;
        private System.Windows.Forms.Label productbarcodelbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfrcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn producttitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn productupc;
        private System.Windows.Forms.DataGridViewTextBoxColumn productbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productquantity;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.Label bookitemqtylbl;
    }
}