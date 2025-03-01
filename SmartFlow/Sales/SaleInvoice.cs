using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Sales.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow
{
    public partial class SaleInvoice : Form
    {
        private decimal qty = 0;
        private decimal total = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int accountsubcontrolid = 705;
        private string accountName = "Sales";

        public SaleInvoice()
        {
            InitializeComponent();
        }
        public SaleInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        private async void SaleInvoice_Load(object sender, EventArgs e)
        {
            await LoadInvoiceAsync();

        }

        public async Task LoadInvoiceAsync()
        {
            try
            {
                if ((_dtinvoice?.Rows.Count > 0) || (_dtinvoicedetails?.Rows.Count > 0))
                {
                    if (_dtinvoice?.Rows.Count > 0)
                    {
                        DataRow row = _dtinvoice.Rows[0];

                        try
                        {
                            // Simplified data assignment using helper methods
                            AssignTextBoxValues(row);
                        }
                        catch (Exception assignEx)
                        {
                            MessageBox.Show($"An error occurred while assigning text box values: {assignEx.Message}", "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit early if there's an issue assigning values
                        }

                        try
                        {
                            // Load grid data efficiently
                            AddGridData(_dtinvoicedetails);
                        }
                        catch (Exception gridEx)
                        {
                            MessageBox.Show($"An error occurred while adding grid data: {gridEx.Message}", "Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit early if there's an issue loading the grid
                        }

                        savebtn.Text = "UPDATE";
                    }
                    else
                    {
                        MessageBox.Show("Invoice data is missing.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    try
                    {
                        await LoadDefaultInvoiceValues();
                    }
                    catch (Exception loadEx)
                    {
                        MessageBox.Show($"An error occurred while loading default invoice values: {loadEx.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AssignTextBoxValues(DataRow row)
        {
            try
            {
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

                // Construct currency label
                if (row["CurrencyName"] != DBNull.Value && row["CurrencySymbol"] != DBNull.Value)
                {
                    currencylbl.Text = row["CurrencyName"].ToString() + " : " + row["CurrencySymbol"].ToString();
                }
                else
                {
                    currencylbl.Text = string.Empty; // In case either value is DBNull
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while assigning values to the controls: {ex.Message}", "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task LoadDefaultInvoiceValues()
        {
            try
            {
                await Task.Delay(500); // Simulate async loading

                var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                var totalString = total.ToString("0.00");

                invoicedatetxtbox.Text = currentDate;
                qtytxtbox.Text = qty.ToString("0");
                nettotaltxtbox.Text = totalString;
                totaldiscounttxtbox.Text = totalString;
                totalvattxtbox.Text = totalString;

                // Ensure async method is awaited properly
                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();

                // Format the shipping charges with two decimal places
                shippingchargestxtbox.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while assigning values to the controls: {ex.Message}", "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        // Safely converting each value and setting the cells
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
                        // Log the error with context to help identify which row failed
                        Debug.WriteLine($"[Error] Processing row (Invoice No: {invoiceRow["InvoiceNo"]}): {ex.Message}");
                    }
                }

                // Add rows to the DataGridView
                dgvsaleproducts.Rows.AddRange(newRows.ToArray());
            }
            catch (Exception ex)
            {
                // Log any errors encountered in the outer try block
                Debug.WriteLine($"[Error] AddGridData: {ex.Message}");
            }
            finally
            {
                // Ensure layout is resumed and the DataGridView is refreshed
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
                // Get the last invoice number from the database or some persistent store
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    // No previous invoice number exists, so create the first invoice number
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number
                    invoiceCounter++; // Increment the counter for the next invoice
                    newInvoiceNumber = $"{sequentialPart}";
                }
                else
                {
                    // Extract the sequential part from the last invoice number (assuming format: INV-XXXXX)
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);

                    // Ensure that the extracted part is numeric and valid
                    if (int.TryParse(sequentialPart, out int lastSequentialNumber))
                    {
                        int nextSequentialNumber = lastSequentialNumber + 1;  // Increment the sequential number
                        newInvoiceNumber = $"{nextSequentialNumber:D5}";
                    }
                    else
                    {
                        // Handle the case where the sequential part is not a valid number
                        throw new InvalidOperationException("The last invoice number does not have a valid sequential part.");
                    }
                }

                return newInvoiceNumber;  // Return the newly generated invoice number
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs during invoice number generation
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                // SQL query to retrieve the latest invoice number formatted to 5 digits
                string query = "SELECT FORMAT(MAX(CAST(InvoiceNo AS INT)), '00000') AS LatestInvoiceNumber FROM InvoiceTable WHERE InvoiceNo LIKE '_____';";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);

                // Check if any records were returned and get the last invoice number
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["LatestInvoiceNumber"].ToString();
                }

                // If no records are found, we will return null or handle it as needed
                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    // You can handle this case differently if necessary (e.g., return "00001" for the first invoice)
                    lastInvoiceNumber = null;
                }
            }
            catch (Exception ex)
            {
                // Show an error message if the database query fails
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInvoiceNumber;

        }
        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Validate that both the lastInvoiceNumber and newInvoiceNumber are not null and are valid numbers
                if (string.IsNullOrEmpty(lastInvoiceNumber) || string.IsNullOrEmpty(newInvoiceNumber))
                {
                    MessageBox.Show("Invoice number is invalid or missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

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
        private void SaleInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
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

                    try
                    {
                        currencySelection.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the Currency Selection form: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.Control && e.KeyCode == Keys.Q)
                {
                    SearchQuotationForm searchQuotationForm = new SearchQuotationForm();

                    // Subscribe to event with exception handling
                    searchQuotationForm.DataSelected += (data) =>
                    {
                        try
                        {
                            AddGridData(data);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while processing the data: {ex.Message}",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    try
                    {
                        searchQuotationForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the Search Quotation form: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void dgvsaleproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.D)
                {
                    try
                    {
                        int productid = Convert.ToInt32(dgvsaleproducts.CurrentRow.Cells["productid"].Value);
                        if (productid > 0)
                        {
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
                            MessageBox.Show("Select One Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while removing the selected rows: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"An error occurred while handling the row selection: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
                {
                    try
                    {
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
                        if (openForm == null)
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
                        else
                        {
                            openForm.BringToFront();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the customer selection form: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    try
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
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the product selection form: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
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

        private async void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
                    {
                        try
                        {
                            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
                            if (openForm == null)
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
                            else
                            {
                                openForm.BringToFront();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while opening the customer selection form: {ex.Message}",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async void savebtn_Click(object sender, EventArgs e)
        {
            bool detailadded = false;
            try
            {
                // Validate currency fields
                if (string.IsNullOrEmpty(currencyidlbl.Text) || currencyidlbl.Text == "currencyidlbl"
                    || string.IsNullOrEmpty(currencynamelbl.Text) || currencynamelbl.Text == "currencynamelbl"
                    || string.IsNullOrEmpty(currencysymbollbl.Text) || currencysymbollbl.Text == "currencysymbollbl"
                    || string.IsNullOrEmpty(currencyconversionratelbl.Text) || currencyconversionratelbl.Text == "currencyconversionratelbl")
                {
                    MessageBox.Show("Kindly Select Currency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                errorProvider.Clear();

                // Validate Customer selection
                if (string.IsNullOrWhiteSpace(selectcustomertxtbox.Text))
                {
                    errorProvider.SetError(selectcustomertxtbox, "Please Select Customer.");
                    selectcustomertxtbox.Focus();
                    return;
                }

                string invoiceNo = string.Empty;
                string format = "dd/MM/yyyy";
                var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture
                DateTime invoiceDate;

                // Parse invoice date with exact format
                if (!DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                {
                    try
                    {
                        // Fallback to general date parsing if custom format fails
                        invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"Invalid Date Format: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Check if the action is Update or Insert
                if (savebtn.Text == "UPDATE")
                {
                    invoiceNo = invoicenotxtbox.Text;
                    try
                    {
                        await UpdateSaleInvoice(invoiceNo, invoiceDate);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        invoiceNo = await CheckInvoiceBeforeInsert();
                        detailadded = await AddSaleInvoice(invoiceNo, invoiceDate);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // If invoice detail added, show the invoice view
                if (detailadded)
                {
                    try
                    {
                        SaleInvoiceView saleInvoiceview = new SaleInvoiceView(invoiceNo)
                        {
                            MdiParent = Application.OpenForms["Dashboard"]
                        };
                        CommonFunction.DisposeOnClose(saleInvoiceview);
                        saleInvoiceview.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error displaying sale invoice view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task UpdateSaleInvoice(string invoiceNo, DateTime invoiceDate)
        {
            try
            {
                // Parsing inputs with error handling
                int customerId = 0;
                if (!int.TryParse(customeridlbl.Text, out customerId))
                {
                    throw new FormatException("Invalid Customer ID format.");
                }

                string customercode = mfrtxtbox.Text;
                string customername = selectcustomertxtbox.Text;
                string customerrefrence = companytxtbox.Text;
                string mobile = mobiletxtbox.Text;
                string salespersonname = salemantxtbox.Text;

                decimal nettotal = 0;
                if (!decimal.TryParse(nettotaltxtbox.Text, out nettotal))
                {
                    throw new FormatException("Invalid Net Total format.");
                }

                float totalvat = 0;
                if (!float.TryParse(totalvattxtbox.Text, out totalvat))
                {
                    throw new FormatException("Invalid Total VAT format.");
                }

                float totaldiscount = 0;
                if (!float.TryParse(totaldiscounttxtbox.Text, out totaldiscount))
                {
                    throw new FormatException("Invalid Total Discount format.");
                }

                decimal shippingcharges = 0;
                if (!decimal.TryParse(shippingchargestxtbox.Text, out shippingcharges))
                {
                    throw new FormatException("Invalid Shipping Charges format.");
                }

                string invoiceCode = invoicecodelbl.Text;

                int currencyid = 0;
                if (!int.TryParse(currencyidlbl.Text, out currencyid))
                {
                    throw new FormatException("Invalid Currency ID format.");
                }

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
                    { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") },  // Fixed time format
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
                    { "AddedBy", "" }, // Ensure this is correctly handled in your DB logic
                    { "InvoiceType", "Sale" }
                };

                // Perform the database operation
                bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);

                if (isUpdated)
                {
                    bool isdeleted = await DeleteStatementData(invoiceNo);
                    // Only update details if the update was successful
                    string companyName = companytxtbox.Text;
                    decimal totalwithshipping = nettotal + shippingcharges;
                    await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerId, "Sales", invoiceNo, accountName, "", accountsubcontrolid, totalwithshipping, 0, "", true, false, companyName, "For Customer");
                    await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerId, "Sales", invoiceNo, accountName, "", accountsubcontrolid, 0, totalwithshipping, "", false, true, companyName, "For Office");
                    if (dgvsaleproducts.Rows.Count > 0)
                    {
                        
                        UpdateInvoiceDetailsData(invoiceNo, invoiceCode);
                    }
                    else
                    {
                        await UpdateInvoiceDetail(invoiceNo);
                        SaleInvoiceView saleInvoiceview = new SaleInvoiceView(invoiceNo);
                        saleInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(saleInvoiceview);
                        saleInvoiceview.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invoice update failed. Please check your data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                // Handle format-specific exceptions for user-friendly feedback
                MessageBox.Show($"Input Error: {ex.Message}", "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Catch any other exceptions and log/display them for debugging
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<bool> DeleteStatementData(string invoiceNo)
        {
            try
            {
                bool isoldrecord = false;
                string tableName = "AccountStatementTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                isoldrecord = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);
                return isoldrecord;
            }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddSaleInvoice(string invoiceNo, DateTime invoiceDate)
        {
            bool isCompleted = false;
            try
            {
                // Parse inputs with error handling
                int customerid = 0;
                if (!int.TryParse(customeridlbl.Text, out customerid))
                {
                    throw new FormatException("Invalid Customer ID format.");
                }

                string customercode = mfrtxtbox.Text;
                string customername = selectcustomertxtbox.Text;
                string customerrefrence = companytxtbox.Text;
                string mobile = mobiletxtbox.Text;
                string salespersonname = salemantxtbox.Text;

                decimal nettotal = 0;
                if (!decimal.TryParse(nettotaltxtbox.Text, out nettotal))
                {
                    throw new FormatException("Invalid Net Total format.");
                }

                float totalvat = 0;
                if (!float.TryParse(totalvattxtbox.Text, out totalvat))
                {
                    throw new FormatException("Invalid Total VAT format.");
                }

                float totaldiscount = 0;
                if (!float.TryParse(totaldiscounttxtbox.Text, out totaldiscount))
                {
                    throw new FormatException("Invalid Total Discount format.");
                }

                decimal shippingcharges = 0;
                if (!decimal.TryParse(shippingchargestxtbox.Text, out shippingcharges))
                {
                    throw new FormatException("Invalid Shipping Charges format.");
                }

                string invoicecode = Guid.NewGuid().ToString();

                int currencyid = 0;
                if (!int.TryParse(currencyidlbl.Text, out currencyid))
                {
                    throw new FormatException("Invalid Currency ID format.");
                }

                string currencyname = currencynamelbl.Text;
                string currencyconversionrate = currencyconversionratelbl.Text;
                string currencysymbol = currencysymbollbl.Text;

                string tableName = "InvoiceTable";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "invoicedate", invoiceDate },
                    { "ClientID", customerid },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },  // Corrected time format
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
                    { "InvoiceType", "Sale" }
                };

                // Perform the database insert for the invoice
                bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);

                if (result)
                {
                    // Process each row in the DataGridView for invoice details
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        // Parse and validate data for each row
                        int productid = 0;
                        if (!int.TryParse(row.Cells["productid"].Value.ToString(), out productid))
                        {
                            throw new FormatException("Invalid Product ID format.");
                        }

                        int quantity = 0;
                        if (!int.TryParse(row.Cells["qtycolumn"].Value.ToString(), out quantity))
                        {
                            throw new FormatException("Invalid Quantity format.");
                        }

                        float unitprice = 0;
                        if (!float.TryParse(row.Cells["pricecolumn"].Value.ToString(), out unitprice))
                        {
                            throw new FormatException("Invalid Unit Price format.");
                        }

                        string productname = row.Cells["productnamecolumn"].Value.ToString();
                        string mfr = row.Cells["codecolumn"].Value.ToString();

                        float discount = 0;
                        if (!float.TryParse(row.Cells["discountcolumn"].Value.ToString(), out discount))
                        {
                            throw new FormatException("Invalid Discount format.");
                        }

                        float vat = 0;
                        if (!float.TryParse(row.Cells["vatcolumn"].Value.ToString(), out vat))
                        {
                            throw new FormatException("Invalid VAT format.");
                        }

                        float total = 0;
                        if (!float.TryParse(row.Cells["totalcolumn"].Value.ToString(), out total))
                        {
                            throw new FormatException("Invalid Total format.");
                        }

                        int unitid = 0;
                        if (!int.TryParse(row.Cells["unitidcolumn"].Value.ToString(), out unitid))
                        {
                            throw new FormatException("Invalid Unit ID format.");
                        }

                        int warehouseid = 0;
                        if (!int.TryParse(row.Cells["warehouseidcolumn"].Value.ToString(), out warehouseid))
                        {
                            throw new FormatException("Invalid Warehouse ID format.");
                        }

                        string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value.ToString();

                        float pricepermeter = 0;
                        if (!float.TryParse(row.Cells["lengthinmetercolumn"].Value.ToString(), out pricepermeter))
                        {
                            throw new FormatException("Invalid Price Per Meter format.");
                        }

                        float lengthinmeter = 0;
                        if (!float.TryParse(row.Cells["pricepermetercolumn"].Value.ToString(), out lengthinmeter))
                        {
                            throw new FormatException("Invalid Length In Meter format.");
                        }

                        string availabilitystatus = row.Cells["availabilitycolumn"].Value.ToString();

                        float vatpercentage = 0;
                        if (!float.TryParse(row.Cells["vatpercentagecolumn"].Value.ToString(), out vatpercentage))
                        {
                            throw new FormatException("Invalid VAT Percentage format.");
                        }

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

                        // Insert data for each row in the details table
                        bool subResult = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                        if (!subResult)
                        {
                            throw new Exception("Failed to insert invoice details.");
                        }
                    }

                    string companyName = companytxtbox.Text;
                    decimal totalwithshippingcharges = nettotal + shippingcharges;
                    await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerid, "Sales", invoiceNo, accountName, "", accountsubcontrolid, totalwithshippingcharges, 0, "", true, false, companyName, "For Customer");
                    await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerid, "Sales", invoiceNo, accountName, "", accountsubcontrolid, 0, totalwithshippingcharges, "", false, true, companyName, "For Office");

                    isCompleted = true;
                }
                else
                {
                    throw new Exception("Failed to insert invoice.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input Error: {ex.Message}", "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isCompleted;

        }


        private async void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool detailAdded = false;
            List<Dictionary<string, object>> invoiceDetails = new List<Dictionary<string, object>>();

            // **Step 1: Collect and Validate All Records**
            foreach (DataGridViewRow row in dgvsaleproducts.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    int productid = row.Cells["productid"].Value != null ? Convert.ToInt32(row.Cells["productid"].Value) : 0;
                    string invoicecode = invoicecodelbl.Text;
                    int quantity = row.Cells["qtycolumn"].Value != null ? Convert.ToInt32(row.Cells["qtycolumn"].Value) : 0;
                    float unitprice = row.Cells["pricecolumn"].Value != null ? float.Parse(row.Cells["pricecolumn"].Value.ToString()) : 0f;
                    string productname = row.Cells["productnamecolumn"].Value != null ? row.Cells["productnamecolumn"].Value.ToString() : string.Empty;
                    string mfr = row.Cells["codecolumn"].Value != null ? row.Cells["codecolumn"].Value.ToString() : string.Empty;
                    float discount = row.Cells["discountcolumn"].Value != null ? float.Parse(row.Cells["discountcolumn"].Value.ToString()) : 0f;
                    float vat = row.Cells["vatcolumn"].Value != null ? float.Parse(row.Cells["vatcolumn"].Value.ToString()) : 0f;
                    float total = row.Cells["totalcolumn"].Value != null ? float.Parse(row.Cells["totalcolumn"].Value.ToString()) : 0f;
                    int unitid = row.Cells["unitidcolumn"].Value != null ? Convert.ToInt32(row.Cells["unitidcolumn"].Value) : 0;
                    int warehouseid = row.Cells["warehouseidcolumn"].Value != null ? Convert.ToInt32(row.Cells["warehouseidcolumn"].Value) : 0;
                    string itemDescription = row.Cells["itemdescriptioncolumn"].Value != null ? row.Cells["itemdescriptioncolumn"].Value.ToString() : string.Empty;
                    float pricePerMeter = row.Cells["pricepermetercolumn"].Value != null ? float.Parse(row.Cells["pricepermetercolumn"].Value.ToString()) : 0f;
                    float lengthInMeter = row.Cells["lengthinmetercolumn"].Value != null ? float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString()) : 0f;
                    string availabilityStatus = row.Cells["availabilitycolumn"].Value != null ? row.Cells["availabilitycolumn"].Value.ToString() : string.Empty;
                    float vatPercentage = row.Cells["vatpercentagecolumn"].Value != null ? float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString()) : 0f;

                    invoiceDetails.Add(new Dictionary<string, object>
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
                    return; // Stop execution if there is an issue
                }
            }

            // **Step 2: Run `UpdateInvoiceDetail` Only After Validation**
            bool isOldRecord = await UpdateInvoiceDetail(invoiceNo);
            if (isOldRecord && invoiceDetails.Count > 0)
            {
                // **Step 3: Insert the Validated Records**
                foreach (var record in invoiceDetails)
                {
                    detailAdded = await DatabaseAccess.ExecuteQueryAsync("InvoiceDetailsTable", "INSERT", record);
                }

                // **Step 4: Show the Updated Invoice View**
                if (detailAdded)
                {
                    SaleInvoiceView saleInvoiceview = new SaleInvoiceView(invoiceNo);
                    saleInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(saleInvoiceview);
                    saleInvoiceview.Show();
                    this.Close();
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    try
                    {
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
                            { "MinusInventory", false },
                            { "ItemAvailability", availabilitystatus },
                            { "IsNewRecord", true },
                            { "VatCode", vatpercentage }
                        };

                        detailAdded = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop execution if there is an issue
                    }
                }

                if (detailAdded)
                {
                    SaleInvoiceView saleInvoiceview = new SaleInvoiceView(invoiceNo);
                    saleInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(saleInvoiceview);
                    saleInvoiceview.Show();
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

                // Attempt to execute the database update
                isoldupdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

                return isoldupdated;
            }
            catch (ArgumentNullException argEx)
            {
                // Handle cases where input arguments are null
                MessageBox.Show($"Argument error: {argEx.Message}", "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // You can return a failure flag or handle accordingly
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL exceptions (e.g., database connection issues or SQL syntax errors)
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // You can return a failure flag or handle accordingly
            }
            catch (Exception ex)
            {
                // Catch any other unhandled exceptions
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // You can return a failure flag or handle accordingly
            }

        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            SaleInvoice saleInvoice = new SaleInvoice();
            saleInvoice.MdiParent = Application.OpenForms["Dashboard"];
            CommonFunction.DisposeOnClose(saleInvoice);
            saleInvoice.Show();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all the necessary fields are filled and are not empty or whitespace
                if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
                {
                    string mfr = mfrtxtbox.Text ?? "Unknown Manufacturer"; // Default value if null
                    string productid = productidlbl.Text ?? "Unknown Product ID"; // Default value if null
                    string productname = selectproducttxtbox.Text ?? "Unknown Product Name"; // Default value if null
                    string qty = qtytxtbox.Text ?? "0"; // Default value if null
                    int unitid = Convert.ToInt32(unitidlbl.Text ?? "0"); // Default to 0 if null
                    string unitname = unitnamelbl.Text ?? "Unknown Unit"; // Default value if null
                    decimal vatamount = decimal.TryParse(productvatlbl.Text, out var parsedVat) ? parsedVat : 0.00m; // Default to 0 if parsing fails
                    decimal discount = decimal.TryParse(productdiscountlbl.Text, out var parsedDiscount) ? parsedDiscount : 0.00m; // Default to 0 if parsing fails
                    float unitprice = float.TryParse(unitsalepricelbl.Text, out var parsedPrice) ? parsedPrice : 0.00f; // Default to 0 if parsing fails
                    decimal finalitemwise = decimal.TryParse(totalcolumnlbl.Text, out var parsedTotal) ? parsedTotal : 0.00m; // Default to 0 if parsing fails
                    int warehouseid = Convert.ToInt32(warehouseidlbl.Text ?? "0"); // Default to 0 if null
                    string itemwisedescription = itemdescriptionlbl.Text ?? "No Description"; // Default value if null
                    decimal lengthinmeterproduct = decimal.TryParse(lengthinmeterlbl.Text, out var parsedLength) ? parsedLength : 0.00m; // Default to 0 if parsing fails
                    decimal priceinmeter = decimal.TryParse(pricepermeterlbl.Text, out var parsedPriceMeter) ? parsedPriceMeter : 0.00m; // Default to 0 if parsing fails
                    string availability = availabilitystatuslbl.Text ?? "Unknown Availability"; // Default value if null
                    string vatpercentage = vatcodelbl.Text ?? "0%"; // Default value if null
                    string discountpercentage = discountpercentagelbl.Text ?? "0%"; // Default value if null
                    bool discounttype = Convert.ToBoolean(discounttypelbl.Text ?? "false"); // Default to false if null
                    string availabilitystatus = availabilitystatuslbl.Text ?? "Unknown Status"; // Default value if null

                    bool productExists = false;

                    // Loop through the rows in the DataGridView to check if the product already exists
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productid &&
                                float.Parse(row.Cells["pricecolumn"].Value.ToString()) == unitprice)
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                decimal currentVat = decimal.Parse(row.Cells["vatcolumn"].Value.ToString());
                                decimal currentDiscount = decimal.Parse(row.Cells["discountcolumn"].Value.ToString());
                                decimal currentitemTotal = decimal.Parse(row.Cells["totalcolumn"].Value.ToString());

                                // Update the quantity and totals
                                row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qty);
                                // Update VAT, round to two decimal places
                                row.Cells["vatcolumn"].Value = Math.Round(currentVat + vatamount, 2);
                                // Update Discount, round to two decimal places
                                row.Cells["discountcolumn"].Value = Math.Round(currentDiscount + discount, 2);
                                // Update Total, round to two decimal places
                                row.Cells["totalcolumn"].Value = Math.Round(currentitemTotal + finalitemwise, 2);

                                productExists = true;
                                break; // Exit the loop once the product is found and updated
                            }
                        }
                    }

                    // If product doesn't exist in the DataGridView, add it as a new row
                    if (!productExists)
                    {
                        dgvsaleproducts.Rows.Add("", mfr, productid, productname, qty, availability, unitid, unitname, unitprice,
                            vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter,
                            vatpercentage, discountpercentage, discounttype);
                    }

                    // Reset labels to default state after processing
                    ResetLabelData();
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields before adding the product.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException formatEx)
            {
                // Handle formatting issues such as invalid decimal or integer conversions
                MessageBox.Show($"Format error: {formatEx.Message}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                // Check if the key pressed is not Enter or a control character (e.g., Backspace)
                if (e.KeyChar != (char)Keys.Enter && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Block the key press if it's not Enter or control
                }
                else
                {
                    // If the product selection text box is empty
                    if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                    {
                        // Check if the ProductSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                        if (openForm == null)
                        {
                            // If not open, create a new ProductSelectionForm
                            ProductSelectionForm productSelection = new ProductSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Subscribe to the event when a product is selected
                            productSelection.ProductDataSelected += UpdateProductTextBox;

                            // Dispose the form when it's closed
                            CommonFunction.DisposeOnClose(productSelection);

                            // Show the form
                            productSelection.Show();
                        }
                        else
                        {
                            // If the form is already open, bring it to the front
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show a message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        
                        WarehouseQty warehouseQty = new WarehouseQty(result, true)
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

        private async Task UpdateProductDataAsync()
        {
            await Task.Run(() =>
            {
                // A helper method to simplify updating label texts
                void UpdateLabel(Control label, Func<string> getValue)
                {
                    label.Invoke((Action)(() => label.Text = getValue()));
                }

                // Update the labels using the helper method
                UpdateLabel(warehouseidlbl, () => GlobalVariables.warehouseidglobal != 0 ? GlobalVariables.warehouseidglobal.ToString() : "0");
                UpdateLabel(itemdescriptionlbl, () => GlobalVariables.productitemwisedescriptiongloabl ?? "N/A");
                UpdateLabel(unitsalepricelbl, () => GlobalVariables.productpriceglobal != 0 ? GlobalVariables.productpriceglobal.ToString("0.00") : "0.00");
                UpdateLabel(pricepermeterlbl, () => GlobalVariables.productinmeterprice != 0 ? GlobalVariables.productinmeterprice.ToString("0.00") : "0.00");
                UpdateLabel(lengthinmeterlbl, () => GlobalVariables.productinmeterlength != 0 ? GlobalVariables.productinmeterlength.ToString("0.00") : "0.00");
                UpdateLabel(totalcolumnlbl, () => GlobalVariables.productfinalamountwithvatanddiscountitemwise != 0 ? GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("0.00") : "0.00");
                UpdateLabel(unitnamelbl, () => GlobalVariables.unitnameglobal ?? "N/A");
                UpdateLabel(unitidlbl, () => GlobalVariables.unitidglobal != 0 ? GlobalVariables.unitidglobal.ToString() : "0");
                UpdateLabel(productdiscountlbl, () => GlobalVariables.productdiscountamountitemwise != 0 ? GlobalVariables.productdiscountamountitemwise.ToString("0.00") : "0.00");
                UpdateLabel(productvatlbl, () => GlobalVariables.productitemwisevatamount != 0 ? GlobalVariables.productitemwisevatamount.ToString("0.00") : "0.00");
                UpdateLabel(vatcodelbl, () => GlobalVariables.productitemwisevatpercentage != 0 ? GlobalVariables.productitemwisevatpercentage.ToString() : "0");
                UpdateLabel(availabilitystatuslbl, () => GlobalVariables.availabilitystatus ?? "IN STOCK");
                UpdateLabel(discountpercentagelbl, () => GlobalVariables.discountpercentage != 0 ? GlobalVariables.discountpercentage.ToString() : "0");
                UpdateLabel(discounttypelbl, () => GlobalVariables.productdiscounttype != false ? GlobalVariables.productdiscounttype.ToString() : "false");

                // Reset global variables
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

        private void dgvsaleproducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }
    }
}
    