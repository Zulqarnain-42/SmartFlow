namespace SmartFlow.Masters
{
    partial class ExcelAccounts
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
            this.selectfilebtn = new System.Windows.Forms.Button();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.selectAccounttxtbox = new System.Windows.Forms.TextBox();
            this.sheetCombo = new System.Windows.Forms.ComboBox();
            this.sheetselectionlbl = new System.Windows.Forms.Label();
            this.accountgroupselectionlbl = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.dataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.accountgroupidlabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sampleexcelfilebtn = new System.Windows.Forms.Button();
            this.accountheadidlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 37);
            this.panel1.TabIndex = 0;
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
            this.headinglbl.Size = new System.Drawing.Size(1196, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "UPLOAD ACCOUNTS USING EXCEL";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectfilebtn
            // 
            this.selectfilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectfilebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectfilebtn.Location = new System.Drawing.Point(9, 54);
            this.selectfilebtn.Margin = new System.Windows.Forms.Padding(2);
            this.selectfilebtn.Name = "selectfilebtn";
            this.selectfilebtn.Size = new System.Drawing.Size(203, 28);
            this.selectfilebtn.TabIndex = 47;
            this.selectfilebtn.Text = "SELECT THE EXCEL FILE";
            this.selectfilebtn.UseVisualStyleBackColor = true;
            this.selectfilebtn.Click += new System.EventHandler(this.selectfilebtn_Click);
            // 
            // txtfilename
            // 
            this.txtfilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfilename.Enabled = false;
            this.txtfilename.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilename.Location = new System.Drawing.Point(9, 88);
            this.txtfilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(204, 27);
            this.txtfilename.TabIndex = 58;
            // 
            // selectAccounttxtbox
            // 
            this.selectAccounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectAccounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAccounttxtbox.Location = new System.Drawing.Point(8, 254);
            this.selectAccounttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectAccounttxtbox.Name = "selectAccounttxtbox";
            this.selectAccounttxtbox.Size = new System.Drawing.Size(204, 27);
            this.selectAccounttxtbox.TabIndex = 63;
            this.selectAccounttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectAccounttxtbox_MouseClick);
            // 
            // sheetCombo
            // 
            this.sheetCombo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetCombo.FormattingEnabled = true;
            this.sheetCombo.Location = new System.Drawing.Point(9, 206);
            this.sheetCombo.Margin = new System.Windows.Forms.Padding(2);
            this.sheetCombo.Name = "sheetCombo";
            this.sheetCombo.Size = new System.Drawing.Size(204, 27);
            this.sheetCombo.TabIndex = 62;
            this.sheetCombo.SelectedIndexChanged += new System.EventHandler(this.sheetCombo_SelectedIndexChanged);
            // 
            // sheetselectionlbl
            // 
            this.sheetselectionlbl.AutoSize = true;
            this.sheetselectionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetselectionlbl.Location = new System.Drawing.Point(8, 184);
            this.sheetselectionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sheetselectionlbl.Name = "sheetselectionlbl";
            this.sheetselectionlbl.Size = new System.Drawing.Size(98, 18);
            this.sheetselectionlbl.TabIndex = 61;
            this.sheetselectionlbl.Text = "Select a Sheet ";
            // 
            // accountgroupselectionlbl
            // 
            this.accountgroupselectionlbl.AutoSize = true;
            this.accountgroupselectionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountgroupselectionlbl.Location = new System.Drawing.Point(8, 232);
            this.accountgroupselectionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountgroupselectionlbl.Name = "accountgroupselectionlbl";
            this.accountgroupselectionlbl.Size = new System.Drawing.Size(140, 18);
            this.accountgroupselectionlbl.TabIndex = 60;
            this.accountgroupselectionlbl.Text = "Select Account Group";
            // 
            // exitbtn
            // 
            this.exitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(9, 316);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(203, 28);
            this.exitbtn.TabIndex = 65;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(8, 284);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(203, 28);
            this.savebtn.TabIndex = 64;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // dataGridViewExcel
            // 
            this.dataGridViewExcel.AllowUserToAddRows = false;
            this.dataGridViewExcel.AllowUserToDeleteRows = false;
            this.dataGridViewExcel.AllowUserToResizeRows = false;
            this.dataGridViewExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExcel.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewExcel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExcel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewExcel.Location = new System.Drawing.Point(220, 58);
            this.dataGridViewExcel.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewExcel.Name = "dataGridViewExcel";
            this.dataGridViewExcel.ReadOnly = true;
            this.dataGridViewExcel.RowHeadersVisible = false;
            this.dataGridViewExcel.RowHeadersWidth = 51;
            this.dataGridViewExcel.RowTemplate.Height = 24;
            this.dataGridViewExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExcel.Size = new System.Drawing.Size(967, 534);
            this.dataGridViewExcel.TabIndex = 66;
            // 
            // accountgroupidlabel
            // 
            this.accountgroupidlabel.AutoSize = true;
            this.accountgroupidlabel.Location = new System.Drawing.Point(10, 348);
            this.accountgroupidlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountgroupidlabel.Name = "accountgroupidlabel";
            this.accountgroupidlabel.Size = new System.Drawing.Size(103, 13);
            this.accountgroupidlabel.TabIndex = 67;
            this.accountgroupidlabel.Text = "accountgroupidlabel";
            this.accountgroupidlabel.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // sampleexcelfilebtn
            // 
            this.sampleexcelfilebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sampleexcelfilebtn.Location = new System.Drawing.Point(9, 567);
            this.sampleexcelfilebtn.Margin = new System.Windows.Forms.Padding(2);
            this.sampleexcelfilebtn.Name = "sampleexcelfilebtn";
            this.sampleexcelfilebtn.Size = new System.Drawing.Size(203, 24);
            this.sampleexcelfilebtn.TabIndex = 68;
            this.sampleexcelfilebtn.Text = "DOWNLOAD SAMPLE FILE";
            this.sampleexcelfilebtn.UseVisualStyleBackColor = true;
            // 
            // accountheadidlbl
            // 
            this.accountheadidlbl.AutoSize = true;
            this.accountheadidlbl.Location = new System.Drawing.Point(11, 361);
            this.accountheadidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountheadidlbl.Name = "accountheadidlbl";
            this.accountheadidlbl.Size = new System.Drawing.Size(88, 13);
            this.accountheadidlbl.TabIndex = 69;
            this.accountheadidlbl.Text = "accountheadidlbl";
            this.accountheadidlbl.Visible = false;
            // 
            // ExcelAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1196, 601);
            this.Controls.Add(this.accountheadidlbl);
            this.Controls.Add(this.sampleexcelfilebtn);
            this.Controls.Add(this.accountgroupidlabel);
            this.Controls.Add(this.dataGridViewExcel);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.selectAccounttxtbox);
            this.Controls.Add(this.sheetCombo);
            this.Controls.Add(this.sheetselectionlbl);
            this.Controls.Add(this.accountgroupselectionlbl);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.selectfilebtn);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ExcelAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPLOAD ACCOUNTS USING EXCEL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Button selectfilebtn;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.TextBox selectAccounttxtbox;
        private System.Windows.Forms.ComboBox sheetCombo;
        private System.Windows.Forms.Label sheetselectionlbl;
        private System.Windows.Forms.Label accountgroupselectionlbl;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.DataGridView dataGridViewExcel;
        private System.Windows.Forms.Label accountgroupidlabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button sampleexcelfilebtn;
        private System.Windows.Forms.Label accountheadidlbl;
    }
}