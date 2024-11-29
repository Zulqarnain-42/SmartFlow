namespace SmartFlow.Reports
{
    partial class ItemWiseInventoyReport
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
            this.itemselectionlbl = new System.Windows.Forms.Label();
            this.itemselectiontxtbox = new System.Windows.Forms.TextBox();
            this.invoicedatetotxtbox = new System.Windows.Forms.MaskedTextBox();
            this.invoicedatefromtxtbox = new System.Windows.Forms.MaskedTextBox();
            this.tolbl = new System.Windows.Forms.Label();
            this.fromlbl = new System.Windows.Forms.Label();
            this.searchbtn = new System.Windows.Forms.Button();
            this.productidlbl = new System.Windows.Forms.Label();
            this.mfrtxtbox = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // itemselectionlbl
            // 
            this.itemselectionlbl.AutoSize = true;
            this.itemselectionlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemselectionlbl.Location = new System.Drawing.Point(71, 82);
            this.itemselectionlbl.Name = "itemselectionlbl";
            this.itemselectionlbl.Size = new System.Drawing.Size(115, 24);
            this.itemselectionlbl.TabIndex = 0;
            this.itemselectionlbl.Text = "SELECT ITEM";
            // 
            // itemselectiontxtbox
            // 
            this.itemselectiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemselectiontxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemselectiontxtbox.Location = new System.Drawing.Point(210, 76);
            this.itemselectiontxtbox.Name = "itemselectiontxtbox";
            this.itemselectiontxtbox.Size = new System.Drawing.Size(455, 32);
            this.itemselectiontxtbox.TabIndex = 1;
            this.itemselectiontxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemselectiontxtbox_MouseClick);
            // 
            // invoicedatetotxtbox
            // 
            this.invoicedatetotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetotxtbox.Location = new System.Drawing.Point(210, 152);
            this.invoicedatetotxtbox.Mask = "00/00/0000";
            this.invoicedatetotxtbox.Name = "invoicedatetotxtbox";
            this.invoicedatetotxtbox.Size = new System.Drawing.Size(455, 32);
            this.invoicedatetotxtbox.TabIndex = 117;
            this.invoicedatetotxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // invoicedatefromtxtbox
            // 
            this.invoicedatefromtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatefromtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatefromtxtbox.Location = new System.Drawing.Point(210, 114);
            this.invoicedatefromtxtbox.Mask = "00/00/0000";
            this.invoicedatefromtxtbox.Name = "invoicedatefromtxtbox";
            this.invoicedatefromtxtbox.Size = new System.Drawing.Size(455, 32);
            this.invoicedatefromtxtbox.TabIndex = 116;
            this.invoicedatefromtxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // tolbl
            // 
            this.tolbl.AutoSize = true;
            this.tolbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolbl.Location = new System.Drawing.Point(71, 154);
            this.tolbl.Name = "tolbl";
            this.tolbl.Size = new System.Drawing.Size(32, 24);
            this.tolbl.TabIndex = 115;
            this.tolbl.Text = "TO";
            // 
            // fromlbl
            // 
            this.fromlbl.AutoSize = true;
            this.fromlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromlbl.Location = new System.Drawing.Point(71, 116);
            this.fromlbl.Name = "fromlbl";
            this.fromlbl.Size = new System.Drawing.Size(60, 24);
            this.fromlbl.TabIndex = 114;
            this.fromlbl.Text = "FROM";
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(210, 190);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(455, 42);
            this.searchbtn.TabIndex = 118;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(72, 242);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(77, 16);
            this.productidlbl.TabIndex = 119;
            this.productidlbl.Text = "productidlbl";
            this.productidlbl.Visible = false;
            // 
            // mfrtxtbox
            // 
            this.mfrtxtbox.AutoSize = true;
            this.mfrtxtbox.Location = new System.Drawing.Point(180, 242);
            this.mfrtxtbox.Name = "mfrtxtbox";
            this.mfrtxtbox.Size = new System.Drawing.Size(59, 16);
            this.mfrtxtbox.TabIndex = 120;
            this.mfrtxtbox.Text = "mfrtxtbox";
            this.mfrtxtbox.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ItemWiseInventoyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 282);
            this.Controls.Add(this.mfrtxtbox);
            this.Controls.Add(this.productidlbl);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.invoicedatetotxtbox);
            this.Controls.Add(this.invoicedatefromtxtbox);
            this.Controls.Add(this.tolbl);
            this.Controls.Add(this.fromlbl);
            this.Controls.Add(this.itemselectiontxtbox);
            this.Controls.Add(this.itemselectionlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemWiseInventoyReport";
            this.Text = "ITEM WISE INVENTORY";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemselectionlbl;
        private System.Windows.Forms.TextBox itemselectiontxtbox;
        private System.Windows.Forms.MaskedTextBox invoicedatetotxtbox;
        private System.Windows.Forms.MaskedTextBox invoicedatefromtxtbox;
        private System.Windows.Forms.Label tolbl;
        private System.Windows.Forms.Label fromlbl;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Label mfrtxtbox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}