namespace SmartFlow.Sales
{
    partial class TaxPlanet
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
            this.searchlbl = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.dgvTaxPlanet = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.findtransactionbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxPlanet)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(922, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "TAX RETURN PLANET";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(13, 56);
            this.searchlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(129, 24);
            this.searchlbl.TabIndex = 5;
            this.searchlbl.Text = "Search Invoice";
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(17, 82);
            this.searchtxtbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(603, 32);
            this.searchtxtbox.TabIndex = 4;
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(626, 82);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(113, 32);
            this.searchbtn.TabIndex = 6;
            this.searchbtn.Text = "Search";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // dgvTaxPlanet
            // 
            this.dgvTaxPlanet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaxPlanet.Location = new System.Drawing.Point(12, 157);
            this.dgvTaxPlanet.Name = "dgvTaxPlanet";
            this.dgvTaxPlanet.RowHeadersWidth = 51;
            this.dgvTaxPlanet.RowTemplate.Height = 24;
            this.dgvTaxPlanet.Size = new System.Drawing.Size(898, 293);
            this.dgvTaxPlanet.TabIndex = 7;
            this.dgvTaxPlanet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaxPlanet_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cancelbtn);
            this.panel2.Controls.Add(this.findtransactionbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 41);
            this.panel2.TabIndex = 8;
            // 
            // cancelbtn
            // 
            this.cancelbtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.Location = new System.Drawing.Point(403, 3);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(250, 32);
            this.cancelbtn.TabIndex = 7;
            this.cancelbtn.Text = "Cancel Transaction";
            this.cancelbtn.UseVisualStyleBackColor = true;
            // 
            // findtransactionbtn
            // 
            this.findtransactionbtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findtransactionbtn.Location = new System.Drawing.Point(659, 3);
            this.findtransactionbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.findtransactionbtn.Name = "findtransactionbtn";
            this.findtransactionbtn.Size = new System.Drawing.Size(250, 32);
            this.findtransactionbtn.TabIndex = 6;
            this.findtransactionbtn.Text = "Find Transaction";
            this.findtransactionbtn.UseVisualStyleBackColor = true;
            this.findtransactionbtn.Click += new System.EventHandler(this.findtransactionbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Searched Record";
            // 
            // TaxPlanet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(922, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTaxPlanet);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.searchlbl);
            this.Controls.Add(this.searchtxtbox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TaxPlanet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAX PLANET";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TaxPlanet_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxPlanet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.DataGridView dgvTaxPlanet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button findtransactionbtn;
        private System.Windows.Forms.Label label1;
    }
}