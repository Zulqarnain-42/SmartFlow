using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class FindSaleInvoiceForm : Form
    {
        public FindSaleInvoiceForm()
        {
            InitializeComponent();
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (invoicenotxtbox.Text.Trim().Length > 0)
                {
                    errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice No.");
                    invoicenotxtbox.Focus();
                    return;
                }

                if(invoicedatetxtbox.Text.Trim().Length > 0)
                {
                    errorProvider.SetError(invoicedatetxtbox,"Please Enter Invoice Date.");
                    invoicedatetxtbox.Focus();
                    return;
                }

                if (salequotationradio.Checked)
                {
                    string query = string.Format("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay," +
                        "UpdatedAt,UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount," +
                        "FreightShippingCharges,TotalQty,PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol," +
                        "ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName,IsTaxAble,QuotationValidUntill,InvoiceSpecialNote " +
                        "FROM InvoiceTable WHERE InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity," +
                            "UnitSalePrice,ItemSerialNo,ProductName,MFR,ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid," +
                            "PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice,PurchaseItemSalePrice,SystemSerialNo," +
                            "ItemTotal,Unitid,IncludeInventory,ProductCondition FROM InvoiceDetailsTable WHERE " +
                            "InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice(dataInvoice, dtInvoiceDetails);
                            saleQuotationInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (saleorderradio.Checked)
                {
                    string query = string.Format("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay," +
                        "UpdatedAt,UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount," +
                        "FreightShippingCharges,TotalQty,PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol," +
                        "ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName,IsTaxAble,QuotationValidUntill,InvoiceSpecialNote " +
                        "FROM InvoiceTable WHERE InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity," +
                            "UnitSalePrice,ItemSerialNo,ProductName,MFR,ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid," +
                            "PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice,PurchaseItemSalePrice,SystemSerialNo," +
                            "ItemTotal,Unitid,IncludeInventory,ProductCondition FROM InvoiceDetailsTable WHERE " +
                            "InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();

                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (saleinvoiceradio.Checked)
                {
                    string query = string.Format("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay," +
                        "UpdatedAt,UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount," +
                        "FreightShippingCharges,TotalQty,PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol," +
                        "ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName,IsTaxAble,QuotationValidUntill,InvoiceSpecialNote " +
                        "FROM InvoiceTable WHERE InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity," +
                            "UnitSalePrice,ItemSerialNo,ProductName,MFR,ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid," +
                            "PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice,PurchaseItemSalePrice,SystemSerialNo," +
                            "ItemTotal,Unitid,IncludeInventory,ProductCondition FROM InvoiceDetailsTable WHERE " +
                            "InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleInvoice saleInvoice = new SaleInvoice(dataInvoice, dtInvoiceDetails);
                            saleInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if(salereturnradio.Checked)
                {
                    string query = string.Format("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay," +
                        "UpdatedAt,UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount," +
                        "FreightShippingCharges,TotalQty,PurchaseInvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,CurrencySymbol," +
                        "ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName,IsTaxAble,QuotationValidUntill,InvoiceSpecialNote " +
                        "FROM InvoiceTable WHERE InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity," +
                            "UnitSalePrice,ItemSerialNo,ProductName,MFR,ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid," +
                            "PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice,PurchaseItemSalePrice,SystemSerialNo," +
                            "ItemTotal,Unitid,IncludeInventory,ProductCondition FROM InvoiceDetailsTable WHERE " +
                            "InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleReturnInvoice saleReturnInvoice = new SaleReturnInvoice(dataInvoice,dtInvoiceDetails);
                            saleReturnInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else
                {
                    MessageBox.Show("Select One Sale Type.");
                }
                

            }catch (Exception ex) { throw ex; }
        }
        private void FindSaleInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (salequotationradio.Checked) { return true; }
            if (saleorderradio.Checked) { return true; }
            if (saleinvoiceradio.Checked) { return true; }
            if (salereturnradio.Checked) { return true; }
            return false; // No TextBox is filled
        }
        private void FindSaleInvoiceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }

        private void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            string userinput = invoicenotxtbox.Text;
            if (userinput.Length > 0) 
            {
                DataTable invoiceData = DatabaseAccess.Retrive("SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo LIKE '" + userinput + "'");
                if(invoiceData.Rows.Count > 0)
                {
                    DataRow row = invoiceData.Rows[0];
                    invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                }
            }

            string saleqPattern = @"^SQ-\d{6}-\d{5}$";
            string saleoPattern = @"^SO-\d{6}-\d{5}$";
            string salerPattern = @"^SR-\d{6}-\d{5}$";
            string saleiPattern = @"^\d{5}$";

            if (Regex.IsMatch(userinput, saleqPattern))
            {
                salequotationradio.Checked = true;
            }
            else if (Regex.IsMatch(userinput, saleoPattern))
            {
                saleorderradio.Checked = true;
            }
            else if (Regex.IsMatch(userinput, saleiPattern))
            {
                saleinvoiceradio.Checked = true;
            }
            else if (Regex.IsMatch(userinput, salerPattern))
            {
                salereturnradio.Checked = true;
            }
            else
            {
                MessageBox.Show("INVOICE NOT EXIST");
            }
        }
    }
}
