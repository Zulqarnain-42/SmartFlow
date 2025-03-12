namespace SmartFlow.Stock
{
    partial class Shelf
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
            this.shelfcodetxtbox = new System.Windows.Forms.TextBox();
            this.rackcodelbl = new System.Windows.Forms.Label();
            this.rackidlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closebtn = new System.Windows.Forms.Button();
            this.shelfidlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.dgvListShelf = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectrackcombo = new System.Windows.Forms.ComboBox();
            this.dELETEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListShelf)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 37);
            this.panel1.TabIndex = 11;
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
            this.headinglbl.Text = "LIST SHELF";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shelfcodetxtbox
            // 
            this.shelfcodetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shelfcodetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shelfcodetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shelfcodetxtbox.Location = new System.Drawing.Point(627, 110);
            this.shelfcodetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.shelfcodetxtbox.Name = "shelfcodetxtbox";
            this.shelfcodetxtbox.ReadOnly = true;
            this.shelfcodetxtbox.Size = new System.Drawing.Size(249, 27);
            this.shelfcodetxtbox.TabIndex = 71;
            // 
            // rackcodelbl
            // 
            this.rackcodelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rackcodelbl.AutoSize = true;
            this.rackcodelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rackcodelbl.Location = new System.Drawing.Point(627, 90);
            this.rackcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rackcodelbl.Name = "rackcodelbl";
            this.rackcodelbl.Size = new System.Drawing.Size(81, 18);
            this.rackcodelbl.TabIndex = 72;
            this.rackcodelbl.Text = "SHELF CODE";
            // 
            // rackidlbl
            // 
            this.rackidlbl.AutoSize = true;
            this.rackidlbl.Location = new System.Drawing.Point(627, 170);
            this.rackidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rackidlbl.Name = "rackidlbl";
            this.rackidlbl.Size = new System.Drawing.Size(46, 13);
            this.rackidlbl.TabIndex = 70;
            this.rackidlbl.Text = "rackidlbl";
            this.rackidlbl.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(625, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "SELECT RACK";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem,
            this.dELETEToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(114, 48);
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(628, 382);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(248, 29);
            this.closebtn.TabIndex = 67;
            this.closebtn.Text = "EXIT";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // shelfidlbl
            // 
            this.shelfidlbl.AutoSize = true;
            this.shelfidlbl.Location = new System.Drawing.Point(627, 148);
            this.shelfidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shelfidlbl.Name = "shelfidlbl";
            this.shelfidlbl.Size = new System.Drawing.Size(47, 13);
            this.shelfidlbl.TabIndex = 65;
            this.shelfidlbl.Text = "shelfidlbl";
            this.shelfidlbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(628, 349);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(248, 29);
            this.savebtn.TabIndex = 60;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // dgvListShelf
            // 
            this.dgvListShelf.AllowUserToAddRows = false;
            this.dgvListShelf.AllowUserToDeleteRows = false;
            this.dgvListShelf.AllowUserToResizeColumns = false;
            this.dgvListShelf.AllowUserToResizeRows = false;
            this.dgvListShelf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListShelf.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListShelf.CausesValidation = false;
            this.dgvListShelf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListShelf.ColumnHeadersVisible = false;
            this.dgvListShelf.ContextMenuStrip = this.contextMenuStrip;
            this.dgvListShelf.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListShelf.Location = new System.Drawing.Point(0, 41);
            this.dgvListShelf.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListShelf.Name = "dgvListShelf";
            this.dgvListShelf.RowHeadersWidth = 51;
            this.dgvListShelf.RowTemplate.Height = 24;
            this.dgvListShelf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListShelf.Size = new System.Drawing.Size(623, 377);
            this.dgvListShelf.TabIndex = 2;
            this.dgvListShelf.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListShelf_CellDoubleClick);
            this.dgvListShelf.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvListShelf_Scroll);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.selectrackcombo);
            this.panel3.Controls.Add(this.shelfcodetxtbox);
            this.panel3.Controls.Add(this.rackcodelbl);
            this.panel3.Controls.Add(this.rackidlbl);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.shelfidlbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.dgvListShelf);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(885, 421);
            this.panel3.TabIndex = 12;
            // 
            // selectrackcombo
            // 
            this.selectrackcombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectrackcombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.selectrackcombo.Font = new System.Drawing.Font("Calibri", 12F);
            this.selectrackcombo.FormattingEnabled = true;
            this.selectrackcombo.Location = new System.Drawing.Point(627, 63);
            this.selectrackcombo.Name = "selectrackcombo";
            this.selectrackcombo.Size = new System.Drawing.Size(249, 27);
            this.selectrackcombo.TabIndex = 73;
            // 
            // dELETEToolStripMenuItem
            // 
            this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
            this.dELETEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dELETEToolStripMenuItem.Text = "DELETE";
            this.dELETEToolStripMenuItem.Click += new System.EventHandler(this.dELETEToolStripMenuItem_Click);
            // 
            // Shelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 421);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Shelf";
            this.Text = "LIST SHELF";
            this.Load += new System.EventHandler(this.Shelf_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListShelf)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.TextBox shelfcodetxtbox;
        private System.Windows.Forms.Label rackcodelbl;
        private System.Windows.Forms.Label rackidlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label shelfidlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.DataGridView dgvListShelf;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ComboBox selectrackcombo;
        private System.Windows.Forms.ToolStripMenuItem dELETEToolStripMenuItem;
    }
}