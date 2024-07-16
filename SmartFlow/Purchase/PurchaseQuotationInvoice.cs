using CrystalDecisions.CrystalReports.Engine;
using DocumentFormat.OpenXml.Spreadsheet;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class PurchaseQuotationInvoice : Form
    {
        private int invoiceCounter = 1;
        public PurchaseQuotationInvoice()
        {
            InitializeComponent();
        }

        private void PurchaseQuotationInvoice_Load(object sender, EventArgs e)
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
                    string invoicepart = "PQ";
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
                    string invoicepart = "PQ";
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

        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber,lastInvoiceNumber)<=0) 
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

        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PQ-%' ORDER BY InvoiceNo DESC";
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

        private void newbtn_Click(object sender, EventArgs e)
        {
            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();
            purchaseQuotationInvoice.Show();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice no");
                    invoicenotxtbox.Focus();
                    return;
                }

                if(codetxtbox.Text.Trim().Length == 0 && selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox,"Please Select a Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                string invoiceno = CheckInvoiceBeforeInsert();
                float.TryParse(nettotaltxtbox.Text.Replace("AED", "").Replace(",", "").Trim(), out float totalpayable);
                string invoicecode = Guid.NewGuid().ToString();
                string addpurchasequote = string.Format("INSERT INTO InvoiceTable (InvoiceNo,InvoiceDate,SupplierId,SupplierName,Narration,CreatedAt,CreatedDay,InvoiceCode,NetPayable) VALUES " +
                    "('" + invoiceno + "','" + invoicedatetxtbox.Text + "','" + supplieridlbl.Text + "','" + selectsuppliertxtbox.Text + "'," +
                    "'" + narationtxtbox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoicecode + "','" + totalpayable + "')");
                
                bool insertquote = DatabaseAccess.Insert(addpurchasequote);

                if(insertquote)
                {
                    foreach(DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        float.TryParse(row.Cells[4].Value.ToString(), out float unitprice);
                        float.TryParse(row.Cells[5].Value.ToString(), out float totalunitprice);
                        string addproductdetails = string.Format("INSERT INTO InvoiceDetailsTable (Invoicecode,Productid,ProductName,Quantity,Price,Total,MFR) VALUES " +
                        "('" + invoicecode + "','" + row.Cells[1].Value + "','" + row.Cells[2].Value + "','" + row.Cells[3].Value + "','" + unitprice + "'," +
                        "'" + totalunitprice + "','" + row.Cells[0].Value + "')");
                        bool insertprod = DatabaseAccess.Insert(addproductdetails);

                    }
                }

            }catch (Exception ex) { throw ex; }
        }

        private void dgvpurchasequotationproduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvpurchaseproducts != null)
                {
                    if (dgvpurchaseproducts.Rows.Count > 0)
                    {
                        if(dgvpurchaseproducts.SelectedRows.Count == 1)
                        {
                            mfrtxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[0].Value.ToString();
                            selectproducttxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[1].Value.ToString();
                            qtytxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[2].Value.ToString();
                            pricetxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[3].Value.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row.");
                    }
                }
                else
                {
                    MessageBox.Show("No Record Available.");
                }
            }catch (Exception ex) { throw ex; }
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

        private void PurchaseQuotationInvoice_KeyDown(object sender, KeyEventArgs e)
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
            if(openForm == null)
            {
                SupplierSelectionForm supplierSelectionForm1 = new SupplierSelectionForm();
                supplierSelectionForm1.ShowDialog();
                UpdateSupplierTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
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

        private void UpdateSupplierTextBox()
        {
            selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
            supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
            codetxtbox.Text = GlobalVariables.suppliercodeglobal;
        }

        private void UpdateProductTextBox()
        {
            selectproducttxtbox.Text = GlobalVariables.productnameglobal;
            mfrtxtbox.Text = GlobalVariables.productmfrglobal;
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
        }

        private void PurchaseQuotationInvoice_FormClosing(object sender, FormClosingEventArgs e)
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
            if(selectsuppliertxtbox.Text.Trim().Length > 0)
            {
                return true;
            }

            if(narationtxtbox.Text.Trim().Length > 0)
            {
                return true;
            }

            if(selectproducttxtbox.Text.Trim().Length > 0)
            {
                return true;
            }

            if (dgvpurchaseproducts.Rows.Count > 0)
            {
                return true;
            }

            return false; // No TextBox is filled
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

        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalColumn(5);
        }

        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalColumn(5);
        }

        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
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

        private void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
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

        private void pricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void purchasetypetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
            if (openForm == null)
            {
                PurchaseTypeSelection purchaseTypeSelection = new PurchaseTypeSelection();
                purchaseTypeSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void purchasetypetxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
            if(openForm == null)
            {
                PurchaseTypeSelection purchaseTypeSelection = new PurchaseTypeSelection();
                purchaseTypeSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string mfr = mfrtxtbox.Text;
                string id = productidlbl.Text.ToString();
                string productname = selectproducttxtbox.Text.ToString();
                string qty = qtytxtbox.Text;
                string price = pricetxtbox.Text;
                bool productExists = false;

                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString())
                        {
                            float.TryParse(row.Cells["pricecolumn"].Value.ToString(), out float unitprice);
                            float.TryParse(pricetxtbox.Text.ToString(), out float newunitprice);
                            if (unitprice == newunitprice)
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                int totalQuantity = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                                float dgvtotal = unitprice * totalQuantity;
                                row.Cells["qtycolumn"].Value = totalQuantity;
                                row.Cells["totalcolumn"].Value = dgvtotal;
                                productExists = true;
                                mfrtxtbox.Text = string.Empty;
                                productidlbl.Text = string.Empty;
                                selectproducttxtbox.Text = string.Empty;
                                qtytxtbox.Text = string.Empty;
                                pricetxtbox.Text = string.Empty;
                                selectproducttxtbox.Focus();
                                break;
                            }
                            else
                            {
                                productExists = true;
                                MessageBox.Show("Price are not same");
                            }
                        }
                    }
                }

                if (!productExists)
                {
                    dgvpurchaseproducts.Rows.Add(mfr, id, productname, qty, price);
                    mfrtxtbox.Text = string.Empty;
                    productidlbl.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                    qtytxtbox.Text = string.Empty;
                    pricetxtbox.Text = string.Empty;
                    selectproducttxtbox.Focus();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void selectsuppliertxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
            if(openForm == null)
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
