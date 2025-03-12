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
    public partial class PurchaseOrder : Form
    {
        private decimal initalizer = 0;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        public PurchaseOrder(DataTable dtinvoice, DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }

        private async void PurchaseOrderInvoice_Load(object sender, EventArgs e)
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
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;
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
                    // Initialize form with default values if the data is empty or null
                    totaldiscounttxtbox.Text = initalizer.ToString("N2");
                    totalvattxtbox.Text = initalizer.ToString("N2");
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    invoicenotxtbox.Text = await Task.Run(() => GenerateNextInvoiceNumber());
                }
            }
            catch (Exception ex)
            {
                // General exception handling
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
                        if (dgvpurchaseproducts.Columns.Contains("unitname"))
                        {
                            newRow.Cells[dgvpurchaseproducts.Columns["unitname"].Index].Value = SafeConvertToString(invoiceRow["UnitName"]);
                        }
                        newRow.Cells[dgvpurchaseproducts.Columns["pricepermetercolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["PricePerMeter"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["productid"].Index].Value = SafeConvertToInt(invoiceRow["Productid"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["qtycolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["Quantity"]);
                        newRow.Cells[dgvpurchaseproducts.Columns["unitidcolumn"].Index].Value = SafeConvertToInt(invoiceRow["Unitid"]);
                        
                        newRow.Cells[dgvpurchaseproducts.Columns["vatpercentagecolumn"].Index].Value = SafeConvertToDecimal(invoiceRow["VatCode"]);
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

        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                const string InvoicePrefix = "PO";
                string datePart = DateTime.Today.ToString("yyMMdd");
                string lastInvoiceNumber = await GetLastInvoiceNumber();

                if (string.IsNullOrEmpty(lastInvoiceNumber))
                {
                    // Start with the first invoice if no previous invoice exists
                    return GenerateInvoiceNumber(InvoicePrefix, datePart, 1);
                }

                // Extract and increment the sequential part from the last invoice
                int lastSequentialNumber = ExtractSequentialNumber(lastInvoiceNumber);
                return GenerateInvoiceNumber(InvoicePrefix, datePart, lastSequentialNumber + 1);
            }
            catch (FormatException formatEx)
            {
                LogError(formatEx);
                MessageBox.Show("An error occurred while processing the invoice format.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An unexpected error occurred while generating the invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string GenerateInvoiceNumber(string prefix, string datePart, int sequentialNumber)
        {
            return $"{prefix}-{datePart}-{sequentialNumber:D5}";
        }

        private int ExtractSequentialNumber(string invoiceNumber)
        {
            try
            {
                // Extract the sequential part from the last invoice number
                string sequentialPart = invoiceNumber.Substring(invoiceNumber.LastIndexOf('-') + 1);
                return int.Parse(sequentialPart);
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to extract sequential number from the invoice.", ex);
            }
        }

        private void LogError(Exception ex)
        {
            // Log error details for debugging purposes
            Debug.WriteLine($"Error: {ex.Message}");
            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
        }


        private async Task<string> GetLastInvoiceNumber()
        {
            try
            {
                const string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PO-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);

                if (invoiceData?.Rows.Count > 0)
                {
                    return invoiceData.Rows[0]["InvoiceNo"].ToString();
                }

                return null; // Return null if no matching rows are found
            }
            catch (Exception ex)
            {
                LogError(ex); // Log the error for debugging purposes
                MessageBox.Show("An error occurred while retrieving the last invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                // Retrieve the last invoice number from the database
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Validate the new invoice number input
                if (string.IsNullOrWhiteSpace(newInvoiceNumber))
                {
                    throw new InvalidOperationException("Invoice number cannot be empty or null.");
                }

                // If no last invoice exists, or the new invoice number is valid, return the new invoice number
                if (string.IsNullOrEmpty(lastInvoiceNumber) || String.Compare(newInvoiceNumber, lastInvoiceNumber, StringComparison.Ordinal) > 0)
                {
                    return newInvoiceNumber;
                }

                // If the new invoice number is not valid, generate the next invoice number
                return await GenerateNextInvoiceNumber();
            }
            catch (InvalidOperationException ex)
            {
                // Handle validation-related errors
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                // Log unexpected errors and notify the user
                LogError(ex);
                MessageBox.Show("An unexpected error occurred while validating the invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(currencyidlbl.Text) && currencyidlbl.Text != "currencyidlbl" 
                    && !string.IsNullOrEmpty(currencynamelbl.Text) && currencynamelbl.Text != "currencynamelbl"
                    && !string.IsNullOrEmpty(currencysymbollbl.Text) && currencysymbollbl.Text != "currencysymbollbl"
                    && !string.IsNullOrEmpty(currencyconversionratelbl.Text) && currencyconversionratelbl.Text != "currencyconversionratelbl")
                {
                    errorProvider.Clear();
                    bool isInserted = false;
                    string invoiceno = string.Empty;

                    if (selectsuppliertxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(selectsuppliertxtbox, "Please Select Supplier");
                        selectsuppliertxtbox.Focus();
                        return;
                    }

                    if (dgvpurchaseproducts.Rows.Count == 0)
                    {
                        errorProvider.SetError(dgvpurchaseproducts, "Please Select Products");
                        selectproducttxtbox.Focus();
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
                        invoiceno = invoicenotxtbox.Text;
                        string invoiceCode = invoicecodelbl.Text;
                        isInserted = await UpdateProductOrder(invoiceno, invoiceDate, invoiceCode);
                    }
                    else
                    {
                        invoiceno = await CheckInvoiceBeforeInsert();
                        isInserted = await AddPurchaseOrder(invoiceno, invoiceDate);
                    }

                    if (isInserted)
                    {
                        OrderReportView orderReport = new OrderReportView(invoiceno);
                        orderReport.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(orderReport);
                        orderReport.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency.");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task<bool> UpdateProductOrder(string invoiceno, DateTime invoiceDate, string invoicecode)
        {
            int supplierId = Convert.ToInt32(supplieridlbl.Text);
            string suppliercode = codetxtbox.Text;
            string supplierName = selectsuppliertxtbox.Text;

            // Parse and round values
            float nettotal = (float)Math.Ceiling(float.Parse(nettotaltxtbox.Text) * 100) / 100;
            float totalvat = (float)Math.Ceiling(float.Parse(totalvattxtbox.Text) * 100) / 100;
            float totaldiscount = (float)Math.Ceiling(float.Parse(totaldiscounttxtbox.Text) * 100) / 100;

            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";
            string whereClause = $"InvoiceNo = '{invoiceno}'";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceno },
                { "invoicedate", invoiceDate },
                { "ClientID", supplierId },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "InvoiceCode", invoicecode },
                { "NetTotal", nettotal },
                { "ClientName", supplierName },
                { "TotalDiscount", totaldiscount },
                { "TotalVat", totalvat },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate },
                { "AddedBy", "JEAN" },
                { "InvoiceType", "Order" }
            };

            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            if (!isUpdated) return false;

            // Collect all records before updating invoice details
            var recordsToInsert = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) continue;

                int productid = string.IsNullOrEmpty(row.Cells["productid"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["productid"].Value.ToString());
                int quantity = string.IsNullOrEmpty(row.Cells["qtycolumn"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                string productname = string.IsNullOrEmpty(row.Cells["productnamecolumn"].Value?.ToString()) ? string.Empty : row.Cells["productnamecolumn"].Value.ToString();
                string mfr = string.IsNullOrEmpty(row.Cells["codecolumn"].Value?.ToString()) ? string.Empty : row.Cells["codecolumn"].Value.ToString();
                int unitid = string.IsNullOrEmpty(row.Cells["unitidcolumn"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                string itemdescription = string.IsNullOrEmpty(row.Cells["itemdescriptioncolumn"].Value?.ToString()) ? string.Empty : row.Cells["itemdescriptioncolumn"].Value.ToString();

                float itemVat = string.IsNullOrEmpty(row.Cells["vatcolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["vatcolumn"].Value.ToString()) * 100) / 100;
                float itemdiscount = string.IsNullOrEmpty(row.Cells["discountcolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["discountcolumn"].Value.ToString()) * 100) / 100;
                float pricepermeter = string.IsNullOrEmpty(row.Cells["pricepermetercolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["pricepermetercolumn"].Value.ToString()) * 100) / 100;
                float lengthinmeter = string.IsNullOrEmpty(row.Cells["lengthinmetercolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString()) * 100) / 100;
                float total = string.IsNullOrEmpty(row.Cells["totalcolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["totalcolumn"].Value.ToString()) * 100) / 100;
                float costprice = string.IsNullOrEmpty(row.Cells["pricecolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["pricecolumn"].Value.ToString()) * 100) / 100;
                float vatpercentage = string.IsNullOrEmpty(row.Cells["vatpercentagecolumn"].Value?.ToString()) ? 0 : (float)Math.Ceiling(float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString()) * 100) / 100;

                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceno },
                    { "Invoicecode", invoicecode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "UnitSalePrice", costprice },
                    { "ProductName", productname },
                    { "ItemWiseDiscount", itemdiscount },
                    { "ItemTotal", total },
                    { "MFR", mfr },
                    { "MinusInventory", false },
                    { "Unitid", unitid },
                    { "ItemWiseVAT", itemVat },
                    { "ItemDescription", itemdescription },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "AddInventory", false },
                    { "VatCode", vatpercentage }
                };

                recordsToInsert.Add(subColumnData);
            }

            // Now update invoice details
            bool isoldrecord = await UpdateInvoiceDetail(invoiceno);
            if (!isoldrecord) return false;

            // Insert collected records
            string subtable = "InvoiceDetailsTable";
            bool isInserted = false;
            foreach (var record in recordsToInsert)
            {
                isInserted = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", record);
                if (!isInserted) break; // Stop if any insert fails
            }
            return true;
        }


        private async Task<bool> AddPurchaseOrder(string invoiceno,DateTime invoiceDate)
        {
            bool isInserted = false;
            string invoicecode = Guid.NewGuid().ToString();
            int supplierId = Convert.ToInt32(supplieridlbl.Text);
            string suppliercode = codetxtbox.Text;
            string supplierName = selectsuppliertxtbox.Text;
            // Parse and round the net total to 2 decimal places
            float nettotal = (float)Math.Ceiling(float.Parse(nettotaltxtbox.Text) * 100) / 100;

            // Parse and round the total VAT to 2 decimal places
            float totalvat = (float)Math.Ceiling(float.Parse(totalvattxtbox.Text) * 100) / 100;
            float totaldiscount = (float)Math.Ceiling(float.Parse(totaldiscounttxtbox.Text) * 100) / 100;


            int currencyid = Convert.ToInt32(currencyidlbl.Text);
            string currencyname = currencynamelbl.Text;
            string currencyconversionrate = currencyconversionratelbl.Text;
            string currencysymbol = currencysymbollbl.Text;

            string tableName = "InvoiceTable";

            var columnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceno },
                { "invoicedate", invoiceDate },
                { "ClientID", supplierId },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek },
                { "InvoiceCode", invoicecode },
                { "NetTotal", nettotal },
                { "ClientName", supplierName },
                { "TotalDiscount", totaldiscount },
                { "TotalVat", totalvat },
                { "Currencyid", currencyid },
                { "CurrencyName", currencyname },
                { "CurrencySymbol", currencysymbol },
                { "ConversionRate", currencyconversionrate },
                { "AddedBy", "JEAN" },
                { "InvoiceType", "Order" }
            };

            bool insertorder = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
            if (insertorder)
            {
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (row.IsNewRow) { continue; }

                    int productid = string.IsNullOrEmpty(row.Cells["productid"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["productid"].Value);
                    int quantity = string.IsNullOrEmpty(row.Cells["qtycolumn"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["qtycolumn"].Value);
                    string productname = row.Cells["productnamecolumn"].Value?.ToString() ?? string.Empty;
                    string mfr = row.Cells["codecolumn"].Value?.ToString() ?? string.Empty;
                    int unitid = string.IsNullOrEmpty(row.Cells["unitidcolumn"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["unitidcolumn"].Value);
                    string itemdescription = row.Cells["itemdescriptioncolumn"].Value?.ToString() ?? string.Empty;

                    float itemVat = string.IsNullOrEmpty(row.Cells["vatcolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["vatcolumn"].Value.ToString()) * 100) / 100;
                    float itemdiscount = string.IsNullOrEmpty(row.Cells["discountcolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["discountcolumn"].Value.ToString()) * 100) / 100;
                    float pricepermeter = string.IsNullOrEmpty(row.Cells["pricepermetercolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["pricepermetercolumn"].Value.ToString()) * 100) / 100;
                    float lengthinmeter = string.IsNullOrEmpty(row.Cells["lengthinmetercolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["lengthinmetercolumn"].Value.ToString()) * 100) / 100;
                    float total = string.IsNullOrEmpty(row.Cells["totalcolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["totalcolumn"].Value.ToString()) * 100) / 100;
                    float costprice = string.IsNullOrEmpty(row.Cells["pricecolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["pricecolumn"].Value.ToString()) * 100) / 100;
                    float vatpercentage = string.IsNullOrEmpty(row.Cells["vatpercentagecolumn"].Value?.ToString()) ? 0f : (float)Math.Ceiling(float.Parse(row.Cells["vatpercentagecolumn"].Value.ToString()) * 100) / 100;


                    string subtable = "InvoiceDetailsTable";
                    var subColumnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "Invoicecode", invoicecode },
                        { "Productid", productid },
                        { "Quantity", quantity },
                        { "UnitSalePrice", costprice },
                        { "ProductName", productname },
                        { "ItemWiseDiscount", itemdiscount },
                        { "ItemTotal", total },
                        { "MFR", mfr },
                        { "MinusInventory", false },
                        { "Unitid", unitid },
                        { "ItemWiseVAT",itemVat },
                        { "ItemDescription",itemdescription },
                        { "PricePerMeter",pricepermeter },
                        { "LengthInMeter",lengthinmeter },
                        { "AddInventory",false },
                        { "VatCode", vatpercentage }
                    };

                    isInserted = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);

                }
            }
            return isInserted;
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


        private void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new instance of the PurchaseOrder form
                PurchaseOrder purchaseOrderInvoice = new PurchaseOrder
                {
                    MdiParent = this.MdiParent
                };

                // Ensure the form gets disposed properly when closed
                CommonFunction.DisposeOnClose(purchaseOrderInvoice);

                // Show the new form
                purchaseOrderInvoice.Show();
            }
            catch (Exception ex)
            {
                // Log the error or show an error message to the user
                MessageBox.Show($"An error occurred while opening the Purchase Order form: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
                // Check if the Control key and D key are pressed
                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Check if at least one row is selected
                    if (dgvpurchaseproducts.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("No row selected. Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ensure that the selected row has a valid product ID
                    int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells["productid"].Value);
                    if (productid > 0)
                    {
                        // Create a list to store rows to remove
                        var rowsToRemove = new List<DataGridViewRow>();

                        foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                rowsToRemove.Add(row);
                            }
                        }

                        // Remove rows outside of the loop to avoid modifying the collection while iterating
                        foreach (var row in rowsToRemove)
                        {
                            dgvpurchaseproducts.Rows.Remove(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select a valid product row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.KeyCode == Keys.E)
                {
                    HandleRowSelectionAsync();
                }
        }


        private void PurchaseOrderInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Check if the Escape key is pressed
                if (e.KeyCode == Keys.Escape)
                {
                    // If any textboxes are filled, ask for confirmation before closing
                    if (AreAnyTextBoxesFilled())
                    {
                        DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                              "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        // Close the form if 'Yes' is clicked
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                            e.Handled = true; // Prevent further processing
                        }
                    }
                    else
                    {
                        // If no changes were made, just close the form
                        this.Close();
                        e.Handled = true; // Prevent further processing
                    }
                }

                if (e.Control && e.KeyCode == Keys.C)
                {
                    CurrencySelection currencySelection = new CurrencySelection();
                    currencySelection.DataSent += currencySelection_DataSent;
                    currencySelection.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void currencySelection_DataSent(CurrencyData receivedCurrency)
        {
            // Use the received data (e.g., display it in a label)
            currencylbl.Text = receivedCurrency.Name + (" : ") + receivedCurrency.Symbol;
            currencyidlbl.Text = receivedCurrency.CurrencyId.ToString();
            currencynamelbl.Text = receivedCurrency.Name.ToString();
            currencysymbollbl.Text = receivedCurrency.Symbol.ToString();
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }


        private async void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the textbox is empty before opening the form
                if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                {
                    // Check if the SupplierSelectionForm is already open
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));
                    if (openForm == null)
                    {
                        // If not open, create and show the SupplierSelectionForm
                        SupplierSelectionForm supplierSelectionForm = new SupplierSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Attach the FormClosed event to update the supplier info in the textbox
                        supplierSelectionForm.SupplierDataSelected += UpdateSupplierTextBox;

                        // Ensure proper disposal of the form when it is closed
                        CommonFunction.DisposeOnClose(supplierSelectionForm);
                        supplierSelectionForm.ShowDialog();
                    }
                    else
                    {
                        // If already open, bring it to the front
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private bool AreAnyTextBoxesFilled()
        {
            try
            {
                // Check if the supplier textbox is filled
                if (!string.IsNullOrWhiteSpace(selectsuppliertxtbox.Text))
                {
                    return true;
                }

                // Check if the product textbox is filled
                if (!string.IsNullOrWhiteSpace(selectproducttxtbox.Text))
                {
                    return true;
                }

                // Check if the DataGridView contains any rows
                if (dgvpurchaseproducts != null && dgvpurchaseproducts.Rows.Count > 0)
                {
                    return true;
                }

                // If none of the conditions are met, return false
                return false;
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors and log them (or display to the user)
                MessageBox.Show($"An error occurred while checking if any text boxes are filled: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Return false in case of an error
            }
        }


        private async void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
        }

        private async void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
        }

        private async void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Check if the textbox is empty
                    if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                    {
                        // Check if the SupplierSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(SupplierSelectionForm));

                        // If the form is not open, create and show it
                        if (openForm == null)
                        {
                            SupplierSelectionForm supplierSelectionForm = new SupplierSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            // Event handler for when the form is closed
                            supplierSelectionForm.SupplierDataSelected += UpdateSupplierTextBox;

                            // Ensure the form is disposed of when closed
                            CommonFunction.DisposeOnClose(supplierSelectionForm);
                            supplierSelectionForm.ShowDialog();
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
                // Handle any exceptions that may occur and show a message box
                MessageBox.Show($"An error occurred while handling the supplier textbox: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the product textbox is empty
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    // Check if the ProductSelectionForm is already open
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

                    // If the form is not open, create and show it
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        productSelectionForm.ProductDataSelected += UpdateProductTextBox;

                        // Ensure the form is disposed of when closed
                        CommonFunction.DisposeOnClose(productSelectionForm);
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
                // Handle any exceptions that may occur and show a message box
                MessageBox.Show($"An error occurred while handling the product textbox: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Check if the Enter key is pressed
                if (e.KeyCode == Keys.Enter)
                {
                    // If the product textbox is empty
                    if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                    {
                        // Check if the ProductSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

                        // If the form is not open, create and show it
                        if (openForm == null)
                        {
                            ProductSelectionForm productSelection = new ProductSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            productSelection.ProductDataSelected += UpdateProductTextBox;

                            // Ensure the form is disposed of when closed
                            CommonFunction.DisposeOnClose(productSelection);
                            productSelection.Show();
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
                // Handle any exceptions and show an error message
                MessageBox.Show($"An error occurred while handling the product textbox: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all required fields are filled
                if (!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text))
                {
                    // Parse values from the UI and handle potential conversion errors
                    try
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
                        string availabilitystatus = availabilitystatuslbl.Text;
                        bool discounttype = Convert.ToBoolean(discounttypelbl.Text);
                        int warehouseid = Convert.ToInt32(warehouseidlbl.Text);

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
                                    // Update the quantity (integer value remains as is)
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
                            dgvpurchaseproducts.Rows.Add("", mfr, productid, productname, qty,availabilitystatus, unitid, unitname, unitprice.ToString("N2"), vatamount.ToString("N2"), discount.ToString("N2")
                                , finalitemwise.ToString("N2"),warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter, vatpercentage, discountpercentage, discounttype);
                        }

                        ResetLabelData();
                    }
                    catch (FormatException ex)
                    {
                        // Catch format errors (e.g., invalid number formats)
                        MessageBox.Show($"Error: Invalid format in input fields. Please check the values entered. \nDetails: {ex.Message}",
                                        "Invalid Data Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Catch any other general errors
                        MessageBox.Show($"An error occurred while processing your request. \nDetails: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Show a message box if any required field is empty
                    MessageBox.Show("Please fill all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors
                MessageBox.Show($"An unexpected error occurred. Please try again. \nDetails: {ex.Message}",
                                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            unitidlbl.Text = string.Empty;
            pricepermeterlbl.Text = string.Empty;
            vatcodelbl.Text = string.Empty;
            discountpercentagelbl.Text = string.Empty;
            selectproducttxtbox.Focus();
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Allow control characters (e.g., backspace, delete, etc.) and digits
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // Block the invalid character and show a message box
                    e.Handled = true;
                    MessageBox.Show("Please enter only numeric values for quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors gracefully
                MessageBox.Show($"An error occurred while processing your input. \nDetails: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void dgvpurchaseproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            await CommonFunction.CalculateTotalColumnAsync(11, dgvpurchaseproducts, nettotaltxtbox);
            await CommonFunction.CalculateTotalDiscountColumnAsync(10, dgvpurchaseproducts, totaldiscounttxtbox);
            await CommonFunction.CalculateTotalVatColumnAsync(9, dgvpurchaseproducts, totalvattxtbox);
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

        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                // Ensure that the text in qtytxtbox is numeric and valid before proceeding
                if (int.TryParse(qtytxtbox.Text, out int itemqty))
                {
                    // Check if the quantity is greater than zero
                    if (itemqty > 0)
                    {
                        // Create a new VATForm with the item quantity
                        VATForm vATForm = new VATForm(itemqty, false)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        // Hook up the FormClosed event to update product data after closing VATForm
                        vATForm.FormClosed += async delegate
                        {
                            await UpdateProductDataAsync();
                        };

                        // Dispose VATForm when it's closed to release resources
                        CommonFunction.DisposeOnClose(vATForm);
                        vATForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Quantity must be greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors gracefully
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
    }
}
