namespace SmartFlow.Sales.CommonForm
{
    partial class ItemWiseDescription
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
            this.itemwisedescriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(793, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ITEM WISE DESCRIPTION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemwisedescriptiontxtbox
            // 
            this.itemwisedescriptiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemwisedescriptiontxtbox.Location = new System.Drawing.Point(0, 45);
            this.itemwisedescriptiontxtbox.Name = "itemwisedescriptiontxtbox";
            this.itemwisedescriptiontxtbox.Size = new System.Drawing.Size(793, 323);
            this.itemwisedescriptiontxtbox.TabIndex = 1;
            this.itemwisedescriptiontxtbox.Text = "";
            this.itemwisedescriptiontxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemwisedescriptiontxtbox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 67);
            this.panel2.TabIndex = 2;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(641, 11);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(140, 44);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // ItemWiseDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.itemwisedescriptiontxtbox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ItemWiseDescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ITEM WISE DESCRIPTION";
            this.Load += new System.EventHandler(this.ItemWiseDescription_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemWiseDescription_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.RichTextBox itemwisedescriptiontxtbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button savebtn;
    }
}