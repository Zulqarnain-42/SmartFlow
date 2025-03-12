namespace SmartFlow.Report
{
    partial class SearchWithSerialNo
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
            this.serialnotxtbox = new System.Windows.Forms.TextBox();
            this.quotationnolbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.invoicedatetotxtbox = new System.Windows.Forms.MaskedTextBox();
            this.datetolbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.datelbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 37);
            this.panel1.TabIndex = 70;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(495, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "SEARCH SERIAL NO";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(139, 152);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(324, 30);
            this.searchbtn.TabIndex = 73;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // serialnotxtbox
            // 
            this.serialnotxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serialnotxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.serialnotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialnotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnotxtbox.Location = new System.Drawing.Point(139, 59);
            this.serialnotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.serialnotxtbox.Name = "serialnotxtbox";
            this.serialnotxtbox.Size = new System.Drawing.Size(324, 27);
            this.serialnotxtbox.TabIndex = 72;
            // 
            // quotationnolbl
            // 
            this.quotationnolbl.AutoSize = true;
            this.quotationnolbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationnolbl.Location = new System.Drawing.Point(18, 61);
            this.quotationnolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quotationnolbl.Name = "quotationnolbl";
            this.quotationnolbl.Size = new System.Drawing.Size(78, 19);
            this.quotationnolbl.TabIndex = 71;
            this.quotationnolbl.Text = "SERIAL NO";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // invoicedatetotxtbox
            // 
            this.invoicedatetotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetotxtbox.Location = new System.Drawing.Point(139, 121);
            this.invoicedatetotxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.invoicedatetotxtbox.Mask = "00/00/0000";
            this.invoicedatetotxtbox.Name = "invoicedatetotxtbox";
            this.invoicedatetotxtbox.Size = new System.Drawing.Size(324, 27);
            this.invoicedatetotxtbox.TabIndex = 149;
            this.invoicedatetotxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // datetolbl
            // 
            this.datetolbl.AutoSize = true;
            this.datetolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetolbl.Location = new System.Drawing.Point(19, 124);
            this.datetolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datetolbl.Name = "datetolbl";
            this.datetolbl.Size = new System.Drawing.Size(59, 18);
            this.datetolbl.TabIndex = 148;
            this.datetolbl.Text = "DATE TO";
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(139, 90);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(324, 27);
            this.invoicedatetxtbox.TabIndex = 147;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(19, 93);
            this.datelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(79, 18);
            this.datelbl.TabIndex = 146;
            this.datelbl.Text = "DATE FROM";
            // 
            // SearchWithSerialNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 211);
            this.Controls.Add(this.invoicedatetotxtbox);
            this.Controls.Add(this.datetolbl);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.serialnotxtbox);
            this.Controls.Add(this.quotationnolbl);
            this.Name = "SearchWithSerialNo";
            this.Text = "SEARCH WITH SERIAL NO";
            this.Load += new System.EventHandler(this.SearchWithSerialNo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.TextBox serialnotxtbox;
        private System.Windows.Forms.Label quotationnolbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox invoicedatetotxtbox;
        private System.Windows.Forms.Label datetolbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Label datelbl;
    }
}