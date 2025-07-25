﻿namespace SmartFlow.Masters
{
    partial class UploadExcel
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
            this.selectfilebtn = new System.Windows.Forms.Button();
            this.dataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.savebtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.warehouseselectionlbl = new System.Windows.Forms.Label();
            this.locationselection = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sheetselectionlbl = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.sampleexcelfilebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectfilebtn
            // 
            this.selectfilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectfilebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectfilebtn.Location = new System.Drawing.Point(10, 58);
            this.selectfilebtn.Margin = new System.Windows.Forms.Padding(2);
            this.selectfilebtn.Name = "selectfilebtn";
            this.selectfilebtn.Size = new System.Drawing.Size(203, 28);
            this.selectfilebtn.TabIndex = 46;
            this.selectfilebtn.Text = "SELECT THE EXCEL FILE";
            this.selectfilebtn.UseVisualStyleBackColor = true;
            this.selectfilebtn.Click += new System.EventHandler(this.selectfilebtn_Click);
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
            this.dataGridViewExcel.TabIndex = 47;
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(11, 354);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(203, 29);
            this.savebtn.TabIndex = 49;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(10, 387);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(203, 29);
            this.exitbtn.TabIndex = 50;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // warehouseselectionlbl
            // 
            this.warehouseselectionlbl.AutoSize = true;
            this.warehouseselectionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouseselectionlbl.Location = new System.Drawing.Point(9, 248);
            this.warehouseselectionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseselectionlbl.Name = "warehouseselectionlbl";
            this.warehouseselectionlbl.Size = new System.Drawing.Size(128, 18);
            this.warehouseselectionlbl.TabIndex = 52;
            this.warehouseselectionlbl.Text = "Select a warehouse";
            // 
            // locationselection
            // 
            this.locationselection.AutoSize = true;
            this.locationselection.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationselection.Location = new System.Drawing.Point(7, 296);
            this.locationselection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.locationselection.Name = "locationselection";
            this.locationselection.Size = new System.Drawing.Size(110, 18);
            this.locationselection.TabIndex = 53;
            this.locationselection.Text = "Select a Location";
            this.locationselection.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 317);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 27);
            this.comboBox1.TabIndex = 54;
            this.comboBox1.Visible = false;
            // 
            // sheetselectionlbl
            // 
            this.sheetselectionlbl.AutoSize = true;
            this.sheetselectionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetselectionlbl.Location = new System.Drawing.Point(9, 200);
            this.sheetselectionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sheetselectionlbl.Name = "sheetselectionlbl";
            this.sheetselectionlbl.Size = new System.Drawing.Size(98, 18);
            this.sheetselectionlbl.TabIndex = 55;
            this.sheetselectionlbl.Text = "Select a Sheet ";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(10, 221);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(204, 27);
            this.comboBox2.TabIndex = 56;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txtfilename
            // 
            this.txtfilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfilename.Enabled = false;
            this.txtfilename.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilename.Location = new System.Drawing.Point(9, 91);
            this.txtfilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(204, 27);
            this.txtfilename.TabIndex = 57;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 37);
            this.panel1.TabIndex = 58;
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
            this.headinglbl.Text = "UPLOAD USING EXCEL";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(9, 269);
            this.selectwarehousetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(204, 27);
            this.selectwarehousetxtbox.TabIndex = 59;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehouse_MouseClick);
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(12, 123);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(70, 13);
            this.warehouseidlbl.TabIndex = 60;
            this.warehouseidlbl.Text = "Warehouseid";
            this.warehouseidlbl.Visible = false;
            // 
            // sampleexcelfilebtn
            // 
            this.sampleexcelfilebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sampleexcelfilebtn.Location = new System.Drawing.Point(9, 567);
            this.sampleexcelfilebtn.Margin = new System.Windows.Forms.Padding(2);
            this.sampleexcelfilebtn.Name = "sampleexcelfilebtn";
            this.sampleexcelfilebtn.Size = new System.Drawing.Size(203, 24);
            this.sampleexcelfilebtn.TabIndex = 61;
            this.sampleexcelfilebtn.Text = "DOWNLOAD SAMPLE FILE";
            this.sampleexcelfilebtn.UseVisualStyleBackColor = true;
            // 
            // UploadExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1196, 601);
            this.Controls.Add(this.sampleexcelfilebtn);
            this.Controls.Add(this.warehouseidlbl);
            this.Controls.Add(this.selectwarehousetxtbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.sheetselectionlbl);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.locationselection);
            this.Controls.Add(this.warehouseselectionlbl);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.dataGridViewExcel);
            this.Controls.Add(this.selectfilebtn);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UploadExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPLOAD PRODUCTS USING EXCEL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadExcel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UploadExcel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button selectfilebtn;
        private System.Windows.Forms.DataGridView dataGridViewExcel;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label locationselection;
        private System.Windows.Forms.Label warehouseselectionlbl;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label sheetselectionlbl;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Button sampleexcelfilebtn;
    }
}