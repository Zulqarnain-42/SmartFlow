namespace SmartFlow.Sales.CommonForm
{
    partial class SearchQuotationForm
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
            this.quotationnolbl = new System.Windows.Forms.Label();
            this.quotationnotxtbox = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(640, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(640, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "SEARCH QUOTATION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quotationnolbl
            // 
            this.quotationnolbl.AutoSize = true;
            this.quotationnolbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationnolbl.Location = new System.Drawing.Point(12, 81);
            this.quotationnolbl.Name = "quotationnolbl";
            this.quotationnolbl.Size = new System.Drawing.Size(138, 24);
            this.quotationnolbl.TabIndex = 1;
            this.quotationnolbl.Text = "QUOTATION NO";
            // 
            // quotationnotxtbox
            // 
            this.quotationnotxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.quotationnotxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.quotationnotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quotationnotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationnotxtbox.Location = new System.Drawing.Point(174, 79);
            this.quotationnotxtbox.Name = "quotationnotxtbox";
            this.quotationnotxtbox.Size = new System.Drawing.Size(432, 32);
            this.quotationnotxtbox.TabIndex = 68;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(174, 117);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(432, 37);
            this.searchbtn.TabIndex = 69;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SearchQuotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 230);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.quotationnotxtbox);
            this.Controls.Add(this.quotationnolbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchQuotationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEARCH QUOTATION FORM";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchQuotationForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label quotationnolbl;
        private System.Windows.Forms.TextBox quotationnotxtbox;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}