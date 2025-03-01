namespace SmartFlow.Transactions.CommonForm
{
    partial class DebitAndCreditForm
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
            this.isdebitentrylbl = new System.Windows.Forms.RadioButton();
            this.iscreditentrylbl = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.savebtn = new System.Windows.Forms.Button();
            this.shortdescriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 37);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(409, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "DEBIT AND CREDIT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // isdebitentrylbl
            // 
            this.isdebitentrylbl.AutoSize = true;
            this.isdebitentrylbl.Location = new System.Drawing.Point(17, 45);
            this.isdebitentrylbl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isdebitentrylbl.Name = "isdebitentrylbl";
            this.isdebitentrylbl.Size = new System.Drawing.Size(57, 17);
            this.isdebitentrylbl.TabIndex = 1;
            this.isdebitentrylbl.TabStop = true;
            this.isdebitentrylbl.Text = "DEBIT";
            this.isdebitentrylbl.UseVisualStyleBackColor = true;
            // 
            // iscreditentrylbl
            // 
            this.iscreditentrylbl.AutoSize = true;
            this.iscreditentrylbl.Location = new System.Drawing.Point(17, 66);
            this.iscreditentrylbl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iscreditentrylbl.Name = "iscreditentrylbl";
            this.iscreditentrylbl.Size = new System.Drawing.Size(65, 17);
            this.iscreditentrylbl.TabIndex = 2;
            this.iscreditentrylbl.TabStop = true;
            this.iscreditentrylbl.Text = "CREDIT";
            this.iscreditentrylbl.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(299, 204);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(99, 32);
            this.savebtn.TabIndex = 5;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // shortdescriptiontxtbox
            // 
            this.shortdescriptiontxtbox.Location = new System.Drawing.Point(17, 98);
            this.shortdescriptiontxtbox.Name = "shortdescriptiontxtbox";
            this.shortdescriptiontxtbox.Size = new System.Drawing.Size(381, 96);
            this.shortdescriptiontxtbox.TabIndex = 6;
            this.shortdescriptiontxtbox.Text = "";
            // 
            // DebitAndCreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 247);
            this.Controls.Add(this.shortdescriptiontxtbox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.iscreditentrylbl);
            this.Controls.Add(this.isdebitentrylbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DebitAndCreditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEBIT AND CREDIT";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DebitAndCreditForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.RadioButton isdebitentrylbl;
        private System.Windows.Forms.RadioButton iscreditentrylbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.RichTextBox shortdescriptiontxtbox;
    }
}