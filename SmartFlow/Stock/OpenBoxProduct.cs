using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class OpenBoxProduct : Form
    {
        private int invoiceCounter = 1;
        private DataTable _datainvoice;
        private DataTable _detaildatainvoice;
        public OpenBoxProduct()
        {
            InitializeComponent();
        }

        public OpenBoxProduct(DataTable datainvoice, DataTable detaildatainvoice)
        {
            InitializeComponent();
            this._datainvoice = datainvoice;
            this._detaildatainvoice = detaildatainvoice;
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
                    string invoicepart = "OBP";
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
                    string invoicepart = "OBP";
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
                string query = $"SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'OBP-{datePart}-%' ORDER BY InvoiceNo DESC";
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
        private async void OpenBoxProduct_Load(object sender, EventArgs e)
        {
            openboxproductidlbl.Text = await GenerateNextInvoiceNumber();
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox, "Kindly Select a warehouse.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if (descriptiontxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(descriptiontxtbox, "Add Description.");
                    descriptiontxtbox.Focus();
                    return;
                }

                string addopenboxproductdata = string.Empty;
                string invoiceno = openboxproductidlbl.Text;
                string description = descriptiontxtbox.Text;

                string tableName = "StockCustomizedTable";
                var columnData = new Dictionary<string, object>
                {
                    { "Code", Guid.NewGuid().ToString() },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                    { "InvoiceNo", invoiceno },
                    { "Description", description }
                };

                int stockcustomid = await DatabaseAccess.InsertDataIdAsync(tableName, columnData);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);

                if (stockcustomid > 0)
                {
                    string openboxproid = productidlbl.Text.ToString();
                    string openboxprodname = productnamelbl.Text;
                    string openmfr = productmfrlbl.Text;
                    string openboxprodupc = productupclbl.Text;
                    string openboxprodprice = productpricelbl.Text;
                    string openboxprodbarcode = productbarcodelbl.Text;
                    int openboxqty = Convert.ToInt32(openboxqtytxtbox.Text);

                    tableName = "StockTable";
                    var subtableData = new Dictionary<string, object>
                    {
                        { "ProductID", openboxproid },
                        { "ProductMfr", openmfr },
                        { "Quantity", openboxqty },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "WarehouseId", warehouseid },
                        { "StockCustom_ID", stockcustomid },
                        { "MinusInventory", true }
                    };

                    bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", subtableData);

                    if (result)
                    {
                        foreach (DataGridViewRow row in dgvproducts.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string productid = Convert.ToString(row.Cells[0].Value);
                                string mfr = row.Cells[1].Value.ToString();
                                string productname = Convert.ToString(row.Cells[2].Value);
                                string upc = Convert.ToString(row.Cells[3].Value);
                                string price = Convert.ToString(row.Cells[4].Value);
                                string barcode = Convert.ToString(row.Cells[5].Value);
                                int quantity = Convert.ToInt32(row.Cells[6].Value);

                                tableName = "StockTable";
                                var subsubtabledata = new Dictionary<string, object>
                                {
                                    { "ProductID", productid },
                                    { "ProductMfr", mfr },
                                    { "Quantity", quantity },
                                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                    { "WarehouseId", warehouseid },
                                    { "StockCustom_ID", stockcustomid },
                                    { "AddInventory", true }
                                };
                                bool result1 = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", subsubtabledata);

                                if (result1)
                                {
                                    int count = 0;
                                    int diff = Convert.ToInt32(quantity) - count;

                                    if (diff > 0)
                                    {
                                        int start = 0;
                                        while (start < diff)
                                        {
                                            string serialnumber = await GenerateRandomSerialNumber();

                                            string serialtable = "SerialNoTable";
                                            var serialtabledata = new Dictionary<string, object>
                                            {
                                                { "ProductId", productid },
                                                { "SerialNo", serialnumber },
                                                { "CreatedAt",DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() }
                                            };

                                            await DatabaseAccess.ExecuteQueryAsync(serialtable, "INSERT", serialtabledata);

                                            start++;
                                        }
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Saved Successfully!");
                        selectwarehousefromtxtbox.Text = string.Empty;
                        openboxproducttxtbox.Text = string.Empty;
                        openboxqtytxtbox.Text = string.Empty;
                        productbarcodelbl.Text = string.Empty;
                        productupclbl.Text = string.Empty;
                        productnamelbl.Text = string.Empty;
                        productidlbl.Text = string.Empty;
                        productpricelbl.Text = string.Empty;
                        productmfrlbl.Text = string.Empty;
                        selectwarehousefromtxtbox.Focus();
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox, "Kindly Select Warehouse");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if (qtytextbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytextbox, "Please Enter Quantity.");
                    qtytextbox.Focus();
                    return;
                }

                bool productExists = false;
                foreach (DataGridViewRow row in dgvproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["productid"].Value != null && row.Cells["productid"].Value.ToString() == openboxprodidlbl.Text.ToString())
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["productqty"].Value);
                            row.Cells["productqty"].Value = currentQuantity + Convert.ToInt32(qtytextbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvproducts.Rows.Add(openboxprodidlbl.Text, openboxprodmfrlbl.Text, openboxproductnamelbl.Text, openboxproductupclbl.Text, openboxproductpricelbl.Text,
                        openboxproductbarcodelbl.Text, qtytextbox.Text);
                }

                ResetLabelData();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetLabelData()
        {
            openboxprodidlbl.Text = string.Empty;
            openboxprodmfrlbl.Text = string.Empty;
            openboxproductnamelbl.Text = string.Empty;
            openboxproductupclbl.Text = string.Empty;
            openboxproductpricelbl.Text = string.Empty;
            openboxproductbarcodelbl.Text = string.Empty;
            remainingproductmfrtxtbox.Text = string.Empty;
            qtytextbox.Text = string.Empty;
            remainingproductmfrtxtbox.Focus();
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
        private void OpenBoxProduct_KeyDown(object sender, KeyEventArgs e)
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
                            warehouseSelection.MdiParent = this.MdiParent;

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
        private async void openboxproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(openboxproducttxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm
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
                        openboxproducttxtbox.Text = productname;
                        productupclbl.Text = productupc;
                        productbarcodelbl.Text = productbarcode;
                        productpricelbl.Text = productprice.ToString();
                        productmfrlbl.Text = productmfr;
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
        private async void remainingproductmfrtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
            if (openForm == null)
            {
                ProductSelectionForm productSelectionForm = new ProductSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterScreen,
                };

                productSelectionForm.ProductDataSelected += UpdateOpenBoxProductTextBox;
                CommonFunction.DisposeOnClose(productSelectionForm);
                productSelectionForm.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }

        }
        private async void UpdateOpenBoxProductTextBox(object sender, ProductData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int productid = e.ProductId;
                    string productName = e.ProductName;
                    string productmfr = e.ProductMfr;
                    string productupc = e.ProductUPC;
                    float productprice = e.ProductPrice;
                    string productbarcode = e.ProductBarcode;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        openboxprodidlbl.Text = productid.ToString();
                        openboxproductnamelbl.Text = productName;
                        remainingproductmfrtxtbox.Text = productName;
                        openboxprodmfrlbl.Text = productmfr;
                        openboxproductupclbl.Text = productupc;
                        openboxproductpricelbl.Text = productprice.ToString();
                        openboxproductbarcodelbl.Text = productbarcode;
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
            if (openboxproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (remainingproductmfrtxtbox.Text.Trim().Length > 0) { return true; }
            if (qtytextbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
