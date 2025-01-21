using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class OpenBoxProduct : Form
    {
        private int invoiceCounter = 1;
        public OpenBoxProduct()
        {
            InitializeComponent();
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
                if(selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Kindly Select a warehouse.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(descriptiontxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(descriptiontxtbox,"Add Description.");
                    descriptiontxtbox.Focus();
                    return;
                }

                string addopenboxproductdata = string.Empty;
                string invoiceno = openboxproductidlbl.Text;
                string description = descriptiontxtbox.Text;

                addopenboxproductdata = string.Format("INSERT INTO StockCustomizedTable (Code,CreatedAt,CreatedDay,InvoiceNo,Description) VALUES ('" + Guid.NewGuid() + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoiceno + "','" + description + "'); " +
                    "SELECT SCOPE_IDENTITY();");

                int stockcustomid = 1;
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);

                if (stockcustomid > 0)
                {
                    string openboxproid = openboxprodidlbl.Text.ToString();
                    string openboxprodname = openboxproductnamelbl.Text;
                    string openboxprodupc = openboxproductupclbl.Text;
                    string openboxprodprice = openboxproductpricelbl.Text;
                    string openboxprodbarcode = openboxproductbarcodelbl.Text;

                    string insertopenboxproducts = string.Format("INSERT INTO StockTable (ProductID,Quantity,CreatedAt,CreatedDay,WarehouseId," +
                        "StockCustom_ID,MinusOpenBoxQuantity) VALUES ('" + openboxproid + "','" + -1 + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                        "'" + DateTime.Now.DayOfWeek + "','" + warehouseid + "','" + stockcustomid + "','" + -1 + "')");

                    bool result = false;

                    if (result)
                    {
                        foreach (DataGridViewRow row in dgvproducts.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string productid = Convert.ToString(row.Cells[0].Value);
                                string productname = Convert.ToString(row.Cells[1].Value);
                                string upc = Convert.ToString(row.Cells[2].Value);
                                string price = Convert.ToString(row.Cells[3].Value);
                                string barcode = Convert.ToString(row.Cells[4].Value);
                                int quantity = Convert.ToInt32(row.Cells[5].Value);

                                string insertproducts = string.Format("INSERT INTO StockTable (ProductID,Quantity,CreatedAt,CreatedDay,WarehouseId," +
                                "StockCustom_ID,AddOpenBoxQuantity) VALUES ('" + productid + "','" + quantity + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "','" + warehouseid + "','" + stockcustomid + "','" + quantity + "')");

                                bool result1 = false;

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
                                            string query1 = string.Format("INSERT INTO SerialNoTable (ProductId,SerialNo,CreatedAt,CreatedDay) " +
                                        "VALUES ('" + productid + "','" + serialnumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                        "'" + System.DateTime.Now.DayOfWeek + "')");

                                            start++;
                                        }
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Saved Successfully!");
                    }
                }

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                if(selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Kindly Select Warehouse");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(qtytextbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytextbox,"Please Enter Quantity.");
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
                    dgvproducts.Rows.Add(openboxprodidlbl.Text, openboxproductnamelbl.Text, openboxproductupclbl.Text, openboxproductpricelbl.Text, 
                        openboxproductbarcodelbl.Text, qtytextbox.Text);
                }

                remainingproductmfrtxtbox.Text = string.Empty;
                qtytextbox.Text = string.Empty;
                remainingproductmfrtxtbox.Focus();

            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                            warehouseSelection.MdiParent = this.MdiParent;

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
                        /* supplieridlbl.Text = supplierId.ToString();
                         selectsuppliertxtbox.Text = supplierName;
                         suppliercodetxtbox.Text = supplierCode;
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
        private async void remainingproductmfrtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(remainingboxproductlbl.Text))
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

                    await CommonFunction.DisposeOnCloseAsync(productSelectionForm);
                    productSelectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
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

        /*private bool InsertOpenBoxProducts()
        {
            string tableName = "";
            var columnData = new Dictionary<string, object>
            {
                { "Code", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString() },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceNo", openboxproductidlbl.Text },
                { "Description", descriptiontxtbox.Text }
            };

            int result = DatabaseAccess.InsertDataId(tableName, columnData);

            if (result == 0) 
            {
                string subtable = "";

                var subcolumnData = new Dictionary<string, object>
                {
                    { "ProductID", },
                    { "Quantity", },
                    { "CreatedAt", },
                    { "CreatedDay", },
                    { "WarehouseId", },
                    { "StockCustom_ID", },
                    { "MinusOpenBoxQuantity", }
                };
            }
        }*/
    }
}
