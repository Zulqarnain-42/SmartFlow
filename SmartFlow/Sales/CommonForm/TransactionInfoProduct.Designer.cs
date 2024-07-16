namespace SmartFlow.Sales.CommonForm
{
    partial class TransactionInfoProduct
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
            this.dgvTransactionInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitbtn = new System.Windows.Forms.Button();
            this.alltransactionbtn = new System.Windows.Forms.Button();
            this.currentcustomerdatabtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 45);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(981, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "TRANSACTIONS INFORMATION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTransactionInfo
            // 
            this.dgvTransactionInfo.AllowUserToAddRows = false;
            this.dgvTransactionInfo.AllowUserToDeleteRows = false;
            this.dgvTransactionInfo.AllowUserToResizeColumns = false;
            this.dgvTransactionInfo.AllowUserToResizeRows = false;
            this.dgvTransactionInfo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTransactionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransactionInfo.Location = new System.Drawing.Point(0, 45);
            this.dgvTransactionInfo.Name = "dgvTransactionInfo";
            this.dgvTransactionInfo.RowHeadersWidth = 51;
            this.dgvTransactionInfo.RowTemplate.Height = 24;
            this.dgvTransactionInfo.Size = new System.Drawing.Size(981, 383);
            this.dgvTransactionInfo.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.alltransactionbtn);
            this.panel2.Controls.Add(this.currentcustomerdatabtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 65);
            this.panel2.TabIndex = 2;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(894, 9);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(75, 36);
            this.exitbtn.TabIndex = 2;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // alltransactionbtn
            // 
            this.alltransactionbtn.Location = new System.Drawing.Point(691, 9);
            this.alltransactionbtn.Name = "alltransactionbtn";
            this.alltransactionbtn.Size = new System.Drawing.Size(197, 36);
            this.alltransactionbtn.TabIndex = 1;
            this.alltransactionbtn.Text = "ALL TRANSACTION";
            this.alltransactionbtn.UseVisualStyleBackColor = true;
            // 
            // currentcustomerdatabtn
            // 
            this.currentcustomerdatabtn.Location = new System.Drawing.Point(495, 9);
            this.currentcustomerdatabtn.Name = "currentcustomerdatabtn";
            this.currentcustomerdatabtn.Size = new System.Drawing.Size(190, 36);
            this.currentcustomerdatabtn.TabIndex = 0;
            this.currentcustomerdatabtn.Text = "CURRENT CUSTOMER";
            this.currentcustomerdatabtn.UseVisualStyleBackColor = true;
            this.currentcustomerdatabtn.Click += new System.EventHandler(this.currentcustomerdatabtn_Click);
            // 
            // TransactionInfoProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTransactionInfo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TransactionInfoProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Info Product";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransactionInfoProduct_FormClosing);
            this.Load += new System.EventHandler(this.TransactionInfoProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransactionInfoProduct_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.DataGridView dgvTransactionInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button alltransactionbtn;
        private System.Windows.Forms.Button currentcustomerdatabtn;
    }
}