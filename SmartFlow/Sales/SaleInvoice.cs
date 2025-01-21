using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Sales.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class SaleInvoice : Form
    {
        private decimal initialzer = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetail;

        public SaleInvoice()
        {
            InitializeComponent();
        }
        public SaleInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();

            this._dtinvoice = dtinvoice;
            this._dtinvoicedetail = dtinvoicedetails;
        }
        private async void SaleInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                // Ensure that both DataTables are not null and have rows
                if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetail != null && _dtinvoicedetail.Rows.Count > 0)
                {
                    // Get the first row of invoice data
                    DataRow row = _dtinvoice.Rows[0];

                    // Populate form fields with invoice details
                    invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                    invoicecodelbl.Text = row["InvoiceCode"].ToString();
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    accountcodetxtbox.Text = row["CodeAccount"].ToString();
                    selectcustomertxtbox.Text = row["AccountSubControlName"].ToString();
                    companytxtbox.Text = row["CompanyName"].ToString();
                    mobiletxtbox.Text = row["MobileNo"].ToString();
                    salemantxtbox.Text = row["SalePerson"].ToString();
                    customeridlbl.Text = row["ClientID"].ToString();
                    shippingchargestxtbox.Text = row["FreightShippingCharges"].ToString();
                    totalvattxtbox.Text = row["TotalVat"].ToString();
                    totaldiscounttxtbox.Text = row["TotalDiscount"].ToString();

                    // Populate sale product details in DataGridView
                    foreach (DataRow invoiceDetailsRow in _dtinvoicedetail.Rows)
                    {
                        int detailsRowIndex = dgvsaleproducts.Rows.Add();
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["codecolumn"].Value = invoiceDetailsRow["MFR"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["unitnamecolumn"].Value = invoiceDetailsRow["UnitName"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = invoiceDetailsRow["LengthInMeter"];
                        dgvsaleproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = invoiceDetailsRow["PricePerMeter"];
                    }

                    // Set button text to indicate that it's an update operation
                    savebtn.Text = "UPDATE";
                }
                else
                {
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    shippingchargestxtbox.Text = initialzer.ToString("N2");
                    invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        private async void SaleInvoice_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.Q)
            {
                try
                {
                    SearchQuotationForm searchQuotationForm = new SearchQuotationForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    await CommonFunction.DisposeOnCloseAsync(searchQuotationForm);
                    searchQuotationForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the search form: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private async void dgvsaleproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                // Ensure the current row has a valid product ID.
                var productidCellValue = dgvsaleproducts.CurrentRow?.Cells[1].Value;
                if (productidCellValue != null && int.TryParse(productidCellValue.ToString(), out int productid) && productid > 0)
                {
                    // Check if there are any selected rows.
                    if (dgvsaleproducts.SelectedRows.Count > 0)
                    {
                        // Collect rows to remove to avoid modifying the collection during iteration.
                        List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dgvsaleproducts.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                rowsToRemove.Add(row);
                            }
                        }

                        // Simulate an async operation (e.g., saving changes to a database).
                        // Here we can await an async task (e.g., save data to a database, etc.)
                        await Task.Delay(500); // Placeholder async operation (e.g., save)

                        // Remove the rows after collecting them.
                        foreach (var row in rowsToRemove)
                        {
                            dgvsaleproducts.Rows.Remove(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select one or more rows to delete.", "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid row with a valid Product ID.", "Invalid Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (e.KeyCode == Keys.E)
            {
                HandleRowSelectionAsync();
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
                    await CommonFunction.DisposeOnCloseAsync(customerSelection);
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
                    await CommonFunction.DisposeOnCloseAsync(productSelection);
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
        private bool AreAnyTextBoxesFilled()
        {
            // List of all TextBox controls to check
            List<TextBox> textBoxes = new List<TextBox>
            {
                selectcustomertxtbox,
                salemantxtbox,
                selectproducttxtbox
            };

            // Check if any TextBox has text
            foreach (var textBox in textBoxes)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true; // At least one TextBox is filled
                }
            }

            // Check if any row is present in DataGridView
            if (dgvsaleproducts.Rows.Count > 0)
            {
                return true;
            }

            return false; // No TextBox is filled, and no rows in DataGridView
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

                await CommonFunction.DisposeOnCloseAsync(customerSelection);
                customerSelection.Show();
            }
            else
            {
                // Bring the form to front if it's already open
                existingForm.BringToFront();
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

                await CommonFunction.DisposeOnCloseAsync(productSelection);
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
            await CommonFunction.CalculateTotalVatColumnAsync(8,dgvsaleproducts,totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(9,dgvsaleproducts,totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(10, dgvsaleproducts, nettotaltxtbox);
        }
        private async void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalVatColumnAsync(8, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(9, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(10, dgvsaleproducts, nettotaltxtbox);
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
            string invoiceNo = string.Empty;
            try
            {
                errorProvider.Clear();
                if (string.IsNullOrWhiteSpace(selectcustomertxtbox.Text))
                {
                    errorProvider.SetError(selectcustomertxtbox, "Please Select Customer.");
                    selectcustomertxtbox.Focus();
                    return;
                }
                else
                {
                    errorProvider.SetError(selectcustomertxtbox, string.Empty); // Clear
                }
                
                if (savebtn.Text == "UPDATE")
                {
                    invoiceNo = invoicenotxtbox.Text;
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int customerId = Convert.ToInt32(customeridlbl.Text);
                    string customerCode = accountcodetxtbox.Text;
                    string customerName = selectcustomertxtbox.Text;
                    string customerRefrence = companytxtbox.Text;
                    string mobile = mobiletxtbox.Text;
                    string salespersonname = salemantxtbox.Text;
                    float nettotal = float.Parse(nettotaltxtbox.Text);
                    float totalvat = float.Parse(totalvattxtbox.Text);
                    float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                    float shippingCharges = float.Parse(shippingchargestxtbox.Text);
                    string invoiceCode = invoicecodelbl.Text;

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
                        { "ClientName", customerName },
                        { "NetTotal", nettotal },
                        { "TotalVat", totalvat },
                        { "TotalDiscount", totaldiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "SalePerson", salespersonname }
                    };

                    bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceNo,invoiceCode);
                    }
                }
                else
                {
                    invoiceNo = await CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int customerid = Convert.ToInt32(customeridlbl.Text);
                    string customercode = accountcodetxtbox.Text;
                    string customername = selectcustomertxtbox.Text;
                    string customerrefrence = companytxtbox.Text;
                    string mobile = mobiletxtbox.Text;
                    string salespersonname = salemantxtbox.Text;
                    float nettotal = float.Parse(nettotaltxtbox.Text);
                    float totalvat = float.Parse(totalvattxtbox.Text);
                    float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                    float shippingcharges = float.Parse(shippingchargestxtbox.Text.ToString());

                    string invoicecode = Guid.NewGuid().ToString();

                    string tableName = "InvoiceTable";
                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "invoicedate", invoiceDate },
                        { "ClientID", customerid },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", nettotal },
                        { "ClientName", customername },
                        { "TotalVat", totalvat },
                        { "TotalDiscount", totaldiscount },
                        { "FreightShippingCharges", shippingcharges },
                        { "SalePerson", salespersonname }
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
                            string vatpercentagecode = string.IsNullOrEmpty(row?.Cells["vatpercentagecolumn"]?.Value?.ToString()) ? "0" : row.Cells["vatpercentagecolumn"].Value.ToString();

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
                                { "VatCode", vatpercentagecode }
                            };
                            detailadded = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                        }
                    }

                    if (detailadded)
                    {
                        SaleInvoiceView saleInvoice = new SaleInvoiceView(invoiceNo);
                        saleInvoice.MdiParent = Application.OpenForms["Dashboard"];
                        await CommonFunction.DisposeOnCloseAsync(saleInvoice);
                        saleInvoice.Show();
                        this.Close();
                    }
                }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private async void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool detailadded = false;
            InsertBackUpData(invoiceNo, invoiceCode);
            DeleteInvoiceDetail(invoiceNo);
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
                string vatpercentagecode = string.IsNullOrEmpty(row?.Cells["vatpercentagecolumn"]?.Value?.ToString()) ? "0" : row.Cells["vatpercentagecolumn"].Value.ToString();

                string subtable = "InvoiceDetailsTable";
                var subColumnData = new Dictionary<string, object>
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
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", true },
                    { "VatCode", vatpercentagecode }
                };
                detailadded = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
            }

            if (detailadded)
            {
                SaleInvoiceView saleInvoice = new SaleInvoiceView(invoiceNo);
                saleInvoice.MdiParent = Application.OpenForms["Dashboard"];
                await CommonFunction.DisposeOnCloseAsync(saleInvoice);
                saleInvoice.Show();
                this.Close();
            }
        }
        private async void InsertBackUpData(string invoiceno, string invoiceCode)
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
                string vatpercentagecode = string.IsNullOrEmpty(row?.Cells["vatpercentagecolumn"]?.Value?.ToString()) ? "0" : row.Cells["vatpercentagecolumn"].Value.ToString();

                string subtable = "InvoiceDetailsTableBackUp";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceno },
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
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", true },
                    { "VatCode",vatpercentagecode }
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

                await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

            }
            catch (Exception ex) { throw ex; }
        }
        private async void newbtn_Click(object sender, EventArgs e)
        {
            SaleInvoice saleInvoice = new SaleInvoice();
            saleInvoice.MdiParent = Application.OpenForms["Dashboard"];
            await CommonFunction.DisposeOnCloseAsync(saleInvoice);
            saleInvoice.Show();
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
                string vatpercentage = vatcodelbl.Text;
                string discountpercentage = discountpercentagelbl.Text;
                bool discounttype = Convert.ToBoolean(discounttypelbl.Text);

                bool productExists = false;
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString() 
                            && float.Parse(row.Cells["pricecolumn"].Value.ToString()) == unitprice)
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                            row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvsaleproducts.Rows.Add("", mfr, productid, productname, qty, unitid, unitname, unitprice.ToString("N2"),
                        vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise.ToString("N2"), warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter,
                        vatpercentage, discountpercentage, discounttype);
                }

                ResetLabelsData();
            }
        }

        private void ResetLabelsData()
        {
            mfrtxtbox.Text = string.Empty;
            selectproducttxtbox.Text = string.Empty;
            productidlbl.Text = string.Empty;
            qtytxtbox.Text = string.Empty;
            invoicecodelbl.Text = string.Empty;
            warehouseidlbl.Text = string.Empty;
            itemdescriptionlbl.Text = string.Empty;
            unitsalepricelbl.Text = string.Empty;
            pricepermeterlbl.Text = string.Empty;
            lengthinmeterlbl.Text = string.Empty;

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

                        await CommonFunction.DisposeOnCloseAsync(productSelection);
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
                        
                        bool shouldOpenForm = false;
                        if (result != null && result.Rows.Count > 0)
                        {
                            foreach (DataRow row in result.Rows)
                            {
                                // Assuming the column name for quantity is "TotalQuantity"
                                int quantity = row["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(row["TotalQuantity"]) : 0;

                                // Check if the quantity is greater than zero
                                if (quantity > 0)
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
                                // Create and show VATForm after WarehouseQty is closed
                                VATForm vATForm = new VATForm(Convert.ToInt32(qtytxtbox.Text),false)
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
                VATForm vATForm = new VATForm(Convert.ToInt32(qtytxtbox.Text),false)
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
            await CommonFunction.CalculateTotalVatColumnAsync(8, dgvsaleproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(9, dgvsaleproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalColumnAsync(10, dgvsaleproducts, nettotaltxtbox);
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
    