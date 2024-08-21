using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class SaleReturnInvoice : Form
    {
        private decimal vatAmount = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        public SaleReturnInvoice()
        {
            InitializeComponent();
        }
        public SaleReturnInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        private void SaleReturnInvoice_Load(object sender, EventArgs e)
        {
            if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
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
                    string invoicepart = "SR";
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
                    string invoicepart = "SR";
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'SR-%' ORDER BY InvoiceNo DESC";
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
        private void SaleReturnInvoice_KeyDown(object sender, KeyEventArgs e)
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
        private void dgvsaleproduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvsaleproducts != null)
                {
                    if (dgvsaleproducts.Rows.Count > 0)
                    {
                        if (dgvsaleproducts.SelectedRows.Count == 1)
                        {
                            mfrtxtbox.Text = dgvsaleproducts.CurrentRow.Cells[0].Value.ToString();
                            selectproducttxtbox.Text = dgvsaleproducts.CurrentRow.Cells[1].Value.ToString();
                            qtytxtbox.Text = dgvsaleproducts.CurrentRow.Cells[3].Value.ToString();
                            pricetxtbox.Text = dgvsaleproducts.CurrentRow.Cells[4].Value.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record.");
                    }
                }
                else
                {
                    MessageBox.Show("No Record Available.");
                }
            }catch(Exception ex) { throw ex; }
        }
        private void dgvsaleproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvsaleproducts.CurrentRow.Cells[0].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvsaleproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvsaleproducts.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }
        private void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
            if(openForm == null)
            {
                CustomerSelectionForm customerSelection = new CustomerSelectionForm();
                customerSelection.ShowDialog();
                UpdateCustomerTextBox();
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
                ProductSelectionForm ProductSelectionForm = new ProductSelectionForm();
                ProductSelectionForm.ShowDialog();
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
                selectproducttxtbox.Text = GlobalVariables.productnameglobal.ToString();
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
                mfrtxtbox.Text = GlobalVariables.productmfrglobal.ToString();
            }

        }
        private void UpdateCustomerTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.customercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.customercodeglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.customermobileglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.customermobileglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.customernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.customernameglobal) && 
                GlobalVariables.customeridglobal > 0)
            {
                codetxtbox.Text = GlobalVariables.customercodeglobal.ToString();
                selectcustomertxtbox.Text = GlobalVariables.customernameglobal.ToString();
                refrencetxtbox.Text = GlobalVariables.customerrefrencegloba.ToString();
                mobiletxtbox.Text = GlobalVariables.customermobileglobal.ToString();
            }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (selectcustomertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvsaleproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void dgvsaleproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalVatColumn(5);
            CalculateTotalColumn(7);
        }
        private void CalculateTotalColumn(int columnIndex)
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvsaleproducts.Rows)
            {
                if (row.Cells[columnIndex].Value != null)
                {
                    if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                    {
                        total += value;
                    }
                }
            }

            nettotaltxtbox.Text = total.ToString("0.00 AED");
        }
        private void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalVatColumn(5);
            CalculateTotalColumn(7);
        }
        private void CalculateTotalVatColumn(int columnIndex)
        {
            decimal totalvat = 0;

            foreach (DataGridViewRow row in dgvsaleproducts.Rows)
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
        private void salesmantxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SalesPersonSelection));
            if (openForm == null)
            {
                SalesPersonSelection salesPersonSelection = new SalesPersonSelection();
                salesPersonSelection.ShowDialog();
                UpdateSalesPersonInfo();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateSalesPersonInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.salespersonnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.salespersonnameglobal) && 
                GlobalVariables.salespersonidglobal > 0)
            {
                salespersonidlbl.Text = GlobalVariables.salespersonidglobal.ToString();
                salesmantxtbox.Text = GlobalVariables.salespersonnameglobal;
            }
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
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
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
                    dgvsaleproducts.Rows.Add(mfr, productid, productname, qty, price, vatAmount);
                }

                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                pricetxtbox.Text = string.Empty;

                selectproducttxtbox.Focus();
            }
            catch (Exception ex) { throw ex; }
        }
        private void selectcustomertxtbox_Leave(object sender, EventArgs e)
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
                if (!string.IsNullOrEmpty(productidlbl.Text) && !string.IsNullOrWhiteSpace(productidlbl.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text))
                {
                    string productmfr = mfrtxtbox.Text;
                    int productid = Convert.ToInt32(productidlbl.Text);
                    ProductQtyWarehouse productQtyWarehouse = new ProductQtyWarehouse(productmfr, productid);
                    productQtyWarehouse.ShowDialog();
                }
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void saletypetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SaleTypeSelection));
            if (openForm == null)
            {
                SaleTypeSelection saletype = new SaleTypeSelection();
                saletype.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void saletypetxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
        }
        private void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
                if (openForm == null)
                {
                    CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm();
                    customerSelectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void salesmantxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SalesPersonSelection));
                if(openForm == null)
                {
                    SalesPersonSelection salesPersonSelection = new SalesPersonSelection();
                    salesPersonSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void narationtxtbox_Leave(object sender, EventArgs e)
        {
            InvoiceNoteForm invoiceNoteForm = new InvoiceNoteForm();
            invoiceNoteForm.ShowDialog();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            bool detailadded = false;
            try
            {
                string invoiceNo = CheckInvoiceBeforeInsert();
                DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                int saletypeid = Convert.ToInt32(saletypeidlbl.Text);
                string saletypename = saletypetxtbox.Text;
                int customerid = Convert.ToInt32(customeridlbl.Text);
                string customercode = codetxtbox.Text;
                string customername = selectcustomertxtbox.Text;
                string customerrefrence = refrencetxtbox.Text;
                string mobile = mobiletxtbox.Text;
                int salepersonid = Convert.ToInt32(salespersonidlbl.Text);
                string salespersonname = salesmantxtbox.Text;
                int currencyid = Convert.ToInt32(currencyidlbl.Text);
                decimal currencyconversionrate = decimal.Parse(currencyconversionratelbl.Text);
                string currencyname = currencynamelbl.Text;
                string currencysymbol = currencysymbollbl.Text;
                string naration = CommonFunction.CleanText(narationtxtbox.Text);
                string invoicespecialnotes = CommonFunction.CleanText(invoicespecialnotelbl.Text);
                float nettotal = float.Parse(nettotaltxtbox.Text);
                float totalvat = float.Parse(totalvattxtbox.Text);
                float totaldiscount = 0;

                if (!string.IsNullOrEmpty(totaldiscounttxtbox.Text) && !string.IsNullOrWhiteSpace(totaldiscounttxtbox.Text))
                {
                    totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                }

                string invoicecode = Guid.NewGuid().ToString();

                string addquotationmaster = string.Format("INSERT INTO InvoiceTable (InvoiceNo,invoicedate,ClientID,Narration,CreatedAt,CreatedDay,InvoiceCode,NetTotal," +
                    "ClientName,TotalVat,TotalDiscount,FreightShippingCharges,Currencyid,CurrencyName,CurrencySymbol,ConversionRate,InvoiceTypeid,IsSaleInvoice," +
                    "InvoiceTypeName,IsTaxAble) VALUES ('" + invoiceNo + "'," +
                    "'" + invoiceDate + "','" + customerid + "','" + naration + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "'," +
                    "'" + invoicecode + "','" + nettotal + "','" + customername + "','" + totalvat + "','" + totaldiscount + "','" + currencyid + "'," +
                    "'" + currencyname + "','" + currencysymbol + "','" + currencyconversionrate + "','" + saletypeid + "','" + true + "','" + saletypename + "'," +
                    "'" + GlobalVariables.saletypeistaxable + "')");
                bool result = DatabaseAccess.Insert(addquotationmaster);

                if (result)
                {
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                        float unitprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                        string productname = row.Cells["productnamecolumn"].Value.ToString();
                        string mfr = row.Cells["codecolumn"].Value.ToString();
                        float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                        float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                        string itemdescription = row.Cells["itemwisedescriptioncolumn"].Value.ToString();
                        int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                        float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                        int unitid = Convert.ToInt32(row.Cells["unitid"].Value.ToString());

                        string addquotationdetail = string.Format("INSERT INTO InvoiceDetailsTable (InvoiceNo,Invoicecode,Productid,Quantity,UnitSalePrice," +
                        "ItemSerialNo,ProductName,MFR,ItemWiseDiscount,ItemWiseVAT,ItemDescription," +
                        "Warehouseid,ItemTotal,Unitid) VALUES ('" + invoiceNo + "','" + invoicecode + "','" + productid + "','" + quantity + "','" + unitprice + "'," +
                        "'" + null + "','" + productname + "','" + mfr + "','" + discount + "','" + vat + "','" + itemdescription + "','" + warehouseid + "'," +
                        "'" + total + "','" + unitid + "')");

                        DatabaseAccess.Insert(addquotationdetail);
                    }
                    detailadded = true;
                }

                if (detailadded)
                {
                    this.Close();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
