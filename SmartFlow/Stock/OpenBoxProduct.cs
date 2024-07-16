using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Text;
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

        private string GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
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
            catch (Exception ex) { throw ex; }
        }

        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'OBP-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = DatabaseAccess.Retrive(query);
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

        private void OpenBoxProduct_Load(object sender, EventArgs e)
        {
            openboxproductidlbl.Text = GenerateNextInvoiceNumber();
        }

        private void savebtn_Click(object sender, EventArgs e)
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

                addopenboxproductdata = string.Format("INSERT INTO StockCustomizedTable (Code,CreatedAt,CreatedDay,InvoiceNo,Description) VALUES ('" + Guid.NewGuid() + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoiceno + "','" + descriptiontxtbox.Text + "'); " +
                    "SELECT SCOPE_IDENTITY();");

                int stockcustomid = DatabaseAccess.InsertId(addopenboxproductdata);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);

                if (stockcustomid > 0)
                {
                    string openboxproid = openboxprodidlbl.Text.ToString();
                    string openboxprodname = openboxproductnamelbl.Text;
                    string openboxprodupc = openboxproductupclbl.Text;
                    string openboxprodprice = openboxproductpricelbl.Text;
                    string openboxprodbarcode = openboxproductbarcodelbl.Text;

                    string insertopenboxproducts = string.Format("INSERT INTO StockTable (Product_ID,Quantity,CreatedAt,CreatedDay,WarehouseId," +
                        "StockCustom_ID,MinusOpenBoxQuantity) VALUES ('" + openboxproid + "','" + -1 + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                        "'" + DateTime.Now.DayOfWeek + "','" + warehouseid + "','" + stockcustomid + "','" + -1 + "')");

                    bool result = DatabaseAccess.Insert(insertopenboxproducts);

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

                                string insertproducts = string.Format("INSERT INTO StockTable (Product_ID,Quantity,CreatedAt,CreatedDay,WarehouseId," +
                                "StockCustom_ID,AddOpenBoxQuantity) VALUES ('" + productid + "','" + quantity + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "','" + warehouseid + "','" + stockcustomid + "','" + quantity + "')");

                                bool result1 = DatabaseAccess.Insert(insertproducts);

                                if (result1) 
                                {
                                    int count = 0;
                                    int diff = Convert.ToInt32(quantity) - count;

                                    if (diff > 0)
                                    {
                                        int start = 0;
                                        while (start < diff)
                                        {
                                            string serialnumber = GenerateRandomSerialNumber();
                                            string query1 = string.Format("INSERT INTO SerialNoTable (ProductId,SerialNo,CreatedAt,CreatedDay) " +
                                        "VALUES ('" + productid + "','" + serialnumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                        "'" + System.DateTime.Now.DayOfWeek + "')");
                                            DatabaseAccess.Insert(query1);
                                            start++;
                                        }
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Saved Successfully!");
                    }
                }

            }catch (Exception ex) { throw ex; }
        }

        static string GenerateRandomSerialNumber()
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
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = GenerateRandomSerialNumber();
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

            }catch(Exception ex) { throw ex; }
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
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        private void selectwarehousefromtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
            if (openForm == null) 
            {
                string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                if (warehousedata != null)
                {
                    if (warehousedata.Rows.Count > 0)
                    {
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                        warehouseSelection.ShowDialog();
                        UpdateWarehouseTextBox();
                    }
                }
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void UpdateWarehouseTextBox()
        {
            selectwarehousefromtxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
            warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
        }

        private void openboxproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if (openForm == null) 
            {
                ProductSelectionForm productSelectionForm = new ProductSelectionForm();
                productSelectionForm.ShowDialog();
                UpdateProductTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void UpdateProductTextBox()
        {
            openboxproducttxtbox.Text = GlobalVariables.productnameglobal.ToString();
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
            productpricelbl.Text = GlobalVariables.productpriceglobal.ToString();
            productnamelbl.Text = GlobalVariables.productnameglobal.ToString();
            productupclbl.Text = GlobalVariables.productupcglobal.ToString();
            productbarcodelbl.Text = GlobalVariables.productbarcodeglobal.ToString();
        }

        private void remainingproductmfrtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if (openForm == null)
            {
                ProductSelectionForm productSelectionForm = new ProductSelectionForm();
                productSelectionForm.ShowDialog();
                UpdateOpenBoxProductTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void UpdateOpenBoxProductTextBox()
        {
            remainingproductmfrtxtbox.Text = GlobalVariables.productnameglobal.ToString();
            openboxprodidlbl.Text = GlobalVariables.productidglobal.ToString();
            openboxproductpricelbl.Text = GlobalVariables.productpriceglobal.ToString();
            openboxproductnamelbl.Text = GlobalVariables.productnameglobal.ToString();
            openboxproductupclbl.Text = GlobalVariables.productupcglobal.ToString();
            openboxproductbarcodelbl.Text = GlobalVariables.productbarcodeglobal.ToString();
        }

        private void OpenBoxProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AreAnyTextBoxesFilled())
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                      "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                }
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true; // At least one TextBox is filled
                }
            }
            return false; // No TextBox is filled
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
