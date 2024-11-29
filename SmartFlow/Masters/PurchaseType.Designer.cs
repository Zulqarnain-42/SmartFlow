namespace SmartFlow.Masters
{
    partial class PurchaseType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseType));
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.purchasetypetxtbox = new System.Windows.Forms.TextBox();
            this.purchasetypelbl = new System.Windows.Forms.Label();
            this.checkBoxactive = new System.Windows.Forms.CheckBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxTax = new System.Windows.Forms.CheckBox();
            this.exitbtn = new System.Windows.Forms.Button();
            this.purchasetypeidlbl = new System.Windows.Forms.Label();
            this.purchasetypecodelbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.headinglbl, "headinglbl");
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Name = "headinglbl";
            // 
            // purchasetypetxtbox
            // 
            this.purchasetypetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.purchasetypetxtbox, "purchasetypetxtbox");
            this.purchasetypetxtbox.Name = "purchasetypetxtbox";
            // 
            // purchasetypelbl
            // 
            resources.ApplyResources(this.purchasetypelbl, "purchasetypelbl");
            this.purchasetypelbl.Name = "purchasetypelbl";
            // 
            // checkBoxactive
            // 
            resources.ApplyResources(this.checkBoxactive, "checkBoxactive");
            this.checkBoxactive.Checked = true;
            this.checkBoxactive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxactive.Name = "checkBoxactive";
            this.checkBoxactive.UseVisualStyleBackColor = true;
            // 
            // savebtn
            // 
            resources.ApplyResources(this.savebtn, "savebtn");
            this.savebtn.Name = "savebtn";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // checkBoxTax
            // 
            resources.ApplyResources(this.checkBoxTax, "checkBoxTax");
            this.checkBoxTax.Name = "checkBoxTax";
            this.checkBoxTax.UseVisualStyleBackColor = true;
            // 
            // exitbtn
            // 
            resources.ApplyResources(this.exitbtn, "exitbtn");
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // purchasetypeidlbl
            // 
            resources.ApplyResources(this.purchasetypeidlbl, "purchasetypeidlbl");
            this.purchasetypeidlbl.Name = "purchasetypeidlbl";
            // 
            // purchasetypecodelbl
            // 
            resources.ApplyResources(this.purchasetypecodelbl, "purchasetypecodelbl");
            this.purchasetypecodelbl.Name = "purchasetypecodelbl";
            // 
            // PurchaseType
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.purchasetypecodelbl);
            this.Controls.Add(this.purchasetypeidlbl);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.checkBoxTax);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.checkBoxactive);
            this.Controls.Add(this.purchasetypetxtbox);
            this.Controls.Add(this.purchasetypelbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "PurchaseType";
            this.Load += new System.EventHandler(this.PurchaseType_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseType_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.TextBox purchasetypetxtbox;
        private System.Windows.Forms.Label purchasetypelbl;
        private System.Windows.Forms.CheckBox checkBoxactive;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox checkBoxTax;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Label purchasetypeidlbl;
        private System.Windows.Forms.Label purchasetypecodelbl;
    }
}