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
            this.productidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productmfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectproductlbl = new System.Windows.Forms.Label();
            this.selectproducttxtbox = new System.Windows.Forms.TextBox();
            this.serialnolbl = new System.Windows.Forms.Label();
            this.serialnotxtbox = new System.Windows.Forms.TextBox();
            this.productidlbl = new System.Windows.Forms.Label();
            this.productmfrlbl = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.productbarcodelbl = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.productupclbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.productserialnoinvoicelbl = new System.Windows.Forms.Label();
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
            this.dgvItemSerialNo.Location = new System.Drawing.Point(9, 121);
            this.dgvItemSerialNo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItemSerialNo.Name = "dgvItemSerialNo";
            this.dgvItemSerialNo.RowHeadersWidth = 51;
            this.dgvItemSerialNo.RowTemplate.Height = 24;
            this.dgvItemSerialNo.Size = new System.Drawing.Size(830, 407);
            this.dgvItemSerialNo.TabIndex = 0;
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
            // selectproductlbl
            // 
            this.selectproductlbl.AutoSize = true;
            this.selectproductlbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproductlbl.Location = new System.Drawing.Point(9, 61);
            this.selectproductlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectproductlbl.Name = "selectproductlbl";
            this.selectproductlbl.Size = new System.Drawing.Size(94, 14);
            this.selectproductlbl.TabIndex = 3;
            this.selectproductlbl.Text = "SELECT PRODUCT";
            // 
            // selectproducttxtbox
            // 
            this.selectproducttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectproducttxtbox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproducttxtbox.Location = new System.Drawing.Point(111, 58);
            this.selectproducttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectproducttxtbox.Name = "selectproducttxtbox";
            this.selectproducttxtbox.Size = new System.Drawing.Size(645, 24);
            this.selectproducttxtbox.TabIndex = 4;
            this.selectproducttxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectproducttxtbox_MouseClick);
            this.selectproducttxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectproducttxtbox_KeyDown);
            // 
            // serialnolbl
            // 
            this.serialnolbl.AutoSize = true;
            this.serialnolbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnolbl.Location = new System.Drawing.Point(9, 89);
            this.serialnolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.serialnolbl.Name = "serialnolbl";
            this.serialnolbl.Size = new System.Drawing.Size(61, 14);
            this.serialnolbl.TabIndex = 5;
            this.serialnolbl.Text = "SERIAL NO";
            // 
            // serialnotxtbox
            // 
            this.serialnotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialnotxtbox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnotxtbox.Location = new System.Drawing.Point(111, 85);
            this.serialnotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.serialnotxtbox.Name = "serialnotxtbox";
            this.serialnotxtbox.Size = new System.Drawing.Size(645, 24);
            this.serialnotxtbox.TabIndex = 6;
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(217, 14);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(61, 13);
            this.productidlbl.TabIndex = 7;
            this.productidlbl.Text = "productidlbl";
            this.productidlbl.Visible = false;
            // 
            // productmfrlbl
            // 
            this.productmfrlbl.AutoSize = true;
            this.productmfrlbl.Location = new System.Drawing.Point(182, 14);
            this.productmfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productmfrlbl.Name = "productmfrlbl";
            this.productmfrlbl.Size = new System.Drawing.Size(31, 13);
            this.productmfrlbl.TabIndex = 8;
            this.productmfrlbl.Text = "mfrlbl";
            this.productmfrlbl.Visible = false;
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(760, 56);
            this.addbtn.Margin = new System.Windows.Forms.Padding(2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(77, 53);
            this.addbtn.TabIndex = 9;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.productserialnoinvoicelbl);
            this.panel2.Controls.Add(this.productbarcodelbl);
            this.panel2.Controls.Add(this.exitbtn);
            this.panel2.Controls.Add(this.productupclbl);
            this.panel2.Controls.Add(this.productidlbl);
            this.panel2.Controls.Add(this.productmfrlbl);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 533);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 49);
            this.panel2.TabIndex = 10;
            // 
            // productbarcodelbl
            // 
            this.productbarcodelbl.AutoSize = true;
            this.productbarcodelbl.Location = new System.Drawing.Point(86, 14);
            this.productbarcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productbarcodelbl.Name = "productbarcodelbl";
            this.productbarcodelbl.Size = new System.Drawing.Size(92, 13);
            this.productbarcodelbl.TabIndex = 13;
            this.productbarcodelbl.Text = "productbarcodelbl";
            this.productbarcodelbl.Visible = false;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(602, 2);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(116, 37);
            this.exitbtn.TabIndex = 1;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // productupclbl
            // 
            this.productupclbl.AutoSize = true;
            this.productupclbl.Location = new System.Drawing.Point(11, 14);
            this.productupclbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productupclbl.Name = "productupclbl";
            this.productupclbl.Size = new System.Drawing.Size(71, 13);
            this.productupclbl.TabIndex = 12;
            this.productupclbl.Text = "productupclbl";
            this.productupclbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(723, 2);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(116, 37);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 37);
            this.panel1.TabIndex = 11;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(848, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "ADD SERIAL NO";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productserialnoinvoicelbl
            // 
            this.productserialnoinvoicelbl.AutoSize = true;
            this.productserialnoinvoicelbl.Location = new System.Drawing.Point(407, 18);
            this.productserialnoinvoicelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productserialnoinvoicelbl.Name = "productserialnoinvoicelbl";
            this.productserialnoinvoicelbl.Size = new System.Drawing.Size(123, 13);
            this.productserialnoinvoicelbl.TabIndex = 14;
            this.productserialnoinvoicelbl.Text = "productserialnoinvoicelbl";
            // 
            // ProductSerialNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.serialnotxtbox);
            this.Controls.Add(this.serialnolbl);
            this.Controls.Add(this.selectproducttxtbox);
            this.Controls.Add(this.selectproductlbl);
            this.Controls.Add(this.dgvItemSerialNo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductSerialNo";
            this.Text = "ADD PRODUCT SERIAL NO";
            this.Load += new System.EventHandler(this.ProductSerialNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSerialNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label productmfrlbl;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productmfr;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialnocolumn;
        private System.Windows.Forms.Label productupclbl;
        private System.Windows.Forms.Label productbarcodelbl;
        private System.Windows.Forms.Label productserialnoinvoicelbl;
    }
}