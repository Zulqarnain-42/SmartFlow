namespace SmartFlow.Stock
{
    partial class QtyUsingScanner
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
            this.barcodelbl = new System.Windows.Forms.Label();
            this.searchtextbox = new System.Windows.Forms.TextBox();
            this.dgvinventory = new System.Windows.Forms.DataGridView();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productupc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.savebtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.qtyusingscanneridlbl = new System.Windows.Forms.Label();
            this.warehouselbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.importantnoteslbl = new System.Windows.Forms.Label();
            this.importantnotestxtbox = new System.Windows.Forms.RichTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerBarcode = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvinventory)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // barcodelbl
            // 
            this.barcodelbl.AutoSize = true;
            this.barcodelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodelbl.Location = new System.Drawing.Point(9, 36);
            this.barcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.barcodelbl.Name = "barcodelbl";
            this.barcodelbl.Size = new System.Drawing.Size(121, 18);
            this.barcodelbl.TabIndex = 0;
            this.barcodelbl.Text = "SEARCH BARCODE ";
            // 
            // searchtextbox
            // 
            this.searchtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtextbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtextbox.Location = new System.Drawing.Point(165, 32);
            this.searchtextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchtextbox.Name = "searchtextbox";
            this.searchtextbox.Size = new System.Drawing.Size(376, 27);
            this.searchtextbox.TabIndex = 1;
            this.searchtextbox.TextChanged += new System.EventHandler(this.searchtextbox_TextChanged);
            // 
            // dgvinventory
            // 
            this.dgvinventory.AllowUserToAddRows = false;
            this.dgvinventory.AllowUserToDeleteRows = false;
            this.dgvinventory.AllowUserToResizeColumns = false;
            this.dgvinventory.AllowUserToResizeRows = false;
            this.dgvinventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvinventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvinventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvinventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productid,
            this.productname,
            this.productupc,
            this.productmfr,
            this.barcode,
            this.quantity});
            this.dgvinventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvinventory.Location = new System.Drawing.Point(2, 3);
            this.dgvinventory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvinventory.Name = "dgvinventory";
            this.dgvinventory.RowHeadersVisible = false;
            this.dgvinventory.RowHeadersWidth = 51;
            this.dgvinventory.RowTemplate.Height = 24;
            this.dgvinventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvinventory.Size = new System.Drawing.Size(922, 522);
            this.dgvinventory.TabIndex = 45;
            this.dgvinventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvinventory_CellDoubleClick);
            this.dgvinventory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvinventory_CellEndEdit);
            this.dgvinventory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvinventory_KeyDown);
            // 
            // productid
            // 
            this.productid.HeaderText = "ID";
            this.productid.MinimumWidth = 6;
            this.productid.Name = "productid";
            this.productid.Width = 125;
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
            // productmfr
            // 
            this.productmfr.HeaderText = "MFR";
            this.productmfr.MinimumWidth = 6;
            this.productmfr.Name = "productmfr";
            this.productmfr.Width = 125;
            // 
            // barcode
            // 
            this.barcode.HeaderText = "BARCODE";
            this.barcode.MinimumWidth = 6;
            this.barcode.Name = "barcode";
            this.barcode.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "QUANTITY";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 125;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(928, 460);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(265, 30);
            this.savebtn.TabIndex = 46;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(928, 495);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(265, 30);
            this.exitbtn.TabIndex = 47;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 37);
            this.panel1.TabIndex = 48;
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
            this.headinglbl.Size = new System.Drawing.Size(1196, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "INVENTORY USING SCANNER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.warehouseidlbl);
            this.panel2.Controls.Add(this.selectwarehousetxtbox);
            this.panel2.Controls.Add(this.qtyusingscanneridlbl);
            this.panel2.Controls.Add(this.warehouselbl);
            this.panel2.Controls.Add(this.barcodelbl);
            this.panel2.Controls.Add(this.searchtextbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 62);
            this.panel2.TabIndex = 49;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(548, 20);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(67, 13);
            this.warehouseidlbl.TabIndex = 6;
            this.warehouseidlbl.Text = "warehouseid";
            this.warehouseidlbl.Visible = false;
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousetxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(165, 4);
            this.selectwarehousetxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(376, 27);
            this.selectwarehousetxtbox.TabIndex = 5;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // qtyusingscanneridlbl
            // 
            this.qtyusingscanneridlbl.AutoSize = true;
            this.qtyusingscanneridlbl.Location = new System.Drawing.Point(545, 3);
            this.qtyusingscanneridlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qtyusingscanneridlbl.Name = "qtyusingscanneridlbl";
            this.qtyusingscanneridlbl.Size = new System.Drawing.Size(92, 13);
            this.qtyusingscanneridlbl.TabIndex = 4;
            this.qtyusingscanneridlbl.Text = "qtyusingscannerid";
            this.qtyusingscanneridlbl.Visible = false;
            // 
            // warehouselbl
            // 
            this.warehouselbl.AutoSize = true;
            this.warehouselbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouselbl.Location = new System.Drawing.Point(9, 7);
            this.warehouselbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouselbl.Name = "warehouselbl";
            this.warehouselbl.Size = new System.Drawing.Size(86, 18);
            this.warehouselbl.TabIndex = 2;
            this.warehouselbl.Text = "WAREHOUSE";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvinventory);
            this.panel3.Controls.Add(this.importantnoteslbl);
            this.panel3.Controls.Add(this.importantnotestxtbox);
            this.panel3.Controls.Add(this.exitbtn);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 99);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1196, 527);
            this.panel3.TabIndex = 50;
            // 
            // importantnoteslbl
            // 
            this.importantnoteslbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importantnoteslbl.AutoSize = true;
            this.importantnoteslbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importantnoteslbl.Location = new System.Drawing.Point(928, 3);
            this.importantnoteslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.importantnoteslbl.Name = "importantnoteslbl";
            this.importantnoteslbl.Size = new System.Drawing.Size(126, 18);
            this.importantnoteslbl.TabIndex = 49;
            this.importantnoteslbl.Text = "IMPORTANT NOTES";
            // 
            // importantnotestxtbox
            // 
            this.importantnotestxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importantnotestxtbox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importantnotestxtbox.Location = new System.Drawing.Point(929, 31);
            this.importantnotestxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importantnotestxtbox.Name = "importantnotestxtbox";
            this.importantnotestxtbox.Size = new System.Drawing.Size(258, 282);
            this.importantnotestxtbox.TabIndex = 48;
            this.importantnotestxtbox.Text = "";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // QtyUsingScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1196, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QtyUsingScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE INVENTORY USING SCANNER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QtyUsingScanner_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QtyUsingScanner_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvinventory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label barcodelbl;
        private System.Windows.Forms.TextBox searchtextbox;
        private System.Windows.Forms.DataGridView dgvinventory;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label warehouselbl;
        private System.Windows.Forms.Label importantnoteslbl;
        private System.Windows.Forms.RichTextBox importantnotestxtbox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label qtyusingscanneridlbl;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Timer timerBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn productupc;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
    }
}