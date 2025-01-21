using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Common
{
    public class CommonFunction
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static async Task GetSupplierAsync(string searchValue, DataGridView dgv)
        {
            try
            {
                string query = @"SELECT AccountSubControlTable.AccountSubControlID [ID],AccountSubControlTable.CodeAccount [Code],AccountSubControlTable.AccountSubControlName [Account Name],
                    AccountSubControlTable.CompanyName [Company Name],AccountSubControlTable.MobileNo [Mobile],AccountSubControlTable.Email [Email],AccountSubControlTable.CreatedAt [Created],
                    AccountSubControlTable.CreatedDay [Day] FROM AccountSubControlTable WHERE IsSupplier = @IsSupplier";

                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    query += @"AND (AccountSubControlTable.AccountSubControlName LIKE @SearchValue OR AccountSubControlTable.CompanyName LIKE @SearchValue)";
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Adding parameters to the query to prevent SQL injection
                        command.Parameters.AddWithValue("@IsSupplier", true);
                        command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                dgv.DataSource = dt;
                                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                            else
                            {
                                MessageBox.Show("No suppliers found matching the search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL error details
                MessageBox.Show($"A database error occurred: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Catch other errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Ensuring that the method returns a completed task
            await Task.CompletedTask;
        }

        public static async Task GetItemSerialNoAsync(string searchValue, int searchId, DataGridView dgv)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(searchValue) && searchId > 0)
                {
                    string query = @"SELECT SerialNOID, ProductId, SerialNo FROM SerialNoTable WHERE ProductId = @SearchId AND IsSold = @IsSold";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(query, connection))
                        {
                            // Add parameters to the query to prevent SQL injection
                            command.Parameters.AddWithValue("@SearchId", searchId);
                            command.Parameters.AddWithValue("@IsSold", false);

                            await connection.OpenAsync(); // Use asynchronous method to open the connection
                            using (var reader = await command.ExecuteReaderAsync()) // Asynchronous reader execution
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);

                                if (dt.Rows.Count > 0)
                                {
                                    dgv.DataSource = dt;
                                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                }
                                else
                                {
                                    MessageBox.Show("No available serial numbers found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid search value and search ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return a completed task to ensure the method returns a Task as expected
            await Task.CompletedTask;
        }

        public static async Task GetCustomerAsync(string searchValue, DataGridView dgv)
        {
            try
            {
                string query = @"SELECT AccountSubControlTable.AccountSubControlID [ID],AccountSubControlTable.CodeAccount [Code],AccountSubControlTable.AccountSubControlName [Account Name],
                    AccountSubControlTable.CompanyName [Company Name],AccountSubControlTable.MobileNo [Mobile],AccountSubControlTable.Email [Email],AccountSubControlTable.CreatedAt [Created],
                    AccountSubControlTable.CreatedDay [Day] FROM AccountSubControlTable WHERE IsCustomer = 1";

                // Add search filter if a search value is provided
                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    query += @"AND (AccountSubControlTable.AccountSubControlName LIKE @SearchValue OR AccountSubControlTable.CompanyName LIKE @SearchValue)";
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        if (!string.IsNullOrWhiteSpace(searchValue))
                        {
                            command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                        }

                        await connection.OpenAsync(); // Asynchronous method to open the connection
                        using (var reader = await command.ExecuteReaderAsync()) // Asynchronous reader execution
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            if (dt.Rows.Count > 0)
                            {
                                dgv.DataSource = dt;
                                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                            else
                            {
                                MessageBox.Show("No customers found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task GetProductAsync(string searchValue, DataGridView dgv)
        {
            try
            {
                // Validate the search value and build the query
                string query = string.IsNullOrWhiteSpace(searchValue)
                    ? GetDefaultProductQuery()
                    : BuildSearchQueryProduct(searchValue);

                // Retrieve product data from the database asynchronously
                DataTable dt = await RetrieveDataAsync(query, searchValue);

                // Populate DataGridView with data if available
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    ShowNoResultsMessage();
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An error occurred while retrieving the product data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static string GetDefaultProductQuery()
        {
            // Default query when no search value is provided
            return @"SELECT ProductID [ID], ProductName [TITLE], StandardPrice [PRICE], UPC, EAN, MFR, Barcode [BARCODE] FROM ProductTable";
        }

        public static async Task<DataTable> RetrieveDataAsync(string query, string searchValue)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(searchValue))
                        {
                            command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                        }

                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx);
                throw;  // Rethrow exception to be caught by the calling method
            }
            return dt;
        }


        private static void ShowNoResultsMessage()
        {
            // Show a user-friendly message when no results are found
            MessageBox.Show("No products found matching your search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void LogError(Exception ex)
        {
            // Log errors to a file or a logging system for further investigation
            // For now, we'll just write to a log file
            try
            {
                string logPath = @"C:\Logs\ProductSearchErrors.log";
                string message = $"[{DateTime.Now}] - Error: {ex.Message} \n{ex.StackTrace}\n\n";
                File.AppendAllText(logPath, message);
            }
            catch
            {
                // In case logging fails, we won't let it affect the main flow
            }
        }

        public static async Task GetAccountInfoAsync(string searchValue, DataGridView dgv)
        {
            try
            {
                // Validate search value and build the query
                string query = string.IsNullOrWhiteSpace(searchValue)
                    ? GetDefaultAccountQuery()
                    : BuildSearchQueryAccount(searchValue);

                // Retrieve account data from the database asynchronously
                DataTable dt = await RetrieveDataAsync(query, searchValue);

                // Populate DataGridView with data if available
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].Visible = false;
                    dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    ShowNoResultsMessage();
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An error occurred while retrieving the account data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static string GetDefaultAccountQuery()
        {
            // Default query when no search value is provided
            return @"SELECT AccountSubControlID [ID], AccountHead_ID [HEADID], AccountSubControlName [ACCOUNT NAME], Email [EMAIL], MobileNo [MOBILE], CodeAccount FROM AccountSubControlTable";
        }

        private static string BuildSearchQueryAccount(string searchValue)
        {
            // Build the search query using parameterization to avoid SQL injection
            return @"SELECT AccountSubControlID [ID], AccountHead_ID [HEADID], AccountSubControlName [ACCOUNT NAME], Email [EMAIL], MobileNo [MOBILE], CodeAccount FROM AccountSubControlTable 
                WHERE AccountSubControlName LIKE @SearchValue";
        }

        /*public static async Task GetAccountGroupInfoAsync(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();

                // Check if the search value is null or empty
                if (string.IsNullOrEmpty(searchvalue) || string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountControlID [ID], AccountControlName [Account Name], AccountHead_ID, Alias FROM AccountControlTable";
                }
                else
                {
                    query = "SELECT AccountControlID [ID], AccountControlName [Account Name], AccountHead_ID, Alias FROM AccountControlTable" +
                            " WHERE AccountControlName LIKE @SearchValue";
                }

                // Retrieve data asynchronously
                *//*dt = await DatabaseAccess.RetriveAsync(query, searchvalue);*//*
                dt = null;
                // Populate DataGridView if data is available
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


        /*public static async Task GetProductQtyWarehouseAsync(DataGridView dgv, string productmfr, int productid)
        {
            try
            {
                string getproductinventoryquery = string.Format("SELECT StockTable.WarehouseID [ID], WarehouseTable.Name [Warehouse Name], " +
                    "SUM(COALESCE(StockTable.[Quantity], 0)) + COALESCE(InvoiceDetailsTable.Quantity, 0) AS Quantity " +
                    "FROM StockTable INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = StockTable.Warehouseid " +
                    "LEFT JOIN ProductTable ON ProductTable.ProductID = StockTable.ProductID " +
                    "AND ProductTable.WarehouseID = WarehouseTable.WarehouseID " +
                    "LEFT JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Productid = StockTable.ProductID " +
                    "AND InvoiceDetailsTable.Productid = ProductTable.ProductID " +
                    "AND InvoiceDetailsTable.Warehouseid = WarehouseTable.WarehouseID WHERE StockTable.ProductID = @ProductID " +
                    "AND StockTable.Warehouseid IN (SELECT WarehouseID FROM WarehouseTable) " +
                    "GROUP BY StockTable.ProductID, StockTable.Warehouseid, WarehouseTable.Name, InvoiceDetailsTable.Quantity " +
                    "ORDER BY StockTable.ProductID");

                // Retrieve data asynchronously
                *//*DataTable datainventory = await DatabaseAccess.RetriveAsync(getproductinventoryquery, productid);*//*
                DataTable datainventory = null;
                // Populate DataGridView if data is available
                if (datainventory != null && datainventory.Rows.Count > 0)
                {
                    dgv.DataSource = datainventory;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    MessageBox.Show("No inventory data found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


        /*public static async Task GetTransactionInfoProductAsync(DataGridView dgv, string productmfr, int productid)
        {
            try
            {
                // Create the query string using parameterized SQL to prevent SQL injection
                string query = "SELECT InvoiceTable.Invoiceid [ID], InvoiceTable.InvoiceNo [Invoice No], InvoiceTable.invoicedate [Date], " +
                    "InvoiceTable.ClientID [Client ID], InvoiceTable.ClientName [Client Name], InvoiceDetailsTable.ProductName [Title], " +
                    "InvoiceDetailsTable.ItemSerialNoid [Serial No], InvoiceDetailsTable.ItemWiseDiscount [Discount], " +
                    "InvoiceDetailsTable.ItemWiseVAT [VAT], InvoiceDetailsTable.UnitSalePrice [Price], InvoiceDetailsTable.MFR [MFR], " +
                    "InvoiceDetailsTable.Quantity [Quantity], InvoiceDetailsTable.SystemSerialNoid [System Serial No] FROM InvoiceTable " +
                    "INNER JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Invoicecode = InvoiceTable.InvoiceCode " +
                    "WHERE InvoiceDetailsTable.Productid = @ProductID AND InvoiceTable.ClientID = @ClientID";

                // Retrieve data asynchronously
                DataTable datatransaction = await DatabaseAccess.RetriveAsync(query, productid, GlobalVariables.customeridglobal);

                // Populate DataGridView if data is available
                if (datatransaction != null && datatransaction.Rows.Count > 0)
                {
                    dgv.DataSource = datatransaction;
                }
                else
                {
                    MessageBox.Show("No transactions found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


        public static string BuildSearchQueryProduct(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT ProductID [ID],ProductName [TITLE],StandardPrice [PRICE],UPC,EAN,MFR,Barcode [BARCODE], (");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" + ");
                }
                queryBuilder.Append($"(CASE WHEN ProductName LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN MFR LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN UPC LIKE '%{term}%' THEN 1 ELSE 0 END)");
            }

            queryBuilder.Append(") AS RelevanceScore FROM ProductTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (ProductName LIKE '%{term}%' OR MFR LIKE '%{term}%' OR UPC LIKE '%{term}%')");
            }

            queryBuilder.Append(" ORDER BY RelevanceScore DESC");

            return queryBuilder.ToString();
        }

        public static async Task<Form> IsFormOpenAsync(Type formType)
        {
            return await Task.Run(() =>
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == formType)
                    {
                        return form;
                    }
                }
                return null;
            });
        }


        public static async Task<string> HashPasswordAsync(string password)
        {
            return await Task.Run(() =>
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Convert byte array to a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            });
        }


        public static async Task PopulateCurrencyComboBoxAsync(ComboBox combo)
        {
            // Retrieve data from the database asynchronously
            string query = "SELECT CurrencyId, Symbol, Name, CurrencyString FROM CurrencyTable";
            DataTable dt = await Task.Run(() => DatabaseAccess.RetriveAsync(query));

            List<CurrencyData> currencies = new List<CurrencyData>();

            foreach (DataRow row in dt.Rows)
            {
                CurrencyData currency = new CurrencyData
                {
                    CurrencyId = Convert.ToInt32(row["CurrencyId"]),
                    Symbol = row["Symbol"].ToString(),
                    Name = row["Name"].ToString(),
                    CurrencyString = row["CurrencyString"].ToString()
                };

                currencies.Add(currency);
            }

            // Setting ComboBox data source on the UI thread
            combo.DataSource = currencies;
            combo.DisplayMember = "Name";  // Or whatever you want to display
            combo.ValueMember = "CurrencyId"; // The actual value will be the CurrencyId
        }



        public static async Task FillUnitDataAsync(ComboBox combo)
        {
            try
            {
                // Initialize a DataTable to hold the unit data
                DataTable dtUnit = await InitializeUnitDataTableAsync();

                // Retrieve the unit data from the database asynchronously
                DataTable dt = await Task.Run(() => GetUnitDataFromDatabaseAsync());

                // If data is retrieved successfully, populate the DataTable
                if (dt != null && dt.Rows.Count > 0)
                {
                    PopulateUnitDataTable(dtUnit, dt);
                }

                // Set ComboBox data source on the UI thread
                SetComboBoxDataSource(combo, dtUnit);
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An error occurred while filling the unit data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task FillWarehouseDataAsync(ComboBox combo)
        {
            try
            {
                // Initialize a DataTable to hold the unit data
                DataTable dtWarehouse = await InitializeWarehouseDataTableAsync();

                // Retrieve the unit data from the database asynchronously
                DataTable dt = await Task.Run(() => GetWarehouseDataFromDatabaseAsync());

                // If data is retrieved successfully, populate the DataTable
                if (dt != null && dt.Rows.Count > 0)
                {
                    PopulateWarehouseDataTable(dtWarehouse, dt);
                }

                // Set ComboBox data source on the UI thread
                SetWarehouseComboBoxDataSource(combo, dtWarehouse);
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An error occurred while filling the unit data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<DataTable> InitializeWarehouseDataTableAsync()
        {
            // Initialize a DataTable with columns for UnitID and UnitName
            DataTable dtWarehouse = new DataTable();
            dtWarehouse.Columns.Add("WarehouseID");
            dtWarehouse.Columns.Add("Name");

            // Add an empty first row to the DataTable
            DataRow emptyRow = dtWarehouse.NewRow();
            emptyRow["WarehouseID"] = DBNull.Value; // Placeholder for no selection
            emptyRow["Name"] = string.Empty; // Empty display text for no selection
            dtWarehouse.Rows.Add(emptyRow);

            // Simulate an asynchronous operation (e.g., external data retrieval)
            await Task.Delay(50); // Placeholder for async task

            return dtWarehouse;
        }

        private static async Task<DataTable> GetWarehouseDataFromDatabaseAsync()
        {
            // Query to retrieve unit data from the database, ordered by default unit
            string query = "SELECT WarehouseID, Name FROM WarehouseTable";

            // Execute the query asynchronously and return the result
            return await DatabaseAccess.RetriveAsync(query);
        }

        private static void PopulateWarehouseDataTable(DataTable dtWarehouse, DataTable dt)
        {
            // Iterate through the result rows and add them to the DataTable
            foreach (DataRow unit in dt.Rows)
            {
                dtWarehouse.Rows.Add(unit["WarehouseID"], unit["Name"]);
            }
        }

        private static void SetWarehouseComboBoxDataSource(ComboBox combo, DataTable dtWarehouse)
        {
            // Set ComboBox properties to bind the data source
            combo.DataSource = dtWarehouse;
            combo.ValueMember = "WarehouseID";
            combo.DisplayMember = "Name";

            // Select the first item by default
            combo.SelectedIndex = 0;
        }

        private static async Task<DataTable> InitializeUnitDataTableAsync()
        {
            // Initialize a DataTable with columns for UnitID and UnitName
            DataTable dtUnit = new DataTable();
            dtUnit.Columns.Add("UnitID");
            dtUnit.Columns.Add("UnitName");

            // Add an empty first row to the DataTable
            DataRow emptyRow = dtUnit.NewRow();
            emptyRow["UnitID"] = DBNull.Value; // Placeholder for no selection
            emptyRow["UnitName"] = string.Empty; // Empty display text for no selection
            dtUnit.Rows.Add(emptyRow);

            // Simulate an asynchronous operation (e.g., external data retrieval)
            await Task.Delay(50); // Placeholder for async task

            return dtUnit;
        }


        private static async Task<DataTable> GetUnitDataFromDatabaseAsync()
        {
            // Query to retrieve unit data from the database, ordered by default unit
            string query = "SELECT UnitID, UnitName FROM UnitTable ORDER BY IsDefault DESC";

            // Execute the query asynchronously and return the result
            return await DatabaseAccess.RetriveAsync(query);
        }


        private static void PopulateUnitDataTable(DataTable dtUnit, DataTable dt)
        {
            // Iterate through the result rows and add them to the DataTable
            foreach (DataRow unit in dt.Rows)
            {
                dtUnit.Rows.Add(unit["UnitID"], unit["UnitName"]);
            }
        }

        private static void SetComboBoxDataSource(ComboBox combo, DataTable dtUnit)
        {
            // Set ComboBox properties to bind the data source
            combo.DataSource = dtUnit;
            combo.ValueMember = "UnitID";
            combo.DisplayMember = "UnitName";

            // Select the first item by default
            combo.SelectedIndex = 0;
        }


        public static async Task ShiftFocusOnEnterAsync(KeyEventArgs e, Control currentControl)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the "ding" sound

                var parent = currentControl.Parent;
                if (parent != null)
                {
                    // Get all controls in the parent container
                    var controls = parent.Controls.Cast<Control>()
                                        .Where(c => c.TabIndex > currentControl.TabIndex)
                                        .OrderBy(c => c.TabIndex);

                    // Focus the next control
                    var nextControl = controls.FirstOrDefault();

                    if (nextControl != null)
                    {
                        // Use async delay to simulate asynchronous behavior if needed
                        await Task.Delay(50);  // Simulate async work, not strictly necessary
                        nextControl.Focus();
                    }
                }
            }
        }


        public static async Task DisposeOnCloseAsync(Form form)
        {
            form.FormClosed += async (sender, e) =>
            {
                // You could perform some async work here if needed
                await Task.Delay(50);  // Simulated async delay, if necessary

                form.Dispose();
            };
        }

        public static async Task CalculateTotalDiscountColumnAsync(int columnIndex, DataGridView dataGridView, TextBox textBox)
        {
            decimal totalDiscount = 0;

            // Run the calculation in the background thread
            await Task.Run(() =>
            {
                // Check if the DataGridView has rows
                if (dataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Skip the row if it's empty
                        if (row.IsNewRow) continue;

                        // Ensure the cell has a value
                        var cellValue = row.Cells[columnIndex].Value;
                        if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal value))
                        {
                            totalDiscount += value;
                        }
                        else
                        {
                            // Handle cases where the value can't be parsed to decimal
                            if (cellValue != null)
                            {
                                // Optional: Log the invalid row if necessary
                                // Example: LogInvalidRow(row.Index);
                            }
                        }
                    }
                }
            });

            // Update the TextBox on the UI thread
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((Action)(() =>
                {
                    textBox.Text = totalDiscount.ToString("N2");
                }));
            }
            else
            {
                textBox.Text = totalDiscount.ToString("N2");
            }
        }


        public static async Task CalculateTotalColumnAsync(int columnIndex, DataGridView dataGridView, TextBox textBox)
        {
            decimal total = 0;

            // Run the calculation in a background thread
            await Task.Run(() =>
            {
                // Check if the DataGridView has rows
                if (dataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Skip the row if it's empty
                        if (row.IsNewRow) continue;

                        // Ensure the cell has a value
                        var cellValue = row.Cells[columnIndex].Value;
                        if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal value))
                        {
                            total += value;
                        }
                        else
                        {
                            // Optionally handle cases where the value can't be parsed to decimal
                            if (cellValue != null)
                            {
                                // Log or handle invalid rows if necessary
                                // Example: LogInvalidRow(row.Index);
                            }
                        }
                    }
                }
            });

            // Update the TextBox on the UI thread
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((Action)(() =>
                {
                    textBox.Text = total.ToString("N2");
                }));
            }
            else
            {
                textBox.Text = total.ToString("N2");
            }
        }


        public static async Task CalculateTotalVatColumnAsync(int columnIndex, DataGridView dataGridView, TextBox textBox)
        {
            decimal totalvat = 0;

            // Run the calculation in a background thread
            await Task.Run(() =>
            {
                // Check if the DataGridView has rows
                if (dataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Skip the row if it's empty
                        if (row.IsNewRow) continue;

                        // Ensure the cell has a value
                        var cellValue = row.Cells[columnIndex].Value;
                        if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal value))
                        {
                            totalvat += value;
                        }
                        else
                        {
                            // Optionally handle cases where the value can't be parsed to decimal
                            if (cellValue != null)
                            {
                                // Log or handle invalid rows if necessary
                                // Example: LogInvalidRow(row.Index);
                            }
                        }
                    }
                }
            });

            // Update the TextBox on the UI thread
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((Action)(() =>
                {
                    textBox.Text = totalvat.ToString("N2");
                }));
            }
            else
            {
                textBox.Text = totalvat.ToString("N2");
            }

        }
    }
}
