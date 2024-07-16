namespace SmartFlow
{
    partial class StockLocation
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
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.locationdatagridview = new System.Windows.Forms.DataGridView();
            this.gridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.locationid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shortnametxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.racknotxtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.createlocationsavebtn = new System.Windows.Forms.Button();
            this.locationnametxtbox = new System.Windows.Forms.TextBox();
            this.usertypelbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.locationdatagridview)).BeginInit();
            this.gridViewMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(96, 11);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(500, 32);
            this.searchtxtbox.TabIndex = 4;
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(12, 15);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(63, 22);
            this.searchlbl.TabIndex = 3;
            this.searchlbl.Text = "Search ";
            // 
            // locationdatagridview
            // 
            this.locationdatagridview.AllowUserToAddRows = false;
            this.locationdatagridview.AllowUserToResizeRows = false;
            this.locationdatagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationdatagridview.BackgroundColor = System.Drawing.Color.White;
            this.locationdatagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.locationdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.locationdatagridview.ContextMenuStrip = this.gridViewMenuStrip;
            this.locationdatagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.locationdatagridview.Location = new System.Drawing.Point(0, 0);
            this.locationdatagridview.MultiSelect = false;
            this.locationdatagridview.Name = "locationdatagridview";
            this.locationdatagridview.ReadOnly = true;
            this.locationdatagridview.RowHeadersVisible = false;
            this.locationdatagridview.RowHeadersWidth = 51;
            this.locationdatagridview.RowTemplate.Height = 24;
            this.locationdatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.locationdatagridview.Size = new System.Drawing.Size(1277, 663);
            this.locationdatagridview.TabIndex = 0;
            this.locationdatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.locationdatagridview_CellDoubleClick);
            this.locationdatagridview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.locationdatagridview_Scroll);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1594, 45);
            this.panel1.TabIndex = 15;
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
            this.label1.Text = "STOCK LOCATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.warehouseidlbl);
            this.panel2.Controls.Add(this.searchlbl);
            this.panel2.Controls.Add(this.searchtxtbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1594, 59);
            this.panel2.TabIndex = 16;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(1498, 15);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(84, 16);
            this.warehouseidlbl.TabIndex = 5;
            this.warehouseidlbl.Text = "warehouseid";
            this.warehouseidlbl.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.selectwarehousetxtbox);
            this.panel4.Controls.Add(this.locationid);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.shortnametxtbox);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.racknotxtbox);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.exitbtn);
            this.panel4.Controls.Add(this.createlocationsavebtn);
            this.panel4.Controls.Add(this.locationnametxtbox);
            this.panel4.Controls.Add(this.usertypelbl);
            this.panel4.Controls.Add(this.locationdatagridview);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 104);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1594, 666);
            this.panel4.TabIndex = 17;
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectwarehousetxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousetxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(1287, 29);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(295, 32);
            this.selectwarehousetxtbox.TabIndex = 28;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // locationid
            // 
            this.locationid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationid.AutoSize = true;
            this.locationid.Location = new System.Drawing.Point(1517, 8);
            this.locationid.Name = "locationid";
            this.locationid.Size = new System.Drawing.Size(65, 16);
            this.locationid.TabIndex = 27;
            this.locationid.Text = "locationid";
            this.locationid.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F);
            this.label3.Location = new System.Drawing.Point(1283, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Select Warehouse ";
            // 
            // shortnametxtbox
            // 
            this.shortnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shortnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shortnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortnametxtbox.Location = new System.Drawing.Point(1287, 216);
            this.shortnametxtbox.Name = "shortnametxtbox";
            this.shortnametxtbox.Size = new System.Drawing.Size(295, 32);
            this.shortnametxtbox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(1283, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Short Name ";
            // 
            // racknotxtbox
            // 
            this.racknotxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.racknotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.racknotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.racknotxtbox.Location = new System.Drawing.Point(1287, 154);
            this.racknotxtbox.Name = "racknotxtbox";
            this.racknotxtbox.Size = new System.Drawing.Size(295, 32);
            this.racknotxtbox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11F);
            this.label5.Location = new System.Drawing.Point(1283, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 24;
            this.label5.Text = "Rack No ";
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F);
            this.exitbtn.Location = new System.Drawing.Point(1287, 300);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(295, 40);
            this.exitbtn.TabIndex = 22;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // createlocationsavebtn
            // 
            this.createlocationsavebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createlocationsavebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.createlocationsavebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createlocationsavebtn.Font = new System.Drawing.Font("Impact", 12F);
            this.createlocationsavebtn.Location = new System.Drawing.Point(1287, 254);
            this.createlocationsavebtn.Name = "createlocationsavebtn";
            this.createlocationsavebtn.Size = new System.Drawing.Size(295, 40);
            this.createlocationsavebtn.TabIndex = 21;
            this.createlocationsavebtn.Text = "Save";
            this.createlocationsavebtn.UseVisualStyleBackColor = false;
            this.createlocationsavebtn.Click += new System.EventHandler(this.createlocationsavebtn_Click);
            // 
            // locationnametxtbox
            // 
            this.locationnametxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.locationnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.locationnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationnametxtbox.Location = new System.Drawing.Point(1287, 92);
            this.locationnametxtbox.Name = "locationnametxtbox";
            this.locationnametxtbox.Size = new System.Drawing.Size(295, 32);
            this.locationnametxtbox.TabIndex = 18;
            // 
            // usertypelbl
            // 
            this.usertypelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usertypelbl.AutoSize = true;
            this.usertypelbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.usertypelbl.Location = new System.Drawing.Point(1283, 65);
            this.usertypelbl.Name = "usertypelbl";
            this.usertypelbl.Size = new System.Drawing.Size(129, 23);
            this.usertypelbl.TabIndex = 23;
            this.usertypelbl.Text = "Location Name ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // StockLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1594, 770);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Location - Future Art Broadcast Trading LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockLocation_FormClosing);
            this.Load += new System.EventHandler(this.StockLocation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockLocation_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.locationdatagridview)).EndInit();
            this.gridViewMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.DataGridView locationdatagridview;
        private System.Windows.Forms.ContextMenuStrip gridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label locationid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox shortnametxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox racknotxtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button createlocationsavebtn;
        private System.Windows.Forms.TextBox locationnametxtbox;
        private System.Windows.Forms.Label usertypelbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label warehouseidlbl;
    }
}