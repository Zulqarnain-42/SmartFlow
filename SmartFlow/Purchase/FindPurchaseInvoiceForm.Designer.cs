namespace SmartFlow.Purchase
{
    partial class FindPurchaseInvoiceForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.purchasequoteradio = new System.Windows.Forms.RadioButton();
            this.lporadio = new System.Windows.Forms.RadioButton();
            this.purchaseinvoiceradio = new System.Windows.Forms.RadioButton();
            this.purchasereturnradio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchbtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(622, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "FIND A PURCHASE INVOICE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchasequoteradio
            // 
            this.purchasequoteradio.AutoSize = true;
            this.purchasequoteradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasequoteradio.Location = new System.Drawing.Point(57, 76);
            this.purchasequoteradio.Name = "purchasequoteradio";
            this.purchasequoteradio.Size = new System.Drawing.Size(213, 27);
            this.purchasequoteradio.TabIndex = 1;
            this.purchasequoteradio.TabStop = true;
            this.purchasequoteradio.Text = "PURCHASE QUOTATION";
            this.purchasequoteradio.UseVisualStyleBackColor = true;
            // 
            // lporadio
            // 
            this.lporadio.AutoSize = true;
            this.lporadio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lporadio.Location = new System.Drawing.Point(366, 76);
            this.lporadio.Name = "lporadio";
            this.lporadio.Size = new System.Drawing.Size(62, 27);
            this.lporadio.TabIndex = 2;
            this.lporadio.TabStop = true;
            this.lporadio.Text = "LPO";
            this.lporadio.UseVisualStyleBackColor = true;
            // 
            // purchaseinvoiceradio
            // 
            this.purchaseinvoiceradio.AutoSize = true;
            this.purchaseinvoiceradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseinvoiceradio.Location = new System.Drawing.Point(57, 116);
            this.purchaseinvoiceradio.Name = "purchaseinvoiceradio";
            this.purchaseinvoiceradio.Size = new System.Drawing.Size(185, 27);
            this.purchaseinvoiceradio.TabIndex = 3;
            this.purchaseinvoiceradio.TabStop = true;
            this.purchaseinvoiceradio.Text = "PURCHASE INVOICE";
            this.purchaseinvoiceradio.UseVisualStyleBackColor = true;
            // 
            // purchasereturnradio
            // 
            this.purchasereturnradio.AutoSize = true;
            this.purchasereturnradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasereturnradio.Location = new System.Drawing.Point(366, 116);
            this.purchasereturnradio.Name = "purchasereturnradio";
            this.purchasereturnradio.Size = new System.Drawing.Size(184, 27);
            this.purchasereturnradio.TabIndex = 4;
            this.purchasereturnradio.TabStop = true;
            this.purchasereturnradio.Text = "PURCHASE RETURN ";
            this.purchasereturnradio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "INVOICE NO";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(176, 170);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(374, 32);
            this.invoicenotxtbox.TabIndex = 6;
            this.invoicenotxtbox.Leave += new System.EventHandler(this.invoicenotxtbox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "DATE";
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(176, 247);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(374, 35);
            this.searchbtn.TabIndex = 9;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(176, 209);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(374, 32);
            this.invoicedatetxtbox.TabIndex = 115;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // FindPurchaseInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(622, 326);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.purchasereturnradio);
            this.Controls.Add(this.purchaseinvoiceradio);
            this.Controls.Add(this.lporadio);
            this.Controls.Add(this.purchasequoteradio);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindPurchaseInvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIND PURCHASE INVOICE - FUTURE ART BROADCAST TRADING LLC";
            this.Load += new System.EventHandler(this.FindPurchaseInvoiceForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindPurchaseInvoiceForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.RadioButton purchasequoteradio;
        private System.Windows.Forms.RadioButton lporadio;
        private System.Windows.Forms.RadioButton purchaseinvoiceradio;
        private System.Windows.Forms.RadioButton purchasereturnradio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
    }
}