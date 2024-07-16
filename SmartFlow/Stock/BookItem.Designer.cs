namespace SmartFlow.Stock
{
    partial class BookItem
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
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.startdatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.startdatelbl = new System.Windows.Forms.Label();
            this.enddatelbl = new System.Windows.Forms.Label();
            this.enddatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvbookingitem = new System.Windows.Forms.DataGridView();
            this.importantnoteslbl = new System.Windows.Forms.Label();
            this.importantnotestxtbox = new System.Windows.Forms.RichTextBox();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.selectwarehouselbl = new System.Windows.Forms.Label();
            this.selectwarehousetxtbox = new System.Windows.Forms.TextBox();
            this.bookinglocationlbl = new System.Windows.Forms.Label();
            this.bookinglocationtxtbox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbookingitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1296, 45);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1296, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "BOOKING OF ITEMS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(12, 15);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(106, 23);
            this.invoicenolbl.TabIndex = 1;
            this.invoicenolbl.Text = "INVOICE NO";
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.invoicenotxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.invoicenotxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(136, 10);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(360, 32);
            this.invoicenotxtbox.TabIndex = 2;
            // 
            // startdatetxtbox
            // 
            this.startdatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startdatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatetxtbox.Location = new System.Drawing.Point(136, 47);
            this.startdatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.startdatetxtbox.Mask = "00/00/0000";
            this.startdatetxtbox.Name = "startdatetxtbox";
            this.startdatetxtbox.Size = new System.Drawing.Size(360, 32);
            this.startdatetxtbox.TabIndex = 117;
            this.startdatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bookinglocationlbl);
            this.panel2.Controls.Add(this.bookinglocationtxtbox);
            this.panel2.Controls.Add(this.selectwarehouselbl);
            this.panel2.Controls.Add(this.selectwarehousetxtbox);
            this.panel2.Controls.Add(this.searchbtn);
            this.panel2.Controls.Add(this.enddatetxtbox);
            this.panel2.Controls.Add(this.enddatelbl);
            this.panel2.Controls.Add(this.startdatelbl);
            this.panel2.Controls.Add(this.invoicenolbl);
            this.panel2.Controls.Add(this.startdatetxtbox);
            this.panel2.Controls.Add(this.invoicenotxtbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 134);
            this.panel2.TabIndex = 118;
            // 
            // startdatelbl
            // 
            this.startdatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startdatelbl.AutoSize = true;
            this.startdatelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdatelbl.Location = new System.Drawing.Point(12, 52);
            this.startdatelbl.Name = "startdatelbl";
            this.startdatelbl.Size = new System.Drawing.Size(101, 23);
            this.startdatelbl.TabIndex = 118;
            this.startdatelbl.Text = "START DATE";
            // 
            // enddatelbl
            // 
            this.enddatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatelbl.AutoSize = true;
            this.enddatelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatelbl.Location = new System.Drawing.Point(12, 90);
            this.enddatelbl.Name = "enddatelbl";
            this.enddatelbl.Size = new System.Drawing.Size(87, 23);
            this.enddatelbl.TabIndex = 119;
            this.enddatelbl.Text = "END DATE";
            // 
            // enddatetxtbox
            // 
            this.enddatetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.enddatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enddatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddatetxtbox.Location = new System.Drawing.Point(136, 85);
            this.enddatetxtbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.enddatetxtbox.Mask = "00/00/0000";
            this.enddatetxtbox.Name = "enddatetxtbox";
            this.enddatetxtbox.Size = new System.Drawing.Size(360, 32);
            this.enddatetxtbox.TabIndex = 120;
            this.enddatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // searchbtn
            // 
            this.searchbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchbtn.Location = new System.Drawing.Point(503, 10);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(124, 32);
            this.searchbtn.TabIndex = 121;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.closebtn);
            this.panel3.Controls.Add(this.savebtn);
            this.panel3.Controls.Add(this.importantnotestxtbox);
            this.panel3.Controls.Add(this.importantnoteslbl);
            this.panel3.Controls.Add(this.dgvbookingitem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1296, 579);
            this.panel3.TabIndex = 119;
            // 
            // dgvbookingitem
            // 
            this.dgvbookingitem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvbookingitem.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvbookingitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbookingitem.Location = new System.Drawing.Point(3, 0);
            this.dgvbookingitem.Name = "dgvbookingitem";
            this.dgvbookingitem.RowHeadersWidth = 51;
            this.dgvbookingitem.RowTemplate.Height = 24;
            this.dgvbookingitem.Size = new System.Drawing.Size(975, 576);
            this.dgvbookingitem.TabIndex = 0;
            // 
            // importantnoteslbl
            // 
            this.importantnoteslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importantnoteslbl.AutoSize = true;
            this.importantnoteslbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importantnoteslbl.Location = new System.Drawing.Point(985, 7);
            this.importantnoteslbl.Name = "importantnoteslbl";
            this.importantnoteslbl.Size = new System.Drawing.Size(160, 23);
            this.importantnoteslbl.TabIndex = 1;
            this.importantnoteslbl.Text = "IMPORTANT NOTES";
            // 
            // importantnotestxtbox
            // 
            this.importantnotestxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importantnotestxtbox.Location = new System.Drawing.Point(989, 33);
            this.importantnotestxtbox.Name = "importantnotestxtbox";
            this.importantnotestxtbox.Size = new System.Drawing.Size(295, 296);
            this.importantnotestxtbox.TabIndex = 2;
            this.importantnotestxtbox.Text = "";
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(989, 522);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(295, 45);
            this.closebtn.TabIndex = 40;
            this.closebtn.Text = "CLOSE";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(989, 471);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(295, 45);
            this.savebtn.TabIndex = 39;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // selectwarehouselbl
            // 
            this.selectwarehouselbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectwarehouselbl.AutoSize = true;
            this.selectwarehouselbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehouselbl.Location = new System.Drawing.Point(657, 52);
            this.selectwarehouselbl.Name = "selectwarehouselbl";
            this.selectwarehouselbl.Size = new System.Drawing.Size(111, 23);
            this.selectwarehouselbl.TabIndex = 122;
            this.selectwarehouselbl.Text = "WAREHOUSE";
            // 
            // selectwarehousetxtbox
            // 
            this.selectwarehousetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectwarehousetxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.selectwarehousetxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectwarehousetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectwarehousetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectwarehousetxtbox.Location = new System.Drawing.Point(848, 47);
            this.selectwarehousetxtbox.Name = "selectwarehousetxtbox";
            this.selectwarehousetxtbox.Size = new System.Drawing.Size(360, 32);
            this.selectwarehousetxtbox.TabIndex = 123;
            this.selectwarehousetxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectwarehousetxtbox_MouseClick);
            // 
            // bookinglocationlbl
            // 
            this.bookinglocationlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookinglocationlbl.AutoSize = true;
            this.bookinglocationlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookinglocationlbl.Location = new System.Drawing.Point(657, 90);
            this.bookinglocationlbl.Name = "bookinglocationlbl";
            this.bookinglocationlbl.Size = new System.Drawing.Size(171, 23);
            this.bookinglocationlbl.TabIndex = 124;
            this.bookinglocationlbl.Text = "BOOKING LOCATION";
            // 
            // bookinglocationtxtbox
            // 
            this.bookinglocationtxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookinglocationtxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bookinglocationtxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.bookinglocationtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookinglocationtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookinglocationtxtbox.Location = new System.Drawing.Point(848, 85);
            this.bookinglocationtxtbox.Name = "bookinglocationtxtbox";
            this.bookinglocationtxtbox.Size = new System.Drawing.Size(360, 32);
            this.bookinglocationtxtbox.TabIndex = 125;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BookItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1296, 758);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "BookItem";
            this.Text = "Book An Item - Future Art Broadcast Trading LLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BookItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BookItem_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbookingitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.MaskedTextBox startdatetxtbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox enddatetxtbox;
        private System.Windows.Forms.Label enddatelbl;
        private System.Windows.Forms.Label startdatelbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvbookingitem;
        private System.Windows.Forms.RichTextBox importantnotestxtbox;
        private System.Windows.Forms.Label importantnoteslbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label selectwarehouselbl;
        private System.Windows.Forms.TextBox selectwarehousetxtbox;
        private System.Windows.Forms.Label bookinglocationlbl;
        private System.Windows.Forms.TextBox bookinglocationtxtbox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}