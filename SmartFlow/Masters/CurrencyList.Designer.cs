namespace SmartFlow.Masters
{
    partial class CurrencyList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListcurrency = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.isdefaultchkbox = new System.Windows.Forms.CheckBox();
            this.closebtn = new System.Windows.Forms.Button();
            this.currencycodelbl = new System.Windows.Forms.Label();
            this.currencyidlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.currencynametxtbox = new System.Windows.Forms.TextBox();
            this.currencystrintxtbox = new System.Windows.Forms.TextBox();
            this.currencysymboltxtbox = new System.Windows.Forms.TextBox();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencystringlbl = new System.Windows.Forms.Label();
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListcurrency)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(1180, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "LIST CURRENCIES";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 61);
            this.panel2.TabIndex = 1;
            // 
            // dgvListcurrency
            // 
            this.dgvListcurrency.AllowUserToAddRows = false;
            this.dgvListcurrency.AllowUserToDeleteRows = false;
            this.dgvListcurrency.AllowUserToResizeColumns = false;
            this.dgvListcurrency.AllowUserToResizeRows = false;
            this.dgvListcurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListcurrency.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListcurrency.CausesValidation = false;
            this.dgvListcurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListcurrency.ColumnHeadersVisible = false;
            this.dgvListcurrency.ContextMenuStrip = this.contextMenuStrip;
            this.dgvListcurrency.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListcurrency.Location = new System.Drawing.Point(0, 3);
            this.dgvListcurrency.Name = "dgvListcurrency";
            this.dgvListcurrency.RowHeadersWidth = 51;
            this.dgvListcurrency.RowTemplate.Height = 24;
            this.dgvListcurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListcurrency.Size = new System.Drawing.Size(831, 406);
            this.dgvListcurrency.TabIndex = 2;
            this.dgvListcurrency.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListcurrency_CellDoubleClick);
            this.dgvListcurrency.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvListcurrency_Scroll);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(110, 28);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.isdefaultchkbox);
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.currencycodelbl);
            this.panel3.Controls.Add(this.currencyidlbl);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.currencynametxtbox);
            this.panel3.Controls.Add(this.currencystrintxtbox);
            this.panel3.Controls.Add(this.currencysymboltxtbox);
            this.panel3.Controls.Add(this.currencynamelbl);
            this.panel3.Controls.Add(this.currencystringlbl);
            this.panel3.Controls.Add(this.currencysymbollbl);
            this.panel3.Controls.Add(this.dgvListcurrency);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1180, 412);
            this.panel3.TabIndex = 3;
            // 
            // isdefaultchkbox
            // 
            this.isdefaultchkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isdefaultchkbox.AutoSize = true;
            this.isdefaultchkbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isdefaultchkbox.Location = new System.Drawing.Point(841, 189);
            this.isdefaultchkbox.Name = "isdefaultchkbox";
            this.isdefaultchkbox.Size = new System.Drawing.Size(119, 27);
            this.isdefaultchkbox.TabIndex = 68;
            this.isdefaultchkbox.Text = "IS DEFAULT";
            this.isdefaultchkbox.UseVisualStyleBackColor = true;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(837, 364);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(331, 36);
            this.closebtn.TabIndex = 67;
            this.closebtn.Text = "EXIT";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // currencycodelbl
            // 
            this.currencycodelbl.AutoSize = true;
            this.currencycodelbl.Location = new System.Drawing.Point(888, 281);
            this.currencycodelbl.Name = "currencycodelbl";
            this.currencycodelbl.Size = new System.Drawing.Size(103, 16);
            this.currencycodelbl.TabIndex = 66;
            this.currencycodelbl.Text = "currencycodelbl";
            this.currencycodelbl.Visible = false;
            // 
            // currencyidlbl
            // 
            this.currencyidlbl.AutoSize = true;
            this.currencyidlbl.Location = new System.Drawing.Point(888, 261);
            this.currencyidlbl.Name = "currencyidlbl";
            this.currencyidlbl.Size = new System.Drawing.Size(83, 16);
            this.currencyidlbl.TabIndex = 65;
            this.currencyidlbl.Text = "currencyidlbl";
            this.currencyidlbl.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1055, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "( USD Dollar etc. )";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1033, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "( Rupees, Dollar etc. )";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1087, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "( Rs. , $ etc. )";
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(837, 222);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(331, 36);
            this.savebtn.TabIndex = 60;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // currencynametxtbox
            // 
            this.currencynametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencynametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencynametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencynametxtbox.Location = new System.Drawing.Point(837, 151);
            this.currencynametxtbox.Name = "currencynametxtbox";
            this.currencynametxtbox.Size = new System.Drawing.Size(331, 32);
            this.currencynametxtbox.TabIndex = 58;
            // 
            // currencystrintxtbox
            // 
            this.currencystrintxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencystrintxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencystrintxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencystrintxtbox.Location = new System.Drawing.Point(837, 90);
            this.currencystrintxtbox.Name = "currencystrintxtbox";
            this.currencystrintxtbox.Size = new System.Drawing.Size(331, 32);
            this.currencystrintxtbox.TabIndex = 56;
            // 
            // currencysymboltxtbox
            // 
            this.currencysymboltxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencysymboltxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currencysymboltxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencysymboltxtbox.Location = new System.Drawing.Point(837, 29);
            this.currencysymboltxtbox.Name = "currencysymboltxtbox";
            this.currencysymboltxtbox.Size = new System.Drawing.Size(331, 32);
            this.currencysymboltxtbox.TabIndex = 55;
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencynamelbl.Location = new System.Drawing.Point(837, 125);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(129, 23);
            this.currencynamelbl.TabIndex = 61;
            this.currencynamelbl.Text = "Currency Name";
            // 
            // currencystringlbl
            // 
            this.currencystringlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencystringlbl.AutoSize = true;
            this.currencystringlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencystringlbl.Location = new System.Drawing.Point(837, 64);
            this.currencystringlbl.Name = "currencystringlbl";
            this.currencystringlbl.Size = new System.Drawing.Size(129, 23);
            this.currencystringlbl.TabIndex = 59;
            this.currencystringlbl.Text = "Currency String";
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencysymbollbl.Location = new System.Drawing.Point(837, 3);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(141, 23);
            this.currencysymbollbl.TabIndex = 57;
            this.currencysymbollbl.Text = "Currency Symbol";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // CurrencyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 518);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "CurrencyList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIST CURRENCY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CurrencyList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrencyList_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListcurrency)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListcurrency;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label currencycodelbl;
        private System.Windows.Forms.Label currencyidlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox currencynametxtbox;
        private System.Windows.Forms.TextBox currencystrintxtbox;
        private System.Windows.Forms.TextBox currencysymboltxtbox;
        private System.Windows.Forms.Label currencynamelbl;
        private System.Windows.Forms.Label currencystringlbl;
        private System.Windows.Forms.Label currencysymbollbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox isdefaultchkbox;
    }
}