namespace SmartFlow.Stock
{
    partial class BoxForm
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
            this.dgvpackinglist = new System.Windows.Forms.DataGridView();
            this.srnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.quantitytxtbox = new System.Windows.Forms.TextBox();
            this.boxnotxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.lengthtxtbox = new System.Windows.Forms.TextBox();
            this.widthtxtbox = new System.Windows.Forms.TextBox();
            this.heighttxtbox = new System.Windows.Forms.TextBox();
            this.weighttxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpackinglist)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(800, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "PACKING LIST BOX";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvpackinglist
            // 
            this.dgvpackinglist.AllowUserToAddRows = false;
            this.dgvpackinglist.AllowUserToDeleteRows = false;
            this.dgvpackinglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpackinglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srnocolumn,
            this.productid,
            this.productmfr,
            this.productname,
            this.quantity});
            this.dgvpackinglist.Location = new System.Drawing.Point(5, 214);
            this.dgvpackinglist.Name = "dgvpackinglist";
            this.dgvpackinglist.ReadOnly = true;
            this.dgvpackinglist.RowHeadersVisible = false;
            this.dgvpackinglist.Size = new System.Drawing.Size(783, 252);
            this.dgvpackinglist.TabIndex = 1;
            this.dgvpackinglist.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvpackinglist_CellFormatting);
            this.dgvpackinglist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvpackinglist_KeyDown);
            // 
            // srnocolumn
            // 
            this.srnocolumn.HeaderText = "#";
            this.srnocolumn.Name = "srnocolumn";
            this.srnocolumn.ReadOnly = true;
            this.srnocolumn.Width = 50;
            // 
            // productid
            // 
            this.productid.HeaderText = "productid";
            this.productid.Name = "productid";
            this.productid.ReadOnly = true;
            this.productid.Visible = false;
            // 
            // productmfr
            // 
            this.productmfr.HeaderText = "MFR";
            this.productmfr.Name = "productmfr";
            this.productmfr.ReadOnly = true;
            this.productmfr.Width = 150;
            // 
            // productname
            // 
            this.productname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productname.HeaderText = "DESCRIPTION";
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "QUANTITY";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 60);
            this.panel2.TabIndex = 2;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(582, 25);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(100, 23);
            this.exitbtn.TabIndex = 1;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(688, 25);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(100, 23);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Location = new System.Drawing.Point(13, 58);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(69, 13);
            this.invoicenolbl.TabIndex = 3;
            this.invoicenolbl.Text = "INVOICE NO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SELECT PRODUCT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "QUANTITY";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.Location = new System.Drawing.Point(123, 54);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(273, 20);
            this.invoicenotxtbox.TabIndex = 6;
            this.invoicenotxtbox.Leave += new System.EventHandler(this.invoicenotxtbox_Leave);
            // 
            // quantitytxtbox
            // 
            this.quantitytxtbox.Location = new System.Drawing.Point(123, 107);
            this.quantitytxtbox.Name = "quantitytxtbox";
            this.quantitytxtbox.Size = new System.Drawing.Size(273, 20);
            this.quantitytxtbox.TabIndex = 8;
            // 
            // boxnotxtbox
            // 
            this.boxnotxtbox.Location = new System.Drawing.Point(529, 54);
            this.boxnotxtbox.Name = "boxnotxtbox";
            this.boxnotxtbox.Size = new System.Drawing.Size(259, 20);
            this.boxnotxtbox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "BOX NO";
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(123, 133);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(273, 23);
            this.addbtn.TabIndex = 11;
            this.addbtn.Text = "ADD ROW";
            this.addbtn.UseVisualStyleBackColor = true;
            // 
            // lengthtxtbox
            // 
            this.lengthtxtbox.Location = new System.Drawing.Point(529, 80);
            this.lengthtxtbox.Name = "lengthtxtbox";
            this.lengthtxtbox.Size = new System.Drawing.Size(259, 20);
            this.lengthtxtbox.TabIndex = 12;
            // 
            // widthtxtbox
            // 
            this.widthtxtbox.Location = new System.Drawing.Point(529, 107);
            this.widthtxtbox.Name = "widthtxtbox";
            this.widthtxtbox.Size = new System.Drawing.Size(259, 20);
            this.widthtxtbox.TabIndex = 13;
            // 
            // heighttxtbox
            // 
            this.heighttxtbox.Location = new System.Drawing.Point(529, 132);
            this.heighttxtbox.Name = "heighttxtbox";
            this.heighttxtbox.Size = new System.Drawing.Size(259, 20);
            this.heighttxtbox.TabIndex = 14;
            // 
            // weighttxtbox
            // 
            this.weighttxtbox.Location = new System.Drawing.Point(529, 158);
            this.weighttxtbox.Name = "weighttxtbox";
            this.weighttxtbox.Size = new System.Drawing.Size(259, 20);
            this.weighttxtbox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "LENGTH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "WIDTH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "HEIGHT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "WEIGHT";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // BoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.weighttxtbox);
            this.Controls.Add(this.heighttxtbox);
            this.Controls.Add(this.widthtxtbox);
            this.Controls.Add(this.lengthtxtbox);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.boxnotxtbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quantitytxtbox);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invoicenolbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvpackinglist);
            this.Controls.Add(this.panel1);
            this.Name = "BoxForm";
            this.Text = "PACKING LIST BOX";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpackinglist)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.DataGridView dgvpackinglist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.TextBox quantitytxtbox;
        private System.Windows.Forms.TextBox boxnotxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnocolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.TextBox lengthtxtbox;
        private System.Windows.Forms.TextBox widthtxtbox;
        private System.Windows.Forms.TextBox heighttxtbox;
        private System.Windows.Forms.TextBox weighttxtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}