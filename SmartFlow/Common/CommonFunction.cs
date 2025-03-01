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
                    query += @" AND (AccountSubControlTable.AccountSubControlName LIKE @SearchValue OR AccountSubControlTable.CompanyName LIKE @SearchValue)";
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

        public static async Task GetAccountGroupInfoAsync(string searchValue, DataGridView dgv)
        {
            try
            {
                // Validate search value and build the query
                string query = string.IsNullOrWhiteSpace(searchValue)
                    ? GetDefaultAccountGroupQuery()
                    : BuildSearchQueryAccountGroup(searchValue);

                // Retrieve account data from the database asynchronously
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
                MessageBox.Show("An error occurred while retrieving the account data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetDefaultAccountGroupQuery()
        {
            return @"SELECT AccountControlID [ID],AccountControlName [ACCOUNT NAME],AccountHeadName [ACCOUNT HEAD NAME],AccountHead_ID [HEADID],CodeAccount FROM AccountControlTable";
        }

        private static string BuildSearchQueryAccountGroup(string searchValue)
        {
            // Build the search query using parameterization to avoid SQL injection
            return @"SELECT AccountControlID [ID],AccountControlName [ACCOUNT NAME],AccountHeadName [ACCOUNT HEAD NAME],AccountHead_ID [HEADID],CompanyName [COMPANY],CodeAccount FROM AccountControlTable WHERE 
                AccountControlName LIKE @searchValue AND CompanyName LIKE @searchValue";
        }

        private static string GetDefaultAccountQuery()
        {
            // Default query when no search value is provided
            return @"SELECT AccountSubControlID [ID], AccountHead_ID [HEADID], AccountSubControlName [ACCOUNT NAME], Email [EMAIL], MobileNo [MOBILE],CompanyName [COMPANY], CodeAccount FROM AccountSubControlTable";
        }

        private static string BuildSearchQueryAccount(string searchValue)
        {
            // Build the search query using parameterization to avoid SQL injection
            return @"SELECT AccountSubControlID AS [ID], AccountHead_ID AS [HEADID], AccountSubControlName AS [ACCOUNT NAME], Email AS [EMAIL], MobileNo AS [MOBILE], CompanyName AS [COMPANY], 
                CodeAccount FROM AccountSubControlTable WHERE EXISTS (SELECT 1 FROM STRING_SPLIT(@SearchValue, ' ') AS Keywords WHERE LOWER(AccountSubControlName) LIKE '%' + LOWER(Keywords.value) + '%' 
                OR LOWER(CompanyName) LIKE '%' + LOWER(Keywords.value) + '%')
                ORDER BY CASE WHEN LOWER(AccountSubControlName) = LOWER(@SearchValue) THEN 1  WHEN LOWER(CompanyName) = LOWER(@SearchValue) THEN 2  WHEN LOWER(AccountSubControlName) LIKE LOWER(@SearchValue) + '%' THEN 3  
                WHEN LOWER(CompanyName) LIKE LOWER(@SearchValue) + '%' THEN 4  
                ELSE 5  
            END;";
        }

        public static string BuildSearchQueryProduct(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder(@"
                SELECT DISTINCT ProductID AS [ID], ProductName AS [TITLE], 
                StandardPrice AS [PRICE], UPC, EAN, MFR, Barcode AS [BARCODE]
                FROM ProductTable
                WHERE 
                ");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND ");
                }

                queryBuilder.Append($@"
                (ProductName LIKE '%{term}%' OR 
                MFR LIKE '%{term}%' OR 
                UPC LIKE '%{term}%') 
                ");
            }

            queryBuilder.Append(" ORDER BY ProductName ASC"); // You can change sorting logic as needed.

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

        public static async Task PopulateBrandComboBoxAsync(ComboBox combo)
        {
            // Retrieve data from the database asynchronously
            string query = "SELECT BrandId,BrandName,Description,BrandCode FROM BrandTable";
            DataTable dt = await Task.Run(() => DatabaseAccess.RetriveAsync(query));

            List<BrandData> brands = new List<BrandData>();

            // Insert an empty row as the first item
            brands.Add(new BrandData
            {
                BrandId = 0,  // You can use 0 or -1 to indicate an empty selection
                BrandName = "", // Empty display text
                Description = "",
                BrandCode = ""
            });

            // Populate the ComboBox with actual data
            foreach (DataRow row in dt.Rows)
            {
                BrandData brand = new BrandData
                {
                    BrandId = Convert.ToInt32(row["BrandId"]),
                    BrandName = row["BrandName"].ToString(),
                    Description = row["Description"].ToString(),
                    BrandCode = row["BrandCode"].ToString()
                };

                brands.Add(brand);
            }

            // Setting ComboBox data source on the UI thread
            combo.DataSource = brands;
            combo.DisplayMember = "BrandName";  // Display brand name
            combo.ValueMember = "BrandId";      // The actual value will be the BrandId

            // Optionally set the selected index to the empty row
            combo.SelectedIndex = 0;
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

        public static void DisposeOnClose(Form form)
        {
            form.FormClosed += (sender, e) =>
            {
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

        public static async Task InsertOrUpdateAccountStatementAsync(
            string clientName,
            int clientId,
            string type,
            string invoiceNo,
            string accountName,
            string longDescription,
            int? accountId,
            decimal debitAmount,
            decimal creditAmount,
            string shortNarration,
            bool? isDebit,  // Make it nullable so it can accept null
            bool isCredit,
            string companyName,
            string StatmentDescription)
        {
            // Step 1: Remove delete query

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Step 2: Insert new record
                    string insertQuery = @"INSERT INTO AccountStatementTable (
                    ClientName, ClientId, CreatedAt, CreatedDay, Type, InvoiceNo, 
                    AccountName, LongDescription, AccountId, DebitAmount, CreditAmount, ShortNaration, IsDebit, IsCredit, CompanyName, StatmentDescription)
                    VALUES (
                    @ClientName, @ClientId, @CreatedAt, @CreatedDay, @Type, @InvoiceNo, 
                    @AccountName, @LongDescription, @AccountId, @DebitAmount, @CreditAmount, @ShortNaration, @IsDebit, @IsCredit, @CompanyName, @StatmentDescription)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@ClientName", clientName);
                        insertCmd.Parameters.AddWithValue("@ClientId", clientId);
                        insertCmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@CreatedDay", DateTime.Now.DayOfWeek.ToString());
                        insertCmd.Parameters.AddWithValue("@Type", type);
                        insertCmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                        insertCmd.Parameters.AddWithValue("@AccountName", accountName);
                        insertCmd.Parameters.AddWithValue("@LongDescription", longDescription);
                        insertCmd.Parameters.AddWithValue("@AccountId", accountId ?? (object)DBNull.Value); // Allow AccountId to be null
                        insertCmd.Parameters.AddWithValue("@DebitAmount", debitAmount);
                        insertCmd.Parameters.AddWithValue("@CreditAmount", creditAmount);
                        insertCmd.Parameters.AddWithValue("@ShortNaration", shortNarration);

                        // Set isDebit to false if it is null
                        insertCmd.Parameters.AddWithValue("@IsDebit", isDebit ?? false);

                        insertCmd.Parameters.AddWithValue("@IsCredit", isCredit);
                        insertCmd.Parameters.AddWithValue("@CompanyName", companyName);
                        insertCmd.Parameters.AddWithValue("@StatmentDescription", StatmentDescription);

                        await insertCmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}
