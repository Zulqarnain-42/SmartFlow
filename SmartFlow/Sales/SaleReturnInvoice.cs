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
using System.Drawing;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow
{
    public partial class SaleReturnInvoice : Form
    {
        private decimal vatAmount = 0;
        private decimal intializer = 0;
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
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
                DataRow row = _dtinvoice.Rows[0];

                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                invoicecodelbl.Text = row["InvoiceCode"].ToString();
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                codetxtbox.Text = row["CodeAccount"].ToString();
                selectcustomertxtbox.Text = row["AccountSubControlName"].ToString();
                companynametxtbox.Text = row["RefrencePersonName"].ToString();
                mobiletxtbox.Text = row["MobileNo"].ToString();
                salesmantxtbox.Text = row["SalePerson"].ToString();
                customeridlbl.Text = row["ClientID"].ToString();
                invoicereftxtbox.Text = row["InvoiceRefrence"].ToString();

                foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                {
                    int detailsRowIndex = dgvsaleproducts.Rows.Add();
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["codecolumn"].Value = invoiceDetailsRow["MFR"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = invoiceDetailsRow["PricePerMeter"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = invoiceDetailsRow["LengthInMeter"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["itemwisedescription"].Value = invoiceDetailsRow["ItemDescription"];
                    dgvsaleproducts.Rows[detailsRowIndex].Cells["unitnamecolumn"].Value = invoiceDetailsRow["UnitName"];
                }

                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                shippingchargestxtbox.Text = intializer.ToString("N2");
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'SR-%' ORDER BY InvoiceNo DESC";
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
                            unitidlbl.Text = dgvsaleproducts.CurrentRow.Cells[4].Value.ToString();
                            unitnamelbl.Text = dgvsaleproducts.CurrentRow.Cells[5].Value.ToString();
                            unitsalepricelbl.Text = dgvsaleproducts.CurrentRow.Cells[6].Value.ToString();
                            productvatlbl.Text = dgvsaleproducts.CurrentRow.Cells[7].Value.ToString();
                            productdiscountlbl.Text = dgvsaleproducts.CurrentRow.Cells[8].Value.ToString();
                            totalcolumnlbl.Text = dgvsaleproducts.CurrentRow.Cells[9].Value.ToString();
                            warehouseidlbl.Text = dgvsaleproducts.CurrentRow.Cells[10].Value.ToString();
                            itemdescriptionlbl.Text = dgvsaleproducts.CurrentRow.Cells[11].Value.ToString();
                            lengthinmeterlbl.Text = dgvsaleproducts.CurrentRow.Cells[12].Value.ToString();
                            pricepermeterlbl.Text = dgvsaleproducts.CurrentRow.Cells[13].Value.ToString();

                            foreach (DataGridViewRow row in dgvsaleproducts.SelectedRows)
                            {
                                if (!row.IsNewRow)
                                {
                                    dgvsaleproducts.Rows.Remove(row);
                                }
                            }
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
                if (openForm == null)
                {
                    CustomerSelectionForm customerSelection = new CustomerSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    customerSelection.FormClosed += delegate
                    {
                        UpdateCustomerTextBox();
                    };

                    CommonFunction.DisposeOnClose(customerSelection);
                    customerSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    productSelectionForm.FormClosed += delegate
                    {
                        UpdateProductTextBox();
                    };
                    CommonFunction.DisposeOnClose(productSelectionForm);
                    productSelectionForm.Show();

                }
                else
                {
                    openForm.BringToFront();
                }
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
                customeridlbl.Text = GlobalVariables.customeridglobal.ToString();
                codetxtbox.Text = GlobalVariables.customercodeglobal.ToString();
                selectcustomertxtbox.Text = GlobalVariables.customernameglobal.ToString();
                companynametxtbox.Text = GlobalVariables.customercompanyname.ToString();
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
            CommonFunction.CalculateTotalVatColumn(6,dgvsaleproducts, totalvattxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvsaleproducts, totaldiscounttxtbox);
            CommonFunction.CalculateTotalColumn(9, dgvsaleproducts, nettotaltxtbox);
        }
        private void dgvsaleproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(6, dgvsaleproducts, totalvattxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvsaleproducts, totaldiscounttxtbox);
            CommonFunction.CalculateTotalColumn(9, dgvsaleproducts, nettotaltxtbox);
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
        private void savebtn_Click(object sender, EventArgs e)
        {
            bool detailadded = false;
            try
            {
                string invoiceNo = string.Empty;
                if (savebtn.Text == "UPDATE")
                {
                    invoiceNo = invoicenotxtbox.Text;
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int customerId = Convert.ToInt32(customeridlbl.Text);
                    string customerCode = codetxtbox.Text;
                    string customerName = selectcustomertxtbox.Text;
                    string customerRefrence = companynametxtbox.Text;
                    string mobile = mobiletxtbox.Text;
                    string salesPersonName = salesmantxtbox.Text;
                    float nettotal = float.Parse(nettotaltxtbox.Text);
                    float totalVat = float.Parse(totalvattxtbox.Text);
                    float totalDiscount = float.Parse(totaldiscounttxtbox.Text);
                    string invoiceCode = invoicecodelbl.Text;
                    float shippingCharges = float.TryParse(shippingchargestxtbox.Text, out float result) ? result : 0;

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
                        { "ClientName", customerName },
                        { "NetTotal", nettotal },
                        { "TotalVat", totalVat },
                        { "TotalDiscount", totalDiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "SalePerson", salesPersonName },
                        { "InvoiceRefrence", invoicereftxtbox.Text }
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
                    string customerrefrence = companynametxtbox.Text;
                    string mobile = mobiletxtbox.Text;
                    string salespersonname = salesmantxtbox.Text;
                    float nettotal = float.Parse(nettotaltxtbox.Text);
                    float totalvat = float.Parse(totalvattxtbox.Text);
                    float totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                    string invoicecode = Guid.NewGuid().ToString();
                    float shippingCharges = float.TryParse(shippingchargestxtbox.Text, out float result) ? result : 0;

                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "invoicedate", invoiceDate },
                        { "ClientID", customerid },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", nettotal },
                        { "ClientName", customername },
                        { "TotalVat", totalvat },
                        { "TotalDiscount", totaldiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "SalePerson", salespersonname },
                        { "InvoiceRefrence", invoicereftxtbox.Text }
                    };

                    bool resultdata = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                    if (resultdata)
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
                            string itemwisedescription = row.Cells["itemwisedescription"].Value.ToString();
                            float pricepermeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                            float lengthinmeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());

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
                                { "AddInventory", true },
                                { "Warehouseid", warehouseid },
                                { "ItemDescription", itemwisedescription },
                                { "PricePerMeter", pricepermeter },
                                { "LengthInMeter", lengthinmeter },
                                { "MinusInventory", false }
                            };

                            detailadded = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);

                        }
                        detailadded = true;
                    }
                }

                if (detailadded)
                {
                    SaleReturnView saleReturnInvoice = new SaleReturnView(invoiceNo);
                    saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(saleReturnInvoice);
                    saleReturnInvoice.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool detailadded = false;
            InsertBackUpData(invoiceNo, invoiceCode);
            DeleteInvoiceDetail(invoiceNo);
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
                string itemwisedescription = row.Cells["itemwisedescription"].Value.ToString();
                float pricepermeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                float lengthinmeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());

                string subtable = "InvoiceDetailsTable";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoiceCode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "UnitSalePrice", unitprice },
                    { "ProductName", productname },
                    { "MFR", mfr },
                    { "ItemWiseDiscount", discount },
                    { "ItemWiseVAT", vat },
                    { "ItemTotal", total },
                    { "Unitid", unitid },
                    { "AddInventory", true },
                    { "Warehouseid", warehouseid },
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", false }
                };

                detailadded = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);


            }
            if (detailadded)
            {
                SaleReturnView saleReturnInvoice = new SaleReturnView(invoiceNo);
                saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
                CommonFunction.DisposeOnClose(saleReturnInvoice);
                saleReturnInvoice.Show();
                this.Close();
            }
        }

        private void InsertBackUpData(string invoiceNo, string invoicecode)
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
                string itemwisedescription = row.Cells["itemwisedescription"].Value.ToString();
                float pricepermeter = float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                float lengthinmeter = float.Parse(row.Cells["pricepermetercolumn"].Value.ToString());

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
                    { "AddInventory", true },
                    { "Warehouseid", warehouseid },
                    { "ItemDescription", itemwisedescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "MinusInventory", false }                };

                DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            SaleReturnInvoice saleReturnInvoice = new SaleReturnInvoice();
            saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
            CommonFunction.DisposeOnClose(saleReturnInvoice);
            saleReturnInvoice.Show();
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

        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };
                        productSelectionForm.FormClosed += delegate
                        {
                            UpdateProductTextBox();
                        };
                        CommonFunction.DisposeOnClose(productSelectionForm);
                        productSelectionForm.Show();

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
            // Allow control keys like Backspace, and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits, and a single dot or negative sign
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Allow only one dot
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
            {
                string mfr = mfrtxtbox.Text;
                string productname = selectproducttxtbox.Text;
                int productid = Convert.ToInt32(productidlbl.Text);
                int qty = Convert.ToInt32(qtytxtbox.Text);
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
                    dgvsaleproducts.Rows.Add(mfr, productid, productname, qty, unitname,unitprice,
                        vatamount.ToString("N2"), discount.ToString("N2"), unitid, finalitemwise,warehouseid,priceinmeter,lengthinmeterproduct, 
                        itemwisedescription);
                }

                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                GlobalVariables.unitidglobal = 0;
                GlobalVariables.productitemwisevatamount = 0;
                GlobalVariables.productdiscountamountitemwise = 0;
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                GlobalVariables.availabilitystatus = null;
                GlobalVariables.warehouseidglobal = 0;
                GlobalVariables.productitemwisedescriptiongloabl = string.Empty;
                GlobalVariables.productpriceglobal = 0;
                GlobalVariables.productinmeterprice = 0;
                GlobalVariables.productinmeterlength = 0;
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                GlobalVariables.unitnameglobal = string.Empty;
                GlobalVariables.unitidglobal = 0;
                GlobalVariables.productdiscountamountitemwise = 0;
                GlobalVariables.productitemwisevatamount = 0;
                selectproducttxtbox.Focus();
            }
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

        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            int itemqty = Convert.ToInt32(qtytxtbox.Text);
            if (itemqty > 0)
            {
                string getwarehousedata = "SELECT WarehouseID,Name FROM WarehouseTable";
                DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                if (warehousedata != null)
                {
                    if (warehousedata.Rows.Count > 0)
                    {
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        warehouseSelection.FormClosed += WarehouseSelection_FormClosed;

                        CommonFunction.DisposeOnClose(warehouseSelection);
                        warehouseSelection.ShowDialog();
                    }
                }
            }
        }

        private void WarehouseSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((WarehouseSelection)sender);

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
        }

        private void dgvsaleproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(6, dgvsaleproducts, totalvattxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvsaleproducts, totaldiscounttxtbox);
            CommonFunction.CalculateTotalColumn(9, dgvsaleproducts, nettotaltxtbox);
        }
    }
}
