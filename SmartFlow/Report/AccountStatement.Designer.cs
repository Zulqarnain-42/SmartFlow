namespace SmartFlow.Report
{
    partial class AccountStatement
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
            this.selectaccountlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.selectaccounttxtbox = new System.Windows.Forms.TextBox();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.invoicedatetotxtbox = new System.Windows.Forms.MaskedTextBox();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.accountheadidlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.balancesheetlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 37);
            this.panel1.TabIndex = 0;
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
            this.balancesheetlbl.Text = "BALANCE SHEET";
            this.balancesheetlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectaccountlbl
            // 
            this.selectaccountlbl.AutoSize = true;
            this.selectaccountlbl.Location = new System.Drawing.Point(20, 63);
            this.selectaccountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectaccountlbl.Name = "selectaccountlbl";
            this.selectaccountlbl.Size = new System.Drawing.Size(103, 13);
            this.selectaccountlbl.TabIndex = 1;
            this.selectaccountlbl.Text = "SELECT ACCOUNT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "START DATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "END DATE";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(131, 136);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(305, 21);
            this.savebtn.TabIndex = 4;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // selectaccounttxtbox
            // 
            this.selectaccounttxtbox.Location = new System.Drawing.Point(131, 61);
            this.selectaccounttxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectaccounttxtbox.Name = "selectaccounttxtbox";
            this.selectaccounttxtbox.Size = new System.Drawing.Size(306, 20);
            this.selectaccounttxtbox.TabIndex = 5;
            this.selectaccounttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectaccounttxtbox_MouseClick);
            this.selectaccounttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectaccounttxtbox_KeyDown);
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.invoicedatetxtbox.Location = new System.Drawing.Point(131, 83);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(306, 19);
            this.invoicedatetxtbox.TabIndex = 8;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // invoicedatetotxtbox
            // 
            this.invoicedatetotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetotxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.invoicedatetotxtbox.Location = new System.Drawing.Point(131, 104);
            this.invoicedatetotxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.invoicedatetotxtbox.Mask = "00/00/0000";
            this.invoicedatetotxtbox.Name = "invoicedatetotxtbox";
            this.invoicedatetotxtbox.Size = new System.Drawing.Size(306, 19);
            this.invoicedatetotxtbox.TabIndex = 9;
            this.invoicedatetotxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(22, 136);
            this.accountidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(64, 13);
            this.accountidlbl.TabIndex = 10;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // accountheadidlbl
            // 
            this.accountheadidlbl.AutoSize = true;
            this.accountheadidlbl.Location = new System.Drawing.Point(25, 153);
            this.accountheadidlbl.Name = "accountheadidlbl";
            this.accountheadidlbl.Size = new System.Drawing.Size(88, 13);
            this.accountheadidlbl.TabIndex = 11;
            this.accountheadidlbl.Text = "accountheadidlbl";
            this.accountheadidlbl.Visible = false;
            // 
            // BalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 206);
            this.Controls.Add(this.accountheadidlbl);
            this.Controls.Add(this.accountidlbl);
            this.Controls.Add(this.invoicedatetotxtbox);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.selectaccounttxtbox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectaccountlbl);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BalanceSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK BALANCE SHEET";
            this.Load += new System.EventHandler(this.BalanceSheet_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label balancesheetlbl;
        private System.Windows.Forms.Label selectaccountlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox selectaccounttxtbox;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.MaskedTextBox invoicedatetotxtbox;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.Label accountheadidlbl;
    }
}