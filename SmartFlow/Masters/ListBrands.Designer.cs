namespace SmartFlow.Masters
{
    partial class ListBrands
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.closebtn = new System.Windows.Forms.Button();
            this.brandcodelbl = new System.Windows.Forms.Label();
            this.brandidlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.brandnametxtbox = new System.Windows.Forms.TextBox();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.unitnamelbl = new System.Windows.Forms.Label();
            this.dgvListbrand = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.headinglbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListbrand)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.descriptiontxtbox);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.brandcodelbl);
            this.panel3.Controls.Add(this.brandidlbl);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.brandnametxtbox);
            this.panel3.Controls.Add(this.descriptionlbl);
            this.panel3.Controls.Add(this.unitnamelbl);
            this.panel3.Controls.Add(this.dgvListbrand);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(885, 384);
            this.panel3.TabIndex = 8;
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(628, 73);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(249, 188);
            this.descriptiontxtbox.TabIndex = 68;
            this.descriptiontxtbox.Text = "";
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(628, 345);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(248, 29);
            this.closebtn.TabIndex = 67;
            this.closebtn.Text = "EXIT";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // brandcodelbl
            // 
            this.brandcodelbl.AutoSize = true;
            this.brandcodelbl.Location = new System.Drawing.Point(628, 330);
            this.brandcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.brandcodelbl.Name = "brandcodelbl";
            this.brandcodelbl.Size = new System.Drawing.Size(68, 13);
            this.brandcodelbl.TabIndex = 66;
            this.brandcodelbl.Text = "brandcodelbl";
            this.brandcodelbl.Visible = false;
            // 
            // brandidlbl
            // 
            this.brandidlbl.AutoSize = true;
            this.brandidlbl.Location = new System.Drawing.Point(700, 330);
            this.brandidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.brandidlbl.Name = "brandidlbl";
            this.brandidlbl.Size = new System.Drawing.Size(52, 13);
            this.brandidlbl.TabIndex = 65;
            this.brandidlbl.Text = "brandidlbl";
            this.brandidlbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(628, 299);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(248, 29);
            this.savebtn.TabIndex = 60;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // brandnametxtbox
            // 
            this.brandnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brandnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brandnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandnametxtbox.Location = new System.Drawing.Point(628, 24);
            this.brandnametxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.brandnametxtbox.Name = "brandnametxtbox";
            this.brandnametxtbox.Size = new System.Drawing.Size(249, 27);
            this.brandnametxtbox.TabIndex = 55;
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.Location = new System.Drawing.Point(628, 52);
            this.descriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(90, 18);
            this.descriptionlbl.TabIndex = 59;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // unitnamelbl
            // 
            this.unitnamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitnamelbl.AutoSize = true;
            this.unitnamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitnamelbl.Location = new System.Drawing.Point(628, 2);
            this.unitnamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitnamelbl.Name = "unitnamelbl";
            this.unitnamelbl.Size = new System.Drawing.Size(93, 18);
            this.unitnamelbl.TabIndex = 57;
            this.unitnamelbl.Text = "BRAND NAME";
            // 
            // dgvListbrand
            // 
            this.dgvListbrand.AllowUserToAddRows = false;
            this.dgvListbrand.AllowUserToDeleteRows = false;
            this.dgvListbrand.AllowUserToResizeColumns = false;
            this.dgvListbrand.AllowUserToResizeRows = false;
            this.dgvListbrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListbrand.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListbrand.CausesValidation = false;
            this.dgvListbrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListbrand.ColumnHeadersVisible = false;
            this.dgvListbrand.ContextMenuStrip = this.contextMenuStrip;
            this.dgvListbrand.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListbrand.Location = new System.Drawing.Point(0, 2);
            this.dgvListbrand.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListbrand.Name = "dgvListbrand";
            this.dgvListbrand.RowHeadersWidth = 51;
            this.dgvListbrand.RowTemplate.Height = 24;
            this.dgvListbrand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListbrand.Size = new System.Drawing.Size(623, 379);
            this.dgvListbrand.TabIndex = 2;
            this.dgvListbrand.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListbrand_CellDoubleClick);
            this.dgvListbrand.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvListbrand_Scroll);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(885, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "LIST BRANDS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 37);
            this.panel1.TabIndex = 7;
            // 
            // ListBrands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 421);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ListBrands";
            this.Text = "LIST OF BRANDS";
            this.Load += new System.EventHandler(this.ListBrands_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBrands_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListbrand)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label brandcodelbl;
        private System.Windows.Forms.Label brandidlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox brandnametxtbox;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.Label unitnamelbl;
        private System.Windows.Forms.DataGridView dgvListbrand;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
    }
}