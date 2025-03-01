namespace SmartFlow.Sales
{
    partial class DetailProformaInvoice
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
            this.totalqtyvaluelbl = new System.Windows.Forms.Label();
            this.totalamountvaluelbl = new System.Windows.Forms.Label();
            this.totalqtylbl = new System.Windows.Forms.Label();
            this.totalamountlbl = new System.Windows.Forms.Label();
            this.dgvlistinvoices = new System.Windows.Forms.DataGridView();
            this.todatevaluelbl = new System.Windows.Forms.Label();
            this.fromdatevaluelbl = new System.Windows.Forms.Label();
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
            this.headinglbl.Text = "LIST PROFORMA INVOICE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvlistinvoices);
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 362);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.exitbtn);
            this.panel3.Controls.Add(this.totalqtyvaluelbl);
            this.panel3.Controls.Add(this.totalamountvaluelbl);
            this.panel3.Controls.Add(this.totalqtylbl);
            this.panel3.Controls.Add(this.totalamountlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 65);
            this.panel3.TabIndex = 3;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(12, 13);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(106, 40);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            // 
            // totalqtyvaluelbl
            // 
            this.totalqtyvaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalqtyvaluelbl.AutoSize = true;
            this.totalqtyvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totalqtyvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totalqtyvaluelbl.Location = new System.Drawing.Point(591, 38);
            this.totalqtyvaluelbl.Name = "totalqtyvaluelbl";
            this.totalqtyvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totalqtyvaluelbl.TabIndex = 3;
            this.totalqtyvaluelbl.Text = "0.0";
            // 
            // totalamountvaluelbl
            // 
            this.totalamountvaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalamountvaluelbl.AutoSize = true;
            this.totalamountvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totalamountvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totalamountvaluelbl.Location = new System.Drawing.Point(591, 12);
            this.totalamountvaluelbl.Name = "totalamountvaluelbl";
            this.totalamountvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totalamountvaluelbl.TabIndex = 2;
            this.totalamountvaluelbl.Text = "0.0";
            // 
            // totalqtylbl
            // 
            this.totalqtylbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalqtylbl.AutoSize = true;
            this.totalqtylbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalqtylbl.Location = new System.Drawing.Point(477, 39);
            this.totalqtylbl.Name = "totalqtylbl";
            this.totalqtylbl.Size = new System.Drawing.Size(108, 17);
            this.totalqtylbl.TabIndex = 1;
            this.totalqtylbl.Text = "TOTAL QUANTITY";
            // 
            // totalamountlbl
            // 
            this.totalamountlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalamountlbl.AutoSize = true;
            this.totalamountlbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.totalamountlbl.Location = new System.Drawing.Point(477, 13);
            this.totalamountlbl.Name = "totalamountlbl";
            this.totalamountlbl.Size = new System.Drawing.Size(101, 17);
            this.totalamountlbl.TabIndex = 0;
            this.totalamountlbl.Text = "TOTAL AMOUNT";
            // 
            // dgvlistinvoices
            // 
            this.dgvlistinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlistinvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlistinvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvlistinvoices.Location = new System.Drawing.Point(0, 3);
            this.dgvlistinvoices.Name = "dgvlistinvoices";
            this.dgvlistinvoices.ReadOnly = true;
            this.dgvlistinvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlistinvoices.Size = new System.Drawing.Size(800, 288);
            this.dgvlistinvoices.TabIndex = 0;
            this.dgvlistinvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlistinvoices_CellDoubleClick);
            this.dgvlistinvoices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvlistinvoices_KeyDown);
            // 
            // todatevaluelbl
            // 
            this.todatevaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.todatevaluelbl.AutoSize = true;
            this.todatevaluelbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.todatevaluelbl.Location = new System.Drawing.Point(575, 68);
            this.todatevaluelbl.Name = "todatevaluelbl";
            this.todatevaluelbl.Size = new System.Drawing.Size(94, 17);
            this.todatevaluelbl.TabIndex = 13;
            this.todatevaluelbl.Text = "todatevaluelbl";
            // 
            // fromdatevaluelbl
            // 
            this.fromdatevaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromdatevaluelbl.AutoSize = true;
            this.fromdatevaluelbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.fromdatevaluelbl.Location = new System.Drawing.Point(575, 48);
            this.fromdatevaluelbl.Name = "fromdatevaluelbl";
            this.fromdatevaluelbl.Size = new System.Drawing.Size(109, 17);
            this.fromdatevaluelbl.TabIndex = 12;
            this.fromdatevaluelbl.Text = "fromdatevaluelbl";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(477, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "TO DATE";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(477, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "FROM DATE";
            // 
            // DetailProformaInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.todatevaluelbl);
            this.Controls.Add(this.fromdatevaluelbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "DetailProformaInvoice";
            this.Text = "LIST PERFORMA INVOICE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DetailProformaInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetailProformaInvoice_KeyDown);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Label totalqtyvaluelbl;
        private System.Windows.Forms.Label totalamountvaluelbl;
        private System.Windows.Forms.Label totalqtylbl;
        private System.Windows.Forms.Label totalamountlbl;
        private System.Windows.Forms.Label todatevaluelbl;
        private System.Windows.Forms.Label fromdatevaluelbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}