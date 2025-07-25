﻿namespace SmartFlow.Masters
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.accountgroupdatagridview = new System.Windows.Forms.DataGridView();
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountgroupid = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.aliastxtbox = new System.Windows.Forms.TextBox();
            this.groupnametxtbox = new System.Windows.Forms.TextBox();
            this.aliaslbl = new System.Windows.Forms.Label();
            this.groupnamelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbrevenue = new System.Windows.Forms.RadioButton();
            this.rbexpense = new System.Windows.Forms.RadioButton();
            this.rbequity = new System.Windows.Forms.RadioButton();
            this.rbliabilities = new System.Windows.Forms.RadioButton();
            this.rbassets = new System.Windows.Forms.RadioButton();
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
            this.searchtxtbox.Location = new System.Drawing.Point(80, 4);
            this.searchtxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(335, 27);
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
            this.searchlbl.Location = new System.Drawing.Point(16, 8);
            this.searchlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(52, 18);
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
            this.accountgroupdatagridview.Location = new System.Drawing.Point(4, 0);
            this.accountgroupdatagridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.accountgroupdatagridview.MultiSelect = false;
            this.accountgroupdatagridview.Name = "accountgroupdatagridview";
            this.accountgroupdatagridview.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountgroupdatagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.accountgroupdatagridview.RowHeadersVisible = false;
            this.accountgroupdatagridview.RowHeadersWidth = 51;
            this.accountgroupdatagridview.RowTemplate.Height = 24;
            this.accountgroupdatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountgroupdatagridview.Size = new System.Drawing.Size(931, 553);
            this.accountgroupdatagridview.TabIndex = 0;
            this.accountgroupdatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountgroupdatagridview_CellDoubleClick_1);
            this.accountgroupdatagridview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.accountgroupdatagridview_Scroll);
            // 
            // gridViewMenuStrip
            // 
            this.gridViewMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gridViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.gridViewMenuStrip.Name = "gridViewMenuStrip";
            this.gridViewMenuStrip.Size = new System.Drawing.Size(95, 26);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // accountgroupid
            // 
            this.accountgroupid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountgroupid.AutoSize = true;
            this.accountgroupid.Location = new System.Drawing.Point(1074, 7);
            this.accountgroupid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountgroupid.Name = "accountgroupid";
            this.accountgroupid.Size = new System.Drawing.Size(81, 13);
            this.accountgroupid.TabIndex = 41;
            this.accountgroupid.Text = "accountgroupid";
            this.accountgroupid.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(941, 470);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(207, 37);
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
            this.aliastxtbox.Location = new System.Drawing.Point(941, 77);
            this.aliastxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aliastxtbox.Name = "aliastxtbox";
            this.aliastxtbox.Size = new System.Drawing.Size(204, 27);
            this.aliastxtbox.TabIndex = 2;
            // 
            // groupnametxtbox
            // 
            this.groupnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupnametxtbox.Location = new System.Drawing.Point(941, 24);
            this.groupnametxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupnametxtbox.Name = "groupnametxtbox";
            this.groupnametxtbox.Size = new System.Drawing.Size(205, 27);
            this.groupnametxtbox.TabIndex = 1;
            this.groupnametxtbox.TextChanged += new System.EventHandler(this.groupnametxtbox_TextChanged);
            // 
            // aliaslbl
            // 
            this.aliaslbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aliaslbl.AutoSize = true;
            this.aliaslbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.aliaslbl.Location = new System.Drawing.Point(940, 55);
            this.aliaslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.aliaslbl.Name = "aliaslbl";
            this.aliaslbl.Size = new System.Drawing.Size(38, 18);
            this.aliaslbl.TabIndex = 34;
            this.aliaslbl.Text = "Alias";
            // 
            // groupnamelbl
            // 
            this.groupnamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupnamelbl.AutoSize = true;
            this.groupnamelbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.groupnamelbl.Location = new System.Drawing.Point(938, 2);
            this.groupnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupnamelbl.Name = "groupnamelbl";
            this.groupnamelbl.Size = new System.Drawing.Size(89, 18);
            this.groupnamelbl.TabIndex = 33;
            this.groupnamelbl.Text = "Group Name ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.headinglbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1155, 37);
            this.panel2.TabIndex = 16;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1155, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ACCOUNT GROUPS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel4.Location = new System.Drawing.Point(0, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1155, 32);
            this.panel4.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbrevenue);
            this.panel5.Controls.Add(this.rbexpense);
            this.panel5.Controls.Add(this.rbequity);
            this.panel5.Controls.Add(this.rbliabilities);
            this.panel5.Controls.Add(this.rbassets);
            this.panel5.Controls.Add(this.closebtn);
            this.panel5.Controls.Add(this.accountgroupid);
            this.panel5.Controls.Add(this.accountgroupdatagridview);
            this.panel5.Controls.Add(this.groupnamelbl);
            this.panel5.Controls.Add(this.savebtn);
            this.panel5.Controls.Add(this.aliaslbl);
            this.panel5.Controls.Add(this.aliastxtbox);
            this.panel5.Controls.Add(this.groupnametxtbox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 69);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1155, 557);
            this.panel5.TabIndex = 18;
            // 
            // rbrevenue
            // 
            this.rbrevenue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbrevenue.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbrevenue.Location = new System.Drawing.Point(943, 219);
            this.rbrevenue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbrevenue.Name = "rbrevenue";
            this.rbrevenue.Size = new System.Drawing.Size(149, 21);
            this.rbrevenue.TabIndex = 47;
            this.rbrevenue.TabStop = true;
            this.rbrevenue.Text = "REVENUE";
            this.rbrevenue.UseVisualStyleBackColor = true;
            // 
            // rbexpense
            // 
            this.rbexpense.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbexpense.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbexpense.Location = new System.Drawing.Point(943, 193);
            this.rbexpense.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbexpense.Name = "rbexpense";
            this.rbexpense.Size = new System.Drawing.Size(151, 21);
            this.rbexpense.TabIndex = 46;
            this.rbexpense.TabStop = true;
            this.rbexpense.Text = "EXPENSES";
            this.rbexpense.UseVisualStyleBackColor = true;
            // 
            // rbequity
            // 
            this.rbequity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbequity.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbequity.Location = new System.Drawing.Point(943, 167);
            this.rbequity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbequity.Name = "rbequity";
            this.rbequity.Size = new System.Drawing.Size(138, 21);
            this.rbequity.TabIndex = 45;
            this.rbequity.TabStop = true;
            this.rbequity.Text = "EQUITY";
            this.rbequity.UseVisualStyleBackColor = true;
            // 
            // rbliabilities
            // 
            this.rbliabilities.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbliabilities.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbliabilities.Location = new System.Drawing.Point(943, 141);
            this.rbliabilities.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbliabilities.Name = "rbliabilities";
            this.rbliabilities.Size = new System.Drawing.Size(158, 21);
            this.rbliabilities.TabIndex = 44;
            this.rbliabilities.TabStop = true;
            this.rbliabilities.Text = "LIABILITIES";
            this.rbliabilities.UseVisualStyleBackColor = true;
            // 
            // rbassets
            // 
            this.rbassets.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbassets.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbassets.Location = new System.Drawing.Point(943, 115);
            this.rbassets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbassets.Name = "rbassets";
            this.rbassets.Size = new System.Drawing.Size(135, 21);
            this.rbassets.TabIndex = 43;
            this.rbassets.TabStop = true;
            this.rbassets.Text = "ASSETS";
            this.rbassets.UseVisualStyleBackColor = true;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(941, 510);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(207, 37);
            this.closebtn.TabIndex = 5;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // AccountGroupHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1155, 626);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AccountGroupHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT GROUPS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label aliaslbl;
        private System.Windows.Forms.Label groupnamelbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.RadioButton rbrevenue;
        private System.Windows.Forms.RadioButton rbexpense;
        private System.Windows.Forms.RadioButton rbequity;
        private System.Windows.Forms.RadioButton rbliabilities;
        private System.Windows.Forms.RadioButton rbassets;
    }
}