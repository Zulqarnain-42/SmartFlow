using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class DamageEntry : Form
    {
        private int invoiceCounter = 1;
        public DamageEntry()
        {
            InitializeComponent();
        }

        private void DamageEntry_Load(object sender, EventArgs e)
        {
            damageidlbl.Text = GenerateNextInvoiceNumber();
        }

        private void savebtn_Click(object sender, EventArgs e)
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

                string query = string.Empty;
                string invoiceno = damageidlbl.Text;

                query = string.Format("INSERT INTO StockCustomizedTable (Code,CreatedAt,CreatedDay,InvoiceNo,Description) VALUES ('" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoiceno + "','"+descriptiontxtbox.Text+"');" +
                        " SELECT SCOPE_IDENTITY();");

                int stockcustomid = DatabaseAccess.InsertId(query);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);

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
                        int negativeQuantity = -Math.Abs(quantity);

                        if (stockcustomid > 0)
                        {
                            string insertstock = string.Format("INSERT INTO StockTable (Product_ID,CreatedAt,CreatedDay,WarehouseId,DamageQty,StockCustom_ID,Quantity) " +
                                "VALUES ('" + productid + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + warehouseid + "'," +
                                "'" + negativeQuantity + "','" + stockcustomid + "','" + negativeQuantity + "')");
                            bool result = DatabaseAccess.Insert(insertstock);
                        }

                        
                    }
                }
                MessageBox.Show("Saved Successfully!");
                savebtn.Enabled = false;
            }
            catch (Exception ex) { throw ex; }
        }

        private void DamageEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
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
                    dgvproducts.Rows.Add(productidlbl.Text, productnamelbl.Text, upclbl.Text, productpricelbl.Text, barcodelbl.Text, qtytxtbox.Text);
                }
                
                productmfrtxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                productmfrtxtbox.Focus();
            }
            catch (Exception ex) { throw ex; }
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
            catch (Exception ex) { throw ex; }
        }

        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'DE-%' ORDER BY InvoiceNo DESC";
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

        private void selectwarehousefromtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
            if(openForm == null)
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

        private void producttxtbox_MouseClick(object sender, MouseEventArgs e)
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
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
            productnamelbl.Text = GlobalVariables.productnameglobal.ToString();
            productmfrtxtbox.Text = GlobalVariables.productmfrglobal.ToString();
            upclbl.Text = GlobalVariables.productupcglobal.ToString();
            barcodelbl.Text = GlobalVariables.productbarcodeglobal.ToString();
            productpricelbl.Text = GlobalVariables.productpriceglobal.ToString();
        }

        private void UpdateWarehouseTextBox() 
        {
            warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
            selectwarehousefromtxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
        }

        private void DamageEntry_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
