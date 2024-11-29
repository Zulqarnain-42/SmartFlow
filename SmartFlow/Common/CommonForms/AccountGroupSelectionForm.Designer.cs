namespace SmartFlow.Common.CommonForms
{
    partial class AccountGroupSelectionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.dgvaccountgroupselection = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchlbl = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaccountgroupselection)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 45);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1232, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ACCOUNT GROUP SELECTION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvaccountgroupselection
            // 
            this.dgvaccountgroupselection.AllowUserToAddRows = false;
            this.dgvaccountgroupselection.AllowUserToDeleteRows = false;
            this.dgvaccountgroupselection.AllowUserToResizeColumns = false;
            this.dgvaccountgroupselection.AllowUserToResizeRows = false;
            this.dgvaccountgroupselection.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvaccountgroupselection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaccountgroupselection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvaccountgroupselection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvaccountgroupselection.Location = new System.Drawing.Point(0, 105);
            this.dgvaccountgroupselection.Name = "dgvaccountgroupselection";
            this.dgvaccountgroupselection.RowHeadersVisible = false;
            this.dgvaccountgroupselection.RowHeadersWidth = 51;
            this.dgvaccountgroupselection.RowTemplate.Height = 24;
            this.dgvaccountgroupselection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvaccountgroupselection.Size = new System.Drawing.Size(1232, 548);
            this.dgvaccountgroupselection.TabIndex = 4;
            this.dgvaccountgroupselection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvaccountgroupselection_CellDoubleClick);
            this.dgvaccountgroupselection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvaccountgroupselection_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchlbl);
            this.panel2.Controls.Add(this.searchtxtbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1232, 60);
            this.panel2.TabIndex = 3;
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(14, 18);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(75, 24);
            this.searchlbl.TabIndex = 2;
            this.searchlbl.Text = "SEARCH";
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Enabled = false;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(109, 14);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(400, 32);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            this.searchtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxtbox_KeyDown);
            // 
            // AccountGroupSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1232, 653);
            this.Controls.Add(this.dgvaccountgroupselection);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccountGroupSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT GROUP SELECTION";
            this.Load += new System.EventHandler(this.AccountGroupSelectionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountGroupSelectionForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaccountgroupselection)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.DataGridView dgvaccountgroupselection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TextBox searchtxtbox;
    }
}