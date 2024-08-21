namespace SmartFlow.Sales.CommonForm
{
    partial class VATForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.vattxtbox = new System.Windows.Forms.TextBox();
            this.discounttxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.vatamountlbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.discountamountlbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.totalwithvatanddiscountlbl = new System.Windows.Forms.Label();
            this.percentageradio = new System.Windows.Forms.RadioButton();
            this.fixedamountradio = new System.Windows.Forms.RadioButton();
            this.unitcombobox = new System.Windows.Forms.ComboBox();
            this.unitlbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.totalwithvatlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.productconditionchkbox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
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
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(800, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ITEM WISE VAT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "VAT/TAX (%) : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "TAX/VAT AMOUNT : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "DISCOUNT AMOUNT : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 55);
            this.panel2.TabIndex = 6;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(648, 13);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(140, 30);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // vattxtbox
            // 
            this.vattxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vattxtbox.Location = new System.Drawing.Point(172, 109);
            this.vattxtbox.Name = "vattxtbox";
            this.vattxtbox.Size = new System.Drawing.Size(243, 22);
            this.vattxtbox.TabIndex = 7;
            this.vattxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vattxtbox.TextChanged += new System.EventHandler(this.vattxtbox_TextChanged);
            this.vattxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vattxtbox_KeyPress);
            // 
            // discounttxtbox
            // 
            this.discounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.discounttxtbox.Enabled = false;
            this.discounttxtbox.Location = new System.Drawing.Point(172, 240);
            this.discounttxtbox.Name = "discounttxtbox";
            this.discounttxtbox.Size = new System.Drawing.Size(243, 22);
            this.discounttxtbox.TabIndex = 8;
            this.discounttxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discounttxtbox.TextChanged += new System.EventHandler(this.discounttxtbox_TextChanged);
            this.discounttxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discounttxtbox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(435, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "label6";
            // 
            // vatamountlbl
            // 
            this.vatamountlbl.AutoSize = true;
            this.vatamountlbl.Location = new System.Drawing.Point(654, 112);
            this.vatamountlbl.Name = "vatamountlbl";
            this.vatamountlbl.Size = new System.Drawing.Size(83, 16);
            this.vatamountlbl.TabIndex = 10;
            this.vatamountlbl.Text = "vatamountlbl";
            this.vatamountlbl.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(435, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "DISCOUNT AMOUNT : ";
            // 
            // discountamountlbl
            // 
            this.discountamountlbl.AutoSize = true;
            this.discountamountlbl.Location = new System.Drawing.Point(654, 242);
            this.discountamountlbl.Name = "discountamountlbl";
            this.discountamountlbl.Size = new System.Drawing.Size(115, 16);
            this.discountamountlbl.TabIndex = 12;
            this.discountamountlbl.Text = "discountamountlbl";
            this.discountamountlbl.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(288, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "FINAL WITH VAT AND DISCOUNT AMOUNT : ";
            // 
            // totalwithvatanddiscountlbl
            // 
            this.totalwithvatanddiscountlbl.AutoSize = true;
            this.totalwithvatanddiscountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalwithvatanddiscountlbl.ForeColor = System.Drawing.Color.Blue;
            this.totalwithvatanddiscountlbl.Location = new System.Drawing.Point(311, 365);
            this.totalwithvatanddiscountlbl.Name = "totalwithvatanddiscountlbl";
            this.totalwithvatanddiscountlbl.Size = new System.Drawing.Size(247, 24);
            this.totalwithvatanddiscountlbl.TabIndex = 15;
            this.totalwithvatanddiscountlbl.Text = "totalwithvatanddiscountlbl";
            this.totalwithvatanddiscountlbl.Visible = false;
            // 
            // percentageradio
            // 
            this.percentageradio.AutoSize = true;
            this.percentageradio.Enabled = false;
            this.percentageradio.Location = new System.Drawing.Point(15, 210);
            this.percentageradio.Name = "percentageradio";
            this.percentageradio.Size = new System.Drawing.Size(121, 20);
            this.percentageradio.TabIndex = 23;
            this.percentageradio.TabStop = true;
            this.percentageradio.Text = "PERCENTAGE";
            this.percentageradio.UseVisualStyleBackColor = true;
            this.percentageradio.CheckedChanged += new System.EventHandler(this.percentageradio_CheckedChanged);
            // 
            // fixedamountradio
            // 
            this.fixedamountradio.AutoSize = true;
            this.fixedamountradio.Enabled = false;
            this.fixedamountradio.Location = new System.Drawing.Point(15, 184);
            this.fixedamountradio.Name = "fixedamountradio";
            this.fixedamountradio.Size = new System.Drawing.Size(128, 20);
            this.fixedamountradio.TabIndex = 22;
            this.fixedamountradio.TabStop = true;
            this.fixedamountradio.Text = "FIXED AMOUNT";
            this.fixedamountradio.UseVisualStyleBackColor = true;
            this.fixedamountradio.CheckedChanged += new System.EventHandler(this.fixedamountradio_CheckedChanged);
            // 
            // unitcombobox
            // 
            this.unitcombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unitcombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unitcombobox.FormattingEnabled = true;
            this.unitcombobox.Location = new System.Drawing.Point(172, 268);
            this.unitcombobox.Name = "unitcombobox";
            this.unitcombobox.Size = new System.Drawing.Size(243, 24);
            this.unitcombobox.TabIndex = 25;
            // 
            // unitlbl
            // 
            this.unitlbl.AutoSize = true;
            this.unitlbl.Location = new System.Drawing.Point(12, 271);
            this.unitlbl.Name = "unitlbl";
            this.unitlbl.Size = new System.Drawing.Size(39, 16);
            this.unitlbl.TabIndex = 24;
            this.unitlbl.Text = "UNIT";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // totalwithvatlbl
            // 
            this.totalwithvatlbl.AutoSize = true;
            this.totalwithvatlbl.Location = new System.Drawing.Point(654, 128);
            this.totalwithvatlbl.Name = "totalwithvatlbl";
            this.totalwithvatlbl.Size = new System.Drawing.Size(86, 16);
            this.totalwithvatlbl.TabIndex = 26;
            this.totalwithvatlbl.Text = "totalwithvatlbl";
            this.totalwithvatlbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TAXABLE AMOUNT : ";
            // 
            // productconditionchkbox
            // 
            this.productconditionchkbox.AutoSize = true;
            this.productconditionchkbox.Checked = true;
            this.productconditionchkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.productconditionchkbox.Location = new System.Drawing.Point(440, 183);
            this.productconditionchkbox.Name = "productconditionchkbox";
            this.productconditionchkbox.Size = new System.Drawing.Size(131, 20);
            this.productconditionchkbox.TabIndex = 27;
            this.productconditionchkbox.Text = "NEW PRODUCT";
            this.productconditionchkbox.UseVisualStyleBackColor = true;
            this.productconditionchkbox.CheckedChanged += new System.EventHandler(this.productconditionchkbox_CheckedChanged);
            // 
            // VATForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.productconditionchkbox);
            this.Controls.Add(this.totalwithvatlbl);
            this.Controls.Add(this.unitcombobox);
            this.Controls.Add(this.unitlbl);
            this.Controls.Add(this.percentageradio);
            this.Controls.Add(this.fixedamountradio);
            this.Controls.Add(this.totalwithvatanddiscountlbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.discountamountlbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vatamountlbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.discounttxtbox);
            this.Controls.Add(this.vattxtbox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "VATForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ITEM WISE VAT";
            this.Load += new System.EventHandler(this.VATForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VATForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox vattxtbox;
        private System.Windows.Forms.TextBox discounttxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label vatamountlbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label discountamountlbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label totalwithvatanddiscountlbl;
        private System.Windows.Forms.RadioButton percentageradio;
        private System.Windows.Forms.RadioButton fixedamountradio;
        private System.Windows.Forms.ComboBox unitcombobox;
        private System.Windows.Forms.Label unitlbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label totalwithvatlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox productconditionchkbox;
    }
}