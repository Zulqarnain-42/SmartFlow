using SmartFlow.Masters;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class FindPurchaseInvoiceForm : Form
    {
        public FindPurchaseInvoiceForm()
        {
            InitializeComponent();
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice No");
                    invoicenotxtbox.Focus();
                    return;
                }

                if (purchasequoteradio.Checked)
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
                        if(dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice(dataInvoice,dtInvoiceDetails);
                            purchaseQuotationInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (lporadio.Checked)
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
                            PurchaseOrder purchaseOrder = new PurchaseOrder(dataInvoice, dtInvoiceDetails);
                            purchaseOrder.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (purchaseinvoiceradio.Checked) 
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
                            PurchaseInvoice purchaseInvoice = new PurchaseInvoice(dataInvoice, dtInvoiceDetails);
                            purchaseInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (purchasereturnradio.Checked)
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
                            PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice(dataInvoice, dtInvoiceDetails);
                            purchaseReturnInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else
                {
                    MessageBox.Show("Select Purchase Type Radio");
                }
            }catch (Exception ex) { throw ex; }
        }
        private void FindPurchaseInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicenotxtbox.Focus();
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (purchasequoteradio.Checked) { return true; }
            if (lporadio.Checked) { return true; }
            if (purchaseinvoiceradio.Checked) { return true; }
            if (purchasereturnradio.Checked) { return true; }
            return false; // No TextBox is filled
        }
        private void FindPurchaseInvoiceForm_KeyDown(object sender, KeyEventArgs e)
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
            string userInput = invoicenotxtbox.Text;
            if (userInput.Length > 0)
            {
                DataTable invoiceDate = DatabaseAccess.Retrive("SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo LIKE '" + userInput + "'");
                if(invoiceDate != null && invoiceDate.Rows.Count > 0)
                {
                    DataRow row = invoiceDate.Rows[0];
                    invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                }
            }

            string piPattern = @"^PI-\d{6}-\d{5}$";
            string pqPattern = @"^PQ-\d{6}-\d{5}$";
            string poPattern = @"^PO-\d{6}-\d{5}$";
            string prPattern = @"^PR-\d{6}-\d{5}$";

            if (Regex.IsMatch(userInput, pqPattern))
            {
                purchasequoteradio.Checked = true;
            }
            else if (Regex.IsMatch(userInput, poPattern))
            {
                lporadio.Checked = true;
            }
            else if (Regex.IsMatch(userInput, piPattern))
            {
                purchaseinvoiceradio.Checked = true;
            }
            else if (Regex.IsMatch(userInput, prPattern))
            {
                purchasereturnradio.Checked = true;
            }
            else
            {
                MessageBox.Show("INVOICE NOT EXIST");
            }
        }
    }
}
