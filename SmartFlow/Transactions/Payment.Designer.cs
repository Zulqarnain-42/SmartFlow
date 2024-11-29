namespace SmartFlow.Transactions
{
    partial class Payment
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.datelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.longdescriptiontxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.serialnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitcreditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcodecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdebitcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iscreditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortnarationcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.currencyconversionratelbl = new System.Windows.Forms.Label();
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencyidlbl = new System.Windows.Forms.Label();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.amounttxtbox = new System.Windows.Forms.TextBox();
            this.amountlbl = new System.Windows.Forms.Label();
            this.accountnametxtbox = new System.Windows.Forms.TextBox();
            this.accountcodetxtbox = new System.Windows.Forms.TextBox();
            this.accountcodeandname = new System.Windows.Forms.Label();
            this.paymentvoucheridlbl = new System.Windows.Forms.Label();
            this.transactioncodelbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // closebtn
            // 
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(1410, 13);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(127, 39);
            this.closebtn.TabIndex = 3;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1543, 13);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(127, 39);
            this.savebtn.TabIndex = 2;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Enabled = false;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(461, 54);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(609, 32);
            this.invoicenotxtbox.TabIndex = 20;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(359, 58);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(96, 23);
            this.invoicenolbl.TabIndex = 17;
            this.invoicenolbl.Text = "Invoice No ";
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(16, 58);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(50, 23);
            this.datelbl.TabIndex = 16;
            this.datelbl.Text = "Date ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Controls.Add(this.closebtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 706);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1682, 64);
            this.panel2.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1371, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 586);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VOUCHER INFO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.longdescriptiontxtbox);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1353, 121);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LONG NARRATION";
            // 
            // longdescriptiontxtbox
            // 
            this.longdescriptiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.longdescriptiontxtbox.Location = new System.Drawing.Point(7, 22);
            this.longdescriptiontxtbox.Multiline = true;
            this.longdescriptiontxtbox.Name = "longdescriptiontxtbox";
            this.longdescriptiontxtbox.Size = new System.Drawing.Size(1340, 93);
            this.longdescriptiontxtbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(928, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1074, 549);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1231, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "( CURRENCY : AED )";
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToAddRows = false;
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AllowUserToResizeColumns = false;
            this.dgvPayment.AllowUserToResizeRows = false;
            this.dgvPayment.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialnocolumn,
            this.debitcreditcolumn,
            this.accountcolumn,
            this.accountcodecolumn,
            this.accountidcolumn,
            this.isdebitcolumn,
            this.iscreditcolumn,
            this.debitcolumn,
            this.creditcolumn,
            this.shortnarationcolumn});
            this.dgvPayment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPayment.Location = new System.Drawing.Point(16, 168);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersVisible = false;
            this.dgvPayment.RowHeadersWidth = 51;
            this.dgvPayment.RowTemplate.Height = 24;
            this.dgvPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayment.Size = new System.Drawing.Size(1349, 360);
            this.dgvPayment.TabIndex = 53;
            this.dgvPayment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayment_CellDoubleClick);
            // 
            // serialnocolumn
            // 
            this.serialnocolumn.HeaderText = "#";
            this.serialnocolumn.MinimumWidth = 6;
            this.serialnocolumn.Name = "serialnocolumn";
            this.serialnocolumn.Width = 50;
            // 
            // debitcreditcolumn
            // 
            this.debitcreditcolumn.HeaderText = "D/C";
            this.debitcreditcolumn.MinimumWidth = 6;
            this.debitcreditcolumn.Name = "debitcreditcolumn";
            this.debitcreditcolumn.Width = 50;
            // 
            // accountcolumn
            // 
            this.accountcolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountcolumn.HeaderText = "ACCOUNT NAME";
            this.accountcolumn.MinimumWidth = 6;
            this.accountcolumn.Name = "accountcolumn";
            // 
            // accountcodecolumn
            // 
            this.accountcodecolumn.HeaderText = "Account Code";
            this.accountcodecolumn.MinimumWidth = 6;
            this.accountcodecolumn.Name = "accountcodecolumn";
            this.accountcodecolumn.Visible = false;
            this.accountcodecolumn.Width = 125;
            // 
            // accountidcolumn
            // 
            this.accountidcolumn.HeaderText = "Account Id";
            this.accountidcolumn.MinimumWidth = 6;
            this.accountidcolumn.Name = "accountidcolumn";
            this.accountidcolumn.Visible = false;
            this.accountidcolumn.Width = 125;
            // 
            // isdebitcolumn
            // 
            this.isdebitcolumn.HeaderText = "Is Debit";
            this.isdebitcolumn.MinimumWidth = 6;
            this.isdebitcolumn.Name = "isdebitcolumn";
            this.isdebitcolumn.Visible = false;
            this.isdebitcolumn.Width = 125;
            // 
            // iscreditcolumn
            // 
            this.iscreditcolumn.HeaderText = "Is Credit";
            this.iscreditcolumn.MinimumWidth = 6;
            this.iscreditcolumn.Name = "iscreditcolumn";
            this.iscreditcolumn.Visible = false;
            this.iscreditcolumn.Width = 125;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1682, 45);
            this.panel1.TabIndex = 54;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(1682, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "PAYMENT VOUCHER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(166, 54);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(187, 32);
            this.invoicedatetxtbox.TabIndex = 113;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // currencyconversionratelbl
            // 
            this.currencyconversionratelbl.AutoSize = true;
            this.currencyconversionratelbl.Location = new System.Drawing.Point(1076, 119);
            this.currencyconversionratelbl.Name = "currencyconversionratelbl";
            this.currencyconversionratelbl.Size = new System.Drawing.Size(161, 16);
            this.currencyconversionratelbl.TabIndex = 149;
            this.currencyconversionratelbl.Text = "currencyconversionratelbl";
            this.currencyconversionratelbl.Visible = false;
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Location = new System.Drawing.Point(1076, 103);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(116, 16);
            this.currencysymbollbl.TabIndex = 148;
            this.currencysymbollbl.Text = "currencysymbollbl";
            this.currencysymbollbl.Visible = false;
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Location = new System.Drawing.Point(1076, 87);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(106, 16);
            this.currencynamelbl.TabIndex = 147;
            this.currencynamelbl.Text = "currencynamelbl";
            this.currencynamelbl.Visible = false;
            // 
            // currencyidlbl
            // 
            this.currencyidlbl.AutoSize = true;
            this.currencyidlbl.Location = new System.Drawing.Point(1076, 70);
            this.currencyidlbl.Name = "currencyidlbl";
            this.currencyidlbl.Size = new System.Drawing.Size(83, 16);
            this.currencyidlbl.TabIndex = 146;
            this.currencyidlbl.Text = "currencyidlbl";
            this.currencyidlbl.Visible = false;
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(1076, 54);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(79, 16);
            this.accountidlbl.TabIndex = 145;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // amounttxtbox
            // 
            this.amounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amounttxtbox.Location = new System.Drawing.Point(166, 130);
            this.amounttxtbox.Name = "amounttxtbox";
            this.amounttxtbox.Size = new System.Drawing.Size(904, 32);
            this.amounttxtbox.TabIndex = 156;
            this.amounttxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amounttxtbox.Leave += new System.EventHandler(this.amounttxtbox_Leave);
            // 
            // amountlbl
            // 
            this.amountlbl.AutoSize = true;
            this.amountlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountlbl.Location = new System.Drawing.Point(16, 134);
            this.amountlbl.Name = "amountlbl";
            this.amountlbl.Size = new System.Drawing.Size(72, 23);
            this.amountlbl.TabIndex = 155;
            this.amountlbl.Text = "Amount";
            // 
            // accountnametxtbox
            // 
            this.accountnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnametxtbox.Location = new System.Drawing.Point(359, 92);
            this.accountnametxtbox.Name = "accountnametxtbox";
            this.accountnametxtbox.Size = new System.Drawing.Size(711, 32);
            this.accountnametxtbox.TabIndex = 154;
            this.accountnametxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.accountnametxtbox_MouseClick);
            this.accountnametxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.accountnametxtbox_KeyDown);
            this.accountnametxtbox.Leave += new System.EventHandler(this.accountnametxtbox_Leave);
            // 
            // accountcodetxtbox
            // 
            this.accountcodetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountcodetxtbox.Enabled = false;
            this.accountcodetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountcodetxtbox.Location = new System.Drawing.Point(166, 92);
            this.accountcodetxtbox.Name = "accountcodetxtbox";
            this.accountcodetxtbox.Size = new System.Drawing.Size(187, 32);
            this.accountcodetxtbox.TabIndex = 153;
            // 
            // accountcodeandname
            // 
            this.accountcodeandname.AutoSize = true;
            this.accountcodeandname.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountcodeandname.Location = new System.Drawing.Point(16, 96);
            this.accountcodeandname.Name = "accountcodeandname";
            this.accountcodeandname.Size = new System.Drawing.Size(137, 23);
            this.accountcodeandname.TabIndex = 152;
            this.accountcodeandname.Text = "Acc. Code/Name";
            // 
            // paymentvoucheridlbl
            // 
            this.paymentvoucheridlbl.AutoSize = true;
            this.paymentvoucheridlbl.Location = new System.Drawing.Point(1079, 139);
            this.paymentvoucheridlbl.Name = "paymentvoucheridlbl";
            this.paymentvoucheridlbl.Size = new System.Drawing.Size(132, 16);
            this.paymentvoucheridlbl.TabIndex = 157;
            this.paymentvoucheridlbl.Text = "paymentvoucheridlbl";
            this.paymentvoucheridlbl.Visible = false;
            // 
            // transactioncodelbl
            // 
            this.transactioncodelbl.AutoSize = true;
            this.transactioncodelbl.Location = new System.Drawing.Point(1167, 54);
            this.transactioncodelbl.Name = "transactioncodelbl";
            this.transactioncodelbl.Size = new System.Drawing.Size(117, 16);
            this.transactioncodelbl.TabIndex = 158;
            this.transactioncodelbl.Text = "transactioncodelbl";
            this.transactioncodelbl.Visible = false;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1682, 770);
            this.Controls.Add(this.transactioncodelbl);
            this.Controls.Add(this.paymentvoucheridlbl);
            this.Controls.Add(this.amounttxtbox);
            this.Controls.Add(this.amountlbl);
            this.Controls.Add(this.accountnametxtbox);
            this.Controls.Add(this.accountcodetxtbox);
            this.Controls.Add(this.accountcodeandname);
            this.Controls.Add(this.currencyconversionratelbl);
            this.Controls.Add(this.currencysymbollbl);
            this.Controls.Add(this.currencynamelbl);
            this.Controls.Add(this.currencyidlbl);
            this.Controls.Add(this.accountidlbl);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPayment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.invoicenolbl);
            this.Controls.Add(this.datelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAYMENT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Payment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Payment_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox longdescriptiontxtbox;
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Label currencyconversionratelbl;
        private System.Windows.Forms.Label currencysymbollbl;
        private System.Windows.Forms.Label currencynamelbl;
        private System.Windows.Forms.Label currencyidlbl;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.TextBox amounttxtbox;
        private System.Windows.Forms.Label amountlbl;
        private System.Windows.Forms.TextBox accountnametxtbox;
        private System.Windows.Forms.TextBox accountcodetxtbox;
        private System.Windows.Forms.Label accountcodeandname;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialnocolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitcreditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcodecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isdebitcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iscreditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortnarationcolumn;
        private System.Windows.Forms.Label paymentvoucheridlbl;
        private System.Windows.Forms.Label transactioncodelbl;
    }
}