using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class DamageEntry : Form
    {
        private int invoiceCounter = 1;
        private DataTable _datainvoice;
        private DataTable _detailinvoicedata;

        public DamageEntry()
        {
            InitializeComponent();
        }

        public DamageEntry(DataTable datainvoice,DataTable detailinvoicedata)
        {
            InitializeComponent();
            this._datainvoice = datainvoice;
            this._detailinvoicedata = detailinvoicedata;
        }

        private async void DamageEntry_Load(object sender, EventArgs e)
        {
            if(_datainvoice != null && _datainvoice.Rows.Count > 0 || _detailinvoicedata != null && _detailinvoicedata.Rows.Count > 0)
            {
                DataRow row = _datainvoice.Rows[0];
                
                descriptiontxtbox.Text = row["Description"].ToString();
                damageidlbl.Text = row["CustomStockID"].ToString();
                damagecodelbl.Text = row["Code"].ToString();
                warehouseidlbl.Text = _detailinvoicedata.Rows.Count > 0
                    ? _detailinvoicedata.Rows[0]["Warehouseid"]?.ToString() ?? ""
                    : "";

                selectwarehousefromtxtbox.Text = _detailinvoicedata.Rows.Count > 0
                    ? _detailinvoicedata.Rows[0]["Name"]?.ToString() ?? ""
                    : "";

                try
                {
                    dgvproducts.SuspendLayout();
                    dgvproducts.VirtualMode = false; // Ensure real-time updates
                    dgvproducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dgvproducts.AllowUserToAddRows = false; // Prevent ghost rows

                    List<DataGridViewRow> newRows = new List<DataGridViewRow>();

                    foreach (DataRow invoiceRow in _detailinvoicedata.Rows)
                    {
                        var newRow = new DataGridViewRow();
                        newRow.CreateCells(dgvproducts);

                        try
                        {
                            // Safely converting each value and setting the cells
                            newRow.Cells[dgvproducts.Columns["productid"].Index].Value = invoiceRow["ProductID"];
                            newRow.Cells[dgvproducts.Columns["productmfr"].Index].Value = invoiceRow["MFR"];
                            newRow.Cells[dgvproducts.Columns["productname"].Index].Value = invoiceRow["ProductName"];
                            newRow.Cells[dgvproducts.Columns["productupc"].Index].Value = invoiceRow["UPC"];
                            newRow.Cells[dgvproducts.Columns["productbarcode"].Index].Value = invoiceRow["Barcode"];
                            newRow.Cells[dgvproducts.Columns["damagedqty"].Index].Value = invoiceRow["Quantity"];

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
                    dgvproducts.Rows.AddRange(newRows.ToArray());
                }
                catch (Exception ex)
                {
                    // Log any errors encountered in the outer try block
                    Debug.WriteLine($"[Error] AddGridData: {ex.Message}");
                }
                finally
                {
                    // Ensure layout is resumed and the DataGridView is refreshed
                    dgvproducts.ResumeLayout();
                    this.Invoke((MethodInvoker)delegate { dgvproducts.Refresh(); });
                }
            }
            else
            {
                damageidlbl.Text = await GenerateNextInvoiceNumber();
            }
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Please Select Warehouse.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(descriptiontxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(descriptiontxtbox,"Please Add Description.");
                    descriptiontxtbox.Focus();
                    return;
                }

                if(string.IsNullOrEmpty(descriptiontxtbox.Text) && string.IsNullOrWhiteSpace(descriptiontxtbox.Text))
                {
                    errorProvider.SetError(descriptiontxtbox,"Kindly add Description");
                    descriptiontxtbox.Focus();
                    return;
                }

                bool IsInserted = await InsertDamageEntry();
                if (IsInserted) 
                {
                    MessageBox.Show("Saved Successfully!");
                    dgvproducts.Rows.Clear();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void DamageEntry_KeyDown(object sender, KeyEventArgs e)
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
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                errorProvider.Clear();
                if (productmfrtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(productmfrtxtbox, "Please Enter Product.");
                    productmfrtxtbox.Focus();
                    return;
                }

                if (qtytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytxtbox, "Please Enter Damaged Quantity.");
                    qtytxtbox.Focus();
                    return;
                }
                bool productExists = false;
                foreach(DataGridViewRow row in dgvproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString())
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["damagedqty"].Value);
                            row.Cells["damagedqty"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvproducts.Rows.Add(productidlbl.Text,productmfrtxtbox.Text, productnamelbl.Text, upclbl.Text, 
                        barcodelbl.Text, qtytxtbox.Text);
                }
                
                productmfrtxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                productmfrtxtbox.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = damageidlbl.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    return damageidlbl.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                    string invoicepart = "DE";
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
                    string invoicepart = "DE";
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
                string datePart = DateTime.Today.ToString("yyMMdd");
                string query = $"SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'DE-{datePart}-%' ORDER BY InvoiceNo DESC";
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
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvproducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvproducts.CurrentRow.Cells[0].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvproducts.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }
        private async void selectwarehousefromtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousefromtxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterScreen,
                            };

                            warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;

                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.Show();
                        }
                    }
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private async void producttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(productmfrtxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm()
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterScreen,
                    };

                    productSelectionForm.ProductDataSelected += UpdateProductTextBox;

                    CommonFunction.DisposeOnClose(productSelectionForm);
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
                        productnamelbl.Text = productname;
                        productmfrtxtbox.Text = productmfr;
                        upclbl.Text = productupc;
                        barcodelbl.Text = productbarcode;
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
                        selectwarehousefromtxtbox.Text = warehousename;
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
            if (selectwarehousefromtxtbox.Text.Trim().Length > 0) { return true; }
            if (productmfrtxtbox.Text.Trim().Length > 0) { return true; }
            if (qtytxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }

        private async Task<bool> InsertDamageEntry()
        {
            string invoiceNo = await CheckInvoiceBeforeInsert();
            string tableName = "StockCustomizedTable";
            var columnData = new Dictionary<string, object>
            {
                { "Code", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString() },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceNo", invoiceNo },
                { "Description", descriptiontxtbox.Text }
            };

            int result = await DatabaseAccess.InsertDataIdAsync(tableName, columnData);

            if (result > 0)
            {
                string subTable = "StockTable";

                foreach(DataGridViewRow row in dgvproducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = Convert.ToInt32(row.Cells["productid"].Value);
                    int warehouseId = Convert.ToInt32(warehouseidlbl.Text);
                    int quantity = Convert.ToInt32(row.Cells["damagedqty"].Value);
                    string productMfr = row.Cells["productmfr"].Value.ToString();

                    var detailData = new Dictionary<string, object>
                    {
                        { "ProductID", productId },
                        { "CreatedAt", DateTime.Now.ToString() },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "DamageQty", quantity },
                        { "Warehouseid", warehouseId },
                        { "Quantity", quantity },
                        { "ProductMfr", productMfr }
                    };

                    bool subResult = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", detailData);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
