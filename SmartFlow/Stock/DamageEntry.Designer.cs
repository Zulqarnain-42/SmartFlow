namespace SmartFlow.Stock
{
    partial class DamageEntry
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
            this.selectwarehousefromtxtbox = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.productmfrtxtbox = new System.Windows.Forms.TextBox();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.damagequantitylbl = new System.Windows.Forms.Label();
            this.productmfrlbl = new System.Windows.Forms.Label();
            this.warehousefromlbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.barcodelbl = new System.Windows.Forms.Label();
            this.upclbl = new System.Windows.Forms.Label();
            this.productnamelbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.damageidlbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.dgvproducts = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.damagecodelbl = new System.Windows.Forms.Label();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productupc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damagedqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(1084, 37);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1084, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "DAMAGE ENTRY";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.selectwarehousefromtxtbox);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.productmfrtxtbox);
            this.panel2.Controls.Add(this.qtytxtbox);
            this.panel2.Controls.Add(this.damagequantitylbl);
            this.panel2.Controls.Add(this.productmfrlbl);
            this.panel2.Controls.Add(this.warehousefromlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 109);
            this.panel2.TabIndex = 1;
            // 
            // selectwarehousefromtxtbox
            // 
            this.selectwarehousefromtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousefromtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousefromtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousefromtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousefromtxtbox.Location = new System.Drawing.Point(175, 11);
            this.selectwarehousefromtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectwarehousefromtxtbox.Name = "selectwarehousefromtxtbox";
            this.selectwarehousefromtxtbox.Size = new System.Drawing.Size(281, 27);
            this.selectwarehousefromtxtbox.TabIndex = 0;
            this.selectwarehousefromtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousefromtxtbox_MouseClick);
            // 
            // addbtn
            // 
            this.addbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.Location = new System.Drawing.Point(969, 52);
            this.addbtn.Margin = new System.Windows.Forms.Padding(2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(106, 52);
            this.addbtn.TabIndex = 3;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // productmfrtxtbox
            // 
            this.productmfrtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.productmfrtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.productmfrtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productmfrtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productmfrtxtbox.Location = new System.Drawing.Point(175, 42);
            this.productmfrtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.productmfrtxtbox.Name = "productmfrtxtbox";
            this.productmfrtxtbox.Size = new System.Drawing.Size(281, 27);
            this.productmfrtxtbox.TabIndex = 1;
            this.productmfrtxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.producttxtbox_MouseClick);
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtytxtbox.Location = new System.Drawing.Point(175, 73);
            this.qtytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(281, 27);
            this.qtytxtbox.TabIndex = 2;
            // 
            // damagequantitylbl
            // 
            this.damagequantitylbl.AutoSize = true;
            this.damagequantitylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damagequantitylbl.Location = new System.Drawing.Point(33, 77);
            this.damagequantitylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.damagequantitylbl.Name = "damagequantitylbl";
            this.damagequantitylbl.Size = new System.Drawing.Size(129, 18);
            this.damagequantitylbl.TabIndex = 15;
            this.damagequantitylbl.Text = "DAMAGE QUANTITY";
            // 
            // productmfrlbl
            // 
            this.productmfrlbl.AutoSize = true;
            this.productmfrlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productmfrlbl.Location = new System.Drawing.Point(33, 46);
            this.productmfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productmfrlbl.Name = "productmfrlbl";
            this.productmfrlbl.Size = new System.Drawing.Size(97, 18);
            this.productmfrlbl.TabIndex = 13;
            this.productmfrlbl.Text = "PRODUCT MFR";
            // 
            // warehousefromlbl
            // 
            this.warehousefromlbl.AutoSize = true;
            this.warehousefromlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehousefromlbl.Location = new System.Drawing.Point(33, 15);
            this.warehousefromlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehousefromlbl.Name = "warehousefromlbl";
            this.warehousefromlbl.Size = new System.Drawing.Size(126, 18);
            this.warehousefromlbl.TabIndex = 9;
            this.warehousefromlbl.Text = "WAREHOUSE FROM";
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(860, 344);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(67, 13);
            this.warehouseidlbl.TabIndex = 30;
            this.warehouseidlbl.Text = "warehouseid";
            this.warehouseidlbl.Visible = false;
            // 
            // barcodelbl
            // 
            this.barcodelbl.AutoSize = true;
            this.barcodelbl.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodelbl.Location = new System.Drawing.Point(860, 307);
            this.barcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.barcodelbl.Name = "barcodelbl";
            this.barcodelbl.Size = new System.Drawing.Size(44, 14);
            this.barcodelbl.TabIndex = 27;
            this.barcodelbl.Text = "Barcode";
            this.barcodelbl.Visible = false;
            // 
            // upclbl
            // 
            this.upclbl.AutoSize = true;
            this.upclbl.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upclbl.Location = new System.Drawing.Point(860, 326);
            this.upclbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.upclbl.Name = "upclbl";
            this.upclbl.Size = new System.Drawing.Size(29, 14);
            this.upclbl.TabIndex = 26;
            this.upclbl.Text = "UPC";
            this.upclbl.Visible = false;
            // 
            // productnamelbl
            // 
            this.productnamelbl.AutoSize = true;
            this.productnamelbl.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productnamelbl.Location = new System.Drawing.Point(860, 270);
            this.productnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productnamelbl.Name = "productnamelbl";
            this.productnamelbl.Size = new System.Drawing.Size(73, 14);
            this.productnamelbl.TabIndex = 25;
            this.productnamelbl.Text = "Product Name";
            this.productnamelbl.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productidlbl.Location = new System.Drawing.Point(860, 251);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(55, 14);
            this.productidlbl.TabIndex = 24;
            this.productidlbl.Text = "Product Id";
            this.productidlbl.Visible = false;
            // 
            // damageidlbl
            // 
            this.damageidlbl.AutoSize = true;
            this.damageidlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damageidlbl.Location = new System.Drawing.Point(1009, 251);
            this.damageidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.damageidlbl.Name = "damageidlbl";
            this.damageidlbl.Size = new System.Drawing.Size(74, 18);
            this.damageidlbl.TabIndex = 23;
            this.damageidlbl.Text = "Damage ID";
            this.damageidlbl.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.damagecodelbl);
            this.panel3.Controls.Add(this.warehouseidlbl);
            this.panel3.Controls.Add(this.damageidlbl);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.upclbl);
            this.panel3.Controls.Add(this.barcodelbl);
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.descriptionlbl);
            this.panel3.Controls.Add(this.dgvproducts);
            this.panel3.Controls.Add(this.productnamelbl);
            this.panel3.Controls.Add(this.productidlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 146);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1084, 475);
            this.panel3.TabIndex = 2;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(862, 429);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(218, 37);
            this.closebtn.TabIndex = 2;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(862, 388);
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
            this.descriptiontxtbox.Location = new System.Drawing.Point(862, 24);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(219, 226);
            this.descriptiontxtbox.TabIndex = 0;
            this.descriptiontxtbox.Text = "";
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(859, 2);
            this.descriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(90, 18);
            this.descriptionlbl.TabIndex = 10;
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
            this.productbarcode,
            this.damagedqty});
            this.dgvproducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvproducts.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvproducts.Location = new System.Drawing.Point(2, 2);
            this.dgvproducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvproducts.Name = "dgvproducts";
            this.dgvproducts.RowHeadersVisible = false;
            this.dgvproducts.RowHeadersWidth = 51;
            this.dgvproducts.RowTemplate.Height = 24;
            this.dgvproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvproducts.Size = new System.Drawing.Size(852, 470);
            this.dgvproducts.TabIndex = 0;
            this.dgvproducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvproducts_KeyDown);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // damagecodelbl
            // 
            this.damagecodelbl.AutoSize = true;
            this.damagecodelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damagecodelbl.Location = new System.Drawing.Point(970, 270);
            this.damagecodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.damagecodelbl.Name = "damagecodelbl";
            this.damagecodelbl.Size = new System.Drawing.Size(103, 18);
            this.damagecodelbl.TabIndex = 31;
            this.damagecodelbl.Text = "damagecodelbl";
            this.damagecodelbl.Visible = false;
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
            this.productmfr.Visible = false;
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
            // productbarcode
            // 
            this.productbarcode.HeaderText = "BARCODE";
            this.productbarcode.MinimumWidth = 6;
            this.productbarcode.Name = "productbarcode";
            this.productbarcode.Width = 125;
            // 
            // damagedqty
            // 
            this.damagedqty.HeaderText = "QUANTITY";
            this.damagedqty.MinimumWidth = 6;
            this.damagedqty.Name = "damagedqty";
            this.damagedqty.Width = 125;
            // 
            // DamageEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 621);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DamageEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAMAGE ENTRY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DamageEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DamageEntry_KeyDown);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.Label damagequantitylbl;
        private System.Windows.Forms.Label productmfrlbl;
        private System.Windows.Forms.Label warehousefromlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox productmfrtxtbox;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Label damageidlbl;
        private System.Windows.Forms.Label barcodelbl;
        private System.Windows.Forms.Label upclbl;
        private System.Windows.Forms.Label productnamelbl;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.TextBox selectwarehousefromtxtbox;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.DataGridView dgvproducts;
        private System.Windows.Forms.Label damagecodelbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn productupc;
        private System.Windows.Forms.DataGridViewTextBoxColumn productbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn damagedqty;
    }
}