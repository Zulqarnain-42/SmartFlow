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
using System.Diagnostics;

namespace SmartFlow.Sales
{
    public partial class PerformaInvoice : Form
    {
        private decimal qty = 0;
        private decimal total = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;

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
            await LoadInvoiceAsync();
        }

        public async Task LoadInvoiceAsync()
        {
            try
            {
                if ((_dtinvoice?.Rows.Count > 0) || (_dtinvoicedetails?.Rows.Count > 0))
                {
                    DataRow row = _dtinvoice.Rows[0];

                    // Simplified data assignment using helper methods
                    AssignTextBoxValues(row);

                    // Load grid data efficiently
                    AddGridData(_dtinvoicedetails);

                    savebtn.Text = "UPDATE";
                }
                else
                {
                    await LoadDefaultInvoiceValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AssignTextBoxValues(DataRow row)
        {
            try
            {
                invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;

                // Handle invoice date conversion safely
                if (row["invoicedate"] != DBNull.Value && DateTime.TryParse(row["invoicedate"].ToString(), out DateTime invoiceDate))
                {
                    invoicedatetxtbox.Text = invoiceDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    invoicedatetxtbox.Text = string.Empty;
                }

                codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;
                selectcustomertxtbox.Text = row["AccountSubControlName"]?.ToString() ?? string.Empty;
                companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
                mobiletxtbox.Text = row["MobileNo"]?.ToString() ?? string.Empty;
                customeridlbl.Text = row["ClientID"]?.ToString() ?? string.Empty;

                // Ensure numerical values default to "0" if invalid
                totalvattxtbox.Text = decimal.TryParse(row["TotalVat"]?.ToString(), out decimal totalVat) ? totalVat.ToString("N2") : "0";
                totaldiscounttxtbox.Text = decimal.TryParse(row["TotalDiscount"]?.ToString(), out decimal totalDiscount) ? totalDiscount.ToString("N2") : "0";
                shippingchargestxtbox.Text = decimal.TryParse(row["FreightShippingCharges"]?.ToString(), out decimal shippingCharges) ? shippingCharges.ToString("N2") : "0";

                salesmantxtbox.Text = row["SalePerson"]?.ToString() ?? string.Empty;
                currencyidlbl.Text = row["Currencyid"]?.ToString() ?? string.Empty;
                currencynamelbl.Text = row["CurrencyName"]?.ToString() ?? string.Empty;
                currencysymbollbl.Text = row["CurrencySymbol"]?.ToString() ?? string.Empty;
                currencyconversionratelbl.Text = row["ConversionRate"]?.ToString() ?? string.Empty;

                // Handle currency name and symbol safely
                string currencyName = row["CurrencyName"]?.ToString() ?? string.Empty;
                string currencySymbol = row["CurrencySymbol"]?.ToString() ?? string.Empty;
                currencylbl.Text = !string.IsNullOrWhiteSpace(currencyName) && !string.IsNullOrWhiteSpace(currencySymbol)
                    ? $"{currencyName} : {currencySymbol}"
                    : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error populating invoice fields: {ex.Message}");
                MessageBox.Show("An error occurred while loading the invoice details. Please check the data and try again.",
                                "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task LoadDefaultInvoiceValues()
        {
            try
            {
                await Task.Delay(500); // Simulate async loading

                // Ensure total and qty are valid before formatting
                string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                string totalString = total >= 0 ? total.ToString("0.00") : "0.00";
                string qtyString = qty >= 0 ? qty.ToString("0") : "0";

                // Assign values safely
                invoicedatetxtbox.Text = currentDate;
                qtytxtbox.Text = qtyString;
                nettotaltxtbox.Text = totalString;
                totaldiscounttxtbox.Text = totalString;
                totalvattxtbox.Text = totalString;

                // Handle async method safely
                try
                {
                    invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating invoice number: {ex.Message}");
                    MessageBox.Show("Failed to generate the next invoice number. Please try again.",
                                    "Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    invoicenotxtbox.Text = "Error"; // Provide fallback text
                }

                shippingchargestxtbox.Text = total >= 0 ? total.ToString("N2") : "0.00";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting invoice details: {ex.Message}");
                MessageBox.Show("An unexpected error occurred while loading invoice details. Please check your input and try again.",
                                "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddGridData(DataTable invoiceDetails)
        {
            if (invoiceDetails == null || invoiceDetails.Rows.Count == 0)
                return;

            try
            {
                dgvsaleproducts.SuspendLayout();
                dgvsaleproducts.VirtualMode = false; // Ensure real-time updates
                dgvsaleproducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvsaleproducts.AllowUserToAddRows = false; // Prevent ghost rows

                List<DataGridViewRow> newRows = new List<DataGridViewRow>();

                foreach (DataRow invoiceRow in invoiceDetails.Rows)
                {
                    var newRow = new DataGridViewRow();
                    newRow.CreateCells(dgvsaleproducts);

                    try
                    {
                        newRow.Cells[dgvsaleproducts.Columns["vatcolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["ItemWiseVAT"]);
                        newRow.Cells[dgvsaleproducts.Columns["discountcolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["ItemWiseDiscount"]);
                        newRow.Cells[dgvsaleproducts.Columns["totalcolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["ItemTotal"]);
                        newRow.Cells[dgvsaleproducts.Columns["productnamecolumn"].Index].Value = SafeConvertToString(invoiceRow["ProductName"]);
                        newRow.Cells[dgvsaleproducts.Columns["pricecolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["UnitSalePrice"]);
                        newRow.Cells[dgvsaleproducts.Columns["warehouseidcolumn"].Index].Value = SafeConvertToInt(invoiceRow["Warehouseid"]);
                        newRow.Cells[dgvsaleproducts.Columns["itemdescriptioncolumn"].Index].Value = SafeConvertToString(invoiceRow["ItemDescription"]);
                        newRow.Cells[dgvsaleproducts.Columns["lengthinmetercolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["LengthInMeter"]);
                        newRow.Cells[dgvsaleproducts.Columns["pricepermetercolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["PricePerMeter"]);
                        newRow.Cells[dgvsaleproducts.Columns["productid"].Index].Value = SafeConvertToInt(invoiceRow["Productid"]);
                        newRow.Cells[dgvsaleproducts.Columns["unitidcolumn"].Index].Value = SafeConvertToInt(invoiceRow["Unitid"]);
                        newRow.Cells[dgvsaleproducts.Columns["unitname"].Index].Value = SafeConvertToString(invoiceRow["UnitName"]);
                        newRow.Cells[dgvsaleproducts.Columns["qtycolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["Quantity"]);
                        newRow.Cells[dgvsaleproducts.Columns["vatpercentagecolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["VatCode"]);
                        newRow.Cells[dgvsaleproducts.Columns["codecolumn"].Index].Value = SafeConvertToString(invoiceRow["MFR"]);
                        newRow.Cells[dgvsaleproducts.Columns["availabilitycolumn"].Index].Value = SafeConvertToString(invoiceRow["ItemAvailability"]);

                        newRow.Height = 25;
                        newRows.Add(newRow);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[Error] Processing row: {ex.Message}");
                    }
                }

                dgvsaleproducts.Rows.AddRange(newRows.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Error] AddGridData: {ex.Message}");
            }
            finally
            {
                dgvsaleproducts.ResumeLayout();
                this.Invoke((MethodInvoker)delegate { dgvsaleproducts.Refresh(); });
            }
        }


        private decimal SafeConvertToDecimal(object value)
        {
            if (value == DBNull.Value || value == null)
                return 0m;
            return decimal.TryParse(value.ToString(), out decimal result) ? result : 0m;
        }

        private int SafeConvertToInt(object value)
        {
            if (value == DBNull.Value || value == null)
                return 0;
            return int.TryParse(value.ToString(), out int result) ? result : 0;
        }

        private string SafeConvertToString(object value)
        {
            return value != DBNull.Value && value != null ? value.ToString() : "";
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
                
            }
            
            // Ensure a safe return value
            return lastInvoiceNumber ?? string.Empty; // Return an empty string if no valid invoice number is found
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
            }

            // Return a fallback value in case of failure
            return null;
        }

        private void PerformaInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    try
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
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while checking unsaved changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.Control && e.KeyCode == Keys.Q && savebtn.Text != "UPDATE")
                {
                    try
                    {
                        SearchQuotationForm searchQuotationForm = new SearchQuotationForm();
                        // Subscribe to event
                        searchQuotationForm.DataSelected += (data) =>
                        {
                            try
                            {
                                AddGridData(data);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while adding data to the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };
                        searchQuotationForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the Search Quotation form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.Control && e.KeyCode == Keys.C)
                {
                    try
                    {
                        CurrencySelection currencySelection = new CurrencySelection();
                        currencySelection.DataSent += currencySelection_DataSent;
                        currencySelection.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the Currency Selection form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // This will catch any unexpected errors in the overall key press handling
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }
        private void dgvsaleproducts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Ensure there is a selected row
                    if (dgvsaleproducts.CurrentRow == null || dgvsaleproducts.CurrentRow.Cells["productid"].Value == null)
                    {
                        MessageBox.Show("No product selected. Please select a row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Attempt to convert product ID safely
                    if (int.TryParse(dgvsaleproducts.CurrentRow.Cells["productid"].Value.ToString(), out int productid) && productid > 0)
                    {
                        // Remove selected rows safely
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
                        MessageBox.Show("Invalid product ID. Please select a valid row.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (e.KeyCode == Keys.E)
                {
                    try
                    {
                        HandleRowSelectionAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error handling row selection: {ex.Message}");
                        MessageBox.Show("An error occurred while handling row selection. Please try again.", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in KeyDown event: {ex.Message}");
                MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(selectcustomertxtbox.Text))
                {
                    Form openForm = null;

                    try
                    {
                        openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error checking if form is open: {ex.Message}");
                        MessageBox.Show("An error occurred while checking for an open form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (openForm == null)
                    {
                        try
                        {
                            CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };
                            customerSelectionForm.CustomerDataSelected += UpdateCustomerTextBox;

                            CommonFunction.DisposeOnClose(customerSelectionForm);
                            customerSelectionForm.Show();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error opening CustomerSelectionForm: {ex.Message}");
                            MessageBox.Show("An error occurred while opening the customer selection form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            openForm.BringToFront();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error bringing form to front: {ex.Message}");
                            MessageBox.Show("An error occurred while bringing the customer selection form to the front.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (string.IsNullOrWhiteSpace(selectproducttxtbox.Text))
                {
                    Form openForm = null;

                    try
                    {
                        openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error checking if ProductSelectionForm is open: {ex.Message}");
                        MessageBox.Show("An error occurred while checking for an open product selection form.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (openForm == null)
                    {
                        try
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
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error opening ProductSelectionForm: {ex.Message}");
                            MessageBox.Show("An error occurred while opening the product selection form.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            openForm.BringToFront();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error bringing ProductSelectionForm to front: {ex.Message}");
                            MessageBox.Show("An error occurred while bringing the product selection form to the front.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                MessageBox.Show("An unexpected error occurred. Please try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            if (selectcustomertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvsaleproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
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
                            CommonFunction.DisposeOnClose(customerSelectionForm);

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
            // Ensure that the text remains numeric after any changes
            if (System.Text.RegularExpressions.Regex.IsMatch(qtytxtbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                qtytxtbox.Text = qtytxtbox.Text.Remove(qtytxtbox.Text.Length - 1);
            }

        }
        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(selectproducttxtbox.Text))
                    {
                        Form openForm = null;

                        try
                        {
                            openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error checking if ProductSelectionForm is open: {ex.Message}");
                            MessageBox.Show("An error occurred while checking for an open product selection form.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (openForm == null)
                        {
                            try
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
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error opening ProductSelectionForm: {ex.Message}");
                                MessageBox.Show("An error occurred while opening the product selection form.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            try
                            {
                                openForm.BringToFront();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error bringing ProductSelectionForm to front: {ex.Message}");
                                MessageBox.Show("An error occurred while bringing the product selection form to the front.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                MessageBox.Show("An unexpected error occurred. Please try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    // Define the custom date format and UK culture
                    string format = "dd/MM/yyyy";
                    var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture

                    // Parse startDate and endDate from the textboxes using the custom format
                    DateTime invoiceDate;

                    // Try parsing the dates from the textboxes with the exact format
                    if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                    {
                        // Date parsing was successful
                        Console.WriteLine($"Start Date: {invoiceDate}");
                    }
                    else
                    {
                        invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    }
                    if (savebtn.Text == "UPDATE")
                    {
                        invoiceNo = invoicenotxtbox.Text;
                        await UpdatePerformaInvoice(invoiceNo, invoiceDate);

                    }
                    else
                    {
                        invoiceNo = await CheckInvoiceBeforeInsert();
                        detailadded = await AddPerformaInvoice(invoiceNo, invoiceDate);
                    }

                    if (detailadded)
                    {
                        ProformaInvoiceView proformaInvoiceView = new ProformaInvoiceView(invoiceNo);
                        proformaInvoiceView.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(proformaInvoiceView);
                        proformaInvoiceView.Show();
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

        private async Task UpdatePerformaInvoice(string invoiceNo, DateTime invoiceDate)
        {
            try
            {
                int customerId;
                float nettotal, totalvat, totaldiscount, shippingcharges;
                int currencyid;

                // Safely parsing and handling exceptions
                if (!int.TryParse(customeridlbl.Text, out customerId))
                {
                    MessageBox.Show("Invalid Customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!float.TryParse(nettotaltxtbox.Text, out nettotal) ||
                    !float.TryParse(totalvattxtbox.Text, out totalvat) ||
                    !float.TryParse(totaldiscounttxtbox.Text, out totaldiscount) ||
                    !float.TryParse(shippingchargestxtbox.Text, out shippingcharges))
                {
                    MessageBox.Show("Invalid numeric values for totals or shipping charges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(currencyidlbl.Text, out currencyid))
                {
                    MessageBox.Show("Invalid Currency ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve text fields safely
                string customercode = codetxtbox.Text.Trim();
                string customername = selectcustomertxtbox.Text.Trim();
                string customerrefrence = companytxtbox.Text.Trim();
                string mobile = mobiletxtbox.Text.Trim();
                string salespersonname = salesmantxtbox.Text.Trim();
                string invoiceCode = invoicecodelbl.Text.Trim();
                string currencyname = currencynamelbl.Text.Trim();
                string currencyconversionrate = currencyconversionratelbl.Text.Trim();
                string currencysymbol = currencysymbollbl.Text.Trim();

                string tableName = "InvoiceTable";
                string whereClause = $"InvoiceNo = '{invoiceNo}'";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "invoicedate", invoiceDate },
                    { "ClientID", customerId },
                    { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }, // Fixed hour formatting (HH for 24-hour format)
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
                    { "ConversionRate", currencyconversionrate },
                    { "AddedBy", "JEAN" },
                    { "InvoiceType", "Performa" }
                };

                bool isUpdated = false;

                try
                {
                    isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show($"Database update failed: {dbEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isUpdated)
                {
                    try
                    {
                        UpdateInvoiceDetailsData(invoiceNo, invoiceCode);
                    }
                    catch (Exception updateEx)
                    {
                        MessageBox.Show($"Error updating invoice details: {updateEx.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invoice update failed. Please check your data and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task<bool> AddPerformaInvoice(string invoiceNo, DateTime invoiceDate)
        {
            bool isCompleted = false;

            try
            {
                int customerid;
                int currencyid;
                float nettotal, totalvat, totaldiscount, shippingcharges;

                // Safely parse integer & float values
                if (!int.TryParse(customeridlbl.Text, out customerid) ||
                    !int.TryParse(currencyidlbl.Text, out currencyid) ||
                    !float.TryParse(nettotaltxtbox.Text, out nettotal) ||
                    !float.TryParse(totalvattxtbox.Text, out totalvat) ||
                    !float.TryParse(totaldiscounttxtbox.Text, out totaldiscount) ||
                    !float.TryParse(shippingchargestxtbox.Text, out shippingcharges))
                {
                    MessageBox.Show("Invalid numeric input detected. Please check the entered values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Generate a unique invoice code
                string invoicecode = Guid.NewGuid().ToString();

                // Retrieve text field values
                string customercode = codetxtbox.Text.Trim();
                string customername = selectcustomertxtbox.Text.Trim();
                string customerrefrence = companytxtbox.Text.Trim();
                string mobile = mobiletxtbox.Text.Trim();
                string salespersonname = salesmantxtbox.Text.Trim();
                string currencyname = currencynamelbl.Text.Trim();
                string currencyconversionrate = currencyconversionratelbl.Text.Trim();
                string currencysymbol = currencysymbollbl.Text.Trim();

                string tableName = "InvoiceTable";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "invoicedate", invoiceDate },
                    { "ClientID", customerid },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }, // Fixed date format
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
                    { "ConversionRate", currencyconversionrate },
                    { "AddedBy", "JEAN" },
                    { "InvoiceType", "Performa" }
                };

                bool result = false;
                try
                {
                    result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (result)
                {
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (row.IsNewRow) continue;

                        try
                        {
                            int productid = row.Cells["productid"].Value is int ? (int)row.Cells["productid"].Value : 0;
                            int quantity = row.Cells["qtycolumn"].Value is int ? (int)row.Cells["qtycolumn"].Value : 0;
                            int unitid = row.Cells["unitidcolumn"].Value is int ? (int)row.Cells["unitidcolumn"].Value : 0;
                            int warehouseid = row.Cells["warehouseidcolumn"].Value is int ? (int)row.Cells["warehouseidcolumn"].Value : 0;
                            float unitprice = row.Cells["pricecolumn"].Value is float ? (float)row.Cells["pricecolumn"].Value : 0f;
                            float discount = row.Cells["discountcolumn"].Value is float ? (float)row.Cells["discountcolumn"].Value : 0f;
                            float vat = row.Cells["vatcolumn"].Value is float ? (float)row.Cells["vatcolumn"].Value : 0f;
                            float total = row.Cells["totalcolumn"].Value is float ? (float)row.Cells["totalcolumn"].Value : 0f;
                            float pricepermeter = row.Cells["lengthinmetercolumn"].Value is float ? (float)row.Cells["lengthinmetercolumn"].Value : 0f;
                            float lengthinmeter = row.Cells["pricepermetercolumn"].Value is float ? (float)row.Cells["pricepermetercolumn"].Value : 0f;
                            float vatpercentage = row.Cells["vatpercentagecolumn"].Value is float ? (float)row.Cells["vatpercentagecolumn"].Value : 0f;

                            string productname = row.Cells["productnamecolumn"].Value?.ToString() ?? string.Empty;
                            string mfr = row.Cells["codecolumn"].Value?.ToString() ?? string.Empty;
                            string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value?.ToString() ?? string.Empty;
                            string availabilitystatus = row.Cells["availabilitycolumn"].Value?.ToString() ?? string.Empty;

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
                                { "MinusInventory", false },
                                { "ItemAvailability", availabilitystatus },
                                { "IsNewRecord", true },
                                { "VatCode", vatpercentage }
                            };

                            bool subResult = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);

                            if (!subResult)
                            {
                                MessageBox.Show($"Failed to insert product details for Product ID: {productid}", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            isCompleted = true;
                        }
                        catch (Exception rowEx)
                        {
                            MessageBox.Show($"Error processing row data: {rowEx.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invoice insertion failed. Please try again.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return isCompleted;
        }

        private async void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool detailAdded = false;
            List<Dictionary<string, object>> invoiceDetails = new List<Dictionary<string, object>>();

            // **Step 1: Collect and Validate All Records Once**
            foreach (DataGridViewRow row in dgvsaleproducts.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    int productid = row.Cells["productid"].Value != null ? Convert.ToInt32(row.Cells["productid"].Value) : 0;
                    int quantity = row.Cells["qtycolumn"].Value != null ? Convert.ToInt32(row.Cells["qtycolumn"].Value) : 0;
                    float unitprice = row.Cells["pricecolumn"].Value != null ? float.Parse(row.Cells["pricecolumn"].Value.ToString()) : 0f;
                    string productname = row.Cells["productnamecolumn"].Value?.ToString() ?? string.Empty;
                    string mfr = row.Cells["codecolumn"].Value?.ToString() ?? string.Empty;
                    float discount = row.Cells["discountcolumn"].Value != null ? float.Parse(row.Cells["discountcolumn"].Value.ToString()) : 0f;
                    float vat = row.Cells["vatcolumn"].Value != null ? float.Parse(row.Cells["vatcolumn"].Value.ToString()) : 0f;
                    float total = row.Cells["totalcolumn"].Value != null ? float.Parse(row.Cells["totalcolumn"].Value.ToString()) : 0f;
                    int unitid = row.Cells["unitidcolumn"].Value != null ? Convert.ToInt32(row.Cells["unitidcolumn"].Value) : 0;
                    int warehouseid = row.Cells["warehouseidcolumn"].Value != null ? Convert.ToInt32(row.Cells["warehouseidcolumn"].Value) : 0;
                    string itemDescription = row.Cells["itemdescriptioncolumn"].Value?.ToString() ?? string.Empty;
                    float pricePerMeter = row.Cells["pricepermetercolumn"].Value != null ? float.Parse(row.Cells["pricepermetercolumn"].Value.ToString()) : 0f;
                    float lengthInMeter = row.Cells["lengthinmetercolumn"].Value != null ? float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString()) : 0f;
                    string availabilityStatus = row.Cells["availabilitycolumn"].Value?.ToString() ?? string.Empty;
                    float vatPercentage = row.Cells["vatpercentagecolumn"].Value != null ? float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString()) : 0f;

                    invoiceDetails.Add(new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "Invoicecode", invoiceCode },
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
                        { "ItemDescription", itemDescription },
                        { "PricePerMeter", pricePerMeter },
                        { "LengthInMeter", lengthInMeter },
                        { "MinusInventory", false },
                        { "ItemAvailability", availabilityStatus },
                        { "IsNewRecord", true },
                        { "VatCode", vatPercentage }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // **Step 2: Validate & Insert into Database**
            if (invoiceDetails.Count > 0)
            {
                bool isOldRecord = await UpdateInvoiceDetail(invoiceNo);

                foreach (var record in invoiceDetails)
                {
                    detailAdded = await DatabaseAccess.ExecuteQueryAsync("InvoiceDetailsTable", "INSERT", record);
                }

                // **Step 3: Show Updated Invoice View if Data Inserted**
                if (detailAdded)
                {
                    ProformaInvoiceView proformaInvoiceView = new ProformaInvoiceView(invoiceNo)
                    {
                        MdiParent = Application.OpenForms["Dashboard"]
                    };
                    CommonFunction.DisposeOnClose(proformaInvoiceView);
                    proformaInvoiceView.Show();
                    this.Close();
                }
            }
        }


        private async Task<bool> UpdateInvoiceDetail(string invoiceNo)
        {
            try
            {
                bool isoldupdated = false;
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                isoldupdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);
                return isoldupdated;
            }
            catch (Exception ex) { throw ex; }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                !string.IsNullOrWhiteSpace(qtytxtbox.Text))
            {
                try
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
                        if (!row.IsNewRow && row.Cells["ProductID"].Value != null)
                        {
                            if (row.Cells["ProductID"].Value.ToString() == productidlbl.Text &&
                                float.Parse(row.Cells["pricecolumn"].Value.ToString()) == unitprice)
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                decimal currentVat = decimal.Parse(row.Cells["vatcolumn"].Value.ToString());
                                decimal currentDiscount = decimal.Parse(row.Cells["discountcolumn"].Value.ToString());
                                decimal currentitemTotal = decimal.Parse(row.Cells["totalcolumn"].Value.ToString());

                                // Update quantities and amounts
                                row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                                row.Cells["vatcolumn"].Value = Math.Round(currentVat + vatamount, 2);
                                row.Cells["discountcolumn"].Value = Math.Round(currentDiscount + discount, 2);
                                row.Cells["totalcolumn"].Value = Math.Round(currentitemTotal + finalitemwise, 2);

                                productExists = true;
                                break;
                            }
                        }
                    }

                    if (!productExists)
                    {
                        dgvsaleproducts.Rows.Add("", mfr, productid, productname, qty, availability, unitid, unitname, unitprice,
                            vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise.ToString("N2"), warehouseid, itemwisedescription,
                            lengthinmeterproduct, priceinmeter, vatpercentage, discountpercentage, discounttype);
                    }

                    ResetLabelData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void newbtn_Click(object sender, EventArgs e)
        {
            PerformaInvoice performaInvoice = new PerformaInvoice();
            performaInvoice.MdiParent = Application.OpenForms["Dashboard"];
            CommonFunction.DisposeOnClose(performaInvoice);
            performaInvoice.Show();
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
                                WarehouseQty warehouseQty = new WarehouseQty(result,false)
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

        private void ItemAvailability_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((ItemAvailability)sender);

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
                // Update a label if the value is valid or fallback to a default value
                void UpdateLabel(Label label, Func<string> valueProvider, string defaultValue)
                {
                    label.Invoke((Action)(() => label.Text = valueProvider() ?? defaultValue));
                }

                UpdateLabel(warehouseidlbl, () => GlobalVariables.warehouseidglobal != 0 ? GlobalVariables.warehouseidglobal.ToString() : "0", "0");
                UpdateLabel(itemdescriptionlbl, () => GlobalVariables.productitemwisedescriptiongloabl, "N/A");
                UpdateLabel(unitsalepricelbl, () => GlobalVariables.productpriceglobal != 0 ? GlobalVariables.productpriceglobal.ToString("0.00") : "0.00", "0.00");
                UpdateLabel(pricepermeterlbl, () => GlobalVariables.productinmeterprice != 0 ? GlobalVariables.productinmeterprice.ToString("0.00") : "0.00", "0.00");
                UpdateLabel(lengthinmeterlbl, () => GlobalVariables.productinmeterlength != 0 ? GlobalVariables.productinmeterlength.ToString("0.00") : "0.00", "0.00");
                UpdateLabel(totalcolumnlbl, () => GlobalVariables.productfinalamountwithvatanddiscountitemwise != 0 ? GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("0.00") : "0.00", "0.00");
                UpdateLabel(unitnamelbl, () => GlobalVariables.unitnameglobal, "N/A");
                UpdateLabel(unitidlbl, () => GlobalVariables.unitidglobal != 0 ? GlobalVariables.unitidglobal.ToString() : "0", "0");
                UpdateLabel(productdiscountlbl, () => GlobalVariables.productdiscountamountitemwise != 0 ? GlobalVariables.productdiscountamountitemwise.ToString("0.00") : "0.00", "0.00");
                UpdateLabel(productvatlbl, () => GlobalVariables.productitemwisevatamount != 0 ? GlobalVariables.productitemwisevatamount.ToString("0.00") : "0.00", "0.00");
                UpdateLabel(vatcodelbl, () => GlobalVariables.productitemwisevatpercentage != 0 ? GlobalVariables.productitemwisevatpercentage.ToString() : "0", "0");
                UpdateLabel(availabilitystatuslbl, () => GlobalVariables.availabilitystatus, "IN STOCK");
                UpdateLabel(discountpercentagelbl, () => GlobalVariables.discountpercentage != 0 ? GlobalVariables.discountpercentage.ToString() : "0", "0");
                UpdateLabel(discounttypelbl, () => GlobalVariables.productdiscounttype != false ? GlobalVariables.productdiscounttype.ToString() : "false", "false");

                ResetGlobalVariables();
            });
        }


        private void ResetGlobalVariables()
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
                try
                {
                    // Iterate through the DataGridView rows
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (row.IsNewRow) continue; // Skip the new row

                        if (row.Cells["vatcolumn"] != null && row.Cells["totalcolumn"] != null) // Ensure columns exist
                        {
                            try
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
                            catch (FormatException ex)
                            {
                                // Handle specific format exceptions (e.g., if the cell contains invalid data)
                                MessageBox.Show($"Error parsing VAT or Total for product in row {row.Index}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                // Handle any other exceptions that may occur
                                MessageBox.Show($"An unexpected error occurred while processing row {row.Index}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during the entire process
                    MessageBox.Show($"An error occurred while removing VAT: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (dgvsaleproducts.SelectedRows.Count > 0) // Check if any row is selected
                {
                    try
                    {
                        DataGridViewRow selectedRow = dgvsaleproducts.SelectedRows[0]; // Get the first selected row
                        int rowIndex = selectedRow.Index;

                        // Safely retrieve and parse values with error handling
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
                    catch (FormatException ex)
                    {
                        // Handle specific format exceptions, e.g., invalid number format
                        MessageBox.Show($"Error processing selected row: {ex.Message}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidCastException ex)
                    {
                        // Handle invalid type conversion (e.g., invalid casting of data types)
                        MessageBox.Show($"Error converting data for the selected row: {ex.Message}", "Cast Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Handle any other unexpected exceptions
                        MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Handle the case where no row is selected
                    MessageBox.Show("No row selected. Please select a row to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any exception that might occur during the overall process
                MessageBox.Show($"An error occurred while processing the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditItemInvoice_DataUpdated(int rowIndex, string productmfr, string productname, int productid, int quantity, int unitid, string unitname,
                                               decimal price, decimal vat, decimal discount, decimal itemtotal, int warehouseid, string itemdescription,
                                               decimal lengthinmeter, decimal priceinmeter, decimal vatpercentage, decimal discountpercentage, bool discounttype)
        {
            // Update DataGridView row with new data
            try
            {
                // Assuming rowIndex is valid
                if (rowIndex >= 0 && rowIndex < dgvsaleproducts.Rows.Count)
                {
                    try
                    {
                        // Safely set values for each cell with error handling for null or invalid data
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
                    catch (ArgumentOutOfRangeException ex)
                    {
                        // This will catch errors if the rowIndex is out of the valid range
                        MessageBox.Show($"Invalid row index: {ex.Message}", "Argument Out Of Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (NullReferenceException ex)
                    {
                        // This will catch any errors if any of the cells are null unexpectedly
                        MessageBox.Show($"Error updating cell value: {ex.Message}", "Null Reference", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidCastException ex)
                    {
                        // Handle invalid type conversion (if the data types don't match expected types)
                        MessageBox.Show($"Invalid data type conversion: {ex.Message}", "Invalid Cast", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Catch any other unexpected exceptions
                        MessageBox.Show($"An unexpected error occurred while updating the row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Row index is invalid. Please check the selected row.", "Row Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // This will catch any other general errors that might happen outside the specific row update logic
                MessageBox.Show($"An error occurred while processing the DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
