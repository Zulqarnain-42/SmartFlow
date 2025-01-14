using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Common
{
    public class CommonFunction
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static void GetSupplier(string searchValue, DataGridView dgv)
        {
            try
            {
                string query = @"
            SELECT 
                AccountSubControlTable.AccountSubControlID [ID],
                AccountSubControlTable.CodeAccount [Code],
                AccountSubControlTable.AccountSubControlName [Account Name],
                AccountSubControlTable.CompanyName [Company Name],
                AccountSubControlTable.MobileNo [Mobile],
                AccountSubControlTable.Email [Email],
                AccountSubControlTable.CreatedAt [Created],
                AccountSubControlTable.CreatedDay [Day]
            FROM AccountSubControlTable
            WHERE IsSupplier = @IsSupplier
        ";

                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    query += @"
                AND (AccountSubControlTable.AccountSubControlName LIKE @SearchValue OR 
                     AccountSubControlTable.CompanyName LIKE @SearchValue)
            ";
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Adding parameters to the query to prevent SQL injection
                        command.Parameters.AddWithValue("@IsSupplier", true);
                        command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                        connection.Open();
                        using (var reader = command.ExecuteReader())
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
        }


        public static void GetItemSerialNo(string searchValue, int searchId, DataGridView dgv)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(searchValue) && searchId > 0)
                {
                    string query = @"
                SELECT SerialNOID, ProductId, SerialNo 
                FROM SerialNoTable 
                WHERE ProductId = @SearchId AND IsSold = @IsSold
            ";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(query, connection))
                        {
                            // Add parameters to the query to prevent SQL injection
                            command.Parameters.AddWithValue("@SearchId", searchId);
                            command.Parameters.AddWithValue("@IsSold", false);

                            connection.Open();
                            using (var reader = command.ExecuteReader())
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
        }


        public static void GetCustomer(string searchValue, DataGridView dgv)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    // Search with the provided value
                    string query = @"
                SELECT 
                    AccountSubControlTable.AccountSubControlID [ID],
                    AccountSubControlTable.CodeAccount [Code],
                    AccountSubControlTable.AccountSubControlName [Account Name],
                    AccountSubControlTable.CompanyName [Company Name],
                    AccountSubControlTable.MobileNo [Mobile],
                    AccountSubControlTable.Email [Email],
                    AccountSubControlTable.CreatedAt [Created],
                    AccountSubControlTable.CreatedDay [Day]
                FROM AccountSubControlTable 
                WHERE (AccountSubControlTable.AccountSubControlName LIKE @SearchValue 
                    OR AccountSubControlTable.CompanyName LIKE @SearchValue) 
                    AND IsCustomer = 1";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(query, connection))
                        {
                            // Add parameters to prevent SQL injection
                            command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                            connection.Open();
                            using (var reader = command.ExecuteReader())
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
                else
                {
                    // Search without filter if no search value is provided
                    string query = @"
                SELECT 
                    AccountSubControlTable.AccountSubControlID [ID],
                    AccountSubControlTable.CodeAccount [Code],
                    AccountSubControlTable.AccountSubControlName [Account Name],
                    AccountSubControlTable.CompanyName [Company Name],
                    AccountSubControlTable.MobileNo [Mobile],
                    AccountSubControlTable.Email [Email],
                    AccountSubControlTable.CreatedAt [Created],
                    AccountSubControlTable.CreatedDay [Day]
                FROM AccountSubControlTable 
                WHERE IsCustomer = 1";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (var reader = command.ExecuteReader())
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


        public static void GetProduct(string searchValue, DataGridView dgv)
        {
            try
            {
                // Validate the search value and build the query
                string query = string.IsNullOrWhiteSpace(searchValue)
                    ? GetDefaultProductQuery()
                    : BuildSearchQueryProduct(searchValue);

                // Retrieve product data from the database
                DataTable dt = RetrieveData(query, searchValue);

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
            return @"
        SELECT ProductID [ID], ProductName [TITLE], StandardPrice [PRICE], UPC, EAN, MFR, Barcode [BARCODE] 
        FROM ProductTable";
        }

        private static DataTable RetrieveData(string query, string searchValue)
        {
            // This method retrieves data from the database using a parameterized query
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new ApplicationException("Error retrieving data from the database.");
            }
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


        public static void GetAccountInfo(string searchValue, DataGridView dgv)
        {
            try
            {
                // Validate search value and build the query
                string query = string.IsNullOrWhiteSpace(searchValue)
                    ? GetDefaultAccountQuery()
                    : BuildSearchQueryAccount(searchValue);

                // Retrieve account data from the database
                DataTable dt = RetrieveData(query, searchValue);

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

        private static string GetDefaultAccountQuery()
        {
            // Default query when no search value is provided
            return @"
        SELECT AccountSubControlID [ID], AccountSubControlName [ACCOUNT NAME], Email [EMAIL], MobileNo [MOBILE], CodeAccount 
        FROM AccountSubControlTable";
        }

        private static string BuildSearchQueryAccount(string searchValue)
        {
            // Build the search query using parameterization to avoid SQL injection
            return @"
        SELECT AccountSubControlID [ID], AccountSubControlName [ACCOUNT NAME], Email [EMAIL], MobileNo [MOBILE], CodeAccount 
        FROM AccountSubControlTable 
        WHERE AccountSubControlName LIKE @SearchValue";
        }


        public static void GetAccountGroupInfo(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && String.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountControlID [ID],AccountControlName [Account Name],AccountHead_ID,Alias FROM AccountControlTable";
                }
                else
                {
                    query = "SELECT AccountControlID [ID],AccountControlName [Account Name],AccountHead_ID,Alias FROM AccountControlTable" +
                        "WHERE AccountControlName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void GetProductQtyWarehouse(DataGridView dgv,string productmfr,int productid)
        {
            try
            {
                string getproductinventoryquery = string.Format("SELECT StockTable.WarehouseID [ID],WarehouseTable.Name [Warehouse Name]," +
                    "SUM(COALESCE(StockTable.[Quantity],0)) + COALESCE(InvoiceDetailsTable.Quantity, 0) AS Quantity " +
                    "FROM StockTable INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = StockTable.Warehouseid " +
                    "LEFT JOIN ProductTable ON ProductTable.ProductID = StockTable.ProductID " +
                    "AND ProductTable.WarehouseID = WarehouseTable.WarehouseID " +
                    "LEFT JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Productid = StockTable.ProductID " +
                    "AND InvoiceDetailsTable.Productid = ProductTable.ProductID " +
                    "AND InvoiceDetailsTable.Warehouseid = WarehouseTable.WarehouseID WHERE StockTable.ProductID = '" + productid + "' " +
                    "AND StockTable.Warehouseid IN (SELECT WarehouseID FROM WarehouseTable) " +
                    "GROUP BY StockTable.ProductID,StockTable.Warehouseid,WarehouseTable.Name,InvoiceDetailsTable.Quantity " +
                    "ORDER BY StockTable.ProductID");
                
                DataTable datainventory = DatabaseAccess.Retrive(getproductinventoryquery);
                if (datainventory != null && datainventory.Rows.Count > 0) 
                {
                    dgv.DataSource = datainventory;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void GetTransactionInfoProduct(DataGridView dgv,string productmfr,int productid)
        {
            try
            {
                string query = string.Format("SELECT InvoiceTable.Invoiceid [ID],InvoiceTable.InvoiceNo [Invoice No],InvoiceTable.invoicedate [Date]," +
                    "InvoiceTable.ClientID [Client ID],InvoiceTable.ClientName [Client Name],InvoiceDetailsTable.ProductName [Title],InvoiceDetailsTable.ItemSerialNoid [Serial No]," +
                    "InvoiceDetailsTable.ItemWiseDiscount [Discount],InvoiceDetailsTable.ItemWiseVAT [VAT],InvoiceDetailsTable.UnitSalePrice [Price]," +
                    "InvoiceDetailsTable.MFR [MFR],InvoiceDetailsTable.Quantity [Quantity],InvoiceDetailsTable.SystemSerialNoid [System Serial No] FROM InvoiceTable " +
                    "INNER JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Invoicecode = InvoiceTable.InvoiceCode " +
                    "WHERE InvoiceDetailsTable.Productid = '" + productid + "' AND ClientID = '" + GlobalVariables.customeridglobal + "'");
                DataTable datatransaction = DatabaseAccess.Retrive(query);

                if(datatransaction!=null && datatransaction.Rows.Count > 0)
                {
                    dgv.DataSource= datatransaction;
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

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

        public static Form IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    return form;
                }
            }
            return null;
        }

        public static string HashPassword(string password)
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
        }

        public static void PopulateCurrencyComboBox(ComboBox combo)
        {
            // Retrieve data from the database (example query)
            string query = "SELECT CurrencyId, Symbol, Name, CurrencyString FROM CurrencyTable";
            DataTable dt = DatabaseAccess.Retrive(query);

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

            combo.DataSource = currencies;
            combo.DisplayMember = "Name";  // Or whatever you want to display
            combo.ValueMember = "CurrencyId"; // The actual value will be the CurrencyId
        }



        public static void FillUnitData(ComboBox combo)
        {
            try
            {
                // Initialize a DataTable to hold the unit data
                DataTable dtUnit = InitializeUnitDataTable();

                // Retrieve the unit data from the database
                DataTable dt = GetUnitDataFromDatabase();

                // If data is retrieved successfully, populate the DataTable
                if (dt != null && dt.Rows.Count > 0)
                {
                    PopulateUnitDataTable(dtUnit, dt);
                }

                // Set ComboBox data source
                SetComboBoxDataSource(combo, dtUnit);
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("An error occurred while filling the unit data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataTable InitializeUnitDataTable()
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

            return dtUnit;
        }

        private static DataTable GetUnitDataFromDatabase()
        {
            // Query to retrieve unit data from the database, ordered by default unit
            string query = "SELECT UnitID, UnitName FROM UnitTable ORDER BY IsDefault DESC";

            // Execute the query and return the result
            return DatabaseAccess.Retrive(query);
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


        public static void ShiftFocusOnEnter(KeyEventArgs e, Control currentControl)
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
                    nextControl?.Focus();
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

        public static void CalculateTotalDiscountColumn(int columnIndex,DataGridView dataGridView,TextBox textBox)
        {
            decimal totaldiscount = 0;

            // Check if the DataGridView has rows
            if (dataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Ensure the cell has a value
                    if (row.Cells[columnIndex].Value != null)
                    {
                        // Try parsing the value in the cell to decimal
                        if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                        {
                            totaldiscount += value;
                        }
                        else
                        {
                            // Optionally handle cases where the value can't be parsed to decimal
                            MessageBox.Show($"Invalid value found in row {row.Index + 1}, column {columnIndex}. Skipping this row.",
                                            "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Update the total discount in the text box with formatting
                textBox.Text = totaldiscount.ToString("N2");
            }
            else
            {
                // If no rows are present, set the discount total to zero
                textBox.Text = "0.00";
            }
        }

        public static void CalculateTotalColumn(int columnIndex,DataGridView dataGridView,TextBox textBox)
        {
            decimal total = 0;

            // Check if the DataGridView has rows
            if (dataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Ensure the cell has a value
                    if (row.Cells[columnIndex].Value != null)
                    {
                        // Try parsing the value in the cell to decimal
                        if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                        {
                            total += value;
                        }
                        else
                        {
                            // Optionally handle cases where the value can't be parsed to decimal
                            MessageBox.Show($"Invalid value found in row {row.Index + 1}, column {columnIndex}. Skipping this row.",
                                            "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Update the total in the text box with formatting
                textBox.Text = total.ToString("N2");
            }
            else
            {
                // If no rows are present, set the total to zero
                textBox.Text = "0.00";
            }
        }

        public static void CalculateTotalVatColumn(int columnIndex,DataGridView dataGridView,TextBox textBox)
        {
            decimal totalvat = 0;

            // Check if the DataGridView has rows
            if (dataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Ensure the cell has a value
                    if (row.Cells[columnIndex].Value != null)
                    {
                        // Try parsing the value in the cell to decimal
                        if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out decimal value))
                        {
                            totalvat += value;
                        }
                        else
                        {
                            // Optionally handle cases where the value can't be parsed to decimal
                            MessageBox.Show($"Invalid value found in row {row.Index + 1}, column {columnIndex}. Skipping this row.",
                                            "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Update the total VAT in the text box with formatting
                textBox.Text = totalvat.ToString("N2");
            }
            else
            {
                // If no rows are present, set the VAT total to zero
                textBox.Text = "0.00";
            }
        }



    }
}
