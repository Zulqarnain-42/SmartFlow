using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Interface;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class PurchaseInvoice : Form
    {
        private readonly ICurrencyService _currencyService;
        private int invoiceCounter = 1;
        private decimal initalizer = 0;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
        public PurchaseInvoice()
        {
            InitializeComponent();
        }

        public PurchaseInvoice(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            InitializeComponent();
            currencyidlbl.Text = _currencyService.DefaultCurrency.CurrencyId.ToString();
            currencynamelbl.Text = _currencyService.DefaultCurrency.Name.ToString();
            currencystringlbl.Text = _currencyService.DefaultCurrency.CurrencyString.ToString();
            currencysymbollbl.Text = _currencyService.DefaultCurrency.Symbol.ToString();
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
                if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
                {
                    // Extract invoice data from the first row
                    DataRow row = _dtinvoice.Rows[0];

                    invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                    codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;
                    invoicedatetxtbox.Text = DateTime.TryParse(row["invoicedate"]?.ToString(), out DateTime invoiceDate)
                        ? invoiceDate.ToString("dd/MM/yyyy")
                        : DateTime.Now.ToString("dd/MM/yyyy"); // Fallback to current date
                    selectsuppliertxtbox.Text = row["ClientName"]?.ToString() ?? string.Empty;
                    supplieridlbl.Text = row["ClientID"]?.ToString() ?? "0"; // Default to 0 if ClientID is missing
                    invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
                    invoicerefrencetxtbox.Text = row["InvoiceRefrence"]?.ToString() ?? string.Empty;
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
                    shippingchargestxtbox.Text = row["FreightShippingCharges"]?.ToString() ?? "0";
                    shipmentreceivedbytxtbox.Text = row["ShipmentReceiveingPerson"]?.ToString() ?? string.Empty;

                    // Add invoice details to the DataGridView
                    foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                    {
                        try
                        {
                            await Task.Run(() =>
                            {
                                Invoke(new Action(() =>
                                {
                                    int detailsRowIndex = dgvpurchaseproducts.Rows.Add();

                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["mfrcolumn"].Value = invoiceDetailsRow["MFR"]?.ToString() ?? string.Empty;
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productidcolumn"].Value = invoiceDetailsRow["Productid"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"]?.ToString() ?? string.Empty;
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitnamecolumn"].Value = invoiceDetailsRow["UnitName"]?.ToString() ?? string.Empty;
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["salepricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"]?.ToString() ?? string.Empty;
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = invoiceDetailsRow["LengthInMeter"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = invoiceDetailsRow["PricePerMeter"]?.ToString() ?? "0";
                                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["costpricecolumn"].Value = invoiceDetailsRow["PurchaseCostPrice"]?.ToString() ?? "0";
                                }));
                            });
                        }
                        catch (Exception innerEx)
                        {
                            MessageBox.Show($"Error while processing invoice details: {innerEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    savebtn.Text = "UPDATE";
                }
                else
                {
                    // Initialize form with default values
                    totaldiscounttxtbox.Text = initalizer.ToString("N2");
                    totalvattxtbox.Text = initalizer.ToString("N2");
                    shippingchargestxtbox.Text = initalizer.ToString("N2");
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    invoicenotxtbox.Text = await Task.Run(() => GenerateNextInvoiceNumberAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                await CommonFunction.DisposeOnCloseAsync(purchaseInvoice);

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

                if (savebtn.Text == "UPDATE")
                {
                    string invoicecode = invoicecodelbl.Text;
                    invoiceNo = invoicenotxtbox.Text;
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierid = Convert.ToInt32(supplieridlbl.Text);
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoiceRef = invoicerefrencetxtbox.Text;
                    float netTotal = float.Parse(nettotaltxtbox.Text);
                    float netVat = float.Parse(totalvattxtbox.Text);
                    float netDiscount = float.Parse(totaldiscounttxtbox.Text);
                    float shippingCharges = float.Parse(shippingchargestxtbox.Text);
                    string shipmentreceivedby = shipmentreceivedbytxtbox.Text;

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
                        { "ShipmentReceiveingPerson", shipmentreceivedby }
                    };

                    bool isUpdated = await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause));

                    if (isUpdated)
                    {
                        await Task.Run(() => UpdateInvoiceDetailsDataAsync(invoiceNo, invoicecode));
                    }
                }
                else
                {
                    string invoicecode = Guid.NewGuid().ToString();
                    invoiceNo = await CheckInvoiceBeforeInsertAsync();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierid = Convert.ToInt32(supplieridlbl.Text);
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoiceRef = invoicerefrencetxtbox.Text;
                    float netTotal = float.Parse(nettotaltxtbox.Text);
                    float netVat = float.Parse(totalvattxtbox.Text);
                    float netDiscount = float.Parse(totaldiscounttxtbox.Text);
                    float shippingCharges = float.Parse(shippingchargestxtbox.Text);
                    string shipmentreceivedby = shipmentreceivedbytxtbox.Text;

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
                        { "ShipmentReceiveingPerson", shipmentreceivedby }
                    };

                    bool insertinvoice = await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData));

                    if (insertinvoice)
                    {
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string mfr = row.Cells["mfrcolumn"].Value.ToString();
                            int productid = Convert.ToInt32(row.Cells["productidcolumn"].Value.ToString());
                            string productname = row.Cells["productnamecolumn"].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                            int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                            float saleprice = float.Parse(row.Cells["salepricecolumn"].Value.ToString());
                            float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                            float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                            float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                            int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                            string itemdescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                            decimal lengthinmeter = decimal.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                            decimal pricepermeter = decimal.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                            decimal costpriceitem = decimal.Parse(row.Cells["costpricecolumn"].Value.ToString());

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
                                { "UnitSalePrice", saleprice }
                            };

                            bool insertprod = await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData));
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
                                        await Task.Run(() => DatabaseAccess.ExecuteQueryAsync(thirdsubtable,"INSERT", thirddata));
                                    }
                                }
                            }
                        }
                        isInserted = true;
                    }
                }

                if (isInserted)
                {
                    InvoiceReportView invoiceReport = new InvoiceReportView(invoiceNo);
                    invoiceReport.MdiParent = Application.OpenForms["Dashboard"];
                    await CommonFunction.DisposeOnCloseAsync(invoiceReport);
                    invoiceReport.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task UpdateInvoiceDetailsDataAsync(string invoiceNo, string invoiceCode)
        {
            bool isInserted = false;

            try
            {
                // Backup current data
                await Task.Run(() => InsertBackUpDataAsync(invoiceNo, invoiceCode));

                // Delete existing invoice details
                await Task.Run(() => DeleteInvoiceDetailAsync(invoiceNo, "InvoiceDetailsTable"));

                // Loop through DataGridView rows to process each product
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (row.IsNewRow) continue; // Skip new/empty rows

                    try
                    {
                        // Extract and validate data from row
                        string mfr = row.Cells["mfrcolumn"]?.Value?.ToString() ?? string.Empty;
                        int productid = Convert.ToInt32(row.Cells["productidcolumn"].Value);
                        string productname = row.Cells["productnamecolumn"]?.Value?.ToString() ?? string.Empty;
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                        int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value);
                        float saleprice = float.Parse(row.Cells["salepricecolumn"].Value.ToString());
                        float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                        float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                        float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                        int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value);
                        string itemdescription = row.Cells["itemdescriptioncolumn"]?.Value?.ToString() ?? string.Empty;
                        decimal lengthinmeter = decimal.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                        decimal pricepermeter = decimal.Parse(row.Cells["pricepermetercolumn"].Value.ToString());
                        decimal costpriceitem = decimal.Parse(row.Cells["costpricecolumn"].Value.ToString());

                        // Prepare data for insertion
                        string subtable = "InvoiceDetailsTable";
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
                            { "AddInventory", true },
                            { "PurchaseCostPrice", costpriceitem },
                            { "PricePerMeter", pricepermeter },
                            { "LengthInMeter", lengthinmeter },
                            { "ItemDescription", itemdescription },
                            { "MinusInventory", false },
                            { "UnitSalePrice", saleprice }
                        };

                        // Insert product details into the database
                        bool insertprod = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                        if (!insertprod)
                        {
                            throw new Exception($"Failed to insert product details for ProductID: {productid}");
                        }

                        // Handle serial numbers for the product
                        await Task.Run(() => DeleteInvoiceDetailAsync(invoiceNo, "SerialNoTable"));

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

                // Mark the operation as successful
                isInserted = true;

                if (isInserted)
                {
                    // Show the invoice report
                    InvoiceReportView invoiceReport = new InvoiceReportView(invoiceNo)
                    {
                        MdiParent = Application.OpenForms["Dashboard"]
                    };
                    await CommonFunction.DisposeOnCloseAsync(invoiceReport);
                    invoiceReport.Show();

                    // Close the current form
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the operation
                MessageBox.Show($"An error occurred while processing the invoice: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task InsertBackUpDataAsync(string invoiceNo, string invoiceCode)
        {
            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) { continue; }

                try
                {
                    // Extract cell values with null or empty checks
                    string mfr = row.Cells["mfrcolumn"].Value?.ToString() ?? string.Empty;
                    int productid = Convert.ToInt32(row.Cells["productidcolumn"].Value ?? 0);
                    string productname = row.Cells["productnamecolumn"].Value?.ToString() ?? string.Empty;
                    int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value ?? 0);
                    int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value ?? 0);
                    float saleprice = float.TryParse(row.Cells["salepricecolumn"].Value?.ToString(), out var salepriceVal) ? salepriceVal : 0f;
                    float discount = float.TryParse(row.Cells["discountcolumn"].Value?.ToString(), out var discountVal) ? discountVal : 0f;
                    float vat = float.TryParse(row.Cells["vatcolumn"].Value?.ToString(), out var vatVal) ? vatVal : 0f;
                    float total = float.TryParse(row.Cells["totalcolumn"].Value?.ToString(), out var totalVal) ? totalVal : 0f;
                    int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value ?? 0);
                    string itemdescription = row.Cells["itemdescriptioncolumn"].Value?.ToString() ?? string.Empty;
                    decimal lengthinmeter = decimal.TryParse(row.Cells["lengthinmetercolumn"].Value?.ToString(), out var lengthinmeterVal) ? lengthinmeterVal : 0m;
                    decimal pricepermeter = decimal.TryParse(row.Cells["pricepermetercolumn"].Value?.ToString(), out var pricepermeterVal) ? pricepermeterVal : 0m;
                    decimal costpriceitem = decimal.TryParse(row.Cells["costpricecolumn"].Value?.ToString(), out var costpriceitemVal) ? costpriceitemVal : 0m;

                    // Prepare the data for insertion into the database
                    string subtable = "InvoiceDetailsTable";
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
                        { "AddInventory", true },
                        { "PurchaseCostPrice", costpriceitem },
                        { "PricePerMeter", pricepermeter },
                        { "LengthInMeter", lengthinmeter },
                        { "ItemDescription", itemdescription },
                        { "MinusInventory", false },
                        { "UnitSalePrice", saleprice }
                    };

                    // Execute the insert query for each row asynchronously
                    bool isSuccess = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                    if (!isSuccess)
                    {
                        throw new Exception($"Failed to insert product with ProductID: {productid}");
                    }
                }
                catch (Exception ex)
                {
                    // Log and handle any exceptions that occur during processing
                    MessageBox.Show($"Error processing row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                if (await AreAnyTextBoxesFilledAsync())
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

                    await CommonFunction.DisposeOnCloseAsync(supplierSelection);
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

                        await CommonFunction.DisposeOnCloseAsync(productSelection);
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

        private async Task<bool> AreAnyTextBoxesFilledAsync()
        {
            // Check if the supplier text box has any text
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }

            // Check if the product text box has any text
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }

            // Check if the DataGridView has any rows
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }

            // Check if the invoice reference text box has any text
            if (invoicerefrencetxtbox.Text.Trim().Length > 0) { return true; }

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
                            await CommonFunction.DisposeOnCloseAsync(supplierSelection);

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
                            await CommonFunction.DisposeOnCloseAsync(productSelection);

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
            await CommonFunction.CalculateTotalDiscountColumnAsync(8, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(10, dgvpurchaseproducts, nettotaltxtbox);
        }

        private async void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalDiscountColumnAsync(8, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(10, dgvpurchaseproducts, nettotaltxtbox);
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
                    int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
                    string itemwisedescription = itemdescriptionlbl.Text;
                    decimal lengthinmeterproduct = decimal.Parse(lengthinmeterlbl.Text);
                    decimal priceinmeter = decimal.Parse(pricepermeterlbl.Text);
                    decimal costprice = decimal.Parse(costpricelbl.Text);

                    bool productExists = false;
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["productidcolumn"].Value != null && row.Cells["productidcolumn"].Value.ToString() == productidlbl.Text.ToString()
                                && float.Parse(row.Cells["salepricecolumn"].Value.ToString()) == unitprice)
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
                        dgvpurchaseproducts.Rows.Add("", mfr, productid, productname, qty, unitid, unitname, unitprice.ToString("N2"), discount.ToString("N2"),
                            vatamount.ToString("N2"), finalitemwise.ToString("N2"), warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter, costprice);
                    }

                    ResetLabelsData();
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResetLabelsData()
        {
            mfrtxtbox.Text = string.Empty;
            selectproducttxtbox.Text = string.Empty;
            qtytxtbox.Text = string.Empty;
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
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
            await CommonFunction.CalculateTotalColumnAsync(10, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(8, dgvpurchaseproducts, totaldiscounttxtbox);
        }

        private async void qtytxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                // Validate if the quantity entered is a valid number and greater than 0
                if (int.TryParse(qtytxtbox.Text, out int itemqty) && itemqty > 0)
                {
                    // Perform the database query asynchronously
                    string getwarehousedata = "SELECT WarehouseID, Name FROM WarehouseTable";
                    DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                    if (warehousedata != null && warehousedata.Rows.Count > 0)
                    {
                        // Create and display the WarehouseSelection form if warehouse data is available
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        warehouseSelection.FormClosed += WarehouseSelection_FormClosed;
                        await CommonFunction.DisposeOnCloseAsync(warehouseSelection);
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



        private async void WarehouseSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Ensure sender is of expected type and dispose of it
                if (sender is WarehouseSelection warehouseSelection)
                {
                    // Clean up the warehouse selection form
                    await CommonFunction.DisposeOnCloseAsync(warehouseSelection);

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
                        await CommonFunction.DisposeOnCloseAsync(vATForm);

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
                costpricelbl.Invoke((Action)(() => costpricelbl.Text = GlobalVariables.productcostprice != 0 ? GlobalVariables.productcostprice.ToString("0.00") : "0.00"));
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
                GlobalVariables.productcostprice = 0;
            });
        }

        // Helper method to format values as currency (handles 0.00 case)
        private string FormatCurrency(decimal value)
        {
            return value > 0 ? value.ToString("C2") : "0.00";
        }

        // Helper method to format decimal values (handles 0.00 case)
        private string FormatDecimal(decimal value)
        {
            return value > 0 ? value.ToString("0.00") : "0.00";
        }

        // Helper method for string checks with default value
        private string GetStringOrDefault(string value, string defaultValue)
        {
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        // Helper method for numeric checks with default value
        private string GetValueOrDefault(int value, string defaultValue)
        {
            return value > 0 ? value.ToString() : defaultValue;
        }



        private async Task DeleteInvoiceDetailAsync(string invoiceNo, string tableName)
        {
            try
            {
                // Validate input parameters
                if (string.IsNullOrEmpty(invoiceNo))
                {
                    throw new ArgumentException("Invoice number cannot be null or empty.", nameof(invoiceNo));
                }

                if (string.IsNullOrEmpty(tableName))
                {
                    throw new ArgumentException("Table name cannot be null or empty.", nameof(tableName));
                }

                string whereClause = "InvoiceNo = @InvoiceNo";
                var columnData = new Dictionary<string, object>
        {
            { "InvoiceNo", invoiceNo }
        };

                // Open a connection asynchronously
                /*using (var connection = await DatabaseAccess.ConnOpenAsync())
                {
                    await connection.OpenAsync();

                    using (var transaction = await connection.BeginTransactionAsync())
                    {
                        try
                        {
                            // Perform the delete operation asynchronously within the transaction
                            await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause, connection, transaction);

                            // Commit transaction if no errors occur
                            await transaction.CommitAsync();
                        }
                        catch (SqlException sqlEx)
                        {
                            // Rollback transaction if an error occurs
                            await transaction.RollbackAsync();

                            // Handle SQL exceptions
                            MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Log the SQL error (optional)
                            LogError($"SQL Error during delete. InvoiceNo: {invoiceNo}, TableName: {tableName}, Error: {sqlEx.Message}");
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction for any other exceptions
                            await transaction.RollbackAsync();

                            // Generic error handling
                            MessageBox.Show($"An error occurred while deleting invoice details. InvoiceNo: {invoiceNo}, TableName: {tableName}, Error: {ex.Message}",
                                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Log the general error (optional)
                            LogError($"General Error during delete. InvoiceNo: {invoiceNo}, TableName: {tableName}, Error: {ex.Message}");
                        }
                    }
                }*/
            }
            catch (ArgumentException argEx)
            {
                // Handle argument exceptions
                MessageBox.Show($"Invalid argument: {argEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Generic error handling
                MessageBox.Show($"An error occurred while deleting invoice details. InvoiceNo: {invoiceNo}, TableName: {tableName}, Error: {ex.Message}",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log the error (optional)
                LogError($"Error during delete. InvoiceNo: {invoiceNo}, TableName: {tableName}, Error: {ex.Message}");
            }
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

                string unitname = selectedRow.Cells["unitnamecolumn"].Value?.ToString() ?? null;

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

                // Open the edit dialog asynchronously

                EditItemInvoice editItemInvoice = new EditItemInvoice(rowIndex, productmfr, productname, productid, quantity, unitid, unitname, price,
                    vat, discount, itemtotal, warehouseid, itemdescription, lengthinmeter, priceinmeter, vatpercentage);
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
                var productidCellValue = dgvpurchaseproducts.CurrentRow?.Cells[1].Value;
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
    }

}
