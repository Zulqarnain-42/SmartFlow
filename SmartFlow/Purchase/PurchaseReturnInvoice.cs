using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow
{
    public partial class PurchaseReturnInvoice : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int accountsubcontrolid = 706;
        private string accountName = "Purchases";

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
        private async void PurchaseReturnInvoice_Load(object sender, EventArgs e)
        {
            if(_dtinvoice!=null && _dtinvoice.Rows.Count>0 || _dtinvoicedetails!=null && _dtinvoicedetails.Rows.Count > 0)
            {
                DataRow row = _dtinvoice.Rows[0];
                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                suppliercodetxtbox.Text = row["CodeAccount"].ToString();
                invoicedatetxtbox.Text = row["invoicedate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                selectsuppliertxtbox.Text = row["ClientName"].ToString();
                supplieridlbl.Text = row["ClientID"].ToString();
                invoicecodelbl.Text = row["InvoiceCode"].ToString();
                invoicereftxtbox.Text = row["InvoiceRefrence"].ToString();
                companytxtbox.Text = row["CompanyName"].ToString();
                shippingchargestxtbox.Text = row["FreightShippingCharges"].ToString();
                currencyidlbl.Text = row["Currencyid"].ToString();
                currencynamelbl.Text = row["CurrencyName"].ToString();
                currencysymbollbl.Text = row["CurrencySymbol"].ToString();
                currencyconversionratelbl.Text = row["ConversionRate"].ToString();
                currencylbl.Text = row["CurrencyName"].ToString() + (" : ") + row["CurrencySymbol"].ToString();
                AddGridData(_dtinvoicedetails);
                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
            }
        }

        private void AddGridData(DataTable datainvoicedetails)
        {
            foreach (DataRow invoiceDetailsRow in datainvoicedetails.Rows)
            {
                int detailsRowIndex = dgvpurchaseproducts.Rows.Add();
               
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitname"].Value = invoiceDetailsRow["UnitName"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = invoiceDetailsRow["LengthInMeter"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = invoiceDetailsRow["PricePerMeter"];
                dgvpurchaseproducts.Rows[detailsRowIndex].Cells["codecolumn"].Value = invoiceDetailsRow["MFR"];
            }
        }

        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
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
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PR-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
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
        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
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
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }
        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells["productid"].Value);
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

            if (e.KeyCode == Keys.E)
            {
                HandleRowSelectionAsync();
            }
        }
        private async void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    supplierSelection.SupplierDataSelected += UpdateSupplierTextBox;

                    CommonFunction.DisposeOnClose(supplierSelection);
                    supplierSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private async void UpdateSupplierTextBox(object sender, SupplierData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int supplierId = e.SupplierId;
                    string supplierName = e.SupplierName;
                    string supplierCode = e.SupplierCode;
                    string companyName = e.SupplierCompanyName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        suppliercodetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }

        private async void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
                    if (openForm == null)
                    {
                        SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        supplierSelection.SupplierDataSelected += UpdateSupplierTextBox;

                        CommonFunction.DisposeOnClose(supplierSelection);
                        supplierSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    productSelection.ProductDataSelected += UpdateProductTextBox;

                    CommonFunction.DisposeOnClose(productSelection);
                    productSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private async void UpdateProductTextBox(object sender, ProductData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int productid = e.ProductId;
                    string productname = e.ProductName;
                    string productmfr = e.ProductMfr;
                    string productupc = e.ProductUPC;
                    float productprice = e.ProductPrice;
                    string productbarcode = e.ProductBarcode;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        productidlbl.Text = productid.ToString();
                        mfrtxtbox.Text = productmfr.ToString();
                        selectproducttxtbox.Text = productname.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        productSelectionForm.ProductDataSelected += UpdateProductTextBox;

                        CommonFunction.DisposeOnClose(productSelectionForm);
                        productSelectionForm.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private async void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
        }

        private async void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(currencyidlbl.Text) && currencyidlbl.Text != "currencyidlbl"
                    && !string.IsNullOrEmpty(currencynamelbl.Text) && currencynamelbl.Text != "currencynamelbl"
                    && !string.IsNullOrEmpty(currencysymbollbl.Text) && currencysymbollbl.Text != "currencysymbollbl"
                    && !string.IsNullOrEmpty(currencyconversionratelbl.Text) && currencyconversionratelbl.Text != "currencyconversionratelbl")
                {
                    string invoiceno = string.Empty;
                    errorProvider.Clear();
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

                    // Define the custom date format and UK culture
                    string format = "dd/MM/yyyy";
                    var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture

                    // Parse startDate and endDate from the textboxes using the custom format
                    DateTime invoiceDate;

                    // Try parsing the dates from the textboxes with the exact format
                    if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                    {
                        // Date parsing was successful
                        Console.WriteLine($"Start Date: {invoiceDate}");
                    }
                    else
                    {
                        invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    }

                    if (savebtn.Text == "UPDATE")
                    {
                        string invoicecode = invoicecodelbl.Text;
                        invoiceno = invoicenotxtbox.Text;
                        await UpdatePurchaseReturn(invoiceno,invoiceDate,invoicecode);
                    }
                    else
                    {
                        string invoicecode = Guid.NewGuid().ToString();
                        invoiceno = await CheckInvoiceBeforeInsert();
                        await AddPurchaseReturn(invoiceno, invoiceDate, invoicecode);
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency!");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task AddPurchaseReturn(string invoiceno,DateTime invoiceDate,string invoicecode)
        {
            bool insertprod = false;
            int supplierid = Convert.ToInt32(supplieridlbl.Text.ToString());
            string suppliercode = suppliercodetxtbox.Text;
            string supplierName = selectsuppliertxtbox.Text;
            string invoiceRef = invoicereftxtbox.Text;
            float netTotal = float.Parse(nettotaltxtbox.Text.ToString());
            float netVat = float.Parse(totalvattxtbox.Text.ToString());
            float netDiscount = float.Parse(totaldiscounttxtbox.Text.ToString());
            float shippingCharges = string.IsNullOrWhiteSpace(shippingchargestxtbox.Text) ? 0 : float.Parse(shippingchargestxtbox.Text);
            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencystring = currencystringlbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceno },
                { "invoicedate", invoiceDate },
                { "ClientID", supplierid },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek },
                { "InvoiceCode", invoicecode },
                { "NetTotal", netTotal },
                { "ClientName", supplierName },
                { "TotalVat", netVat },
                { "TotalDiscount", netDiscount },
                { "FreightShippingCharges", shippingCharges },
                { "InvoiceRefrence", invoiceRef },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate },
                { "InvoiceType", "Purchase Return" }
            };

            bool insertinvoice = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);

            if (insertinvoice)
            {
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (row.IsNewRow) { continue; }

                    string mfr = row.Cells["codecolumn"].Value == null ? string.Empty : row.Cells["codecolumn"].Value.ToString();
                    int productid = row.Cells["productid"].Value == null ? 0 : Convert.ToInt32(row.Cells["productid"].Value);
                    string productname = row.Cells["productnamecolumn"].Value == null ? string.Empty : row.Cells["productnamecolumn"].Value.ToString();
                    int quantity = row.Cells["qtycolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["qtycolumn"].Value);
                    int unitid = row.Cells["unitidcolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["unitidcolumn"].Value);
                    float saleprice = row.Cells["pricecolumn"].Value == null ? 0f : float.Parse(row.Cells["pricecolumn"].Value.ToString());
                    float discount = row.Cells["discountcolumn"].Value == null ? 0f : float.Parse(row.Cells["discountcolumn"].Value.ToString());
                    float vat = row.Cells["vatcolumn"].Value == null ? 0f : float.Parse(row.Cells["vatcolumn"].Value.ToString());
                    float total = row.Cells["totalcolumn"].Value == null ? 0f : float.Parse(row.Cells["totalcolumn"].Value.ToString());
                    int warehouseid = row.Cells["warehouseidcolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["warehouseidcolumn"].Value);
                    string itemdescription = row.Cells["itemdescriptioncolumn"].Value == null ? string.Empty : row.Cells["itemdescriptioncolumn"].Value.ToString();
                    decimal lengthinmeter = row.Cells["lengthinmetercolumn"].Value == null ? 0m : decimal.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                    decimal pricepermeter = row.Cells["pricepermetercolumn"].Value == null ? 0m : decimal.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                    float vatpercentage = row.Cells["vatpercentagecolumn"]?.Value == null ? 0f : float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString());

                    string subtable = "InvoiceDetailsTable";
                    var subColumnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "Invoicecode", invoicecode },
                        { "Productid", productid },
                        { "Quantity", quantity },
                        { "ProductName", productname },
                        { "MFR", mfr },
                        { "ItemWiseDiscount", discount },
                        { "ItemWiseVAT", vat },
                        { "Warehouseid", warehouseid },
                        { "ItemTotal", total },
                        { "Unitid", unitid },
                        { "AddInventory", false },
                        { "PricePerMeter", pricepermeter },
                        { "LengthInMeter", lengthinmeter },
                        { "ItemDescription", itemdescription },
                        { "MinusInventory", true },
                        { "UnitSalePrice", saleprice },
                        { "VatCode", vatpercentage }
                    };
                    insertprod = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                }
            }


            if (insertprod)
            {
                ReturnReportView returnReport = new ReturnReportView(invoiceno);
                returnReport.MdiParent = Application.OpenForms["Dashboard"];
                CommonFunction.DisposeOnClose(returnReport);
                returnReport.Show();
                this.Close();
            }
        }

        private async Task UpdatePurchaseReturn(string invoiceno,DateTime invoiceDate,string invoicecode)
        {
            int supplierid = Convert.ToInt32(supplieridlbl.Text.ToString());
            string suppliercode = suppliercodetxtbox.Text;
            string supplierName = selectsuppliertxtbox.Text;
            string invoiceRef = invoicereftxtbox.Text;
            float netTotal = float.Parse(nettotaltxtbox.Text.ToString());
            float netVat = float.Parse(totalvattxtbox.Text.ToString());
            float netDiscount = float.Parse(totaldiscounttxtbox.Text.ToString());
            float shippingCharges = string.IsNullOrWhiteSpace(shippingchargestxtbox.Text) ? 0 : float.Parse(shippingchargestxtbox.Text);
            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencystring = currencystringlbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";
            string whereClause = "InvoiceNo = '" + invoiceno + "'";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceno },
                { "invoicedate", invoiceDate },
                { "ClientID", supplierid },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek },
                { "InvoiceCode", invoicecode },
                { "NetTotal", netTotal },
                { "ClientName", supplierName },
                { "TotalVat", netVat },
                { "TotalDiscount", netDiscount },
                { "FreightShippingCharges", shippingCharges },
                { "InvoiceRefrence", invoiceRef },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate },
                { "InvoiceType", "Purchase Return" }
            };

            bool insertinvoice = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);

            if (insertinvoice)
            {
                bool isAdded = await UpdateInvoiceDetailsData(invoiceno, invoicecode);
                if (isAdded)
                {
                    ReturnReportView returnReport = new ReturnReportView(invoiceno);
                    returnReport.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(returnReport);
                    returnReport.Show();
                    this.Close();
                }
            }
        }

        private async Task<bool> UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            // First, update invoice details
            bool isOldRecord = await UpdateInvoiceDetail(invoiceNo);
            if (!isOldRecord)
            {
                MessageBox.Show("Something is wrong while updating invoice details.");
                return false;
            }

            // List to store insert operations for batch processing (if supported)
            List<Task<bool>> insertTasks = new List<Task<bool>>();
            string subtable = "InvoiceDetailsTable";

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) { continue; }

                // Safe parsing of values
                string mfr = row.Cells["codecolumn"].Value?.ToString() ?? string.Empty;
                int productid = row.Cells["productid"].Value == null ? 0 : Convert.ToInt32(row.Cells["productid"].Value);
                string productname = row.Cells["productnamecolumn"].Value?.ToString() ?? string.Empty;
                int quantity = row.Cells["qtycolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["qtycolumn"].Value);
                int unitid = row.Cells["unitidcolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["unitidcolumn"].Value);
                int warehouseid = row.Cells["warehouseidcolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["warehouseidcolumn"].Value);
                string itemdescription = row.Cells["itemdescriptioncolumn"].Value?.ToString() ?? string.Empty;

                float.TryParse(row.Cells["pricecolumn"].Value?.ToString(), out float saleprice);
                float.TryParse(row.Cells["discountcolumn"].Value?.ToString(), out float discount);
                float.TryParse(row.Cells["vatcolumn"].Value?.ToString(), out float vat);
                float.TryParse(row.Cells["totalcolumn"].Value?.ToString(), out float total);
                float.TryParse(row.Cells["vatpercentagecolumn"]?.Value?.ToString(), out float vatpercentage);
                decimal.TryParse(row.Cells["lengthinmetercolumn"].Value?.ToString(), out decimal lengthinmeter);
                decimal.TryParse(row.Cells["pricepermetercolumn"].Value?.ToString(), out decimal pricepermeter);

                // Prepare column data
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoiceCode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "ProductName", productname },
                    { "MFR", mfr },
                    { "ItemWiseDiscount", discount },
                    { "ItemWiseVAT", vat },
                    { "Warehouseid", warehouseid },
                    { "ItemTotal", total },
                    { "Unitid", unitid },
                    { "AddInventory", false },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "ItemDescription", itemdescription },
                    { "MinusInventory", true },
                    { "UnitSalePrice", saleprice },
                    { "VatCode", vatpercentage }
                };

                // Store the task in the list
                insertTasks.Add(DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData));
            }

            // Execute all inserts asynchronously
            bool[] results = await Task.WhenAll(insertTasks);

            // Check if any insert failed
            if (results.Any(r => !r))
            {
                MessageBox.Show("Error inserting one or more invoice detail records.");
                return false;
            }

            return true;
        }


        private async Task<bool> UpdateInvoiceDetail(string invoiceNo)
        {
            try
            {
                bool isoldrecord = false;
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                var columnData = new Dictionary<string, object>
                {
                    { "IsNewRecord", false }
                };

                isoldrecord = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                return isoldrecord;
            }
            catch (Exception ex) { throw ex; }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) &&
                !string.IsNullOrEmpty(qtytxtbox.Text) &&
                !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                !string.IsNullOrWhiteSpace(qtytxtbox.Text))
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
                string availabilitystatus = availabilitystatuslbl.Text;
                float vatpercentage = float.Parse(vatcodelbl.Text);

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
                    dgvpurchaseproducts.Rows.Add("", mfr, productid, productname, qty,availabilitystatus, unitid, unitname, unitprice
                        ,vatamount, discount, finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter, vatpercentage);
                }

                ResetLabelData();
            }
        }

        private void ResetLabelData()
        {
            mfrtxtbox.Text = string.Empty;
            selectproducttxtbox.Text = string.Empty;
            productidlbl.Text = string.Empty;
            qtytxtbox.Text = string.Empty;
            unitnamelbl.Text = string.Empty;
            productvatlbl.Text = string.Empty;
            productdiscountlbl.Text = string.Empty;
            unitsalepricelbl.Text = string.Empty;
            totalcolumnlbl.Text = string.Empty;
            itemdescriptionlbl.Text = string.Empty;
            unitidlbl.Text = string.Empty;
            pricepermeterlbl.Text = string.Empty;
            selectproducttxtbox.Focus();
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void qtytxtbox_Leave(object sender, EventArgs e)
        {
            int itemqty = Convert.ToInt32(qtytxtbox.Text);
            if (itemqty > 0)
            {
                string getwarehousedata = "SELECT WarehouseID,Address,Name FROM WarehouseTable";
                DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                if (warehousedata != null)
                {
                    if (warehousedata.Rows.Count > 0)
                    {
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;
                        warehouseSelection.FormClosed += WarehouseSelection_FormClosed;

                        CommonFunction.DisposeOnClose(warehouseSelection);
                        warehouseSelection.ShowDialog();
                    }
                }
            }
        }

        private async void UpdateWarehouseInfo(object sender, WarehouseData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int warehouseid = e.WarehouseId;
                    string warehousename = e.WarehouseName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        warehouseidlbl.Text = warehouseid.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                vATForm.FormClosed += async delegate
                {
                    await UpdateProductDataAsync();
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

        private async Task UpdateProductDataAsync()
        {
            await Task.Run(() =>
            {
                // Assuming these updates are thread-safe
                warehouseidlbl.Invoke((Action)(() => warehouseidlbl.Text = GlobalVariables.warehouseidglobal != 0 ? GlobalVariables.warehouseidglobal.ToString() : "0"));
                itemdescriptionlbl.Invoke((Action)(() => itemdescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl ?? "N/A"));
                unitsalepricelbl.Invoke((Action)(() => unitsalepricelbl.Text = GlobalVariables.productpriceglobal != 0 ? GlobalVariables.productpriceglobal.ToString("0.00") : "0.00"));
                pricepermeterlbl.Invoke((Action)(() => pricepermeterlbl.Text = GlobalVariables.productinmeterprice != 0 ? GlobalVariables.productinmeterprice.ToString("0.00") : "0.00"));
                lengthinmeterlbl.Invoke((Action)(() => lengthinmeterlbl.Text = GlobalVariables.productinmeterlength != 0 ? GlobalVariables.productinmeterlength.ToString("0.00") : "0.00"));
                totalcolumnlbl.Invoke((Action)(() => totalcolumnlbl.Text = GlobalVariables.productfinalamountwithvatanddiscountitemwise != 0 ? GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString("0.00") : "0.00"));
                unitnamelbl.Invoke((Action)(() => unitnamelbl.Text = GlobalVariables.unitnameglobal ?? "N/A"));
                unitidlbl.Invoke((Action)(() => unitidlbl.Text = GlobalVariables.unitidglobal != 0 ? GlobalVariables.unitidglobal.ToString() : "0"));
                productdiscountlbl.Invoke((Action)(() => productdiscountlbl.Text = GlobalVariables.productdiscountamountitemwise != 0 ? GlobalVariables.productdiscountamountitemwise.ToString("0.00") : "0.00"));
                productvatlbl.Invoke((Action)(() => productvatlbl.Text = GlobalVariables.productitemwisevatamount != 0 ? GlobalVariables.productitemwisevatamount.ToString("0.00") : "0.00"));
                vatcodelbl.Invoke((Action)(() => vatcodelbl.Text = GlobalVariables.productitemwisevatpercentage != 0 ? GlobalVariables.productitemwisevatpercentage.ToString() : "0"));
                availabilitystatuslbl.Invoke((Action)(() => availabilitystatuslbl.Text = GlobalVariables.availabilitystatus ?? "IN STOCK"));
                discountpercentagelbl.Invoke((Action)(() => discountpercentagelbl.Text = GlobalVariables.discountpercentage != 0 ? GlobalVariables.discountpercentage.ToString() : "0"));
                discounttypelbl.Invoke((Action)(() => discounttypelbl.Text = GlobalVariables.productdiscounttype != false ? GlobalVariables.productdiscounttype.ToString() : "false"));
                ResetGlobalVariables();
            });
        }

        private async void ResetGlobalVariables()
        {
            await Task.Run(() =>
            {
                GlobalVariables.warehouseidglobal = 0;
                GlobalVariables.productitemwisedescriptiongloabl = null;
                GlobalVariables.productpriceglobal = 0;
                GlobalVariables.productinmeterprice = 0;
                GlobalVariables.productinmeterlength = 0;
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                GlobalVariables.unitnameglobal = null;
                GlobalVariables.unitidglobal = 0;
                GlobalVariables.productdiscountamountitemwise = 0;
                GlobalVariables.productitemwisevatamount = 0;
                GlobalVariables.productitemwisevatpercentage = 0;
                GlobalVariables.availabilitystatus = string.Empty;
                GlobalVariables.discountpercentage = 0;
                GlobalVariables.productdiscounttype = false;
            });
        }

        private async void dgvpurchaseproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
        }

        private void dgvpurchaseproducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRowSelectionAsync();
        }

        private void HandleRowSelectionAsync()
        {
            if (dgvpurchaseproducts.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dgvpurchaseproducts.SelectedRows[0]; // Get the first selected row
                int rowIndex = selectedRow.Index;
                string productmfr = selectedRow.Cells["codecolumn"].Value?.ToString() ?? null;
                string productname = selectedRow.Cells["productnamecolumn"].Value?.ToString() ?? null;

                int productid = selectedRow.Cells["productid"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["productid"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["productid"].Value.ToString())
                    : 0; // Default to 0 if empty or null

                int quantity = selectedRow.Cells["qtycolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["qtycolumn"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["qtycolumn"].Value.ToString())
                    : 0;

                int unitid = selectedRow.Cells["unitidcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["unitidcolumn"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["unitidcolumn"].Value.ToString())
                    : 0;

                string unitname = selectedRow.Cells["unitname"].Value?.ToString() ?? null;

                float price = selectedRow.Cells["pricecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["pricecolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["pricecolumn"].Value.ToString())
                    : 0.0f;

                float vat = selectedRow.Cells["vatcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["vatcolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["vatcolumn"].Value.ToString())
                    : 0.0f;

                float discount = selectedRow.Cells["discountcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["discountcolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["discountcolumn"].Value.ToString())
                    : 0.0f;

                float itemtotal = selectedRow.Cells["totalcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["totalcolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["totalcolumn"].Value.ToString())
                    : 0.0f;

                int warehouseid = selectedRow.Cells["warehouseidcolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["warehouseidcolumn"].Value.ToString())
                    ? Convert.ToInt32(selectedRow.Cells["warehouseidcolumn"].Value.ToString())
                    : 0;

                string itemdescription = selectedRow.Cells["itemdescriptioncolumn"].Value?.ToString() ?? null;

                float lengthinmeter = selectedRow.Cells["lengthinmetercolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["lengthinmetercolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["lengthinmetercolumn"].Value.ToString())
                    : 0.0f;

                float priceinmeter = selectedRow.Cells["pricepermetercolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["pricepermetercolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["pricepermetercolumn"].Value.ToString())
                    : 0.0f;

                float vatpercentage = selectedRow.Cells["vatpercentagecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["vatpercentagecolumn"].Value.ToString())
                    ? float.Parse(selectedRow.Cells["vatpercentagecolumn"].Value.ToString())
                    : 0.0f;

                float discountpercentage = selectedRow.Cells["discountpercentagecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["discountpercentagecolumn"].Value.ToString())
                        ? float.Parse(selectedRow.Cells["discountpercentagecolumn"].Value.ToString())
                        : 0.0f;

                bool discounttype = selectedRow.Cells["discounttypecolumn"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["discounttypecolumn"].Value.ToString())
                        ? Convert.ToBoolean(selectedRow.Cells["discounttypecolumn"].Value.ToString())
                        : false;
                // Open the edit dialog asynchronously

                EditItemInvoice editItemInvoice = new EditItemInvoice(rowIndex, productmfr, productname, productid, quantity, unitid, unitname, price,
                            vat, discount, itemtotal, warehouseid, itemdescription, lengthinmeter, priceinmeter, vatpercentage, discountpercentage, discounttype, true);
                editItemInvoice.DataUpdated += EditItemInvoice_DataUpdated;
                editItemInvoice.ShowDialog(); // This will still block but in a separate thread.

            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }

        private void EditItemInvoice_DataUpdated(int rowIndex, string productmfr, string productname, int productid, int quantity, int unitid, string unitname,
                                             decimal price, decimal vat, decimal discount, decimal itemtotal, int warehouseid, string itemdescription,
                                             decimal lengthinmeter, decimal priceinmeter, decimal vatpercentage, decimal discountpercentage, bool discounttype)
        {
            // Update DataGridView row with new data
            dgvpurchaseproducts.Rows[rowIndex].Cells["codecolumn"].Value = productmfr;
            dgvpurchaseproducts.Rows[rowIndex].Cells["productnamecolumn"].Value = productname;
            dgvpurchaseproducts.Rows[rowIndex].Cells["productid"].Value = productid;
            dgvpurchaseproducts.Rows[rowIndex].Cells["qtycolumn"].Value = quantity;
            dgvpurchaseproducts.Rows[rowIndex].Cells["unitidcolumn"].Value = unitid;
            dgvpurchaseproducts.Rows[rowIndex].Cells["unitname"].Value = unitname;
            dgvpurchaseproducts.Rows[rowIndex].Cells["pricecolumn"].Value = price;
            dgvpurchaseproducts.Rows[rowIndex].Cells["vatcolumn"].Value = vat;
            dgvpurchaseproducts.Rows[rowIndex].Cells["discountcolumn"].Value = discount;
            dgvpurchaseproducts.Rows[rowIndex].Cells["totalcolumn"].Value = itemtotal;
            dgvpurchaseproducts.Rows[rowIndex].Cells["warehouseidcolumn"].Value = warehouseid;
            dgvpurchaseproducts.Rows[rowIndex].Cells["itemdescriptioncolumn"].Value = itemdescription;
            dgvpurchaseproducts.Rows[rowIndex].Cells["lengthinmetercolumn"].Value = lengthinmeter;
            dgvpurchaseproducts.Rows[rowIndex].Cells["pricepermetercolumn"].Value = priceinmeter;
            dgvpurchaseproducts.Rows[rowIndex].Cells["vatpercentagecolumn"].Value = vatpercentage;
            dgvpurchaseproducts.Rows[rowIndex].Cells["discountpercentagecolumn"].Value = discountpercentage;
            dgvpurchaseproducts.Rows[rowIndex].Cells["discounttypecolumn"].Value = discounttype;
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice();

                // Check if MdiParent is null
                if (this.MdiParent != null)
                {
                    purchaseReturnInvoice.MdiParent = this.MdiParent;
                }
                else
                {
                    // Handle the case when MdiParent is null
                    MessageBox.Show("MdiParent is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                CommonFunction.DisposeOnClose(purchaseReturnInvoice);
                purchaseReturnInvoice.Show();
            }
            catch (Exception ex)
            {
                // Error handling to catch any issues during the form instantiation or other operations
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
