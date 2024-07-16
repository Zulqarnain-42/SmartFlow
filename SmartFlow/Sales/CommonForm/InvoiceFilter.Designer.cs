namespace SmartFlow.Sales.CommonForm
{
    partial class InvoiceFilter
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
            this.enddatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.enddatelbl = new System.Windows.Forms.Label();
            this.startdatelbl = new System.Windows.Forms.Label();
            this.startdatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.searchbtn = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(657, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(657, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "INVOICES FILTER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enddatetxtbox
            // 
            this.enddatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enddatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatetxtbox.Location = new System.Drawing.Point(198, 133);
            this.enddatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.enddatetxtbox.Mask = "00/00/0000";
            this.enddatetxtbox.Name = "enddatetxtbox";
            this.enddatetxtbox.Size = new System.Drawing.Size(360, 32);
            this.enddatetxtbox.TabIndex = 1;
            this.enddatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // enddatelbl
            // 
            this.enddatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatelbl.AutoSize = true;
            this.enddatelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatelbl.Location = new System.Drawing.Point(74, 138);
            this.enddatelbl.Name = "enddatelbl";
            this.enddatelbl.Size = new System.Drawing.Size(87, 23);
            this.enddatelbl.TabIndex = 123;
            this.enddatelbl.Text = "END DATE";
            // 
            // startdatelbl
            // 
            this.startdatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatelbl.AutoSize = true;
            this.startdatelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatelbl.Location = new System.Drawing.Point(74, 100);
            this.startdatelbl.Name = "startdatelbl";
            this.startdatelbl.Size = new System.Drawing.Size(101, 23);
            this.startdatelbl.TabIndex = 122;
            this.startdatelbl.Text = "START DATE";
            // 
            // startdatetxtbox
            // 
            this.startdatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startdatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatetxtbox.Location = new System.Drawing.Point(198, 95);
            this.startdatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.startdatetxtbox.Mask = "00/00/0000";
            this.startdatetxtbox.Name = "startdatetxtbox";
            this.startdatetxtbox.Size = new System.Drawing.Size(360, 32);
            this.startdatetxtbox.TabIndex = 0;
            this.startdatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(198, 172);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(360, 36);
            this.searchbtn.TabIndex = 2;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // InvoiceFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(657, 287);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.enddatetxtbox);
            this.Controls.Add(this.enddatelbl);
            this.Controls.Add(this.startdatelbl);
            this.Controls.Add(this.startdatetxtbox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "InvoiceFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Filter";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.MaskedTextBox enddatetxtbox;
        private System.Windows.Forms.Label enddatelbl;
        private System.Windows.Forms.Label startdatelbl;
        private System.Windows.Forms.MaskedTextBox startdatetxtbox;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}