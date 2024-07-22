using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class StockTransfer : Form
    {
        private int invoiceCounter = 1;
        public StockTransfer()
        {
            InitializeComponent();
        }
        private void StockTransfer_Load(object sender, EventArgs e)
        {
            stocktransferidlbl.Text = GenerateNextInvoiceNumber();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Please Select Warehouse From you want to transfer the item.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(selectwarehousetotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Please Select Warehouse you want to transfer.");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(selectwarehousefromtxtbox.Text == selectwarehousetotxtbox.Text)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Select Different Warehouse for Transfer.");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(mfrtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(mfrtxtbox,"Please Select a Product.");
                    mfrtxtbox.Focus();
                    return;
                }

                if(qtytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytxtbox,"Please Enter Quantity.");
                    qtytxtbox.Focus();
                    return;
                }

                bool productExists = false;
                foreach(DataGridViewRow row in dgvproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value!=null && row.Cells["ProductID"].Value.ToString()== productidlbl.Text.ToString())
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["productquantity"].Value);
                            row.Cells["productquantity"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvproducts.Rows.Add(productidlbl.Text,mfrtxtbox.Text, productnamelbl.Text, productupclbl.Text, productpricelbl.Text, 
                        productbarcodelbl.Text, qtytxtbox.Text);
                }

                mfrtxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                productnamelbl.Text = string.Empty;
                productupclbl.Text = string.Empty;
                productbarcodelbl.Text = string.Empty;
                productpricelbl.Text = string.Empty;
                mfrtxtbox.Focus();

            }catch(Exception ex) { throw ex; }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Please Select Warehouse from.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(selectwarehousetotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Please Select Warehouse to.");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(selectwarehousefromtxtbox.Text == selectwarehousetotxtbox.Text)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Select Different Warehouse");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(string.IsNullOrEmpty(descriptiontxtbox.Text) && string.IsNullOrWhiteSpace(descriptiontxtbox.Text))
                {
                    errorProvider.SetError(descriptiontxtbox,"Please Enter Description.");
                    descriptiontxtbox.Focus();
                    return;
                }

                string addtransferdata = string.Empty;
                string invoiceno = stocktransferidlbl.Text;

                addtransferdata = string.Format("INSERT INTO StockCustomizedTable (Code,CreatedAt,CreatedDay,InvoiceNo,Description) VALUES ('" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoiceno + "','" + descriptiontxtbox.Text + "'); " +
                                "SELECT SCOPE_IDENTITY();");
                int stockcustomid = DatabaseAccess.InsertId(addtransferdata);
                int warehouseid = Convert.ToInt32(warehousetoidlbl.Text);
                int warehousefromid = Convert.ToInt32(warehousefromidlbl.Text);

                foreach (DataGridViewRow row in dgvproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string productid = Convert.ToString(row.Cells[0].Value);
                        string productname = Convert.ToString(row.Cells[1].Value);
                        string upc = Convert.ToString(row.Cells[2].Value);
                        string price = Convert.ToString(row.Cells[3].Value);
                        string barcode = Convert.ToString(row.Cells[4].Value);
                        int quantity = Convert.ToInt32(row.Cells[6].Value.ToString());
                        
                        if (stockcustomid > 0)
                        {
                            
                            string insertstock = string.Format("INSERT INTO StockTable (Product_ID,CreatedAt,CreatedDay,WarehouseId,TransferFromWarehouseID," +
                                "TransferToWarehouseID,TransformQty,TransToQty,RefrenceLink,StockCustom_ID,Quantity) VALUES ('" + productid + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "','" + warehouseid + "','" + warehousefromid + "','" + warehouseid + "'," +
                                "'" + quantity + "','" + quantity + "','" + descriptiontxtbox.Text + "','" + stockcustomid + "','" + quantity + "')");

                            bool result = DatabaseAccess.Insert(insertstock);

                        }
                        savebtn.Enabled = false;
                        

                    }
                    
                }
                MessageBox.Show("Saved Successfully!");
            }
            catch(Exception ex) { throw ex; }
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
                    string invoicepart = "ST";
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
                    string invoicepart = "ST";
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
                string query = "SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'ST-%' ORDER BY InvoiceNo DESC";
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
        private void StockTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void mfrtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
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
            }catch(Exception ex) { throw ex; }
        }
        private void UpdateProductTextBox()
        {
            mfrtxtbox.Text = GlobalVariables.productmfrglobal;
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
            productnamelbl.Text = GlobalVariables.productnameglobal.ToString();
            productupclbl.Text = GlobalVariables.productupcglobal.ToString();
            productbarcodelbl.Text = GlobalVariables.productbarcodeglobal.ToString();
            productpricelbl.Text =  GlobalVariables.productpriceglobal.ToString();
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
                        UpdateWarehouseFromTextBox();
                    }
                }

            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateWarehouseFromTextBox()
        {
            selectwarehousefromtxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
            warehousefromidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
        }
        private void selectwarehousetotxtbox_MouseClick(object sender, MouseEventArgs e)
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
                        UpdateWarehouseToTextBox();
                    }
                }

            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateWarehouseToTextBox() 
        {
            selectwarehousetotxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
            warehousetoidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
        }
        private void StockTransfer_FormClosing(object sender, FormClosingEventArgs e)
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
        private void selectwarehousetotxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                            UpdateWarehouseToTextBox();
                        }
                    }

                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void mfrtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
        }
        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            if(qtytxtbox.Text.Trim().Length > 0 && mfrtxtbox.Text.Trim().Length > 0)
            {
                string query = string.Format("SELECT StockTable.Product_ID,StockTable.WarehouseId," +
                    "StockTable.TransferToWarehouseID,StockTable.TransToQty,StockTable.DamageQty,StockTable.AddOpenBoxQuantity," +
                    "StockTable.MinusOpenBoxQuantity FROM StockCustomizedTable INNER JOIN StockTable ON StockTable.StockCustom_ID = StockCustomizedTable.CustomStockID " +
                    "WHERE Product_ID = '" + productidlbl.Text + "'");

                DataTable productstockdata = DatabaseAccess.Retrive(query);

                if (productstockdata.Rows.Count > 0)
                {

                }

                string queryproduct = string.Format("SELECT ProductID,ProductName,MFR,Barcode,SecondMFr,Quantity,WarehouseID " +
                    "FROM ProductTable WHERE ProductID = '" + productidlbl.Text + "'");

                DataTable productdata = DatabaseAccess.Retrive(queryproduct);

                if(productdata.Rows.Count == 1)
                {
                    DataRow row = productdata.Rows[0];
                    int openingwarehouseid = Convert.ToInt32(row["WarehouseID"].ToString());
                    int openingquantity = Convert.ToInt32(row["Quantity"].ToString());
                }

                string invoicequery = string.Format("SELECT InvoiceTable.InvoiceNo,InvoiceDetailsTable.Productid,InvoiceDetailsTable.Quantity," +
                    "InvoiceDetailsTable.Warehouseid FROM InvoiceTable INNER JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Invoicecode = InvoiceTable.InvoiceCode " +
                    "WHERE Productid = '" + productidlbl.Text + "'");

                DataTable invoiceData = DatabaseAccess.Retrive(invoicequery);

                if (invoiceData.Rows.Count > 0)
                {

                }
            } 
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
