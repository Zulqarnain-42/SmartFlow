namespace SmartFlow.Masters
{
    partial class Currency
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
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.currencystringlbl = new System.Windows.Forms.Label();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencysymboltxtbox = new System.Windows.Forms.TextBox();
            this.currencystrintxtbox = new System.Windows.Forms.TextBox();
            this.currencynametxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(765, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(765, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "CURRENCIES";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencysymbollbl.Location = new System.Drawing.Point(33, 70);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(141, 23);
            this.currencysymbollbl.TabIndex = 1;
            this.currencysymbollbl.Text = "Currency Symbol";
            // 
            // currencystringlbl
            // 
            this.currencystringlbl.AutoSize = true;
            this.currencystringlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencystringlbl.Location = new System.Drawing.Point(33, 108);
            this.currencystringlbl.Name = "currencystringlbl";
            this.currencystringlbl.Size = new System.Drawing.Size(129, 23);
            this.currencystringlbl.TabIndex = 2;
            this.currencystringlbl.Text = "Currency String";
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencynamelbl.Location = new System.Drawing.Point(33, 146);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(129, 23);
            this.currencynamelbl.TabIndex = 4;
            this.currencynamelbl.Text = "Currency Name";
            // 
            // currencysymboltxtbox
            // 
            this.currencysymboltxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencysymboltxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencysymboltxtbox.Location = new System.Drawing.Point(208, 65);
            this.currencysymboltxtbox.Name = "currencysymboltxtbox";
            this.currencysymboltxtbox.Size = new System.Drawing.Size(373, 32);
            this.currencysymboltxtbox.TabIndex = 0;
            this.currencysymboltxtbox.TextChanged += new System.EventHandler(this.currencysymboltxtbox_TextChanged);
            // 
            // currencystrintxtbox
            // 
            this.currencystrintxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencystrintxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencystrintxtbox.Location = new System.Drawing.Point(207, 103);
            this.currencystrintxtbox.Name = "currencystrintxtbox";
            this.currencystrintxtbox.Size = new System.Drawing.Size(373, 32);
            this.currencystrintxtbox.TabIndex = 1;
            // 
            // currencynametxtbox
            // 
            this.currencynametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencynametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencynametxtbox.Location = new System.Drawing.Point(207, 141);
            this.currencynametxtbox.Name = "currencynametxtbox";
            this.currencynametxtbox.Size = new System.Drawing.Size(373, 32);
            this.currencynametxtbox.TabIndex = 2;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(208, 218);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(373, 36);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(588, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "( Rs. , $ etc. )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(591, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "( Rupees, Dollar etc. )";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(594, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "( USD Dollar etc. )";
            // 
            // Currency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(765, 291);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.currencynametxtbox);
            this.Controls.Add(this.currencystrintxtbox);
            this.Controls.Add(this.currencysymboltxtbox);
            this.Controls.Add(this.currencynamelbl);
            this.Controls.Add(this.currencystringlbl);
            this.Controls.Add(this.currencysymbollbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Currency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Currency";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Currency_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label currencysymbollbl;
        private System.Windows.Forms.Label currencystringlbl;
        private System.Windows.Forms.Label currencynamelbl;
        private System.Windows.Forms.TextBox currencysymboltxtbox;
        private System.Windows.Forms.TextBox currencystrintxtbox;
        private System.Windows.Forms.TextBox currencynametxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}