namespace SmartFlow.Stock
{
    partial class StockTransfer
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
            this.multiplestocktransferlbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectwarehousetotxtbox = new System.Windows.Forms.TextBox();
            this.selectwarehousefromtxtbox = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.mfrtxtbox = new System.Windows.Forms.TextBox();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.quantitylbl = new System.Windows.Forms.Label();
            this.productmfrlbl = new System.Windows.Forms.Label();
            this.warehousetolbl = new System.Windows.Forms.Label();
            this.warehousefromlbl = new System.Windows.Forms.Label();
            this.warehousetoidlbl = new System.Windows.Forms.Label();
            this.warehousefromidlbl = new System.Windows.Forms.Label();
            this.productpricelbl = new System.Windows.Forms.Label();
            this.stocktransferidlbl = new System.Windows.Forms.Label();
            this.productbarcodelbl = new System.Windows.Forms.Label();
            this.productupclbl = new System.Windows.Forms.Label();
            this.productnamelbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.dgvproducts = new System.Windows.Forms.DataGridView();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productupc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.closebtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.multiplestocktransferlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1448, 45);
            this.panel1.TabIndex = 0;
            // 
            // multiplestocktransferlbl
            // 
            this.multiplestocktransferlbl.BackColor = System.Drawing.Color.Black;
            this.multiplestocktransferlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplestocktransferlbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplestocktransferlbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.multiplestocktransferlbl.Location = new System.Drawing.Point(0, 0);
            this.multiplestocktransferlbl.Name = "multiplestocktransferlbl";
            this.multiplestocktransferlbl.Size = new System.Drawing.Size(1448, 45);
            this.multiplestocktransferlbl.TabIndex = 0;
            this.multiplestocktransferlbl.Text = "STOCK TRANSFER";
            this.multiplestocktransferlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.selectwarehousetotxtbox);
            this.panel2.Controls.Add(this.selectwarehousefromtxtbox);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.mfrtxtbox);
            this.panel2.Controls.Add(this.qtytxtbox);
            this.panel2.Controls.Add(this.quantitylbl);
            this.panel2.Controls.Add(this.productmfrlbl);
            this.panel2.Controls.Add(this.warehousetolbl);
            this.panel2.Controls.Add(this.warehousefromlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1448, 121);
            this.panel2.TabIndex = 1;
            // 
            // selectwarehousetotxtbox
            // 
            this.selectwarehousetotxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousetotxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousetotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetotxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetotxtbox.Location = new System.Drawing.Point(761, 17);
            this.selectwarehousetotxtbox.Name = "selectwarehousetotxtbox";
            this.selectwarehousetotxtbox.Size = new System.Drawing.Size(374, 30);
            this.selectwarehousetotxtbox.TabIndex = 1;
            this.selectwarehousetotxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetotxtbox_MouseClick);
            this.selectwarehousetotxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectwarehousetotxtbox_KeyDown);
            // 
            // selectwarehousefromtxtbox
            // 
            this.selectwarehousefromtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousefromtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousefromtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousefromtxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousefromtxtbox.Location = new System.Drawing.Point(211, 17);
            this.selectwarehousefromtxtbox.Name = "selectwarehousefromtxtbox";
            this.selectwarehousefromtxtbox.Size = new System.Drawing.Size(374, 30);
            this.selectwarehousefromtxtbox.TabIndex = 0;
            this.selectwarehousefromtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousefromtxtbox_MouseClick);
            // 
            // addbtn
            // 
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.Location = new System.Drawing.Point(1158, 18);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(99, 64);
            this.addbtn.TabIndex = 4;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.mfrtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.mfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mfrtxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfrtxtbox.Location = new System.Drawing.Point(211, 52);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.Size = new System.Drawing.Size(374, 30);
            this.mfrtxtbox.TabIndex = 2;
            this.mfrtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mfrtxtbox_MouseClick);
            this.mfrtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mfrtxtbox_KeyDown);
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtytxtbox.Location = new System.Drawing.Point(761, 52);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(374, 30);
            this.qtytxtbox.TabIndex = 3;
            this.qtytxtbox.Leave += new System.EventHandler(this.qtytxtbox_Leave);
            // 
            // quantitylbl
            // 
            this.quantitylbl.AutoSize = true;
            this.quantitylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantitylbl.Location = new System.Drawing.Point(620, 56);
            this.quantitylbl.Name = "quantitylbl";
            this.quantitylbl.Size = new System.Drawing.Size(91, 23);
            this.quantitylbl.TabIndex = 7;
            this.quantitylbl.Text = "QUANTITY";
            // 
            // productmfrlbl
            // 
            this.productmfrlbl.AutoSize = true;
            this.productmfrlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productmfrlbl.Location = new System.Drawing.Point(24, 56);
            this.productmfrlbl.Name = "productmfrlbl";
            this.productmfrlbl.Size = new System.Drawing.Size(125, 23);
            this.productmfrlbl.TabIndex = 5;
            this.productmfrlbl.Text = "PRODUCT MFR";
            // 
            // warehousetolbl
            // 
            this.warehousetolbl.AutoSize = true;
            this.warehousetolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehousetolbl.Location = new System.Drawing.Point(620, 21);
            this.warehousetolbl.Name = "warehousetolbl";
            this.warehousetolbl.Size = new System.Drawing.Size(136, 23);
            this.warehousetolbl.TabIndex = 2;
            this.warehousetolbl.Text = "WAREHOUSE TO";
            // 
            // warehousefromlbl
            // 
            this.warehousefromlbl.AutoSize = true;
            this.warehousefromlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehousefromlbl.Location = new System.Drawing.Point(24, 21);
            this.warehousefromlbl.Name = "warehousefromlbl";
            this.warehousefromlbl.Size = new System.Drawing.Size(163, 23);
            this.warehousefromlbl.TabIndex = 0;
            this.warehousefromlbl.Text = "WAREHOUSE FROM";
            // 
            // warehousetoidlbl
            // 
            this.warehousetoidlbl.AutoSize = true;
            this.warehousetoidlbl.Location = new System.Drawing.Point(1142, 389);
            this.warehousetoidlbl.Name = "warehousetoidlbl";
            this.warehousetoidlbl.Size = new System.Drawing.Size(95, 16);
            this.warehousetoidlbl.TabIndex = 20;
            this.warehousetoidlbl.Text = "warehousetoid";
            this.warehousetoidlbl.Visible = false;
            // 
            // warehousefromidlbl
            // 
            this.warehousefromidlbl.AutoSize = true;
            this.warehousefromidlbl.Location = new System.Drawing.Point(1142, 405);
            this.warehousefromidlbl.Name = "warehousefromidlbl";
            this.warehousefromidlbl.Size = new System.Drawing.Size(110, 16);
            this.warehousefromidlbl.TabIndex = 19;
            this.warehousefromidlbl.Text = "warehousefromid";
            this.warehousefromidlbl.Visible = false;
            // 
            // productpricelbl
            // 
            this.productpricelbl.AutoSize = true;
            this.productpricelbl.Location = new System.Drawing.Point(1142, 373);
            this.productpricelbl.Name = "productpricelbl";
            this.productpricelbl.Size = new System.Drawing.Size(82, 16);
            this.productpricelbl.TabIndex = 16;
            this.productpricelbl.Text = "productprice";
            this.productpricelbl.Visible = false;
            // 
            // stocktransferidlbl
            // 
            this.stocktransferidlbl.AutoSize = true;
            this.stocktransferidlbl.Location = new System.Drawing.Point(1142, 357);
            this.stocktransferidlbl.Name = "stocktransferidlbl";
            this.stocktransferidlbl.Size = new System.Drawing.Size(94, 16);
            this.stocktransferidlbl.TabIndex = 15;
            this.stocktransferidlbl.Text = "stocktransferid";
            this.stocktransferidlbl.Visible = false;
            // 
            // productbarcodelbl
            // 
            this.productbarcodelbl.AutoSize = true;
            this.productbarcodelbl.Location = new System.Drawing.Point(1142, 341);
            this.productbarcodelbl.Name = "productbarcodelbl";
            this.productbarcodelbl.Size = new System.Drawing.Size(58, 16);
            this.productbarcodelbl.TabIndex = 13;
            this.productbarcodelbl.Text = "barcode";
            this.productbarcodelbl.Visible = false;
            // 
            // productupclbl
            // 
            this.productupclbl.AutoSize = true;
            this.productupclbl.Location = new System.Drawing.Point(1142, 325);
            this.productupclbl.Name = "productupclbl";
            this.productupclbl.Size = new System.Drawing.Size(74, 16);
            this.productupclbl.TabIndex = 12;
            this.productupclbl.Text = "productupc";
            this.productupclbl.Visible = false;
            // 
            // productnamelbl
            // 
            this.productnamelbl.AutoSize = true;
            this.productnamelbl.Location = new System.Drawing.Point(1142, 300);
            this.productnamelbl.Name = "productnamelbl";
            this.productnamelbl.Size = new System.Drawing.Size(86, 16);
            this.productnamelbl.TabIndex = 11;
            this.productnamelbl.Text = "productname";
            this.productnamelbl.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(1142, 284);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(63, 16);
            this.productidlbl.TabIndex = 10;
            this.productidlbl.Text = "productid";
            this.productidlbl.Visible = false;
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
            this.productquantity});
            this.dgvproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvproducts.Location = new System.Drawing.Point(3, 3);
            this.dgvproducts.Name = "dgvproducts";
            this.dgvproducts.RowHeadersVisible = false;
            this.dgvproducts.RowHeadersWidth = 51;
            this.dgvproducts.RowTemplate.Height = 24;
            this.dgvproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvproducts.Size = new System.Drawing.Size(1132, 570);
            this.dgvproducts.TabIndex = 0;
            this.dgvproducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvproducts_KeyDown);
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
            this.productmfr.MinimumWidth = 6;
            this.productmfr.Name = "productmfr";
            this.productmfr.Width = 125;
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
            // productquantity
            // 
            this.productquantity.HeaderText = "QUANTITY";
            this.productquantity.MinimumWidth = 6;
            this.productquantity.Name = "productquantity";
            this.productquantity.Width = 125;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.warehousefromidlbl);
            this.panel3.Controls.Add(this.warehousetoidlbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.descriptionlbl);
            this.panel3.Controls.Add(this.dgvproducts);
            this.panel3.Controls.Add(this.productpricelbl);
            this.panel3.Controls.Add(this.productidlbl);
            this.panel3.Controls.Add(this.stocktransferidlbl);
            this.panel3.Controls.Add(this.productnamelbl);
            this.panel3.Controls.Add(this.productupclbl);
            this.panel3.Controls.Add(this.productbarcodelbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1448, 607);
            this.panel3.TabIndex = 3;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1145, 477);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(291, 45);
            this.savebtn.TabIndex = 2;
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
            this.descriptiontxtbox.Location = new System.Drawing.Point(1145, 31);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(291, 250);
            this.descriptiontxtbox.TabIndex = 1;
            this.descriptiontxtbox.Text = "";
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(1141, 5);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(116, 23);
            this.descriptionlbl.TabIndex = 6;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(1145, 528);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(291, 45);
            this.closebtn.TabIndex = 8;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // StockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1448, 773);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultipleTransfer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockTransfer_FormClosing);
            this.Load += new System.EventHandler(this.StockTransfer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockTransfer_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label multiplestocktransferlbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvproducts;
        private System.Windows.Forms.Label warehousefromlbl;
        private System.Windows.Forms.Label warehousetolbl;
        private System.Windows.Forms.Label productmfrlbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.Label quantitylbl;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox mfrtxtbox;
        private System.Windows.Forms.Label productbarcodelbl;
        private System.Windows.Forms.Label productupclbl;
        private System.Windows.Forms.Label productnamelbl;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label stocktransferidlbl;
        private System.Windows.Forms.Label productpricelbl;
        private System.Windows.Forms.TextBox selectwarehousetotxtbox;
        private System.Windows.Forms.TextBox selectwarehousefromtxtbox;
        private System.Windows.Forms.Label warehousetoidlbl;
        private System.Windows.Forms.Label warehousefromidlbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn productupc;
        private System.Windows.Forms.DataGridViewTextBoxColumn productprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn productbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productquantity;
        private System.Windows.Forms.Button closebtn;
    }
}