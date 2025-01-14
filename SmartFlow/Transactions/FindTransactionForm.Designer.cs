namespace SmartFlow.Transactions
{
    partial class FindTransactionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.paymentradiobtn = new System.Windows.Forms.RadioButton();
            this.creditradiobtn = new System.Windows.Forms.RadioButton();
            this.receiptradiobtn = new System.Windows.Forms.RadioButton();
            this.debitradiobtn = new System.Windows.Forms.RadioButton();
            this.journalradiobtn = new System.Windows.Forms.RadioButton();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.datelbl = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "FIND AN INVOICE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentradiobtn
            // 
            this.paymentradiobtn.AutoSize = true;
            this.paymentradiobtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentradiobtn.Location = new System.Drawing.Point(80, 90);
            this.paymentradiobtn.Name = "paymentradiobtn";
            this.paymentradiobtn.Size = new System.Drawing.Size(105, 27);
            this.paymentradiobtn.TabIndex = 1;
            this.paymentradiobtn.TabStop = true;
            this.paymentradiobtn.Text = "PAYMENT";
            this.paymentradiobtn.UseVisualStyleBackColor = true;
            // 
            // creditradiobtn
            // 
            this.creditradiobtn.AutoSize = true;
            this.creditradiobtn.Enabled = false;
            this.creditradiobtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditradiobtn.Location = new System.Drawing.Point(80, 134);
            this.creditradiobtn.Name = "creditradiobtn";
            this.creditradiobtn.Size = new System.Drawing.Size(133, 27);
            this.creditradiobtn.TabIndex = 2;
            this.creditradiobtn.TabStop = true;
            this.creditradiobtn.Text = "CREDIT NOTE";
            this.creditradiobtn.UseVisualStyleBackColor = true;
            // 
            // receiptradiobtn
            // 
            this.receiptradiobtn.AutoSize = true;
            this.receiptradiobtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiptradiobtn.Location = new System.Drawing.Point(264, 90);
            this.receiptradiobtn.Name = "receiptradiobtn";
            this.receiptradiobtn.Size = new System.Drawing.Size(94, 27);
            this.receiptradiobtn.TabIndex = 3;
            this.receiptradiobtn.TabStop = true;
            this.receiptradiobtn.Text = "RECEIPT";
            this.receiptradiobtn.UseVisualStyleBackColor = true;
            // 
            // debitradiobtn
            // 
            this.debitradiobtn.AutoSize = true;
            this.debitradiobtn.Enabled = false;
            this.debitradiobtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debitradiobtn.Location = new System.Drawing.Point(264, 134);
            this.debitradiobtn.Name = "debitradiobtn";
            this.debitradiobtn.Size = new System.Drawing.Size(123, 27);
            this.debitradiobtn.TabIndex = 4;
            this.debitradiobtn.TabStop = true;
            this.debitradiobtn.Text = "DEBIT NOTE";
            this.debitradiobtn.UseVisualStyleBackColor = true;
            // 
            // journalradiobtn
            // 
            this.journalradiobtn.AutoSize = true;
            this.journalradiobtn.Enabled = false;
            this.journalradiobtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journalradiobtn.Location = new System.Drawing.Point(465, 90);
            this.journalradiobtn.Name = "journalradiobtn";
            this.journalradiobtn.Size = new System.Drawing.Size(103, 27);
            this.journalradiobtn.TabIndex = 5;
            this.journalradiobtn.TabStop = true;
            this.journalradiobtn.Text = "JOURNAL";
            this.journalradiobtn.UseVisualStyleBackColor = true;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(194, 260);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(374, 32);
            this.invoicedatetxtbox.TabIndex = 121;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(194, 299);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(374, 35);
            this.searchbtn.TabIndex = 120;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(78, 265);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(50, 23);
            this.datelbl.TabIndex = 119;
            this.datelbl.Text = "DATE";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(194, 222);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(374, 32);
            this.invoicenotxtbox.TabIndex = 118;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(78, 227);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(106, 23);
            this.invoicenolbl.TabIndex = 117;
            this.invoicenolbl.Text = "INVOICE NO";
            // 
            // FindTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(655, 364);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.invoicenolbl);
            this.Controls.Add(this.journalradiobtn);
            this.Controls.Add(this.debitradiobtn);
            this.Controls.Add(this.receiptradiobtn);
            this.Controls.Add(this.creditradiobtn);
            this.Controls.Add(this.paymentradiobtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FindTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIND TRANSACTION FORM";
            this.Load += new System.EventHandler(this.FindTransactionForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton paymentradiobtn;
        private System.Windows.Forms.RadioButton creditradiobtn;
        private System.Windows.Forms.RadioButton receiptradiobtn;
        private System.Windows.Forms.RadioButton debitradiobtn;
        private System.Windows.Forms.RadioButton journalradiobtn;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label invoicenolbl;
    }
}