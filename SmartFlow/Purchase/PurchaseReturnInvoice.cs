using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class PurchaseReturnInvoice : Form
    {
        private int invoiceCounter = 1;
        public PurchaseReturnInvoice()
        {
            InitializeComponent();
        }

        private void PurchaseReturnInvoice_Load(object sender, EventArgs e)
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
                    string invoicepart = "PR";
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
                    string invoicepart = "PR";
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PR-%' ORDER BY InvoiceNo DESC";
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

        private void PurchaseReturnInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells[0].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvpurchaseproducts.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }

        private void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
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

        private void UpdateSupplierTextBox()
        {
            selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
            suppliercodetxtbox.Text = GlobalVariables.suppliercodeglobal;
        }

        private void PurchaseReturnInvoice_FormClosing(object sender, FormClosingEventArgs e)
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
            if (narationtxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
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

        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if(openForm == null)
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

        private void UpdateProductTextBox()
        {
            selectproducttxtbox.Text = GlobalVariables.productnameglobal;
            mfrtxtbox.Text = GlobalVariables.productmfrglobal;
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
        }

        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
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


        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalColumn(5);
        }

        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalColumn(5);
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

        private void addrowbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string mfr = mfrtxtbox.Text;
                string productname = selectproducttxtbox.Text;
                string productid = productidlbl.Text;
                string qty = qtytxtbox.Text;
                string price = pricetxtbox.Text;

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
                    dgvpurchaseproducts.Rows.Add(mfr,productid,productname,qty,price);
                }

                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                pricetxtbox.Text = string.Empty;
            }
            catch(Exception ex) { throw ex; }
        }

        private void checkpurchasebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string purchaseorder = purchasenotxtbox.Text;
                string getpurchaseorder = "";
                DataTable getpurchaseorderdata = DatabaseAccess.Retrive(getpurchaseorder);
                
                if (getpurchaseorderdata != null)
                {
                    if (getpurchaseorderdata.Rows.Count > 0)
                    {
                        invoicedatetxtbox.Text = getpurchaseorderdata.Rows[0][""].ToString();
                        selectsuppliertxtbox.Text = getpurchaseorderdata.Rows[0][""].ToString();
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
            catch(Exception ex) { throw ex; }
        }

        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string mfr = mfrtxtbox.Text;
                string productname = selectproducttxtbox.Text;
                string productid = productidlbl.Text;
                string qty = qtytxtbox.Text;
                string price = pricetxtbox.Text;

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
                    dgvpurchaseproducts.Rows.Add(mfr, productid, productname, qty, price);
                }

                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                pricetxtbox.Text = string.Empty;
            }
            catch (Exception ex) { throw ex; }
        }

        private void selectsuppliertxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
            if (openForm == null)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void selectproducttxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductQtyWarehouse));
            if (openForm == null)
            {
                ProductQtyWarehouse productQtyWarehouse = new ProductQtyWarehouse();
                productQtyWarehouse.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }
    }
}
