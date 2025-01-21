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
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Purchase
{
    public partial class PurchaseQuotationInvoice : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
        public PurchaseQuotationInvoice()
        {
            InitializeComponent();
        }

        public PurchaseQuotationInvoice(DataTable dtInvoice,DataTable dtInvoiceDetail)
        {
            InitializeComponent();
            this._dtinvoice = dtInvoice;
            this._dtinvoicedetails = dtInvoiceDetail;
        }

        private async void PurchaseQuotationInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
                {
                    DataRow row = _dtinvoice.Rows[0];

                    // Set Invoice Data
                    invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                    codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;

                    // Safely handle DateTime conversion with fallback for empty or invalid data
                    if (DateTime.TryParse(row["invoicedate"]?.ToString(), out DateTime invoiceDate))
                    {
                        invoicedatetxtbox.Text = invoiceDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        invoicedatetxtbox.Text = string.Empty; // Fallback if DateTime is invalid
                    }

                    selectsuppliertxtbox.Text = row["ClientName"]?.ToString() ?? string.Empty;
                    supplieridlbl.Text = row["ClientID"]?.ToString() ?? string.Empty;
                    invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;

                    // Fill DataGridView with Invoice Details
                    foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                    {
                        int detailsRowIndex = dgvpurchaseproducts.Rows.Add();
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["mfrcolumn"].Value = invoiceDetailsRow["MFR"]?.ToString() ?? string.Empty;
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"]?.ToString() ?? string.Empty;
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"]?.ToString() ?? string.Empty;
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"] != DBNull.Value ? Convert.ToInt32(invoiceDetailsRow["Quantity"]) : 0;
                    }

                    savebtn.Text = "UPDATE";
                }
                else
                {
                    // Handle case when invoice or invoice details are null or empty
                    invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the invoice data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                // Get the last invoice number (this could be fetched from a database or a file)
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;
                int invoiceCounter = 1; // Default counter value, could be adjusted based on your requirement

                if (lastInvoiceNumber == null)
                {
                    // Generate the invoice number using the current date and a sequential number
                    string invoicePart = "PQ";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{invoicePart}-{datePart}-{sequentialPart}";

                    return newInvoiceNumber; // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    string invoicePart = "PQ";
                    string datePart = DateTime.Today.ToString("yyMMdd");

                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number with the incremented sequence
                    newInvoiceNumber = $"{invoicePart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show($"Error generating invoice number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                // Fetch the last invoice number from the system (database or file)
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Check if the invoice number is valid
                if (string.IsNullOrEmpty(lastInvoiceNumber) || string.IsNullOrEmpty(newInvoiceNumber))
                {
                    MessageBox.Show("Invoice number is not valid. Please check the invoice numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Compare the new invoice number with the last one
                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    // Generate and return the next invoice number if the new one is not greater
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    // Return the entered invoice number if it's valid and greater than the last one
                    return newInvoiceNumber;
                }
            }
            catch (Exception ex)
            {
                // Display error message and return null in case of an error
                MessageBox.Show($"Error checking invoice number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PQ-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInvoiceNumber;
        }

        private async void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();

                // Check if MdiParent is null
                if (this.MdiParent != null)
                {
                    purchaseQuotationInvoice.MdiParent = this.MdiParent;
                }
                else
                {
                    // Handle the case when MdiParent is null
                    MessageBox.Show("MdiParent is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                await CommonFunction.DisposeOnCloseAsync(purchaseQuotationInvoice);
                purchaseQuotationInvoice.Show();
            }
            catch (Exception ex)
            {
                // Error handling to catch any issues during the form instantiation or other operations
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool IsInserted = false;
                string invoiceno = string.Empty;
                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice no");
                    invoicenotxtbox.Focus();
                    return;
                }

                if(codetxtbox.Text.Trim().Length == 0 && selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox,"Please Select a Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                if (savebtn.Text == "UPDATE")
                {
                    invoiceno = invoicenotxtbox.Text;

                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string invoiceCode = invoicecodelbl.Text;
                    int supplierId = Convert.ToInt32(supplieridlbl.Text);
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string tableName = "InvoiceTable";
                    string whereClause = "InvoiceNo = '" + invoiceno + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierId },
                        { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "UpdatedDay", DateTime.Now.DayOfWeek },
                        { "ClientName", supplierName }
                    };

                    bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceno, invoiceCode);
                    }
                }
                else
                {
                    invoiceno = await CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierId = Convert.ToInt32(supplieridlbl.Text);
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoicecode = Guid.NewGuid().ToString();
                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierId },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "ClientName", supplierName }
                    };

                    bool insertquote = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);

                    if (insertquote)
                    {
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (row.IsNewRow) { continue; }

                            int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                            int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                            string productname = row.Cells["productnamecolumn"].Value.ToString();
                            string mfr = row.Cells["mfrcolumn"].Value.ToString();

                            string subtable = "InvoiceDetailsTable";
                            var subColumnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceno },
                                { "Invoicecode", invoicecode },
                                { "Productid", productid },
                                { "Quantity", quantity },
                                { "ItemSerialNoid", null },
                                { "ProductName", productname },
                                { "MFR", mfr },
                                { "AddInventory", false },
                                { "MinusInventory", false }
                            };

                            IsInserted = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                        }

                        IsInserted = true;
                    }
                }

                if (IsInserted)
                {
                    this.Close();
                    QuotationReportView quotationReportView = new QuotationReportView(invoiceno);
                    quotationReportView.MdiParent = Application.OpenForms["Dashboard"];
                    await CommonFunction.DisposeOnCloseAsync(quotationReportView);
                    quotationReportView.Show();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateInvoiceDetailsData(string invoiceNo,string invoiceCode)
        {
            /*bool detailadded = false;
            try
            {
                // Start a transaction
                using (var transaction = DatabaseAccess.BeginTransaction())
                {
                    // Insert backup data
                    InsertBackUpData(invoiceNo, invoiceCode);

                    // Delete existing invoice details
                    DeleteInvoiceDetail(invoiceNo);

                    // Insert new invoice details
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                        string productname = row.Cells["productnamecolumn"].Value.ToString();
                        string mfr = row.Cells["mfrcolumn"].Value.ToString();

                        string subtable = "InvoiceDetailsTable";
                        var subColumnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "Invoicecode", invoiceCode },
                { "Productid", productid },
                { "Quantity", quantity },
                { "ItemSerialNoid", null },
                { "ProductName", productname },
                { "MFR", mfr },
                 { "AddInventory", false },
                                { "MinusInventory", false }
            };

                        // Execute insert for each row
                        detailadded = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData, transaction);
                        if (!detailadded)
                        {
                            // Rollback transaction if insertion fails
                            transaction.Rollback();
                            MessageBox.Show("Error inserting details into the invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Commit the transaction if everything goes smoothly
                    transaction.Commit();

                    // After successful insertion, close the form and show report
                    this.Close();
                    QuotationReportView quotationReportView = new QuotationReportView(invoiceNo);
                    quotationReportView.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(quotationReportView);
                    quotationReportView.Show();
                }
            }
            catch (Exception ex)
            {
                // In case of any error, show the error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/

        }

        private async void InsertBackUpData(string invoiceNo, string invoicecode)
        {
            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) { continue; }

                int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                string productname = row.Cells["productnamecolumn"].Value.ToString();
                string mfr = row.Cells["mfrcolumn"].Value.ToString();

                string subtable = "InvoiceDetailsTable";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoicecode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "ItemSerialNoid", null },
                    { "ProductName", productname },
                    { "MFR", mfr },
                     { "AddInventory", false },
                                { "MinusInventory", false }
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

        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells[1].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvpurchaseproducts.Rows.Remove(row);
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

        private bool AreAnyTextBoxesFilled()
        {
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }

        private async void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    supplierSelection.SupplierDataSelected += UpdateSupplierTextBox;
                    await CommonFunction.DisposeOnCloseAsync(supplierSelection);
                    supplierSelection.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private async void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
            if (openForm == null)
            {
                SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                supplierSelection.SupplierDataSelected += UpdateSupplierTextBox;
                await CommonFunction.DisposeOnCloseAsync(supplierSelection);
                supplierSelection.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void PurchaseQuotationInvoice_KeyDown(object sender, KeyEventArgs e)
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

        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
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

                    await CommonFunction.DisposeOnCloseAsync(productSelectionForm);
                    productSelectionForm.ShowDialog();
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
                        mfrtxtbox.Text = productmfr.ToString();
                        selectproducttxtbox.Text = productname.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating Product information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectproducttxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectproducttxtbox,"Please Select Product.");
                    selectproducttxtbox.Focus();
                    return;
                }

                if(qtytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytxtbox,"Please Enter Quantity.");
                    qtytxtbox.Focus();
                    return;
                }

                int productid = Convert.ToInt32(productidlbl.Text);
                string productName = selectproducttxtbox.Text;
                string productMfr = mfrtxtbox.Text;
                int qty = Convert.ToInt32(qtytxtbox.Text);

                dgvpurchaseproducts.Rows.Add("",productMfr,productid,productName,qty);

                productidlbl.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                mfrtxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                selectproducttxtbox.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace, and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
