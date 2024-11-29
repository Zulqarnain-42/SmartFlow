namespace SmartFlow.Stock
{
    partial class StockManageForm
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
            this.searchrecordlbl = new System.Windows.Forms.Label();
            this.searchlbl = new System.Windows.Forms.Label();
            this.searchbtn = new System.Windows.Forms.Button();
            this.searchtxtbox = new System.Windows.Forms.TextBox();
            this.searchdataGridView = new System.Windows.Forms.DataGridView();
            this.saleinvoiceradio = new System.Windows.Forms.RadioButton();
            this.salereturnradio = new System.Windows.Forms.RadioButton();
            this.revisedradio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.searchdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchrecordlbl
            // 
            this.searchrecordlbl.AutoSize = true;
            this.searchrecordlbl.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchrecordlbl.Location = new System.Drawing.Point(15, 106);
            this.searchrecordlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchrecordlbl.Name = "searchrecordlbl";
            this.searchrecordlbl.Size = new System.Drawing.Size(188, 23);
            this.searchrecordlbl.TabIndex = 11;
            this.searchrecordlbl.Text = "Total Searched Record";
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(15, 35);
            this.searchlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(125, 23);
            this.searchlbl.TabIndex = 10;
            this.searchlbl.Text = "Search Invoice";
            // 
            // searchbtn
            // 
            this.searchbtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.Location = new System.Drawing.Point(622, 61);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(113, 32);
            this.searchbtn.TabIndex = 8;
            this.searchbtn.Text = "Search";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // searchtxtbox
            // 
            this.searchtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbox.Location = new System.Drawing.Point(14, 61);
            this.searchtxtbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchtxtbox.Name = "searchtxtbox";
            this.searchtxtbox.Size = new System.Drawing.Size(603, 29);
            this.searchtxtbox.TabIndex = 7;
            // 
            // searchdataGridView
            // 
            this.searchdataGridView.AllowUserToAddRows = false;
            this.searchdataGridView.AllowUserToDeleteRows = false;
            this.searchdataGridView.AllowUserToResizeColumns = false;
            this.searchdataGridView.AllowUserToResizeRows = false;
            this.searchdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchdataGridView.Location = new System.Drawing.Point(15, 148);
            this.searchdataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.searchdataGridView.Name = "searchdataGridView";
            this.searchdataGridView.ReadOnly = true;
            this.searchdataGridView.RowHeadersWidth = 51;
            this.searchdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchdataGridView.Size = new System.Drawing.Size(972, 208);
            this.searchdataGridView.TabIndex = 9;
            this.searchdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchdataGridView_CellClick);
            // 
            // saleinvoiceradio
            // 
            this.saleinvoiceradio.AutoSize = true;
            this.saleinvoiceradio.Location = new System.Drawing.Point(776, 37);
            this.saleinvoiceradio.Name = "saleinvoiceradio";
            this.saleinvoiceradio.Size = new System.Drawing.Size(118, 20);
            this.saleinvoiceradio.TabIndex = 12;
            this.saleinvoiceradio.TabStop = true;
            this.saleinvoiceradio.Text = "SALE INVOICE";
            this.saleinvoiceradio.UseVisualStyleBackColor = true;
            // 
            // salereturnradio
            // 
            this.salereturnradio.AutoSize = true;
            this.salereturnradio.Location = new System.Drawing.Point(776, 67);
            this.salereturnradio.Name = "salereturnradio";
            this.salereturnradio.Size = new System.Drawing.Size(123, 20);
            this.salereturnradio.TabIndex = 13;
            this.salereturnradio.TabStop = true;
            this.salereturnradio.Text = "SALE RETURN";
            this.salereturnradio.UseVisualStyleBackColor = true;
            // 
            // revisedradio
            // 
            this.revisedradio.AutoSize = true;
            this.revisedradio.Location = new System.Drawing.Point(776, 94);
            this.revisedradio.Name = "revisedradio";
            this.revisedradio.Size = new System.Drawing.Size(124, 20);
            this.revisedradio.TabIndex = 14;
            this.revisedradio.TabStop = true;
            this.revisedradio.Text = "SALE REVISED";
            this.revisedradio.UseVisualStyleBackColor = true;
            // 
            // StockManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 391);
            this.Controls.Add(this.revisedradio);
            this.Controls.Add(this.salereturnradio);
            this.Controls.Add(this.saleinvoiceradio);
            this.Controls.Add(this.searchrecordlbl);
            this.Controls.Add(this.searchlbl);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.searchtxtbox);
            this.Controls.Add(this.searchdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StockManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK MANAGEMENT";
            ((System.ComponentModel.ISupportInitialize)(this.searchdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label searchrecordlbl;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.TextBox searchtxtbox;
        private System.Windows.Forms.DataGridView searchdataGridView;
        private System.Windows.Forms.RadioButton saleinvoiceradio;
        private System.Windows.Forms.RadioButton salereturnradio;
        private System.Windows.Forms.RadioButton revisedradio;
    }
}