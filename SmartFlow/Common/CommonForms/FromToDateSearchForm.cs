using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class FromToDateSearchForm : Form
    {
        private string _hiddendata;
        public FromToDateSearchForm()
        {
            InitializeComponent();
        }
        public FromToDateSearchForm(string hidden)
        {
            InitializeComponent();
            this._hiddendata = hidden;
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (string.IsNullOrEmpty(invoicedatefromtxtbox.Text) && string.IsNullOrWhiteSpace(invoicedatefromtxtbox.Text))
                {
                    errorProvider.SetError(invoicedatefromtxtbox,"Please Enter Date From.");
                    invoicedatefromtxtbox.Focus();
                    return;
                }

                if(string.IsNullOrEmpty(invoicedatetotxtbox.Text) && string.IsNullOrWhiteSpace(invoicedatetotxtbox.Text))
                {
                    errorProvider.SetError(invoicedatetotxtbox,"Please Enter Date To");
                    invoicedatetotxtbox.Focus();
                    return;
                }

                if (radioButton1.Visible && radioButton2.Visible && radioButton3.Visible && radioButton4.Visible && radioButton5.Visible &&
                    radioButton6.Visible && radioButton7.Visible && radioButton8.Visible && radioButton9.Visible)
                {
                    if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked &&
                        !radioButton6.Checked && !radioButton7.Checked && !radioButton8.Checked && !radioButton9.Checked)
                    {
                        MessageBox.Show("Please Select One Option.");
                        return;
                    }
                }
                else if(radioButton1.Visible && radioButton2.Visible && radioButton3.Visible && radioButton4.Visible && radioButton5.Visible)
                {
                    if(!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked)
                    {
                        MessageBox.Show("Please Select One Option.");
                        return;
                    }
                }
                else if(radioButton1.Visible && radioButton2.Visible && radioButton3.Visible && radioButton4.Visible)
                {
                    if(!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
                    {
                        MessageBox.Show("Please Select One Option.");
                        return;
                    }
                }

                DateTime fromDate = DateTime.Parse(invoicedatefromtxtbox.Text);
                DateTime toDate = DateTime.Parse(invoicedatetotxtbox.Text);
                DataTable dtInvoiceData = null;

                if (radioButton1.Visible == true && radioButton1.Checked)
                {
                    if(radioButton1.Text == "PURCHASE QUOTATION")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE PATINDEX('PQ-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");

                    }
                    else if(radioButton1.Text == "SALES QUOTATION")
                    {
                       dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                       "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                       "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                       "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                       "WHERE PATINDEX('SQ-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                       "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton1.Text == "PAYMENT")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT TransactionId,InvoiceNo,Date,CurrencyName,ConversionRate,CreatedAt,CreatedDay FROM TransactionTable " +
                            "WHERE PATINDEX('PA-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND Date BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton1.Text == "STOCK LOCATION")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton2.Visible == true && radioButton2.Checked)
                {
                    if (radioButton2.Text == "LPO")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE PATINDEX('PO-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if (radioButton2.Text == "SALE ORDER")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE PATINDEX('SO-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton2.Text == "RECEIPT")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT TransactionId,InvoiceNo,Date,CurrencyName,ConversionRate,CreatedAt,CreatedDay FROM TransactionTable " +
                            "WHERE PATINDEX('RE-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND Date BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton2.Text == "STOCK TRANSFER")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton3.Visible == true && radioButton3.Checked)
                {
                    if(radioButton3.Text == "PURCHASE INVOICE")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE PATINDEX('PI-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton3.Text == "SALE INVOICE")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE InvoiceNo LIKE '_____' AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton3.Text == "JOURNAL")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT TransactionId,InvoiceNo,Date,CurrencyName,ConversionRate,CreatedAt,CreatedDay FROM TransactionTable " +
                            "WHERE PATINDEX('JO-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND Date BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton3.Text == "DAMAGE ENTRY")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton4.Visible == true && radioButton4.Checked)
                {
                    if(radioButton4.Text == "PURCHASE RETURN")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE PATINDEX('PR-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton4.Text == "SALE RETURN")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,UpdatedAt," +
                        "UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,TotalQty," +
                        "PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName," +
                        "IsTaxAble,QuotationValidUntill,InvoiceSpecialNote FROM InvoiceTable " +
                        "WHERE PATINDEX('SR-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND " +
                        "invoicedate BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton4.Text == "CREDIT NOTE")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT TransactionId,InvoiceNo,Date,CurrencyName,ConversionRate,CreatedAt,CreatedDay FROM TransactionTable " +
                            "WHERE PATINDEX('CR-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND Date BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if(radioButton4.Text == "OPEN BOX PRODUCT")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton5.Visible == true && radioButton5.Checked)
                {
                    if(radioButton5.Text == "DEBIT NOTE")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("SELECT TransactionId,InvoiceNo,Date,CurrencyName,ConversionRate,CreatedAt,CreatedDay FROM TransactionTable " +
                            "WHERE PATINDEX('DE-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]', InvoiceNo) > 0 AND Date BETWEEN '" + fromDate + "' AND '" + toDate + "'");
                    }
                    else if (radioButton5.Text == "USING SCANNER")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton6.Visible == true && radioButton6.Checked)
                {
                    if (radioButton6.Text == "USING MFR")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if (radioButton7.Visible == true && radioButton7.Checked)
                {
                    if(radioButton7.Text == "BOOKING ITEMS")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton8.Visible == true && radioButton8.Checked)
                {
                    if(radioButton8.Text == "PACKING LIST")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }
                else if(radioButton9.Visible == true && radioButton9.Checked)
                {
                    if(radioButton9.Text == "DELIVERY NOTE")
                    {
                        dtInvoiceData = DatabaseAccess.Retrive("");
                    }
                }

                dgvResult.DataSource = dtInvoiceData;

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void FromToDateSearchForm_Load(object sender, EventArgs e)
        {
            if(_hiddendata == "Purchase")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton1.Text = "PURCHASE QUOTATION";
                radioButton2.Text = "LPO";
                radioButton3.Text = "PURCHASE INVOICE";
                radioButton4.Text = "PURCHASE RETURN";
            }
            else if(_hiddendata == "Sale")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton1.Text = "SALES QUOTATION";
                radioButton2.Text = "SALE ORDER";
                radioButton3.Text = "SALE INVOICE";
                radioButton4.Text = "SALE RETURN";
            }
            else if(_hiddendata == "Transaction")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton1.Text = "PAYMENT";
                radioButton2.Text = "RECEIPT";
                radioButton3.Text = "JOURNAL";
                radioButton4.Text = "CREDIT NOTE";
                radioButton5.Text = "DEBIT NOTE";
            }
            else if( _hiddendata == "Stock")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
                radioButton7.Visible = true;
                radioButton8.Visible = true;
                radioButton9.Visible = true;
                radioButton1.Text = "STOCK LOCATION";
                radioButton2.Text = "STOCK TRANSFER";
                radioButton3.Text = "DAMAGE ENTRY";
                radioButton4.Text = "OPEN BOX PRODUCT";
                radioButton5.Text = "USING SCANNER";
                radioButton6.Text = "USING MFR";
                radioButton7.Text = "BOOKING ITEMS";
                radioButton8.Text = "PACKING LIST";
                radioButton9.Text = "DELIVERY NOTE";
            }

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            invoicedatefromtxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
