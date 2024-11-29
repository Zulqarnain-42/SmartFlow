namespace SmartFlow.Masters
{
    partial class UpdateOpeningBalance
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
            this.debitamountradio = new System.Windows.Forms.RadioButton();
            this.creditamountradio = new System.Windows.Forms.RadioButton();
            this.totalamountlbl = new System.Windows.Forms.Label();
            this.amounttxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.accountnamelbl = new System.Windows.Forms.Label();
            this.accountidlbl = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(616, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(616, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "UPDATE OPENING BALANCE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // debitamountradio
            // 
            this.debitamountradio.AutoSize = true;
            this.debitamountradio.Location = new System.Drawing.Point(96, 84);
            this.debitamountradio.Name = "debitamountradio";
            this.debitamountradio.Size = new System.Drawing.Size(130, 20);
            this.debitamountradio.TabIndex = 1;
            this.debitamountradio.TabStop = true;
            this.debitamountradio.Text = "DEBIT AMOUNT";
            this.debitamountradio.UseVisualStyleBackColor = true;
            // 
            // creditamountradio
            // 
            this.creditamountradio.AutoSize = true;
            this.creditamountradio.Location = new System.Drawing.Point(96, 110);
            this.creditamountradio.Name = "creditamountradio";
            this.creditamountradio.Size = new System.Drawing.Size(140, 20);
            this.creditamountradio.TabIndex = 2;
            this.creditamountradio.TabStop = true;
            this.creditamountradio.Text = "CREDIT AMOUNT";
            this.creditamountradio.UseVisualStyleBackColor = true;
            // 
            // totalamountlbl
            // 
            this.totalamountlbl.AutoSize = true;
            this.totalamountlbl.Location = new System.Drawing.Point(96, 157);
            this.totalamountlbl.Name = "totalamountlbl";
            this.totalamountlbl.Size = new System.Drawing.Size(116, 16);
            this.totalamountlbl.TabIndex = 3;
            this.totalamountlbl.Text = "TOTAL AMOUNT ";
            // 
            // amounttxtbox
            // 
            this.amounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amounttxtbox.Location = new System.Drawing.Point(218, 154);
            this.amounttxtbox.Name = "amounttxtbox";
            this.amounttxtbox.Size = new System.Drawing.Size(298, 22);
            this.amounttxtbox.TabIndex = 4;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(218, 183);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(298, 23);
            this.savebtn.TabIndex = 5;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(218, 212);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(298, 23);
            this.exitbtn.TabIndex = 6;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // accountnamelbl
            // 
            this.accountnamelbl.AutoSize = true;
            this.accountnamelbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnamelbl.ForeColor = System.Drawing.Color.Green;
            this.accountnamelbl.Location = new System.Drawing.Point(96, 56);
            this.accountnamelbl.Name = "accountnamelbl";
            this.accountnamelbl.Size = new System.Drawing.Size(53, 21);
            this.accountnamelbl.TabIndex = 7;
            this.accountnamelbl.Text = "label2";
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(12, 250);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(79, 16);
            this.accountidlbl.TabIndex = 8;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UpdateOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(616, 275);
            this.Controls.Add(this.accountidlbl);
            this.Controls.Add(this.accountnamelbl);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.amounttxtbox);
            this.Controls.Add(this.totalamountlbl);
            this.Controls.Add(this.creditamountradio);
            this.Controls.Add(this.debitamountradio);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "UpdateOpeningBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE OPENING BALANCE";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateOpeningBalance_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.RadioButton debitamountradio;
        private System.Windows.Forms.RadioButton creditamountradio;
        private System.Windows.Forms.Label totalamountlbl;
        private System.Windows.Forms.TextBox amounttxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Label accountnamelbl;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}