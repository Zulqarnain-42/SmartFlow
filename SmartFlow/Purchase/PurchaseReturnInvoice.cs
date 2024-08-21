using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class PurchaseReturnInvoice : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        public PurchaseReturnInvoice()
        {
            InitializeComponent();
        }
        public PurchaseReturnInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        private void PurchaseReturnInvoice_Load(object sender, EventArgs e)
        {
            if(_dtinvoice!=null && _dtinvoice.Rows.Count>0 && _dtinvoicedetails!=null && _dtinvoicedetails.Rows.Count > 0)
            {

            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                invoicenotxtbox.Text = GenerateNextInvoiceNumber();
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
            if(!string.IsNullOrEmpty(GlobalVariables.suppliernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.suppliercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) && 
                GlobalVariables.supplieridglobal > 0)
            {
                supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
                selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                suppliercodetxtbox.Text = GlobalVariables.suppliercodeglobal;
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
            if(!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) && 
                GlobalVariables.productidglobal > 0)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal;
                mfrtxtbox.Text = GlobalVariables.productmfrglobal;
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
            }

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
            CalculateTotalColumn(11);
            CalculateTotalVat(9);
            CalculateTotalDiscountColumn(10);
        }
        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalColumn(11);
            CalculateTotalVat(9);
            CalculateTotalDiscountColumn(10);
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
        private void selectsuppliertxtbox_Leave(object sender, EventArgs e)
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
        private void selectproducttxtbox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(productidlbl.Text) && !string.IsNullOrWhiteSpace(productidlbl.Text) && !string.IsNullOrEmpty(mfrtxtbox.Text) &&
                !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductQtyWarehouse));
                if (openForm == null)
                {
                    string productmfr = mfrtxtbox.Text;
                    int productid = Convert.ToInt32(productidlbl.Text);
                    ProductQtyWarehouse productQtyWarehouse = new ProductQtyWarehouse(productmfr, productid);
                    productQtyWarehouse.ShowDialog();
                    UpdateWarehouseinfo();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateWarehouseinfo()
        {
            if (GlobalVariables.warehouseidglobal > 0 && !string.IsNullOrEmpty(GlobalVariables.warehousenameglobal)
                && !string.IsNullOrWhiteSpace(GlobalVariables.warehousenameglobal))
            {
                warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
                itemwisedescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl;
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
                openForm.ShowDialog();
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
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
                if (openForm == null) 
                {
                    PurchaseTypeSelection purchaseType = new PurchaseTypeSelection();
                    purchaseType.ShowDialog();
                    UpdatePurchaseTypeTxtBox();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void narationtxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(InvoiceNoteForm));
            if (openForm == null)
            {
                InvoiceNoteForm invoiceNoteForm = new InvoiceNoteForm();
                invoiceNoteForm.ShowDialog();
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
                    string productname = selectproducttxtbox.Text;
                    string productid = productidlbl.Text;
                    string qty = qtytxtbox.Text;
                    string price = pricetxtbox.Text;
                    decimal vat = GlobalVariables.productitemwisevatamount;
                    decimal discount = GlobalVariables.productdiscountamountitemwise;
                    string unitid = GlobalVariables.unitidglobal.ToString();
                    string unitname = GlobalVariables.unitnameglobal.ToString();
                    string itemdescription = itemwisedescriptionlbl.Text;
                    int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
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

                    int quantity = Convert.ToInt32(qty);

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
                        dgvpurchaseproducts.Rows.Add(mfr, itemdescription, null, productid, productname, qty, unitid, unitname, price, vat, discount, finalitemwise, warehouseid);
                    }

                    mfrtxtbox.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                    productidlbl.Text = string.Empty;
                    qtytxtbox.Text = string.Empty;
                    pricetxtbox.Text = string.Empty;
                }
            }
            catch (Exception ex) { throw ex; }

        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool isInserted = false;
                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox, "Please Enter Invoice no");
                    invoicenotxtbox.Focus();
                    return;
                }

                if (suppliercodetxtbox.Text.Trim().Length == 0 && selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox, "Please Select a Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                string invoiceno = CheckInvoiceBeforeInsert();
                DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                string invoicecode = Guid.NewGuid().ToString();
                string purchaseType = purchasetypetxtbox.Text;
                int purchaseTypeid = Convert.ToInt32(purchasetypeidlbl.Text);
                int supplierId = Convert.ToInt32(supplieridlbl.Text);
                string suppliercode = suppliercodetxtbox.Text;
                string supplierName = selectsuppliertxtbox.Text;
                string naration = CommonFunction.CleanText(narationtxtbox.Text);
                string invoicespecialnote = CommonFunction.CleanText(invoicespecialnotelbl.Text);
                int currencyid = Convert.ToInt32(currencyidlbl.Text);
                string currencyName = currencynamelbl.Text;
                string currencySymbol = currencysymbollbl.Text;
                float currencyconversionRate = float.Parse(currencyconversionratelbl.Text);
                float nettotal = float.Parse(nettotaltxtbox.Text);
                float netVat = float.Parse(totalvattxtbox.Text);
                float totaldiscount = float.Parse(totaldiscounttxtbox.Text);


                string addpurchasequote = string.Format("INSERT INTO InvoiceTable (InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,InvoiceCode,NetTotal,ClientName," +
                    "TotalVat,TotalDiscount,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName,IsTaxAble) " +
                    "VALUES ('" + invoiceno + "','" + invoiceDate + "','" + supplierId + "','" + naration + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                    "'" + DateTime.Now.DayOfWeek + "','" + invoicecode + "','" + nettotal + "','" + supplierName + "','" + netVat + "','" + totaldiscount + "','" + currencyid + "'," +
                    "'" + currencyName + "','" + currencySymbol + "','" + currencyconversionRate + "','" + purchaseTypeid + "','" + false + "','" + purchaseType + "'," +
                    "'" + GlobalVariables.purchasetypeistaxable + "')");

                bool insertquote = DatabaseAccess.Insert(addpurchasequote);

                if (insertquote)
                {
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                        float costprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                        string productname = row.Cells["productnamecolumn"].Value.ToString();
                        string mfr = row.Cells["mfrcolumn"].Value.ToString();
                        float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                        float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                        string itemdescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                        int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                        float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                        int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());

                        string addproductdetails = string.Format("INSERT INTO InvoiceDetailsTable (InvoiceNo,Invoicecode,Productid,Quantity,UnitSalePrice,ProductName,MFR," +
                            "ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid,ItemTotal,Unitid,IncludeInventory) VALUES ('" + invoiceno + "','" + invoicecode + "'," +
                            "'" + productid + "','" + quantity + "','" + costprice + "','" + productname + "','" + mfr + "','" + discount + "','" + vat + "'," +
                            "'" + itemdescription + "','" + warehouseid + "','" + total + "','" + unitid + "','" + true + "')");

                        bool insertprod = DatabaseAccess.Insert(addproductdetails);

                    }

                    isInserted = true;
                }

                if (isInserted)
                {
                    this.Close();
                }

            }
            catch (Exception ex) { throw ex; }
        }
    }
}
