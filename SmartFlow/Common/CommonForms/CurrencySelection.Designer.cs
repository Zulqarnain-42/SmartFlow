namespace SmartFlow.Common.CommonForms
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.cmbcurrency = new System.Windows.Forms.ComboBox();
            this.selectcurrencylbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.conversionratelbl = new System.Windows.Forms.Label();
            this.conversionratetxtbox = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(507, 45);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(507, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "CURRENCY SELECTION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbcurrency
            // 
            this.cmbcurrency.FormattingEnabled = true;
            this.cmbcurrency.Location = new System.Drawing.Point(141, 80);
            this.cmbcurrency.Name = "cmbcurrency";
            this.cmbcurrency.Size = new System.Drawing.Size(327, 24);
            this.cmbcurrency.TabIndex = 1;
            // 
            // selectcurrencylbl
            // 
            this.selectcurrencylbl.AutoSize = true;
            this.selectcurrencylbl.Location = new System.Drawing.Point(12, 83);
            this.selectcurrencylbl.Name = "selectcurrencylbl";
            this.selectcurrencylbl.Size = new System.Drawing.Size(101, 16);
            this.selectcurrencylbl.TabIndex = 2;
            this.selectcurrencylbl.Text = "SELECT CURR";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(141, 139);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(327, 24);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // conversionratelbl
            // 
            this.conversionratelbl.AutoSize = true;
            this.conversionratelbl.Location = new System.Drawing.Point(12, 113);
            this.conversionratelbl.Name = "conversionratelbl";
            this.conversionratelbl.Size = new System.Drawing.Size(76, 16);
            this.conversionratelbl.TabIndex = 5;
            this.conversionratelbl.Text = "CON RATE";
            // 
            // conversionratetxtbox
            // 
            this.conversionratetxtbox.Location = new System.Drawing.Point(141, 111);
            this.conversionratetxtbox.Name = "conversionratetxtbox";
            this.conversionratetxtbox.Size = new System.Drawing.Size(327, 22);
            this.conversionratetxtbox.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // CurrencySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 204);
            this.Controls.Add(this.conversionratetxtbox);
            this.Controls.Add(this.conversionratelbl);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.selectcurrencylbl);
            this.Controls.Add(this.cmbcurrency);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CurrencySelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CURRENCY SELECTION";
            this.Load += new System.EventHandler(this.CurrencySelection_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.ComboBox cmbcurrency;
        private System.Windows.Forms.Label selectcurrencylbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label conversionratelbl;
        private System.Windows.Forms.TextBox conversionratetxtbox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}