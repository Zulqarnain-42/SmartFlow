namespace SmartFlow.Transactions
{
    partial class DetailReceipt
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitbtn = new System.Windows.Forms.Button();
            this.totalcreditvaluelbl = new System.Windows.Forms.Label();
            this.totaldebitvaluelbl = new System.Windows.Forms.Label();
            this.totalcreditlbl = new System.Windows.Forms.Label();
            this.totaldebitlbl = new System.Windows.Forms.Label();
            this.dgvlistinvoices = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistinvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 4;
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
            this.headinglbl.Text = "LIST RECEIPT INVOICE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvlistinvoices);
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 366);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.exitbtn);
            this.panel3.Controls.Add(this.totalcreditvaluelbl);
            this.panel3.Controls.Add(this.totaldebitvaluelbl);
            this.panel3.Controls.Add(this.totalcreditlbl);
            this.panel3.Controls.Add(this.totaldebitlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 65);
            this.panel3.TabIndex = 2;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(12, 13);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(106, 40);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // totalcreditvaluelbl
            // 
            this.totalcreditvaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalcreditvaluelbl.AutoSize = true;
            this.totalcreditvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totalcreditvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totalcreditvaluelbl.Location = new System.Drawing.Point(604, 38);
            this.totalcreditvaluelbl.Name = "totalcreditvaluelbl";
            this.totalcreditvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totalcreditvaluelbl.TabIndex = 3;
            this.totalcreditvaluelbl.Text = "0.0";
            // 
            // totaldebitvaluelbl
            // 
            this.totaldebitvaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldebitvaluelbl.AutoSize = true;
            this.totaldebitvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totaldebitvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totaldebitvaluelbl.Location = new System.Drawing.Point(604, 12);
            this.totaldebitvaluelbl.Name = "totaldebitvaluelbl";
            this.totaldebitvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totaldebitvaluelbl.TabIndex = 2;
            this.totaldebitvaluelbl.Text = "0.0";
            // 
            // totalcreditlbl
            // 
            this.totalcreditlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalcreditlbl.AutoSize = true;
            this.totalcreditlbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcreditlbl.Location = new System.Drawing.Point(500, 39);
            this.totalcreditlbl.Name = "totalcreditlbl";
            this.totalcreditlbl.Size = new System.Drawing.Size(89, 17);
            this.totalcreditlbl.TabIndex = 1;
            this.totalcreditlbl.Text = "TOTAL CREDIT";
            // 
            // totaldebitlbl
            // 
            this.totaldebitlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldebitlbl.AutoSize = true;
            this.totaldebitlbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.totaldebitlbl.Location = new System.Drawing.Point(500, 13);
            this.totaldebitlbl.Name = "totaldebitlbl";
            this.totaldebitlbl.Size = new System.Drawing.Size(82, 17);
            this.totaldebitlbl.TabIndex = 0;
            this.totaldebitlbl.Text = "TOTAL DEBIT";
            // 
            // dgvlistinvoices
            // 
            this.dgvlistinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlistinvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistinvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvlistinvoices.Location = new System.Drawing.Point(0, 0);
            this.dgvlistinvoices.Name = "dgvlistinvoices";
            this.dgvlistinvoices.ReadOnly = true;
            this.dgvlistinvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlistinvoices.Size = new System.Drawing.Size(800, 295);
            this.dgvlistinvoices.TabIndex = 0;
            this.dgvlistinvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlistinvoices_CellDoubleClick);
            this.dgvlistinvoices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvlistinvoices_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "TO DATE";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "FROM DATE";
            this.label1.Visible = false;
            // 
            // DetailReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DetailReceipt";
            this.Text = "DETAIL RECEIPT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DetailReceipt_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlistinvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvlistinvoices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Label totalcreditvaluelbl;
        private System.Windows.Forms.Label totaldebitvaluelbl;
        private System.Windows.Forms.Label totalcreditlbl;
        private System.Windows.Forms.Label totaldebitlbl;
    }
}