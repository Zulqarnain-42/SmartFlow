using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Masters;
using SmartFlow.Sales;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class PurchaseInvoice : Form
    {
        private int invoiceCounter = 1;
        private decimal vatAmount = 0;
        public PurchaseInvoice()
        {
            InitializeComponent();
            
        }

        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            invoicenotxtbox.Text = GenerateNextInvoiceNumber();
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
                    string invoicepart = "PI";
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
                    string invoicepart = "PI";
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PI-%' ORDER BY InvoiceNo DESC";
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

        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return GenerateNextInvoiceNumber();
                }
                else
                {
                    return invoicenotxtbox.Text;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void purchaseordernotxtbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.MdiParent = this;
            purchaseInvoice.Show();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string invoicecode = Guid.NewGuid().ToString();
                string addpurchaseinvoice = string.Format("");

                bool insertinvoice = DatabaseAccess.Insert(addpurchaseinvoice);
                if (insertinvoice)
                {
                    foreach(DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        string addproductdetails = string.Format("");
                        bool insertprod = DatabaseAccess.Insert(addproductdetails);
                    }
                }
                else
                {
                    MessageBox.Show("");
                }
            }catch (Exception ex) { throw ex; }
        }

        private void PurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        private void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
            if (openForm == null) 
            {
                SupplierSelectionForm selectionForm = new SupplierSelectionForm();
                selectionForm.ShowDialog();
                UpdateSupplierTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void UpdateProductTextBox()
        {
            selectproducttxtbox.Text = GlobalVariables.productnameglobal;
            mfrtxtbox.Text = GlobalVariables.productmfrglobal;
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
        }

        private void UpdateSupplierTextBox()
        {
            selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
            codetxtbox.Text = GlobalVariables.suppliercodeglobal;
        }

        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
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

        private void PurchaseInvoice_FormClosing(object sender, FormClosingEventArgs e)
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
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
            if (invoicerefrencetxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }

        private void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm supplierSelection = new SupplierSelectionForm();
                    supplierSelection.ShowDialog();
                    UpdateSupplierTextBox();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm();
                    productSelection.ShowDialog();
                    UpdateProductTextBox();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalVat(6);
            CalculateTotalColumn(8);
        }

        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalVat(6);
            CalculateTotalColumn(8);
        }

        private void CalculateTotalColumn(int columnIndex)
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.Cells[columnIndex].Value != null)
                {
                    if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                    {
                        total += value;
                    }
                }
            }

            nettotaltxtbox.Text = total.ToString("#,##0.## AED");
        }

        private void CalculateTotalVat(int columnIndex)
        {
            decimal totalvat = 0;

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.Cells[columnIndex].Value != null)
                {
                    if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                    {
                        totalvat += value;
                    }
                }
            }

            totalvattxtbox.Text = totalvat.ToString("#,##0.## AED");
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void costpricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void lowestpricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void standardpricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void salepricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void selectpurchasetype_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SaleTypeSelection));
            if (openForm == null)
            {
                SaleTypeSelection saleTypeSelection = new SaleTypeSelection();
                saleTypeSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void selectpurchasetype_KeyDown(object sender, KeyEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SaleTypeSelection));
            if (openForm == null)
            {
                SaleTypeSelection saleTypeSelection = new SaleTypeSelection();
                saleTypeSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void checkbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string purchaseorder = purchaseordernotxtbox.Text;
                string getpurchaseorder = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.SupplierId,InvoiceTable.Narration," +
                    "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                    "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.CustomerId,InvoiceTable.NetPayable,InvoiceTable.SupplierName,InvoiceTable.TotalVat," +
                    "InvoiceDetailsTable.AmountWithoutDiscount,InvoiceDetailsTable.Discount,InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.MFR," +
                    "InvoiceDetailsTable.Price,InvoiceDetailsTable.Productid,InvoiceDetailsTable.ProductName,InvoiceDetailsTable.Quantity,InvoiceDetailsTable.SerialNo," +
                    "InvoiceDetailsTable.Total FROM InvoiceTable INNER JOIN InvoiceDetailsTable on InvoiceDetailsTable.Invoicecode = InvoiceTable.InvoiceCode " +
                    "WHERE InvoiceTable.InvoiceNo = '" + purchaseorder + "'");
                
                DataTable getpurchaseorderdata = DatabaseAccess.Retrive(getpurchaseorder);

                if (getpurchaseorderdata != null)
                {
                    if (getpurchaseorderdata.Rows.Count > 0)
                    {
                        invoicenotxtbox.Text = "";
                        invoicedatetxtbox.Text = "";
                        codetxtbox.Text = "";
                        selectsuppliertxtbox.Text = "";


                    }
                    else
                    {
                        MessageBox.Show("No Purchase Order Data Available");
                    }
                }
                else
                {
                    MessageBox.Show("No Purchase Order Data Available");
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void salepricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string mfr = mfrtxtbox.Text;
                string productid = productidlbl.Text;
                string productname = selectproducttxtbox.Text;
                string qty = qtytxtbox.Text;
                string costprice = maskedTextBox1.Text;
                string lowestprice = maskedTextBox2.Text;
                string standardprice = maskedTextBox3.Text;
                string saleprice = pricetxtbox.Text;

                int quantity = Convert.ToInt32(qty);

                if (quantity > 0)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                            warehouseSelection.ShowDialog();
                        }
                    }

                    warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
                }

                bool productExists = false;
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["productid"].Value != null && row.Cells["productid"].Value.ToString() == productidlbl.Text.ToString())
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                            row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvpurchaseproducts.Rows.Add(mfr, productid, productname, qty, costprice, lowestprice, standardprice, saleprice, vatAmount);
                }

                mfrtxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                maskedTextBox1.Text = string.Empty;
                maskedTextBox2.Text = string.Empty;
                maskedTextBox3.Text = string.Empty;
                pricetxtbox.Text = string.Empty;
                selectproducttxtbox.Focus();
            }
            catch (Exception ex) { throw ex; }
        }

        private void selectsuppliertxtbox_Leave(object sender, EventArgs e)
        {

        }

        private void selectproducttxtbox_Leave(object sender, EventArgs e)
        {

        }
    }
}
