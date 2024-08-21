namespace SmartFlow.Masters
{
    partial class GroupingAccount
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.selectaccounttxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptiontxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupingnametxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvgroupingaccount = new System.Windows.Forms.DataGridView();
            this.accountidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountnamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addbtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgroupingaccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 45);
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
            this.label1.Size = new System.Drawing.Size(1013, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACCOUNT GROUPING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Controls.Add(this.accountidlbl);
            this.panel2.Controls.Add(this.selectaccounttxtbox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.descriptiontxtbox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupingnametxtbox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 234);
            this.panel2.TabIndex = 1;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(816, 168);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(185, 42);
            this.exitbtn.TabIndex = 25;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(816, 120);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(185, 42);
            this.savebtn.TabIndex = 24;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(813, 76);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(79, 16);
            this.accountidlbl.TabIndex = 23;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // selectaccounttxtbox
            // 
            this.selectaccounttxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectaccounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectaccounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectaccounttxtbox.Location = new System.Drawing.Point(167, 178);
            this.selectaccounttxtbox.Name = "selectaccounttxtbox";
            this.selectaccounttxtbox.Size = new System.Drawing.Size(446, 32);
            this.selectaccounttxtbox.TabIndex = 2;
            this.selectaccounttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectaccounttxtbox_MouseClick);
            this.selectaccounttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectaccounttxtbox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "SELECT ACCOUNT";
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(167, 48);
            this.descriptiontxtbox.Multiline = true;
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(446, 124);
            this.descriptiontxtbox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "DESCRIPTION";
            // 
            // groupingnametxtbox
            // 
            this.groupingnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupingnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupingnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupingnametxtbox.Location = new System.Drawing.Point(167, 10);
            this.groupingnametxtbox.Name = "groupingnametxtbox";
            this.groupingnametxtbox.Size = new System.Drawing.Size(446, 32);
            this.groupingnametxtbox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "GROUPING NAME";
            // 
            // dgvgroupingaccount
            // 
            this.dgvgroupingaccount.AllowUserToAddRows = false;
            this.dgvgroupingaccount.AllowUserToDeleteRows = false;
            this.dgvgroupingaccount.AllowUserToResizeColumns = false;
            this.dgvgroupingaccount.AllowUserToResizeRows = false;
            this.dgvgroupingaccount.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvgroupingaccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvgroupingaccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountidcolumn,
            this.accountnamecolumn});
            this.dgvgroupingaccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvgroupingaccount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvgroupingaccount.Location = new System.Drawing.Point(0, 279);
            this.dgvgroupingaccount.Name = "dgvgroupingaccount";
            this.dgvgroupingaccount.RowHeadersVisible = false;
            this.dgvgroupingaccount.RowHeadersWidth = 51;
            this.dgvgroupingaccount.RowTemplate.Height = 24;
            this.dgvgroupingaccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvgroupingaccount.Size = new System.Drawing.Size(1013, 312);
            this.dgvgroupingaccount.TabIndex = 2;
            this.dgvgroupingaccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvgroupingaccount_KeyDown);
            // 
            // accountidcolumn
            // 
            this.accountidcolumn.HeaderText = "ID";
            this.accountidcolumn.MinimumWidth = 6;
            this.accountidcolumn.Name = "accountidcolumn";
            this.accountidcolumn.Width = 125;
            // 
            // accountnamecolumn
            // 
            this.accountnamecolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountnamecolumn.HeaderText = "Account Name";
            this.accountnamecolumn.MinimumWidth = 6;
            this.accountnamecolumn.Name = "accountnamecolumn";
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(619, 178);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(117, 32);
            this.addbtn.TabIndex = 27;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // GroupingAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1013, 591);
            this.Controls.Add(this.dgvgroupingaccount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "GroupingAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCOUNT GROUPING - FUTURE ART BROADCAST TRADING LLC";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GroupingAccount_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgroupingaccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox groupingnametxtbox;
        private System.Windows.Forms.TextBox selectaccounttxtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptiontxtbox;
        private System.Windows.Forms.DataGridView dgvgroupingaccount;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountnamecolumn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}