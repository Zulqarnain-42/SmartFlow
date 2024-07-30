namespace SmartFlow.Masters
{
    partial class Customers
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
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.customerdatagridview = new System.Windows.Forms.DataGridView();
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerdatagridview)).BeginInit();
            this.gridViewMenuStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(80, 65);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(822, 32);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.searchlbl.Location = new System.Drawing.Point(5, 69);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(66, 23);
            this.searchlbl.TabIndex = 3;
            this.searchlbl.Text = "Search ";
            // 
            // customerdatagridview
            // 
            this.customerdatagridview.AllowUserToAddRows = false;
            this.customerdatagridview.AllowUserToResizeRows = false;
            this.customerdatagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerdatagridview.BackgroundColor = System.Drawing.Color.White;
            this.customerdatagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerdatagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.customerdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerdatagridview.ContextMenuStrip = this.gridViewMenuStrip;
            this.customerdatagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerdatagridview.Location = new System.Drawing.Point(-5, 101);
            this.customerdatagridview.MultiSelect = false;
            this.customerdatagridview.Name = "customerdatagridview";
            this.customerdatagridview.ReadOnly = true;
            this.customerdatagridview.RowHeadersVisible = false;
            this.customerdatagridview.RowHeadersWidth = 51;
            this.customerdatagridview.RowTemplate.Height = 24;
            this.customerdatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerdatagridview.Size = new System.Drawing.Size(1599, 611);
            this.customerdatagridview.TabIndex = 1;
            this.customerdatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerdatagridview_CellDoubleClick);
            this.customerdatagridview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.customerdatagridview_Scroll);
            // 
            // gridViewMenuStrip
            // 
            this.gridViewMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gridViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.gridViewMenuStrip.Name = "gridViewMenuStrip";
            this.gridViewMenuStrip.Size = new System.Drawing.Size(105, 28);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.newbtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 714);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1594, 56);
            this.panel3.TabIndex = 14;
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.closebtn.Location = new System.Drawing.Point(1195, 5);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(192, 48);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.BackColor = System.Drawing.Color.SpringGreen;
            this.newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.newbtn.Location = new System.Drawing.Point(1393, 5);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(192, 48);
            this.newbtn.TabIndex = 0;
            this.newbtn.Text = "NEW";
            this.newbtn.UseVisualStyleBackColor = false;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1594, 45);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1594, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUSTOMERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1594, 770);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchtxtbox);
            this.Controls.Add(this.searchlbl);
            this.Controls.Add(this.customerdatagridview);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER LIST - FUTURE ART BROADCAST TRADING LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customers_FormClosing);
            this.Load += new System.EventHandler(this.Customers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Customers_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.customerdatagridview)).EndInit();
            this.gridViewMenuStrip.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.DataGridView customerdatagridview;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.ContextMenuStrip gridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}