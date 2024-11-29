namespace SmartFlow.Sales.CommonForm
{
    partial class AvailabilityForm
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
            this.availabilitytimelbl = new System.Windows.Forms.Label();
            this.availtxtbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 45);
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
            this.label1.Size = new System.Drawing.Size(605, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "PRODUCT AVAILABILITY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // availabilitytimelbl
            // 
            this.availabilitytimelbl.AutoSize = true;
            this.availabilitytimelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availabilitytimelbl.Location = new System.Drawing.Point(54, 109);
            this.availabilitytimelbl.Name = "availabilitytimelbl";
            this.availabilitytimelbl.Size = new System.Drawing.Size(101, 23);
            this.availabilitytimelbl.TabIndex = 1;
            this.availabilitytimelbl.Text = "Available in ";
            // 
            // availtxtbox
            // 
            this.availtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.availtxtbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availtxtbox.Location = new System.Drawing.Point(176, 105);
            this.availtxtbox.Name = "availtxtbox";
            this.availtxtbox.Size = new System.Drawing.Size(353, 30);
            this.availtxtbox.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 63);
            this.panel2.TabIndex = 3;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(475, 16);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(118, 35);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AvailabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 284);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.availtxtbox);
            this.Controls.Add(this.availabilitytimelbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AvailabilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUCT AVAILABILITY FORM";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AvailabilityForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label availabilitytimelbl;
        private System.Windows.Forms.TextBox availtxtbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}