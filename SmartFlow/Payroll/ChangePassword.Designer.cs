namespace SmartFlow.Payroll
{
    partial class ChangePassword
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
            this.oldpasswordlbl = new System.Windows.Forms.Label();
            this.newpasswordlbl = new System.Windows.Forms.Label();
            this.confirmpasswordlbl = new System.Windows.Forms.Label();
            this.oldpasswordtxtbox = new System.Windows.Forms.TextBox();
            this.newpasswordtxtbox = new System.Windows.Forms.TextBox();
            this.confirmpasswordtxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(582, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(582, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "CHANGE PASSWORD";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oldpasswordlbl
            // 
            this.oldpasswordlbl.AutoSize = true;
            this.oldpasswordlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldpasswordlbl.Location = new System.Drawing.Point(12, 77);
            this.oldpasswordlbl.Name = "oldpasswordlbl";
            this.oldpasswordlbl.Size = new System.Drawing.Size(137, 23);
            this.oldpasswordlbl.TabIndex = 1;
            this.oldpasswordlbl.Text = "OLD PASSWORD";
            // 
            // newpasswordlbl
            // 
            this.newpasswordlbl.AutoSize = true;
            this.newpasswordlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpasswordlbl.Location = new System.Drawing.Point(12, 116);
            this.newpasswordlbl.Name = "newpasswordlbl";
            this.newpasswordlbl.Size = new System.Drawing.Size(142, 23);
            this.newpasswordlbl.TabIndex = 2;
            this.newpasswordlbl.Text = "NEW PASSWORD";
            // 
            // confirmpasswordlbl
            // 
            this.confirmpasswordlbl.AutoSize = true;
            this.confirmpasswordlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpasswordlbl.Location = new System.Drawing.Point(12, 154);
            this.confirmpasswordlbl.Name = "confirmpasswordlbl";
            this.confirmpasswordlbl.Size = new System.Drawing.Size(180, 23);
            this.confirmpasswordlbl.TabIndex = 3;
            this.confirmpasswordlbl.Text = "CONFIRM PASSWORD";
            // 
            // oldpasswordtxtbox
            // 
            this.oldpasswordtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldpasswordtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldpasswordtxtbox.Location = new System.Drawing.Point(200, 73);
            this.oldpasswordtxtbox.Name = "oldpasswordtxtbox";
            this.oldpasswordtxtbox.PasswordChar = '*';
            this.oldpasswordtxtbox.Size = new System.Drawing.Size(347, 32);
            this.oldpasswordtxtbox.TabIndex = 4;
            this.oldpasswordtxtbox.Leave += new System.EventHandler(this.oldpasswordtxtbox_Leave);
            // 
            // newpasswordtxtbox
            // 
            this.newpasswordtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newpasswordtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpasswordtxtbox.Location = new System.Drawing.Point(200, 112);
            this.newpasswordtxtbox.Name = "newpasswordtxtbox";
            this.newpasswordtxtbox.PasswordChar = '*';
            this.newpasswordtxtbox.Size = new System.Drawing.Size(347, 32);
            this.newpasswordtxtbox.TabIndex = 5;
            // 
            // confirmpasswordtxtbox
            // 
            this.confirmpasswordtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmpasswordtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpasswordtxtbox.Location = new System.Drawing.Point(200, 150);
            this.confirmpasswordtxtbox.Name = "confirmpasswordtxtbox";
            this.confirmpasswordtxtbox.PasswordChar = '*';
            this.confirmpasswordtxtbox.Size = new System.Drawing.Size(347, 32);
            this.confirmpasswordtxtbox.TabIndex = 6;
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(200, 188);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(347, 45);
            this.savebtn.TabIndex = 7;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(582, 283);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.confirmpasswordtxtbox);
            this.Controls.Add(this.newpasswordtxtbox);
            this.Controls.Add(this.oldpasswordtxtbox);
            this.Controls.Add(this.confirmpasswordlbl);
            this.Controls.Add(this.newpasswordlbl);
            this.Controls.Add(this.oldpasswordlbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHANGE PASSWORD";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePassword_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label oldpasswordlbl;
        private System.Windows.Forms.Label newpasswordlbl;
        private System.Windows.Forms.Label confirmpasswordlbl;
        private System.Windows.Forms.TextBox oldpasswordtxtbox;
        private System.Windows.Forms.TextBox newpasswordtxtbox;
        private System.Windows.Forms.TextBox confirmpasswordtxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}