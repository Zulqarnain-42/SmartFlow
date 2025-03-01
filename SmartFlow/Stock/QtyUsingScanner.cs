using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class QtyUsingScanner : Form
    {
        private int invoiceCounter = 1;
        private DataTable _datainvoice;
        private DataTable _detaildatainvoice;
        public QtyUsingScanner()
        {
            InitializeComponent();
            dgvinventory.CellDoubleClick += dgvinventory_CellDoubleClick;
        }

        public QtyUsingScanner(DataTable datainvoice,DataTable detaildatainvoice)
        {
            InitializeComponent();
            this._datainvoice = datainvoice;
            this._detaildatainvoice = detaildatainvoice;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {

                errorProvider.Clear();
                if(selectwarehousetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetxtbox,"Please Select Warehouse");
                    selectwarehousetxtbox.Focus();
                    return;
                }

                if(dgvinventory.Rows.Count == 0)
                {
                    errorProvider.SetError(dgvinventory,"No Rows Available To Add");
                    dgvinventory.Focus();
                    return;
                }

                string query = string.Empty;
                string invoiceno = await CheckInvoiceBeforeInsert();
                string importantNotes = importantnotestxtbox.Text;

                string tableName = "StockCustomizedTable";
                var columnData = new Dictionary<string, object>
                {
                    { "Code", Guid.NewGuid().ToString() },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                    { "InvoiceNo", invoiceno },
                    { "Description", importantNotes }
                };

                int stockcustomid = await DatabaseAccess.InsertDataIdAsync(tableName, columnData);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);

                bool result = false;

                if (stockcustomid > 0) 
                {
                    foreach (DataGridViewRow row in dgvinventory.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string productid = Convert.ToString(row.Cells[0].Value);
                            string productname = Convert.ToString(row.Cells[1].Value);
                            string upc = Convert.ToString(row.Cells[2].Value);
                            string mfr = Convert.ToString(row.Cells[3].Value);
                            string barcode = Convert.ToString(row.Cells[4].Value);
                            int quantity = Convert.ToInt32(row.Cells[5].Value);

                            if (quantity > 0)
                            {
                                tableName = "StockTable";

                                var subtableData = new Dictionary<string, object>
                                {
                                    { "ProductID", productid },
                                    { "ProductMfr", mfr },
                                    { "Quantity", quantity },
                                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                    { "WarehouseId", warehouseid },
                                    { "StockCustom_ID", stockcustomid }
                                };

                                result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", subtableData); 
                                if (result)
                                {
                                    int count = 0;
                                    int diff = Convert.ToInt32(quantity) - count;

                                    if (diff > 0)
                                    {
                                        int start = 0;
                                        while (start < diff)
                                        {
                                            string serialnumber = await GenerateRandomSerialNumber();
                                            tableName = "SerialNoTable";

                                            var serialColumnData = new Dictionary<string, object>
                                            {
                                                { "ProductId", productid },
                                                { "SerialNo", serialnumber },
                                                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                                { "CreatedDay", DateTime.Now.DayOfWeek }
                                            };

                                            await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", serialColumnData);
                                            start++;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Inventory Updated");
                    dgvinventory.Rows.Clear();
                    importantnotestxtbox.Clear();
                    selectwarehousetxtbox.Clear();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void QtyUsingScanner_KeyDown(object sender, KeyEventArgs e)
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

        private async void searchDatabase(string barcode)
        {
            string query = "SELECT ProductID,ProductName,StandardPrice,UPC,EAN,MFR,Barcode " +
                "FROM ProductTable WHERE Barcode LIKE '" + barcode + "' OR UPC LIKE '" + barcode + "' OR MFR LIKE '" + barcode + "' " +
                "OR SecondUpc LIKE '" + barcode + "' OR EAN LIKE '" + barcode + "'";

            DataTable dataTable = await DatabaseAccess.RetriveAsync(query);
            string productid = null, mfr = null, title = null, upc = null, systembarcode = null;
            int quantity = 0;

            if (dataTable.Rows.Count>0)
            {
                bool productExists = false;
                foreach (DataGridViewRow row in dgvinventory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Assuming the ProductID column index is 0 and Quantity column index is 2
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == dataTable.Rows[0]["ProductID"].ToString())
                        {
                            // Increment the quantity
                            int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                            row.Cells["Quantity"].Value = currentQuantity + 1;
                            dgvinventory.ClearSelection();
                            row.Selected = true;
                            dgvinventory.FirstDisplayedScrollingRowIndex = row.Index;
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        productid = row["ProductID"].ToString();
                        title = row["ProductName"].ToString();
                        upc = row["UPC"].ToString();
                        mfr = row["MFR"].ToString();
                        systembarcode = row["Barcode"].ToString();
                        quantity = 1;
                    }

                    int newRowIndex = dgvinventory.Rows.Add(productid, title, upc, mfr, systembarcode, quantity);
                    dgvinventory.ClearSelection();
                    // Highlight and scroll to the new row
                    DataGridViewRow newRow = dgvinventory.Rows[newRowIndex];
                    newRow.Selected = true;

                    // Scroll to the new row to make sure it's visible
                    dgvinventory.FirstDisplayedScrollingRowIndex = newRowIndex;
                    searchtextbox.Clear();
                }
            }
            else
            {
                MessageBox.Show("UPC IS NOT AVAILABLE");
            }
        }
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            // Restart the timer on every character entered
            timerBarcode.Stop(); // Stop the timer in case it's already running
            timerBarcode.Start(); // Start the timer again
        }
        private async void QtyUsingScanner_Load(object sender, EventArgs e)
        {
            if(_datainvoice != null && _datainvoice.Rows.Count > 0 || _detaildatainvoice != null && _detaildatainvoice.Rows.Count > 0)
            {
                DataRow row = _datainvoice.Rows[0];
                importantnotestxtbox.Text = row["Description"].ToString();

                try
                {
                    dgvinventory.SuspendLayout();
                    dgvinventory.VirtualMode = false; // Ensure real-time updates
                    dgvinventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dgvinventory.AllowUserToAddRows = false; // Prevent ghost rows

                    List<DataGridViewRow> newRows = new List<DataGridViewRow>();

                    foreach (DataRow invoiceRow in _detaildatainvoice.Rows)
                    {
                        var newRow = new DataGridViewRow();
                        newRow.CreateCells(dgvinventory);

                        try
                        {
                            // Safely converting each value and setting the cells
                            newRow.Cells[dgvinventory.Columns["productid"].Index].Value = invoiceRow["ProductID"];
                            newRow.Cells[dgvinventory.Columns["productmfr"].Index].Value = invoiceRow["MFR"];
                            newRow.Cells[dgvinventory.Columns["productname"].Index].Value = invoiceRow["ProductName"];
                            newRow.Cells[dgvinventory.Columns["productupc"].Index].Value = invoiceRow["UPC"];
                            newRow.Cells[dgvinventory.Columns["barcode"].Index].Value = invoiceRow["Barcode"];
                            newRow.Cells[dgvinventory.Columns["quantity"].Index].Value = invoiceRow["Quantity"];

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
                    dgvinventory.Rows.AddRange(newRows.ToArray());
                }
                catch (Exception ex)
                {
                    // Log any errors encountered in the outer try block
                    Debug.WriteLine($"[Error] AddGridData: {ex.Message}");
                }
                finally
                {
                    // Ensure layout is resumed and the DataGridView is refreshed
                    dgvinventory.ResumeLayout();
                    this.Invoke((MethodInvoker)delegate { dgvinventory.Refresh(); });
                }
            }
            else
            {
                qtyusingscanneridlbl.Text = await GenerateNextInvoiceNumber();
            }
            timerBarcode.Interval = 300;
            timerBarcode.Tick += timerBarcode_Tick;
        }
        static async Task<string> GenerateRandomSerialNumber()
        {
            Random random = new Random();
            const string chars = "0123456789";
            char[] serialChars = new char[10];

            for (int i = 0; i < serialChars.Length; i++)
            {
                serialChars[i] = chars[random.Next(chars.Length)];
            }

            string serialNumber = new string(serialChars);
            string query = "SELECT SerialNo FROM SerialNoTable WHERE SerialNo = '" + serialNumber + "'";
            DataTable dt = await DatabaseAccess.RetriveAsync(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = await GenerateRandomSerialNumber();
                }
            }
            return serialNumber;
        }
        private void dgvinventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvinventory.CurrentRow.Cells[0].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvinventory.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvinventory.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }
        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = qtyusingscanneridlbl.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    return qtyusingscanneridlbl.Text;
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
                    string invoicepart = "QUS";
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
                    string invoicepart = "QUS";
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
                string query = $"SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'QUS-{datePart}-%' ORDER BY InvoiceNo DESC";
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
        private bool AreAnyTextBoxesFilled()
        {
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (searchtextbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private async void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousetxtbox.Text))
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
                                StartPosition = FormStartPosition.CenterParent,
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
                        selectwarehousetxtbox.Text = warehousename;
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

        private void timerBarcode_Tick(object sender, EventArgs e)
        {
            // Stop the timer to avoid repetitive actions
            timerBarcode.Stop();

            // Process the scanned barcode
            string barcode = searchtextbox.Text.Trim();

            if (!string.IsNullOrEmpty(barcode))
            {
                // Perform your desired action with the barcode (e.g., search in database)
                searchDatabase(barcode);

                // Clear the TextBox after processing (optional)
                searchtextbox.Clear();
            }
        }

        private void dgvinventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click was in the "Quantity" column
            if (dgvinventory.Columns[e.ColumnIndex].Name == "quantity" && e.RowIndex >= 0)
            {
                // Put the cell in edit mode
                dgvinventory.BeginEdit(true);
            }
        }

        private void dgvinventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvinventory.Columns[e.ColumnIndex].Name == "quantity" && e.RowIndex >= 0)
            {
                // Validate the input (ensure it's an integer, etc.)
                if (!int.TryParse(dgvinventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out int quantity))
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    dgvinventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Reset to default
                }
            }
        }
    }
}
