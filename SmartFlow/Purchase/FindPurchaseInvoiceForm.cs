using SmartFlow.Common;
using SmartFlow.Purchase.ReportViewer;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class FindPurchaseInvoiceForm : Form
    {
        public FindPurchaseInvoiceForm()
        {
            InitializeComponent();
        }
        private async void searchbtn_Click(object sender, EventArgs e)
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
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);


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

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                        if(dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice(dataInvoice,dtInvoiceDetails);
                            purchaseQuotationInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            await CommonFunction.DisposeOnCloseAsync(purchaseQuotationInvoice);
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
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

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

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            PurchaseOrder purchaseOrder = new PurchaseOrder(dataInvoice, dtInvoiceDetails);
                            purchaseOrder.MdiParent = Application.OpenForms["Dashboard"];
                            await CommonFunction.DisposeOnCloseAsync(purchaseOrder);
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
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill,InvoiceTable.ShipmentReceiveingPerson," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

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

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            PurchaseInvoice purchaseInvoice = new PurchaseInvoice(dataInvoice, dtInvoiceDetails);
                            purchaseInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            await CommonFunction.DisposeOnCloseAsync(purchaseInvoice);
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
                    string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

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

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                        if (dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            this.Close();
                            PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice(dataInvoice, dtInvoiceDetails);
                            purchaseReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
                            await CommonFunction.DisposeOnCloseAsync(purchaseReturnInvoice);
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
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private async void FindPurchaseInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicenotxtbox.Focus();
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Example of an asynchronous operation (e.g., loading data from a database)
            await LoadInvoiceDataAsync();
        }

        /// <summary>
        /// Simulates an asynchronous operation, such as fetching data from a database or an API.
        /// </summary>
        private async Task LoadInvoiceDataAsync()
        {
            // Simulate a delay to mimic an asynchronous operation (e.g., database call)
            await Task.Delay(1000); // Replace this with your actual async logic
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
        private async void FindPurchaseInvoiceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    // Example: Asynchronous confirmation or operation
                    DialogResult result = await Task.Run(() =>
                    {
                        return MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                               "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    });

                    if (result == DialogResult.Yes)
                    {
                        // Example: Async operation before closing
                        await PerformUnsavedChangesCleanupAsync();

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

        /// <summary>
        /// Simulates an asynchronous operation for cleaning up unsaved changes.
        /// Replace this with actual async operations as needed.
        /// </summary>
        private async Task PerformUnsavedChangesCleanupAsync()
        {
            // Simulate a delay to mimic an async operation
            await Task.Delay(500);
            Console.WriteLine("Unsaved changes cleanup completed.");
        }

        private async void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            string userInput = invoicenotxtbox.Text;
            if (userInput.Length > 0)
            {
                try
                {
                    // Asynchronously retrieve data from the database
                    DataTable invoiceDate = await Task.Run(() =>
                        DatabaseAccess.RetriveAsync($"SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo LIKE '{userInput}'"));

                    if (invoiceDate != null && invoiceDate.Rows.Count > 0)
                    {
                        DataRow row = invoiceDate.Rows[0];
                        invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving the invoice date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
