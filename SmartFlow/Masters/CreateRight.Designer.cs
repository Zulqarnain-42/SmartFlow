namespace SmartFlow.Masters
{
    partial class CreateRight
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
            this.rightsnamelbl = new System.Windows.Forms.Label();
            this.rightnametxtbox = new System.Windows.Forms.TextBox();
            this.roleselectionlbl = new System.Windows.Forms.Label();
            this.roleselectiontxtbox = new System.Windows.Forms.TextBox();
            this.dgvSelectedRoles = new System.Windows.Forms.DataGridView();
            this.addbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.roleidlbl = new System.Windows.Forms.Label();
            this.rightsidlbl = new System.Windows.Forms.Label();
            this.roleidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolenamecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoles)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 45);
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
            this.headinglbl.Size = new System.Drawing.Size(1088, 45);
            this.headinglbl.TabIndex = 1;
            this.headinglbl.Text = "CREATE RIGHT";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightsnamelbl
            // 
            this.rightsnamelbl.AutoSize = true;
            this.rightsnamelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightsnamelbl.Location = new System.Drawing.Point(50, 55);
            this.rightsnamelbl.Name = "rightsnamelbl";
            this.rightsnamelbl.Size = new System.Drawing.Size(58, 23);
            this.rightsnamelbl.TabIndex = 1;
            this.rightsnamelbl.Text = "NAME";
            // 
            // rightnametxtbox
            // 
            this.rightnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightnametxtbox.Location = new System.Drawing.Point(178, 51);
            this.rightnametxtbox.Name = "rightnametxtbox";
            this.rightnametxtbox.Size = new System.Drawing.Size(341, 32);
            this.rightnametxtbox.TabIndex = 2;
            // 
            // roleselectionlbl
            // 
            this.roleselectionlbl.AutoSize = true;
            this.roleselectionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleselectionlbl.Location = new System.Drawing.Point(50, 93);
            this.roleselectionlbl.Name = "roleselectionlbl";
            this.roleselectionlbl.Size = new System.Drawing.Size(108, 23);
            this.roleselectionlbl.TabIndex = 3;
            this.roleselectionlbl.Text = "SELECT ROLE";
            // 
            // roleselectiontxtbox
            // 
            this.roleselectiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roleselectiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleselectiontxtbox.Location = new System.Drawing.Point(178, 89);
            this.roleselectiontxtbox.Name = "roleselectiontxtbox";
            this.roleselectiontxtbox.Size = new System.Drawing.Size(341, 32);
            this.roleselectiontxtbox.TabIndex = 4;
            this.roleselectiontxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roleselectiontxtbox_MouseClick);
            this.roleselectiontxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.roleselectiontxtbox_KeyDown);
            // 
            // dgvSelectedRoles
            // 
            this.dgvSelectedRoles.AllowUserToAddRows = false;
            this.dgvSelectedRoles.AllowUserToDeleteRows = false;
            this.dgvSelectedRoles.AllowUserToResizeColumns = false;
            this.dgvSelectedRoles.AllowUserToResizeRows = false;
            this.dgvSelectedRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roleidcolumn,
            this.rolenamecolumn});
            this.dgvSelectedRoles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSelectedRoles.Location = new System.Drawing.Point(0, 138);
            this.dgvSelectedRoles.Name = "dgvSelectedRoles";
            this.dgvSelectedRoles.RowHeadersVisible = false;
            this.dgvSelectedRoles.RowHeadersWidth = 51;
            this.dgvSelectedRoles.RowTemplate.Height = 24;
            this.dgvSelectedRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedRoles.Size = new System.Drawing.Size(1088, 463);
            this.dgvSelectedRoles.TabIndex = 5;
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(525, 89);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 32);
            this.addbtn.TabIndex = 6;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 607);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1088, 60);
            this.panel2.TabIndex = 7;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(760, 3);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(155, 45);
            this.exitbtn.TabIndex = 1;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(921, 3);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(155, 45);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // roleidlbl
            // 
            this.roleidlbl.AutoSize = true;
            this.roleidlbl.Location = new System.Drawing.Point(671, 61);
            this.roleidlbl.Name = "roleidlbl";
            this.roleidlbl.Size = new System.Drawing.Size(55, 16);
            this.roleidlbl.TabIndex = 8;
            this.roleidlbl.Text = "roleidlbl";
            this.roleidlbl.Visible = false;
            // 
            // rightsidlbl
            // 
            this.rightsidlbl.AutoSize = true;
            this.rightsidlbl.Location = new System.Drawing.Point(526, 55);
            this.rightsidlbl.Name = "rightsidlbl";
            this.rightsidlbl.Size = new System.Drawing.Size(64, 16);
            this.rightsidlbl.TabIndex = 9;
            this.rightsidlbl.Text = "rightsidlbl";
            this.rightsidlbl.Visible = false;
            // 
            // roleidcolumn
            // 
            this.roleidcolumn.HeaderText = "ID";
            this.roleidcolumn.MinimumWidth = 6;
            this.roleidcolumn.Name = "roleidcolumn";
            this.roleidcolumn.Width = 125;
            // 
            // rolenamecolumn
            // 
            this.rolenamecolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rolenamecolumn.HeaderText = "Role Name";
            this.rolenamecolumn.MinimumWidth = 6;
            this.rolenamecolumn.Name = "rolenamecolumn";
            // 
            // CreateRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 667);
            this.Controls.Add(this.rightsidlbl);
            this.Controls.Add(this.roleidlbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.dgvSelectedRoles);
            this.Controls.Add(this.roleselectiontxtbox);
            this.Controls.Add(this.roleselectionlbl);
            this.Controls.Add(this.rightnametxtbox);
            this.Controls.Add(this.rightsnamelbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "CreateRight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE RIGHTS";
            this.Load += new System.EventHandler(this.CreateRights_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoles)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label rightsnamelbl;
        private System.Windows.Forms.TextBox rightnametxtbox;
        private System.Windows.Forms.Label roleselectionlbl;
        private System.Windows.Forms.TextBox roleselectiontxtbox;
        private System.Windows.Forms.DataGridView dgvSelectedRoles;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label roleidlbl;
        private System.Windows.Forms.Label rightsidlbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolenamecolumn;
    }
}