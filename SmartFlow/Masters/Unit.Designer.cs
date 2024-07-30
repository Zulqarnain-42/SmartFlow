namespace SmartFlow
{
    partial class Unit
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
            this.unitdatagridview = new System.Windows.Forms.DataGridView();
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.unitdescription = new System.Windows.Forms.TextBox();
            this.DESCRIPTIONLBL = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.unitnametxtbox = new System.Windows.Forms.TextBox();
            this.UNITNAMELBL = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.unitdatagridview)).BeginInit();
            this.gridViewMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // unitdatagridview
            // 
            this.unitdatagridview.AllowUserToAddRows = false;
            this.unitdatagridview.AllowUserToResizeRows = false;
            this.unitdatagridview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitdatagridview.BackgroundColor = System.Drawing.Color.White;
            this.unitdatagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unitdatagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.unitdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.unitdatagridview.ContextMenuStrip = this.gridViewMenuStrip;
            this.unitdatagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.unitdatagridview.Location = new System.Drawing.Point(3, 6);
            this.unitdatagridview.MultiSelect = false;
            this.unitdatagridview.Name = "unitdatagridview";
            this.unitdatagridview.ReadOnly = true;
            this.unitdatagridview.RowHeadersVisible = false;
            this.unitdatagridview.RowHeadersWidth = 51;
            this.unitdatagridview.RowTemplate.Height = 24;
            this.unitdatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.unitdatagridview.Size = new System.Drawing.Size(1274, 337);
            this.unitdatagridview.TabIndex = 0;
            this.unitdatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.unitdatagridview_CellDoubleClick);
            this.unitdatagridview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.unitdatagridview_Scroll);
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
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1538, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(87, 18);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(500, 32);
            this.searchtxtbox.TabIndex = 4;
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(12, 18);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(66, 23);
            this.searchlbl.TabIndex = 3;
            this.searchlbl.Text = "Search ";
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(1287, 310);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(295, 40);
            this.exitbtn.TabIndex = 5;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // unitdescription
            // 
            this.unitdescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitdescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unitdescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitdescription.Location = new System.Drawing.Point(1287, 88);
            this.unitdescription.Multiline = true;
            this.unitdescription.Name = "unitdescription";
            this.unitdescription.Size = new System.Drawing.Size(295, 170);
            this.unitdescription.TabIndex = 4;
            // 
            // DESCRIPTIONLBL
            // 
            this.DESCRIPTIONLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DESCRIPTIONLBL.AutoSize = true;
            this.DESCRIPTIONLBL.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DESCRIPTIONLBL.Location = new System.Drawing.Point(1283, 62);
            this.DESCRIPTIONLBL.Name = "DESCRIPTIONLBL";
            this.DESCRIPTIONLBL.Size = new System.Drawing.Size(116, 23);
            this.DESCRIPTIONLBL.TabIndex = 3;
            this.DESCRIPTIONLBL.Text = "DESCRIPTION";
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1287, 264);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(295, 40);
            this.savebtn.TabIndex = 2;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // unitnametxtbox
            // 
            this.unitnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unitnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitnametxtbox.Location = new System.Drawing.Point(1287, 29);
            this.unitnametxtbox.Name = "unitnametxtbox";
            this.unitnametxtbox.Size = new System.Drawing.Size(295, 32);
            this.unitnametxtbox.TabIndex = 1;
            // 
            // UNITNAMELBL
            // 
            this.UNITNAMELBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UNITNAMELBL.AutoSize = true;
            this.UNITNAMELBL.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UNITNAMELBL.Location = new System.Drawing.Point(1283, 3);
            this.UNITNAMELBL.Name = "UNITNAMELBL";
            this.UNITNAMELBL.Size = new System.Drawing.Size(101, 23);
            this.UNITNAMELBL.TabIndex = 0;
            this.UNITNAMELBL.Text = "UNIT NAME";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1594, 45);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1594, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "UNIT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.searchtxtbox);
            this.panel3.Controls.Add(this.searchlbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1594, 59);
            this.panel3.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.unitdatagridview);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.unitdescription);
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.UNITNAMELBL);
            this.panel2.Controls.Add(this.unitnametxtbox);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Controls.Add(this.DESCRIPTIONLBL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1594, 666);
            this.panel2.TabIndex = 20;
            // 
            // Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1594, 770);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Unit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNIT - FUTURE ART BROADCAST TRADING LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Unit_FormClosing);
            this.Load += new System.EventHandler(this.Unit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Unit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.unitdatagridview)).EndInit();
            this.gridViewMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView unitdatagridview;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.ContextMenuStrip gridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox unitnametxtbox;
        private System.Windows.Forms.Label UNITNAMELBL;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox unitdescription;
        private System.Windows.Forms.Label DESCRIPTIONLBL;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}