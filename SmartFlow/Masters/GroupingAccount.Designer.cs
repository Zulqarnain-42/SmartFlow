namespace SmartFlow.Masters
{
    partial class GroupingAccount
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
            this.groupingcodelbl = new System.Windows.Forms.Label();
            this.groupingaccountidlbl = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.selectaccounttxtbox = new System.Windows.Forms.TextBox();
            this.selectaccountlbl = new System.Windows.Forms.Label();
            this.descriptiontxtbox = new System.Windows.Forms.TextBox();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.groupingnametxtbox = new System.Windows.Forms.TextBox();
            this.groupingnamelbl = new System.Windows.Forms.Label();
            this.dgvgroupingaccount = new System.Windows.Forms.DataGridView();
            this.accountidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rEMOVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.accountheadidlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgroupingaccount)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(760, 37);
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
            this.headinglbl.Size = new System.Drawing.Size(760, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ACCOUNT GROUPING";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.accountheadidlbl);
            this.panel2.Controls.Add(this.groupingcodelbl);
            this.panel2.Controls.Add(this.groupingaccountidlbl);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Controls.Add(this.accountidlbl);
            this.panel2.Controls.Add(this.selectaccounttxtbox);
            this.panel2.Controls.Add(this.selectaccountlbl);
            this.panel2.Controls.Add(this.descriptiontxtbox);
            this.panel2.Controls.Add(this.descriptionlbl);
            this.panel2.Controls.Add(this.groupingnametxtbox);
            this.panel2.Controls.Add(this.groupingnamelbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 190);
            this.panel2.TabIndex = 1;
            // 
            // groupingcodelbl
            // 
            this.groupingcodelbl.AutoSize = true;
            this.groupingcodelbl.Location = new System.Drawing.Point(467, 32);
            this.groupingcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupingcodelbl.Name = "groupingcodelbl";
            this.groupingcodelbl.Size = new System.Drawing.Size(82, 13);
            this.groupingcodelbl.TabIndex = 29;
            this.groupingcodelbl.Text = "groupingcodelbl";
            this.groupingcodelbl.Visible = false;
            // 
            // groupingaccountidlbl
            // 
            this.groupingaccountidlbl.AutoSize = true;
            this.groupingaccountidlbl.Location = new System.Drawing.Point(465, 16);
            this.groupingaccountidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupingaccountidlbl.Name = "groupingaccountidlbl";
            this.groupingaccountidlbl.Size = new System.Drawing.Size(105, 13);
            this.groupingaccountidlbl.TabIndex = 28;
            this.groupingaccountidlbl.Text = "groupingaccountidlbl";
            this.groupingaccountidlbl.Visible = false;
            // 
            // addbtn
            // 
            this.addbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addbtn.Location = new System.Drawing.Point(464, 145);
            this.addbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(88, 26);
            this.addbtn.TabIndex = 27;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.Location = new System.Drawing.Point(612, 136);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(139, 34);
            this.exitbtn.TabIndex = 25;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(612, 98);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(139, 34);
            this.savebtn.TabIndex = 24;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(610, 62);
            this.accountidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(64, 13);
            this.accountidlbl.TabIndex = 23;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // selectaccounttxtbox
            // 
            this.selectaccounttxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectaccounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectaccounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectaccounttxtbox.Location = new System.Drawing.Point(125, 145);
            this.selectaccounttxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectaccounttxtbox.Name = "selectaccounttxtbox";
            this.selectaccounttxtbox.Size = new System.Drawing.Size(335, 27);
            this.selectaccounttxtbox.TabIndex = 2;
            this.selectaccounttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectaccounttxtbox_MouseClick);
            this.selectaccounttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectaccounttxtbox_KeyDown);
            // 
            // selectaccountlbl
            // 
            this.selectaccountlbl.AutoSize = true;
            this.selectaccountlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectaccountlbl.Location = new System.Drawing.Point(9, 148);
            this.selectaccountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectaccountlbl.Name = "selectaccountlbl";
            this.selectaccountlbl.Size = new System.Drawing.Size(114, 18);
            this.selectaccountlbl.TabIndex = 19;
            this.selectaccountlbl.Text = "SELECT ACCOUNT";
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(125, 39);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptiontxtbox.Multiline = true;
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(335, 101);
            this.descriptiontxtbox.TabIndex = 1;
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(9, 53);
            this.descriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(90, 18);
            this.descriptionlbl.TabIndex = 17;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // groupingnametxtbox
            // 
            this.groupingnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupingnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupingnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupingnametxtbox.Location = new System.Drawing.Point(125, 8);
            this.groupingnametxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupingnametxtbox.Name = "groupingnametxtbox";
            this.groupingnametxtbox.Size = new System.Drawing.Size(335, 27);
            this.groupingnametxtbox.TabIndex = 0;
            // 
            // groupingnamelbl
            // 
            this.groupingnamelbl.AutoSize = true;
            this.groupingnamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupingnamelbl.Location = new System.Drawing.Point(9, 11);
            this.groupingnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupingnamelbl.Name = "groupingnamelbl";
            this.groupingnamelbl.Size = new System.Drawing.Size(116, 18);
            this.groupingnamelbl.TabIndex = 0;
            this.groupingnamelbl.Text = "GROUPING NAME";
            // 
            // dgvgroupingaccount
            // 
            this.dgvgroupingaccount.AllowUserToAddRows = false;
            this.dgvgroupingaccount.AllowUserToDeleteRows = false;
            this.dgvgroupingaccount.AllowUserToResizeColumns = false;
            this.dgvgroupingaccount.AllowUserToResizeRows = false;
            this.dgvgroupingaccount.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvgroupingaccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvgroupingaccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountidcolumn,
            this.accountnamecolumn});
            this.dgvgroupingaccount.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvgroupingaccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvgroupingaccount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvgroupingaccount.Location = new System.Drawing.Point(0, 227);
            this.dgvgroupingaccount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvgroupingaccount.Name = "dgvgroupingaccount";
            this.dgvgroupingaccount.RowHeadersVisible = false;
            this.dgvgroupingaccount.RowHeadersWidth = 51;
            this.dgvgroupingaccount.RowTemplate.Height = 24;
            this.dgvgroupingaccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvgroupingaccount.Size = new System.Drawing.Size(760, 253);
            this.dgvgroupingaccount.TabIndex = 2;
            this.dgvgroupingaccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvgroupingaccount_KeyDown);
            // 
            // accountidcolumn
            // 
            this.accountidcolumn.HeaderText = "ID";
            this.accountidcolumn.MinimumWidth = 6;
            this.accountidcolumn.Name = "accountidcolumn";
            this.accountidcolumn.Width = 125;
            // 
            // accountnamecolumn
            // 
            this.accountnamecolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountnamecolumn.HeaderText = "Account Name";
            this.accountnamecolumn.MinimumWidth = 6;
            this.accountnamecolumn.Name = "accountnamecolumn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEMOVEToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 26);
            // 
            // rEMOVEToolStripMenuItem
            // 
            this.rEMOVEToolStripMenuItem.Name = "rEMOVEToolStripMenuItem";
            this.rEMOVEToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.rEMOVEToolStripMenuItem.Text = "REMOVE";
            this.rEMOVEToolStripMenuItem.Click += new System.EventHandler(this.rEMOVEToolStripMenuItem_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // accountheadidlbl
            // 
            this.accountheadidlbl.AutoSize = true;
            this.accountheadidlbl.Location = new System.Drawing.Point(467, 82);
            this.accountheadidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountheadidlbl.Name = "accountheadidlbl";
            this.accountheadidlbl.Size = new System.Drawing.Size(88, 13);
            this.accountheadidlbl.TabIndex = 30;
            this.accountheadidlbl.Text = "accountheadidlbl";
            this.accountheadidlbl.Visible = false;
            // 
            // GroupingAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(760, 480);
            this.Controls.Add(this.dgvgroupingaccount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GroupingAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT GROUPING";
            this.Load += new System.EventHandler(this.GroupingAccount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GroupingAccount_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgroupingaccount)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label groupingnamelbl;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.TextBox groupingnametxtbox;
        private System.Windows.Forms.TextBox selectaccounttxtbox;
        private System.Windows.Forms.Label selectaccountlbl;
        private System.Windows.Forms.TextBox descriptiontxtbox;
        private System.Windows.Forms.DataGridView dgvgroupingaccount;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label groupingaccountidlbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountnamecolumn;
        private System.Windows.Forms.Label groupingcodelbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rEMOVEToolStripMenuItem;
        private System.Windows.Forms.Label accountheadidlbl;
    }
}