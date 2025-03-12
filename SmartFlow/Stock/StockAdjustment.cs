using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class StockAdjustment: Form
    {
        private int invoiceCounter = 1;
        public StockAdjustment()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        selecteditemidlbl.Text = productid.ToString();
                        selecteditemnamelbl.Text = productname.ToString();
                        openboxproducttxtbox.Text = productname.ToString();
                        selectedproductmfrlbl.Text = productmfr;
                        selecteditemupclbl.Text = productupc.ToString();
                        selecteditembarcodelbl.Text = productbarcode.ToString();
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

        private async void addedproductmfrtxtbox_MouseClick(object sender, MouseEventArgs e)
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
                        minusitemidlbl.Text = productid.ToString();
                        minusitemnamelbl.Text = productName;
                        addedproductmfrtxtbox.Text = productName;
                        minusitemproductmfrlbl.Text = productmfr;
                        minusitemupclbl.Text = productupc;
                        minusitembarcodelbl.Text = productbarcode;
                        minusitempricelbl.Text = productprice.ToString();
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
                        if (row.Cells["productid"].Value != null && row.Cells["productid"].Value.ToString() == minusitemidlbl.Text.ToString())
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
                    dgvproducts.Rows.Add(minusitemidlbl.Text, minusitemproductmfrlbl.Text, minusitemnamelbl.Text, minusitemupclbl.Text, minusitempricelbl.Text,
                        minusitembarcodelbl.Text, qtytextbox.Text);
                }


                ResetLabelData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetLabelData()
        {
            addedproductmfrtxtbox.Text = string.Empty;
            qtytextbox.Text = string.Empty;
            minusitemidlbl.Text = string.Empty;
            minusitemproductmfrlbl.Text = string.Empty;
            minusitemnamelbl.Text = string.Empty;
            minusitemupclbl.Text = string.Empty;
            minusitempricelbl.Text = string.Empty;
            minusitembarcodelbl.Text = string.Empty;
            addedproductmfrtxtbox.Focus();
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
                string invoiceno = invoicenolbl.Text;
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
                    string openboxproid = selecteditemidlbl.Text.ToString();
                    string openboxprodname = selecteditemnamelbl.Text;
                    string openboxprodmfr = selectedproductmfrlbl.Text;
                    string openboxprodupc = selecteditemupclbl.Text;
                    string openboxprodprice = selecteditempricelbl.Text;
                    string openboxprodbarcode = selecteditembarcodelbl.Text;
                    int openboxqty = Convert.ToInt32(selectitemqtytxtbox.Text);

                    tableName = "StockTable";
                    Dictionary<string, object> subtableData;
                    if (addchkbox.Checked == true)
                    {
                        subtableData = new Dictionary<string, object>
                        {
                            { "ProductID", openboxproid },
                            { "ProductMfr", openboxprodmfr },
                            { "Quantity", openboxqty },
                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "WarehouseId", warehouseid },
                            { "StockCustom_ID", stockcustomid },
                            { "AddInventory", true }
                        };
                    }
                    else
                    {
                        subtableData = new Dictionary<string, object>
                        {
                            { "ProductID", openboxproid },
                            { "ProductMfr", openboxprodmfr },
                            { "Quantity", openboxqty },
                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "WarehouseId", warehouseid },
                            { "StockCustom_ID", stockcustomid }
                        };
                    }

                    bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", subtableData);

                    if (result)
                    {
                        foreach (DataGridViewRow row in dgvproducts.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string productid = Convert.ToString(row.Cells[0].Value);
                                string mfr = Convert.ToString(row.Cells[1].Value);
                                string productname = row.Cells[2].Value.ToString();
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
                                    { "MinusInventory", true }
                                };
                                await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", subsubtabledata);
                            }
                        }

                        MessageBox.Show("Saved Successfully!");
                        dgvproducts.Rows.Clear();
                        descriptiontxtbox.Clear();
                        selectwarehousefromtxtbox.Clear();
                        openboxproducttxtbox.Clear();
                        selectitemqtytxtbox.Clear();
                        addchkbox.Checked = false;
                        selectedproductmfrlbl.Text = string.Empty;
                        selecteditempricelbl.Text = string.Empty;
                        selecteditemidlbl.Text = string.Empty;
                        selecteditemnamelbl.Text = string.Empty;
                        selecteditemupclbl.Text = string.Empty;
                        selecteditembarcodelbl.Text = string.Empty;
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void StockAdjustment_Load(object sender, EventArgs e)
        {
            invoicenolbl.Text = await GenerateNextInvoiceNumber();
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
                    string invoicepart = "STA";
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
                    string invoicepart = "STA";
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
                string query = $"SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'STA-{datePart}-%' ORDER BY InvoiceNo DESC";
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
    }
}
