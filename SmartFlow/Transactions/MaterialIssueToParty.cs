using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Sales.ReportViewer;
using SmartFlow.Transactions.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class MaterialIssueToParty : Form
    {
        private decimal qty = 0;
        private decimal total = 0;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int rowIndexFromMouseDown; // Stores the index of the row being dragged

        public MaterialIssueToParty()
        {
            InitializeComponent();
            dgvsaleproducts.MouseDown += dgvsaleproducts_MouseDown;
            dgvsaleproducts.DragOver += dgvsaleproducts_DragOver;
            dgvsaleproducts.DragDrop += dgvsaleproducts_DragDrop;
        }

        public MaterialIssueToParty(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
            dgvsaleproducts.MouseDown += dgvsaleproducts_MouseDown;
            dgvsaleproducts.DragOver += dgvsaleproducts_DragOver;
            dgvsaleproducts.DragDrop += dgvsaleproducts_DragDrop;
        }
        private void MaterialIssueToParty_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.C)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.DataSent += currencySelection_DataSent;
                currencySelection.ShowDialog();
            }
        }


        private async void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            // Only proceed if the textbox is empty
            if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
            {
                // Check if the CustomerSelectionForm is already open
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));

                // If not open, show the form
                if (openForm == null)
                {
                    CustomerSelectionForm customerSelection = new CustomerSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    customerSelection.CustomerDataSelected += UpdateCustomerTextBox;

                    // Ensure the form is disposed of when closed
                    CommonFunction.DisposeOnClose(customerSelection);
                    customerSelection.Show();
                }
                else
                {
                    // If the form is already open, bring it to the front
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal; // Restore if minimized
                    }
                    openForm.BringToFront();
                }
            }
        }
        private async void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return; // Early return if the key is not Enter

            if (!string.IsNullOrEmpty(selectcustomertxtbox.Text)) return; // Early return if TextBox is not empty

            // Check if CustomerSelectionForm is already open
            Form existingForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));

            if (existingForm == null)
            {
                // Open the form if it's not already open
                CustomerSelectionForm customerSelection = new CustomerSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                customerSelection.CustomerDataSelected += UpdateCustomerTextBox;

                CommonFunction.DisposeOnClose(customerSelection);
                customerSelection.Show();
            }
            else
            {
                // Bring the form to front if it's already open
                existingForm.BringToFront();
            }
        }
        
        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            // Only proceed if the textbox is empty
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                // Check if the ProductSelectionForm is already open
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

                // If the form is not open, show it
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    productSelection.ProductDataSelected += UpdateProductTextBox;

                    // Ensure the form is disposed of when closed
                    CommonFunction.DisposeOnClose(productSelection);
                    productSelection.Show();
                }
                else
                {
                    // If the form is already open, bring it to the front
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal; // Restore if minimized
                    }
                    openForm.BringToFront();
                }
            }
        }
        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return; // Early return if the key is not Enter

            if (!string.IsNullOrEmpty(selectproducttxtbox.Text)) return; // Early return if TextBox is not empty

            // Check if ProductSelectionForm is already open
            Form existingForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

            if (existingForm == null)
            {
                // Open the form if it's not already open
                ProductSelectionForm productSelection = new ProductSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                productSelection.ProductDataSelected += UpdateProductTextBox;

                CommonFunction.DisposeOnClose(productSelection);
                productSelection.Show();
            }
            else
            {
                // Bring the form to front if it's already open
                existingForm.BringToFront();
            }
        }
        private async void MaterialIssueToParty_Load(object sender, EventArgs e)
        {
            await LoadInvoiceAsync();
        }

        public async Task LoadInvoiceAsync()
        {
            try
            {
                if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 || _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
                {
                    // Load invoice details
                    DataRow row = _dtinvoice.Rows[0];

                    invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                    invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
                    invoicedatetxtbox.Text = row["invoicedate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    accountcodetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;
                    selectcustomertxtbox.Text = row["AccountSubControlName"]?.ToString() ?? string.Empty;
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
                    mobiletxtbox.Text = row["MobileNo"]?.ToString() ?? string.Empty;
                    customeridlbl.Text = row["ClientID"]?.ToString() ?? string.Empty;
                    totalvattxtbox.Text = row["TotalVat"]?.ToString() ?? "0";
                    totaldiscounttxtbox.Text = row["TotalDiscount"]?.ToString() ?? "0";
                    salemantxtbox.Text = row["SalePerson"]?.ToString() ?? string.Empty;
                    shippingchargestxtbox.Text = row["FreightShippingCharges"]?.ToString() ?? "0";
                    currencyidlbl.Text = row["Currencyid"]?.ToString() ?? string.Empty;
                    currencynamelbl.Text = row["CurrencyName"]?.ToString() ?? string.Empty;
                    currencysymbollbl.Text = row["CurrencySymbol"]?.ToString() ?? string.Empty;
                    currencyconversionratelbl.Text = row["ConversionRate"]?.ToString() ?? string.Empty;

                    // Load invoice details into DataGridView
                    foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                    {
                        try
                        {
                            int detailsRowIndex = dgvsaleproducts.Rows.Add();
                            DataGridViewRow dgvRow = dgvsaleproducts.Rows[detailsRowIndex];

                            dgvRow.Cells["codecolumn"].Value = invoiceDetailsRow["MFR"]?.ToString();
                            dgvRow.Cells["productid"].Value = invoiceDetailsRow["Productid"]?.ToString();
                            dgvRow.Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"]?.ToString();
                            dgvRow.Cells["qtycolumn"].Value = ConvertToDecimal(invoiceDetailsRow["Quantity"]);
                            dgvRow.Cells["availabilitycolumn"].Value = invoiceDetailsRow["ItemAvailability"]?.ToString();
                            dgvRow.Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"]?.ToString();
                            dgvRow.Cells["unitname"].Value = invoiceDetailsRow["UnitName"]?.ToString();
                            dgvRow.Cells["pricecolumn"].Value = ConvertToDecimal(invoiceDetailsRow["UnitSalePrice"]);
                            dgvRow.Cells["vatcolumn"].Value = ConvertToDecimal(invoiceDetailsRow["ItemWiseVAT"]);
                            dgvRow.Cells["discountcolumn"].Value = ConvertToDecimal(invoiceDetailsRow["ItemWiseDiscount"]);
                            dgvRow.Cells["totalcolumn"].Value = ConvertToDecimal(invoiceDetailsRow["ItemTotal"]);
                            dgvRow.Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"]?.ToString();
                            dgvRow.Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"]?.ToString();
                            dgvRow.Cells["lengthinmetercolumn"].Value = ConvertToDecimal(invoiceDetailsRow["LengthInMeter"]);
                            dgvRow.Cells["pricepermetercolumn"].Value = ConvertToDecimal(invoiceDetailsRow["PricePerMeter"]);
                            dgvRow.Cells["vatpercentagecolumn"].Value = ConvertToDecimal(invoiceDetailsRow["VatCode"]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error loading invoice detail row: {ex.Message}");
                        }
                    }

                    savebtn.Text = "UPDATE";
                }
                else
                {
                    // Set default values when no data is available
                    await Task.Delay(500);
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    qtytxtbox.Text = qty.ToString("0");
                    nettotaltxtbox.Text = total.ToString("0.00");
                    totaldiscounttxtbox.Text = total.ToString("0.00");
                    totalvattxtbox.Text = total.ToString("0.00");
                    invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                    shippingchargestxtbox.Text = total.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Utility method to safely convert values to decimal
        private decimal ConvertToDecimal(object value)
        {
            return decimal.TryParse(value?.ToString(), out decimal result) ? result : 0;
        }

        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = await Task.Run(() => GetLastInvoiceNumber());
                string newInvoiceNumber;
                string invoicePart = "MIP";
                string datePart = DateTime.Today.ToString("yyMMdd");

                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    // No previous invoice number, generate the first one
                    int initialSequentialNumber = 1;
                    string sequentialPart = initialSequentialNumber.ToString("D5"); // 5-digit sequential number

                    newInvoiceNumber = $"{invoicePart}-{datePart}-{sequentialPart}";
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    int lastSequentialNumber;
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);

                    if (!int.TryParse(sequentialPart, out lastSequentialNumber))
                    {
                        throw new FormatException("Invalid format in the last invoice number. Unable to parse sequential part.");
                    }

                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Validate sequential number bounds (optional)
                    if (nextSequentialNumber > 99999)
                    {
                        throw new OverflowException("Sequential number has exceeded the maximum limit.");
                    }

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicePart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"Error generating invoice number: {ex.Message}\n{ex.StackTrace}");

                // Show a user-friendly message
                MessageBox.Show("An error occurred while generating the invoice number. Please contact support.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                // Query to fetch the latest invoice number starting with 'PI-'
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'MIP-%' ORDER BY InvoiceNo DESC";

                // Retrieve data from the database asynchronously
                DataTable invoiceData = await Task.Run(() => DatabaseAccess.RetriveAsync(query));

                // Ensure the result is not null and has rows
                if (invoiceData != null && invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
                else
                {
                    // Optional: Log or handle cases where no data is found
                    Console.WriteLine("No matching invoice numbers found in the database.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error retrieving the last invoice number: {ex.Message}\n{ex.StackTrace}");

                // Display a user-friendly error message
                MessageBox.Show("An error occurred while retrieving the last invoice number from the database. " +
                                "Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the last invoice number (null if not found or an error occurred)
            return lastInvoiceNumber;
        }
        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Validate that both the lastInvoiceNumber and newInvoiceNumber are not null and are valid numbers
                /*if (string.IsNullOrEmpty(lastInvoiceNumber) || string.IsNullOrEmpty(newInvoiceNumber))
                {
                    MessageBox.Show("Invoice number is invalid or missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }*/

                // Ensure both invoice numbers have the same format for comparison (e.g., zero-padded)
                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    // Generate the next invoice number if the new invoice is <= the last invoice number
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    // Return the user-provided invoice number if it's valid and greater than the last invoice number
                    return newInvoiceNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        private void dgvsaleproducts_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.C)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.DataSent += currencySelection_DataSent;
                currencySelection.ShowDialog();
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            if (selectcustomertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvsaleproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }

        private void currencySelection_DataSent(CurrencyData receivedCurrency)
        {
            // Use the received data (e.g., display it in a label)
            currencylbl.Text = receivedCurrency.Name + (" : ") + receivedCurrency.Symbol;
            currencyidlbl.Text = receivedCurrency.CurrencyId.ToString();
            currencynamelbl.Text = receivedCurrency.Name.ToString();
            currencysymbollbl.Text = receivedCurrency.Symbol.ToString();
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            bool detailadded = false;
            try
            {
                if (!string.IsNullOrEmpty(currencyidlbl.Text) && currencyidlbl.Text != "currencyidlbl"
                    && !string.IsNullOrEmpty(currencynamelbl.Text) && currencynamelbl.Text != "currencynamelbl"
                    && !string.IsNullOrEmpty(currencysymbollbl.Text) && currencysymbollbl.Text != "currencysymbollbl"
                    && !string.IsNullOrEmpty(currencyconversionratelbl.Text) && currencyconversionratelbl.Text != "currencyconversionratelbl")
                {
                    errorProvider.Clear();
                    if (selectcustomertxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(selectcustomertxtbox, "Please Select Customer.");
                        selectcustomertxtbox.Focus();
                        return;
                    }

                    string invoiceNo = string.Empty;
                    if (savebtn.Text == "UPDATE")
                    {
                        invoiceNo = invoicenotxtbox.Text;
                        DateTime invoiceDate;
                        string format = "dd/MM/yyyy"; // Custom format for UK-style dates
                        var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture
                        if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                        {
                            await UpdateMaterialIssueInvoice(invoiceNo, invoiceDate);
                        }
                        else
                        {
                            invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                            await UpdateMaterialIssueInvoice(invoiceNo, invoiceDate);
                        }

                    }
                    else
                    {
                        invoiceNo = await CheckInvoiceBeforeInsert();
                        DateTime invoiceDate;
                        string format = "dd/MM/yyyy"; // Custom format for UK-style dates
                        var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture
                        if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                        {
                            detailadded = await AddMaterialIssueInvoice(invoiceNo, invoiceDate);
                        }
                        else
                        {
                            invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                            detailadded = await AddMaterialIssueInvoice(invoiceNo, invoiceDate);
                        }
                    }

                    if (detailadded)
                    {
                        MessageBox.Show("Saved Successfully!");
                        MaterialIssueReportView materialIssueReportView = new MaterialIssueReportView(invoiceNo);
                        materialIssueReportView.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(materialIssueReportView);
                        materialIssueReportView.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task UpdateMaterialIssueInvoice(string invoiceNo, DateTime invoiceDate)
        {
            int customerId = Convert.ToInt32(customeridlbl.Text);
            string customercode = mfrtxtbox.Text;
            string customername = selectcustomertxtbox.Text;
            string customerrefrence = companytxtbox.Text;
            string mobile = mobiletxtbox.Text;
            string salespersonname = salemantxtbox.Text;
            float nettotal = float.Parse(nettotaltxtbox.Text);
            float totalvat = float.Parse(totalvattxtbox.Text);
            float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
            float shippingcharges = float.Parse(shippingchargestxtbox.Text);
            string invoiceCode = invoicecodelbl.Text;
            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";

            string whereClause = "InvoiceNo = '" + invoiceNo + "'";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "invoicedate", invoiceDate },
                { "ClientID", customerId },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceCode", invoiceCode },
                { "ClientName", customername },
                { "NetTotal", nettotal },
                { "TotalVat", totalvat },
                { "TotalDiscount", totaldiscount },
                { "FreightShippingCharges", shippingcharges },
                { "SalePerson", salespersonname },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate }
            };

            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            if (isUpdated)
            {
                UpdateInvoiceDetailsData(invoiceNo, invoiceCode);
            }
        }

        private async Task<bool> AddMaterialIssueInvoice(string invoiceNo, DateTime invoiceDate)
        {
            bool isCompleted = false;
            int customerid = Convert.ToInt32(customeridlbl.Text);
            string customercode = mfrtxtbox.Text;
            string customername = selectcustomertxtbox.Text;
            string customerrefrence = companytxtbox.Text;
            string mobile = mobiletxtbox.Text;
            string salespersonname = salemantxtbox.Text;
            float nettotal = float.Parse(nettotaltxtbox.Text);
            float totalvat = float.Parse(totalvattxtbox.Text);
            float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
            float shippingcharges = float.Parse(shippingchargestxtbox.Text.ToString());
            string invoicecode = Guid.NewGuid().ToString();
            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "invoicedate", invoiceDate },
                { "ClientID", customerid },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceCode", invoicecode },
                { "NetTotal", nettotal },
                { "ClientName", customername },
                { "TotalVat", totalvat },
                { "TotalDiscount", totaldiscount },
                { "FreightShippingCharges", shippingcharges },
                { "SalePerson", salespersonname },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate }
            };

            bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);

            if (result)
            {
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (row.IsNewRow) { continue; }

                    int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                    int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                    float unitprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                    string productname = row.Cells["productnamecolumn"].Value.ToString();
                    string mfr = row.Cells["codecolumn"].Value.ToString();
                    float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                    float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                    float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                    int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                    int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                    string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                    float pricepermeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                    float lengthinmeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                    string availabilitystatus = row.Cells["availabilitycolumn"].Value.ToString();
                    float vatpercentage = float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString());

                    string subtable = "InvoiceDetailsTable";
                    var subColumnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "Invoicecode", invoicecode },
                        { "Productid", productid },
                        { "Quantity", quantity },
                        { "UnitSalePrice", unitprice },
                        { "ProductName", productname },
                        { "MFR", mfr },
                        { "ItemWiseDiscount", discount },
                        { "ItemWiseVAT", vat },
                        { "ItemTotal", total },
                        { "Unitid", unitid },
                        { "AddInventory", false },
                        { "Warehouseid", warehouseid },
                        { "ItemDescription", itemwisedescription },
                        { "PricePerMeter", pricepermeter },
                        { "LengthInMeter", lengthinmeter },
                        { "MinusInventory", true },
                        { "ItemAvailability", availabilitystatus },
                        { "IsNewRecord", true },
                        { "VatCode", vatpercentage }
                    };

                    isCompleted = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                }
            }
            return isCompleted;
        }

        private async void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool detailadded = false;
            bool isold = await UpdateInvoiceDetail(invoiceNo);
            if (isold) 
            {
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (row.IsNewRow) { continue; }

                    int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                    string invoicecode = invoicecodelbl.Text;
                    int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                    float unitprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                    string productname = row.Cells["productnamecolumn"].Value.ToString();
                    string mfr = row.Cells["codecolumn"].Value.ToString();
                    float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                    float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                    float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                    int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                    int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                    string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                    float pricepermeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                    float lengthinmeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                    string availabilitystatus = row.Cells["availabilitycolumn"].Value.ToString();
                    float vatpercentage = float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString());

                    string subtable = "InvoiceDetailsTable";
                    var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoicecode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "UnitSalePrice", unitprice },
                    { "ProductName", productname },
                    { "MFR", mfr },
                    { "ItemWiseDiscount", discount },
                    { "ItemWiseVAT", vat },
                    { "ItemTotal", total },
                    { "Unitid", unitid },
                    { "AddInventory", false },
                    { "Warehouseid", warehouseid },
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", true },
                    { "ItemAvailability", availabilitystatus },
                    { "IsNewRecord", true },
                    { "VatCode", vatpercentage }

                };

                    detailadded = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                }
                if (detailadded)
                {
                    MessageBox.Show("Updated Successfully!");
                    MaterialIssueReportView materialIssueReportView = new MaterialIssueReportView(invoiceNo);
                    materialIssueReportView.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(materialIssueReportView);
                    materialIssueReportView.Show();
                    this.Close();
                }
            }
            
        }

        private async Task<bool> UpdateInvoiceDetail(string invoiceNo)
        {
            try
            {
                bool isold = false;
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                var columnData = new Dictionary<string, object>
                {
                    { "IsNewRecord", false }
                };

                isold = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                return isold;
            }
            catch (Exception ex) { throw ex; }
        }

        private async void dgvsaleproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
        }

        private async void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
        }

        private async void UpdateProductTextBox(object sender, ProductData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int productid = e.ProductId;
                    string productname = e.ProductName;
                    string productmfr = e.ProductMfr;
                    string productupc = e.ProductUPC;
                    float productprice = e.ProductPrice;
                    string productbarcode = e.ProductBarcode;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        productidlbl.Text = productid.ToString();
                        mfrtxtbox.Text = productmfr.ToString();
                        selectproducttxtbox.Text = productname.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateCustomerTextBox(object sender, CustomerData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int customerid = e.CustomerId;
                    string customername = e.CustomerName;
                    string customercode = e.CustomerCode;
                    string customermobile = e.CustomerMobile;
                    string customercompany = e.CustomerCompanyName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        customeridlbl.Text = customerid.ToString();
                        selectcustomertxtbox.Text = customername.ToString();
                        accountcodetxtbox.Text = customercode.ToString();
                        mobiletxtbox.Text = customermobile.ToString();
                        companytxtbox.Text = customercompany.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            MaterialIssueToParty materialIssueToParty = new MaterialIssueToParty();
            materialIssueToParty.MdiParent = Application.OpenForms["Dashboard"];
            materialIssueToParty.Show();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
            {
                string mfr = mfrtxtbox.Text;
                string productid = productidlbl.Text;
                string productname = selectproducttxtbox.Text;
                string qty = qtytxtbox.Text;
                int unitid = Convert.ToInt32(unitidlbl.Text);
                string unitname = unitnamelbl.Text;
                decimal vatamount = decimal.Parse(productvatlbl.Text);
                decimal discount = decimal.Parse(productdiscountlbl.Text);
                float unitprice = float.Parse(unitsalepricelbl.Text);
                decimal finalitemwise = decimal.Parse(totalcolumnlbl.Text);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
                string itemwisedescription = itemdescriptionlbl.Text;
                decimal lengthinmeterproduct = decimal.Parse(lengthinmeterlbl.Text);
                decimal priceinmeter = decimal.Parse(pricepermeterlbl.Text);
                string availability = availabilitystatuslbl.Text;
                string vatpercentage = vatcodelbl.Text;
                string discountpercentage = discountpercentagelbl.Text;
                bool discounttype = Convert.ToBoolean(discounttypelbl.Text);
                string availabilitystatus = availabilitystatuslbl.Text;

                bool productExists = false;
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString() &&
                            float.Parse(row.Cells["pricecolumn"].Value.ToString()) == unitprice)
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                            decimal currentVat = decimal.Parse(row.Cells["vatcolumn"].Value.ToString());
                            decimal currentDiscount = decimal.Parse(row.Cells["discountcolumn"].Value.ToString());
                            decimal currentitemTotal = decimal.Parse(row.Cells["totalcolumn"].Value.ToString());

                            row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            // Update VAT, round to two decimal places
                            row.Cells["vatcolumn"].Value = Math.Round(currentVat + vatamount, 2);

                            // Update Discount, round to two decimal places
                            row.Cells["discountcolumn"].Value = Math.Round(currentDiscount + discount, 2);

                            // Update Total, round to two decimal places
                            row.Cells["totalcolumn"].Value = Math.Round(currentitemTotal + finalitemwise, 2);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvsaleproducts.Rows.Add("", mfr, productid, productname, qty, availability, unitid, unitname, unitprice,
                        vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter,
                        vatpercentage, discountpercentage, discounttype);
                }

                ResetLabelData();
            }
        }

        private void ResetLabelData()
        {
            mfrtxtbox.Text = string.Empty;
            selectproducttxtbox.Text = string.Empty;
            productidlbl.Text = string.Empty;
            qtytxtbox.Text = string.Empty;
            unitnamelbl.Text = string.Empty;
            productvatlbl.Text = string.Empty;
            productdiscountlbl.Text = string.Empty;
            unitsalepricelbl.Text = string.Empty;
            totalcolumnlbl.Text = string.Empty;
            itemdescriptionlbl.Text = string.Empty;
            discounttypelbl.Text = string.Empty;
            availabilitystatuslbl.Text = string.Empty;
            warehouseidlbl.Text = string.Empty;
            unitidlbl.Text = string.Empty;
            pricepermeterlbl.Text = string.Empty;
            vatcodelbl.Text = string.Empty;
            discountpercentagelbl.Text = string.Empty;
            selectproducttxtbox.Focus();
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace, and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void selectproducttxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block the key press
            }
            else
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelection = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };
                        productSelection.ProductDataSelected += UpdateProductTextBox;

                        CommonFunction.DisposeOnClose(productSelection);
                        productSelection.Show();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private async void qtytxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
                {
                    int itemqty = Convert.ToInt32(qtytxtbox.Text);
                    if (itemqty > 0)
                    {
                        string productid = productidlbl.Text;
                        SqlParameter param1 = new SqlParameter("@ProductID", SqlDbType.Int)
                        {
                            Value = string.IsNullOrEmpty(productid) ? (object)DBNull.Value : Convert.ToInt32(productid)
                        };
                        DataTable result = await DatabaseAccess.ExecuteStoredProcedureAsync("GetTotalQuantityAndWarehouse", param1);

                        // Create the WarehouseQty form
                        WarehouseQty warehouseQty = new WarehouseQty(result,true)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };
                        
                        // Event to handle closing the current form and opening the new one
                        warehouseQty.FormClosed += WarehouseQty_FormClosed;
                        // Show the WarehouseQty form
                        warehouseQty.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void WarehouseQty_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((WarehouseQty)sender);

                // Create and show VATForm after WarehouseQty is closed
                VATForm vATForm = new VATForm(Convert.ToInt32(qtytxtbox.Text), false)
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };
                vATForm.FormClosed += async delegate
                {
                    await UpdateProductDataAsync();
                };
                // Apply DisposeOnClose to VATForm
                CommonFunction.DisposeOnClose(vATForm);
                vATForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task UpdateProductDataAsync()
        {
            await Task.Run(() =>
            {
                // Assuming these updates are thread-safe
                warehouseidlbl.Invoke((Action)(() => warehouseidlbl.Text = GlobalVariables.warehouseidglobal != 0 ? GlobalVariables.warehouseidglobal.ToString() : "0"));
                itemdescriptionlbl.Invoke((Action)(() => itemdescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl ?? "N/A"));
                unitsalepricelbl.Invoke((Action)(() => unitsalepricelbl.Text = GlobalVariables.productpriceglobal != 0 ? GlobalVariables.productpriceglobal.ToString("0.00") : "0.00"));
                pricepermeterlbl.Invoke((Action)(() => pricepermeterlbl.Text = GlobalVariables.productinmeterprice != 0 ? GlobalVariables.productinmeterprice.ToString("0.00") : "0.00"));
                lengthinmeterlbl.Invoke((Action)(() => lengthinmeterlbl.Text = GlobalVariables.productinmeterlength != 0 ? GlobalVariables.productinmeterlength.ToString("0.00") : "0.00"));
                totalcolumnlbl.Invoke((Action)(() => totalcolumnlbl.Text = GlobalVariables.productfinalamountwithvatanddiscountitemwise != 0 ? GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("0.00") : "0.00"));
                unitnamelbl.Invoke((Action)(() => unitnamelbl.Text = GlobalVariables.unitnameglobal ?? "N/A"));
                unitidlbl.Invoke((Action)(() => unitidlbl.Text = GlobalVariables.unitidglobal != 0 ? GlobalVariables.unitidglobal.ToString() : "0"));
                productdiscountlbl.Invoke((Action)(() => productdiscountlbl.Text = GlobalVariables.productdiscountamountitemwise != 0 ? GlobalVariables.productdiscountamountitemwise.ToString("0.00") : "0.00"));
                productvatlbl.Invoke((Action)(() => productvatlbl.Text = GlobalVariables.productitemwisevatamount != 0 ? GlobalVariables.productitemwisevatamount.ToString("0.00") : "0.00"));
                vatcodelbl.Invoke((Action)(() => vatcodelbl.Text = GlobalVariables.productitemwisevatpercentage != 0 ? GlobalVariables.productitemwisevatpercentage.ToString() : "0"));
                availabilitystatuslbl.Invoke((Action)(() => availabilitystatuslbl.Text = GlobalVariables.availabilitystatus ?? "IN STOCK"));
                discountpercentagelbl.Invoke((Action)(() => discountpercentagelbl.Text = GlobalVariables.discountpercentage != 0 ? GlobalVariables.discountpercentage.ToString() : "0"));
                discounttypelbl.Invoke((Action)(() => discounttypelbl.Text = GlobalVariables.productdiscounttype != false ? GlobalVariables.productdiscounttype.ToString() : "false"));
                ResetGlobalVariables();
            });
        }

        private async void ResetGlobalVariables()
        {
            await Task.Run(() =>
            {
                GlobalVariables.warehouseidglobal = 0;
                GlobalVariables.productitemwisedescriptiongloabl = null;
                GlobalVariables.productpriceglobal = 0;
                GlobalVariables.productinmeterprice = 0;
                GlobalVariables.productinmeterlength = 0;
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                GlobalVariables.unitnameglobal = null;
                GlobalVariables.unitidglobal = 0;
                GlobalVariables.productdiscountamountitemwise = 0;
                GlobalVariables.productitemwisevatamount = 0;
                GlobalVariables.productitemwisevatpercentage = 0;
                GlobalVariables.availabilitystatus = string.Empty;
                GlobalVariables.discountpercentage = 0;
                GlobalVariables.productdiscounttype = false;
            });
        }


        private async void dgvsaleproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
        }

        private void removevatchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (removevatchkbox.Checked)
            {
                // Iterate through the DataGridView rows
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (row.Cells["vatcolumn"] != null && row.Cells["totalcolumn"] != null) // Ensure columns exist
                    {
                        // Get the current VAT and Total
                        decimal vat = row.Cells["vatcolumn"].Value != null ? Convert.ToDecimal(row.Cells["vatcolumn"].Value) : 0;
                        decimal total = row.Cells["totalcolumn"].Value != null ? Convert.ToDecimal(row.Cells["totalcolumn"].Value) : 0;

                        // Remove VAT from the Total
                        total -= vat;

                        // Update VAT and Total columns
                        row.Cells["vatcolumn"].Value = 0; // Set VAT to 0
                        row.Cells["totalcolumn"].Value = total; // Update Total
                    }
                }
            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRowSelectionAsync();
        }

        private void HandleRowSelectionAsync()
        {
            if (dgvsaleproducts.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dgvsaleproducts.SelectedRows[0]; // Get the first selected row
                int rowIndex = selectedRow.Index;
                string productmfr = selectedRow.Cells["codecolumn"].Value?.ToString() ?? null;
                string productname = selectedRow.Cells["productnamecolumn"].Value?.ToString() ?? null;

                int productid = selectedRow.Cells["productid"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["productid"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["productid"].Value.ToString())
                    : 0; // Default to 0 if empty or null

                int quantity = selectedRow.Cells["qtycolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["qtycolumn"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["qtycolumn"].Value.ToString())
                    : 0;

                int unitid = selectedRow.Cells["unitidcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["unitidcolumn"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["unitidcolumn"].Value.ToString())
                    : 0;

                string unitname = selectedRow.Cells["unitname"].Value?.ToString() ?? null;

                float price = selectedRow.Cells["pricecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["pricecolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["pricecolumn"].Value.ToString())
                    : 0.0f;

                float vat = selectedRow.Cells["vatcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["vatcolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["vatcolumn"].Value.ToString())
                    : 0.0f;

                float discount = selectedRow.Cells["discountcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["discountcolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["discountcolumn"].Value.ToString())
                    : 0.0f;

                float itemtotal = selectedRow.Cells["totalcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["totalcolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["totalcolumn"].Value.ToString())
                    : 0.0f;

                int warehouseid = selectedRow.Cells["warehouseidcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["warehouseidcolumn"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["warehouseidcolumn"].Value.ToString())
                    : 0;

                string itemdescription = selectedRow.Cells["itemdescriptioncolumn"].Value?.ToString() ?? null;

                float lengthinmeter = selectedRow.Cells["lengthinmetercolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["lengthinmetercolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["lengthinmetercolumn"].Value.ToString())
                    : 0.0f;

                float priceinmeter = selectedRow.Cells["pricepermetercolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["pricepermetercolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["pricepermetercolumn"].Value.ToString())
                    : 0.0f;

                float vatpercentage = selectedRow.Cells["vatpercentagecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["vatpercentagecolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["vatpercentagecolumn"].Value.ToString())
                    : 0.0f;

                float discountpercentage = selectedRow.Cells["discountpercentagecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["discountpercentagecolumn"].Value.ToString())
                        ? float.Parse(selectedRow.Cells["discountpercentagecolumn"].Value.ToString())
                        : 0.0f;

                bool discounttype = selectedRow.Cells["discounttypecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["discounttypecolumn"].Value.ToString())
                        ? Convert.ToBoolean(selectedRow.Cells["discounttypecolumn"].Value.ToString())
                        : false;
                // Open the edit dialog asynchronously

                EditItemInvoice editItemInvoice = new EditItemInvoice(rowIndex, productmfr, productname, productid, quantity, unitid, unitname, price,
                            vat, discount, itemtotal, warehouseid, itemdescription, lengthinmeter, priceinmeter, vatpercentage, discountpercentage, discounttype, true);
                editItemInvoice.DataUpdated += EditItemInvoice_DataUpdated;
                editItemInvoice.ShowDialog(); // This will still block but in a separate thread.

            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }

        private void dgvsaleproducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }

        private void EditItemInvoice_DataUpdated(int rowIndex, string productmfr, string productname, int productid, int quantity, int unitid, string unitname,
                                             decimal price, decimal vat, decimal discount, decimal itemtotal, int warehouseid, string itemdescription,
                                             decimal lengthinmeter, decimal priceinmeter, decimal vatpercentage, decimal discountpercentage, bool discounttype)
        {
            // Update DataGridView row with new data
            dgvsaleproducts.Rows[rowIndex].Cells["codecolumn"].Value = productmfr;
            dgvsaleproducts.Rows[rowIndex].Cells["productnamecolumn"].Value = productname;
            dgvsaleproducts.Rows[rowIndex].Cells["productid"].Value = productid;
            dgvsaleproducts.Rows[rowIndex].Cells["qtycolumn"].Value = quantity;
            dgvsaleproducts.Rows[rowIndex].Cells["unitidcolumn"].Value = unitid;
            dgvsaleproducts.Rows[rowIndex].Cells["unitname"].Value = unitname;
            dgvsaleproducts.Rows[rowIndex].Cells["pricecolumn"].Value = price;
            dgvsaleproducts.Rows[rowIndex].Cells["vatcolumn"].Value = vat;
            dgvsaleproducts.Rows[rowIndex].Cells["discountcolumn"].Value = discount;
            dgvsaleproducts.Rows[rowIndex].Cells["totalcolumn"].Value = itemtotal;
            dgvsaleproducts.Rows[rowIndex].Cells["warehouseidcolumn"].Value = warehouseid;
            dgvsaleproducts.Rows[rowIndex].Cells["itemdescriptioncolumn"].Value = itemdescription;
            dgvsaleproducts.Rows[rowIndex].Cells["lengthinmetercolumn"].Value = lengthinmeter;
            dgvsaleproducts.Rows[rowIndex].Cells["pricepermetercolumn"].Value = priceinmeter;
            dgvsaleproducts.Rows[rowIndex].Cells["vatpercentagecolumn"].Value = vatpercentage;
            dgvsaleproducts.Rows[rowIndex].Cells["discountpercentagecolumn"].Value = discountpercentage;
            dgvsaleproducts.Rows[rowIndex].Cells["discounttypecolumn"].Value = discounttype;
        }

        private void dgvsaleproducts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgvsaleproducts.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    dgvsaleproducts.ClearSelection();
                    dgvsaleproducts.Rows[hitTestInfo.RowIndex].Selected = true;
                    dgvsaleproducts.CurrentCell = dgvsaleproducts.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];

                    // Show the ContextMenuStrip at mouse position
                    contextMenuStrip.Show(dgvsaleproducts, new Point(e.X, e.Y));
                }
            }

            if (dgvsaleproducts.SelectedRows.Count > 0)
            {
                rowIndexFromMouseDown = dgvsaleproducts.HitTest(e.X, e.Y).RowIndex;
                if (rowIndexFromMouseDown >= 0)
                {
                    dgvsaleproducts.DoDragDrop(dgvsaleproducts.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void dgvsaleproducts_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvsaleproducts_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvsaleproducts.PointToClient(new Point(e.X, e.Y));
            int rowIndexOfItemUnderMouseToDrop = dgvsaleproducts.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (rowIndexFromMouseDown >= 0 && rowIndexOfItemUnderMouseToDrop >= 0 && rowIndexFromMouseDown != rowIndexOfItemUnderMouseToDrop)
            {
                DataGridViewRow rowToMove = dgvsaleproducts.Rows[rowIndexFromMouseDown];
                dgvsaleproducts.Rows.RemoveAt(rowIndexFromMouseDown);
                dgvsaleproducts.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
        }
    }
}
