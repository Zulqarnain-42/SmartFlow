namespace SmartFlow.Stock
{
    partial class ListWarehouse
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
            this.dgvlistwarehouse = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehousecodelbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.citytxtbox = new System.Windows.Forms.TextBox();
            this.citylbl = new System.Windows.Forms.Label();
            this.addresstxtbox = new System.Windows.Forms.TextBox();
            this.addresslbl = new System.Windows.Forms.Label();
            this.warehousenametxtbox = new System.Windows.Forms.TextBox();
            this.warehousenamelbl = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.createwarehousesavebtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistwarehouse)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(885, 37);
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
            this.headinglbl.Size = new System.Drawing.Size(885, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "LIST WAREHOUSE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 50);
            this.panel2.TabIndex = 11;
            // 
            // dgvlistwarehouse
            // 
            this.dgvlistwarehouse.AllowUserToAddRows = false;
            this.dgvlistwarehouse.AllowUserToDeleteRows = false;
            this.dgvlistwarehouse.AllowUserToResizeColumns = false;
            this.dgvlistwarehouse.AllowUserToResizeRows = false;
            this.dgvlistwarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlistwarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistwarehouse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvlistwarehouse.Location = new System.Drawing.Point(0, 86);
            this.dgvlistwarehouse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvlistwarehouse.Name = "dgvlistwarehouse";
            this.dgvlistwarehouse.RowHeadersVisible = false;
            this.dgvlistwarehouse.RowHeadersWidth = 51;
            this.dgvlistwarehouse.RowTemplate.Height = 24;
            this.dgvlistwarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlistwarehouse.Size = new System.Drawing.Size(620, 370);
            this.dgvlistwarehouse.TabIndex = 12;
            this.dgvlistwarehouse.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlistwarehouse_CellDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // warehousecodelbl
            // 
            this.warehousecodelbl.AutoSize = true;
            this.warehousecodelbl.Location = new System.Drawing.Point(627, 357);
            this.warehousecodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehousecodelbl.Name = "warehousecodelbl";
            this.warehousecodelbl.Size = new System.Drawing.Size(93, 13);
            this.warehousecodelbl.TabIndex = 41;
            this.warehousecodelbl.Text = "warehousecodelbl";
            this.warehousecodelbl.Visible = false;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(625, 340);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 40;
            this.warehouseidlbl.Text = "warehouseidlbl";
            this.warehouseidlbl.Visible = false;
            // 
            // citytxtbox
            // 
            this.citytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.citytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.citytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.citytxtbox.Location = new System.Drawing.Point(625, 309);
            this.citytxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.citytxtbox.Name = "citytxtbox";
            this.citytxtbox.Size = new System.Drawing.Size(252, 27);
            this.citytxtbox.TabIndex = 39;
            // 
            // citylbl
            // 
            this.citylbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.citylbl.AutoSize = true;
            this.citylbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.citylbl.Location = new System.Drawing.Point(626, 288);
            this.citylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.citylbl.Name = "citylbl";
            this.citylbl.Size = new System.Drawing.Size(35, 18);
            this.citylbl.TabIndex = 38;
            this.citylbl.Text = "City ";
            // 
            // addresstxtbox
            // 
            this.addresstxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addresstxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addresstxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addresstxtbox.Location = new System.Drawing.Point(625, 169);
            this.addresstxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addresstxtbox.Multiline = true;
            this.addresstxtbox.Name = "addresstxtbox";
            this.addresstxtbox.Size = new System.Drawing.Size(252, 117);
            this.addresstxtbox.TabIndex = 37;
            // 
            // addresslbl
            // 
            this.addresslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addresslbl.AutoSize = true;
            this.addresslbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.addresslbl.Location = new System.Drawing.Point(626, 146);
            this.addresslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addresslbl.Name = "addresslbl";
            this.addresslbl.Size = new System.Drawing.Size(61, 18);
            this.addresslbl.TabIndex = 36;
            this.addresslbl.Text = "Address ";
            // 
            // warehousenametxtbox
            // 
            this.warehousenametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warehousenametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warehousenametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehousenametxtbox.Location = new System.Drawing.Point(625, 118);
            this.warehousenametxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.warehousenametxtbox.Name = "warehousenametxtbox";
            this.warehousenametxtbox.Size = new System.Drawing.Size(252, 27);
            this.warehousenametxtbox.TabIndex = 35;
            // 
            // warehousenamelbl
            // 
            this.warehousenamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warehousenamelbl.AutoSize = true;
            this.warehousenamelbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.warehousenamelbl.Location = new System.Drawing.Point(626, 97);
            this.warehousenamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehousenamelbl.Name = "warehousenamelbl";
            this.warehousenamelbl.Size = new System.Drawing.Size(121, 18);
            this.warehousenamelbl.TabIndex = 34;
            this.warehousenamelbl.Text = "Warehouse Name ";
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.exitbtn.Location = new System.Drawing.Point(625, 414);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(251, 32);
            this.exitbtn.TabIndex = 43;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // createwarehousesavebtn
            // 
            this.createwarehousesavebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createwarehousesavebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createwarehousesavebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.createwarehousesavebtn.Location = new System.Drawing.Point(625, 377);
            this.createwarehousesavebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createwarehousesavebtn.Name = "createwarehousesavebtn";
            this.createwarehousesavebtn.Size = new System.Drawing.Size(251, 32);
            this.createwarehousesavebtn.TabIndex = 42;
            this.createwarehousesavebtn.Text = "Save";
            this.createwarehousesavebtn.UseVisualStyleBackColor = true;
            this.createwarehousesavebtn.Click += new System.EventHandler(this.createwarehousesavebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ListWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 457);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.createwarehousesavebtn);
            this.Controls.Add(this.warehousecodelbl);
            this.Controls.Add(this.warehouseidlbl);
            this.Controls.Add(this.citytxtbox);
            this.Controls.Add(this.citylbl);
            this.Controls.Add(this.addresstxtbox);
            this.Controls.Add(this.addresslbl);
            this.Controls.Add(this.warehousenametxtbox);
            this.Controls.Add(this.warehousenamelbl);
            this.Controls.Add(this.dgvlistwarehouse);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ListWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListWarehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ListWarehouse_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistwarehouse)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvlistwarehouse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.Label warehousecodelbl;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.TextBox citytxtbox;
        private System.Windows.Forms.Label citylbl;
        private System.Windows.Forms.TextBox addresstxtbox;
        private System.Windows.Forms.Label addresslbl;
        private System.Windows.Forms.TextBox warehousenametxtbox;
        private System.Windows.Forms.Label warehousenamelbl;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button createwarehousesavebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}