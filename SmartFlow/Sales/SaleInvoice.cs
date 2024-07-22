using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class SaleInvoice : Form
    {
        private decimal vatAmount = 0;
        private int invoiceCounter = 1;
        public SaleInvoice()
        {
            InitializeComponent();
        }
        private void SaleInvoice_Load(object sender, EventArgs e)
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
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{sequentialPart}";

                    return newInvoiceNumber;
                    // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{nextSequentialNumber:D5}";
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'DE-%' ORDER BY InvoiceNo DESC";
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
        private void SaleInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }

            if(e.Control && e.KeyCode == Keys.Q)
            {
                SearchQuotationForm searchQuotationForm = new SearchQuotationForm();
                searchQuotationForm.ShowDialog();
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
                        if(dgvsaleproducts.SelectedRows.Count == 1)
                        {
                            mfrtxtbox.Text = dgvsaleproducts.CurrentRow.Cells[0].Value.ToString();
                            selectproducttxtbox.Text = dgvsaleproducts.CurrentRow.Cells[1].Value.ToString();
                            qtytxtbox.Text = dgvsaleproducts.CurrentRow.Cells[3].Value.ToString();
                            pricetxtbox.Text = dgvsaleproducts.CurrentRow.Cells[4].Value.ToString();
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
            if (openForm == null)
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
                ProductSelectionForm productSelection = new ProductSelectionForm();
                productSelection.ShowDialog();
                UpdateProductTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void SaleInvoice_FormClosing(object sender, FormClosingEventArgs e)
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
            if (selectcustomertxtbox.Text.Trim().Length > 0) { return true; }
            if (salemantxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvsaleproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
        private void dgvsaleproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalVatColumn(5);
            CalculateTotalColumn(7);
        }
        private void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalVatColumn(5);
            CalculateTotalColumn(7);
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
            if (GlobalVariables.customeridglobal > 0 && GlobalVariables.customercodeglobal != null && GlobalVariables.customernameglobal != null &&
               GlobalVariables.customermobileglobal != null)
            {
                customeridlbl.Text = GlobalVariables.customeridglobal.ToString();
                accountcodetxtbox.Text = GlobalVariables.customercodeglobal.ToString();
                selectcustomertxtbox.Text = GlobalVariables.customernameglobal.ToString();
                reftxtbox.Text = GlobalVariables.customerrefrencegloba.ToString();
                mobiletxtbox.Text = GlobalVariables.customermobileglobal.ToString();
            }

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

            totalvattxtbox.Text = totalvat.ToString("N2");
        }
        private void salemantxtbox_MouseClick(object sender, MouseEventArgs e)
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
            if (GlobalVariables.salespersonidglobal > 0 && GlobalVariables.salespersonnameglobal != null)
            {
                salespersonidlbl.Text = GlobalVariables.salespersonidglobal.ToString();
                salemantxtbox.Text = GlobalVariables.salespersonnameglobal;
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
        private void selectcustomertxtbox_Leave(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
            if(openForm == null)
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
        private void saletypetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SaleTypeSelection));
            if (openForm == null)
            {
                SaleTypeSelection saleTypeSelection = new SaleTypeSelection();
                saleTypeSelection.ShowDialog();
                UpdateSaleTypeInfo();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateSaleTypeInfo()
        {
            if (GlobalVariables.saletypenameglobal != null && GlobalVariables.saletypeidglobal > 0)
            {
                saletypetxtbox.Text = GlobalVariables.saletypenameglobal.ToString();
                saletypeidlbl.Text = GlobalVariables.saletypeidglobal.ToString();
            }
        }
        private void saletypetxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SaleTypeSelection));
                if (openForm == null)
                {
                    SaleTypeSelection saleTypeSelection1 = new SaleTypeSelection();
                    saleTypeSelection1.ShowDialog();
                    UpdateSaleTypeInfo();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void narationtxtbox_Leave(object sender, EventArgs e)
        {
            InvoiceNoteForm noteForm = new InvoiceNoteForm();
            noteForm.ShowDialog();
        }
        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text) &&
                    !string.IsNullOrEmpty(pricetxtbox.Text) && !string.IsNullOrWhiteSpace(pricetxtbox.Text))
                {
                    int itemqty = Convert.ToInt32(qtytxtbox.Text);
                    float itemprice = float.Parse(pricetxtbox.Text);
                    float totalamount = itemqty * itemprice;
                    if (GlobalVariables.saletypeistaxable)
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
                    string warehouseid = warehouseidlbl.Text;
                    string itemwisedescription = itemwisedescriptionlbl.Text;
                    string productname = selectproducttxtbox.Text;
                    string productid = productidlbl.Text;
                    string qty = qtytxtbox.Text;
                    string price = pricetxtbox.Text;
                    string unitid = GlobalVariables.unitidglobal.ToString();
                    decimal vatamount = GlobalVariables.productitemwisevatamount;
                    if (vatamount > 0)
                    {
                        totalvattxtbox.Visible = true;
                        totalvatlbl.Visible = true;
                    }
                    decimal discount = GlobalVariables.productdiscountamountitemwise;
                    if (discount > 0)
                    {
                        totaldiscounttxtbox.Visible = true;
                        totaldiscountlbl.Visible = true;
                    }
                    string finalitemwise = GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("N2");
                    int quantity = Convert.ToInt32(qty);

                    bool productExists = false;
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString())
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
                        dgvsaleproducts.Rows.Add(mfr, warehouseid, itemwisedescription, productid, productname, qty, unitid, unitid, price, vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise);
                    }

                    mfrtxtbox.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                    productidlbl.Text = string.Empty;
                    qtytxtbox.Text = string.Empty;
                    pricetxtbox.Text = string.Empty;
                    GlobalVariables.unitidglobal = 0;
                    GlobalVariables.productitemwisevatamount = 0;
                    GlobalVariables.productdiscountamountitemwise = 0;
                    GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                    selectproducttxtbox.Focus();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void LoadDataQuotation(DataTable quotationData)
        {
            try
            {
                if (quotationData.Rows.Count > 0)
                {
                    DataRow dataRow = quotationData.Rows[0];

                    string invoiceNo = dataRow["InvoiceNo"].ToString();
                    string invoiceCode = dataRow["InvoiceCode"].ToString();

                    string quotationDetails = string.Format("SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity,UnitSalePrice,ItemSerialNo,ProductName," +
                        "MFR,ItemWiseDiscount,ItemWiseVAT,ItemDescription,Warehouseid,PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice," +
                        "PurchaseItemSalePrice,SystemSerialNo,ItemTotal,Unitid FROM InvoiceDetailsTable WHERE InvoiceNo = '" + invoiceNo + "' AND Invoicecode = '" + invoiceCode + "'");

                    DataTable quotationDetail = DatabaseAccess.Retrive(quotationDetails);
                    if(quotationDetail!=null && quotationDetail.Rows.Count > 0)
                    {
                        accountcodetxtbox.Text = dataRow["CustomerCode"].ToString();
                        selectcustomertxtbox.Text = dataRow["ClientName"].ToString();
                        mobiletxtbox.Text = dataRow["ContactNo"].ToString();
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
    }
}
