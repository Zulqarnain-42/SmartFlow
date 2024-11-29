namespace SmartFlow
{
    partial class Login
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
            this.passwordlbl = new System.Windows.Forms.Label();
            this.usernamelbl = new System.Windows.Forms.Label();
            this.usernametxtbox = new System.Windows.Forms.TextBox();
            this.passwordtxtbox = new System.Windows.Forms.TextBox();
            this.loginbtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.linkLabelrestorepassword = new System.Windows.Forms.LinkLabel();
            this.linkLabelforgotpassword = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlbl.Location = new System.Drawing.Point(303, 153);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(90, 23);
            this.passwordlbl.TabIndex = 1;
            this.passwordlbl.Text = "Password ";
            // 
            // usernamelbl
            // 
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamelbl.Location = new System.Drawing.Point(303, 125);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(93, 23);
            this.usernamelbl.TabIndex = 2;
            this.usernamelbl.Text = "Username ";
            // 
            // usernametxtbox
            // 
            this.usernametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernametxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametxtbox.Location = new System.Drawing.Point(445, 121);
            this.usernametxtbox.Name = "usernametxtbox";
            this.usernametxtbox.Size = new System.Drawing.Size(301, 30);
            this.usernametxtbox.TabIndex = 4;
            // 
            // passwordtxtbox
            // 
            this.passwordtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordtxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtxtbox.Location = new System.Drawing.Point(445, 149);
            this.passwordtxtbox.Name = "passwordtxtbox";
            this.passwordtxtbox.Size = new System.Drawing.Size(301, 30);
            this.passwordtxtbox.TabIndex = 5;
            // 
            // loginbtn
            // 
            this.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.Location = new System.Drawing.Point(445, 203);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(298, 30);
            this.loginbtn.TabIndex = 6;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(445, 239);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(298, 30);
            this.exitbtn.TabIndex = 7;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // linkLabelrestorepassword
            // 
            this.linkLabelrestorepassword.AutoSize = true;
            this.linkLabelrestorepassword.Location = new System.Drawing.Point(13, 321);
            this.linkLabelrestorepassword.Name = "linkLabelrestorepassword";
            this.linkLabelrestorepassword.Size = new System.Drawing.Size(125, 16);
            this.linkLabelrestorepassword.TabIndex = 8;
            this.linkLabelrestorepassword.TabStop = true;
            this.linkLabelrestorepassword.Text = "Restore Database?";
            // 
            // linkLabelforgotpassword
            // 
            this.linkLabelforgotpassword.AutoSize = true;
            this.linkLabelforgotpassword.Location = new System.Drawing.Point(13, 296);
            this.linkLabelforgotpassword.Name = "linkLabelforgotpassword";
            this.linkLabelforgotpassword.Size = new System.Drawing.Size(147, 16);
            this.linkLabelforgotpassword.TabIndex = 9;
            this.linkLabelforgotpassword.TabStop = true;
            this.linkLabelforgotpassword.Text = "Forgot Your Password?";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(785, 349);
            this.Controls.Add(this.linkLabelforgotpassword);
            this.Controls.Add(this.linkLabelrestorepassword);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.passwordtxtbox);
            this.Controls.Add(this.usernametxtbox);
            this.Controls.Add(this.usernamelbl);
            this.Controls.Add(this.passwordlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Label usernamelbl;
        private System.Windows.Forms.TextBox usernametxtbox;
        private System.Windows.Forms.TextBox passwordtxtbox;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.LinkLabel linkLabelrestorepassword;
        private System.Windows.Forms.LinkLabel linkLabelforgotpassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}