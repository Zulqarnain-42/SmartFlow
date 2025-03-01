namespace SmartFlow.Stock
{
    partial class ListRacks
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.rackidlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.dgvListRack = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.rackcodetxtbox = new System.Windows.Forms.TextBox();
            this.rackcodelbl = new System.Windows.Forms.Label();
            this.racklocationdescriptionlbl = new System.Windows.Forms.Label();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRack)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.racklocationdescriptionlbl);
            this.panel3.Controls.Add(this.rackcodetxtbox);
            this.panel3.Controls.Add(this.rackcodelbl);
            this.panel3.Controls.Add(this.warehouseidlbl);
            this.panel3.Controls.Add(this.selectwarehousetxtbox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.rackidlbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.dgvListRack);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(885, 384);
            this.panel3.TabIndex = 10;
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(627, 26);
            this.selectwarehousetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(249, 27);
            this.selectwarehousetxtbox.TabIndex = 69;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(627, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "SELECT WAREHOUSE";
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(628, 345);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(248, 29);
            this.closebtn.TabIndex = 67;
            this.closebtn.Text = "EXIT";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // rackidlbl
            // 
            this.rackidlbl.AutoSize = true;
            this.rackidlbl.Location = new System.Drawing.Point(628, 264);
            this.rackidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rackidlbl.Name = "rackidlbl";
            this.rackidlbl.Size = new System.Drawing.Size(46, 13);
            this.rackidlbl.TabIndex = 65;
            this.rackidlbl.Text = "rackidlbl";
            this.rackidlbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(628, 312);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(248, 29);
            this.savebtn.TabIndex = 60;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // dgvListRack
            // 
            this.dgvListRack.AllowUserToAddRows = false;
            this.dgvListRack.AllowUserToDeleteRows = false;
            this.dgvListRack.AllowUserToResizeColumns = false;
            this.dgvListRack.AllowUserToResizeRows = false;
            this.dgvListRack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListRack.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListRack.CausesValidation = false;
            this.dgvListRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRack.ColumnHeadersVisible = false;
            this.dgvListRack.ContextMenuStrip = this.contextMenuStrip;
            this.dgvListRack.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListRack.Location = new System.Drawing.Point(0, 2);
            this.dgvListRack.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListRack.Name = "dgvListRack";
            this.dgvListRack.RowHeadersWidth = 51;
            this.dgvListRack.RowTemplate.Height = 24;
            this.dgvListRack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListRack.Size = new System.Drawing.Size(623, 379);
            this.dgvListRack.TabIndex = 2;
            this.dgvListRack.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRack_CellDoubleClick);
            this.dgvListRack.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvListRack_Scroll);
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
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
            this.headinglbl.Text = "LIST RACKS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 37);
            this.panel1.TabIndex = 9;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(628, 286);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 70;
            this.warehouseidlbl.Text = "warehouseidlbl";
            this.warehouseidlbl.Visible = false;
            // 
            // rackcodetxtbox
            // 
            this.rackcodetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rackcodetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rackcodetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rackcodetxtbox.Location = new System.Drawing.Point(627, 82);
            this.rackcodetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.rackcodetxtbox.Name = "rackcodetxtbox";
            this.rackcodetxtbox.ReadOnly = true;
            this.rackcodetxtbox.Size = new System.Drawing.Size(249, 27);
            this.rackcodetxtbox.TabIndex = 71;
            // 
            // rackcodelbl
            // 
            this.rackcodelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rackcodelbl.AutoSize = true;
            this.rackcodelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rackcodelbl.Location = new System.Drawing.Point(627, 60);
            this.rackcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rackcodelbl.Name = "rackcodelbl";
            this.rackcodelbl.Size = new System.Drawing.Size(78, 18);
            this.rackcodelbl.TabIndex = 72;
            this.rackcodelbl.Text = "RACK CODE";
            // 
            // racklocationdescriptionlbl
            // 
            this.racklocationdescriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.racklocationdescriptionlbl.AutoSize = true;
            this.racklocationdescriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.racklocationdescriptionlbl.Location = new System.Drawing.Point(627, 120);
            this.racklocationdescriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.racklocationdescriptionlbl.Name = "racklocationdescriptionlbl";
            this.racklocationdescriptionlbl.Size = new System.Drawing.Size(107, 18);
            this.racklocationdescriptionlbl.TabIndex = 73;
            this.racklocationdescriptionlbl.Text = "RACK LOCATION";
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(627, 140);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(249, 122);
            this.descriptiontxtbox.TabIndex = 74;
            this.descriptiontxtbox.Text = "";
            // 
            // ListRacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 421);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ListRacks";
            this.Text = "LIST RACKS";
            this.Load += new System.EventHandler(this.ListRacks_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListRacks_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRack)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label rackidlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.DataGridView dgvListRack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.TextBox rackcodetxtbox;
        private System.Windows.Forms.Label rackcodelbl;
        private System.Windows.Forms.Label racklocationdescriptionlbl;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
    }
}