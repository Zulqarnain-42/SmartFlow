using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Purchase
{
    public partial class PurchaseOrder : Form
    {
        private int invoiceCounter = 1;
        private decimal Initializer = 0;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        public PurchaseOrder(DataTable dtinvoice, DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }

        private void PurchaseOrderInvoice_Load(object sender, EventArgs e)
        {
            PopulateInvoiceDetails();
        }


        private void PopulateInvoiceDetails()
        {
            try
            {
                // Validate data tables
                if (IsDataTableValid(_dtinvoice) && IsDataTableValid(_dtinvoicedetails))
                {
                    PopulateInvoiceHeader(_dtinvoice.Rows[0]);
                    PopulateInvoiceDetailsGrid(_dtinvoicedetails);
                    savebtn.Text = "UPDATE";
                }
                else
                {
                    ResetInvoiceForm();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while processing the invoice details.");
            }
        }

        private bool IsDataTableValid(DataTable table)
        {
            return table != null && table.Rows.Count > 0;
        }

        private void PopulateInvoiceHeader(DataRow invoiceRow)
        {
            invoicenotxtbox.Text = GetSafeString(invoiceRow, "InvoiceNo");
            codetxtbox.Text = GetSafeString(invoiceRow, "CodeAccount");
            invoicedatetxtbox.Text = GetSafeDateString(invoiceRow, "invoicedate", "dd/MM/yyyy", DateTime.Now);
            selectsuppliertxtbox.Text = GetSafeString(invoiceRow, "ClientName");
            supplieridlbl.Text = GetSafeString(invoiceRow, "ClientID");
            invoicecodelbl.Text = GetSafeString(invoiceRow, "InvoiceCode");
            companytxtbox.Text = GetSafeString(invoiceRow, "CompanyName");
        }

        private void PopulateInvoiceDetailsGrid(DataTable invoiceDetails)
        {
            foreach (DataRow detailsRow in invoiceDetails.Rows)
            {
                int rowIndex = dgvpurchaseproducts.Rows.Add();
                SetCellValue(rowIndex, "mfrcolumn", detailsRow, "MFR");
                SetCellValue(rowIndex, "productidcolumn", detailsRow, "Productid");
                SetCellValue(rowIndex, "productnamecolumn", detailsRow, "ProductName");
                SetCellValue(rowIndex, "qtycolumn", detailsRow, "Quantity", true);
                SetCellValue(rowIndex, "pricecolumn", detailsRow, "UnitSalePrice", true);
                SetCellValue(rowIndex, "unitidcolumn", detailsRow, "Unitid");
                SetCellValue(rowIndex, "unitnamecolumn", detailsRow, "UnitName");
                SetCellValue(rowIndex, "vatcolumn", detailsRow, "ItemWiseVAT", true);
                SetCellValue(rowIndex, "itemdescriptioncolummn", detailsRow, "ItemDescription");
                SetCellValue(rowIndex, "pricepermetercolumn", detailsRow, "PricePerMeter", true);
                SetCellValue(rowIndex, "lengthinmetercolumn", detailsRow, "LengthInMeter", true);
                SetCellValue(rowIndex, "totalcolumn", detailsRow, "ItemTotal", true);
            }
        }

        private async void ResetInvoiceForm()
        {
            nettotaltxtbox.Text = "0.00"; // Default total
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
        }

        private string GetSafeString(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() ?? string.Empty : string.Empty;
        }

        private string GetSafeDateString(DataRow row, string columnName, string format, DateTime defaultValue)
        {
            if (row.Table.Columns.Contains(columnName) && DateTime.TryParse(row[columnName]?.ToString(), out DateTime dateValue))
            {
                return dateValue.ToString(format);
            }
            return defaultValue.ToString(format);
        }

        private void SetCellValue(int rowIndex, string columnName, DataRow sourceRow, string sourceColumnName, bool isNumeric = false)
        {
            if (dgvpurchaseproducts.Columns.Contains(columnName) && sourceRow.Table.Columns.Contains(sourceColumnName))
            {
                var value = sourceRow[sourceColumnName];
                dgvpurchaseproducts.Rows[rowIndex].Cells[columnName].Value = isNumeric && decimal.TryParse(value?.ToString(), out decimal numericValue)
                    ? (object)numericValue
                    : value?.ToString();
            }
        }

        private void HandleException(Exception ex, string userMessage)
        {
            // Log the exception details (e.g., to a file or logging framework)
            Debug.WriteLine(ex.ToString());

            // Display user-friendly message
            MessageBox.Show(userMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                const string InvoicePrefix = "PO";
                string datePart = DateTime.Today.ToString("yyMMdd");
                string lastInvoiceNumber = await GetLastInvoiceNumber();

                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    // Start with the first invoice if no previous invoice exists
                    return GenerateInvoiceNumber(InvoicePrefix, datePart, 1);
                }

                // Extract and increment the sequential part from the last invoice
                int lastSequentialNumber = ExtractSequentialNumber(lastInvoiceNumber);
                return GenerateInvoiceNumber(InvoicePrefix, datePart, lastSequentialNumber + 1);
            }
            catch (FormatException formatEx)
            {
                LogError(formatEx);
                MessageBox.Show("An error occurred while processing the invoice format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An unexpected error occurred while generating the invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string GenerateInvoiceNumber(string prefix, string datePart, int sequentialNumber)
        {
            return $"{prefix}-{datePart}-{sequentialNumber:D5}";
        }

        private int ExtractSequentialNumber(string invoiceNumber)
        {
            try
            {
                // Extract the sequential part from the last invoice number
                string sequentialPart = invoiceNumber.Substring(invoiceNumber.LastIndexOf('-') + 1);
                return int.Parse(sequentialPart);
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to extract sequential number from the invoice.", ex);
            }
        }

        private void LogError(Exception ex)
        {
            // Log error details for debugging purposes
            Debug.WriteLine($"Error: {ex.Message}");
            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
        }


        private async Task<string> GetLastInvoiceNumber()
        {
            try
            {
                const string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PO-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);

                if (invoiceData?.Rows.Count > 0)
                {
                    return invoiceData.Rows[0]["InvoiceNo"].ToString();
                }

                return null; // Return null if no matching rows are found
            }
            catch (Exception ex)
            {
                LogError(ex); // Log the error for debugging purposes
                MessageBox.Show("An error occurred while retrieving the last invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                // Retrieve the last invoice number from the database
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Validate the new invoice number input
                if (string.IsNullOrWhiteSpace(newInvoiceNumber))
                {
                    throw new InvalidOperationException("Invoice number cannot be empty or null.");
                }

                // If no last invoice exists, or the new invoice number is valid, return the new invoice number
                if (string.IsNullOrEmpty(lastInvoiceNumber) || String.Compare(newInvoiceNumber, lastInvoiceNumber, StringComparison.Ordinal) > 0)
                {
                    return newInvoiceNumber;
                }

                // If the new invoice number is not valid, generate the next invoice number
                return await GenerateNextInvoiceNumber();
            }
            catch (InvalidOperationException ex)
            {
                // Handle validation-related errors
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                // Log unexpected errors and notify the user
                LogError(ex);
                MessageBox.Show("An unexpected error occurred while validating the invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool isInserted = false;
                string invoiceno = string.Empty;

                if (selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox, "Please Select Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                if (dgvpurchaseproducts.Rows.Count == 0)
                {
                    errorProvider.SetError(dgvpurchaseproducts,"Please Select Products");
                    selectproducttxtbox.Focus();
                    return;
                }

                if(savebtn.Text == "UPDATE")
                {
                    invoiceno = invoicenotxtbox.Text;
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string invoicecode = Guid.NewGuid().ToString();
                    int supplierId = Convert.ToInt32(supplieridlbl.Text);
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    float nettotal = float.Parse(nettotaltxtbox.Text.ToString());
                    float totalvat = float.Parse(totalvattxtbox.Text);

                    string tableName = "InvoiceTable";
                    string whereClause = "InvoiceNo = '" + invoiceno + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierId },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", nettotal },
                        { "ClientName", supplierName },
                        { "TotalVat", totalvat }
                    };

                    bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceno, invoicecode);
                    }
                }
                else
                {
                    invoiceno = await CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string invoicecode = Guid.NewGuid().ToString();
                    int supplierId = Convert.ToInt32(supplieridlbl.Text);
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    float nettotal = float.Parse(nettotaltxtbox.Text.ToString());
                    float totalvat = float.Parse(totalvattxtbox.Text);

                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierId },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", nettotal },
                        { "ClientName", supplierName },
                        { "TotalVat", totalvat }
                    };

                    bool insertorder = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                    if (insertorder)
                    {
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (row.IsNewRow) { continue; }

                            int productid = Convert.ToInt32(row.Cells["productidcolumn"].Value.ToString());
                            int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                            float costprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                            string productname = row.Cells["productnamecolumn"].Value.ToString();
                            string mfr = row.Cells["mfrcolumn"].Value.ToString();
                            float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                            int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                            float itemVat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                            string itemdescription = row.Cells["itemdescriptioncolummn"].Value.ToString();
                            float pricepermeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                            float lengthinmeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());

                            string subtable = "InvoiceDetailsTable";
                            var subColumnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceno },
                                { "Invoicecode", invoicecode },
                                { "Productid", productid },
                                { "Quantity", quantity },
                                { "UnitSalePrice", costprice },
                                { "ProductName", productname },
                                { "ItemTotal", total },
                                { "MFR", mfr },
                                { "MinusInventory", false },
                                { "Unitid", unitid },
                                { "ItemWiseVAT",itemVat },
                                { "ItemDescription",itemdescription },
                                { "PricePerMeter",pricepermeter },
                                { "LengthInMeter",lengthinmeter },
                                { "AddInventory",false }
                            };

                            isInserted = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);

                        }
                        isInserted = true;
                    }
                }

                if (isInserted)
                {
                    OrderReportView orderReport = new OrderReportView(invoiceno);
                    orderReport.MdiParent = Application.OpenForms["Dashboard"];
                    await CommonFunction.DisposeOnCloseAsync(orderReport);
                    orderReport.Show();
                    this.Close();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void UpdateInvoiceDetailsData(string invoiceNo,string invoiceCode)
        {
            try
            {
                bool isInserted = false;

                // Backup and delete existing invoice details
                InsertBackUpData(invoiceNo, invoiceCode);
                DeleteInvoiceDetail(invoiceNo);

                // Loop through DataGridView rows
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    try
                    {
                        // Safely extract and validate values from DataGridView cells
                        int productId = Convert.ToInt32(row.Cells["productidcolumn"].Value ?? throw new InvalidOperationException("Product ID cannot be null."));
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value ?? throw new InvalidOperationException("Quantity cannot be null."));
                        float costPrice = float.Parse(row.Cells["pricecolumn"].Value?.ToString() ?? throw new InvalidOperationException("Cost Price cannot be null."));
                        string productName = row.Cells["productnamecolumn"].Value?.ToString() ?? throw new InvalidOperationException("Product Name cannot be null.");
                        string mfr = row.Cells["mfrcolumn"].Value?.ToString() ?? throw new InvalidOperationException("MFR cannot be null.");
                        float total = float.Parse(row.Cells["totalcolumn"].Value?.ToString() ?? throw new InvalidOperationException("Total cannot be null."));
                        int unitId = Convert.ToInt32(row.Cells["unitidcolumn"].Value ?? throw new InvalidOperationException("Unit ID cannot be null."));
                        float itemVat = float.Parse(row.Cells["vatcolumn"].Value?.ToString() ?? throw new InvalidOperationException("VAT cannot be null."));
                        string itemDescription = row.Cells["itemdescriptioncolummn"].Value?.ToString() ?? string.Empty;
                        float pricePerMeter = float.Parse(row.Cells["pricepermetercolumn"].Value?.ToString() ?? "0");
                        float lengthInMeter = float.Parse(row.Cells["lengthinmetercolumn"].Value?.ToString() ?? "0");

                        // Prepare data for insertion
                        string subTable = "InvoiceDetailsTable";
                        var subColumnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "InvoiceCode", invoiceCode },
                { "ProductId", productId },
                { "Quantity", quantity },
                { "UnitSalePrice", costPrice },
                { "ProductName", productName },
                { "ItemTotal", total },
                { "MFR", mfr },
                { "AddInventory", false },
                { "MinusInventory", false },
                { "UnitId", unitId },
                { "ItemWiseVAT", itemVat },
                { "ItemDescription", itemDescription },
                { "PricePerMeter", pricePerMeter },
                { "LengthInMeter", lengthInMeter }
            };

                        // Execute the insertion query
                        isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);

                        if (!isInserted)
                        {
                            throw new InvalidOperationException($"Failed to insert data for Product ID: {productId}");
                        }
                    }
                    catch (Exception rowEx)
                    {
                        // Log and notify about row-specific errors
                        Debug.WriteLine($"Error processing row: {rowEx.Message}");
                        MessageBox.Show($"An error occurred while processing a row: {rowEx.Message}", "Row Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // If data was successfully inserted, open the Order Report View
                if (isInserted)
                {
                    OrderReportView orderReport = new OrderReportView(invoiceNo)
                    {
                        MdiParent = Application.OpenForms["Dashboard"]
                    };
                    await CommonFunction.DisposeOnCloseAsync(orderReport);
                    orderReport.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Log and handle unexpected errors
                Debug.WriteLine($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
                MessageBox.Show("An unexpected error occurred while saving the invoice details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void InsertBackUpData(string invoiceNo, string invoicecode)
        {
            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                try
                {
                    if (row.IsNewRow) continue;

                    // Validate and extract values from DataGridView cells
                    int productId = Convert.ToInt32(row.Cells["productidcolumn"].Value ?? throw new InvalidOperationException("Product ID cannot be null."));
                    int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value ?? throw new InvalidOperationException("Quantity cannot be null."));
                    float costPrice = float.Parse(row.Cells["pricecolumn"].Value?.ToString() ?? throw new InvalidOperationException("Cost Price cannot be null."));
                    string productName = row.Cells["productnamecolumn"].Value?.ToString() ?? throw new InvalidOperationException("Product Name cannot be null.");
                    string mfr = row.Cells["mfrcolumn"].Value?.ToString() ?? throw new InvalidOperationException("Manufacturer (MFR) cannot be null.");
                    float total = float.Parse(row.Cells["totalcolumn"].Value?.ToString() ?? throw new InvalidOperationException("Total cannot be null."));
                    int unitId = Convert.ToInt32(row.Cells["unitidcolumn"].Value ?? throw new InvalidOperationException("Unit ID cannot be null."));
                    float itemVat = float.Parse(row.Cells["vatcolumn"].Value?.ToString() ?? throw new InvalidOperationException("VAT cannot be null."));
                    string itemDescription = row.Cells["itemdescriptioncolummn"].Value?.ToString() ?? string.Empty; // Allow empty descriptions
                    float pricePerMeter = float.Parse(row.Cells["pricepermetercolumn"].Value?.ToString() ?? "0"); // Default to 0 if null
                    float lengthInMeter = float.Parse(row.Cells["lengthinmetercolumn"].Value?.ToString() ?? "0"); // Default to 0 if null

                    // Prepare data for the database
                    string subTable = "InvoiceDetailsTable";
                    var subColumnData = new Dictionary<string, object>
        {
            { "InvoiceNo", invoiceNo },
            { "InvoiceCode", invoicecode },
            { "ProductId", productId },
            { "Quantity", quantity },
            { "UnitSalePrice", costPrice },
            { "ProductName", productName },
            { "ItemTotal", total },
            { "MFR", mfr },
            { "AddInventory", false },
            { "MinusInventory", false },
            { "UnitId", unitId },
            { "ItemWiseVAT", itemVat },
            { "ItemDescription", itemDescription },
            { "PricePerMeter", pricePerMeter },
            { "LengthInMeter", lengthInMeter }
        };

                    // Execute the insert query
                    bool isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);

                    if (!isInserted)
                    {
                        throw new InvalidOperationException($"Failed to insert data for Product ID: {productId}");
                    }
                }
                catch (Exception ex)
                {
                    // Log and notify about row-specific errors
                    Debug.WriteLine($"Error processing row: {ex.Message}");
                    MessageBox.Show($"An error occurred while processing a row: {ex.Message}", "Row Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private async void DeleteInvoiceDetail(string invoiceNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(invoiceNo))
                {
                    throw new ArgumentException("Invoice number cannot be null or empty.", nameof(invoiceNo));
                }

                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
        {
            { "@InvoiceNo", invoiceNo }
        };

                // Execute the delete query
                bool isDeleted = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

                if (!isDeleted)
                {
                    throw new InvalidOperationException($"Failed to delete details for InvoiceNo: {invoiceNo}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Debug.WriteLine($"Error deleting invoice details: {ex.Message}");

                // Rethrow the exception with additional context
                throw new Exception($"An error occurred while deleting details for InvoiceNo: {invoiceNo}.", ex);
            }
        }


        private async void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new instance of the PurchaseOrder form
                PurchaseOrder purchaseOrderInvoice = new PurchaseOrder
                {
                    MdiParent = this.MdiParent
                };

                // Ensure the form gets disposed properly when closed
                await CommonFunction.DisposeOnCloseAsync(purchaseOrderInvoice);

                // Show the new form
                purchaseOrderInvoice.Show();
            }
            catch (Exception ex)
            {
                // Log the error or show an error message to the user
                MessageBox.Show($"An error occurred while opening the Purchase Order form: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
                // Check if the Control key and D key are pressed
                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Check if at least one row is selected
                    if (dgvpurchaseproducts.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("No row selected. Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ensure that the selected row has a valid product ID
                    int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells[0].Value);
                    if (productid > 0)
                    {
                        // Create a list to store rows to remove
                        var rowsToRemove = new List<DataGridViewRow>();

                        foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                rowsToRemove.Add(row);
                            }
                        }

                        // Remove rows outside of the loop to avoid modifying the collection while iterating
                        foreach (var row in rowsToRemove)
                        {
                            dgvpurchaseproducts.Rows.Remove(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select a valid product row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.KeyCode == Keys.E)
                {
                    HandleRowSelectionAsync();
                }
        }


        private void PurchaseOrderInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Check if the Escape key is pressed
                if (e.KeyCode == Keys.Escape)
                {
                    // If any textboxes are filled, ask for confirmation before closing
                    if (AreAnyTextBoxesFilled())
                    {
                        DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                              "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        // Close the form if 'Yes' is clicked
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                            e.Handled = true; // Prevent further processing
                        }
                    }
                    else
                    {
                        // If no changes were made, just close the form
                        this.Close();
                        e.Handled = true; // Prevent further processing
                    }
                }

                if (e.Control && e.KeyCode == Keys.C)
                {
                    CurrencySelection currencySelection = new CurrencySelection();
                    currencySelection.DataSent += currencySelection_DataSent;
                    currencySelection.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private async void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the textbox is empty before opening the form
                if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                {
                    // Check if the SupplierSelectionForm is already open
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
                    if (openForm == null)
                    {
                        // If not open, create and show the SupplierSelectionForm
                        SupplierSelectionForm supplierSelectionForm = new SupplierSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Attach the FormClosed event to update the supplier info in the textbox
                        supplierSelectionForm.SupplierDataSelected += UpdateSupplierTextBox;

                        // Ensure proper disposal of the form when it is closed
                        await CommonFunction.DisposeOnCloseAsync(supplierSelectionForm);
                        supplierSelectionForm.ShowDialog();
                    }
                    else
                    {
                        // If already open, bring it to the front
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void UpdateSupplierTextBox(object sender, SupplierData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int supplierId = e.SupplierId;
                    string supplierName = e.SupplierName;
                    string supplierCode = e.SupplierCode;
                    string companyName = e.SupplierCompanyName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        codetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;
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
            try
            {
                // Check if the supplier textbox is filled
                if (!string.IsNullOrWhiteSpace(selectsuppliertxtbox.Text))
                {
                    return true;
                }

                // Check if the product textbox is filled
                if (!string.IsNullOrWhiteSpace(selectproducttxtbox.Text))
                {
                    return true;
                }

                // Check if the DataGridView contains any rows
                if (dgvpurchaseproducts != null && dgvpurchaseproducts.Rows.Count > 0)
                {
                    return true;
                }

                // If none of the conditions are met, return false
                return false;
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors and log them (or display to the user)
                MessageBox.Show($"An error occurred while checking if any text boxes are filled: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Return false in case of an error
            }
        }


        private async void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(8,dgvpurchaseproducts,nettotaltxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(7,dgvpurchaseproducts,totalvattxtbox);
        }

        private async void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(9, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(8, dgvpurchaseproducts, totalvattxtbox);
        }

        private async void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Check if the textbox is empty
                    if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                    {
                        // Check if the SupplierSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));

                        // If the form is not open, create and show it
                        if (openForm == null)
                        {
                            SupplierSelectionForm supplierSelectionForm = new SupplierSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Event handler for when the form is closed
                            supplierSelectionForm.SupplierDataSelected += UpdateSupplierTextBox;

                            // Ensure the form is disposed of when closed
                            await CommonFunction.DisposeOnCloseAsync(supplierSelectionForm);
                            supplierSelectionForm.ShowDialog();
                        }
                        else
                        {
                            // Bring the already open form to the front
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur and show a message box
                MessageBox.Show($"An error occurred while handling the supplier textbox: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the product textbox is empty
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    // Check if the ProductSelectionForm is already open
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

                    // If the form is not open, create and show it
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        productSelectionForm.ProductDataSelected += UpdateProductTextBox;

                        // Ensure the form is disposed of when closed
                        await CommonFunction.DisposeOnCloseAsync(productSelectionForm);
                        productSelectionForm.ShowDialog();
                    }
                    else
                    {
                        // Bring the already open form to the front
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur and show a message box
                MessageBox.Show($"An error occurred while handling the product textbox: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Check if the Enter key is pressed
                if (e.KeyCode == Keys.Enter)
                {
                    // If the product textbox is empty
                    if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                    {
                        // Check if the ProductSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

                        // If the form is not open, create and show it
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
                            // Bring the already open form to the front
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and show an error message
                MessageBox.Show($"An error occurred while handling the product textbox: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all required fields are filled
                if (!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
                {
                    // Parse values from the UI and handle potential conversion errors
                    try
                    {
                        string mfr = mfrtxtbox.Text;
                        string productid = productidlbl.Text;
                        string productname = selectproducttxtbox.Text;
                        int qty = Convert.ToInt32(qtytxtbox.Text); // Ensure quantity is a valid integer
                        string itemdescription = itemdescriptionlbl.Text;
                        decimal saleprice = decimal.Parse(unitsalepricelbl.Text); // Ensure sale price is a valid decimal
                        decimal pricepermeter = decimal.Parse(pricepermeterlbl.Text); // Ensure price per meter is valid
                        decimal lengthinmeter = decimal.Parse(lengthinmeterlbl.Text); // Ensure length in meters is valid
                        decimal itemtotal = decimal.Parse(totalcolumnlbl.Text); // Ensure item total is valid
                        int unitid = Convert.ToInt32(unitidlbl.Text); // Ensure unit ID is valid
                        string unitname = unitnamelbl.Text;
                        decimal itemvat = decimal.Parse(productvatlbl.Text); // Ensure VAT value is valid

                        bool productExists = false;

                        // Loop through existing products to check if the product already exists in the DataGridView
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                // If product already exists, update the quantity
                                if (row.Cells["productidcolumn"].Value != null &&
                                    row.Cells["productidcolumn"].Value.ToString() == productidlbl.Text)
                                {
                                    int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                    int totalqty = currentQuantity + qty;
                                    row.Cells["qtycolumn"].Value = totalqty;

                                    productExists = true;
                                    break;
                                }
                            }
                        }

                        // If product does not exist, add new row to DataGridView
                        if (!productExists)
                        {
                            dgvpurchaseproducts.Rows.Add("",mfr, productid, productname, qty, unitid, unitname, saleprice, itemvat, itemtotal, itemdescription, pricepermeter, lengthinmeter);

                            // Clear input fields
                            mfrtxtbox.Text = string.Empty;
                            productidlbl.Text = string.Empty;
                            selectproducttxtbox.Text = string.Empty;
                            qtytxtbox.Text = string.Empty;

                            // Focus back on the product textbox
                            selectproducttxtbox.Focus();
                        }
                    }
                    catch (FormatException ex)
                    {
                        // Catch format errors (e.g., invalid number formats)
                        MessageBox.Show($"Error: Invalid format in input fields. Please check the values entered. \nDetails: {ex.Message}",
                                        "Invalid Data Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Catch any other general errors
                        MessageBox.Show($"An error occurred while processing your request. \nDetails: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Show a message box if any required field is empty
                    MessageBox.Show("Please fill all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors
                MessageBox.Show($"An unexpected error occurred. Please try again. \nDetails: {ex.Message}",
                                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Allow control characters (e.g., backspace, delete, etc.) and digits
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // Block the invalid character and show a message box
                    e.Handled = true;
                    MessageBox.Show("Please enter only numeric values for quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors gracefully
                MessageBox.Show($"An error occurred while processing your input. \nDetails: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void dgvpurchaseproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(8, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(7, dgvpurchaseproducts, totalvattxtbox);
        }

        private void removevatchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (removevatchkbox.Checked)
            {
                // Iterate through the DataGridView rows
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
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
            try
            {
                // Ensure that the text in qtytxtbox is numeric and valid before proceeding
                if (int.TryParse(qtytxtbox.Text, out int itemqty))
                {
                    // Check if the quantity is greater than zero
                    if (itemqty > 0)
                    {
                        // Create a new VATForm with the item quantity
                        VATForm vATForm = new VATForm(itemqty, false)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Hook up the FormClosed event to update product data after closing VATForm
                        vATForm.FormClosed += async delegate
                        {
                            await UpdateProductDataAsync();
                        };

                        // Dispose VATForm when it's closed to release resources
                        await CommonFunction.DisposeOnCloseAsync(vATForm);
                        vATForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Quantity must be greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Handle invalid input (non-numeric values)
                    MessageBox.Show("Please enter a valid numeric quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    qtytxtbox.Focus(); // Focus back to the qtytxtbox for correction
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors gracefully
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task UpdateProductDataAsync()
        {
            await Task.Run(() =>
            {
                // Assuming these updates are thread-safe
                itemdescriptionlbl.Invoke((Action)(() => itemdescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl ?? "N/A"));
                unitsalepricelbl.Invoke((Action)(() => unitsalepricelbl.Text = GlobalVariables.productpriceglobal != 0 ? GlobalVariables.productpriceglobal.ToString("0.00") : "0.00"));
                pricepermeterlbl.Invoke((Action)(() => pricepermeterlbl.Text = GlobalVariables.productinmeterprice != 0 ? GlobalVariables.productinmeterprice.ToString("0.00") : "0.00"));
                lengthinmeterlbl.Invoke((Action)(() => lengthinmeterlbl.Text = GlobalVariables.productinmeterlength != 0 ? GlobalVariables.productinmeterlength.ToString("0.00") : "0.00"));
                totalcolumnlbl.Invoke((Action)(() => totalcolumnlbl.Text = GlobalVariables.productfinalamountwithvatanddiscountitemwise != 0 ? GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("0.00") : "0.00"));
                unitnamelbl.Invoke((Action)(() => unitnamelbl.Text = GlobalVariables.unitnameglobal ?? "N/A"));
                unitidlbl.Invoke((Action)(() => unitidlbl.Text = GlobalVariables.unitidglobal != 0 ? GlobalVariables.unitidglobal.ToString() : "0"));
                productvatlbl.Invoke((Action)(() => productvatlbl.Text = GlobalVariables.productitemwisevatamount != 0 ? GlobalVariables.productitemwisevatamount.ToString("0.00") : "0.00"));
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
            });
        }

        private void dgvpurchaseproducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            if (dgvpurchaseproducts.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dgvpurchaseproducts.SelectedRows[0]; // Get the first selected row
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
