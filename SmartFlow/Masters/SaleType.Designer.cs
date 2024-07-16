namespace SmartFlow.Masters
{
    partial class SaleType
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
            this.label1 = new System.Windows.Forms.Label();
            this.salestypelbl = new System.Windows.Forms.Label();
            this.saletypetxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.checkBoxactive = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxTax = new System.Windows.Forms.CheckBox();
            this.exitbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "SALES TYPE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salestypelbl
            // 
            this.salestypelbl.AutoSize = true;
            this.salestypelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salestypelbl.Location = new System.Drawing.Point(31, 64);
            this.salestypelbl.Name = "salestypelbl";
            this.salestypelbl.Size = new System.Drawing.Size(88, 23);
            this.salestypelbl.TabIndex = 1;
            this.salestypelbl.Text = "SALE TYPE";
            // 
            // saletypetxtbox
            // 
            this.saletypetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saletypetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saletypetxtbox.Location = new System.Drawing.Point(125, 60);
            this.saletypetxtbox.Name = "saletypetxtbox";
            this.saletypetxtbox.Size = new System.Drawing.Size(373, 32);
            this.saletypetxtbox.TabIndex = 0;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(125, 125);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(373, 34);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // checkBoxactive
            // 
            this.checkBoxactive.AutoSize = true;
            this.checkBoxactive.Checked = true;
            this.checkBoxactive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxactive.Location = new System.Drawing.Point(125, 98);
            this.checkBoxactive.Name = "checkBoxactive";
            this.checkBoxactive.Size = new System.Drawing.Size(77, 20);
            this.checkBoxactive.TabIndex = 1;
            this.checkBoxactive.Text = "ACTIVE";
            this.checkBoxactive.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // checkBoxTax
            // 
            this.checkBoxTax.AutoSize = true;
            this.checkBoxTax.Location = new System.Drawing.Point(387, 98);
            this.checkBoxTax.Name = "checkBoxTax";
            this.checkBoxTax.Size = new System.Drawing.Size(111, 20);
            this.checkBoxTax.TabIndex = 2;
            this.checkBoxTax.Text = "TAX INVOICE";
            this.checkBoxTax.UseVisualStyleBackColor = true;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(125, 165);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(373, 34);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // SaleType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(564, 206);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.checkBoxTax);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.checkBoxactive);
            this.Controls.Add(this.saletypetxtbox);
            this.Controls.Add(this.salestypelbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SaleType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Type - Future Art Broadcast Trading LLC";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label salestypelbl;
        private System.Windows.Forms.TextBox saletypetxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.CheckBox checkBoxactive;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox checkBoxTax;
        private System.Windows.Forms.Button exitbtn;
    }
}