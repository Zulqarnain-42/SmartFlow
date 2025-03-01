using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Sales.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow
{
    public partial class SaleReturnInvoice : Form
    {
        private decimal qty = 0;
        private decimal total = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int accountsubcontrolid = 705;
        private string accountName = "Sales";

        public SaleReturnInvoice()
        {
            InitializeComponent();
        }
        public SaleReturnInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        private async void SaleReturnInvoice_Load(object sender, EventArgs e)
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
            invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
            invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
            invoicedatetxtbox.Text = row["invoicedate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
            codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;
            selectcustomertxtbox.Text = row["AccountSubControlName"]?.ToString() ?? string.Empty;
            companynametxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
            mobiletxtbox.Text = row["MobileNo"]?.ToString() ?? string.Empty;
            customeridlbl.Text = row["ClientID"]?.ToString() ?? string.Empty;
            totalvattxtbox.Text = row["TotalVat"]?.ToString() ?? "0";
            totaldiscounttxtbox.Text = row["TotalDiscount"]?.ToString() ?? "0";
            salesmantxtbox.Text = row["SalePerson"]?.ToString() ?? string.Empty;
            shippingchargestxtbox.Text = row["FreightShippingCharges"]?.ToString() ?? "0";
            currencyidlbl.Text = row["Currencyid"]?.ToString() ?? string.Empty;
            currencynamelbl.Text = row["CurrencyName"]?.ToString() ?? string.Empty;
            currencysymbollbl.Text = row["CurrencySymbol"]?.ToString() ?? string.Empty;
            currencyconversionratelbl.Text = row["ConversionRate"]?.ToString() ?? string.Empty;
            currencylbl.Text = row["CurrencyName"].ToString() + (" : ") + row["CurrencySymbol"].ToString();
        }

        private async Task LoadDefaultInvoiceValues()
        {
            await Task.Delay(500); // Simulate async loading

            var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            var totalString = total.ToString("0.00");

            invoicedatetxtbox.Text = currentDate;
            qtytxtbox.Text = qty.ToString("0");
            nettotaltxtbox.Text = totalString;
            totaldiscounttxtbox.Text = totalString;
            totalvattxtbox.Text = totalString;
            invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
            shippingchargestxtbox.Text = total.ToString("N2");
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
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (lastInvoiceNumber == null)
                {

                    // Generate the invoice number using the current date and a sequential number
                    string invoicepart = "SR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{sequentialPart}";

                    return newInvoiceNumber;
                    // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    string invoicepart = "SR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;

            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'SR-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);

                if (invoiceData != null && invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"]?.ToString();
                }
            }
            catch (Exception)
            {
                // Show a user-friendly error message
                MessageBox.Show("An error occurred while retrieving the last invoice number. Please try again or contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInvoiceNumber ?? "SR-0000"; // Return a default value if no invoice number is found
        }

        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                // Retrieve the last invoice number
                string lastInvoiceNumber = await GetLastInvoiceNumber();

                // Get the new invoice number from the textbox
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Validate the new invoice number
                if (string.IsNullOrEmpty(newInvoiceNumber))
                {
                    throw new InvalidOperationException("Invoice number cannot be empty.");
                }

                // Compare the new invoice number with the last invoice number
                if (string.Compare(newInvoiceNumber, lastInvoiceNumber, StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    // Generate a new invoice number if the current one is not greater
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    // Return the current invoice number if it is valid
                    return newInvoiceNumber;
                }
            }
            catch (Exception)
            {

                // Show a user-friendly error message
                MessageBox.Show("An error occurred while processing the invoice number. Please try again or contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Return null to indicate failure
                return null;
            }
        }

        private void SaleReturnInvoice_KeyDown(object sender, KeyEventArgs e)
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

            if(e.Control && e.KeyCode == Keys.S)
            {
                SearchInvoiceForm searchInvoiceForm = new SearchInvoiceForm();
                // Subscribe to event
                searchInvoiceForm.DataSelected += (data) =>
                {
                    AddGridData(data);
                };
                searchInvoiceForm.ShowDialog();
            }
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

        private void dgvsaleproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
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
                    MessageBox.Show("Select One Row");
                }
            }

            if (e.KeyCode == Keys.E)
            {
                HandleRowSelectionAsync();
            }
        }
        private async void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
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
        }
        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
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
                        selectproducttxtbox.Text = productname.ToString();
                        mfrtxtbox.Text = productmfr.ToString();
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
                        selectcustomertxtbox.Text = customername;
                        codetxtbox.Text = customercode.ToString();
                        mobiletxtbox.Text = customermobile.ToString();
                        companynametxtbox.Text = customercompany.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating Customer information: {ex.Message}",
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
        private async void dgvsaleproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9,dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
        }
        private async void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvsaleproducts, nettotaltxtbox);
        }
        private async void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
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
                        await UpdateSaleReturn(invoiceNo, invoiceDate);

                    }
                    else
                    {
                        invoiceNo = await CheckInvoiceBeforeInsert();
                        detailadded = await AddSaleReturn(invoiceNo, invoiceDate);
                    }

                    if (detailadded)
                    {
                        SaleReturnView salereturnInvoiceview = new SaleReturnView(invoiceNo);
                        salereturnInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(salereturnInvoiceview);
                        salereturnInvoiceview.Show();
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

        private async Task UpdateSaleReturn(string invoiceNo, DateTime invoiceDate)
        {
            int customerId = Convert.ToInt32(customeridlbl.Text);
            string customercode = codetxtbox.Text;
            string customername = selectcustomertxtbox.Text;
            string customerrefrence = companynametxtbox.Text;
            string mobile = mobiletxtbox.Text;
            string salespersonname = salesmantxtbox.Text;
            decimal nettotal = decimal.Parse(nettotaltxtbox.Text);
            float totalvat = float.Parse(totalvattxtbox.Text);
            float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
            decimal shippingcharges = decimal.Parse(shippingchargestxtbox.Text);
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
                { "ConversionRate", currencyconversionrate },
                { "AddedBy", "JEAN" },
                { "InvoiceType", "Sale Return" }
            };

            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            if (isUpdated)
            {
                bool isdeleted = await DeleteStatementData(invoiceNo);
                string companyName = companynametxtbox.Text;
                decimal totalwithshippingcharges = nettotal + shippingcharges;
                await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerId, "Sales Return", invoiceNo, accountName, "", accountsubcontrolid, 0, totalwithshippingcharges,  "", true, false, companyName,"For Customer");
                await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerId, "Sales Return", invoiceNo, accountName, "", accountsubcontrolid,totalwithshippingcharges, 0, "", false, true, companyName,"For Office");

                UpdateInvoiceDetailsData(invoiceNo, invoiceCode);
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

        private async Task<bool> AddSaleReturn(string invoiceNo, DateTime invoiceDate)
        {
            bool isCompleted = false;
            int customerid = Convert.ToInt32(customeridlbl.Text);
            string customercode = codetxtbox.Text;
            string customername = selectcustomertxtbox.Text;
            string customerrefrence = companynametxtbox.Text;
            string mobile = mobiletxtbox.Text;
            string salespersonname = salesmantxtbox.Text;
            decimal nettotal = decimal.Parse(nettotaltxtbox.Text);
            float totalvat = float.Parse(totalvattxtbox.Text);
            float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
            decimal shippingcharges = decimal.Parse(shippingchargestxtbox.Text.ToString());
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
                { "ConversionRate", currencyconversionrate },
                { "AddedBy", "JEAN" },
                { "InvoiceType", "Sale Return" }

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
                        { "AddInventory", true },
                        { "Warehouseid", warehouseid },
                        { "ItemDescription", itemwisedescription },
                        { "PricePerMeter", pricepermeter },
                        { "LengthInMeter", lengthinmeter },
                        { "MinusInventory", false },
                        { "ItemAvailability", availabilitystatus },
                        { "IsNewRecord", true },
                        { "VatCode", vatpercentage }
                    };

                    isCompleted = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                }
            }
            string companyName = companynametxtbox.Text;
            decimal totalwithshippingcharges = nettotal + shippingcharges;
            await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerid, "Sales Return", invoiceNo, accountName, "", accountsubcontrolid, 0, totalwithshippingcharges, "", true, false, companyName,"For Customer");
            await CommonFunction.InsertOrUpdateAccountStatementAsync(customername, customerid, "Sales Return", invoiceNo, accountName, "", accountsubcontrolid, totalwithshippingcharges, 0, "", false, true, companyName, "For Office");
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
                    SaleReturnView salereturnInvoiceview = new SaleReturnView(invoiceNo);
                    salereturnInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(salereturnInvoiceview);
                    salereturnInvoiceview.Show();
                    this.Close();
                }
            }

            else
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
                        { "MinusInventory", false },
                        { "ItemAvailability", availabilitystatus },
                        { "IsNewRecord", true },
                        { "VatCode", vatpercentage }

                    };

                    detailAdded = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                }
                if (detailAdded)
                {
                    SaleReturnView salereturnInvoiceview = new SaleReturnView(invoiceNo);
                    salereturnInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(salereturnInvoiceview);
                    salereturnInvoiceview.Show();
                    this.Close();
                }
            }
        }

        private async Task<bool> UpdateInvoiceDetail(string invoiceNo)
        {
            try
            {
                bool isoldrecord = false;
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                var columnData = new Dictionary<string, object>
                {
                    { "IsNewRecord", false }
                };

                isoldrecord = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                return isoldrecord;
            }
            catch (Exception ex) { throw ex; }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            SaleReturnInvoice saleReturnInvoice = new SaleReturnInvoice();
            saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
            CommonFunction.DisposeOnClose(saleReturnInvoice);
            saleReturnInvoice.Show();
        }

        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };
                        productSelectionForm.ProductDataSelected += UpdateProductTextBox;

                        CommonFunction.DisposeOnClose(productSelectionForm);
                        productSelectionForm.Show();

                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace, and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits, and a single dot or negative sign
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Allow only one dot
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
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

        private async void qtytxtbox_Leave(object sender, EventArgs e)
        {
            int itemqty = Convert.ToInt32(qtytxtbox.Text);
            if (itemqty > 0)
            {
                string getwarehousedata = "SELECT WarehouseID,Address,Name FROM WarehouseTable";
                DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                if (warehousedata != null)
                {
                    if (warehousedata.Rows.Count > 0)
                    {
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;
                        warehouseSelection.FormClosed += WarehouseSelection_FormClosed;

                        CommonFunction.DisposeOnClose(warehouseSelection);
                        warehouseSelection.ShowDialog();
                    }
                }
            }
        }
        private async void UpdateWarehouseInfo(object sender, WarehouseData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int warehouseid = e.WarehouseId;
                    string warehousename = e.WarehouseName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        warehouseidlbl.Text = warehouseid.ToString();
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
        private void WarehouseSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((WarehouseSelection)sender);

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
    }
}
