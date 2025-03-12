namespace SmartFlow.Report
{
    partial class DetailAccountStatement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.printbtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.totalcreditvaluelbl = new System.Windows.Forms.Label();
            this.totaldebitvaluelbl = new System.Windows.Forms.Label();
            this.closingbalanceamtlbl = new System.Windows.Forms.Label();
            this.totalamountlbl = new System.Windows.Forms.Label();
            this.dgvlistinvoices = new System.Windows.Forms.DataGridView();
            this.todatevaluelbl = new System.Windows.Forms.Label();
            this.fromdatevaluelbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.accountnamevaluelbl = new System.Windows.Forms.Label();
            this.openingbalancevaluelbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 14;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(800, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "DETAIL ACCOUNT STATEMENT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvlistinvoices);
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 362);
            this.panel2.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.printbtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(601, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(199, 297);
            this.panel4.TabIndex = 4;
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(3, 3);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(193, 23);
            this.printbtn.TabIndex = 0;
            this.printbtn.Text = "PRINT";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.totalcreditvaluelbl);
            this.panel3.Controls.Add(this.totaldebitvaluelbl);
            this.panel3.Controls.Add(this.closingbalanceamtlbl);
            this.panel3.Controls.Add(this.totalamountlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 65);
            this.panel3.TabIndex = 3;
            // 
            // totalcreditvaluelbl
            // 
            this.totalcreditvaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalcreditvaluelbl.AutoSize = true;
            this.totalcreditvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totalcreditvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totalcreditvaluelbl.Location = new System.Drawing.Point(12, 38);
            this.totalcreditvaluelbl.Name = "totalcreditvaluelbl";
            this.totalcreditvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totalcreditvaluelbl.TabIndex = 5;
            this.totalcreditvaluelbl.Text = "0.0";
            // 
            // totaldebitvaluelbl
            // 
            this.totaldebitvaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totaldebitvaluelbl.AutoSize = true;
            this.totaldebitvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totaldebitvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totaldebitvaluelbl.Location = new System.Drawing.Point(12, 12);
            this.totaldebitvaluelbl.Name = "totaldebitvaluelbl";
            this.totaldebitvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totaldebitvaluelbl.TabIndex = 3;
            this.totaldebitvaluelbl.Text = "0.0";
            // 
            // closingbalanceamtlbl
            // 
            this.closingbalanceamtlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closingbalanceamtlbl.AutoSize = true;
            this.closingbalanceamtlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.closingbalanceamtlbl.ForeColor = System.Drawing.Color.Blue;
            this.closingbalanceamtlbl.Location = new System.Drawing.Point(598, 12);
            this.closingbalanceamtlbl.Name = "closingbalanceamtlbl";
            this.closingbalanceamtlbl.Size = new System.Drawing.Size(31, 18);
            this.closingbalanceamtlbl.TabIndex = 2;
            this.closingbalanceamtlbl.Text = "0.0";
            // 
            // totalamountlbl
            // 
            this.totalamountlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalamountlbl.AutoSize = true;
            this.totalamountlbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.totalamountlbl.Location = new System.Drawing.Point(477, 13);
            this.totalamountlbl.Name = "totalamountlbl";
            this.totalamountlbl.Size = new System.Drawing.Size(115, 17);
            this.totalamountlbl.TabIndex = 0;
            this.totalamountlbl.Text = "CLOSING BALANCE";
            // 
            // dgvlistinvoices
            // 
            this.dgvlistinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlistinvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlistinvoices.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlistinvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvlistinvoices.Location = new System.Drawing.Point(0, 3);
            this.dgvlistinvoices.Name = "dgvlistinvoices";
            this.dgvlistinvoices.ReadOnly = true;
            this.dgvlistinvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlistinvoices.Size = new System.Drawing.Size(595, 288);
            this.dgvlistinvoices.TabIndex = 0;
            // 
            // todatevaluelbl
            // 
            this.todatevaluelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.todatevaluelbl.AutoSize = true;
            this.todatevaluelbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.todatevaluelbl.Location = new System.Drawing.Point(575, 68);
            this.todatevaluelbl.Name = "todatevaluelbl";
            this.todatevaluelbl.Size = new System.Drawing.Size(94, 17);
            this.todatevaluelbl.TabIndex = 19;
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
            this.fromdatevaluelbl.TabIndex = 18;
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
            this.label2.TabIndex = 17;
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
            this.label1.TabIndex = 16;
            this.label1.Text = "FROM DATE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "ACCOUNT NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "OPENING BALANCE";
            // 
            // accountnamevaluelbl
            // 
            this.accountnamevaluelbl.AutoSize = true;
            this.accountnamevaluelbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnamevaluelbl.Location = new System.Drawing.Point(156, 48);
            this.accountnamevaluelbl.Name = "accountnamevaluelbl";
            this.accountnamevaluelbl.Size = new System.Drawing.Size(135, 17);
            this.accountnamevaluelbl.TabIndex = 22;
            this.accountnamevaluelbl.Text = "accountnamevaluelbl";
            // 
            // openingbalancevaluelbl
            // 
            this.openingbalancevaluelbl.AutoSize = true;
            this.openingbalancevaluelbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openingbalancevaluelbl.Location = new System.Drawing.Point(156, 68);
            this.openingbalancevaluelbl.Name = "openingbalancevaluelbl";
            this.openingbalancevaluelbl.Size = new System.Drawing.Size(149, 17);
            this.openingbalancevaluelbl.TabIndex = 23;
            this.openingbalancevaluelbl.Text = "openingbalancevaluelbl";
            // 
            // DetailAccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openingbalancevaluelbl);
            this.Controls.Add(this.accountnamevaluelbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.todatevaluelbl);
            this.Controls.Add(this.fromdatevaluelbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DetailAccountStatement";
            this.Text = "DETAIL ACCOUNT STATEMENT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DetailAccountStatement_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label totaldebitvaluelbl;
        private System.Windows.Forms.Label closingbalanceamtlbl;
        private System.Windows.Forms.Label totalamountlbl;
        private System.Windows.Forms.DataGridView dgvlistinvoices;
        private System.Windows.Forms.Label todatevaluelbl;
        private System.Windows.Forms.Label fromdatevaluelbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalcreditvaluelbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label accountnamevaluelbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label openingbalancevaluelbl;
        private System.Windows.Forms.Button printbtn;
    }
}