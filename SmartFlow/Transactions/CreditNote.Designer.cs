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
            this.headinglbl = new System.Windows.Forms.Label();
            this.shortnarationcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditamountradio = new System.Windows.Forms.RadioButton();
            this.shortnarationtxtbox = new System.Windows.Forms.TextBox();
            this.narationlbl = new System.Windows.Forms.Label();
            this.totalcreditvaluelbl = new System.Windows.Forms.Label();
            this.totaldebitvaluelbl = new System.Windows.Forms.Label();
            this.totalcreditlbl = new System.Windows.Forms.Label();
            this.totaldebitlbl = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.accountheadidlbl = new System.Windows.Forms.Label();
            this.currencylbl = new System.Windows.Forms.Label();
            this.cashradiobtn = new System.Windows.Forms.RadioButton();
            this.bankaccountradio = new System.Windows.Forms.RadioButton();
            this.voucherinfolbl = new System.Windows.Forms.Label();
            this.voucherinfotxtbox = new System.Windows.Forms.RichTextBox();
            this.paymentvoucheridlbl = new System.Windows.Forms.Label();
            this.amounttxtbox = new System.Windows.Forms.TextBox();
            this.amountlbl = new System.Windows.Forms.Label();
            this.accountnametxtbox = new System.Windows.Forms.TextBox();
            this.accountcodetxtbox = new System.Windows.Forms.TextBox();
            this.accountcodeandname = new System.Windows.Forms.Label();
            this.accountidlbl = new System.Windows.Forms.Label();
            this.invoicedatetxtbox = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.creditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.savebtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currencyconversionratelbl = new System.Windows.Forms.Label();
            this.currencyidlbl = new System.Windows.Forms.Label();
            this.currencynamelbl = new System.Windows.Forms.Label();
            this.currencystringlbl = new System.Windows.Forms.Label();
            this.currencysymbollbl = new System.Windows.Forms.Label();
            this.transactionidlbl = new System.Windows.Forms.Label();
            this.transactioncodelbl = new System.Windows.Forms.Label();
            this.invoicenotxtbox = new System.Windows.Forms.TextBox();
            this.invoicenolbl = new System.Windows.Forms.Label();
            this.datelbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.longdescriptiontxtbox = new System.Windows.Forms.TextBox();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.serialnocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitcreditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcodecolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountidcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdebitcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iscreditcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitamountradio = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
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
            this.headinglbl.Size = new System.Drawing.Size(1262, 37);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "CREDIT NOTE VOUCHER";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shortnarationcolumn
            // 
            this.shortnarationcolumn.HeaderText = "SHORT NARATION";
            this.shortnarationcolumn.Name = "shortnarationcolumn";
            this.shortnarationcolumn.ReadOnly = true;
            this.shortnarationcolumn.Width = 135;
            // 
            // creditamountradio
            // 
            this.creditamountradio.AutoSize = true;
            this.creditamountradio.Location = new System.Drawing.Point(808, 70);
            this.creditamountradio.Name = "creditamountradio";
            this.creditamountradio.Size = new System.Drawing.Size(115, 17);
            this.creditamountradio.TabIndex = 210;
            this.creditamountradio.Text = "CREDIT AMOUNT";
            this.creditamountradio.UseVisualStyleBackColor = true;
            // 
            // shortnarationtxtbox
            // 
            this.shortnarationtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shortnarationtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortnarationtxtbox.Location = new System.Drawing.Point(125, 137);
            this.shortnarationtxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.shortnarationtxtbox.Name = "shortnarationtxtbox";
            this.shortnarationtxtbox.Size = new System.Drawing.Size(678, 27);
            this.shortnarationtxtbox.TabIndex = 185;
            // 
            // narationlbl
            // 
            this.narationlbl.AutoSize = true;
            this.narationlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.narationlbl.Location = new System.Drawing.Point(13, 140);
            this.narationlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.narationlbl.Name = "narationlbl";
            this.narationlbl.Size = new System.Drawing.Size(74, 18);
            this.narationlbl.TabIndex = 208;
            this.narationlbl.Text = "NARATION";
            // 
            // totalcreditvaluelbl
            // 
            this.totalcreditvaluelbl.AutoSize = true;
            this.totalcreditvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totalcreditvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totalcreditvaluelbl.Location = new System.Drawing.Point(824, 534);
            this.totalcreditvaluelbl.Name = "totalcreditvaluelbl";
            this.totalcreditvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totalcreditvaluelbl.TabIndex = 207;
            this.totalcreditvaluelbl.Text = "0.0";
            // 
            // totaldebitvaluelbl
            // 
            this.totaldebitvaluelbl.AutoSize = true;
            this.totaldebitvaluelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.totaldebitvaluelbl.ForeColor = System.Drawing.Color.Blue;
            this.totaldebitvaluelbl.Location = new System.Drawing.Point(824, 508);
            this.totaldebitvaluelbl.Name = "totaldebitvaluelbl";
            this.totaldebitvaluelbl.Size = new System.Drawing.Size(31, 18);
            this.totaldebitvaluelbl.TabIndex = 206;
            this.totaldebitvaluelbl.Text = "0.0";
            // 
            // totalcreditlbl
            // 
            this.totalcreditlbl.AutoSize = true;
            this.totalcreditlbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcreditlbl.Location = new System.Drawing.Point(720, 535);
            this.totalcreditlbl.Name = "totalcreditlbl";
            this.totalcreditlbl.Size = new System.Drawing.Size(89, 17);
            this.totalcreditlbl.TabIndex = 205;
            this.totalcreditlbl.Text = "TOTAL CREDIT";
            // 
            // totaldebitlbl
            // 
            this.totaldebitlbl.AutoSize = true;
            this.totaldebitlbl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.totaldebitlbl.Location = new System.Drawing.Point(720, 509);
            this.totaldebitlbl.Name = "totaldebitlbl";
            this.totaldebitlbl.Size = new System.Drawing.Size(82, 17);
            this.totaldebitlbl.TabIndex = 204;
            this.totaldebitlbl.Text = "TOTAL DEBIT";
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(808, 137);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(85, 27);
            this.addbtn.TabIndex = 186;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = true;
            // 
            // accountheadidlbl
            // 
            this.accountheadidlbl.AutoSize = true;
            this.accountheadidlbl.Location = new System.Drawing.Point(1016, 58);
            this.accountheadidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountheadidlbl.Name = "accountheadidlbl";
            this.accountheadidlbl.Size = new System.Drawing.Size(88, 13);
            this.accountheadidlbl.TabIndex = 203;
            this.accountheadidlbl.Text = "accountheadidlbl";
            this.accountheadidlbl.Visible = false;
            // 
            // currencylbl
            // 
            this.currencylbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currencylbl.AutoSize = true;
            this.currencylbl.Location = new System.Drawing.Point(1130, 43);
            this.currencylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencylbl.Name = "currencylbl";
            this.currencylbl.Size = new System.Drawing.Size(98, 13);
            this.currencylbl.TabIndex = 202;
            this.currencylbl.Text = "CURRENCY : AED";
            // 
            // cashradiobtn
            // 
            this.cashradiobtn.AutoSize = true;
            this.cashradiobtn.Location = new System.Drawing.Point(1133, 107);
            this.cashradiobtn.Margin = new System.Windows.Forms.Padding(2);
            this.cashradiobtn.Name = "cashradiobtn";
            this.cashradiobtn.Size = new System.Drawing.Size(54, 17);
            this.cashradiobtn.TabIndex = 201;
            this.cashradiobtn.Text = "CASH";
            this.cashradiobtn.UseVisualStyleBackColor = true;
            this.cashradiobtn.Visible = false;
            // 
            // bankaccountradio
            // 
            this.bankaccountradio.AutoSize = true;
            this.bankaccountradio.Location = new System.Drawing.Point(1133, 85);
            this.bankaccountradio.Margin = new System.Windows.Forms.Padding(2);
            this.bankaccountradio.Name = "bankaccountradio";
            this.bankaccountradio.Size = new System.Drawing.Size(109, 17);
            this.bankaccountradio.TabIndex = 200;
            this.bankaccountradio.Text = "BANK ACCOUNT";
            this.bankaccountradio.UseVisualStyleBackColor = true;
            this.bankaccountradio.Visible = false;
            // 
            // voucherinfolbl
            // 
            this.voucherinfolbl.AutoSize = true;
            this.voucherinfolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucherinfolbl.Location = new System.Drawing.Point(1025, 162);
            this.voucherinfolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.voucherinfolbl.Name = "voucherinfolbl";
            this.voucherinfolbl.Size = new System.Drawing.Size(87, 18);
            this.voucherinfolbl.TabIndex = 199;
            this.voucherinfolbl.Text = "Voucher Info";
            // 
            // voucherinfotxtbox
            // 
            this.voucherinfotxtbox.Location = new System.Drawing.Point(1028, 182);
            this.voucherinfotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.voucherinfotxtbox.Name = "voucherinfotxtbox";
            this.voucherinfotxtbox.Size = new System.Drawing.Size(225, 460);
            this.voucherinfotxtbox.TabIndex = 187;
            this.voucherinfotxtbox.Text = "";
            // 
            // paymentvoucheridlbl
            // 
            this.paymentvoucheridlbl.AutoSize = true;
            this.paymentvoucheridlbl.Location = new System.Drawing.Point(1016, 75);
            this.paymentvoucheridlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paymentvoucheridlbl.Name = "paymentvoucheridlbl";
            this.paymentvoucheridlbl.Size = new System.Drawing.Size(104, 13);
            this.paymentvoucheridlbl.TabIndex = 198;
            this.paymentvoucheridlbl.Text = "paymentvoucheridlbl";
            this.paymentvoucheridlbl.Visible = false;
            // 
            // amounttxtbox
            // 
            this.amounttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amounttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amounttxtbox.Location = new System.Drawing.Point(124, 106);
            this.amounttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.amounttxtbox.Name = "amounttxtbox";
            this.amounttxtbox.Size = new System.Drawing.Size(678, 27);
            this.amounttxtbox.TabIndex = 184;
            this.amounttxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amountlbl
            // 
            this.amountlbl.AutoSize = true;
            this.amountlbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountlbl.Location = new System.Drawing.Point(12, 109);
            this.amountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amountlbl.Name = "amountlbl";
            this.amountlbl.Size = new System.Drawing.Size(58, 18);
            this.amountlbl.TabIndex = 197;
            this.amountlbl.Text = "Amount";
            // 
            // accountnametxtbox
            // 
            this.accountnametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountnametxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnametxtbox.Location = new System.Drawing.Point(269, 75);
            this.accountnametxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.accountnametxtbox.Name = "accountnametxtbox";
            this.accountnametxtbox.Size = new System.Drawing.Size(534, 27);
            this.accountnametxtbox.TabIndex = 183;
            // 
            // accountcodetxtbox
            // 
            this.accountcodetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountcodetxtbox.Enabled = false;
            this.accountcodetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountcodetxtbox.Location = new System.Drawing.Point(124, 75);
            this.accountcodetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.accountcodetxtbox.Name = "accountcodetxtbox";
            this.accountcodetxtbox.Size = new System.Drawing.Size(141, 27);
            this.accountcodetxtbox.TabIndex = 196;
            // 
            // accountcodeandname
            // 
            this.accountcodeandname.AutoSize = true;
            this.accountcodeandname.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountcodeandname.Location = new System.Drawing.Point(12, 78);
            this.accountcodeandname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountcodeandname.Name = "accountcodeandname";
            this.accountcodeandname.Size = new System.Drawing.Size(111, 18);
            this.accountcodeandname.TabIndex = 195;
            this.accountcodeandname.Text = "Acc. Code/Name";
            // 
            // accountidlbl
            // 
            this.accountidlbl.AutoSize = true;
            this.accountidlbl.Location = new System.Drawing.Point(1016, 43);
            this.accountidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountidlbl.Name = "accountidlbl";
            this.accountidlbl.Size = new System.Drawing.Size(64, 13);
            this.accountidlbl.TabIndex = 194;
            this.accountidlbl.Text = "accountidlbl";
            this.accountidlbl.Visible = false;
            // 
            // invoicedatetxtbox
            // 
            this.invoicedatetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicedatetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicedatetxtbox.Location = new System.Drawing.Point(124, 44);
            this.invoicedatetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicedatetxtbox.Mask = "00/00/0000";
            this.invoicedatetxtbox.Name = "invoicedatetxtbox";
            this.invoicedatetxtbox.Size = new System.Drawing.Size(141, 27);
            this.invoicedatetxtbox.TabIndex = 181;
            this.invoicedatetxtbox.ValidatingType = typeof(System.DateTime);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 37);
            this.panel1.TabIndex = 193;
            // 
            // creditcolumn
            // 
            this.creditcolumn.HeaderText = "CREDIT";
            this.creditcolumn.MinimumWidth = 6;
            this.creditcolumn.Name = "creditcolumn";
            this.creditcolumn.ReadOnly = true;
            this.creditcolumn.Width = 125;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // savebtn
            // 
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(1157, 11);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(95, 32);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            // 
            // closebtn
            // 
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(1058, 11);
            this.closebtn.Margin = new System.Windows.Forms.Padding(2);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(95, 32);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.currencyconversionratelbl);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Controls.Add(this.closebtn);
            this.panel2.Controls.Add(this.currencyidlbl);
            this.panel2.Controls.Add(this.currencynamelbl);
            this.panel2.Controls.Add(this.currencystringlbl);
            this.panel2.Controls.Add(this.currencysymbollbl);
            this.panel2.Controls.Add(this.transactionidlbl);
            this.panel2.Controls.Add(this.transactioncodelbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 650);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 52);
            this.panel2.TabIndex = 190;
            // 
            // currencyconversionratelbl
            // 
            this.currencyconversionratelbl.AutoSize = true;
            this.currencyconversionratelbl.Location = new System.Drawing.Point(345, 11);
            this.currencyconversionratelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencyconversionratelbl.Name = "currencyconversionratelbl";
            this.currencyconversionratelbl.Size = new System.Drawing.Size(128, 13);
            this.currencyconversionratelbl.TabIndex = 171;
            this.currencyconversionratelbl.Text = "currencyconversionratelbl";
            this.currencyconversionratelbl.Visible = false;
            // 
            // currencyidlbl
            // 
            this.currencyidlbl.AutoSize = true;
            this.currencyidlbl.Location = new System.Drawing.Point(6, 11);
            this.currencyidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencyidlbl.Name = "currencyidlbl";
            this.currencyidlbl.Size = new System.Drawing.Size(66, 13);
            this.currencyidlbl.TabIndex = 167;
            this.currencyidlbl.Text = "currencyidlbl";
            this.currencyidlbl.Visible = false;
            // 
            // currencynamelbl
            // 
            this.currencynamelbl.AutoSize = true;
            this.currencynamelbl.Location = new System.Drawing.Point(76, 11);
            this.currencynamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencynamelbl.Name = "currencynamelbl";
            this.currencynamelbl.Size = new System.Drawing.Size(84, 13);
            this.currencynamelbl.TabIndex = 170;
            this.currencynamelbl.Text = "currencynamelbl";
            this.currencynamelbl.Visible = false;
            // 
            // currencystringlbl
            // 
            this.currencystringlbl.AutoSize = true;
            this.currencystringlbl.Location = new System.Drawing.Point(164, 11);
            this.currencystringlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencystringlbl.Name = "currencystringlbl";
            this.currencystringlbl.Size = new System.Drawing.Size(83, 13);
            this.currencystringlbl.TabIndex = 169;
            this.currencystringlbl.Text = "currencystringlbl";
            this.currencystringlbl.Visible = false;
            // 
            // currencysymbollbl
            // 
            this.currencysymbollbl.AutoSize = true;
            this.currencysymbollbl.Location = new System.Drawing.Point(251, 11);
            this.currencysymbollbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencysymbollbl.Name = "currencysymbollbl";
            this.currencysymbollbl.Size = new System.Drawing.Size(90, 13);
            this.currencysymbollbl.TabIndex = 168;
            this.currencysymbollbl.Text = "currencysymbollbl";
            this.currencysymbollbl.Visible = false;
            // 
            // transactionidlbl
            // 
            this.transactionidlbl.AutoSize = true;
            this.transactionidlbl.Location = new System.Drawing.Point(817, 11);
            this.transactionidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.transactionidlbl.Name = "transactionidlbl";
            this.transactionidlbl.Size = new System.Drawing.Size(77, 13);
            this.transactionidlbl.TabIndex = 163;
            this.transactionidlbl.Text = "transactionidlbl";
            this.transactionidlbl.Visible = false;
            // 
            // transactioncodelbl
            // 
            this.transactioncodelbl.AutoSize = true;
            this.transactioncodelbl.Location = new System.Drawing.Point(898, 11);
            this.transactioncodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.transactioncodelbl.Name = "transactioncodelbl";
            this.transactioncodelbl.Size = new System.Drawing.Size(93, 13);
            this.transactioncodelbl.TabIndex = 158;
            this.transactioncodelbl.Text = "transactioncodelbl";
            this.transactioncodelbl.Visible = false;
            // 
            // invoicenotxtbox
            // 
            this.invoicenotxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicenotxtbox.Enabled = false;
            this.invoicenotxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenotxtbox.Location = new System.Drawing.Point(346, 44);
            this.invoicenotxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.invoicenotxtbox.Name = "invoicenotxtbox";
            this.invoicenotxtbox.Size = new System.Drawing.Size(457, 27);
            this.invoicenotxtbox.TabIndex = 182;
            // 
            // invoicenolbl
            // 
            this.invoicenolbl.AutoSize = true;
            this.invoicenolbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicenolbl.Location = new System.Drawing.Point(269, 47);
            this.invoicenolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.invoicenolbl.Name = "invoicenolbl";
            this.invoicenolbl.Size = new System.Drawing.Size(77, 18);
            this.invoicenolbl.TabIndex = 189;
            this.invoicenolbl.Text = "Invoice No ";
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelbl.Location = new System.Drawing.Point(12, 47);
            this.datelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(40, 18);
            this.datelbl.TabIndex = 188;
            this.datelbl.Text = "Date ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.longdescriptiontxtbox);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 548);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1015, 98);
            this.groupBox2.TabIndex = 191;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LONG NARRATION";
            // 
            // longdescriptiontxtbox
            // 
            this.longdescriptiontxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.longdescriptiontxtbox.Location = new System.Drawing.Point(5, 18);
            this.longdescriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.longdescriptiontxtbox.Multiline = true;
            this.longdescriptiontxtbox.Name = "longdescriptiontxtbox";
            this.longdescriptiontxtbox.Size = new System.Drawing.Size(1006, 76);
            this.longdescriptiontxtbox.TabIndex = 0;
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
            this.dgvPayment.Location = new System.Drawing.Point(12, 182);
            this.dgvPayment.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.ReadOnly = true;
            this.dgvPayment.RowHeadersVisible = false;
            this.dgvPayment.RowHeadersWidth = 51;
            this.dgvPayment.RowTemplate.Height = 24;
            this.dgvPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayment.Size = new System.Drawing.Size(1012, 325);
            this.dgvPayment.TabIndex = 192;
            // 
            // serialnocolumn
            // 
            this.serialnocolumn.HeaderText = "#";
            this.serialnocolumn.MinimumWidth = 6;
            this.serialnocolumn.Name = "serialnocolumn";
            this.serialnocolumn.ReadOnly = true;
            this.serialnocolumn.Width = 50;
            // 
            // debitcreditcolumn
            // 
            this.debitcreditcolumn.HeaderText = "D/C";
            this.debitcreditcolumn.MinimumWidth = 6;
            this.debitcreditcolumn.Name = "debitcreditcolumn";
            this.debitcreditcolumn.ReadOnly = true;
            this.debitcreditcolumn.Width = 50;
            // 
            // accountcolumn
            // 
            this.accountcolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountcolumn.HeaderText = "ACCOUNT NAME";
            this.accountcolumn.MinimumWidth = 6;
            this.accountcolumn.Name = "accountcolumn";
            this.accountcolumn.ReadOnly = true;
            // 
            // accountcodecolumn
            // 
            this.accountcodecolumn.HeaderText = "Account Code";
            this.accountcodecolumn.MinimumWidth = 6;
            this.accountcodecolumn.Name = "accountcodecolumn";
            this.accountcodecolumn.ReadOnly = true;
            this.accountcodecolumn.Visible = false;
            this.accountcodecolumn.Width = 125;
            // 
            // accountidcolumn
            // 
            this.accountidcolumn.HeaderText = "Account Id";
            this.accountidcolumn.MinimumWidth = 6;
            this.accountidcolumn.Name = "accountidcolumn";
            this.accountidcolumn.ReadOnly = true;
            this.accountidcolumn.Visible = false;
            this.accountidcolumn.Width = 125;
            // 
            // isdebitcolumn
            // 
            this.isdebitcolumn.HeaderText = "Is Debit";
            this.isdebitcolumn.MinimumWidth = 6;
            this.isdebitcolumn.Name = "isdebitcolumn";
            this.isdebitcolumn.ReadOnly = true;
            this.isdebitcolumn.Visible = false;
            this.isdebitcolumn.Width = 125;
            // 
            // iscreditcolumn
            // 
            this.iscreditcolumn.HeaderText = "Is Credit";
            this.iscreditcolumn.MinimumWidth = 6;
            this.iscreditcolumn.Name = "iscreditcolumn";
            this.iscreditcolumn.ReadOnly = true;
            this.iscreditcolumn.Visible = false;
            this.iscreditcolumn.Width = 125;
            // 
            // debitcolumn
            // 
            this.debitcolumn.HeaderText = "DEBIT";
            this.debitcolumn.MinimumWidth = 6;
            this.debitcolumn.Name = "debitcolumn";
            this.debitcolumn.ReadOnly = true;
            this.debitcolumn.Width = 125;
            // 
            // debitamountradio
            // 
            this.debitamountradio.AutoSize = true;
            this.debitamountradio.Checked = true;
            this.debitamountradio.Location = new System.Drawing.Point(808, 47);
            this.debitamountradio.Name = "debitamountradio";
            this.debitamountradio.Size = new System.Drawing.Size(107, 17);
            this.debitamountradio.TabIndex = 209;
            this.debitamountradio.TabStop = true;
            this.debitamountradio.Text = "DEBIT AMOUNT";
            this.debitamountradio.UseVisualStyleBackColor = true;
            // 
            // CreditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 702);
            this.Controls.Add(this.creditamountradio);
            this.Controls.Add(this.shortnarationtxtbox);
            this.Controls.Add(this.narationlbl);
            this.Controls.Add(this.totalcreditvaluelbl);
            this.Controls.Add(this.totaldebitvaluelbl);
            this.Controls.Add(this.totalcreditlbl);
            this.Controls.Add(this.totaldebitlbl);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.accountheadidlbl);
            this.Controls.Add(this.currencylbl);
            this.Controls.Add(this.cashradiobtn);
            this.Controls.Add(this.bankaccountradio);
            this.Controls.Add(this.voucherinfolbl);
            this.Controls.Add(this.voucherinfotxtbox);
            this.Controls.Add(this.paymentvoucheridlbl);
            this.Controls.Add(this.amounttxtbox);
            this.Controls.Add(this.amountlbl);
            this.Controls.Add(this.accountnametxtbox);
            this.Controls.Add(this.accountcodetxtbox);
            this.Controls.Add(this.accountcodeandname);
            this.Controls.Add(this.accountidlbl);
            this.Controls.Add(this.invoicedatetxtbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.invoicenotxtbox);
            this.Controls.Add(this.invoicenolbl);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvPayment);
            this.Controls.Add(this.debitamountradio);
            this.Name = "CreditNote";
            this.Text = "CREDIT NOTE VOUCHER";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortnarationcolumn;
        private System.Windows.Forms.RadioButton creditamountradio;
        private System.Windows.Forms.TextBox shortnarationtxtbox;
        private System.Windows.Forms.Label narationlbl;
        private System.Windows.Forms.Label totalcreditvaluelbl;
        private System.Windows.Forms.Label totaldebitvaluelbl;
        private System.Windows.Forms.Label totalcreditlbl;
        private System.Windows.Forms.Label totaldebitlbl;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Label accountheadidlbl;
        private System.Windows.Forms.Label currencylbl;
        private System.Windows.Forms.RadioButton cashradiobtn;
        private System.Windows.Forms.RadioButton bankaccountradio;
        private System.Windows.Forms.Label voucherinfolbl;
        private System.Windows.Forms.RichTextBox voucherinfotxtbox;
        private System.Windows.Forms.Label paymentvoucheridlbl;
        private System.Windows.Forms.TextBox amounttxtbox;
        private System.Windows.Forms.Label amountlbl;
        private System.Windows.Forms.TextBox accountnametxtbox;
        private System.Windows.Forms.TextBox accountcodetxtbox;
        private System.Windows.Forms.Label accountcodeandname;
        private System.Windows.Forms.Label accountidlbl;
        private System.Windows.Forms.MaskedTextBox invoicedatetxtbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditcolumn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label currencyconversionratelbl;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label currencyidlbl;
        private System.Windows.Forms.Label currencynamelbl;
        private System.Windows.Forms.Label currencystringlbl;
        private System.Windows.Forms.Label currencysymbollbl;
        private System.Windows.Forms.Label transactionidlbl;
        private System.Windows.Forms.Label transactioncodelbl;
        private System.Windows.Forms.TextBox invoicenotxtbox;
        private System.Windows.Forms.Label invoicenolbl;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox longdescriptiontxtbox;
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialnocolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitcreditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcodecolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountidcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isdebitcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iscreditcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitcolumn;
        private System.Windows.Forms.RadioButton debitamountradio;
    }
}