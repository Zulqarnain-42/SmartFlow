namespace SmartFlow.Masters
{
    partial class AccountHead
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
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.accountheadtxtbox = new System.Windows.Forms.TextBox();
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvaccounthead = new System.Windows.Forms.DataGridView();
            this.accountid = new System.Windows.Forms.Label();
            this.UNITNAMELBL = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gridViewMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaccounthead)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(1326, 129);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(250, 35);
            this.exitbtn.TabIndex = 3;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1326, 88);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(250, 35);
            this.savebtn.TabIndex = 2;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // accountheadtxtbox
            // 
            this.accountheadtxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountheadtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountheadtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountheadtxtbox.Location = new System.Drawing.Point(1326, 52);
            this.accountheadtxtbox.Name = "accountheadtxtbox";
            this.accountheadtxtbox.Size = new System.Drawing.Size(250, 32);
            this.accountheadtxtbox.TabIndex = 1;
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
            // dgvaccounthead
            // 
            this.dgvaccounthead.AllowUserToAddRows = false;
            this.dgvaccounthead.AllowUserToResizeRows = false;
            this.dgvaccounthead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvaccounthead.BackgroundColor = System.Drawing.Color.White;
            this.dgvaccounthead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvaccounthead.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvaccounthead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaccounthead.ContextMenuStrip = this.gridViewMenuStrip;
            this.dgvaccounthead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvaccounthead.Location = new System.Drawing.Point(3, 3);
            this.dgvaccounthead.MultiSelect = false;
            this.dgvaccounthead.Name = "dgvaccounthead";
            this.dgvaccounthead.ReadOnly = true;
            this.dgvaccounthead.RowHeadersVisible = false;
            this.dgvaccounthead.RowHeadersWidth = 51;
            this.dgvaccounthead.RowTemplate.Height = 24;
            this.dgvaccounthead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvaccounthead.Size = new System.Drawing.Size(1313, 673);
            this.dgvaccounthead.TabIndex = 0;
            this.dgvaccounthead.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvaccounthead_Scroll);
            // 
            // accountid
            // 
            this.accountid.AutoSize = true;
            this.accountid.Location = new System.Drawing.Point(1511, 26);
            this.accountid.Name = "accountid";
            this.accountid.Size = new System.Drawing.Size(65, 16);
            this.accountid.TabIndex = 2;
            this.accountid.Text = "accountid";
            this.accountid.Visible = false;
            // 
            // UNITNAMELBL
            // 
            this.UNITNAMELBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UNITNAMELBL.AutoSize = true;
            this.UNITNAMELBL.Font = new System.Drawing.Font("Calibri", 11F);
            this.UNITNAMELBL.Location = new System.Drawing.Point(1322, 26);
            this.UNITNAMELBL.Name = "UNITNAMELBL";
            this.UNITNAMELBL.Size = new System.Drawing.Size(139, 23);
            this.UNITNAMELBL.TabIndex = 0;
            this.UNITNAMELBL.Text = "ACCOUNT NAME";
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(94, 6);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(500, 32);
            this.searchtxtbox.TabIndex = 0;
            // 
            // searchlbl
            // 
            this.searchlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.searchlbl.Location = new System.Drawing.Point(8, 10);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(71, 23);
            this.searchlbl.TabIndex = 0;
            this.searchlbl.Text = "SEARCH";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1594, 45);
            this.panel1.TabIndex = 22;
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
            this.label1.Text = "ACCOUNT HEAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchtxtbox);
            this.panel2.Controls.Add(this.searchlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1594, 46);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.accountid);
            this.panel3.Controls.Add(this.dgvaccounthead);
            this.panel3.Controls.Add(this.exitbtn);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.UNITNAMELBL);
            this.panel3.Controls.Add(this.accountheadtxtbox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1594, 679);
            this.panel3.TabIndex = 24;
            // 
            // AccountHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1594, 770);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountHead";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT HEAD - FUTURE ART BROADCAST TRADING LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountHead_FormClosing);
            this.Load += new System.EventHandler(this.AccountHead_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountHead_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gridViewMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaccounthead)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.DataGridView dgvaccounthead;
        private System.Windows.Forms.ContextMenuStrip gridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox accountheadtxtbox;
        private System.Windows.Forms.Label UNITNAMELBL;
        private System.Windows.Forms.Label accountid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}