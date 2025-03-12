namespace SmartFlow.Report
{
    partial class ItemWiseSalesReturn
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
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.searchbtn = new System.Windows.Forms.Button();
            this.invoicedatetotxtbox = new System.Windows.Forms.MaskedTextBox();
            this.datetolbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.datelbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mfrtxtbox = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(508, 37);
            this.panel1.TabIndex = 151;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(508, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ITEM WISE SALES RETURN";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 12F);
            this.selectproducttxtbox.Location = new System.Drawing.Point(175, 78);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(281, 27);
            this.selectproducttxtbox.TabIndex = 158;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // selectproductlbl
            // 
            this.selectproductlbl.AutoSize = true;
            this.selectproductlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.selectproductlbl.Location = new System.Drawing.Point(24, 82);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(112, 18);
            this.selectproductlbl.TabIndex = 157;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(175, 172);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(281, 28);
            this.searchbtn.TabIndex = 156;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // invoicedatetotxtbox
            // 
            this.invoicedatetotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetotxtbox.Location = new System.Drawing.Point(175, 140);
            this.invoicedatetotxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.invoicedatetotxtbox.Mask = "00/00/0000";
            this.invoicedatetotxtbox.Name = "invoicedatetotxtbox";
            this.invoicedatetotxtbox.Size = new System.Drawing.Size(281, 27);
            this.invoicedatetotxtbox.TabIndex = 155;
            this.invoicedatetotxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // datetolbl
            // 
            this.datetolbl.AutoSize = true;
            this.datetolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetolbl.Location = new System.Drawing.Point(24, 144);
            this.datetolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datetolbl.Name = "datetolbl";
            this.datetolbl.Size = new System.Drawing.Size(59, 18);
            this.datetolbl.TabIndex = 154;
            this.datetolbl.Text = "DATE TO";
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(175, 109);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(281, 27);
            this.invoicedatetxtbox.TabIndex = 153;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(24, 113);
            this.datelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(79, 18);
            this.datelbl.TabIndex = 152;
            this.datelbl.Text = "DATE FROM";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.AutoSize = true;
            this.mfrtxtbox.Location = new System.Drawing.Point(27, 187);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.Size = new System.Drawing.Size(49, 13);
            this.mfrtxtbox.TabIndex = 160;
            this.mfrtxtbox.Text = "mfrtxtbox";
            this.mfrtxtbox.Visible = false;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(27, 172);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(61, 13);
            this.productidlbl.TabIndex = 159;
            this.productidlbl.Text = "productidlbl";
            this.productidlbl.Visible = false;
            // 
            // ItemWiseSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 211);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectproducttxtbox);
            this.Controls.Add(this.selectproductlbl);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.invoicedatetotxtbox);
            this.Controls.Add(this.datetolbl);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.mfrtxtbox);
            this.Controls.Add(this.productidlbl);
            this.Name = "ItemWiseSalesReturn";
            this.Text = "ITEM WISE SALES RETURN";
            this.Load += new System.EventHandler(this.ItemWiseSalesReturn_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Label selectproductlbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.MaskedTextBox invoicedatetotxtbox;
        private System.Windows.Forms.Label datetolbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label mfrtxtbox;
        private System.Windows.Forms.Label productidlbl;
    }
}