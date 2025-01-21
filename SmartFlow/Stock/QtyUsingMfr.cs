using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class QtyUsingMfr : Form
    {
        private int invoiceCounter = 1;
        public QtyUsingMfr()
        {
            InitializeComponent();
            dgvinventory.CellDoubleClick += dgvinventory_CellDoubleClick;
        }
        private async void searchbtn_Click(object sender, EventArgs e)
        {
            string searchvalue = searchtextbox.Text.Trim();
            searchtextbox.Clear();
            string getproductdata = string.Format("SELECT ProductID,ProductName,MFR,Barcode,UPC FROM ProductTable WHERE MFR = '" + searchvalue + "'");
            DataTable datatableproduct = await DatabaseAccess.RetriveAsync(getproductdata);
            string productid = null, productname = null, mfr = null, barcode = null, upc = null;

            int quantity = 0;
            if (datatableproduct.Rows.Count > 0)
            {
                bool productExists = false;
                foreach (DataGridViewRow row in dgvinventory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Assuming the ProductID column index is 0 and Quantity column index is 2
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == datatableproduct.Rows[0]["ProductID"].ToString())
                        {
                            // Increment the quantity
                            int currentQuantity = Convert.ToInt32(row.Cells["productquantity"].Value);
                            row.Cells["productquantity"].Value = currentQuantity + 1;
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
                    productid = datatableproduct.Rows[0]["ProductID"].ToString();
                    productname = datatableproduct.Rows[0]["ProductName"].ToString();
                    mfr = datatableproduct.Rows[0]["MFR"].ToString();
                    barcode = datatableproduct.Rows[0]["Barcode"].ToString();
                    upc = datatableproduct.Rows[0]["UPC"].ToString();
                    quantity = 1;

                    int newRowIndex = dgvinventory.Rows.Add(productid, productname, upc, mfr, barcode, quantity);
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
                MessageBox.Show("Product Not Available");
            }
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
                    errorProvider.SetError(selectwarehousetxtbox,"Please Select Warehouse.");
                    selectwarehousetxtbox.Focus();
                    return;
                }

                if(dgvinventory.Rows.Count == 0)
                {
                    errorProvider.SetError(dgvinventory,"No Product Selected");
                    dgvinventory.Focus();
                    return;
                }

                string query = string.Empty;
                bool result = false;
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

                        if (quantity > 0 && stockcustomid > 0)
                        {
                            tableName = "StockTable";

                            var stockColumnData = new Dictionary<string, object>
                            {
                                { "ProductID", productid },
                                { "ProductMfr", mfr },
                                { "Quantity", quantity },
                                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                { "WarehouseId", warehouseid },
                                { "StockCustom_ID", stockcustomid }
                            };

                            result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", stockColumnData);
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

                                        var serialData = new Dictionary<string, object>
                                        {
                                            { "ProductId", productid },
                                            { "SerialNo", serialnumber },
                                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() }
                                        };
                                        await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", serialData);
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
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }
        private void QtyUsingMfr_KeyDown(object sender, KeyEventArgs e)
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
        private async void QtyUsingMfr_Load(object sender, EventArgs e)
        {
            qtyusingmfridlbl.Text = await GenerateNextInvoiceNumber();
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
                string newInvoiceNumber = qtyusingmfridlbl.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    return qtyusingmfridlbl.Text;
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
                    string invoicepart = "QUM";
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
                    string invoicepart = "QUM";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch(Exception ex) 
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
                string query = $"SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'QUM-{datePart}-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return lastInvoiceNumber;
        }
        private bool AreAnyTextBoxesFilled()
        {
            if(selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (searchtextbox.Text.Trim().Length > 0) { return true; }
            if (importantnotestxtbox.Text.Trim().Length > 0) { return true; }
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
                            await CommonFunction.DisposeOnCloseAsync(warehouseSelection);
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
                        /*supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        codetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;*/
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

        private void dgvinventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click was in the "Quantity" column
            if (dgvinventory.Columns[e.ColumnIndex].Name == "productquantity" && e.RowIndex >= 0)
            {
                // Put the cell in edit mode
                dgvinventory.BeginEdit(true);
            }
        }

        private void dgvinventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvinventory.Columns[e.ColumnIndex].Name == "productquantity" && e.RowIndex >= 0)
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
