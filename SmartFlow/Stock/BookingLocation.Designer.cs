namespace SmartFlow.Stock
{
    partial class BookingLocation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.descriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.racklocationdescriptionlbl = new System.Windows.Forms.Label();
            this.bookingcodetxtbox = new System.Windows.Forms.TextBox();
            this.rackcodelbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.bookinglocationidlbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.dgvListRack = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 37);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(885, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "BOOKING LOCATION";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(631, 177);
            this.descriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(249, 122);
            this.descriptiontxtbox.TabIndex = 85;
            this.descriptiontxtbox.Text = "";
            // 
            // racklocationdescriptionlbl
            // 
            this.racklocationdescriptionlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.racklocationdescriptionlbl.AutoSize = true;
            this.racklocationdescriptionlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.racklocationdescriptionlbl.Location = new System.Drawing.Point(631, 157);
            this.racklocationdescriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.racklocationdescriptionlbl.Name = "racklocationdescriptionlbl";
            this.racklocationdescriptionlbl.Size = new System.Drawing.Size(156, 18);
            this.racklocationdescriptionlbl.TabIndex = 84;
            this.racklocationdescriptionlbl.Text = "LOCATION DESCRIPTION";
            // 
            // bookingcodetxtbox
            // 
            this.bookingcodetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bookingcodetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookingcodetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingcodetxtbox.Location = new System.Drawing.Point(631, 119);
            this.bookingcodetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.bookingcodetxtbox.Name = "bookingcodetxtbox";
            this.bookingcodetxtbox.ReadOnly = true;
            this.bookingcodetxtbox.Size = new System.Drawing.Size(249, 27);
            this.bookingcodetxtbox.TabIndex = 82;
            // 
            // rackcodelbl
            // 
            this.rackcodelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rackcodelbl.AutoSize = true;
            this.rackcodelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rackcodelbl.Location = new System.Drawing.Point(631, 97);
            this.rackcodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rackcodelbl.Name = "rackcodelbl";
            this.rackcodelbl.Size = new System.Drawing.Size(170, 18);
            this.rackcodelbl.TabIndex = 83;
            this.rackcodelbl.Text = "BOOKING LOCATION CODE";
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(632, 323);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 81;
            this.warehouseidlbl.Text = "warehouseidlbl";
            this.warehouseidlbl.Visible = false;
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(631, 63);
            this.selectwarehousetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(249, 27);
            this.selectwarehousetxtbox.TabIndex = 80;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(631, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "SELECT WAREHOUSE";
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(632, 382);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(248, 29);
            this.closebtn.TabIndex = 78;
            this.closebtn.Text = "EXIT";
            this.closebtn.UseVisualStyleBackColor = true;
            // 
            // bookinglocationidlbl
            // 
            this.bookinglocationidlbl.AutoSize = true;
            this.bookinglocationidlbl.Location = new System.Drawing.Point(632, 301);
            this.bookinglocationidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookinglocationidlbl.Name = "bookinglocationidlbl";
            this.bookinglocationidlbl.Size = new System.Drawing.Size(100, 13);
            this.bookinglocationidlbl.TabIndex = 77;
            this.bookinglocationidlbl.Text = "bookinglocationidlbl";
            this.bookinglocationidlbl.Visible = false;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(632, 349);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(248, 29);
            this.savebtn.TabIndex = 76;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            // 
            // dgvListRack
            // 
            this.dgvListRack.AllowUserToAddRows = false;
            this.dgvListRack.AllowUserToDeleteRows = false;
            this.dgvListRack.AllowUserToResizeColumns = false;
            this.dgvListRack.AllowUserToResizeRows = false;
            this.dgvListRack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListRack.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListRack.CausesValidation = false;
            this.dgvListRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRack.ColumnHeadersVisible = false;
            this.dgvListRack.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListRack.Location = new System.Drawing.Point(4, 39);
            this.dgvListRack.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListRack.Name = "dgvListRack";
            this.dgvListRack.RowHeadersWidth = 51;
            this.dgvListRack.RowTemplate.Height = 24;
            this.dgvListRack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListRack.Size = new System.Drawing.Size(623, 379);
            this.dgvListRack.TabIndex = 75;
            // 
            // BookingLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 421);
            this.Controls.Add(this.descriptiontxtbox);
            this.Controls.Add(this.racklocationdescriptionlbl);
            this.Controls.Add(this.bookingcodetxtbox);
            this.Controls.Add(this.rackcodelbl);
            this.Controls.Add(this.warehouseidlbl);
            this.Controls.Add(this.selectwarehousetxtbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.bookinglocationidlbl);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.dgvListRack);
            this.Controls.Add(this.panel1);
            this.Name = "BookingLocation";
            this.Text = "BOOKING LOCATION";
            this.Load += new System.EventHandler(this.BookingLocation_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.RichTextBox descriptiontxtbox;
        private System.Windows.Forms.Label racklocationdescriptionlbl;
        private System.Windows.Forms.TextBox bookingcodetxtbox;
        private System.Windows.Forms.Label rackcodelbl;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label bookinglocationidlbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.DataGridView dgvListRack;
    }
}