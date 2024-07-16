namespace SmartFlow.Sales
{
    partial class FindSaleInvoiceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.salereturnradio = new System.Windows.Forms.RadioButton();
            this.saleinvoiceradio = new System.Windows.Forms.RadioButton();
            this.saleorderradio = new System.Windows.Forms.RadioButton();
            this.salequotationradio = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "FIND A SALE INVOICE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(172, 239);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(374, 35);
            this.searchbtn.TabIndex = 58;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "DATE";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(172, 162);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(374, 32);
            this.invoicenotxtbox.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 55;
            this.label3.Text = "INVOICE NO";
            // 
            // salereturnradio
            // 
            this.salereturnradio.AutoSize = true;
            this.salereturnradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salereturnradio.Location = new System.Drawing.Point(362, 108);
            this.salereturnradio.Name = "salereturnradio";
            this.salereturnradio.Size = new System.Drawing.Size(138, 27);
            this.salereturnradio.TabIndex = 54;
            this.salereturnradio.TabStop = true;
            this.salereturnradio.Text = "SALE RETURN ";
            this.salereturnradio.UseVisualStyleBackColor = true;
            // 
            // saleinvoiceradio
            // 
            this.saleinvoiceradio.AutoSize = true;
            this.saleinvoiceradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleinvoiceradio.Location = new System.Drawing.Point(53, 108);
            this.saleinvoiceradio.Name = "saleinvoiceradio";
            this.saleinvoiceradio.Size = new System.Drawing.Size(139, 27);
            this.saleinvoiceradio.TabIndex = 53;
            this.saleinvoiceradio.TabStop = true;
            this.saleinvoiceradio.Text = "SALE INVOICE";
            this.saleinvoiceradio.UseVisualStyleBackColor = true;
            // 
            // saleorderradio
            // 
            this.saleorderradio.AutoSize = true;
            this.saleorderradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleorderradio.Location = new System.Drawing.Point(362, 68);
            this.saleorderradio.Name = "saleorderradio";
            this.saleorderradio.Size = new System.Drawing.Size(126, 27);
            this.saleorderradio.TabIndex = 52;
            this.saleorderradio.TabStop = true;
            this.saleorderradio.Text = "SALE ORDER";
            this.saleorderradio.UseVisualStyleBackColor = true;
            // 
            // salequotationradio
            // 
            this.salequotationradio.AutoSize = true;
            this.salequotationradio.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salequotationradio.Location = new System.Drawing.Point(53, 68);
            this.salequotationradio.Name = "salequotationradio";
            this.salequotationradio.Size = new System.Drawing.Size(176, 27);
            this.salequotationradio.TabIndex = 51;
            this.salequotationradio.TabStop = true;
            this.salequotationradio.Text = "SALES QUOTATION";
            this.salequotationradio.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(172, 200);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(374, 32);
            this.invoicedatetxtbox.TabIndex = 116;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // FindSaleInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(622, 326);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.salereturnradio);
            this.Controls.Add(this.saleinvoiceradio);
            this.Controls.Add(this.saleorderradio);
            this.Controls.Add(this.salequotationradio);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindSaleInvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Invoice Form";
            this.Load += new System.EventHandler(this.FindSaleInvoiceForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton salereturnradio;
        private System.Windows.Forms.RadioButton saleinvoiceradio;
        private System.Windows.Forms.RadioButton saleorderradio;
        private System.Windows.Forms.RadioButton salequotationradio;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
    }
}