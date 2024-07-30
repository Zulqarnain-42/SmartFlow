namespace SmartFlow.Masters
{
    partial class AccountGroupHistory
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
            this.accountgroupdatagridview = new System.Windows.Forms.DataGridView();
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountgroupid = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.aliastxtbox = new System.Windows.Forms.TextBox();
            this.groupnametxtbox = new System.Windows.Forms.TextBox();
            this.primarygrouplbl = new System.Windows.Forms.Label();
            this.aliaslbl = new System.Windows.Forms.Label();
            this.groupnamelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.selectprimarygrouptxtbox = new System.Windows.Forms.TextBox();
            this.closebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accountgroupdatagridview)).BeginInit();
            this.gridViewMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(106, 6);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(500, 32);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            // 
            // searchlbl
            // 
            this.searchlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.searchlbl.Location = new System.Drawing.Point(21, 10);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(66, 23);
            this.searchlbl.TabIndex = 3;
            this.searchlbl.Text = "Search ";
            // 
            // accountgroupdatagridview
            // 
            this.accountgroupdatagridview.AllowUserToAddRows = false;
            this.accountgroupdatagridview.AllowUserToResizeRows = false;
            this.accountgroupdatagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountgroupdatagridview.BackgroundColor = System.Drawing.Color.White;
            this.accountgroupdatagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.accountgroupdatagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.accountgroupdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountgroupdatagridview.ContextMenuStrip = this.gridViewMenuStrip;
            this.accountgroupdatagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.accountgroupdatagridview.Location = new System.Drawing.Point(6, 0);
            this.accountgroupdatagridview.MultiSelect = false;
            this.accountgroupdatagridview.Name = "accountgroupdatagridview";
            this.accountgroupdatagridview.ReadOnly = true;
            this.accountgroupdatagridview.RowHeadersVisible = false;
            this.accountgroupdatagridview.RowHeadersWidth = 51;
            this.accountgroupdatagridview.RowTemplate.Height = 24;
            this.accountgroupdatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountgroupdatagridview.Size = new System.Drawing.Size(1296, 682);
            this.accountgroupdatagridview.TabIndex = 0;
            this.accountgroupdatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountgroupdatagridview_CellDoubleClick);
            this.accountgroupdatagridview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.accountgroupdatagridview_Scroll);
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
            // accountgroupid
            // 
            this.accountgroupid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountgroupid.AutoSize = true;
            this.accountgroupid.Location = new System.Drawing.Point(1485, 10);
            this.accountgroupid.Name = "accountgroupid";
            this.accountgroupid.Size = new System.Drawing.Size(100, 16);
            this.accountgroupid.TabIndex = 41;
            this.accountgroupid.Text = "accountgroupid";
            this.accountgroupid.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1309, 468);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(276, 45);
            this.savebtn.TabIndex = 4;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // aliastxtbox
            // 
            this.aliastxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aliastxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aliastxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliastxtbox.Location = new System.Drawing.Point(1309, 88);
            this.aliastxtbox.Name = "aliastxtbox";
            this.aliastxtbox.Size = new System.Drawing.Size(276, 32);
            this.aliastxtbox.TabIndex = 2;
            // 
            // groupnametxtbox
            // 
            this.groupnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupnametxtbox.Location = new System.Drawing.Point(1309, 29);
            this.groupnametxtbox.Name = "groupnametxtbox";
            this.groupnametxtbox.Size = new System.Drawing.Size(276, 32);
            this.groupnametxtbox.TabIndex = 1;
            this.groupnametxtbox.TextChanged += new System.EventHandler(this.groupnametxtbox_TextChanged);
            // 
            // primarygrouplbl
            // 
            this.primarygrouplbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.primarygrouplbl.AutoSize = true;
            this.primarygrouplbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.primarygrouplbl.Location = new System.Drawing.Point(1305, 121);
            this.primarygrouplbl.Name = "primarygrouplbl";
            this.primarygrouplbl.Size = new System.Drawing.Size(124, 23);
            this.primarygrouplbl.TabIndex = 35;
            this.primarygrouplbl.Text = "Primary Group";
            // 
            // aliaslbl
            // 
            this.aliaslbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aliaslbl.AutoSize = true;
            this.aliaslbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.aliaslbl.Location = new System.Drawing.Point(1308, 62);
            this.aliaslbl.Name = "aliaslbl";
            this.aliaslbl.Size = new System.Drawing.Size(46, 23);
            this.aliaslbl.TabIndex = 34;
            this.aliaslbl.Text = "Alias";
            // 
            // groupnamelbl
            // 
            this.groupnamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupnamelbl.AutoSize = true;
            this.groupnamelbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.groupnamelbl.Location = new System.Drawing.Point(1305, 3);
            this.groupnamelbl.Name = "groupnamelbl";
            this.groupnamelbl.Size = new System.Drawing.Size(112, 23);
            this.groupnamelbl.TabIndex = 33;
            this.groupnamelbl.Text = "Group Name ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1594, 45);
            this.panel2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1594, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "ACCOUNT GROUPS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.searchtxtbox);
            this.panel4.Controls.Add(this.searchlbl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1594, 40);
            this.panel4.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.selectprimarygrouptxtbox);
            this.panel5.Controls.Add(this.closebtn);
            this.panel5.Controls.Add(this.accountgroupid);
            this.panel5.Controls.Add(this.accountgroupdatagridview);
            this.panel5.Controls.Add(this.groupnamelbl);
            this.panel5.Controls.Add(this.savebtn);
            this.panel5.Controls.Add(this.aliaslbl);
            this.panel5.Controls.Add(this.aliastxtbox);
            this.panel5.Controls.Add(this.primarygrouplbl);
            this.panel5.Controls.Add(this.groupnametxtbox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 85);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1594, 685);
            this.panel5.TabIndex = 18;
            // 
            // selectprimarygrouptxtbox
            // 
            this.selectprimarygrouptxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectprimarygrouptxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectprimarygrouptxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectprimarygrouptxtbox.Location = new System.Drawing.Point(1309, 147);
            this.selectprimarygrouptxtbox.Name = "selectprimarygrouptxtbox";
            this.selectprimarygrouptxtbox.Size = new System.Drawing.Size(276, 32);
            this.selectprimarygrouptxtbox.TabIndex = 3;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(1309, 519);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(276, 45);
            this.closebtn.TabIndex = 5;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // AccountGroupHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1594, 770);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountGroupHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT GROUPS - FUTURE ART BROADCAST TRADING LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountGroupHistory_FormClosing);
            this.Load += new System.EventHandler(this.AccountGroupHistory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountGroupHistory_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.accountgroupdatagridview)).EndInit();
            this.gridViewMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.DataGridView accountgroupdatagridview;
        private System.Windows.Forms.ContextMenuStrip gridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label accountgroupid;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox aliastxtbox;
        private System.Windows.Forms.TextBox groupnametxtbox;
        private System.Windows.Forms.Label primarygrouplbl;
        private System.Windows.Forms.Label aliaslbl;
        private System.Windows.Forms.Label groupnamelbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.TextBox selectprimarygrouptxtbox;
    }
}