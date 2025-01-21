using SmartFlow.Common.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartFlow.Sales.ReportViewer;
using SmartFlow.Sales.CommonForm;
using System.Data.SqlClient;
using System.IO;
using static SmartFlow.DatabaseAccess;
using SmartFlow.Common.CommonForms;
using System.Globalization;

namespace SmartFlow.Sales
{
    public partial class PerformaInvoice : Form
    {
        private decimal price = 0;
        private decimal qty = 0;
        private decimal total = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
        public PerformaInvoice(DataTable dtinvoice, DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        public PerformaInvoice()
        {
            InitializeComponent();
        }
        private async void PerformaInvoice_Load(object sender, EventArgs e)
        {
            if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
            {
                try
                {
                    DataRow row = _dtinvoice.Rows[0];

                    invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                    invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;
                    selectcustomertxtbox.Text = row["AccountSubControlName"]?.ToString() ?? string.Empty;
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
                    mobiletxtbox.Text = row["MobileNo"]?.ToString() ?? string.Empty;
                    customeridlbl.Text = row["ClientID"]?.ToString() ?? string.Empty;
                    totalvattxtbox.Text = decimal.TryParse(row["TotalVat"]?.ToString(), out decimal totalVat) ? totalVat.ToString("0.00") : "0.00";
                    totaldiscounttxtbox.Text = decimal.TryParse(row["TotalDiscount"]?.ToString(), out decimal totalDiscount) ? totalDiscount.ToString("0.00") : "0.00";
                    salesmantxtbox.Text = row["SalePerson"]?.ToString() ?? string.Empty;
                    shippingchargestxtbox.Text = decimal.TryParse(row["FreightShippingCharges"]?.ToString(), out decimal shippingCharges) ? shippingCharges.ToString("0.00") : "0.00";

                    foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                    {
                        int detailsRowIndex = dgvsaleproducts.Rows.Add();

                        dgvsaleproducts.Rows[detailsRowIndex].Cells["codecolumn"].Value = invoiceDetailsRow["MFR"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = int.TryParse(invoiceDetailsRow["Quantity"]?.ToString(), out int quantity) ? quantity : 0;
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["availabilitycolumn"].Value = invoiceDetailsRow["ItemAvailability"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = decimal.TryParse(invoiceDetailsRow["UnitSalePrice"]?.ToString(), out decimal unitPrice) ? unitPrice.ToString("0.00") : "0.00";
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = decimal.TryParse(invoiceDetailsRow["ItemWiseVAT"]?.ToString(), out decimal vat) ? vat.ToString("0.00") : "0.00";
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = decimal.TryParse(invoiceDetailsRow["ItemWiseDiscount"]?.ToString(), out decimal discount) ? discount.ToString("0.00") : "0.00";
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = decimal.TryParse(invoiceDetailsRow["ItemTotal"]?.ToString(), out decimal itemTotal) ? itemTotal.ToString("0.00") : "0.00";
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = decimal.TryParse(invoiceDetailsRow["LengthInMeter"]?.ToString(), out decimal length) ? length.ToString("0.00") : "0.00";
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = decimal.TryParse(invoiceDetailsRow["PricePerMeter"]?.ToString(), out decimal pricePerMeter) ? pricePerMeter.ToString("0.00") : "0.00";
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"]?.ToString();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["unitname"].Value = invoiceDetailsRow["UnitName"]?.ToString();
                    }

                    savebtn.Text = "UPDATE";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while processing the invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                qtytxtbox.Text = qty.ToString("0");
                nettotaltxtbox.Text = total.ToString("0.00");
                totaldiscounttxtbox.Text = total.ToString("0.00");
                totalvattxtbox.Text = total.ToString("0.00");
                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                shippingchargestxtbox.Text = total.ToString("N2");
            }

        }
        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                // Retrieve the last invoice number
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (string.IsNullOrWhiteSpace(lastInvoiceNumber))
                {
                    // No previous invoice number exists; generate the first one
                    string invoicePrefix = "PIS";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate parts to form the new invoice number
                    newInvoiceNumber = $"{invoicePrefix}-{datePart}-{sequentialPart}";
                }
                else
                {
                    // Validate the format of the last invoice number
                    string[] parts = lastInvoiceNumber.Split('-');
                    if (parts.Length != 3 || parts[0] != "PIS" || parts[1].Length != 6 || !int.TryParse(parts[2], out int lastSequentialNumber))
                    {
                        throw new FormatException("Invalid format for the last invoice number.");
                    }

                    // Extract parts from the valid last invoice number
                    string invoicePrefix = parts[0];
                    string datePart = DateTime.Today.ToString("yyMMdd");

                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicePrefix}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (FormatException formatEx)
            {
                // Handle specific format-related exceptions
                MessageBox.Show($"Invoice format error: {formatEx.Message}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                // SQL query to retrieve the last invoice number
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PIS-%' ORDER BY InvoiceNo DESC";
                
                // Retrieve data from the database
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
                
                // Check if the query returned any rows
                if (invoiceData != null && invoiceData.Rows.Count > 0)
                {
                    // Attempt to retrieve the last invoice number
                    object invoiceNoObj = invoiceData.Rows[0]["InvoiceNo"];
                    if (invoiceNoObj != null)
                    {
                        lastInvoiceNumber = invoiceNoObj.ToString();
                        
                        // Validate the format of the retrieved invoice number
                        if (!lastInvoiceNumber.StartsWith("PIS-") || lastInvoiceNumber.Split('-').Length != 3)
                        {
                            throw new FormatException("Invalid invoice number format retrieved from the database.");
                        }
                    }
                }
            }
            catch (FormatException formatEx)
            {
                // Handle specific format-related exceptions
                MessageBox.Show($"Invoice number format error: {formatEx.Message}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An error occurred while retrieving the last invoice number: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Optional: Log the exception for debugging
                LogError(ex); // Assume a method `LogError(Exception ex)` exists to log errors
            }
            
            // Ensure a safe return value
            return lastInvoiceNumber ?? string.Empty; // Return an empty string if no valid invoice number is found
        }
        public void LogError(Exception ex)
        {
            try
            {
                // Define a log file path
                string logFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLog.txt");

                // Create or append to the log file
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"Date/Time: {DateTime.Now}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                    writer.WriteLine("--------------------------------------------------");
                }
            }
            catch
            {
                // If logging fails, silently handle it to avoid recursive errors
            }
        }
        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                // Retrieve the last invoice number
                string lastInvoiceNumber = await GetLastInvoiceNumber();

                // Get the invoice number from the text box
                string newInvoiceNumber = invoicenotxtbox.Text?.Trim();

                // Validate inputs
                if (string.IsNullOrEmpty(newInvoiceNumber))
                {
                    throw new InvalidOperationException("The invoice number in the text box cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    throw new InvalidOperationException("Failed to retrieve the last invoice number from the database.");
                }

                // Compare the invoice numbers
                if (string.Compare(newInvoiceNumber, lastInvoiceNumber, StringComparison.Ordinal) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    return newInvoiceNumber;
                }
            }
            catch (InvalidOperationException invalidOpEx)
            {
                // Handle specific validation-related exceptions
                MessageBox.Show($"Validation Error: {invalidOpEx.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Optional: Log the error
                LogError(ex); // Ensure LogError is implemented if used
            }

            // Return a fallback value in case of failure
            return null;
        }
        private void PerformaInvoice_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                {
                    if (AreAnyTextBoxesFilled())
                    {
                        DialogResult result = MessageBox.Show(
                            "There are unsaved changes. Do you really want to close?",
                            "Confirm Close",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }

                    e.Handled = true; // Mark the event as handled
                }

            if (e.Control && e.KeyCode == Keys.C)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.DataSent += currencySelection_DataSent;
                currencySelection.ShowDialog();
            }

        }
        private void currencySelection_DataSent(CurrencyData receivedCurrency)
        {
            // Use the received data (e.g., display it in a label)
            currencylbl.Text = receivedCurrency.Name + (" : ") + receivedCurrency.Symbol;
            currencyidlbl.Text = receivedCurrency.CurrencyId.ToString();
            currencynamelbl.Text = receivedCurrency.Name.ToString();
            currencysymbollbl.Text = receivedCurrency.Symbol.ToString();
            currencystringlbl.Text = receivedCurrency.CurrencyString.ToString();
        }
        private void dgvsaleproducts_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Ensure DataGridView is not null and has rows
                    if (dgvsaleproducts == null || dgvsaleproducts.Rows.Count == 0)
                    {
                        MessageBox.Show("No records available to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Check if a row is selected
                    if (dgvsaleproducts.CurrentRow == null || dgvsaleproducts.CurrentRow.IsNewRow)
                    {
                        MessageBox.Show("Please select a valid row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate ProductID
                    if (int.TryParse(dgvsaleproducts.CurrentRow.Cells[3].Value?.ToString(), out int productId) && productId > 0)
                    {
                        // Remove all selected rows
                        foreach (DataGridViewRow row in dgvsaleproducts.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                dgvsaleproducts.Rows.Remove(row);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Product ID. Please select a valid row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.KeyCode == Keys.E)
                {
                    HandleRowSelectionAsync();
                }

        }
        private async void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the selectcustomer textbox is empty
                if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
                {
                    // Check if the CustomerSelectionForm is already open
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));

                    if (openForm == null)
                    {
                        // If the form is not open, create and show the form
                        CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Attach the FormClosed event handler in a standard way (instead of lambda)
                        customerSelectionForm.CustomerDataSelected += UpdateCustomerTextBox;

                        // Ensure proper disposal when the form is closed
                        await CommonFunction.DisposeOnCloseAsync(customerSelectionForm);

                        // Show the customer selection form
                        customerSelectionForm.Show();
                    }
                    else
                    {
                        // If the form is already open, bring it to the front
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors and show a message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        codetxtbox.Text = customercode.ToString();
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
        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                try
                {
                    // Check if the ProductSelectionForm is already open
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

                    if (openForm == null)
                    {
                        // If the form is not open, create and show a new ProductSelectionForm
                        ProductSelectionForm productSelection = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent
                        };

                        productSelection.ProductDataSelected += UpdateProductTextBox;

                        // Automatically dispose the form when it's closed
                        await CommonFunction.DisposeOnCloseAsync(productSelection);
                        productSelection.Show();
                    }
                    else
                    {
                        // If the form is already open, bring it to the front
                        openForm.BringToFront();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur
                    MessageBox.Show($"An error occurred while trying to open the Product Selection form: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
        private bool AreAnyTextBoxesFilled()
        {
            return AreTextBoxesFilledRecursive(this.Controls);
        }
        private bool AreTextBoxesFilledRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true;
                }

                // Check child controls (e.g., inside Panel, GroupBox)
                if (control.HasChildren)
                {
                    if (AreTextBoxesFilledRecursive(control.Controls))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private async void dgvsaleproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10,dgvsaleproducts,totaldiscounttxtbox);
        }
        private async void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11,dgvsaleproducts,nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
        }
        private async void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    // Check if the customer selection textbox is empty
                    if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
                    {
                        // Check if the CustomerSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
                        if (openForm == null)
                        {
                            // If the form is not open, create and show the CustomerSelectionForm
                            CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Properly subscribe to the FormClosed event
                            customerSelectionForm.CustomerDataSelected += UpdateCustomerTextBox;

                            // Ensure proper disposal when the form is closed
                            await CommonFunction.DisposeOnCloseAsync(customerSelectionForm);

                            // Show the CustomerSelectionForm
                            customerSelectionForm.Show();
                        }
                        else
                        {
                            // If the form is already open, bring it to the front
                            openForm.BringToFront();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control characters (like backspace), decimal point, and minus sign for numeric input
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true; // Ignore the input
            }

        }
        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            {
                try
                {
                    // Check if the product textbox is empty
                    if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                    {
                        // Check if the ProductSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                        if (openForm == null)
                        {
                            // If the form is not open, create and show the ProductSelectionForm
                            ProductSelectionForm productSelection = new ProductSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Subscribe to the FormClosed event to update the product textbox when the form is closed
                            productSelection.ProductDataSelected += UpdateProductTextBox;

                            // Dispose the form when it is closed and show it
                            await CommonFunction.DisposeOnCloseAsync(productSelection);
                            productSelection.Show();
                        }
                        else
                        {
                            // If the form is already open, bring it to the front
                            openForm.BringToFront();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the process
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            bool detailAdded = false;
            string invoiceNo = string.Empty;
            try
            {
                // Clear previous errors
                errorProvider.Clear();

                // Validate Customer Selection
                if (string.IsNullOrWhiteSpace(selectcustomertxtbox.Text))
                {
                    errorProvider.SetError(selectcustomertxtbox, "Please Select Customer.");
                    selectcustomertxtbox.Focus();
                    return;
                }

                // Extract common values
                DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                int customerId = Convert.ToInt32(customeridlbl.Text);
                string customerName = selectcustomertxtbox.Text;
                string salespersonName = salesmantxtbox.Text;
                float netTotal = ParseFloat(nettotaltxtbox.Text);
                float totalVat = ParseFloat(totalvattxtbox.Text);
                float totalDiscount = ParseFloat(totaldiscounttxtbox.Text);
                float shippingCharges = ParseFloat(shippingchargestxtbox.Text);

                // Handle Update
                if (savebtn.Text == "UPDATE")
                {
                    invoiceNo = invoicenotxtbox.Text;
                    string invoiceCode = invoicecodelbl.Text;
                    string tableName = "InvoiceTable";
                    string whereClause = $"InvoiceNo = '{invoiceNo}'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "InvoiceDate", invoiceDate },
                        { "ClientID", customerId },
                        { "UpdatedAt", DateTime.Now },
                        { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "InvoiceCode", invoiceCode },
                        { "ClientName", customerName },
                        { "NetTotal", netTotal },
                        { "TotalVat", totalVat },
                        { "TotalDiscount", totalDiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "SalePerson", salespersonName }
                    };

                    bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceNo, invoiceCode);
                    }
                }
                else
                {
                    // Handle Insert
                    invoiceNo = await CheckInvoiceBeforeInsert();
                    string invoiceCode = Guid.NewGuid().ToString();
                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "InvoiceDate", invoiceDate },
                        { "ClientID", customerId },
                        { "CreatedAt", DateTime.Now },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "InvoiceCode", invoiceCode },
                        { "NetTotal", netTotal },
                        { "ClientName", customerName },
                        { "TotalVat", totalVat },
                        { "TotalDiscount", totalDiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "SalePerson", salespersonName }
                    };

                    bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                    if (result)
                    {
                        foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // Extract row data
                            var subColumnData = GetInvoiceDetailData(invoiceNo, invoiceCode, row);
                            detailAdded = await DatabaseAccess.ExecuteQueryAsync("InvoiceDetailsTable", "INSERT", subColumnData);
                        }

                        detailAdded = true;
                    }
                }

                // Show View if Detail is Added
                if (detailAdded)
                {
                    ProformaInvoiceView proformaInvoiceView = new ProformaInvoiceView(invoiceNo);
                    proformaInvoiceView.MdiParent = Application.OpenForms["Dashboard"];
                    await CommonFunction.DisposeOnCloseAsync(proformaInvoiceView);
                    proformaInvoiceView.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private float ParseFloat(string text)
        {
            float.TryParse(text, out float result);
            return result;
        }
        private Dictionary<string, object> GetInvoiceDetailData(string invoiceNo, string invoiceCode, DataGridViewRow row)
        {
            return new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "InvoiceCode", invoiceCode },
                { "ProductID", Convert.ToInt32(row.Cells["productid"].Value) },
                { "Quantity", Convert.ToInt32(row.Cells["qtycolumn"].Value) },
                { "UnitSalePrice", ParseFloat(row.Cells["pricecolumn"].Value.ToString()) },
                { "ProductName", row.Cells["productnamecolumn"].Value.ToString() },
                { "MFR", row.Cells["codecolumn"].Value.ToString() },
                { "ItemWiseDiscount", ParseFloat(row.Cells["discountcolumn"].Value.ToString()) },
                { "ItemWiseVAT", ParseFloat(row.Cells["vatcolumn"].Value.ToString()) },
                { "ItemTotal", ParseFloat(row.Cells["totalcolumn"].Value.ToString()) },
                { "UnitID", Convert.ToInt32(row.Cells["unitidcolumn"].Value) },
                { "AddInventory", false },
                { "WarehouseID", Convert.ToInt32(row.Cells["warehouseidcolumn"].Value) },
                { "ItemDescription", row.Cells["itemdescriptioncolumn"].Value.ToString() },
                { "PricePerMeter", ParseFloat(row.Cells["lengthinmetercolumn"].Value.ToString()) },
                { "LengthInMeter", ParseFloat(row.Cells["pricepermetercolumn"].Value.ToString()) },
                { "MinusInventory", false },
                { "ItemAvailability", row.Cells["availabilitycolumn"].Value.ToString() }
            };
        }
        private async void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool detailAdded = false;

            try
            {
                // Insert backup and delete previous invoice details
                InsertBackUpData(invoiceNo, invoiceCode);
                DeleteInvoiceDetail(invoiceNo);

                // Iterate over each row in the sale products grid
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Extract data from the row
                    var rowData = ExtractRowData(row);

                    // Insert invoice detail data into the database
                    detailAdded = await InsertInvoiceDetail(invoiceNo, invoiceCode, rowData);
                }

                // If details were added successfully, show the proforma invoice view
                if (detailAdded)
                {
                    ShowProformaInvoiceView(invoiceNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private Dictionary<string, object> ExtractRowData(DataGridViewRow row)
        {
            return new Dictionary<string, object>
            {
                { "Productid", Convert.ToInt32(row.Cells["productid"].Value) },
                { "Quantity", Convert.ToInt32(row.Cells["qtycolumn"].Value) },
                { "UnitSalePrice", ParseFloat(row.Cells["pricecolumn"].Value.ToString()) },
                { "ProductName", row.Cells["productnamecolumn"].Value.ToString() },
                { "MFR", row.Cells["codecolumn"].Value.ToString() },
                { "ItemWiseDiscount", ParseFloat(row.Cells["discountcolumn"].Value.ToString()) },
                { "ItemWiseVAT", ParseFloat(row.Cells["vatcolumn"].Value.ToString()) },
                { "ItemTotal", ParseFloat(row.Cells["totalcolumn"].Value.ToString()) },
                { "Unitid", Convert.ToInt32(row.Cells["unitidcolumn"].Value) },
                { "Warehouseid", Convert.ToInt32(row.Cells["warehouseidcolumn"].Value) },
                { "ItemDescription", row.Cells["itemdescriptioncolumn"].Value.ToString() },
                { "PricePerMeter", ParseFloat(row.Cells["lengthinmetercolumn"].Value.ToString()) },
                { "LengthInMeter", ParseFloat(row.Cells["pricepermetercolumn"].Value.ToString()) },
                { "ItemAvailability", row.Cells["availabilitycolumn"].Value.ToString() },
                { "AddInventory", false },
                { "MinusInventory", false }
            };
        }
        // Helper Method: Insert Invoice Detail into Database
        private async Task<bool> InsertInvoiceDetail(string invoiceNo, string invoiceCode, Dictionary<string, object> rowData)
        {
            string subtable = "InvoiceDetailsTable";
            rowData["InvoiceNo"] = invoiceNo;
            rowData["InvoiceCode"] = invoiceCode;
            return await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", rowData);
        }

        // Helper Method: Show Proforma Invoice View
        private async void ShowProformaInvoiceView(string invoiceNo)
        {
            ProformaInvoiceView proformaInvoiceView = new ProformaInvoiceView(invoiceNo);
            proformaInvoiceView.MdiParent = Application.OpenForms["Dashboard"];
            await CommonFunction.DisposeOnCloseAsync(proformaInvoiceView);
            proformaInvoiceView.Show();
            this.Close();
        }
        private async void InsertBackUpData(string invoiceNo, string invoicecode)
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

                string subtable = "InvoiceDetailsTableBackUp";
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
                    { "MinusInventory", false },
                    { "ItemAvailability", availabilitystatus }
                };

                await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
            }
        }
        private async void DeleteInvoiceDetail(string invoiceNo)
        {
            try
            {
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                // Executes the DELETE query
                bool success = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

                // Optionally, you can log the success/failure of the query execution
                if (!success)
                {
                    // Log the failure or handle accordingly
                    Console.WriteLine("Failed to delete invoice details for InvoiceNo: " + invoiceNo);
                }
            }
            catch (Exception ex)
            {
                // Log the exception details for better debugging
                Console.WriteLine("Error occurred: " + ex.Message);
                // Optionally log stack trace or inner exception details
                Console.WriteLine("Stack Trace: " + ex.StackTrace);

                // Throw the original exception to maintain the stack trace
                throw;
            }

        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that all required fields are not empty or whitespace
                if (string.IsNullOrWhiteSpace(selectproducttxtbox.Text) ||
                    string.IsNullOrWhiteSpace(mfrtxtbox.Text) ||
                    string.IsNullOrWhiteSpace(qtytxtbox.Text) ||
                    string.IsNullOrWhiteSpace(productidlbl.Text) ||
                    string.IsNullOrWhiteSpace(unitidlbl.Text) ||
                    string.IsNullOrWhiteSpace(unitsalepricelbl.Text) ||
                    string.IsNullOrWhiteSpace(totalcolumnlbl.Text) ||
                    string.IsNullOrWhiteSpace(warehouseidlbl.Text))
                {
                    MessageBox.Show("Please ensure all fields are filled out before adding a product.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse values and handle invalid inputs
                string mfr = mfrtxtbox.Text;
                string productid = productidlbl.Text;
                string productname = selectproducttxtbox.Text;
                string qty = qtytxtbox.Text;
                int unitid = Convert.ToInt32(unitidlbl.Text);
                decimal vatamount = 0, discount = 0, finalitemwise = 0, lengthinmeterproduct = 0, priceinmeter = 0;
                int warehouseid = 0;

                // Try parsing values and check for errors
                if (!int.TryParse(unitidlbl.Text, out unitid))
                {
                    MessageBox.Show("Invalid unit ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(productvatlbl.Text, out vatamount))
                {
                    MessageBox.Show("Invalid VAT amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(productdiscountlbl.Text, out discount))
                {
                    MessageBox.Show("Invalid discount amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!float.TryParse(unitsalepricelbl.Text, out float unitprice))
                {
                    MessageBox.Show("Invalid unit price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(totalcolumnlbl.Text, out finalitemwise))
                {
                    MessageBox.Show("Invalid final item total.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(warehouseidlbl.Text, out warehouseid))
                {
                    MessageBox.Show("Invalid warehouse ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(lengthinmeterlbl.Text, out lengthinmeterproduct))
                {
                    MessageBox.Show("Invalid length in meter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(pricepermeterlbl.Text, out priceinmeter))
                {
                    MessageBox.Show("Invalid price per meter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string itemwisedescription = itemdescriptionlbl.Text;
                string availability = availabilitystatuslbl.Text;

                bool productExists = false;
                bool priceMismatch = false;

                // Iterate through the DataGridView to check if the product exists and if the price matches
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Check if the product ID exists
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productid)
                        {
                            // Check if the price matches
                            if (float.Parse(row.Cells["pricecolumn"].Value.ToString()) != unitprice)
                            {
                                priceMismatch = true;
                            }
                            else
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qty);
                                productExists = true;
                            }
                            break;
                        }
                    }
                }

                // If the product doesn't exist, add it to the DataGridView
                if (!productExists)
                {
                    dgvsaleproducts.Rows.Add("",mfr, productid, productname, qty, availability, unitid, unitnamelbl.Text, unitprice,
                        vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter);
                }

                // Clear the textboxes and reset global variables
                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                // Focus on the product textbox
                selectproducttxtbox.Focus();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("There was an error parsing one of the fields. Please check the input values.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of the PerformaInvoice form
                PerformaInvoice performaInvoice = new PerformaInvoice();

                // Set the MDI parent form to the currently open "Dashboard" form
                if (Application.OpenForms["Dashboard"] != null)
                {
                    performaInvoice.MdiParent = Application.OpenForms["Dashboard"];
                }
                else
                {
                    MessageBox.Show("Dashboard form is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Handle disposal of the form when it is closed (assuming DisposeOnClose is a custom method)
                await CommonFunction.DisposeOnCloseAsync(performaInvoice);

                // Show the PerformaInvoice form
                performaInvoice.Show();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors that may occur during form creation or handling
                MessageBox.Show($"An error occurred while opening the form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        bool shouldOpenForm = false;
                        if (result != null && result.Rows.Count > 0)
                        {
                            foreach (DataRow row in result.Rows)
                            {
                                // Assuming the column name for quantity is "TotalQuantity"
                                int quantity = row["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(row["TotalQuantity"]) : 0;

                                // Check if the quantity is greater than zero
                                if (quantity > 0 && quantity > Convert.ToInt32(qtytxtbox.Text))
                                {
                                    shouldOpenForm = true;
                                    break; // No need to check further rows, form will be opened
                                }
                            }

                            if (shouldOpenForm)
                            {
                                // Create the WarehouseQty form
                                WarehouseQty warehouseQty = new WarehouseQty(result)
                                {
                                    WindowState = FormWindowState.Normal,
                                    StartPosition = FormStartPosition.CenterParent,
                                };

                                // Event to handle closing the current form and opening the new one
                                warehouseQty.FormClosed += WarehouseQty_FormClosed;

                                // Show the WarehouseQty form
                                warehouseQty.ShowDialog();
                            }
                            else
                            {
                                ItemAvailability itemAvailability = new ItemAvailability()
                                {
                                    WindowState = FormWindowState.Normal,
                                    StartPosition = FormStartPosition.CenterParent,
                                };

                                itemAvailability.FormClosed += ItemAvailability_FormClosed;
                                itemAvailability.ShowDialog();
                            }
                        }


                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        // Event handler for when WarehouseQty form is closed
        private async void WarehouseQty_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                await CommonFunction.DisposeOnCloseAsync((WarehouseQty)sender);

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
                await CommonFunction.DisposeOnCloseAsync(vATForm);
                vATForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void ItemAvailability_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                await CommonFunction.DisposeOnCloseAsync((ItemAvailability)sender);

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
                await CommonFunction.DisposeOnCloseAsync(vATForm);
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
                availabilitystatuslbl.Invoke((Action)(() => availabilitystatuslbl.Text = GlobalVariables.availabilitystatus ?? "IN STOCK"));
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
                GlobalVariables.availabilitystatus = null;
            });
        }

        private async void dgvsaleproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
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

        private void dgvsaleproducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
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

                string unitname = selectedRow.Cells["unitnamecolumn"].Value?.ToString() ?? null;

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

                // Open the edit dialog asynchronously

                EditItemInvoice editItemInvoice = new EditItemInvoice(rowIndex, productmfr, productname, productid, quantity, unitid, unitname, price,
                    vat, discount, itemtotal, warehouseid, itemdescription, lengthinmeter, priceinmeter, vatpercentage);
                editItemInvoice.ShowDialog(); // This will still block but in a separate thread.

            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }
}
