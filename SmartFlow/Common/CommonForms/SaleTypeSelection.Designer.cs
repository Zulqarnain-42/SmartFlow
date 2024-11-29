namespace SmartFlow.Common.CommonForms
{
    partial class SaleTypeSelection
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
            this.salestypeselectionlbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchlbl = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.dgvsalestypeselection = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalestypeselection)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.salestypeselectionlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 45);
            this.panel1.TabIndex = 0;
            // 
            // salestypeselectionlbl
            // 
            this.salestypeselectionlbl.BackColor = System.Drawing.Color.Black;
            this.salestypeselectionlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salestypeselectionlbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salestypeselectionlbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.salestypeselectionlbl.Location = new System.Drawing.Point(0, 0);
            this.salestypeselectionlbl.Name = "salestypeselectionlbl";
            this.salestypeselectionlbl.Size = new System.Drawing.Size(1232, 45);
            this.salestypeselectionlbl.TabIndex = 0;
            this.salestypeselectionlbl.Text = "SALES TYPE SELECTION";
            this.salestypeselectionlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.searchlbl.Location = new System.Drawing.Point(12, 17);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(75, 24);
            this.searchlbl.TabIndex = 3;
            this.searchlbl.Text = "SEARCH";
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(93, 13);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(400, 32);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            this.searchtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxtbox_KeyDown);
            // 
            // dgvsalestypeselection
            // 
            this.dgvsalestypeselection.AllowUserToAddRows = false;
            this.dgvsalestypeselection.AllowUserToDeleteRows = false;
            this.dgvsalestypeselection.AllowUserToResizeColumns = false;
            this.dgvsalestypeselection.AllowUserToResizeRows = false;
            this.dgvsalestypeselection.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvsalestypeselection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsalestypeselection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvsalestypeselection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvsalestypeselection.Location = new System.Drawing.Point(0, 105);
            this.dgvsalestypeselection.MultiSelect = false;
            this.dgvsalestypeselection.Name = "dgvsalestypeselection";
            this.dgvsalestypeselection.RowHeadersVisible = false;
            this.dgvsalestypeselection.RowHeadersWidth = 51;
            this.dgvsalestypeselection.RowTemplate.Height = 24;
            this.dgvsalestypeselection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvsalestypeselection.Size = new System.Drawing.Size(1232, 548);
            this.dgvsalestypeselection.TabIndex = 2;
            this.dgvsalestypeselection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsalestypeselection_CellDoubleClick);
            this.dgvsalestypeselection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvsalestypeselection_KeyDown);
            // 
            // SaleTypeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1232, 653);
            this.Controls.Add(this.dgvsalestypeselection);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SaleTypeSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALE TYPE SELECTION";
            this.Load += new System.EventHandler(this.SaleTypeSelection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaleTypeSelection_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalestypeselection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label salestypeselectionlbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvsalestypeselection;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
    }
}