
using DocumentFormat.OpenXml.Spreadsheet;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class PurchaseQuotationInvoice : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        public PurchaseQuotationInvoice()
        {
            InitializeComponent();
        }
        public PurchaseQuotationInvoice(DataTable dtInvoice,DataTable dtInvoiceDetail)
        {
            InitializeComponent();
            this._dtinvoice = dtInvoice;
            this._dtinvoicedetails = dtInvoiceDetail;
        }
        private void PurchaseQuotationInvoice_Load(object sender, EventArgs e)
        {
            if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails!=null && _dtinvoicedetails.Rows.Count > 0)
            {
                DataRow row = _dtinvoice.Rows[0];
                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                purchasetypetxtbox.Text = row["InvoiceTypeName"].ToString();
                purchasetypeidlbl.Text = row["InvoiceTypeid"].ToString();
                selectsuppliertxtbox.Text = row["ClientName"].ToString();
                currencyidlbl.Text = row["Currencyid"].ToString();
                currencynamelbl.Text = row["CurrencyName"].ToString();
                currencysymbollbl.Text = row["CurrencySymbol"].ToString();
                currencyconversionratelbl.Text = row["ConversionRate"].ToString();
                nettotaltxtbox.Text = row["NetTotal"].ToString();
                if (row["TotalVat"].ToString() != null)
                {
                    totalvattxtbox.Visible = true;
                    totalvattxtbox.Text = row["TotalVat"].ToString();
                }

                if(row["TotalDiscount"].ToString() != null)
                {
                    totaldiscounttxtbox.Visible = true;
                    totaldiscounttxtbox.Text = row["TotalDiscount"].ToString();
                }
                
                narationtxtbox.Text = row["Narration"].ToString();
                foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                {
                    int detailsRowIndex = dgvpurchaseproducts.Rows.Add();
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["mfrcolumn"].Value = invoiceDetailsRow["MFR"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productconditioncolumn"].Value = invoiceDetailsRow["ProductCondition"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitnamecolumn"].Value = invoiceDetailsRow["Unitid"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"];
                }
            }
            else
            {
                invoicenotxtbox.Text = GenerateNextInvoiceNumber();
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                bool IsInserted = false;
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
                DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                string invoicecode = Guid.NewGuid().ToString();
                string purchaseType = purchasetypetxtbox.Text;
                int purchaseTypeid = Convert.ToInt32(purchasetypeidlbl.Text);
                int supplierId = Convert.ToInt32(supplieridlbl.Text);
                string suppliercode = codetxtbox.Text;
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
                    "TotalVat,TotalDiscount,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice,InvoiceTypeName,IsTaxAble,InvoiceSpecialNote) " +
                    "VALUES ('" + invoiceno + "','" + invoiceDate + "','" + supplierId + "','" + naration + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                    "'" + DateTime.Now.DayOfWeek + "','" + invoicecode + "','" + nettotal + "','" + supplierName + "','" + netVat + "','" + totaldiscount + "','" + currencyid + "'," +
                    "'" + currencyName + "','" + currencySymbol + "','" + currencyconversionRate + "','" + purchaseTypeid + "','" + false + "','" + purchaseType + "'," +
                    "'" + GlobalVariables.purchasetypeistaxable + "','" + invoicespecialnote + "')");
                
                bool insertquote = DatabaseAccess.Insert(addpurchasequote);

                if(insertquote)
                {
                    foreach(DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                        bool productCondition = Convert.ToBoolean(row.Cells["productconditioncolumn"].Value.ToString());
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
                            "ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid,ItemTotal,Unitid,ProductCondition,IncludeInventory) VALUES ('" + invoiceno + "','" + invoicecode + "'," +
                            "'" + productid + "','" + quantity + "','" + costprice + "','" + productname + "','" + mfr + "','" + discount + "','" + vat + "'," +
                            "'" + itemdescription + "','" + warehouseid + "','" + total + "','" + unitid + "','" + productCondition + "','" + false + "')");
                        bool insertprod = DatabaseAccess.Insert(addproductdetails);

                    }

                    IsInserted = true;
                }

                if (IsInserted)
                {
                    this.Close();
                    QuotationReportView quotationReportView = new QuotationReportView();
                    quotationReportView.Show();
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
            if(!string.IsNullOrEmpty(GlobalVariables.suppliernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.suppliercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) && 
                GlobalVariables.supplieridglobal > 0)
            {
                selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
                codetxtbox.Text = GlobalVariables.suppliercodeglobal;
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
        private bool AreAnyTextBoxesFilled()
        {
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }
            if (narationtxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
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

            nettotaltxtbox.Text = total.ToString("N2");
        }
        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalColumn(11);
            CalculateTotalVatColumn(8);
            CalculateTotalDiscountColumn(9);
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
        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalColumn(11);
            CalculateTotalVatColumn(8);
            CalculateTotalDiscountColumn(9);
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
            if(GlobalVariables.purchasetypeidglobal > 0 && !string.IsNullOrEmpty(GlobalVariables.purchasetypenameglobal) && 
                !string.IsNullOrWhiteSpace(GlobalVariables.purchasetypenameglobal))
            {
                purchasetypeidlbl.Text = GlobalVariables.purchasetypeidglobal.ToString();
                purchasetypetxtbox.Text = GlobalVariables.purchasetypenameglobal.ToString();
            }
        }
        private void purchasetypetxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
            if(openForm == null)
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
                !string.IsNullOrWhiteSpace(selectsuppliertxtbox.Text))
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
            if(GlobalVariables.currencyidglobal > 0 && !string.IsNullOrEmpty(GlobalVariables.currencynameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencynameglobal)
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
            if(!string.IsNullOrEmpty(GlobalVariables.invoicespecialnote) && !string.IsNullOrWhiteSpace(GlobalVariables.invoicespecialnote))
            {
                invoicespecialnotelbl.Text = GlobalVariables.invoicespecialnote;
            }
        }
        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if(purchasetypetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(purchasetypetxtbox,"Please Select Purchase type.");
                    purchasetypetxtbox.Focus();
                    return;
                }

                if(selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectproducttxtbox,"Please Select Supplier");
                    selectproducttxtbox.Focus();
                    return;
                }

                if(!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) && 
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
                    string itemdescription = itemwisedescriptionlbl.Text;
                    string id = productidlbl.Text.ToString();
                    string productname = selectproducttxtbox.Text.ToString();
                    string qty = qtytxtbox.Text;
                    decimal vat = GlobalVariables.productitemwisevatamount;
                    decimal discount = GlobalVariables.productdiscountamountitemwise;
                    string unitid = GlobalVariables.unitidglobal.ToString();
                    string unitname = GlobalVariables.unitnameglobal.ToString();
                    int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
                    decimal price = decimal.Parse(pricetxtbox.Text);
                    bool productCondition = GlobalVariables.productconditionglobal;

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
                                    GlobalVariables.productitemwisevatamount = 0;
                                    GlobalVariables.productdiscountamountitemwise = 0;
                                    GlobalVariables.unitidglobal = 0;
                                    GlobalVariables.unitnameglobal = string.Empty;
                                    selectproducttxtbox.Focus();
                                    break;
                                }
                                else
                                {
                                    productExists = false;
                                    mfrtxtbox.Text = string.Empty;
                                    productidlbl.Text = string.Empty;
                                    selectproducttxtbox.Text = string.Empty;
                                    qtytxtbox.Text = string.Empty;
                                    pricetxtbox.Text = string.Empty;
                                    GlobalVariables.productitemwisevatamount = 0;
                                    GlobalVariables.productdiscountamountitemwise = 0;
                                    GlobalVariables.unitidglobal = 0;
                                    GlobalVariables.unitnameglobal = string.Empty;
                                    selectproducttxtbox.Focus();
                                    break;
                                }
                            }
                        }
                    }

                    if (!productExists)
                    {
                        dgvpurchaseproducts.Rows.Add(mfr,
                                                    itemdescription,
                                                    productCondition,
                                                    id, 
                                                    productname, 
                                                    qty,
                                                    unitid,
                                                    unitname,
                                                    vat.ToString("N2"),
                                                    discount.ToString("N2"), 
                                                    price.ToString("N2"), 
                                                    finalitemwise,
                                                    warehouseid);
                        mfrtxtbox.Text = string.Empty;
                        productidlbl.Text = string.Empty;
                        selectproducttxtbox.Text = string.Empty;
                        qtytxtbox.Text = string.Empty;
                        pricetxtbox.Text = string.Empty;
                        GlobalVariables.productitemwisevatamount = 0;
                        GlobalVariables.productdiscountamountitemwise = 0;
                        GlobalVariables.unitidglobal = 0;
                        GlobalVariables.unitnameglobal = string.Empty;
                        selectproducttxtbox.Focus();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void PurchaseQuotationInvoice_KeyDown(object sender, KeyEventArgs e)
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
    }
}
