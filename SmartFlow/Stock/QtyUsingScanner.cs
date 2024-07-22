using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class QtyUsingScanner : Form
    {
        private int invoiceCounter = 1;
        public QtyUsingScanner()
        {
            InitializeComponent();
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
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
                string invoiceno = qtyusingscanneridlbl.Text;

                query = string.Format("INSERT INTO StockCustomizedTable (Code,CreatedAt,CreatedDay,InvoiceNo,Description) VALUES ('" + Guid.NewGuid() + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoiceno + "','" + importantnotestxtbox.Text + "'); " +
                    "SELECT SCOPE_IDENTITY();");
                int stockcustomid = DatabaseAccess.InsertId(query);
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
                            string price = Convert.ToString(row.Cells[2].Value);
                            string upc = Convert.ToString(row.Cells[3].Value);
                            string mfr = Convert.ToString(row.Cells[4].Value);
                            string barcode = Convert.ToString(row.Cells[5].Value);
                            int quantity = Convert.ToInt32(row.Cells[6].Value);

                            if (quantity > 0)
                            {
                                query = string.Format("INSERT INTO StockTable (Product_ID,Quantity,CreatedAt,CreatedDay,WarehouseId) VALUES " +
                                    "('" + productid + "','" + quantity + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + System.DateTime.Now.DayOfWeek + "'," +
                                    "'" + warehouseid + "')");
                                result = DatabaseAccess.Insert(query);
                                if (result)
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
                    }
                    MessageBox.Show("Inventory Updated");
                }
            }
            catch(Exception ex) { throw ex; }
        }
        private void QtyUsingScanner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void searchDatabase(string barcode)
        {
            string query = "SELECT ProductID,ProductName,StandardPrice,UPC,EAN,MFR,Barcode " +
                "FROM ProductTable WHERE Barcode LIKE '" + barcode + "'";

            DataTable dataTable = DatabaseAccess.Retrive(query);
            string productid = null, mfr = null, title = null, upc = null, price = null, systembarcode = null;
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
                        price = row["StandardPrice"].ToString();
                        upc = row["UPC"].ToString();
                        mfr = row["MFR"].ToString();
                        systembarcode = row["Barcode"].ToString();
                        quantity = 1;
                    }

                    dgvinventory.Rows.Add(productid, title, price, upc, mfr, systembarcode,quantity);
                }  
            }
            else
            {
                MessageBox.Show("UPC Not Available");
            }
        }
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            if(searchtextbox.Text.Length >= 8)
            {
                string searchvalue = searchtextbox.Text;
                searchtextbox.Clear();
                searchDatabase(searchvalue);
            }
            
        }
        private void QtyUsingScanner_Load(object sender, EventArgs e)
        {
            qtyusingscanneridlbl.Text = GenerateNextInvoiceNumber();
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
        private string GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
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
            catch (Exception ex) { throw ex; }
        }
        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'QUS-%' ORDER BY InvoiceNo DESC";
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
        private void QtyUsingScanner_FormClosing(object sender, FormClosingEventArgs e)
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
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (searchtextbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
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
                        UpdateWarehouseTxtBox();
                    }
                }
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateWarehouseTxtBox()
        {
            selectwarehousetxtbox.Text = GlobalVariables.warehousenameglobal;
            warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
        }
    }
}
