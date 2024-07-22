using DocumentFormat.OpenXml.Office2010.Excel;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class PurchaseOrder : Form
    {
        private int invoiceCounter = 1;
        private decimal vatAmount = 0;
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        private void PurchaseOrderInvoice_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                    string invoicepart = "PO";
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
                    string invoicepart = "PO";
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PO-%' ORDER BY InvoiceNo DESC";
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
        private void CalculateTotalVatColumn(int columnIndex)
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
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox, "Please Select Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                if (dgvpurchaseproducts.Rows.Count == 0)
                {
                    errorProvider.SetError(dgvpurchaseproducts,"Please Select Products");
                    selectproducttxtbox.Focus();
                    return;
                }

                string invoiceno = CheckInvoiceBeforeInsert();
                float.TryParse(nettotaltxtbox.Text, out float totalpayable);
                string invoicecode = Guid.NewGuid().ToString(); 
                string addpurchaseorder = string.Format("INSERT INTO InvoiceTable (InvoiceNo,InvoiceDate,SupplierId,SupplierName,Narration,CreatedAt,CreatedDay,InvoiceCode," +
                    "NetPayable) VALUES ('" + invoiceno + "','" + invoicedatetxtbox.Text + "','" + supplieridlbl.Text + "','" + selectsuppliertxtbox.Text + "'," +
                    "'" + narationtxtbox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoicecode + "','" + totalpayable + "')");
                bool insertorder = DatabaseAccess.Insert(addpurchaseorder);
                if (insertorder)
                {
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        float.TryParse(row.Cells[4].Value.ToString(), out float unitprice);
                        float.TryParse(row.Cells[5].Value.ToString(), out float totalunitprice);
                        string addproductdetails = string.Format("INSERT INTO InvoiceDetailsTable (Invoicecode,Productid,ProductName,Quantity,Price,Total,MFR) VALUES " +
                        "('" + invoicecode + "','" + row.Cells[1].Value + "','" + row.Cells[2].Value + "','" + row.Cells[3].Value + "','" + row.Cells[4].Value + "'," +
                        "'" + row.Cells[5].Value + "','" + row.Cells[0].Value + "')");
                        bool insertprod = DatabaseAccess.Insert(addproductdetails);
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            PurchaseOrder purchaseOrderInvoice = new PurchaseOrder();
            purchaseOrderInvoice.MdiParent = this;
            purchaseOrderInvoice.Show();
        }
        private void dgvpurchasequotationproduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvpurchaseproducts != null)
                {
                    if (dgvpurchaseproducts.Rows.Count > 0)
                    {
                        if(dgvpurchaseproducts.SelectedRows.Count == 1)
                        {
                            mfrtxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[0].Value.ToString();
                            productidlbl.Text = dgvpurchaseproducts.CurrentRow.Cells[1].Value.ToString();
                            selectproducttxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[2].Value.ToString();
                            qtytxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[3].Value.ToString();
                            pricetxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[4].Value.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row");
                    }
                }
                else
                {
                    MessageBox.Show("No Record Available.");
                }
            }catch(Exception ex) { throw ex; }
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
        private void PurchaseOrderInvoice_KeyDown(object sender, KeyEventArgs e)
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
                SupplierSelectionForm supplierSelectionForm = new SupplierSelectionForm();
                supplierSelectionForm.ShowDialog();
                UpdateSupplierTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateSupplierTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.suppliernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.suppliercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) && 
                GlobalVariables.supplieridglobal > 0)
            {
                selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
                codetxtbox.Text = GlobalVariables.suppliercodeglobal;
            }
        }
        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if (openForm == null) 
            {
                ProductSelectionForm productSelectionForm2 = new ProductSelectionForm();
                productSelectionForm2.ShowDialog();
                UpdateProductTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateProductTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) && 
                GlobalVariables.productidglobal > 0)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal;
                mfrtxtbox.Text = GlobalVariables.productmfrglobal;
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
            }
        }
        private void PurchaseOrderInvoice_FormClosing(object sender, FormClosingEventArgs e)
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
        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalVatColumn(8);
            CalculateTotalColumn(11);
            CalculateTotalDiscountColumn(9);
        }
        private void CalculateTotalDiscountColumn(int columnIndex)
        {
            decimal totaldiscount = 0;

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.Cells[columnIndex].Value != null)
                {
                    if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                    {
                        totaldiscount += value;
                    }
                }
            }

            totaldiscounttxtbox.Text = totaldiscount.ToString("N2");
        }
        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalVatColumn(8);
            CalculateTotalColumn(11);
            CalculateTotalDiscountColumn(9);
        }
        private void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm supplierSelectionForm = new SupplierSelectionForm();
                    supplierSelectionForm.ShowDialog();
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
                    ProductSelectionForm productSelectionForm2 = new ProductSelectionForm();
                    productSelectionForm2.ShowDialog();
                    UpdateProductTextBox();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void purchasetypetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
            if (openForm == null)
            {
                PurchaseTypeSelection purchaseTypeSelection = new PurchaseTypeSelection();
                purchaseTypeSelection.ShowDialog();
                UpdatePurchaseTypeTxtBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdatePurchaseTypeTxtBox()
        {
            if (GlobalVariables.purchasetypeidglobal > 0 && !string.IsNullOrEmpty(GlobalVariables.purchasetypenameglobal) &&
                !string.IsNullOrWhiteSpace(GlobalVariables.purchasetypenameglobal))
            {
                purchasetypeidlbl.Text = GlobalVariables.purchasetypeidglobal.ToString();
                purchasetypetxtbox.Text = GlobalVariables.purchasetypenameglobal.ToString();
            }
        }
        private void purchasetypetxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
            if (openForm == null) 
            {
                PurchaseTypeSelection purchaseTypeSelection = new PurchaseTypeSelection();
                purchaseTypeSelection.ShowDialog();
                UpdatePurchaseTypeTxtBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void selectsuppliertxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(codetxtbox.Text) && !string.IsNullOrWhiteSpace(codetxtbox.Text) && !string.IsNullOrEmpty(selectsuppliertxtbox.Text) && 
                !string.IsNullOrWhiteSpace(selectsuppliertxtbox.Text) && !string.IsNullOrEmpty(supplieridlbl.Text) && !string.IsNullOrWhiteSpace(supplieridlbl.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
                if (openForm == null)
                {
                    CurrencySelection currencySelection = new CurrencySelection();
                    currencySelection.ShowDialog();
                    UpdateCurrencySelection();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateCurrencySelection()
        {
            if (GlobalVariables.currencyidglobal > 0 && !string.IsNullOrEmpty(GlobalVariables.currencynameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencynameglobal)
                && !string.IsNullOrEmpty(GlobalVariables.currencysymbolglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencysymbolglobal) &&
                GlobalVariables.currencyconversionrateglobal > 0)
            {
                currencyidlbl.Text = GlobalVariables.currencyidglobal.ToString();
                currencynamelbl.Text = GlobalVariables.currencynameglobal.ToString();
                currencysymbollbl.Text = GlobalVariables.currencysymbolglobal.ToString();
                currencyconversionratelbl.Text = GlobalVariables.currencyconversionrateglobal.ToString();
            }
        }
        private void selectproducttxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductQtyWarehouse));
            if (openForm == null) 
            {
                if (!string.IsNullOrEmpty(productidlbl.Text) && !string.IsNullOrWhiteSpace(productidlbl.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text))
                {
                    string productmfr = mfrtxtbox.Text;
                    int productid = Convert.ToInt32(productidlbl.Text);
                    ProductQtyWarehouse productQtyWarehouse = new ProductQtyWarehouse(productmfr,productid);
                    productQtyWarehouse.ShowDialog();
                }
            }
            else
            {
                openForm.BringToFront(); 
            }
        }
        private void narationtxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(InvoiceNoteForm));
            if (openForm == null) 
            {
                InvoiceNoteForm invoiceNote = new InvoiceNoteForm();
                invoiceNote.ShowDialog();
                UpdateInvoiceSpecialNote();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateInvoiceSpecialNote()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.invoicespecialnote) && !string.IsNullOrWhiteSpace(GlobalVariables.invoicespecialnote))
            {
                invoicespecialnotelbl.Text = GlobalVariables.invoicespecialnote;
            }
        }
        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) && 
                    !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) && !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text) &&
                    !string.IsNullOrEmpty(pricetxtbox.Text) && !string.IsNullOrWhiteSpace(pricetxtbox.Text))
                {
                    int itemqty = Convert.ToInt32(qtytxtbox.Text);
                    float itemprice = float.Parse(pricetxtbox.Text);
                    float totalamount = itemqty * itemprice;

                    if (GlobalVariables.purchasetypeistaxable)
                    {
                        VATForm vATForm = new VATForm(totalamount);
                        vATForm.ShowDialog();
                    }
                    else
                    {
                        DiscountForm discountForm = new DiscountForm(totalamount);
                        discountForm.ShowDialog();
                    }
                    string mfr = mfrtxtbox.Text;
                    string itemdescription = GlobalVariables.productitemwisedescriptiongloabl;
                    string productid = productidlbl.Text;
                    string productname = selectproducttxtbox.Text;
                    string qty = qtytxtbox.Text;
                    string price = pricetxtbox.Text;
                    decimal vat = GlobalVariables.productitemwisevatamount;
                    decimal discount = GlobalVariables.productdiscountamountitemwise;
                    string unitid = GlobalVariables.unitidglobal.ToString();
                    string unitname = GlobalVariables.unitnameglobal.ToString();
                    string productcondition = "NEW";

                    if (vat > 0)
                    {
                        totalvattxtbox.Visible = true;
                        totalvatlbl.Visible = true;
                    }

                    if (discount > 0)
                    {
                        totaldiscounttxtbox.Visible = true;
                        totaldiscountlbl.Visible = true;
                    }
                    string finalitemwise = GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("N2");

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
                                    int totalqty = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                                    float dgvtotal = unitprice * totalqty;
                                    row.Cells["qtycolumn"].Value = totalqty;

                                    row.Cells["vatcolumn"].Value = vatAmount;
                                    row.Cells["totalcolumn"].Value = Convert.ToDecimal(dgvtotal) + vatAmount;
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
                                    productExists = false;
                                    ProductConditionForm productConditionForm = new ProductConditionForm();
                                    productConditionForm.ShowDialog();
                                    productcondition = GlobalVariables.productconditionglobal;
                                }
                            }
                        }
                    }

                    if (!productExists)
                    {
                        dgvpurchaseproducts.Rows.Add(mfr, itemdescription, productcondition, productid, productname, qty, unitid, unitname, vat, discount, price, finalitemwise);
                        mfrtxtbox.Text = string.Empty;
                        productidlbl.Text = string.Empty;
                        selectproducttxtbox.Text = string.Empty;
                        qtytxtbox.Text = string.Empty;
                        pricetxtbox.Text = string.Empty;
                        selectproducttxtbox.Focus();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
