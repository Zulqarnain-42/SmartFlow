namespace SmartFlow.Report
{
    partial class BalanceSheet
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.balancesheetlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 45);
            this.panel1.TabIndex = 0;
            // 
            // balancesheetlbl
            // 
            this.balancesheetlbl.BackColor = System.Drawing.Color.Black;
            this.balancesheetlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balancesheetlbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancesheetlbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.balancesheetlbl.Location = new System.Drawing.Point(0, 0);
            this.balancesheetlbl.Name = "balancesheetlbl";
            this.balancesheetlbl.Size = new System.Drawing.Size(624, 45);
            this.balancesheetlbl.TabIndex = 0;
            this.balancesheetlbl.Text = "BALANCE SHEET";
            this.balancesheetlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectaccountlbl
            // 
            this.selectaccountlbl.AutoSize = true;
            this.selectaccountlbl.Location = new System.Drawing.Point(27, 78);
            this.selectaccountlbl.Name = "selectaccountlbl";
            this.selectaccountlbl.Size = new System.Drawing.Size(128, 16);
            this.selectaccountlbl.TabIndex = 1;
            this.selectaccountlbl.Text = "SELECT ACCOUNT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "START DATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "END DATE";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(175, 167);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(407, 26);
            this.savebtn.TabIndex = 4;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // selectaccounttxtbox
            // 
            this.selectaccounttxtbox.Location = new System.Drawing.Point(175, 75);
            this.selectaccounttxtbox.Name = "selectaccounttxtbox";
            this.selectaccounttxtbox.Size = new System.Drawing.Size(407, 22);
            this.selectaccounttxtbox.TabIndex = 5;
            this.selectaccounttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectaccounttxtbox_MouseClick);
            this.selectaccounttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectaccounttxtbox_KeyDown);
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.invoicedatetxtbox.Location = new System.Drawing.Point(175, 102);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(407, 22);
            this.invoicedatetxtbox.TabIndex = 8;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.maskedTextBox1.Location = new System.Drawing.Point(175, 128);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(407, 22);
            this.maskedTextBox1.TabIndex = 9;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(30, 167);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(79, 16);
            this.accountidlbl.TabIndex = 10;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // BalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 254);
            this.Controls.Add(this.accountidlbl);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.selectaccounttxtbox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectaccountlbl);
            this.Controls.Add(this.panel1);
            this.Name = "BalanceSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK BALANCE SHEET";
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
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label accountidlbl;
    }
}