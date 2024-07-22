namespace SmartFlow.Sales.CommonForm
{
    partial class SearchSaleInvoice
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
            this.searchbtn = new System.Windows.Forms.Button();
            this.saleinvoicenotxtbox = new System.Windows.Forms.TextBox();
            this.quotationnolbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.panel1.Size = new System.Drawing.Size(640, 45);
            this.panel1.TabIndex = 70;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(640, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "SEARCH SALE INVOICE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(174, 124);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(432, 37);
            this.searchbtn.TabIndex = 73;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // saleinvoicenotxtbox
            // 
            this.saleinvoicenotxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.saleinvoicenotxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.saleinvoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saleinvoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleinvoicenotxtbox.Location = new System.Drawing.Point(174, 86);
            this.saleinvoicenotxtbox.Name = "saleinvoicenotxtbox";
            this.saleinvoicenotxtbox.Size = new System.Drawing.Size(432, 32);
            this.saleinvoicenotxtbox.TabIndex = 72;
            // 
            // quotationnolbl
            // 
            this.quotationnolbl.AutoSize = true;
            this.quotationnolbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationnolbl.Location = new System.Drawing.Point(12, 90);
            this.quotationnolbl.Name = "quotationnolbl";
            this.quotationnolbl.Size = new System.Drawing.Size(122, 24);
            this.quotationnolbl.TabIndex = 71;
            this.quotationnolbl.Text = "SALE INVOICE";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SearchSaleInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 230);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.saleinvoicenotxtbox);
            this.Controls.Add(this.quotationnolbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchSaleInvoice";
            this.Text = "Search Sale Invoice";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.TextBox saleinvoicenotxtbox;
        private System.Windows.Forms.Label quotationnolbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}