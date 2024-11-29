namespace SmartFlow.Masters
{
    partial class CreateRole
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
            this.rolenamelbl = new System.Windows.Forms.Label();
            this.rolenametxtbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.roleidlbl = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(600, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(600, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "CREATE ROLE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rolenamelbl
            // 
            this.rolenamelbl.AutoSize = true;
            this.rolenamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolenamelbl.Location = new System.Drawing.Point(41, 69);
            this.rolenamelbl.Name = "rolenamelbl";
            this.rolenamelbl.Size = new System.Drawing.Size(102, 23);
            this.rolenamelbl.TabIndex = 1;
            this.rolenamelbl.Text = "ROLE NAME";
            // 
            // rolenametxtbox
            // 
            this.rolenametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rolenametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolenametxtbox.Location = new System.Drawing.Point(158, 65);
            this.rolenametxtbox.Name = "rolenametxtbox";
            this.rolenametxtbox.Size = new System.Drawing.Size(383, 32);
            this.rolenametxtbox.TabIndex = 2;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(158, 141);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(383, 32);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(158, 179);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(383, 32);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // roleidlbl
            // 
            this.roleidlbl.AutoSize = true;
            this.roleidlbl.Location = new System.Drawing.Point(45, 134);
            this.roleidlbl.Name = "roleidlbl";
            this.roleidlbl.Size = new System.Drawing.Size(55, 16);
            this.roleidlbl.TabIndex = 7;
            this.roleidlbl.Text = "roleidlbl";
            this.roleidlbl.Visible = false;
            // 
            // CreateRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 274);
            this.Controls.Add(this.roleidlbl);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.rolenametxtbox);
            this.Controls.Add(this.rolenamelbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "CreateRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE ROLE";
            this.Load += new System.EventHandler(this.CreateRole_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label rolenamelbl;
        private System.Windows.Forms.TextBox rolenametxtbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label roleidlbl;
    }
}