namespace SmartFlow.Report
{
    partial class AccountWisePayment
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
            this.balancesheetlbl = new System.Windows.Forms.Label();
            this.accountheadidlbl = new System.Windows.Forms.Label();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.invoicedatetotxtbox = new System.Windows.Forms.MaskedTextBox();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.selectaccounttxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectaccountlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.balancesheetlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 37);
            this.panel1.TabIndex = 22;
            // 
            // balancesheetlbl
            // 
            this.balancesheetlbl.BackColor = System.Drawing.Color.Black;
            this.balancesheetlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balancesheetlbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancesheetlbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.balancesheetlbl.Location = new System.Drawing.Point(0, 0);
            this.balancesheetlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.balancesheetlbl.Name = "balancesheetlbl";
            this.balancesheetlbl.Size = new System.Drawing.Size(468, 37);
            this.balancesheetlbl.TabIndex = 0;
            this.balancesheetlbl.Text = "ACCOUNT WISE PAYMENT";
            this.balancesheetlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accountheadidlbl
            // 
            this.accountheadidlbl.AutoSize = true;
            this.accountheadidlbl.Location = new System.Drawing.Point(25, 183);
            this.accountheadidlbl.Name = "accountheadidlbl";
            this.accountheadidlbl.Size = new System.Drawing.Size(88, 13);
            this.accountheadidlbl.TabIndex = 31;
            this.accountheadidlbl.Text = "accountheadidlbl";
            this.accountheadidlbl.Visible = false;
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(22, 166);
            this.accountidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(64, 13);
            this.accountidlbl.TabIndex = 30;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // invoicedatetotxtbox
            // 
            this.invoicedatetotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetotxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.invoicedatetotxtbox.Location = new System.Drawing.Point(131, 134);
            this.invoicedatetotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicedatetotxtbox.Mask = "00/00/0000";
            this.invoicedatetotxtbox.Name = "invoicedatetotxtbox";
            this.invoicedatetotxtbox.Size = new System.Drawing.Size(306, 19);
            this.invoicedatetotxtbox.TabIndex = 29;
            this.invoicedatetotxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.invoicedatetxtbox.Location = new System.Drawing.Point(131, 113);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(306, 19);
            this.invoicedatetxtbox.TabIndex = 28;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // selectaccounttxtbox
            // 
            this.selectaccounttxtbox.Location = new System.Drawing.Point(131, 91);
            this.selectaccounttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectaccounttxtbox.Name = "selectaccounttxtbox";
            this.selectaccounttxtbox.Size = new System.Drawing.Size(306, 20);
            this.selectaccounttxtbox.TabIndex = 27;
            this.selectaccounttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectaccounttxtbox_MouseClick);
            this.selectaccounttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectaccounttxtbox_KeyDown);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(131, 166);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(305, 21);
            this.savebtn.TabIndex = 26;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "END DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "START DATE";
            // 
            // selectaccountlbl
            // 
            this.selectaccountlbl.AutoSize = true;
            this.selectaccountlbl.Location = new System.Drawing.Point(20, 93);
            this.selectaccountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectaccountlbl.Name = "selectaccountlbl";
            this.selectaccountlbl.Size = new System.Drawing.Size(103, 13);
            this.selectaccountlbl.TabIndex = 23;
            this.selectaccountlbl.Text = "SELECT ACCOUNT";
            // 
            // AccountWisePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 206);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.accountheadidlbl);
            this.Controls.Add(this.accountidlbl);
            this.Controls.Add(this.invoicedatetotxtbox);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.selectaccounttxtbox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectaccountlbl);
            this.Name = "AccountWisePayment";
            this.Text = "ACCOUNT WISE PAYMENT";
            this.Load += new System.EventHandler(this.AccountWisePayment_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label balancesheetlbl;
        private System.Windows.Forms.Label accountheadidlbl;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetotxtbox;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.TextBox selectaccounttxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label selectaccountlbl;
    }
}