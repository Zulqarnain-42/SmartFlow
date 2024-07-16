namespace SmartFlow
{
    partial class Warehouse
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
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.warehouseid = new System.Windows.Forms.Label();
            this.citytxtbox = new System.Windows.Forms.TextBox();
            this.citylbl = new System.Windows.Forms.Label();
            this.addresstxtbox = new System.Windows.Forms.TextBox();
            this.addresslbl = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.createwarehousesavebtn = new System.Windows.Forms.Button();
            this.warehousenametxtbox = new System.Windows.Forms.TextBox();
            this.warehousenamelbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridViewMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewMenuStrip
            // 
            this.gridViewMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gridViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.gridViewMenuStrip.Name = "gridViewMenuStrip";
            this.gridViewMenuStrip.Size = new System.Drawing.Size(105, 28);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 45);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "WAREHOUSE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.warehouseid);
            this.panel3.Controls.Add(this.citytxtbox);
            this.panel3.Controls.Add(this.citylbl);
            this.panel3.Controls.Add(this.addresstxtbox);
            this.panel3.Controls.Add(this.addresslbl);
            this.panel3.Controls.Add(this.exitbtn);
            this.panel3.Controls.Add(this.createwarehousesavebtn);
            this.panel3.Controls.Add(this.warehousenametxtbox);
            this.panel3.Controls.Add(this.warehousenamelbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 445);
            this.panel3.TabIndex = 21;
            // 
            // warehouseid
            // 
            this.warehouseid.AutoSize = true;
            this.warehouseid.Location = new System.Drawing.Point(1498, 8);
            this.warehouseid.Name = "warehouseid";
            this.warehouseid.Size = new System.Drawing.Size(84, 16);
            this.warehouseid.TabIndex = 31;
            this.warehouseid.Text = "warehouseid";
            this.warehouseid.Visible = false;
            // 
            // citytxtbox
            // 
            this.citytxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.citytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.citytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.citytxtbox.Location = new System.Drawing.Point(16, 266);
            this.citytxtbox.Name = "citytxtbox";
            this.citytxtbox.Size = new System.Drawing.Size(369, 32);
            this.citytxtbox.TabIndex = 30;
            // 
            // citylbl
            // 
            this.citylbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.citylbl.AutoSize = true;
            this.citylbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.citylbl.Location = new System.Drawing.Point(12, 240);
            this.citylbl.Name = "citylbl";
            this.citylbl.Size = new System.Drawing.Size(43, 23);
            this.citylbl.TabIndex = 29;
            this.citylbl.Text = "City ";
            // 
            // addresstxtbox
            // 
            this.addresstxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addresstxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addresstxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addresstxtbox.Location = new System.Drawing.Point(16, 94);
            this.addresstxtbox.Multiline = true;
            this.addresstxtbox.Name = "addresstxtbox";
            this.addresstxtbox.Size = new System.Drawing.Size(369, 143);
            this.addresstxtbox.TabIndex = 28;
            // 
            // addresslbl
            // 
            this.addresslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addresslbl.AutoSize = true;
            this.addresslbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.addresslbl.Location = new System.Drawing.Point(12, 67);
            this.addresslbl.Name = "addresslbl";
            this.addresslbl.Size = new System.Drawing.Size(77, 23);
            this.addresslbl.TabIndex = 27;
            this.addresslbl.Text = "Address ";
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.exitbtn.Location = new System.Drawing.Point(16, 393);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(369, 40);
            this.exitbtn.TabIndex = 26;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // createwarehousesavebtn
            // 
            this.createwarehousesavebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createwarehousesavebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createwarehousesavebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.createwarehousesavebtn.Location = new System.Drawing.Point(16, 347);
            this.createwarehousesavebtn.Name = "createwarehousesavebtn";
            this.createwarehousesavebtn.Size = new System.Drawing.Size(369, 40);
            this.createwarehousesavebtn.TabIndex = 25;
            this.createwarehousesavebtn.Text = "Save";
            this.createwarehousesavebtn.UseVisualStyleBackColor = true;
            this.createwarehousesavebtn.Click += new System.EventHandler(this.createwarehousesavebtn_Click);
            // 
            // warehousenametxtbox
            // 
            this.warehousenametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warehousenametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warehousenametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehousenametxtbox.Location = new System.Drawing.Point(16, 31);
            this.warehousenametxtbox.Name = "warehousenametxtbox";
            this.warehousenametxtbox.Size = new System.Drawing.Size(369, 32);
            this.warehousenametxtbox.TabIndex = 24;
            // 
            // warehousenamelbl
            // 
            this.warehousenamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warehousenamelbl.AutoSize = true;
            this.warehousenamelbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.warehousenamelbl.Location = new System.Drawing.Point(12, 3);
            this.warehousenamelbl.Name = "warehousenamelbl";
            this.warehousenamelbl.Size = new System.Drawing.Size(151, 23);
            this.warehousenamelbl.TabIndex = 23;
            this.warehousenamelbl.Text = "Warehouse Name ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(397, 490);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Warehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse - Future Art Broadcast Trading LLC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Warehouse_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Warehouse_KeyDown);
            this.gridViewMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip gridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox citytxtbox;
        private System.Windows.Forms.Label citylbl;
        private System.Windows.Forms.TextBox addresstxtbox;
        private System.Windows.Forms.Label addresslbl;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button createwarehousesavebtn;
        private System.Windows.Forms.TextBox warehousenametxtbox;
        private System.Windows.Forms.Label warehousenamelbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label warehouseid;
    }
}