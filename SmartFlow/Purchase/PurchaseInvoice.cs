using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Purchase
{
    public partial class PurchaseInvoice : Form
    {
        private decimal initalizer = 0;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int accountsubcontrolid = 706;
        private string accountName = "Purchases";

        public PurchaseInvoice()
        {
            InitializeComponent();
        }

        public PurchaseInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }

        private async void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                // Check if both data tables have data
                if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 || _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
                {
                    // Extract invoice data from the first row
                    DataRow row = _dtinvoice.Rows[0];

                    invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                    codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;
                    invoicedatetxtbox.Text = row["invoicedate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    selectsuppliertxtbox.Text = row["ClientName"]?.ToString() ?? string.Empty;
                    supplieridlbl.Text = row["ClientID"]?.ToString() ?? "0"; // Default to 0 if ClientID is missing
                    invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
                    invoicerefrencetxtbox.Text = row["InvoiceRefrence"]?.ToString() ?? string.Empty;
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
                    inlandtransportationtxtbox.Text = row["FreightShippingCharges"]?.ToString() ?? "0";
                    shipmentreceivedbytxtbox.Text = row["ShipmentReceiveingPerson"]?.ToString() ?? string.Empty;
                    currencyidlbl.Text = row["Currencyid"].ToString();
                    currencynamelbl.Text = row["CurrencyName"].ToString();
                    currencysymbollbl.Text = row["CurrencySymbol"].ToString();
                    currencyconversionratelbl.Text = row["ConversionRate"].ToString();
                    currencylbl.Text = row["CurrencyName"].ToString() + (" : ") + row["CurrencySymbol"].ToString();

                    // Add invoice details to the DataGridView

                    AddGridData(_dtinvoicedetails);
                    savebtn.Text = "UPDATE";
                }
                else
                {
                    // Initialize form with default values
                    totaldiscounttxtbox.Text = initalizer.ToString("N2");
                    totalvattxtbox.Text = initalizer.ToString("N2");
                    inlandtransportationtxtbox.Text = initalizer.ToString("N2");
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    invoicenotxtbox.Text = await Task.Run(() => GenerateNextInvoiceNumberAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddGridData(DataTable invoiceDetails)
        {
            if (invoiceDetails == null || invoiceDetails.Rows.Count == 0)
                return;

            try
            {
                dgvpurchaseproducts.SuspendLayout();
                dgvpurchaseproducts.VirtualMode = false; // Ensure real-time updates
                dgvpurchaseproducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvpurchaseproducts.AllowUserToAddRows = false; // Prevent ghost rows

                List<DataGridViewRow> newRows = new List<DataGridViewRow>();

                foreach (DataRow invoiceRow in invoiceDetails.Rows)
                {
                    var newRow = new DataGridViewRow();
                    newRow.CreateCells(dgvpurchaseproducts);

                    try
                    {
                        newRow.Cells[dgvpurchaseproducts.Columns["vatcolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["ItemWiseVAT"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["discountcolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["ItemWiseDiscount"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["totalcolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["ItemTotal"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["productnamecolumn"].Index].Value = SafeConvertToString(invoiceRow["ProductName"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["pricecolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["UnitSalePrice"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["warehouseidcolumn"].Index].Value = SafeConvertToInt(invoiceRow["Warehouseid"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["itemdescriptioncolumn"].Index].Value = SafeConvertToString(invoiceRow["ItemDescription"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["lengthinmetercolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["LengthInMeter"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["pricepermetercolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["PricePerMeter"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["productid"].Index].Value = SafeConvertToInt(invoiceRow["Productid"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["unitidcolumn"].Index].Value = SafeConvertToInt(invoiceRow["Unitid"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["unitname"].Index].Value = SafeConvertToString(invoiceRow["UnitName"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["qtycolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["Quantity"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["vatpercentagecolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["VatCode"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["costpricecolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["PurchaseCostPrice"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["codecolumn"].Index].Value = SafeConvertToString(invoiceRow["MFR"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["availabilitycolumn"].Index].Value = SafeConvertToString(invoiceRow["ItemAvailability"]);

                        newRow.Height = 25;
                        newRows.Add(newRow);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[Error] Processing row: {ex.Message}");
                    }
                }

                dgvpurchaseproducts.Rows.AddRange(newRows.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Error] AddGridData: {ex.Message}");
            }
            finally
            {
                dgvpurchaseproducts.ResumeLayout();
                this.Invoke((MethodInvoker)delegate { dgvpurchaseproducts.Refresh(); });
            }
        }


        private decimal SafeConvertToDecimal(object value)
        {
            if (value == DBNull.Value || value == null)
                return 0m;
            return decimal.TryParse(value.ToString(), out decimal result) ? result : 0m;
        }

        private int SafeConvertToInt(object value)
        {
            if (value == DBNull.Value || value == null)
                return 0;
            return int.TryParse(value.ToString(), out int result) ? result : 0;
        }

        private string SafeConvertToString(object value)
        {
            return value != DBNull.Value && value != null ? value.ToString() : "";
        }

        private async Task<string> GenerateNextInvoiceNumberAsync()
        {
            try
            {
                string lastInvoiceNumber = await Task.Run(() => GetLastInvoiceNumberAsync());
                string newInvoiceNumber;
                string invoicePart = "PI";
                string datePart = DateTime.Today.ToString("yyMMdd");

                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    // No previous invoice number, generate the first one
                    int initialSequentialNumber = 1;
                    string sequentialPart = initialSequentialNumber.ToString("D5"); // 5-digit sequential number

                    newInvoiceNumber = $"{invoicePart}-{datePart}-{sequentialPart}";
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    int lastSequentialNumber;
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);

                    if (!int.TryParse(sequentialPart, out lastSequentialNumber))
                    {
                        throw new FormatException("Invalid format in the last invoice number. Unable to parse sequential part.");
                    }

                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Validate sequential number bounds (optional)
                    if (nextSequentialNumber > 99999)
                    {
                        throw new OverflowException("Sequential number has exceeded the maximum limit.");
                    }

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicePart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"Error generating invoice number: {ex.Message}\n{ex.StackTrace}");

                // Show a user-friendly message
                MessageBox.Show("An error occurred while generating the invoice number. Please contact support.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        private async Task<string> GetLastInvoiceNumberAsync()
        {
            string lastInvoiceNumber = null;
            try
            {
                // Query to fetch the latest invoice number starting with 'PI-'
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PI-%' ORDER BY InvoiceNo DESC";

                // Retrieve data from the database asynchronously
                DataTable invoiceData = await Task.Run(() => DatabaseAccess.RetriveAsync(query));

                // Ensure the result is not null and has rows
                if (invoiceData != null && invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
                else
                {
                    // Optional: Log or handle cases where no data is found
                    Console.WriteLine("No matching invoice numbers found in the database.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error retrieving the last invoice number: {ex.Message}\n{ex.StackTrace}");

                // Display a user-friendly error message
                MessageBox.Show("An error occurred while retrieving the last invoice number from the database. " +
                                "Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the last invoice number (null if not found or an error occurred)
            return lastInvoiceNumber;
        }

        private async Task<string> CheckInvoiceBeforeInsertAsync()
        {
            try
            {
                // Retrieve the last invoice number asynchronously
                string lastInvoiceNumber = await GetLastInvoiceNumberAsync();

                // Ensure the input invoice number is valid
                if (string.IsNullOrWhiteSpace(invoicenotxtbox.Text))
                {
                    MessageBox.Show("Invoice number field cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string newInvoiceNumber = invoicenotxtbox.Text;

                // Compare the new invoice number with the last invoice number
                if (!string.IsNullOrEmpty(lastInvoiceNumber) && string.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    // Generate and return the next valid invoice number asynchronously
                    return await GetLastInvoiceNumberAsync();
                }
                else
                {
                    // Return the provided invoice number
                    return newInvoiceNumber;
                }
            }
            catch (Exception ex)
            {
                // Log the error for debugging (if applicable)
                Console.WriteLine($"Error while processing invoice numbers: {ex.Message}\n{ex.StackTrace}");

                // Show an error message to the user
                MessageBox.Show("An error occurred while validating the invoice number. Please contact support.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Return null in case of an error
                return null;
            }
        }

        private async void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new instance of the PurchaseInvoice form
                PurchaseInvoice purchaseInvoice = new PurchaseInvoice();

                // Set the MDI parent to match the current form's MDI parent
                if (this.MdiParent != null)
                {
                    purchaseInvoice.MdiParent = this.MdiParent;
                }
                else
                {
                    MessageBox.Show("MDI Parent is not set. Unable to open the PurchaseInvoice form as an MDI child.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Perform any asynchronous operations here if required
                await Task.Run(() =>
                {
                    // Simulate a delay or perform a background operation
                    System.Threading.Thread.Sleep(100); // Example, replace with actual async logic
                });

                // Ensure the form is disposed of properly upon closure
                CommonFunction.DisposeOnClose(purchaseInvoice);

                // Show the PurchaseInvoice form
                purchaseInvoice.Show();
            }
            catch (Exception ex)
            {
                // Log the error for debugging (if applicable)
                Console.WriteLine($"Error while opening PurchaseInvoice form: {ex.Message}\n{ex.StackTrace}");

                // Display an error message to the user
                MessageBox.Show("An error occurred while opening the PurchaseInvoice form. Please try again or contact support.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    string invoiceNo = string.Empty;
                    errorProvider.Clear();
                    bool isInserted = false;

                    // Validate inputs
                    if (selectsuppliertxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(selectsuppliertxtbox, "Please Select Supplier.");
                        selectsuppliertxtbox.Focus();
                        return;
                    }
                    if (invoicerefrencetxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(invoicerefrencetxtbox, "Please Enter Reference Invoice.");
                        invoicerefrencetxtbox.Focus();
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
                        invoiceNo = invoicenotxtbox.Text;
                        await UpdatePurchaseInvoice(invoiceNo,invoiceDate,invoicecode);
                    }
                    else
                    {
                        string invoicecode = Guid.NewGuid().ToString();
                        invoiceNo = await CheckInvoiceBeforeInsertAsync();
                        isInserted = await AddPurchaseInvoice(invoiceNo, invoiceDate, invoicecode);
                    }

                    if (isInserted)
                    {
                        InvoiceReportView invoiceReport = new InvoiceReportView(invoiceNo);
                        invoiceReport.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(invoiceReport);
                        invoiceReport.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateItemCost()
        {
            int totalQuantity = 0;
            decimal totalexpenses = Convert.ToInt32(freighttxtbox.Text) + Convert.ToInt32(inlandtransportationtxtbox.Text) + Convert.ToInt32(importdutytxtbox.Text) + Convert.ToInt32(customchargestxtbox.Text) +
                Convert.ToInt32(vatchargestxtbox.Text) + Convert.ToInt32(excisedutytxtbox.Text) + Convert.ToInt32(antidumpingdutiestxtbox.Text) + Convert.ToInt32(terminalhandlingcharges.Text) +
                Convert.ToInt32(demurragechargestxtbox.Text) + Convert.ToInt32(warehousingchargestxtbox.Text) + Convert.ToInt32(insurancechargestxtbox.Text) + Convert.ToInt32(custombondtxtbox.Text) +
                Convert.ToInt32(importlisencepermittxtbox.Text) + Convert.ToInt32(inspectionfeestxtbox.Text) + Convert.ToInt32(legalizationcertificatetxtbox.Text) + Convert.ToInt32(letterofcreditfeetxtbox.Text) +
                Convert.ToInt32(foreignexchangechargestxtbox.Text) + Convert.ToInt32(custombrokerfeecharges.Text) + Convert.ToInt32(freightforwardertxtbox.Text);

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.Cells["qtycolumn"].Value != null)
                {
                    totalQuantity += Convert.ToInt32(row.Cells["qtycolumn"].Value);
                }
            }

            decimal expenseperunit = totalexpenses / totalQuantity;
        }

        private async Task<bool> AddPurchaseInvoice(string invoiceNo,DateTime invoiceDate,string invoicecode)
        {
            bool insertprod = false;
            int supplierid = Convert.ToInt32(supplieridlbl.Text);
            string supplierName = selectsuppliertxtbox.Text;
            string invoiceRef = invoicerefrencetxtbox.Text;
            decimal netTotal = decimal.Parse(nettotaltxtbox.Text);
            float netVat = float.Parse(totalvattxtbox.Text);
            float netDiscount = float.Parse(totaldiscounttxtbox.Text);
            decimal shippingCharges = decimal.Parse(inlandtransportationtxtbox.Text);
            string shipmentreceivedby = shipmentreceivedbytxtbox.Text;
            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencystring = currencystringlbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "invoicedate", invoiceDate },
                { "ClientID", supplierid },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceCode", invoicecode },
                { "NetTotal", netTotal },
                { "ClientName", supplierName },
                { "TotalVat", netVat },
                { "TotalDiscount", netDiscount },
                { "FreightShippingCharges", shippingCharges },
                { "InvoiceRefrence", invoiceRef },
                { "ShipmentReceiveingPerson", shipmentreceivedby },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate },
                { "AddedBy", "JEAN" },
                { "InvoiceType", "Purchase" }
            };

            bool insertinvoice = await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData));
            string companyName = companytxtbox.Text;
            decimal totalwithshippingcharges = netTotal + shippingCharges;
            await CommonFunction.InsertOrUpdateAccountStatementAsync(supplierName, supplierid, "Purchases", invoiceNo, accountName, "", accountsubcontrolid, totalwithshippingcharges, 0, "", true, false, companyName, "For Supplier");
            await CommonFunction.InsertOrUpdateAccountStatementAsync(supplierName, supplierid, "Purchases", invoiceNo, accountName, "", accountsubcontrolid, 0, totalwithshippingcharges, "", false, true, companyName, "For Office");

            if (insertinvoice)
            {
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (row.IsNewRow) continue;

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
                    decimal costpriceitem = row.Cells["costpricecolumn"].Value == null ? 0m : decimal.Parse(row.Cells["costpricecolumn"].Value.ToString());
                    decimal vatpercentage = row.Cells["vatpercentagecolumn"].Value == null ? 0m : decimal.Parse(row.Cells["vatpercentagecolumn"].Value.ToString());
                    int actualqtyordered = row.Cells["actualqtyorderedcolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["actualqtyorderedcolumn"].Value);

                    string subtable = "InvoiceDetailsTable";
                    var subColumnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
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
                        { "AddInventory", true },
                        { "PurchaseCostPrice", costpriceitem },
                        { "PricePerMeter", pricepermeter },
                        { "LengthInMeter", lengthinmeter },
                        { "ItemDescription", itemdescription },
                        { "MinusInventory", false },
                        { "UnitSalePrice", saleprice },
                        { "VatCode", vatpercentage },
                        { "QtyOrdered", actualqtyordered }
                    };

                    insertprod = await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData));
                    


                    if (insertprod)
                    {
                        string thirdsubtable = "SerialNoTable";
                        int count = 0;
                        int diff = quantity - count;

                        if (diff > 0)
                        {
                            int start = 0;
                            while (start < diff)
                            {
                                string serialnumber = await GenerateRandomSerialNumberAsync();
                                var thirddata = new Dictionary<string, object>
                                {
                                    { "ProductId", productid },
                                    { "SerialNo", serialnumber },
                                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") },
                                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                    { "InvoiceNo", invoiceNo }
                                };
                                start++;
                                await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(thirdsubtable, "INSERT", thirddata));
                            }
                        }
                    }
                }
            }
            
            return insertprod;
        }

        private async Task UpdatePurchaseInvoice(string invoiceNo,DateTime invoiceDate,string invoicecode)
        {
            int supplierid = Convert.ToInt32(supplieridlbl.Text);
            string supplierName = selectsuppliertxtbox.Text;
            string invoiceRef = invoicerefrencetxtbox.Text;
            decimal netTotal = decimal.Parse(nettotaltxtbox.Text);
            float netVat = float.Parse(totalvattxtbox.Text);
            float netDiscount = float.Parse(totaldiscounttxtbox.Text);
            decimal shippingCharges = decimal.Parse(inlandtransportationtxtbox.Text);
            string shipmentreceivedby = shipmentreceivedbytxtbox.Text;
            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencystring = currencystringlbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";
            string whereClause = $"InvoiceNo = '{invoiceNo}'";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "invoicedate", invoiceDate },
                { "ClientID", supplierid },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceCode", invoicecode },
                { "NetTotal", netTotal },
                { "ClientName", supplierName },
                { "TotalVat", netVat },
                { "TotalDiscount", netDiscount },
                { "FreightShippingCharges", shippingCharges },
                { "InvoiceRefrence", invoiceRef },
                { "ShipmentReceiveingPerson", shipmentreceivedby },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate },
                { "AddedBy", "JEAN" },
                { "InvoiceType", "Purchase" }
            };

            bool isUpdated = await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause));
            bool isdeleted = await DeleteStatementData(invoiceNo);
            string companyName = companytxtbox.Text;
            decimal totalwithshippingcharges = netTotal + shippingCharges;
            await CommonFunction.InsertOrUpdateAccountStatementAsync(supplierName, supplierid, "Purchases", invoiceNo, accountName, "", accountsubcontrolid, totalwithshippingcharges, 0, "", true, false, companyName, "For Supplier");
            await CommonFunction.InsertOrUpdateAccountStatementAsync(supplierName, supplierid, "Purchases", invoiceNo, accountName, "", accountsubcontrolid, 0, totalwithshippingcharges, "", false, true, companyName, "For Office");


            if (isUpdated)
            {

                // Delete existing invoice details
                bool isoldupdated = await UpdateInvoiceDetail(invoiceNo);
                if (isoldupdated) 
                {
                    // Loop through DataGridView rows to process each product
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (row.IsNewRow) continue; // Skip new/empty rows

                        try
                        {
                            // Extract and validate data from row
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
                            decimal costpriceitem = row.Cells["costpricecolumn"].Value == null ? 0m : decimal.Parse(row.Cells["costpricecolumn"].Value.ToString());
                            decimal vatpercentage = row.Cells["vatpercentagecolumn"].Value == null ? 0m : decimal.Parse(row.Cells["vatpercentagecolumn"].Value.ToString());
                            int actualqtyordered = row.Cells["actualqtyorderedcolumn"].Value == null ? 0 : Convert.ToInt32(row.Cells["actualqtyorderedcolumn"].Value);

                            // Prepare data for insertion
                            string subtable = "InvoiceDetailsTable";
                            var subColumnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceNo },
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
                                { "AddInventory", true },
                                { "PurchaseCostPrice", costpriceitem },
                                { "PricePerMeter", pricepermeter },
                                { "LengthInMeter", lengthinmeter },
                                { "ItemDescription", itemdescription },
                                { "MinusInventory", false },
                                { "UnitSalePrice", saleprice },
                                { "VatCode", vatpercentage },
                                { "QtyOrdered", actualqtyordered }
                            };

                            // Insert product details into the database
                            bool insertprod = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                            if (!insertprod)
                            {
                                throw new Exception($"Failed to insert product details for ProductID: {productid}");
                            }

                            int count = 0; // Replace with actual count if available
                            int diff = quantity - count;

                            if (diff > 0)
                            {
                                for (int i = 0; i < diff; i++)
                                {
                                    string serialnumber = await GenerateRandomSerialNumberAsync();
                                    string query1 = string.Format(
                                        "INSERT INTO SerialNoTable (ProductId, SerialNo, CreatedAt, CreatedDay, InvoiceNo) " +
                                        "VALUES ({0}, '{1}', '{2}', '{3}', '{4}')",
                                        productid, serialnumber, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                        DateTime.Now.DayOfWeek, invoiceNo);

                                    // Execute the serial number insertion query
                                    if (!await DatabaseAccess.ExecuteNonQueryAsync(query1))
                                    {
                                        throw new Exception($"Failed to insert serial number: {serialnumber} for ProductID: {productid}");
                                    }
                                }
                            }
                        }
                        catch (Exception rowEx)
                        {
                            // Log row-level error and continue with other rows
                            Console.WriteLine($"Error processing row for ProductID: {row.Cells["productidcolumn"]?.Value}. {rowEx.Message}");
                        }
                    }

                    // Show the invoice report
                    InvoiceReportView invoiceReport = new InvoiceReportView(invoiceNo)
                    {
                        MdiParent = Application.OpenForms["Dashboard"]
                    };
                    CommonFunction.DisposeOnClose(invoiceReport);
                    invoiceReport.Show();

                    // Close the current form
                    this.Close();
                }
            }
        }

        private async Task<bool> DeleteStatementData(string invoiceNo)
        {
            try
            {
                bool isoldrecord = false;
                string tableName = "AccountStatementTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                isoldrecord = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);
                return isoldrecord;
            }
            catch (Exception ex) { throw ex; }
        }

        public static async Task<string> GenerateRandomSerialNumberAsync()
        {
            Random random = new Random();
            const string chars = "FABT0123456789";
            char[] serialChars = new char[10];
            string serialNumber = string.Empty;

            // Loop until a unique serial number is generated
            bool isUnique = false;
            while (!isUnique)
            {
                // Generate a random serial number
                for (int i = 0; i < serialChars.Length; i++)
                {
                    serialChars[i] = chars[random.Next(chars.Length)];
                }

                serialNumber = new string(serialChars);

                // Query to check if the serial number already exists in the database
                string query = "SELECT COUNT(*) FROM SerialNoTable WHERE SerialNo = @SerialNo";

                // Use parameterized query to avoid SQL injection
                var parameters = new Dictionary<string, object>
                {
                    { "@SerialNo", serialNumber }
                };

                // Retrieving the count of existing serial numbers asynchronously
                DataTable dt = await DatabaseAccess.RetriveAsync(query, parameters);

                if (dt != null && dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) == 0)
                {
                    // If no record with this serial number exists, it's unique
                    isUnique = true;
                }
            }

            return serialNumber;
        }

        private async void PurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    var result = await Task.Run(() =>
                        MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                        "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));

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
                        codetxtbox.Text = supplierCode;
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



        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                // Catch and display any unexpected errors
                MessageBox.Show($"An error occurred while opening the product selection form: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            if (selectsuppliertxtbox?.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox?.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts?.Rows.Count > 0) { return true; }
            if (invoicerefrencetxtbox?.Text.Trim().Length > 0) { return true; }

            return false; // No TextBox is filled
        }


        private async void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                    {
                        // Check if the SupplierSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
                        if (openForm == null)
                        {
                            // Create and show the SupplierSelectionForm
                            SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            supplierSelection.SupplierDataSelected += UpdateSupplierTextBox;

                            // Dispose of the form when it's closed
                            CommonFunction.DisposeOnClose(supplierSelection);

                            // Show the SupplierSelectionForm as a dialog
                            await Task.Run(() => supplierSelection.ShowDialog());
                        }
                        else
                        {
                            // Bring the already open form to the front
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch and display any unexpected errors
                MessageBox.Show($"An error occurred while handling the supplier selection: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                    {
                        // Check if the ProductSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                        if (openForm == null)
                        {
                            // Create and show the ProductSelectionForm
                            ProductSelectionForm productSelection = new ProductSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            productSelection.ProductDataSelected += UpdateProductTextBox;

                            // Dispose of the form when it's closed
                            CommonFunction.DisposeOnClose(productSelection);

                            // Show the ProductSelectionForm as a dialog
                            productSelection.ShowDialog();
                        }
                        else
                        {
                            // Bring the already open form to the front
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch and display any unexpected errors
                MessageBox.Show($"An error occurred while handling the product selection: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
        }

        private async void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs first
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
                    string itemwisedescription = itemdescriptionlbl.Text;
                    decimal lengthinmeterproduct = decimal.Parse(lengthinmeterlbl.Text);
                    decimal priceinmeter = decimal.Parse(pricepermeterlbl.Text);
                    string vatpercentage = vatcodelbl.Text;
                    string discountpercentage = discountpercentagelbl.Text;
                    bool discounttype = Convert.ToBoolean(discounttypelbl.Text);
                    int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
                    decimal costprice = decimal.Parse(costpricelbl.Text);
                    string availabilitystatus = availabilitystatuslbl.Text;
                    int actualqtyordered = Convert.ToInt32(actualqtyorderedlbl.Text);

                    bool productExists = false;
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["productid"].Value != null && row.Cells["productid"].Value.ToString() == productidlbl.Text.ToString()
                                && float.Parse(row.Cells["pricecolumn"].Value.ToString()) == unitprice)
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                decimal currentVat = decimal.Parse(row.Cells["vatcolumn"].Value.ToString());
                                decimal currentDiscount = decimal.Parse(row.Cells["discountcolumn"].Value.ToString());
                                decimal currentitemTotal = decimal.Parse(row.Cells["totalcolumn"].Value.ToString());

                                row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                                // Update VAT, round to two decimal places
                                row.Cells["vatcolumn"].Value = Math.Round(currentVat + vatamount, 2);

                                // Update Discount, round to two decimal places
                                row.Cells["discountcolumn"].Value = Math.Round(currentDiscount + discount, 2);

                                // Update Total, round to two decimal places
                                row.Cells["totalcolumn"].Value = Math.Round(currentitemTotal + finalitemwise, 2);

                                productExists = true;
                                break;
                            }
                        }
                    }

                    if (!productExists)
                    {
                        dgvpurchaseproducts.Rows.Add("", mfr, productid, productname, qty, availabilitystatus, unitid, unitname, unitprice.ToString("N2"), vatamount.ToString("N2"), discount.ToString("N2"),
                            finalitemwise.ToString("N2"), warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter, costprice, vatpercentage,"","", actualqtyordered);
                    }

                    ResetLabelData();
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            discounttypelbl.Text = string.Empty;
            warehouseidlbl.Text = string.Empty;
            unitidlbl.Text = string.Empty;
            pricepermeterlbl.Text = string.Empty;
            vatcodelbl.Text = string.Empty;
            discountpercentagelbl.Text = string.Empty;
            actualqtyorderedlbl.Text = string.Empty;
            selectproducttxtbox.Focus();
        }

        private async void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            else
            {
                // Example of async validation or an external task
                await PerformAsyncValidation();
            }
        }

        // Example of an async task you might call during the key press
        private async Task PerformAsyncValidation()
        {
            // Simulate async work (e.g., a database or API call)
            await Task.Delay(500); // Placeholder for an async operation
                                   // Perform validation or other async tasks here
        }
        private async void dgvpurchaseproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
        }

        private async void qtytxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                // Validate if the quantity entered is a valid number and greater than 0
                if (int.TryParse(qtytxtbox.Text, out int itemqty) && itemqty > 0)
                {
                    // Perform the database query asynchronously
                    string getwarehousedata = "SELECT WarehouseID,Address, Name FROM WarehouseTable";
                    DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                    if (warehousedata != null && warehousedata.Rows.Count > 0)
                    {
                        // Create and display the WarehouseSelection form if warehouse data is available
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
                    else
                    {
                        // If no warehouses are available, notify the user
                        MessageBox.Show("No warehouse data available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // If the quantity is not a valid number or <= 0, show a warning
                    MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show a message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Ensure sender is of expected type and dispose of it
                if (sender is WarehouseSelection warehouseSelection)
                {
                    // Clean up the warehouse selection form
                    CommonFunction.DisposeOnClose(warehouseSelection);

                    // Check for valid quantity input before proceeding
                    if (int.TryParse(qtytxtbox.Text, out int itemQty) && itemQty > 0)
                    {
                        // Create and show VATForm after WarehouseSelection is closed
                        VATForm vATForm = new VATForm(itemQty, true)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Update product data when VATForm is closed
                        vATForm.FormClosed += async delegate
                        {
                            await UpdateProductDataAsync();
                        };

                        // Apply DisposeOnClose to VATForm
                        CommonFunction.DisposeOnClose(vATForm);

                        // Show the VAT form asynchronously
                        vATForm.ShowDialog();
                    }
                    else
                    {
                        // Notify the user of invalid quantity
                        MessageBox.Show("Invalid quantity value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Unexpected sender type handling
                    MessageBox.Show("Unexpected form closed event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Provide detailed error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                costpricelbl.Invoke((Action)(() => costpricelbl.Text = GlobalVariables.productcostprice != 0 ? GlobalVariables.productcostprice.ToString("0.00") : "0.00"));
                actualqtyorderedlbl.Invoke((Action)(() => actualqtyorderedlbl.Text = GlobalVariables.actualqtyordered != 0 ? GlobalVariables.actualqtyordered.ToString("0") : "0"));
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
                GlobalVariables.productcostprice = 0;
                GlobalVariables.actualqtyordered = 0;
            });
        }



        private async Task<bool> UpdateInvoiceDetail(string invoiceNo)
        {
            try
            {
                bool isUpdated = false;
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                var columnData = new Dictionary<string, object>
                {
                    { "IsNewRecord", false }
                };

                isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                return isUpdated;
            }
            catch (Exception ex) { throw ex; }
        }

        // Optional: Log errors for debugging or auditing purposes
        private void LogError(string message)
        {
            // You could log to a file, database, or a logging service here
            // Example: File.AppendAllText("errors.log", $"{DateTime.Now}: {message}\n");
            Console.WriteLine(message);  // For now, just output to console
        }



        private async void removevatchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (removevatchkbox.Checked)
            {
                // Use async Task.Run to offload the operation from the UI thread
                await Task.Run(() =>
                {
                    // Iterate through the DataGridView rows
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
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
                });
            }
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

        private async void dgvpurchaseproducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                HandleRowSelectionAsync();
            }

            if (e.Control && e.KeyCode == Keys.D)
            {
                // Ensure the current row has a valid product ID.
                var productidCellValue = dgvpurchaseproducts.CurrentRow?.Cells["productid"].Value;
                if (productidCellValue != null && int.TryParse(productidCellValue.ToString(), out int productid) && productid > 0)
                {
                    // Check if there are any selected rows.
                    if (dgvpurchaseproducts.SelectedRows.Count > 0)
                    {
                        // Collect rows to remove to avoid modifying the collection during iteration.
                        List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                rowsToRemove.Add(row);
                            }
                        }

                        // Simulate an async operation (e.g., saving changes to a database).
                        // Here we can await an async task (e.g., save data to a database, etc.)
                        await Task.Delay(500); // Placeholder async operation (e.g., save)

                        // Remove the rows after collecting them.
                        foreach (var row in rowsToRemove)
                        {
                            dgvpurchaseproducts.Rows.Remove(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select one or more rows to delete.", "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid row with a valid Product ID.", "Invalid Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
    }

}
