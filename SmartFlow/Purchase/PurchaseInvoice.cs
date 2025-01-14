using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Masters;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Purchase
{
    public partial class PurchaseInvoice : Form
    {
        private int invoiceCounter = 1;
        private decimal initalizer = 0;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
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

        private void PurchaseInvoice_Load(object sender, EventArgs e)
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
                    invoicenotxtbox.Text = GenerateNextInvoiceNumber();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
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
        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                // Query to fetch the latest invoice number starting with 'PI-'
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PI-%' ORDER BY InvoiceNo DESC";

                // Retrieve data from the database
                DataTable invoiceData = DatabaseAccess.Retrive(query);

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
        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                // Retrieve the last invoice number
                string lastInvoiceNumber = GetLastInvoiceNumber();

                // Ensure the input invoice number is valid
                if (string.IsNullOrWhiteSpace(invoicenotxtbox.Text))
                {
                    MessageBox.Show("Invoice number field cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string newInvoiceNumber = invoicenotxtbox.Text;

                // Compare the new invoice number with the last invoice number
                if (!string.IsNullOrEmpty(lastInvoiceNumber) && String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    // Generate and return the next valid invoice number
                    return GenerateNextInvoiceNumber();
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
        private void newbtn_Click(object sender, EventArgs e)
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
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string invoiceNo = string.Empty;
                errorProvider.Clear();
                bool isInserted = false;
                
                if(selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox,"Please Select Supplier.");
                    selectsuppliertxtbox.Focus();
                    return;
                }
                if(invoicerefrencetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicerefrencetxtbox,"Please Enter Refrence Invoice.");
                    invoicerefrencetxtbox.Focus();
                    return;
                }

                if (savebtn.Text == "UPDATE")
                {
                    string invoicecode = invoicecodelbl.Text;
                    invoiceNo = invoicenotxtbox.Text;
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierid = Convert.ToInt32(supplieridlbl.Text.ToString());
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoiceRef = invoicerefrencetxtbox.Text;
                    float netTotal = float.Parse(nettotaltxtbox.Text.ToString());
                    float netVat = float.Parse(totalvattxtbox.Text.ToString());
                    float netDiscount = float.Parse(totaldiscounttxtbox.Text.ToString());
                    float shippingCharges = float.Parse(shippingchargestxtbox.Text.ToString());
                    string shipmentreceivedby = shipmentreceivedbytxtbox.Text;

                    string tableName = "InvoiceTable";
                    string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
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
                        { "ShipmentReceiveingPerson", shipmentreceivedby }
                    };
                    bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);

                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceNo, invoicecode);
                    }
                }
                else
                {
                    string invoicecode = Guid.NewGuid().ToString();
                    invoiceNo = CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierid = Convert.ToInt32(supplieridlbl.Text.ToString());
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoiceRef = invoicerefrencetxtbox.Text;
                    float netTotal = float.Parse(nettotaltxtbox.Text.ToString());
                    float netVat = float.Parse(totalvattxtbox.Text.ToString());
                    float netDiscount = float.Parse(totaldiscounttxtbox.Text.ToString());
                    float shippingCharges = float.Parse(shippingchargestxtbox.Text.ToString());
                    string shipmentreceivedby = shipmentreceivedbytxtbox.Text;

                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
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
                        { "ShipmentReceiveingPerson", shipmentreceivedby }
                    };
                    bool insertinvoice = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                    if (insertinvoice)
                    {
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (row.IsNewRow) { continue; }

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

                            bool insertprod = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
                            if (insertprod)
                            {
                                int count = 0;
                                int diff = quantity - count;

                                if (diff > 0)
                                {
                                    int start = 0;
                                    while (start < diff)
                                    {
                                        string serialnumber = GenerateRandomSerialNumber();
                                        string query1 = string.Format("INSERT INTO SerialNoTable (ProductId,SerialNo,CreatedAt,CreatedDay,InvoiceNo) " +
                                    "VALUES ('" + productid + "','" + serialnumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                    "'" + System.DateTime.Now.DayOfWeek + "','" + invoiceNo + "')");

                                        start++;
                                    }
                                }
                            }
                        }
                        isInserted = true;
                    }
                }
 

                if(isInserted == true)
                {
                    InvoiceReportView invoiceReport = new InvoiceReportView(invoiceNo);
                    invoiceReport.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(invoiceReport);
                    invoiceReport.Show();
                    this.Close();
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool isInserted = false;

            try
            {
                // Backup current data
                InsertBackUpData(invoiceNo, invoiceCode);

                // Delete existing invoice details
                DeleteInvoiceDetail(invoiceNo, "InvoiceDetailsTable");

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
                        bool insertprod = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
                        if (!insertprod)
                        {
                            throw new Exception($"Failed to insert product details for ProductID: {productid}");
                        }

                        // Handle serial numbers for the product
                        DeleteInvoiceDetail(invoiceNo, "SerialNoTable");

                        int count = 0; // Replace with actual count if available
                        int diff = quantity - count;

                        if (diff > 0)
                        {
                            for (int i = 0; i < diff; i++)
                            {
                                string serialnumber = GenerateRandomSerialNumber();
                                string query1 = string.Format(
                                    "INSERT INTO SerialNoTable (ProductId, SerialNo, CreatedAt, CreatedDay, InvoiceNo) " +
                                    "VALUES ({0}, '{1}', '{2}', '{3}', '{4}')",
                                    productid, serialnumber, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Now.DayOfWeek, invoiceNo);

                                // Execute the serial number insertion query
                                if (!DatabaseAccess.ExecuteNonQuery(query1))
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
                    CommonFunction.DisposeOnClose(invoiceReport);
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

        private void InsertBackUpData(string invoiceNo, string invoicecode)
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

                    // Execute the insert query for each row
                    bool isSuccess = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
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
        public static string GenerateRandomSerialNumber()
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

                // Retrieving the count of existing serial numbers
                DataTable dt = DatabaseAccess.Retrive(query, parameters);

                if (dt != null && dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) == 0)
                {
                    // If no record with this serial number exists, it's unique
                    isUnique = true;
                }
            }

            return serialNumber;

        }
        private void PurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
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



        private void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm selectionForm = new SupplierSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    // Use lambda for event handler
                    selectionForm.FormClosed += (s, args) => UpdateSupplierTextBox();

                    // Dispose the form properly when it's closed
                    CommonFunction.DisposeOnClose(selectionForm);
                    selectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private void UpdateProductTextBox()
        {
            try
            {
                // Ensure that the global variables have valid values before updating the text boxes
                if (!string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) &&
                    !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) &&
                    GlobalVariables.productidglobal > 0)
                {
                    selectproducttxtbox.Text = GlobalVariables.productnameglobal;
                    mfrtxtbox.Text = GlobalVariables.productmfrglobal;
                    productidlbl.Text = GlobalVariables.productidglobal.ToString();
                }
                else
                {
                    // Optionally, handle cases where values are invalid
                    MessageBox.Show("Product information is incomplete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating product information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSupplierTextBox()
        {
            try
            {
                // Ensure that the global variables have valid values before updating the text boxes
                if (!string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) &&
                    !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) &&
                    GlobalVariables.supplieridglobal > 0)
                {
                    supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
                    selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                    codetxtbox.Text = GlobalVariables.suppliercodeglobal;
                    companytxtbox.Text = GlobalVariables.suppliercompanyName;
                }
                else
                {
                    // Optionally, handle cases where values are invalid
                    MessageBox.Show("Supplier information is incomplete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the product textbox is empty
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    // Check if the ProductSelectionForm is already open
                    Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        // Create and show a new ProductSelectionForm
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Add event handler to update product details when the form is closed
                        productSelectionForm.FormClosed += delegate
                        {
                            UpdateProductTextBox();
                        };

                        // Dispose of the form when it's closed
                        CommonFunction.DisposeOnClose(productSelectionForm);

                        // Show the product selection form as a dialog
                        productSelectionForm.ShowDialog();
                    }
                    else
                    {
                        // Bring the already open form to the front
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
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
            if (invoicerefrencetxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                    {
                        // Check if the SupplierSelectionForm is already open
                        Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                        if (openForm == null)
                        {
                            // Create and show the SupplierSelectionForm
                            SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Add event handler to update supplier details when the form is closed
                            supplierSelection.FormClosed += delegate
                            {
                                UpdateSupplierTextBox();
                            };

                            // Dispose of the form when it's closed
                            CommonFunction.DisposeOnClose(supplierSelection);

                            // Show the SupplierSelectionForm as a dialog
                            supplierSelection.ShowDialog();
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

        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                    {
                        // Check if the ProductSelectionForm is already open
                        Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                        if (openForm == null)
                        {
                            // Create and show the ProductSelectionForm
                            ProductSelectionForm productSelection = new ProductSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Add event handler to update product details when the form is closed
                            productSelection.FormClosed += delegate
                            {
                                UpdateProductTextBox();
                            };

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

        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(8,dgvpurchaseproducts,totalvattxtbox);
            CommonFunction.CalculateTotalColumn(9,dgvpurchaseproducts,nettotaltxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7,dgvpurchaseproducts,totaldiscounttxtbox);
        }
        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(8, dgvpurchaseproducts, totalvattxtbox);
            CommonFunction.CalculateTotalColumn(9, dgvpurchaseproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvpurchaseproducts, totaldiscounttxtbox);
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            AddProductToGrid();
        }

        private void AddProductToGrid()
        {
            try
            {
                // Validate inputs first
                if (IsInputValid())
                {
                    // Parse and assign the input values
                    string mfr = mfrtxtbox.Text;
                    string productid = productidlbl.Text;
                    string productname = selectproducttxtbox.Text;
                    string qty = qtytxtbox.Text;

                    int unitid = TryParseInt(unitidlbl.Text);
                    string unitname = unitnamelbl.Text;

                    decimal vatamount = TryParseDecimal(productvatlbl.Text);
                    decimal discount = TryParseDecimal(productdiscountlbl.Text);
                    float unitprice = TryParseFloat(unitsalepricelbl.Text);
                    decimal finalitemwise = TryParseDecimal(totalcolumnlbl.Text);
                    int warehouseid = TryParseInt(warehouseidlbl.Text);
                    string itemwisedescription = itemdescriptionlbl.Text;

                    decimal lengthinmeterproduct = TryParseDecimal(lengthinmeterlbl.Text);
                    decimal priceinmeter = TryParseDecimal(pricepermeterlbl.Text);
                    decimal costpriceitem = TryParseDecimal(costpricelbl.Text);


                    // Check if the product exists in the DataGridView and update quantity if necessary
                    if (!UpdateProductQuantity(productid, unitprice, qty))
                    {
                        // If product doesn't exist, add a new row to the DataGridView
                        dgvpurchaseproducts.Rows.Add(mfr, productid, productname, qty, unitid, unitname, unitprice, discount, vatamount,
                                                      finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter,
                                                      costpriceitem);
                    }

                    // Reset input fields and global variables
                    ResetFields();
                    ResetGlobalVariables();
                    selectproducttxtbox.Focus();
                }
                else
                {
                    // Show validation error message
                    MessageBox.Show("Please fill in all the required fields (Manufacturer, Product, and Quantity).",
                                    "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInputValid()
        {
            // Check if required fields are not empty or whitespace
            return !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) &&
                   !string.IsNullOrEmpty(qtytxtbox.Text) &&
                   !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                   !string.IsNullOrWhiteSpace(qtytxtbox.Text);
        }

        private int TryParseInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                // Return default value (0) in case of parsing failure
                return 0;
            }
        }

        private decimal TryParseDecimal(string value)
        {
            decimal result;
            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                // Return default value (0) in case of parsing failure
                return 0;
            }
        }

        private float TryParseFloat(string value)
        {
            float result;
            if (float.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                // Return default value (0) in case of parsing failure
                return 0;
            }
        }

        private bool UpdateProductQuantity(string productid, float unitprice, string qty)
        {
            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (!row.IsNewRow &&
                    row.Cells["productidcolumn"].Value?.ToString() == productid &&
                    float.TryParse(row.Cells["salepricecolumn"].Value?.ToString(), out float cellPrice) &&
                    cellPrice == unitprice)
                {
                    // Update the quantity
                    if (int.TryParse(row.Cells["qtycolumn"].Value?.ToString(), out int currentQuantity) &&
                        int.TryParse(qty, out int additionalQuantity))
                    {
                        row.Cells["qtycolumn"].Value = currentQuantity + additionalQuantity;
                        return true; // Product exists and quantity was updated
                    }
                }
            }
            return false; // Product does not exist
        }


        private void ResetFields()
        {
            mfrtxtbox.Text = string.Empty;
            selectproducttxtbox.Text = string.Empty;
            productidlbl.Text = string.Empty;
            qtytxtbox.Text = string.Empty;
        }

        private void ResetGlobalVariables()
        {
            GlobalVariables.unitidglobal = 0;
            GlobalVariables.productpriceglobal = 0;
            GlobalVariables.productitemwisevatamount = 0;
            GlobalVariables.productdiscountamountitemwise = 0;
            GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
            GlobalVariables.warehouseidglobal = 0;
            GlobalVariables.productitemwisedescriptiongloabl = string.Empty;
            GlobalVariables.productinmeterlength = 0;
            GlobalVariables.productinmeterprice = 0;
            GlobalVariables.productcostprice = 0;
        }



        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void salepricetxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dgvpurchaseproducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if there are any rows and at least one row is selected
                if (dgvpurchaseproducts != null && dgvpurchaseproducts.SelectedRows.Count > 0)
                {
                    // Access the first selected row
                    var selectedRow = dgvpurchaseproducts.SelectedRows[0];

                    // Safely retrieve the values from the selected row
                    mfrtxtbox.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                    productidlbl.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                    selectproducttxtbox.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
                    qtytxtbox.Text = selectedRow.Cells[3].Value?.ToString() ?? string.Empty;
                    unitidlbl.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;
                    unitnamelbl.Text = selectedRow.Cells[5].Value?.ToString() ?? string.Empty;
                    unitsalepricelbl.Text = selectedRow.Cells[6].Value?.ToString() ?? string.Empty;
                    productdiscountlbl.Text = selectedRow.Cells[8].Value?.ToString() ?? string.Empty;
                    productvatlbl.Text = selectedRow.Cells[7].Value?.ToString() ?? string.Empty;
                    totalcolumnlbl.Text = selectedRow.Cells[9].Value?.ToString() ?? string.Empty;
                    warehouseidlbl.Text = selectedRow.Cells[10].Value?.ToString() ?? string.Empty;
                    itemdescriptionlbl.Text = selectedRow.Cells[11].Value?.ToString() ?? string.Empty;
                    lengthinmeterlbl.Text = selectedRow.Cells[12].Value?.ToString() ?? string.Empty;
                    pricepermeterlbl.Text = selectedRow.Cells[13].Value?.ToString() ?? string.Empty;
                    costpricelbl.Text = selectedRow.Cells[14].Value?.ToString() ?? string.Empty;

                    // Remove the selected row(s) from the DataGridView
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
                    // If no rows are selected, prompt the user to select a row
                    MessageBox.Show("Please select a row first.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show a message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvpurchaseproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CommonFunction.CalculateTotalVatColumn(8, dgvpurchaseproducts, totalvattxtbox);
            CommonFunction.CalculateTotalColumn(9, dgvpurchaseproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvpurchaseproducts, totaldiscounttxtbox);
        }

        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                // Validate if the quantity entered is a valid number and greater than 0
                if (int.TryParse(qtytxtbox.Text, out int itemqty) && itemqty > 0)
                {
                    // Query to retrieve warehouse data from the database
                    string getwarehousedata = "SELECT WarehouseID, Name FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null && warehousedata.Rows.Count > 0)
                    {
                        // Create and display the WarehouseSelection form if warehouse data is available
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

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


        private void WarehouseSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Ensure sender is of expected type and dispose of it
                if (sender is WarehouseSelection warehouseSelection)
                {
                    CommonFunction.DisposeOnClose(warehouseSelection);

                    // Create and show VATForm after WarehouseSelection is closed
                    if (int.TryParse(qtytxtbox.Text, out int itemQty) && itemQty > 0)
                    {
                        VATForm vATForm = new VATForm(itemQty, true)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Update product data when VATForm is closed
                        vATForm.FormClosed += (s, args) => UpdateProductData();

                        // Apply DisposeOnClose to VATForm
                        CommonFunction.DisposeOnClose(vATForm);
                        vATForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Unexpected form closed event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Provide detailed error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateProductData()
        {
            try
            {
                // Check if the global variables contain valid values before updating UI
                warehouseidlbl.Text = GlobalVariables.warehouseidglobal > 0 ? GlobalVariables.warehouseidglobal.ToString() : "N/A";
                itemdescriptionlbl.Text = !string.IsNullOrEmpty(GlobalVariables.productitemwisedescriptiongloabl) ? GlobalVariables.productitemwisedescriptiongloabl : "No Description";

                unitsalepricelbl.Text = GlobalVariables.productpriceglobal > 0
                    ? GlobalVariables.productpriceglobal.ToString() // Format as currency
                    : "0.00";

                pricepermeterlbl.Text = GlobalVariables.productinmeterprice > 0
                    ? GlobalVariables.productinmeterprice.ToString() // Format as decimal with 2 places
                    : "0.00";

                lengthinmeterlbl.Text = GlobalVariables.productinmeterlength > 0
                    ? GlobalVariables.productinmeterlength.ToString() // Format as decimal with 2 places
                    : "0.00";

                totalcolumnlbl.Text = GlobalVariables.productfinalamountwithvatanddiscountitemwise > 0
                    ? GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString() // Format as currency
                    : "0.00";

                unitnamelbl.Text = !string.IsNullOrEmpty(GlobalVariables.unitnameglobal) ? GlobalVariables.unitnameglobal : "Unit Name";
                unitidlbl.Text = GlobalVariables.unitidglobal > 0 ? GlobalVariables.unitidglobal.ToString() : "0";

                productdiscountlbl.Text = GlobalVariables.productdiscountamountitemwise > 0
                    ? GlobalVariables.productdiscountamountitemwise.ToString() // Format as currency
                    : "0.00";

                productvatlbl.Text = GlobalVariables.productitemwisevatamount > 0
                    ? GlobalVariables.productitemwisevatamount.ToString() // Format as currency
                    : "0.00";

                itemsalepricelbl.Text = GlobalVariables.productsaleprice > 0
                    ? GlobalVariables.productsaleprice.ToString() // Format as currency
                    : "0.00";

                costpricelbl.Text = GlobalVariables.productcostprice > 0
                    ? GlobalVariables.productcostprice.ToString() // Format as currency
                    : "0.00";

            }
            catch (Exception ex)
            {
                // Optionally log or display a message in case of errors
                MessageBox.Show($"An error occurred while updating product data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteInvoiceDetail(string invoiceNo, string tableName)
        {
            try
            {
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

                // Assuming ExecuteQuery is handling database connections, you might want to ensure the connection is disposed
                DatabaseAccess.ExecuteQuery(tableName, "DELETE", columnData, whereClause);
            }
            catch (ArgumentException argEx)
            {
                // Handle argument exceptions specifically
                MessageBox.Show($"Invalid argument: {argEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL exceptions specifically (assuming you're using SQL)
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Generic error handling with more context
                MessageBox.Show($"An error occurred while deleting invoice details. InvoiceNo: {invoiceNo}, TableName: {tableName}, Error: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void removevatchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (removevatchkbox.Checked)
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
            }
        }

    }
}
