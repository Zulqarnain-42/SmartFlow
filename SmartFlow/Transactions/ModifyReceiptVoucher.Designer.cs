﻿namespace SmartFlow.Transactions
{
    partial class ModifyReceiptVoucher
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
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(434, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "EDIT RECEIPT VOUCHER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(110, 107);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(281, 27);
            this.invoicedatetxtbox.TabIndex = 121;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(110, 139);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(280, 28);
            this.searchbtn.TabIndex = 120;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(23, 112);
            this.datelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(39, 18);
            this.datelbl.TabIndex = 119;
            this.datelbl.Text = "DATE";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(110, 77);
            this.invoicenotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(281, 27);
            this.invoicenotxtbox.TabIndex = 118;
            this.invoicenotxtbox.TextChanged += new System.EventHandler(this.invoicenotxtbox_TextChanged);
            this.invoicenotxtbox.Leave += new System.EventHandler(this.invoicenotxtbox_Leave);
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(23, 81);
            this.invoicenolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(83, 18);
            this.invoicenolbl.TabIndex = 117;
            this.invoicenolbl.Text = "INVOICE NO";
            // 
            // ModifyReceiptVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.invoicenolbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModifyReceiptVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFY RECEIPT VOUCHER";
            this.Load += new System.EventHandler(this.ModifyReceiptVoucher_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label invoicenolbl;
    }
}