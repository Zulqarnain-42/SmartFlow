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

                if(radioButton1.Visible && radioButton2.Visible && radioButton3.Visible && radioButton4.Visible)
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
                }

                dgvResult.DataSource = dtInvoiceData;

            }catch (Exception ex) { throw ex; }
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
            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            invoicedatefromtxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
