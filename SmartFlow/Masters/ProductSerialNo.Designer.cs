namespace SmartFlow.Masters
{
    partial class ProductSerialNo
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
            this.dgvItemSerialNo = new System.Windows.Forms.DataGridView();
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.serialnolbl = new System.Windows.Forms.Label();
            this.serialnotxtbox = new System.Windows.Forms.TextBox();
            this.productidlbl = new System.Windows.Forms.Label();
            this.mfrlbl = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.productidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSerialNo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvItemSerialNo
            // 
            this.dgvItemSerialNo.AllowUserToAddRows = false;
            this.dgvItemSerialNo.AllowUserToDeleteRows = false;
            this.dgvItemSerialNo.AllowUserToResizeColumns = false;
            this.dgvItemSerialNo.AllowUserToResizeRows = false;
            this.dgvItemSerialNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSerialNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productidcolumn,
            this.productmfr,
            this.serialnocolumn});
            this.dgvItemSerialNo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItemSerialNo.Location = new System.Drawing.Point(12, 149);
            this.dgvItemSerialNo.Name = "dgvItemSerialNo";
            this.dgvItemSerialNo.RowHeadersWidth = 51;
            this.dgvItemSerialNo.RowTemplate.Height = 24;
            this.dgvItemSerialNo.Size = new System.Drawing.Size(1107, 501);
            this.dgvItemSerialNo.TabIndex = 0;
            // 
            // selectproductlbl
            // 
            this.selectproductlbl.AutoSize = true;
            this.selectproductlbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproductlbl.Location = new System.Drawing.Point(12, 75);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(112, 18);
            this.selectproductlbl.TabIndex = 3;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(148, 71);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(890, 28);
            this.selectproducttxtbox.TabIndex = 4;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // serialnolbl
            // 
            this.serialnolbl.AutoSize = true;
            this.serialnolbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnolbl.Location = new System.Drawing.Point(12, 109);
            this.serialnolbl.Name = "serialnolbl";
            this.serialnolbl.Size = new System.Drawing.Size(72, 18);
            this.serialnolbl.TabIndex = 5;
            this.serialnolbl.Text = "SERIAL NO";
            // 
            // serialnotxtbox
            // 
            this.serialnotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialnotxtbox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnotxtbox.Location = new System.Drawing.Point(148, 105);
            this.serialnotxtbox.Name = "serialnotxtbox";
            this.serialnotxtbox.Size = new System.Drawing.Size(971, 28);
            this.serialnotxtbox.TabIndex = 6;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(927, 49);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(77, 16);
            this.productidlbl.TabIndex = 7;
            this.productidlbl.Text = "productidlbl";
            this.productidlbl.Visible = false;
            // 
            // mfrlbl
            // 
            this.mfrlbl.AutoSize = true;
            this.mfrlbl.Location = new System.Drawing.Point(738, 50);
            this.mfrlbl.Name = "mfrlbl";
            this.mfrlbl.Size = new System.Drawing.Size(39, 16);
            this.mfrlbl.TabIndex = 8;
            this.mfrlbl.Text = "mfrlbl";
            this.mfrlbl.Visible = false;
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(1044, 71);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 9;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 656);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 60);
            this.panel2.TabIndex = 10;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(803, 3);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(155, 45);
            this.exitbtn.TabIndex = 1;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(964, 3);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(155, 45);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 45);
            this.panel1.TabIndex = 11;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1131, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ADD SERIAL NO";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productidcolumn
            // 
            this.productidcolumn.HeaderText = "ProductID";
            this.productidcolumn.MinimumWidth = 6;
            this.productidcolumn.Name = "productidcolumn";
            this.productidcolumn.Visible = false;
            this.productidcolumn.Width = 125;
            // 
            // productmfr
            // 
            this.productmfr.HeaderText = "MFR";
            this.productmfr.MinimumWidth = 6;
            this.productmfr.Name = "productmfr";
            this.productmfr.Width = 125;
            // 
            // serialnocolumn
            // 
            this.serialnocolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serialnocolumn.HeaderText = "SERIAL NO";
            this.serialnocolumn.MinimumWidth = 6;
            this.serialnocolumn.Name = "serialnocolumn";
            // 
            // ProductSerialNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 716);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.mfrlbl);
            this.Controls.Add(this.productidlbl);
            this.Controls.Add(this.serialnotxtbox);
            this.Controls.Add(this.serialnolbl);
            this.Controls.Add(this.selectproducttxtbox);
            this.Controls.Add(this.selectproductlbl);
            this.Controls.Add(this.dgvItemSerialNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductSerialNo";
            this.Text = "ADD PRODUCT SERIAL NO";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSerialNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemSerialNo;
        private System.Windows.Forms.Label selectproductlbl;
        private System.Windows.Forms.TextBox selectproducttxtbox;
        private System.Windows.Forms.Label serialnolbl;
        private System.Windows.Forms.TextBox serialnotxtbox;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Label mfrlbl;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialnocolumn;
    }
}