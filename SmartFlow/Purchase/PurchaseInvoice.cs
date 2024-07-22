using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Masters;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
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
            if (!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) && 
                GlobalVariables.productidglobal > 0)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal;
                mfrtxtbox.Text = GlobalVariables.productmfrglobal;
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
            }
        }
        private void UpdateSupplierTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.suppliernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.suppliercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) && 
                GlobalVariables.supplieridglobal > 0)
            {
                selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                codetxtbox.Text = GlobalVariables.suppliercodeglobal;
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
            CalculateTotalVat(13);
            CalculateTotalColumn(14);
            CalculateTotalDiscount(12);
        }
        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalVat(13);
            CalculateTotalColumn(14);
            CalculateTotalDiscount(12);
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

            nettotaltxtbox.Text = total.ToString("N2");
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

            totalvattxtbox.Text = totalvat.ToString("N2");
        }
        private void CalculateTotalDiscount(int columnIndex)
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

            totalvattxtbox.Text = totaldiscount.ToString("N2");
        }
        private void selectpurchasetype_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SaleTypeSelection));
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
        private void salepricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) &&
                    !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) && !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text) &&
                    !string.IsNullOrEmpty(salepricetxtbox.Text) && !string.IsNullOrWhiteSpace(salepricetxtbox.Text) && !string.IsNullOrEmpty(costpricetxtbox.Text) && 
                    !string.IsNullOrWhiteSpace(costpricetxtbox.Text) && !string.IsNullOrEmpty(lowestpricetxtbox.Text) && !string.IsNullOrWhiteSpace(lowestpricetxtbox.Text) && 
                    !string.IsNullOrEmpty(standardpricetxtbox.Text) && !string.IsNullOrWhiteSpace(standardpricetxtbox.Text))
                {
                    int itemqty = Convert.ToInt32(qtytxtbox.Text);
                    float itemprice = float.Parse(costpricetxtbox.Text);
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
                    string costprice = costpricetxtbox.Text;
                    string lowestprice = lowestpricetxtbox.Text;
                    string standardprice = standardpricetxtbox.Text;
                    string saleprice = salepricetxtbox.Text;
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
                        dgvpurchaseproducts.Rows.Add(mfr, productid,itemdescription,productcondition, productname, qty,unitid,unitname, costprice, lowestprice, standardprice,
                            saleprice,discount, vat,finalitemwise);
                    }

                    mfrtxtbox.Text = string.Empty;
                    productidlbl.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                    qtytxtbox.Text = string.Empty;
                    costpricetxtbox.Text = string.Empty;
                    lowestpricetxtbox.Text = string.Empty;
                    standardpricetxtbox.Text = string.Empty;
                    salepricetxtbox.Text = string.Empty;
                    selectproducttxtbox.Focus();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void selectsuppliertxtbox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codetxtbox.Text) && !string.IsNullOrWhiteSpace(codetxtbox.Text) && !string.IsNullOrEmpty(selectsuppliertxtbox.Text) &&
                !string.IsNullOrWhiteSpace(selectsuppliertxtbox.Text) && !string.IsNullOrEmpty(supplieridlbl.Text) && !string.IsNullOrWhiteSpace(supplieridlbl.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
                if (openForm == null) 
                {
                    CurrencySelection currencySelection = new CurrencySelection();
                    currencySelection.ShowDialog();
                    UpdateCurrencyTextBox();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateCurrencyTextBox()
        {
            if (GlobalVariables.currencyidglobal > 0 && GlobalVariables.currencynameglobal != null && GlobalVariables.currencysymbolglobal != null &&
                GlobalVariables.currencyconversionrateglobal > 0)
            {
                currencyidlbl.Text = GlobalVariables.currencyidglobal.ToString();
                currencyconversionratelbl.Text = GlobalVariables.currencyconversionrateglobal.ToString();
                currencynamelbl.Text = GlobalVariables.currencynameglobal.ToString();
                currencysymbollbl.Text = GlobalVariables.currencysymbolglobal.ToString();
            }
        }
        private void narationtxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(InvoiceNoteForm));
            if (openForm == null)
            {
                InvoiceNoteForm invoiceNoteForm = new InvoiceNoteForm();
                invoiceNoteForm.ShowDialog();
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
    }
}
