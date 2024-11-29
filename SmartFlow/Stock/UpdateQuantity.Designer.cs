namespace SmartFlow.Stock
{
    partial class UpdateQuantity
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
            this.productid = new System.Windows.Forms.Label();
            this.productname = new System.Windows.Forms.Label();
            this.productmfr = new System.Windows.Forms.Label();
            this.quantitylbl = new System.Windows.Forms.Label();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.openingstocklbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.selectwarehouselbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.warehouseidlbl = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(830, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(830, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "UPDATE PRODUCT QUANTITY";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productid
            // 
            this.productid.AutoSize = true;
            this.productid.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productid.ForeColor = System.Drawing.Color.Blue;
            this.productid.Location = new System.Drawing.Point(94, 60);
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(108, 23);
            this.productid.TabIndex = 1;
            this.productid.Text = "PRODUCT ID";
            this.productid.Visible = false;
            // 
            // productname
            // 
            this.productname.AutoSize = true;
            this.productname.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productname.ForeColor = System.Drawing.Color.Blue;
            this.productname.Location = new System.Drawing.Point(94, 85);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(50, 23);
            this.productname.TabIndex = 2;
            this.productname.Text = "TITLE";
            // 
            // productmfr
            // 
            this.productmfr.AutoSize = true;
            this.productmfr.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productmfr.ForeColor = System.Drawing.Color.Blue;
            this.productmfr.Location = new System.Drawing.Point(94, 110);
            this.productmfr.Name = "productmfr";
            this.productmfr.Size = new System.Drawing.Size(47, 23);
            this.productmfr.TabIndex = 3;
            this.productmfr.Text = "MFR";
            // 
            // quantitylbl
            // 
            this.quantitylbl.AutoSize = true;
            this.quantitylbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantitylbl.Location = new System.Drawing.Point(98, 212);
            this.quantitylbl.Name = "quantitylbl";
            this.quantitylbl.Size = new System.Drawing.Size(91, 23);
            this.quantitylbl.TabIndex = 4;
            this.quantitylbl.Text = "QUANTITY";
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtytxtbox.Location = new System.Drawing.Point(300, 210);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(415, 32);
            this.qtytxtbox.TabIndex = 5;
            // 
            // savebtn
            // 
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(300, 247);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(415, 34);
            this.savebtn.TabIndex = 6;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // openingstocklbl
            // 
            this.openingstocklbl.AutoSize = true;
            this.openingstocklbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openingstocklbl.ForeColor = System.Drawing.Color.Blue;
            this.openingstocklbl.Location = new System.Drawing.Point(94, 135);
            this.openingstocklbl.Name = "openingstocklbl";
            this.openingstocklbl.Size = new System.Drawing.Size(139, 23);
            this.openingstocklbl.TabIndex = 7;
            this.openingstocklbl.Text = "OPENING STOCK";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // selectwarehouselbl
            // 
            this.selectwarehouselbl.AutoSize = true;
            this.selectwarehouselbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehouselbl.Location = new System.Drawing.Point(98, 176);
            this.selectwarehouselbl.Name = "selectwarehouselbl";
            this.selectwarehouselbl.Size = new System.Drawing.Size(169, 23);
            this.selectwarehouselbl.TabIndex = 8;
            this.selectwarehouselbl.Text = "SELECT WAREHOUSE";
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(300, 172);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(415, 32);
            this.selectwarehousetxtbox.TabIndex = 9;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(0, 343);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(84, 16);
            this.warehouseidlbl.TabIndex = 10;
            this.warehouseidlbl.Text = "warehouseid";
            this.warehouseidlbl.Visible = false;
            // 
            // UpdateQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(830, 362);
            this.Controls.Add(this.warehouseidlbl);
            this.Controls.Add(this.selectwarehousetxtbox);
            this.Controls.Add(this.selectwarehouselbl);
            this.Controls.Add(this.openingstocklbl);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.qtytxtbox);
            this.Controls.Add(this.quantitylbl);
            this.Controls.Add(this.productmfr);
            this.Controls.Add(this.productname);
            this.Controls.Add(this.productid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE QUANTITY";
            this.Load += new System.EventHandler(this.UpdateQuantity_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateQuantity_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label productid;
        private System.Windows.Forms.Label productname;
        private System.Windows.Forms.Label productmfr;
        private System.Windows.Forms.Label quantitylbl;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label openingstocklbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label selectwarehouselbl;
        private System.Windows.Forms.Label warehouseidlbl;
    }
}