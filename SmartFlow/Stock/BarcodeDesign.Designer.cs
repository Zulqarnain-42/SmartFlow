namespace SmartFlow.Stock
{
    partial class BarcodeDesign
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.qtybarcode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.productmfrlbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.generatebtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvbarcodeproducts = new System.Windows.Forms.DataGridView();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbarcodeproducts)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // selectproductlbl
            // 
            this.selectproductlbl.AutoSize = true;
            this.selectproductlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproductlbl.Location = new System.Drawing.Point(9, 9);
            this.selectproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(112, 18);
            this.selectproductlbl.TabIndex = 4;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "NO OF BARCODES";
            // 
            // qtybarcode
            // 
            this.qtybarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtybarcode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtybarcode.Location = new System.Drawing.Point(130, 36);
            this.qtybarcode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.qtybarcode.Name = "qtybarcode";
            this.qtybarcode.Size = new System.Drawing.Size(376, 27);
            this.qtybarcode.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 37);
            this.panel1.TabIndex = 46;
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
            this.headinglbl.Size = new System.Drawing.Size(838, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "BARCODE DESIGN";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectproducttxtbox);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.selectproductlbl);
            this.panel2.Controls.Add(this.qtybarcode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 71);
            this.panel2.TabIndex = 47;
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectproducttxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(130, 5);
            this.selectproducttxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(376, 27);
            this.selectproducttxtbox.TabIndex = 0;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // addbtn
            // 
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.Location = new System.Drawing.Point(750, 5);
            this.addbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(79, 57);
            this.addbtn.TabIndex = 2;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // productmfrlbl
            // 
            this.productmfrlbl.AutoSize = true;
            this.productmfrlbl.Location = new System.Drawing.Point(0, 464);
            this.productmfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productmfrlbl.Name = "productmfrlbl";
            this.productmfrlbl.Size = new System.Drawing.Size(57, 13);
            this.productmfrlbl.TabIndex = 51;
            this.productmfrlbl.Text = "productmfr";
            this.productmfrlbl.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(0, 449);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(51, 13);
            this.productidlbl.TabIndex = 50;
            this.productidlbl.Text = "productid";
            this.productidlbl.Visible = false;
            // 
            // generatebtn
            // 
            this.generatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generatebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generatebtn.Location = new System.Drawing.Point(611, 428);
            this.generatebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generatebtn.Name = "generatebtn";
            this.generatebtn.Size = new System.Drawing.Size(218, 49);
            this.generatebtn.TabIndex = 5;
            this.generatebtn.Text = "GENERATE BARCODE";
            this.generatebtn.UseVisualStyleBackColor = true;
            this.generatebtn.Click += new System.EventHandler(this.generatebtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvbarcodeproducts);
            this.panel3.Location = new System.Drawing.Point(0, 113);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(838, 310);
            this.panel3.TabIndex = 51;
            // 
            // dgvbarcodeproducts
            // 
            this.dgvbarcodeproducts.AllowUserToAddRows = false;
            this.dgvbarcodeproducts.AllowUserToDeleteRows = false;
            this.dgvbarcodeproducts.AllowUserToResizeColumns = false;
            this.dgvbarcodeproducts.AllowUserToResizeRows = false;
            this.dgvbarcodeproducts.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvbarcodeproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbarcodeproducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productid,
            this.productmfr,
            this.productname,
            this.barcodeqty});
            this.dgvbarcodeproducts.Location = new System.Drawing.Point(2, 2);
            this.dgvbarcodeproducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvbarcodeproducts.Name = "dgvbarcodeproducts";
            this.dgvbarcodeproducts.RowHeadersVisible = false;
            this.dgvbarcodeproducts.RowHeadersWidth = 51;
            this.dgvbarcodeproducts.RowTemplate.Height = 24;
            this.dgvbarcodeproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbarcodeproducts.Size = new System.Drawing.Size(833, 306);
            this.dgvbarcodeproducts.TabIndex = 0;
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
            // barcodeqty
            // 
            this.barcodeqty.HeaderText = "QTY";
            this.barcodeqty.MinimumWidth = 6;
            this.barcodeqty.Name = "barcodeqty";
            this.barcodeqty.Width = 125;
            // 
            // BarcodeDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(838, 482);
            this.Controls.Add(this.productmfrlbl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.productidlbl);
            this.Controls.Add(this.generatebtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BarcodeDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BARCODE DESIGN";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarcodeDesign_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbarcodeproducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label selectproductlbl;
        private System.Windows.Forms.TextBox qtybarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Button generatebtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvbarcodeproducts;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeqty;
        private System.Windows.Forms.Label productmfrlbl;
    }
}