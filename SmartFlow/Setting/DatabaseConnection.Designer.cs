namespace SmartFlow.Setting
{
    partial class DatabaseConnection
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
            this.servernamelbl = new System.Windows.Forms.Label();
            this.databasenamelbl = new System.Windows.Forms.Label();
            this.useridlbl = new System.Windows.Forms.Label();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.servernametxtbox = new System.Windows.Forms.TextBox();
            this.databasenametxtbox = new System.Windows.Forms.TextBox();
            this.usernametxtbox = new System.Windows.Forms.TextBox();
            this.passwordtxtbox = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(641, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(641, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "DATABASE CONNECTION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // servernamelbl
            // 
            this.servernamelbl.AutoSize = true;
            this.servernamelbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servernamelbl.Location = new System.Drawing.Point(35, 90);
            this.servernamelbl.Name = "servernamelbl";
            this.servernamelbl.Size = new System.Drawing.Size(129, 24);
            this.servernamelbl.TabIndex = 1;
            this.servernamelbl.Text = "SERVER NAME";
            // 
            // databasenamelbl
            // 
            this.databasenamelbl.AutoSize = true;
            this.databasenamelbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasenamelbl.Location = new System.Drawing.Point(35, 126);
            this.databasenamelbl.Name = "databasenamelbl";
            this.databasenamelbl.Size = new System.Drawing.Size(151, 24);
            this.databasenamelbl.TabIndex = 2;
            this.databasenamelbl.Text = "DATABASE NAME";
            // 
            // useridlbl
            // 
            this.useridlbl.AutoSize = true;
            this.useridlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useridlbl.Location = new System.Drawing.Point(35, 162);
            this.useridlbl.Name = "useridlbl";
            this.useridlbl.Size = new System.Drawing.Size(105, 24);
            this.useridlbl.TabIndex = 3;
            this.useridlbl.Text = "USERNAME";
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlbl.Location = new System.Drawing.Point(35, 198);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(103, 24);
            this.passwordlbl.TabIndex = 4;
            this.passwordlbl.Text = "PASSWORD";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(225, 231);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(356, 35);
            this.savebtn.TabIndex = 5;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // servernametxtbox
            // 
            this.servernametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.servernametxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servernametxtbox.Location = new System.Drawing.Point(225, 87);
            this.servernametxtbox.Name = "servernametxtbox";
            this.servernametxtbox.Size = new System.Drawing.Size(356, 30);
            this.servernametxtbox.TabIndex = 6;
            // 
            // databasenametxtbox
            // 
            this.databasenametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.databasenametxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasenametxtbox.Location = new System.Drawing.Point(225, 123);
            this.databasenametxtbox.Name = "databasenametxtbox";
            this.databasenametxtbox.Size = new System.Drawing.Size(356, 30);
            this.databasenametxtbox.TabIndex = 7;
            // 
            // usernametxtbox
            // 
            this.usernametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernametxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametxtbox.Location = new System.Drawing.Point(225, 159);
            this.usernametxtbox.Name = "usernametxtbox";
            this.usernametxtbox.Size = new System.Drawing.Size(356, 30);
            this.usernametxtbox.TabIndex = 8;
            // 
            // passwordtxtbox
            // 
            this.passwordtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordtxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtxtbox.Location = new System.Drawing.Point(225, 195);
            this.passwordtxtbox.Name = "passwordtxtbox";
            this.passwordtxtbox.PasswordChar = '*';
            this.passwordtxtbox.Size = new System.Drawing.Size(356, 30);
            this.passwordtxtbox.TabIndex = 9;
            this.passwordtxtbox.UseSystemPasswordChar = true;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(225, 272);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(356, 35);
            this.exitbtn.TabIndex = 10;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DatabaseConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(641, 348);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.passwordtxtbox);
            this.Controls.Add(this.usernametxtbox);
            this.Controls.Add(this.databasenametxtbox);
            this.Controls.Add(this.servernametxtbox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.useridlbl);
            this.Controls.Add(this.databasenamelbl);
            this.Controls.Add(this.servernamelbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "DatabaseConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATABASE CONNECTION";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabaseConnection_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label servernamelbl;
        private System.Windows.Forms.Label databasenamelbl;
        private System.Windows.Forms.Label useridlbl;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox servernametxtbox;
        private System.Windows.Forms.TextBox databasenametxtbox;
        private System.Windows.Forms.TextBox usernametxtbox;
        private System.Windows.Forms.TextBox passwordtxtbox;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}