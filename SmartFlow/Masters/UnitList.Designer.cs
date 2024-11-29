namespace SmartFlow.Masters
{
    partial class UnitList
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
            this.closebtn = new System.Windows.Forms.Button();
            this.unitcodelbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.isdefaultchkbox = new System.Windows.Forms.CheckBox();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.unitidlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.unitnametxtbox = new System.Windows.Forms.TextBox();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.unitnamelbl = new System.Windows.Forms.Label();
            this.dgvListunit = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListunit)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(837, 425);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(331, 36);
            this.closebtn.TabIndex = 67;
            this.closebtn.Text = "EXIT";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // unitcodelbl
            // 
            this.unitcodelbl.AutoSize = true;
            this.unitcodelbl.Location = new System.Drawing.Point(838, 406);
            this.unitcodelbl.Name = "unitcodelbl";
            this.unitcodelbl.Size = new System.Drawing.Size(72, 16);
            this.unitcodelbl.TabIndex = 66;
            this.unitcodelbl.Text = "unitcodelbl";
            this.unitcodelbl.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.isdefaultchkbox);
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.unitcodelbl);
            this.panel3.Controls.Add(this.unitidlbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.unitnametxtbox);
            this.panel3.Controls.Add(this.descriptionlbl);
            this.panel3.Controls.Add(this.unitnamelbl);
            this.panel3.Controls.Add(this.dgvListunit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1180, 473);
            this.panel3.TabIndex = 6;
            // 
            // isdefaultchkbox
            // 
            this.isdefaultchkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isdefaultchkbox.AutoSize = true;
            this.isdefaultchkbox.Location = new System.Drawing.Point(841, 327);
            this.isdefaultchkbox.Name = "isdefaultchkbox";
            this.isdefaultchkbox.Size = new System.Drawing.Size(106, 20);
            this.isdefaultchkbox.TabIndex = 69;
            this.isdefaultchkbox.Text = "IS DEFAULT";
            this.isdefaultchkbox.UseVisualStyleBackColor = true;
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(837, 90);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(331, 231);
            this.descriptiontxtbox.TabIndex = 68;
            this.descriptiontxtbox.Text = "";
            // 
            // unitidlbl
            // 
            this.unitidlbl.AutoSize = true;
            this.unitidlbl.Location = new System.Drawing.Point(916, 406);
            this.unitidlbl.Name = "unitidlbl";
            this.unitidlbl.Size = new System.Drawing.Size(52, 16);
            this.unitidlbl.TabIndex = 65;
            this.unitidlbl.Text = "unitidlbl";
            this.unitidlbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(837, 353);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(331, 36);
            this.savebtn.TabIndex = 60;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // unitnametxtbox
            // 
            this.unitnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unitnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitnametxtbox.Location = new System.Drawing.Point(837, 29);
            this.unitnametxtbox.Name = "unitnametxtbox";
            this.unitnametxtbox.Size = new System.Drawing.Size(331, 32);
            this.unitnametxtbox.TabIndex = 55;
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(837, 64);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(116, 23);
            this.descriptionlbl.TabIndex = 59;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // unitnamelbl
            // 
            this.unitnamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitnamelbl.AutoSize = true;
            this.unitnamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitnamelbl.Location = new System.Drawing.Point(837, 3);
            this.unitnamelbl.Name = "unitnamelbl";
            this.unitnamelbl.Size = new System.Drawing.Size(101, 23);
            this.unitnamelbl.TabIndex = 57;
            this.unitnamelbl.Text = "UNIT NAME";
            // 
            // dgvListunit
            // 
            this.dgvListunit.AllowUserToAddRows = false;
            this.dgvListunit.AllowUserToDeleteRows = false;
            this.dgvListunit.AllowUserToResizeColumns = false;
            this.dgvListunit.AllowUserToResizeRows = false;
            this.dgvListunit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListunit.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListunit.CausesValidation = false;
            this.dgvListunit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListunit.ColumnHeadersVisible = false;
            this.dgvListunit.ContextMenuStrip = this.contextMenuStrip;
            this.dgvListunit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListunit.Location = new System.Drawing.Point(0, 3);
            this.dgvListunit.Name = "dgvListunit";
            this.dgvListunit.RowHeadersWidth = 51;
            this.dgvListunit.RowTemplate.Height = 24;
            this.dgvListunit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListunit.Size = new System.Drawing.Size(831, 467);
            this.dgvListunit.TabIndex = 2;
            this.dgvListunit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListunit_CellDoubleClick);
            this.dgvListunit.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvListunit_Scroll);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(110, 28);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1180, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "LIST UNIT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 45);
            this.panel1.TabIndex = 4;
            // 
            // UnitList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 518);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UnitList";
            this.Text = "UnitList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UnitList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UnitList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListunit)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label unitcodelbl;
        private System.Windows.Forms.Label unitidlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox unitnametxtbox;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.Label unitnamelbl;
        private System.Windows.Forms.DataGridView dgvListunit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.CheckBox isdefaultchkbox;
    }
}