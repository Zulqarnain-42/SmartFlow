namespace SmartFlow.Masters
{
    partial class AddCompany
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
            this.companynamelbl = new System.Windows.Forms.Label();
            this.addresslbl = new System.Windows.Forms.Label();
            this.countrylbl = new System.Windows.Forms.Label();
            this.companynametxtbox = new System.Windows.Forms.TextBox();
            this.countrynametxtbox = new System.Windows.Forms.TextBox();
            this.addresstxtbox = new System.Windows.Forms.RichTextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(559, 37);
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
            this.headinglbl.Size = new System.Drawing.Size(559, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ADD CUSTOMER NEW COMPANY";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // companynamelbl
            // 
            this.companynamelbl.AutoSize = true;
            this.companynamelbl.Location = new System.Drawing.Point(24, 71);
            this.companynamelbl.Name = "companynamelbl";
            this.companynamelbl.Size = new System.Drawing.Size(94, 13);
            this.companynamelbl.TabIndex = 1;
            this.companynamelbl.Text = "COMPANY NAME";
            // 
            // addresslbl
            // 
            this.addresslbl.AutoSize = true;
            this.addresslbl.Location = new System.Drawing.Point(24, 122);
            this.addresslbl.Name = "addresslbl";
            this.addresslbl.Size = new System.Drawing.Size(59, 13);
            this.addresslbl.TabIndex = 2;
            this.addresslbl.Text = "ADDRESS";
            // 
            // countrylbl
            // 
            this.countrylbl.AutoSize = true;
            this.countrylbl.Location = new System.Drawing.Point(24, 97);
            this.countrylbl.Name = "countrylbl";
            this.countrylbl.Size = new System.Drawing.Size(60, 13);
            this.countrylbl.TabIndex = 3;
            this.countrylbl.Text = "COUNTRY";
            // 
            // companynametxtbox
            // 
            this.companynametxtbox.Location = new System.Drawing.Point(182, 67);
            this.companynametxtbox.Name = "companynametxtbox";
            this.companynametxtbox.Size = new System.Drawing.Size(304, 20);
            this.companynametxtbox.TabIndex = 4;
            // 
            // countrynametxtbox
            // 
            this.countrynametxtbox.Location = new System.Drawing.Point(182, 93);
            this.countrynametxtbox.Name = "countrynametxtbox";
            this.countrynametxtbox.Size = new System.Drawing.Size(304, 20);
            this.countrynametxtbox.TabIndex = 5;
            // 
            // addresstxtbox
            // 
            this.addresstxtbox.Location = new System.Drawing.Point(182, 119);
            this.addresstxtbox.Name = "addresstxtbox";
            this.addresstxtbox.Size = new System.Drawing.Size(304, 96);
            this.addresstxtbox.TabIndex = 6;
            this.addresstxtbox.Text = "";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(182, 221);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(304, 27);
            this.savebtn.TabIndex = 7;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(182, 254);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(304, 27);
            this.exitbtn.TabIndex = 8;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 333);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.addresstxtbox);
            this.Controls.Add(this.countrynametxtbox);
            this.Controls.Add(this.companynametxtbox);
            this.Controls.Add(this.countrylbl);
            this.Controls.Add(this.addresslbl);
            this.Controls.Add(this.companynamelbl);
            this.Controls.Add(this.panel1);
            this.Name = "AddCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD CUSTOMER COMPANY";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label companynamelbl;
        private System.Windows.Forms.Label addresslbl;
        private System.Windows.Forms.Label countrylbl;
        private System.Windows.Forms.TextBox companynametxtbox;
        private System.Windows.Forms.TextBox countrynametxtbox;
        private System.Windows.Forms.RichTextBox addresstxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}