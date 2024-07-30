namespace SmartFlow.Sales.CommonForm
{
    partial class DiscountForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.discounttxtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fixedamountradio = new System.Windows.Forms.RadioButton();
            this.percentageradio = new System.Windows.Forms.RadioButton();
            this.unitlbl = new System.Windows.Forms.Label();
            this.unitcombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalwithdiscountlbl = new System.Windows.Forms.Label();
            this.discountamountlbl = new System.Windows.Forms.Label();
            this.productconditionchkbox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.headinglbl.Text = "ITEM WISE DISCOUNT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 55);
            this.panel2.TabIndex = 7;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(453, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "DISCOUNT AMOUNT : ";
            // 
            // discounttxtbox
            // 
            this.discounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.discounttxtbox.Enabled = false;
            this.discounttxtbox.Location = new System.Drawing.Point(190, 216);
            this.discounttxtbox.Name = "discounttxtbox";
            this.discounttxtbox.Size = new System.Drawing.Size(243, 22);
            this.discounttxtbox.TabIndex = 16;
            this.discounttxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discounttxtbox.TextChanged += new System.EventHandler(this.discounttxtbox_TextChanged);
            this.discounttxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discounttxtbox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "FINAL WITH DISCOUNT AMOUNT : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "DISCOUNT AMOUNT : ";
            // 
            // fixedamountradio
            // 
            this.fixedamountradio.AutoSize = true;
            this.fixedamountradio.Location = new System.Drawing.Point(33, 133);
            this.fixedamountradio.Name = "fixedamountradio";
            this.fixedamountradio.Size = new System.Drawing.Size(128, 20);
            this.fixedamountradio.TabIndex = 20;
            this.fixedamountradio.TabStop = true;
            this.fixedamountradio.Text = "FIXED AMOUNT";
            this.fixedamountradio.UseVisualStyleBackColor = true;
            this.fixedamountradio.CheckedChanged += new System.EventHandler(this.fixedamountradio_CheckedChanged);
            // 
            // percentageradio
            // 
            this.percentageradio.AutoSize = true;
            this.percentageradio.Location = new System.Drawing.Point(33, 159);
            this.percentageradio.Name = "percentageradio";
            this.percentageradio.Size = new System.Drawing.Size(121, 20);
            this.percentageradio.TabIndex = 21;
            this.percentageradio.TabStop = true;
            this.percentageradio.Text = "PERCENTAGE";
            this.percentageradio.UseVisualStyleBackColor = true;
            this.percentageradio.CheckedChanged += new System.EventHandler(this.percentageradio_CheckedChanged);
            // 
            // unitlbl
            // 
            this.unitlbl.AutoSize = true;
            this.unitlbl.Location = new System.Drawing.Point(30, 247);
            this.unitlbl.Name = "unitlbl";
            this.unitlbl.Size = new System.Drawing.Size(39, 16);
            this.unitlbl.TabIndex = 22;
            this.unitlbl.Text = "UNIT";
            // 
            // unitcombobox
            // 
            this.unitcombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unitcombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unitcombobox.FormattingEnabled = true;
            this.unitcombobox.Location = new System.Drawing.Point(190, 244);
            this.unitcombobox.Name = "unitcombobox";
            this.unitcombobox.Size = new System.Drawing.Size(243, 24);
            this.unitcombobox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "TOTAL AMOUNT : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(421, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "label6";
            // 
            // totalwithdiscountlbl
            // 
            this.totalwithdiscountlbl.AutoSize = true;
            this.totalwithdiscountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalwithdiscountlbl.ForeColor = System.Drawing.Color.Blue;
            this.totalwithdiscountlbl.Location = new System.Drawing.Point(262, 345);
            this.totalwithdiscountlbl.Name = "totalwithdiscountlbl";
            this.totalwithdiscountlbl.Size = new System.Drawing.Size(186, 24);
            this.totalwithdiscountlbl.TabIndex = 26;
            this.totalwithdiscountlbl.Text = "totalwithdiscountlbl";
            this.totalwithdiscountlbl.Visible = false;
            // 
            // discountamountlbl
            // 
            this.discountamountlbl.AutoSize = true;
            this.discountamountlbl.Location = new System.Drawing.Point(645, 218);
            this.discountamountlbl.Name = "discountamountlbl";
            this.discountamountlbl.Size = new System.Drawing.Size(115, 16);
            this.discountamountlbl.TabIndex = 27;
            this.discountamountlbl.Text = "discountamountlbl";
            this.discountamountlbl.Visible = false;
            // 
            // productconditionchkbox
            // 
            this.productconditionchkbox.AutoSize = true;
            this.productconditionchkbox.Checked = true;
            this.productconditionchkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.productconditionchkbox.Location = new System.Drawing.Point(456, 134);
            this.productconditionchkbox.Name = "productconditionchkbox";
            this.productconditionchkbox.Size = new System.Drawing.Size(131, 20);
            this.productconditionchkbox.TabIndex = 28;
            this.productconditionchkbox.Text = "NEW PRODUCT";
            this.productconditionchkbox.UseVisualStyleBackColor = true;
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.productconditionchkbox);
            this.Controls.Add(this.discountamountlbl);
            this.Controls.Add(this.totalwithdiscountlbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unitcombobox);
            this.Controls.Add(this.unitlbl);
            this.Controls.Add(this.percentageradio);
            this.Controls.Add(this.fixedamountradio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.discounttxtbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiscountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ITEM WISE DISCOUNT";
            this.Load += new System.EventHandler(this.DiscountForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox discounttxtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton fixedamountradio;
        private System.Windows.Forms.RadioButton percentageradio;
        private System.Windows.Forms.Label unitlbl;
        private System.Windows.Forms.ComboBox unitcombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalwithdiscountlbl;
        private System.Windows.Forms.Label discountamountlbl;
        private System.Windows.Forms.CheckBox productconditionchkbox;
    }
}