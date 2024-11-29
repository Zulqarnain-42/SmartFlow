namespace SmartFlow.Sales
{
    partial class CurrencySelection
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
            this.currencyselectlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.okbtn = new System.Windows.Forms.Button();
            this.currencyconversiontxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(569, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "CURRENCY DETAILS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currencyselectlbl
            // 
            this.currencyselectlbl.AutoSize = true;
            this.currencyselectlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyselectlbl.Location = new System.Drawing.Point(34, 82);
            this.currencyselectlbl.Name = "currencyselectlbl";
            this.currencyselectlbl.Size = new System.Drawing.Size(80, 23);
            this.currencyselectlbl.TabIndex = 1;
            this.currencyselectlbl.Text = "Currency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conversion Rate";
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.currencyComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.currencyComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(191, 83);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(294, 32);
            this.currencyComboBox.TabIndex = 0;
            // 
            // okbtn
            // 
            this.okbtn.Location = new System.Drawing.Point(191, 172);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(294, 31);
            this.okbtn.TabIndex = 2;
            this.okbtn.Text = "OK";
            this.okbtn.UseVisualStyleBackColor = true;
            this.okbtn.Click += new System.EventHandler(this.okbtn_Click);
            // 
            // currencyconversiontxtbox
            // 
            this.currencyconversiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencyconversiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyconversiontxtbox.Location = new System.Drawing.Point(191, 121);
            this.currencyconversiontxtbox.Mask = "0.000";
            this.currencyconversiontxtbox.Name = "currencyconversiontxtbox";
            this.currencyconversiontxtbox.Size = new System.Drawing.Size(294, 32);
            this.currencyconversiontxtbox.TabIndex = 1;
            this.currencyconversiontxtbox.Text = "1000";
            this.currencyconversiontxtbox.ValidatingType = typeof(int);
            // 
            // CurrencySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(569, 274);
            this.Controls.Add(this.currencyconversiontxtbox);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currencyselectlbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "CurrencySelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CURRENCY SELECTION";
            this.Load += new System.EventHandler(this.CurrencySelection_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label currencyselectlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.Button okbtn;
        private System.Windows.Forms.MaskedTextBox currencyconversiontxtbox;
    }
}