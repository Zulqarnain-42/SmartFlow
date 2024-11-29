namespace SmartFlow.Purchase
{
    partial class WarehouseSelection
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
            this.warehouseselectionlbl = new System.Windows.Forms.Label();
            this.dgvwarehouseselection = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwarehouseselection)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // warehouseselectionlbl
            // 
            this.warehouseselectionlbl.AutoSize = true;
            this.warehouseselectionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouseselectionlbl.Location = new System.Drawing.Point(12, 45);
            this.warehouseselectionlbl.Name = "warehouseselectionlbl";
            this.warehouseselectionlbl.Size = new System.Drawing.Size(160, 23);
            this.warehouseselectionlbl.TabIndex = 0;
            this.warehouseselectionlbl.Text = "Select a Warehouse";
            // 
            // dgvwarehouseselection
            // 
            this.dgvwarehouseselection.AllowUserToAddRows = false;
            this.dgvwarehouseselection.AllowUserToDeleteRows = false;
            this.dgvwarehouseselection.AllowUserToResizeColumns = false;
            this.dgvwarehouseselection.AllowUserToResizeRows = false;
            this.dgvwarehouseselection.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvwarehouseselection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvwarehouseselection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvwarehouseselection.Location = new System.Drawing.Point(12, 71);
            this.dgvwarehouseselection.Name = "dgvwarehouseselection";
            this.dgvwarehouseselection.RowHeadersVisible = false;
            this.dgvwarehouseselection.RowHeadersWidth = 51;
            this.dgvwarehouseselection.RowTemplate.Height = 24;
            this.dgvwarehouseselection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvwarehouseselection.Size = new System.Drawing.Size(776, 367);
            this.dgvwarehouseselection.TabIndex = 1;
            this.dgvwarehouseselection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvwarehouseselection_CellDoubleClick);
            this.dgvwarehouseselection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvwarehouseselection_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 2;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(800, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "WAREHOUSE SELECTION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WarehouseSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvwarehouseselection);
            this.Controls.Add(this.warehouseselectionlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WAREHOUSE SELECTION";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WarehouseSelection_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvwarehouseselection)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warehouseselectionlbl;
        private System.Windows.Forms.DataGridView dgvwarehouseselection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
    }
}