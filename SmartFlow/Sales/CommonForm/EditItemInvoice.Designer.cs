namespace SmartFlow.Sales.CommonForm
{
    partial class EditItemInvoice
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
            this.invoiceItemLbl = new System.Windows.Forms.Label();
            this.qtylbl = new System.Windows.Forms.Label();
            this.productidlbl = new System.Windows.Forms.Label();
            this.mfrlbl = new System.Windows.Forms.Label();
            this.pricelbl = new System.Windows.Forms.Label();
            this.vatpercentagelbl = new System.Windows.Forms.Label();
            this.discountlbl = new System.Windows.Forms.Label();
            this.selectunitlbl = new System.Windows.Forms.Label();
            this.lengthinmeterlbl = new System.Windows.Forms.Label();
            this.warehouseselectionlbl = new System.Windows.Forms.Label();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.qtytxtbox = new System.Windows.Forms.TextBox();
            this.pricetxtbox = new System.Windows.Forms.TextBox();
            this.vattxtbox = new System.Windows.Forms.TextBox();
            this.discounttxtbox = new System.Windows.Forms.TextBox();
            this.unitcombobox = new System.Windows.Forms.ComboBox();
            this.unitidlbl = new System.Windows.Forms.Label();
            this.warehouseidlbl = new System.Windows.Forms.Label();
            this.itemdescriptionlbl = new System.Windows.Forms.Label();
            this.itemdescriptiontxtbox = new System.Windows.Forms.RichTextBox();
            this.warehousecombo = new System.Windows.Forms.ComboBox();
            this.lengthinmetertxtbox = new System.Windows.Forms.TextBox();
            this.totalwithvatanddiscountlbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.percentageradio = new System.Windows.Forms.RadioButton();
            this.fixedamountradio = new System.Windows.Forms.RadioButton();
            this.savebtn = new System.Windows.Forms.Button();
            this.rowindexlbl = new System.Windows.Forms.Label();
            this.vatamountlbl = new System.Windows.Forms.Label();
            this.discountamtlbl = new System.Windows.Forms.Label();
            this.discounttypelbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.nodiscountradio = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.invoiceItemLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 37);
            this.panel1.TabIndex = 0;
            // 
            // invoiceItemLbl
            // 
            this.invoiceItemLbl.BackColor = System.Drawing.Color.Black;
            this.invoiceItemLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceItemLbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceItemLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.invoiceItemLbl.Location = new System.Drawing.Point(0, 0);
            this.invoiceItemLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.invoiceItemLbl.Name = "invoiceItemLbl";
            this.invoiceItemLbl.Size = new System.Drawing.Size(719, 37);
            this.invoiceItemLbl.TabIndex = 0;
            this.invoiceItemLbl.Text = "INVOICE ITEM";
            this.invoiceItemLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qtylbl
            // 
            this.qtylbl.AutoSize = true;
            this.qtylbl.Location = new System.Drawing.Point(9, 106);
            this.qtylbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qtylbl.Name = "qtylbl";
            this.qtylbl.Size = new System.Drawing.Size(62, 13);
            this.qtylbl.TabIndex = 1;
            this.qtylbl.Text = "QUANTITY";
            // 
            // productidlbl
            // 
            this.productidlbl.AutoSize = true;
            this.productidlbl.Location = new System.Drawing.Point(652, 273);
            this.productidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productidlbl.Name = "productidlbl";
            this.productidlbl.Size = new System.Drawing.Size(61, 13);
            this.productidlbl.TabIndex = 2;
            this.productidlbl.Text = "productidlbl";
            this.productidlbl.Visible = false;
            // 
            // mfrlbl
            // 
            this.mfrlbl.AutoSize = true;
            this.mfrlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.mfrlbl.ForeColor = System.Drawing.Color.Red;
            this.mfrlbl.Location = new System.Drawing.Point(9, 42);
            this.mfrlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mfrlbl.Name = "mfrlbl";
            this.mfrlbl.Size = new System.Drawing.Size(43, 19);
            this.mfrlbl.TabIndex = 3;
            this.mfrlbl.Text = "MFR ";
            // 
            // pricelbl
            // 
            this.pricelbl.AutoSize = true;
            this.pricelbl.Location = new System.Drawing.Point(9, 128);
            this.pricelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pricelbl.Name = "pricelbl";
            this.pricelbl.Size = new System.Drawing.Size(39, 13);
            this.pricelbl.TabIndex = 4;
            this.pricelbl.Text = "PRICE";
            // 
            // vatpercentagelbl
            // 
            this.vatpercentagelbl.AutoSize = true;
            this.vatpercentagelbl.Location = new System.Drawing.Point(9, 242);
            this.vatpercentagelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vatpercentagelbl.Name = "vatpercentagelbl";
            this.vatpercentagelbl.Size = new System.Drawing.Size(45, 13);
            this.vatpercentagelbl.TabIndex = 5;
            this.vatpercentagelbl.Text = "VAT (%)";
            // 
            // discountlbl
            // 
            this.discountlbl.AutoSize = true;
            this.discountlbl.Location = new System.Drawing.Point(9, 222);
            this.discountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discountlbl.Name = "discountlbl";
            this.discountlbl.Size = new System.Drawing.Size(63, 13);
            this.discountlbl.TabIndex = 6;
            this.discountlbl.Text = "DISCOUNT";
            // 
            // selectunitlbl
            // 
            this.selectunitlbl.AutoSize = true;
            this.selectunitlbl.Location = new System.Drawing.Point(376, 103);
            this.selectunitlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectunitlbl.Name = "selectunitlbl";
            this.selectunitlbl.Size = new System.Drawing.Size(77, 13);
            this.selectunitlbl.TabIndex = 8;
            this.selectunitlbl.Text = "SELECT UNIT";
            // 
            // lengthinmeterlbl
            // 
            this.lengthinmeterlbl.AutoSize = true;
            this.lengthinmeterlbl.Location = new System.Drawing.Point(9, 151);
            this.lengthinmeterlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lengthinmeterlbl.Name = "lengthinmeterlbl";
            this.lengthinmeterlbl.Size = new System.Drawing.Size(106, 13);
            this.lengthinmeterlbl.TabIndex = 9;
            this.lengthinmeterlbl.Text = "LENGTH IN METER";
            // 
            // warehouseselectionlbl
            // 
            this.warehouseselectionlbl.AutoSize = true;
            this.warehouseselectionlbl.Location = new System.Drawing.Point(376, 128);
            this.warehouseselectionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseselectionlbl.Name = "warehouseselectionlbl";
            this.warehouseselectionlbl.Size = new System.Drawing.Size(122, 13);
            this.warehouseselectionlbl.TabIndex = 10;
            this.warehouseselectionlbl.Text = "SELECT WAREHOUSE";
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionlbl.ForeColor = System.Drawing.Color.Red;
            this.descriptionlbl.Location = new System.Drawing.Point(9, 71);
            this.descriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(99, 19);
            this.descriptionlbl.TabIndex = 11;
            this.descriptionlbl.Text = "DESCRIPTION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(125, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "MFR ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(125, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "DESCRIPTION";
            // 
            // qtytxtbox
            // 
            this.qtytxtbox.Location = new System.Drawing.Point(155, 103);
            this.qtytxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.qtytxtbox.Name = "qtytxtbox";
            this.qtytxtbox.Size = new System.Drawing.Size(209, 20);
            this.qtytxtbox.TabIndex = 14;
            this.qtytxtbox.Leave += new System.EventHandler(this.qtytxtbox_Leave);
            // 
            // pricetxtbox
            // 
            this.pricetxtbox.Location = new System.Drawing.Point(155, 126);
            this.pricetxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.pricetxtbox.Name = "pricetxtbox";
            this.pricetxtbox.Size = new System.Drawing.Size(209, 20);
            this.pricetxtbox.TabIndex = 15;
            this.pricetxtbox.Leave += new System.EventHandler(this.pricetxtbox_Leave);
            // 
            // vattxtbox
            // 
            this.vattxtbox.Location = new System.Drawing.Point(155, 240);
            this.vattxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.vattxtbox.Name = "vattxtbox";
            this.vattxtbox.Size = new System.Drawing.Size(209, 20);
            this.vattxtbox.TabIndex = 16;
            this.vattxtbox.Leave += new System.EventHandler(this.vattxtbox_Leave);
            // 
            // discounttxtbox
            // 
            this.discounttxtbox.Location = new System.Drawing.Point(155, 217);
            this.discounttxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.discounttxtbox.Name = "discounttxtbox";
            this.discounttxtbox.Size = new System.Drawing.Size(209, 20);
            this.discounttxtbox.TabIndex = 17;
            this.discounttxtbox.Leave += new System.EventHandler(this.discounttxtbox_Leave);
            // 
            // unitcombobox
            // 
            this.unitcombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unitcombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unitcombobox.FormattingEnabled = true;
            this.unitcombobox.Location = new System.Drawing.Point(502, 99);
            this.unitcombobox.Margin = new System.Windows.Forms.Padding(2);
            this.unitcombobox.Name = "unitcombobox";
            this.unitcombobox.Size = new System.Drawing.Size(209, 21);
            this.unitcombobox.TabIndex = 18;
            this.unitcombobox.SelectedIndexChanged += new System.EventHandler(this.unitcombobox_SelectedIndexChanged);
            // 
            // unitidlbl
            // 
            this.unitidlbl.AutoSize = true;
            this.unitidlbl.Location = new System.Drawing.Point(609, 273);
            this.unitidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unitidlbl.Name = "unitidlbl";
            this.unitidlbl.Size = new System.Drawing.Size(42, 13);
            this.unitidlbl.TabIndex = 19;
            this.unitidlbl.Text = "unitidlbl";
            this.unitidlbl.Visible = false;
            // 
            // warehouseidlbl
            // 
            this.warehouseidlbl.AutoSize = true;
            this.warehouseidlbl.Location = new System.Drawing.Point(637, 286);
            this.warehouseidlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warehouseidlbl.Name = "warehouseidlbl";
            this.warehouseidlbl.Size = new System.Drawing.Size(77, 13);
            this.warehouseidlbl.TabIndex = 20;
            this.warehouseidlbl.Text = "warehouseidlbl";
            this.warehouseidlbl.Visible = false;
            // 
            // itemdescriptionlbl
            // 
            this.itemdescriptionlbl.AutoSize = true;
            this.itemdescriptionlbl.Location = new System.Drawing.Point(376, 150);
            this.itemdescriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.itemdescriptionlbl.Name = "itemdescriptionlbl";
            this.itemdescriptionlbl.Size = new System.Drawing.Size(109, 13);
            this.itemdescriptionlbl.TabIndex = 21;
            this.itemdescriptionlbl.Text = "ITEM DESCRIPTION";
            // 
            // itemdescriptiontxtbox
            // 
            this.itemdescriptiontxtbox.Location = new System.Drawing.Point(502, 148);
            this.itemdescriptiontxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.itemdescriptiontxtbox.Name = "itemdescriptiontxtbox";
            this.itemdescriptiontxtbox.Size = new System.Drawing.Size(209, 110);
            this.itemdescriptiontxtbox.TabIndex = 22;
            this.itemdescriptiontxtbox.Text = "";
            // 
            // warehousecombo
            // 
            this.warehousecombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.warehousecombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.warehousecombo.FormattingEnabled = true;
            this.warehousecombo.Location = new System.Drawing.Point(502, 124);
            this.warehousecombo.Margin = new System.Windows.Forms.Padding(2);
            this.warehousecombo.Name = "warehousecombo";
            this.warehousecombo.Size = new System.Drawing.Size(209, 21);
            this.warehousecombo.TabIndex = 23;
            // 
            // lengthinmetertxtbox
            // 
            this.lengthinmetertxtbox.Location = new System.Drawing.Point(155, 149);
            this.lengthinmetertxtbox.Margin = new System.Windows.Forms.Padding(2);
            this.lengthinmetertxtbox.Name = "lengthinmetertxtbox";
            this.lengthinmetertxtbox.Size = new System.Drawing.Size(209, 20);
            this.lengthinmetertxtbox.TabIndex = 24;
            // 
            // totalwithvatanddiscountlbl
            // 
            this.totalwithvatanddiscountlbl.AutoSize = true;
            this.totalwithvatanddiscountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalwithvatanddiscountlbl.ForeColor = System.Drawing.Color.Blue;
            this.totalwithvatanddiscountlbl.Location = new System.Drawing.Point(238, 338);
            this.totalwithvatanddiscountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalwithvatanddiscountlbl.Name = "totalwithvatanddiscountlbl";
            this.totalwithvatanddiscountlbl.Size = new System.Drawing.Size(201, 18);
            this.totalwithvatanddiscountlbl.TabIndex = 26;
            this.totalwithvatanddiscountlbl.Text = "totalwithvatanddiscountlbl";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 342);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(237, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "FINAL WITH VAT AND DISCOUNT AMOUNT : ";
            // 
            // percentageradio
            // 
            this.percentageradio.AutoSize = true;
            this.percentageradio.Location = new System.Drawing.Point(9, 193);
            this.percentageradio.Margin = new System.Windows.Forms.Padding(2);
            this.percentageradio.Name = "percentageradio";
            this.percentageradio.Size = new System.Drawing.Size(98, 17);
            this.percentageradio.TabIndex = 28;
            this.percentageradio.TabStop = true;
            this.percentageradio.Text = "PERCENTAGE";
            this.percentageradio.UseVisualStyleBackColor = true;
            this.percentageradio.CheckedChanged += new System.EventHandler(this.percentageradio_CheckedChanged);
            // 
            // fixedamountradio
            // 
            this.fixedamountradio.AutoSize = true;
            this.fixedamountradio.Location = new System.Drawing.Point(9, 172);
            this.fixedamountradio.Margin = new System.Windows.Forms.Padding(2);
            this.fixedamountradio.Name = "fixedamountradio";
            this.fixedamountradio.Size = new System.Drawing.Size(106, 17);
            this.fixedamountradio.TabIndex = 27;
            this.fixedamountradio.TabStop = true;
            this.fixedamountradio.Text = "FIXED AMOUNT";
            this.fixedamountradio.UseVisualStyleBackColor = true;
            this.fixedamountradio.CheckedChanged += new System.EventHandler(this.fixedamountradio_CheckedChanged);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(622, 325);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(88, 29);
            this.savebtn.TabIndex = 29;
            this.savebtn.Text = "SAVE";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // rowindexlbl
            // 
            this.rowindexlbl.AutoSize = true;
            this.rowindexlbl.Location = new System.Drawing.Point(655, 260);
            this.rowindexlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rowindexlbl.Name = "rowindexlbl";
            this.rowindexlbl.Size = new System.Drawing.Size(59, 13);
            this.rowindexlbl.TabIndex = 30;
            this.rowindexlbl.Text = "rowindexlbl";
            this.rowindexlbl.Visible = false;
            // 
            // vatamountlbl
            // 
            this.vatamountlbl.AutoSize = true;
            this.vatamountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatamountlbl.ForeColor = System.Drawing.Color.Blue;
            this.vatamountlbl.Location = new System.Drawing.Point(374, 238);
            this.vatamountlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vatamountlbl.Name = "vatamountlbl";
            this.vatamountlbl.Size = new System.Drawing.Size(103, 18);
            this.vatamountlbl.TabIndex = 32;
            this.vatamountlbl.Text = "vatamountlbl";
            // 
            // discountamtlbl
            // 
            this.discountamtlbl.AutoSize = true;
            this.discountamtlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountamtlbl.ForeColor = System.Drawing.Color.Blue;
            this.discountamtlbl.Location = new System.Drawing.Point(376, 218);
            this.discountamtlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discountamtlbl.Name = "discountamtlbl";
            this.discountamtlbl.Size = new System.Drawing.Size(117, 18);
            this.discountamtlbl.TabIndex = 33;
            this.discountamtlbl.Text = "discountamtlbl";
            // 
            // discounttypelbl
            // 
            this.discounttypelbl.AutoSize = true;
            this.discounttypelbl.Location = new System.Drawing.Point(499, 273);
            this.discounttypelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discounttypelbl.Name = "discounttypelbl";
            this.discounttypelbl.Size = new System.Drawing.Size(77, 13);
            this.discounttypelbl.TabIndex = 34;
            this.discounttypelbl.Text = "discounttypelbl";
            this.discounttypelbl.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // nodiscountradio
            // 
            this.nodiscountradio.AutoSize = true;
            this.nodiscountradio.Location = new System.Drawing.Point(155, 172);
            this.nodiscountradio.Margin = new System.Windows.Forms.Padding(2);
            this.nodiscountradio.Name = "nodiscountradio";
            this.nodiscountradio.Size = new System.Drawing.Size(100, 17);
            this.nodiscountradio.TabIndex = 35;
            this.nodiscountradio.TabStop = true;
            this.nodiscountradio.Text = "NO DISCOUNT";
            this.nodiscountradio.UseVisualStyleBackColor = true;
            this.nodiscountradio.CheckedChanged += new System.EventHandler(this.nodiscountradio_CheckedChanged);
            // 
            // EditItemInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 366);
            this.Controls.Add(this.nodiscountradio);
            this.Controls.Add(this.discounttypelbl);
            this.Controls.Add(this.discountamtlbl);
            this.Controls.Add(this.vatamountlbl);
            this.Controls.Add(this.rowindexlbl);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.percentageradio);
            this.Controls.Add(this.fixedamountradio);
            this.Controls.Add(this.totalwithvatanddiscountlbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lengthinmetertxtbox);
            this.Controls.Add(this.warehousecombo);
            this.Controls.Add(this.itemdescriptiontxtbox);
            this.Controls.Add(this.itemdescriptionlbl);
            this.Controls.Add(this.warehouseidlbl);
            this.Controls.Add(this.unitidlbl);
            this.Controls.Add(this.unitcombobox);
            this.Controls.Add(this.discounttxtbox);
            this.Controls.Add(this.vattxtbox);
            this.Controls.Add(this.pricetxtbox);
            this.Controls.Add(this.qtytxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionlbl);
            this.Controls.Add(this.warehouseselectionlbl);
            this.Controls.Add(this.lengthinmeterlbl);
            this.Controls.Add(this.selectunitlbl);
            this.Controls.Add(this.discountlbl);
            this.Controls.Add(this.vatpercentagelbl);
            this.Controls.Add(this.pricelbl);
            this.Controls.Add(this.mfrlbl);
            this.Controls.Add(this.productidlbl);
            this.Controls.Add(this.qtylbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditItemInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDIT ITEM INVOICE";
            this.Load += new System.EventHandler(this.EditItemInvoice_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label invoiceItemLbl;
        private System.Windows.Forms.Label qtylbl;
        private System.Windows.Forms.Label productidlbl;
        private System.Windows.Forms.Label mfrlbl;
        private System.Windows.Forms.Label pricelbl;
        private System.Windows.Forms.Label vatpercentagelbl;
        private System.Windows.Forms.Label discountlbl;
        private System.Windows.Forms.Label selectunitlbl;
        private System.Windows.Forms.Label lengthinmeterlbl;
        private System.Windows.Forms.Label warehouseselectionlbl;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox qtytxtbox;
        private System.Windows.Forms.TextBox pricetxtbox;
        private System.Windows.Forms.TextBox vattxtbox;
        private System.Windows.Forms.TextBox discounttxtbox;
        private System.Windows.Forms.ComboBox unitcombobox;
        private System.Windows.Forms.Label unitidlbl;
        private System.Windows.Forms.Label warehouseidlbl;
        private System.Windows.Forms.Label itemdescriptionlbl;
        private System.Windows.Forms.RichTextBox itemdescriptiontxtbox;
        private System.Windows.Forms.ComboBox warehousecombo;
        private System.Windows.Forms.TextBox lengthinmetertxtbox;
        private System.Windows.Forms.Label totalwithvatanddiscountlbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton percentageradio;
        private System.Windows.Forms.RadioButton fixedamountradio;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label rowindexlbl;
        private System.Windows.Forms.Label vatamountlbl;
        private System.Windows.Forms.Label discountamtlbl;
        private System.Windows.Forms.Label discounttypelbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton nodiscountradio;
    }
}