using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Sales.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow
{
    public partial class SaleQuotationInvoice : Form
    {
        private decimal price = 0;
        private decimal qty = 0;
        private decimal total = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private int _dragRowIndex = -1;
        private DataTable _dtinvoicedetails;

        public SaleQuotationInvoice()
        {
            InitializeComponent();
        }
        public SaleQuotationInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        private void SaleQuotationInvoice_Load(object sender, EventArgs e)
        {
            if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
            {
                DataRow row = _dtinvoice.Rows[0];

                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                invoicecodelbl.Text = row["InvoiceCode"].ToString();
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                codetxtbox.Text = row["CodeAccount"].ToString();
                selectcustomertxtbox.Text = row["AccountSubControlName"].ToString();
                companytxtbox.Text = row["CompanyName"].ToString();
                mobiletxtbox.Text = row["MobileNo"].ToString();
                customeridlbl.Text = row["ClientID"].ToString();
                totalvattxtbox.Text = row["TotalVat"].ToString();
                totaldiscounttxtbox.Text = row["TotalDiscount"].ToString();
                validuntiltxtbox.Text = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
                salesmantxtbox.Text = row["SalePerson"].ToString();
                shippingchargestxtbox.Text = row["FreightShippingCharges"].ToString();
                

                foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                {
                    int detailsRowIndex = dgvsaleproducts.Rows.Add();
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["codecolumn"].Value = invoiceDetailsRow["MFR"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["availabilitycolumn"].Value = invoiceDetailsRow["ItemAvailability"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["availabilitycolumn"].Value = invoiceDetailsRow["ItemAvailability"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = invoiceDetailsRow["LengthInMeter"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = invoiceDetailsRow["PricePerMeter"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["unitname"].Value = invoiceDetailsRow["UnitName"];
                }

                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                validuntiltxtbox.Text = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
                qtytxtbox.Text = qty.ToString("0");
                nettotaltxtbox.Text = total.ToString("0.00");
                totaldiscounttxtbox.Text = total.ToString("0.00");
                totalvattxtbox.Text = total.ToString("0.00");
                invoicenotxtbox.Text = GenerateNextInvoiceNumber();
                shippingchargestxtbox.Text = total.ToString("N2");
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
                    string invoicepart = "SQ";
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
                    string invoicepart = "SQ";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'SQ-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = DatabaseAccess.Retrive(query);
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void SaleQuotationInvoice_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.C)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.DataSent += currencySelection_DataSent;
                currencySelection.ShowDialog();
            }
        }

        private void currencySelection_DataSent(CurrencyData receivedCurrency)
        {
            // Use the received data (e.g., display it in a label)
            currencylbl.Text = receivedCurrency.Name + (" : ") + receivedCurrency.Symbol;
            currencyidlbl.Text = receivedCurrency.CurrencyId.ToString();
            currencynamelbl.Text = receivedCurrency.Name.ToString();
            currencysymbollbl.Text = receivedCurrency.Symbol.ToString();
            currencystringlbl.Text = receivedCurrency.CurrencyString.ToString();
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
                            productidlbl.Text = dgvsaleproducts.CurrentRow.Cells[1].Value.ToString();
                            selectproducttxtbox.Text = dgvsaleproducts.CurrentRow.Cells[2].Value.ToString();
                            qtytxtbox.Text = dgvsaleproducts.CurrentRow.Cells[3].Value.ToString();
                            availabilitystatuslbl.Text = dgvsaleproducts.CurrentRow.Cells[4].Value.ToString();
                            unitidlbl.Text = dgvsaleproducts.CurrentRow.Cells[5].Value.ToString();
                            unitnamelbl.Text = dgvsaleproducts.CurrentRow.Cells[6].Value.ToString();
                            unitsalepricelbl.Text = dgvsaleproducts.CurrentRow.Cells[7].Value.ToString();
                            productvatlbl.Text = dgvsaleproducts.CurrentRow.Cells[8].Value.ToString();
                            productdiscountlbl.Text = dgvsaleproducts.CurrentRow.Cells[9].Value.ToString();
                            totalcolumnlbl.Text = dgvsaleproducts.CurrentRow.Cells[10].Value.ToString();
                            warehouseidlbl.Text = dgvsaleproducts.CurrentRow.Cells[11].Value.ToString();
                            itemdescriptionlbl.Text = dgvsaleproducts.CurrentRow.Cells[12].Value.ToString();
                            lengthinmeterlbl.Text = dgvsaleproducts.CurrentRow.Cells[13].Value.ToString();
                            pricepermeterlbl.Text = dgvsaleproducts.CurrentRow.Cells[14].Value.ToString();

                            int productid = Convert.ToInt32(dgvsaleproducts.CurrentRow.Cells[1].Value);
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

                            selectproducttxtbox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record");
                    }
                }
                else
                {
                    MessageBox.Show("No Record Available");
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgvsaleproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvsaleproducts.CurrentRow.Cells[3].Value);
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
            if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
                if (openForm == null)
                {
                    CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    customerSelectionForm.FormClosed += delegate
                    {
                        UpdateCustomerTextBox();
                    };
                    CommonFunction.DisposeOnClose(customerSelectionForm);
                    customerSelectionForm.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            } 
        }
        private void UpdateCustomerTextBox()
        {
            if(GlobalVariables.customeridglobal > 0 && GlobalVariables.customercodeglobal != null && GlobalVariables.customernameglobal != null &&
                GlobalVariables.customermobileglobal != null)
            {
                customeridlbl.Text = GlobalVariables.customeridglobal.ToString();
                codetxtbox.Text = GlobalVariables.customercodeglobal.ToString();
                selectcustomertxtbox.Text = GlobalVariables.customernameglobal.ToString();
                companytxtbox.Text = GlobalVariables.customercompanyname.ToString();
                mobiletxtbox.Text = GlobalVariables.customermobileglobal.ToString();
            }
        }
        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    productSelection.FormClosed += delegate
                    {
                        UpdateProductTextBox();
                    };
                    CommonFunction.DisposeOnClose(productSelection);
                    productSelection.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateProductTextBox()
        {
            if(GlobalVariables.productnameglobal != null && GlobalVariables.productidglobal > 0 && GlobalVariables.productmfrglobal != null)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal.ToString();
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
                mfrtxtbox.Text = GlobalVariables.productmfrglobal.ToString();
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
            CommonFunction.CalculateTotalVatColumn(8, dgvsaleproducts, totalvattxtbox);
            CommonFunction.CalculateTotalColumn(10, dgvsaleproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalDiscountColumn(9, dgvsaleproducts, totaldiscounttxtbox);
        }
        private void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(8, dgvsaleproducts, totalvattxtbox);
            CommonFunction.CalculateTotalColumn(10, dgvsaleproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalDiscountColumn(9, dgvsaleproducts, totaldiscounttxtbox);
        }
        private void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectcustomertxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
                    if (openForm == null)
                    {
                        CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };
                        customerSelectionForm.FormClosed += delegate
                        {
                            UpdateCustomerTextBox();
                        };
                        CommonFunction.DisposeOnClose(customerSelectionForm);
                        customerSelectionForm.Show();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }
        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is not a digit and not a control character (e.g., backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }
        private void qtytxtbox_TextChanged(object sender, EventArgs e)
        {
            // Ensure that the text remains numeric after any changes
            if (System.Text.RegularExpressions.Regex.IsMatch(qtytxtbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                qtytxtbox.Text = qtytxtbox.Text.Remove(qtytxtbox.Text.Length - 1);
            }
        }
        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelection = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };
                        productSelection.FormClosed += delegate
                        {
                            UpdateProductTextBox();
                        };
                        CommonFunction.DisposeOnClose(productSelection);
                        productSelection.Show();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            bool detailadded = false;
            try
            {
                errorProvider.Clear();
                if (selectcustomertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectcustomertxtbox,"Please Select Customer.");
                    selectcustomertxtbox.Focus();
                    return;
                }

                string invoiceNo = string.Empty;
                if (savebtn.Text == "UPDATE")
                {
                    invoiceNo = invoicenotxtbox.Text;
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int customerId = Convert.ToInt32(customeridlbl.Text);
                    string customercode = codetxtbox.Text;
                    string customername = selectcustomertxtbox.Text;
                    string customerrefrence = companytxtbox.Text;
                    string mobile = mobiletxtbox.Text;
                    string salespersonname = salesmantxtbox.Text;
                    DateTime quotationvalidity = DateTime.Parse(validuntiltxtbox.Text);
                    float nettotal = float.Parse(nettotaltxtbox.Text);
                    float totalvat = float.Parse(totalvattxtbox.Text);
                    float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                    float shippingcharges = float.Parse(shippingchargestxtbox.Text);
                    string invoiceCode = invoicecodelbl.Text;
                    string tableName = "InvoiceTable";

                    string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "invoicedate", invoiceDate },
                        { "ClientID", customerId },
                        { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "InvoiceCode", invoiceCode },
                        { "ClientName", customername },
                        { "NetTotal", nettotal },
                        { "TotalVat", totalvat },
                        { "TotalDiscount", totaldiscount },
                        { "FreightShippingCharges", shippingcharges },
                        { "QuotationValidUntill", quotationvalidity },
                        { "SalePerson", salespersonname }
                    };

                    bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceNo, invoiceCode);
                    }
                }
                else
                {
                    invoiceNo = CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int customerid = Convert.ToInt32(customeridlbl.Text);
                    string customercode = codetxtbox.Text;
                    string customername = selectcustomertxtbox.Text;
                    string customerrefrence = companytxtbox.Text;
                    string mobile = mobiletxtbox.Text;
                    string salespersonname = salesmantxtbox.Text;
                    DateTime quotationvalidity = DateTime.Parse(validuntiltxtbox.Text);
                    float nettotal = float.Parse(nettotaltxtbox.Text);
                    float totalvat = float.Parse(totalvattxtbox.Text);
                    float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                    float shippingcharges = float.Parse(shippingchargestxtbox.Text.ToString());
                    string invoicecode = Guid.NewGuid().ToString();
                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "invoicedate", invoiceDate },
                        { "ClientID", customerid },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", nettotal },
                        { "ClientName", customername },
                        { "TotalVat", totalvat },
                        { "TotalDiscount", totaldiscount },
                        { "FreightShippingCharges", shippingcharges },
                        { "QuotationValidUntill", quotationvalidity },
                        { "SalePerson", salespersonname }
                    };

                    bool result = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

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
                            float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                            int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                            int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                            string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                            float pricepermeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                            float lengthinmeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                            string availabilitystatus = row.Cells["availabilitycolumn"].Value.ToString();

                            string subtable = "InvoiceDetailsTable";
                            var subColumnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceNo },
                                { "Invoicecode", invoicecode },
                                { "Productid", productid },
                                { "Quantity", quantity },
                                { "UnitSalePrice", unitprice },
                                { "ProductName", productname },
                                { "MFR", mfr },
                                { "ItemWiseDiscount", discount },
                                { "ItemWiseVAT", vat },
                                { "ItemTotal", total },
                                { "Unitid", unitid },
                                { "AddInventory", false },
                                { "Warehouseid", warehouseid },
                                { "ItemDescription", itemwisedescription },
                                { "PricePerMeter", pricepermeter },
                                { "LengthInMeter", lengthinmeter },
                                { "MinusInventory", false },
                                { "ItemAvailability", availabilitystatus }
                            };

                            detailadded = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
                        }
                        detailadded = true;
                    }
                }

                if (detailadded)
                {
                    SaleQuotationView saleQuotationInvoiceview = new SaleQuotationView(invoiceNo);
                    saleQuotationInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(saleQuotationInvoiceview);
                    saleQuotationInvoiceview.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void UpdateInvoiceDetailsData(string invoiceNo,string invoiceCode)
        {
            bool detailadded = false;
            InsertBackUpData(invoiceNo, invoiceCode);
            DeleteInvoiceDetail(invoiceNo);
            foreach (DataGridViewRow row in dgvsaleproducts.Rows)
            {
                if (row.IsNewRow) { continue; }
                
                int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                string invoicecode = invoicecodelbl.Text;
                int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                float unitprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                string productname = row.Cells["productnamecolumn"].Value.ToString();
                string mfr = row.Cells["codecolumn"].Value.ToString();
                float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                float pricepermeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                float lengthinmeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                string availabilitystatus = row.Cells["availabilitycolumn"].Value.ToString();
                
                string subtable = "InvoiceDetailsTable";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoicecode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "UnitSalePrice", unitprice },
                    { "ProductName", productname },
                    { "MFR", mfr },
                    { "ItemWiseDiscount", discount },
                    { "ItemWiseVAT", vat },
                    { "ItemTotal", total },
                    { "Unitid", unitid },
                    { "AddInventory", false },
                    { "Warehouseid", warehouseid },
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", false },
                    { "ItemAvailability", availabilitystatus }
                };
                
                detailadded = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
            }
            if (detailadded)
            {
                SaleQuotationView saleQuotationInvoiceview = new SaleQuotationView(invoiceNo);
                saleQuotationInvoiceview.MdiParent = Application.OpenForms["Dashboard"];
                CommonFunction.DisposeOnClose(saleQuotationInvoiceview);
                saleQuotationInvoiceview.Show();
                this.Close();
            }
        }

        private void InsertBackUpData(string invoiceNo,string invoicecode)
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
                float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                string itemwisedescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                float pricepermeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                float lengthinmeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                string availabilitystatus = row.Cells["availabilitycolumn"].Value.ToString();

                string subtable = "InvoiceDetailsTableBackUp";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoicecode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "UnitSalePrice", unitprice },
                    { "ProductName", productname },
                    { "MFR", mfr },
                    { "ItemWiseDiscount", discount },
                    { "ItemWiseVAT", vat },
                    { "ItemTotal", total },
                    { "Unitid", unitid },
                    { "AddInventory", false },
                    { "Warehouseid", warehouseid },
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", false },
                    { "ItemAvailability", availabilitystatus }
                };

                DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
            }
        }
        private void DeleteInvoiceDetail(string invoiceNo)
        {
            try
            {
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                DatabaseAccess.ExecuteQuery(tableName, "DELETE", columnData, whereClause);

            }
            catch (Exception ex) { throw ex; }
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
            {
                string mfr = mfrtxtbox.Text;
                string productid = productidlbl.Text;
                string productname = selectproducttxtbox.Text;
                string qty = qtytxtbox.Text;
                int unitid = Convert.ToInt32(unitidlbl.Text);
                string unitname = unitnamelbl.Text;
                decimal vatamount = decimal.Parse(productvatlbl.Text);
                decimal discount = decimal.Parse(productdiscountlbl.Text);
                float unitprice = float.Parse(unitsalepricelbl.Text);
                decimal finalitemwise = decimal.Parse(totalcolumnlbl.Text);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
                string itemwisedescription = itemdescriptionlbl.Text;
                decimal lengthinmeterproduct = decimal.Parse(lengthinmeterlbl.Text);
                decimal priceinmeter = decimal.Parse(pricepermeterlbl.Text);
                string availability = availabilitystatuslbl.Text;

                bool productExists = false;
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString() &&
                            float.Parse(row.Cells["pricecolumn"].Value.ToString()) == unitprice)
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
                    dgvsaleproducts.Rows.Add(mfr, productid, productname, qty, availability, unitid, unitname, unitprice,
                        vatamount.ToString("N2"), discount.ToString("N2"), finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter);
                }

                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                GlobalVariables.unitidglobal = 0;
                GlobalVariables.productpriceglobal = 0;
                GlobalVariables.productitemwisevatamount = 0;
                GlobalVariables.productdiscountamountitemwise = 0;
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                GlobalVariables.warehouseidglobal = 0;
                GlobalVariables.productitemwisedescriptiongloabl = string.Empty;
                GlobalVariables.productinmeterlength = 0;
                GlobalVariables.productinmeterprice = 0;
                selectproducttxtbox.Focus();
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice();
            saleQuotationInvoice.MdiParent = Application.OpenForms["Dashboard"];
            CommonFunction.DisposeOnClose(saleQuotationInvoice);
            saleQuotationInvoice.Show();
        }

        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
                {
                    int itemqty = Convert.ToInt32(qtytxtbox.Text);
                    if (itemqty > 0)
                    {
                        string productid = productidlbl.Text;
                        SqlParameter param1 = new SqlParameter("@ProductID", SqlDbType.Int)
                        {
                            Value = string.IsNullOrEmpty(productid) ? (object)DBNull.Value : Convert.ToInt32(productid)
                        };
                        DataTable result = DatabaseAccess.ExecuteStoredProcedure("GetTotalQuantityAndWarehouse", param1);

                        bool shouldOpenForm = false;
                        if (result != null && result.Rows.Count > 0)
                        {
                            foreach (DataRow row in result.Rows)
                            {
                                // Assuming the column name for quantity is "TotalQuantity"
                                int quantity = row["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(row["TotalQuantity"]) : 0;

                                // Check if the quantity is greater than zero
                                if (quantity > 0)
                                {
                                    shouldOpenForm = true;
                                    break; // No need to check further rows, form will be opened
                                }
                            }

                            if (shouldOpenForm)
                            {
                                // Create the WarehouseQty form
                                WarehouseQty warehouseQty = new WarehouseQty(result)
                                {
                                    WindowState = FormWindowState.Normal,
                                    StartPosition = FormStartPosition.CenterParent,
                                };

                                // Event to handle closing the current form and opening the new one
                                warehouseQty.FormClosed += WarehouseQty_FormClosed;

                                // Show the WarehouseQty form
                                warehouseQty.ShowDialog();
                            }
                            else
                            {
                                ItemAvailability itemAvailability = new ItemAvailability()
                                {
                                    WindowState = FormWindowState.Normal,
                                    StartPosition = FormStartPosition.CenterParent,
                                };

                                itemAvailability.FormClosed += ItemAvailability_FormClosed;
                                itemAvailability.ShowDialog();
                            }
                        }


                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Event handler for when WarehouseQty form is closed
        private void WarehouseQty_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((WarehouseQty)sender);

                // Create and show VATForm after WarehouseQty is closed
                VATForm vATForm = new VATForm(Convert.ToInt32(qtytxtbox.Text), false)
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                vATForm.FormClosed += delegate
                {
                    UpdateProductData();
                };

                // Apply DisposeOnClose to VATForm
                CommonFunction.DisposeOnClose(vATForm);
                vATForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemAvailability_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((ItemAvailability)sender);

                // Create and show VATForm after WarehouseQty is closed
                VATForm vATForm = new VATForm(Convert.ToInt32(qtytxtbox.Text), false)
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                vATForm.FormClosed += delegate
                {
                    UpdateProductData();
                };

                // Apply DisposeOnClose to VATForm
                CommonFunction.DisposeOnClose(vATForm);
                vATForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProductData()
        {
            warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
            itemdescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl.ToString();
            unitsalepricelbl.Text = GlobalVariables.productpriceglobal.ToString();
            pricepermeterlbl.Text = GlobalVariables.productinmeterprice.ToString();
            lengthinmeterlbl.Text = GlobalVariables.productinmeterlength.ToString();
            totalcolumnlbl.Text = GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString();
            unitnamelbl.Text = GlobalVariables.unitnameglobal.ToString();
            unitidlbl.Text = GlobalVariables.unitidglobal.ToString();
            productdiscountlbl.Text = GlobalVariables.productdiscountamountitemwise.ToString();
            productvatlbl.Text = GlobalVariables.productitemwisevatamount.ToString();
            availabilitystatuslbl.Text = GlobalVariables.availabilitystatus.ToString();
        }

        private void dgvsaleproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(8,dgvsaleproducts,totalvattxtbox);
            CommonFunction.CalculateTotalColumn(10, dgvsaleproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalDiscountColumn(9, dgvsaleproducts, totaldiscounttxtbox);
        }

        private void removevatchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (removevatchkbox.Checked)
            {
                // Iterate through the DataGridView rows
                foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                {
                    if (row.Cells["vatcolumn"] != null && row.Cells["totalcolumn"] != null) // Ensure columns exist
                    {
                        // Get the current VAT and Total
                        decimal vat = row.Cells["vatcolumn"].Value != null ? Convert.ToDecimal(row.Cells["vatcolumn"].Value) : 0;
                        decimal total = row.Cells["totalcolumn"].Value != null ? Convert.ToDecimal(row.Cells["totalcolumn"].Value) : 0;

                        // Remove VAT from the Total
                        total -= vat;

                        // Update VAT and Total columns
                        row.Cells["vatcolumn"].Value = 0; // Set VAT to 0
                        row.Cells["totalcolumn"].Value = total; // Update Total
                    }
                }
            }
        }
    }
}
