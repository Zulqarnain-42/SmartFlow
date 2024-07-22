namespace SmartFlow.Common.CommonForms
{
    partial class PurchaseTypeSelection
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
            this.purchasetypeselectionlbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchlbl = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.dgvpurchasetypeselection = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchasetypeselection)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.purchasetypeselectionlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 45);
            this.panel1.TabIndex = 0;
            // 
            // purchasetypeselectionlbl
            // 
            this.purchasetypeselectionlbl.BackColor = System.Drawing.Color.Black;
            this.purchasetypeselectionlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchasetypeselectionlbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasetypeselectionlbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.purchasetypeselectionlbl.Location = new System.Drawing.Point(0, 0);
            this.purchasetypeselectionlbl.Name = "purchasetypeselectionlbl";
            this.purchasetypeselectionlbl.Size = new System.Drawing.Size(1232, 45);
            this.purchasetypeselectionlbl.TabIndex = 0;
            this.purchasetypeselectionlbl.Text = "PURCHASE TYPE SELECTION";
            this.purchasetypeselectionlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchlbl);
            this.panel2.Controls.Add(this.searchtxtbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1232, 60);
            this.panel2.TabIndex = 1;
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(12, 16);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(75, 24);
            this.searchlbl.TabIndex = 3;
            this.searchlbl.Text = "SEARCH";
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(93, 14);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(400, 32);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            this.searchtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxtbox_KeyDown);
            // 
            // dgvpurchasetypeselection
            // 
            this.dgvpurchasetypeselection.AllowUserToAddRows = false;
            this.dgvpurchasetypeselection.AllowUserToDeleteRows = false;
            this.dgvpurchasetypeselection.AllowUserToResizeColumns = false;
            this.dgvpurchasetypeselection.AllowUserToResizeRows = false;
            this.dgvpurchasetypeselection.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvpurchasetypeselection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchasetypeselection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvpurchasetypeselection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvpurchasetypeselection.Location = new System.Drawing.Point(0, 105);
            this.dgvpurchasetypeselection.Name = "dgvpurchasetypeselection";
            this.dgvpurchasetypeselection.RowHeadersVisible = false;
            this.dgvpurchasetypeselection.RowHeadersWidth = 51;
            this.dgvpurchasetypeselection.RowTemplate.Height = 24;
            this.dgvpurchasetypeselection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpurchasetypeselection.Size = new System.Drawing.Size(1232, 548);
            this.dgvpurchasetypeselection.TabIndex = 2;
            this.dgvpurchasetypeselection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpurchasetypeselection_CellDoubleClick);
            this.dgvpurchasetypeselection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvpurchasetypeselection_KeyDown);
            // 
            // PurchaseTypeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1232, 653);
            this.Controls.Add(this.dgvpurchasetypeselection);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "PurchaseTypeSelection";
            this.Text = "Purchase Type Selection";
            this.Load += new System.EventHandler(this.PurchaseTypeSelection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseTypeSelection_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchasetypeselection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label purchasetypeselectionlbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvpurchasetypeselection;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
    }
}