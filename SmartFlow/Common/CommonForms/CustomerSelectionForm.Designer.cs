namespace SmartFlow.Common.Forms
{
    partial class CustomerSelectionForm
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
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.dgvcustomer = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustomer)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 37);
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
            this.headinglbl.Size = new System.Drawing.Size(924, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "SEARCH FOR CUSTOMER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(74, 10);
            this.searchtxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(300, 27);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            this.searchtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxtbox_KeyDown);
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(9, 13);
            this.searchlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(61, 19);
            this.searchlbl.TabIndex = 0;
            this.searchlbl.Text = "SEARCH";
            // 
            // dgvcustomer
            // 
            this.dgvcustomer.AllowUserToAddRows = false;
            this.dgvcustomer.AllowUserToDeleteRows = false;
            this.dgvcustomer.AllowUserToResizeColumns = false;
            this.dgvcustomer.AllowUserToResizeRows = false;
            this.dgvcustomer.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvcustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvcustomer.Location = new System.Drawing.Point(0, 0);
            this.dgvcustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvcustomer.Name = "dgvcustomer";
            this.dgvcustomer.RowHeadersVisible = false;
            this.dgvcustomer.RowHeadersWidth = 51;
            this.dgvcustomer.RowTemplate.Height = 24;
            this.dgvcustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcustomer.Size = new System.Drawing.Size(924, 445);
            this.dgvcustomer.TabIndex = 0;
            this.dgvcustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcustomer_CellDoubleClick);
            this.dgvcustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvcustomer_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.searchtxtbox);
            this.panel3.Controls.Add(this.searchlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 49);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvcustomer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 445);
            this.panel2.TabIndex = 3;
            // 
            // CustomerSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(924, 531);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER SELECTION";
            this.Load += new System.EventHandler(this.CustomerSelectionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerSelectionForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustomer)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.DataGridView dgvcustomer;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}