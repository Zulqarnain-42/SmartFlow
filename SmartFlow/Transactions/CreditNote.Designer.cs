namespace SmartFlow.Transactions
{
    partial class CreditNote
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
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCreditNote = new System.Windows.Forms.DataGridView();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.datelbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.srnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitcreditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortnarationcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditNote)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(81, 51);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(187, 32);
            this.invoicedatetxtbox.TabIndex = 125;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1412, 45);
            this.panel1.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1412, 45);
            this.label4.TabIndex = 0;
            this.label4.Text = "CREDIT NOTE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(967, 527);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 122;
            this.label3.Text = "( CURRENCY : AED )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(798, 527);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 121;
            this.label2.Text = "0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 120;
            this.label1.Text = "0.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 567);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1089, 121);
            this.groupBox2.TabIndex = 119;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LONG NARRATION";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(7, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1077, 93);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1107, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 586);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VOUCHER INFO";
            // 
            // dgvCreditNote
            // 
            this.dgvCreditNote.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCreditNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srnocolumn,
            this.debitcreditcolumn,
            this.accountcolumn,
            this.debitcolumn,
            this.creditcolumn,
            this.shortnarationcolumn});
            this.dgvCreditNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCreditNote.Location = new System.Drawing.Point(19, 99);
            this.dgvCreditNote.Name = "dgvCreditNote";
            this.dgvCreditNote.RowHeadersVisible = false;
            this.dgvCreditNote.RowHeadersWidth = 51;
            this.dgvCreditNote.RowTemplate.Height = 24;
            this.dgvCreditNote.Size = new System.Drawing.Size(1082, 425);
            this.dgvCreditNote.TabIndex = 123;
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Enabled = false;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(369, 51);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(590, 32);
            this.invoicenotxtbox.TabIndex = 117;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(274, 56);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(96, 23);
            this.invoicenolbl.TabIndex = 116;
            this.invoicenolbl.Text = "Invoice No ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Controls.Add(this.closebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 706);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1412, 64);
            this.panel2.TabIndex = 114;
            // 
            // savebtn
            // 
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1273, 13);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(127, 39);
            this.savebtn.TabIndex = 2;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            // 
            // closebtn
            // 
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(1140, 13);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(127, 39);
            this.closebtn.TabIndex = 3;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(17, 56);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(50, 23);
            this.datelbl.TabIndex = 115;
            this.datelbl.Text = "Date ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // srnocolumn
            // 
            this.srnocolumn.HeaderText = "#";
            this.srnocolumn.MinimumWidth = 6;
            this.srnocolumn.Name = "srnocolumn";
            this.srnocolumn.Width = 125;
            // 
            // debitcreditcolumn
            // 
            this.debitcreditcolumn.HeaderText = "D/C";
            this.debitcreditcolumn.MinimumWidth = 6;
            this.debitcreditcolumn.Name = "debitcreditcolumn";
            this.debitcreditcolumn.Width = 125;
            // 
            // accountcolumn
            // 
            this.accountcolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountcolumn.HeaderText = "ACCOUNT NAME";
            this.accountcolumn.MinimumWidth = 6;
            this.accountcolumn.Name = "accountcolumn";
            // 
            // debitcolumn
            // 
            this.debitcolumn.HeaderText = "DEBIT";
            this.debitcolumn.MinimumWidth = 6;
            this.debitcolumn.Name = "debitcolumn";
            this.debitcolumn.Width = 125;
            // 
            // creditcolumn
            // 
            this.creditcolumn.HeaderText = "CREDIT";
            this.creditcolumn.MinimumWidth = 6;
            this.creditcolumn.Name = "creditcolumn";
            this.creditcolumn.Width = 125;
            // 
            // shortnarationcolumn
            // 
            this.shortnarationcolumn.HeaderText = "SHORT NARATION";
            this.shortnarationcolumn.MinimumWidth = 6;
            this.shortnarationcolumn.Name = "shortnarationcolumn";
            this.shortnarationcolumn.Width = 200;
            // 
            // CreditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1412, 770);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCreditNote);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.invoicenolbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.datelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "CreditNote";
            this.Text = "CreditNote";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreditNote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreditNote_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditNote)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCreditNote;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnocolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitcreditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortnarationcolumn;
    }
}