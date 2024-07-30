namespace SmartFlow.Common.CommonForms
{
    partial class StockLocationSelection
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
            this.dgvstocklocation = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstocklocation)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvstocklocation
            // 
            this.dgvstocklocation.AllowUserToAddRows = false;
            this.dgvstocklocation.AllowUserToDeleteRows = false;
            this.dgvstocklocation.AllowUserToResizeColumns = false;
            this.dgvstocklocation.AllowUserToResizeRows = false;
            this.dgvstocklocation.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvstocklocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstocklocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvstocklocation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvstocklocation.Location = new System.Drawing.Point(0, 0);
            this.dgvstocklocation.Name = "dgvstocklocation";
            this.dgvstocklocation.RowHeadersVisible = false;
            this.dgvstocklocation.RowHeadersWidth = 51;
            this.dgvstocklocation.RowTemplate.Height = 24;
            this.dgvstocklocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvstocklocation.Size = new System.Drawing.Size(1232, 548);
            this.dgvstocklocation.TabIndex = 0;
            this.dgvstocklocation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstocklocation_CellDoubleClick);
            this.dgvstocklocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvstocklocation_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 45);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1232, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEARCH FOR STOCK LOCATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(91, 17);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(400, 32);
            this.searchtxtbox.TabIndex = 0;
            this.searchtxtbox.TextChanged += new System.EventHandler(this.searchtxtbox_TextChanged);
            this.searchtxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxtbox_KeyDown);
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(12, 20);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(75, 24);
            this.searchlbl.TabIndex = 0;
            this.searchlbl.Text = "SEARCH";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchtxtbox);
            this.panel2.Controls.Add(this.searchlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1232, 60);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvstocklocation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1232, 548);
            this.panel3.TabIndex = 4;
            // 
            // StockLocationSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1232, 653);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "StockLocationSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK LOCATION SELECTION - FUTURE ART BROADCAST TRADING LLC";
            this.Load += new System.EventHandler(this.StockLocationSelection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockLocationSelection_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstocklocation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvstocklocation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}