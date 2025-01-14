using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
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
                // Check if the invoice number TextBox is empty
                if (string.IsNullOrWhiteSpace(invoicenotxtbox.Text))
                {
                    errorProvider.SetError(invoicenotxtbox, "Please enter an invoice number.");
                    invoicenotxtbox.Focus();
                    return;
                }

                if (salequotationradio.Checked)
                {
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.Invoicecode," +
                            "InvoiceDetailsTable.Productid, InvoiceDetailsTable.Quantity, InvoiceDetailsTable.UnitSalePrice, InvoiceDetailsTable.ItemSerialNoid," +
                            "InvoiceDetailsTable.ProductName, InvoiceDetailsTable.MFR, InvoiceDetailsTable.ItemWiseDiscount, InvoiceDetailsTable.ItemWiseVAT," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PurchaseCostPrice, InvoiceDetailsTable.PurchaseLowestSalePrice," +
                            "InvoiceDetailsTable.PurchaseStandardPrice, InvoiceDetailsTable.PurchaseItemSalePrice, InvoiceDetailsTable.SystemSerialNoid," +
                            "InvoiceDetailsTable.ItemTotal, InvoiceDetailsTable.Unitid, InvoiceDetailsTable.AddInventory, InvoiceDetailsTable.ItemAvailability," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PricePerMeter, InvoiceDetailsTable.LengthInMeter, InvoiceDetailsTable.ItemDescription," +
                            "InvoiceDetailsTable.MinusInventory, UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                            "InvoiceDetailsTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice(dataInvoice, dtInvoiceDetails);
                            saleQuotationInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(saleQuotationInvoice);
                            saleQuotationInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (proformainvoicebtn.Checked)
                {
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.Invoicecode," +
                            "InvoiceDetailsTable.Productid, InvoiceDetailsTable.Quantity, InvoiceDetailsTable.UnitSalePrice, InvoiceDetailsTable.ItemSerialNoid," +
                            "InvoiceDetailsTable.ProductName, InvoiceDetailsTable.MFR, InvoiceDetailsTable.ItemWiseDiscount, InvoiceDetailsTable.ItemWiseVAT," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PurchaseCostPrice, InvoiceDetailsTable.PurchaseLowestSalePrice," +
                            "InvoiceDetailsTable.PurchaseStandardPrice, InvoiceDetailsTable.PurchaseItemSalePrice, InvoiceDetailsTable.SystemSerialNoid," +
                            "InvoiceDetailsTable.ItemTotal, InvoiceDetailsTable.Unitid, InvoiceDetailsTable.AddInventory, InvoiceDetailsTable.ItemAvailability," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PricePerMeter, InvoiceDetailsTable.LengthInMeter, InvoiceDetailsTable.ItemDescription," +
                            "InvoiceDetailsTable.MinusInventory, UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                            "InvoiceDetailsTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleInvoice saleInvoice = new SaleInvoice(dataInvoice, dtInvoiceDetails);
                            saleInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(saleInvoice);
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
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.Invoicecode," +
                            "InvoiceDetailsTable.Productid, InvoiceDetailsTable.Quantity, InvoiceDetailsTable.UnitSalePrice, InvoiceDetailsTable.ItemSerialNoid," +
                            "InvoiceDetailsTable.ProductName, InvoiceDetailsTable.MFR, InvoiceDetailsTable.ItemWiseDiscount, InvoiceDetailsTable.ItemWiseVAT," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PurchaseCostPrice, InvoiceDetailsTable.PurchaseLowestSalePrice," +
                            "InvoiceDetailsTable.PurchaseStandardPrice, InvoiceDetailsTable.PurchaseItemSalePrice, InvoiceDetailsTable.SystemSerialNoid," +
                            "InvoiceDetailsTable.ItemTotal, InvoiceDetailsTable.Unitid, InvoiceDetailsTable.AddInventory, InvoiceDetailsTable.ItemAvailability," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PricePerMeter, InvoiceDetailsTable.LengthInMeter, InvoiceDetailsTable.ItemDescription," +
                            "InvoiceDetailsTable.MinusInventory, UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                            "InvoiceDetailsTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleReturnInvoice saleReturnInvoice = new SaleReturnInvoice(dataInvoice,dtInvoiceDetails);
                            saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(saleReturnInvoice);
                            saleReturnInvoice.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else if (proformainvoicebtn.Checked)
                {
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = DatabaseAccess.Retrive(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.Invoicecode," +
                            "InvoiceDetailsTable.Productid, InvoiceDetailsTable.Quantity, InvoiceDetailsTable.UnitSalePrice, InvoiceDetailsTable.ItemSerialNoid," +
                            "InvoiceDetailsTable.ProductName, InvoiceDetailsTable.MFR, InvoiceDetailsTable.ItemWiseDiscount, InvoiceDetailsTable.ItemWiseVAT," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PurchaseCostPrice, InvoiceDetailsTable.PurchaseLowestSalePrice," +
                            "InvoiceDetailsTable.PurchaseStandardPrice, InvoiceDetailsTable.PurchaseItemSalePrice, InvoiceDetailsTable.SystemSerialNoid," +
                            "InvoiceDetailsTable.ItemTotal, InvoiceDetailsTable.Unitid, InvoiceDetailsTable.AddInventory, InvoiceDetailsTable.ItemAvailability," +
                            "InvoiceDetailsTable.Warehouseid, InvoiceDetailsTable.PricePerMeter, InvoiceDetailsTable.LengthInMeter, InvoiceDetailsTable.ItemDescription," +
                            "InvoiceDetailsTable.MinusInventory, UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                            "InvoiceDetailsTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                        DataTable dtInvoiceDetails = DatabaseAccess.Retrive(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            SaleReturnInvoice saleReturnInvoice = new SaleReturnInvoice(dataInvoice, dtInvoiceDetails);
                            saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(saleReturnInvoice);
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
                

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void FindSaleInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (salequotationradio.Checked) { return true; }
            if (proformainvoicebtn.Checked) { return true; }
            if (salereturnradio.Checked) { return true; }
            return false; // No TextBox is filled
        }
        private void FindSaleInvoiceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                try
                {
                    if (AreAnyTextBoxesFilled()) // Check if any text boxes are filled
                    {
                        DialogResult result = MessageBox.Show(
                            "There are unsaved changes. Do you really want to close?",
                            "Confirm Close",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                e.Handled = true;
            }
        }

        private void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string userinput = invoicenotxtbox.Text.Trim();

                // Validate if user input is not empty
                if (userinput.Length > 0)
                {
                    // Using parameterized query to avoid SQL injection
                    string query = "SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo = @InvoiceNo";
                    var parameters = new Dictionary<string, object>
        {
            { "@InvoiceNo", userinput }
        };

                    DataTable invoiceData = DatabaseAccess.Retrive(query, parameters);

                    if (invoiceData.Rows.Count > 0)
                    {
                        DataRow row = invoiceData.Rows[0];
                        invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        MessageBox.Show("Invoice not found.");
                    }

                    // Validate user input format for different invoice types using regex
                    string saleqPattern = @"^SQ-\d{6}-\d{5}$";
                    string salerPattern = @"^SR-\d{6}-\d{5}$";
                    string saleiPattern = @"^\d{5}$";

                    if (Regex.IsMatch(userinput, saleqPattern))
                    {
                        salequotationradio.Checked = true;
                    }
                    else if (Regex.IsMatch(userinput, saleiPattern))
                    {
                        proformainvoicebtn.Checked = true;
                    }
                    else if (Regex.IsMatch(userinput, salerPattern))
                    {
                        salereturnradio.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("INVOICE NOT EXIST", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an invoice number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
