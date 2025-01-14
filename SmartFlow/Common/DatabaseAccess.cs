using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SmartFlow
{
    public class DatabaseAccess
    {

        public static SqlConnection conn;
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        /*private static string connectionString = @"Data Source=10.255.254.241,1433;Initial Catalog=SmartFlow;User id=fabt;Password=Fabt101;";*/
        /*private static string connectionString = @"Data Source=DESKTOP-1D6LU8Q\SQLEXPRESS;Initial Catalog=19112024;Integrated Security=True;Encrypt=False;";*/
        private static SqlConnection ConnOpen()
        {
            conn = new SqlConnection(connectionString);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
        public static bool ExecuteQuery(string tableName, string operation, Dictionary<string, object> columnData, string whereClause = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(operation))
                    throw new ArgumentException("Table name and operation must be provided.");

                string query = string.Empty;

                // Dynamically construct the query based on the operation
                if (operation.ToUpper() == "INSERT")
                {
                    string columns = string.Join(", ", columnData.Keys);
                    string values = string.Join(", ", columnData.Keys.Select(key => "@" + key));
                    query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                }
                else if (operation.ToUpper() == "UPDATE")
                {
                    if (string.IsNullOrWhiteSpace(whereClause))
                        throw new ArgumentException("WHERE clause is required for UPDATE operations.");

                    string setClause = string.Join(", ", columnData.Keys.Select(key => $"{key} = @{key}"));
                    query = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}";
                }
                else if (operation.ToUpper() == "DELETE")
                {
                    if (string.IsNullOrWhiteSpace(whereClause))
                        throw new ArgumentException("WHERE clause is required for DELETE operations.");

                    query = $"DELETE FROM {tableName} WHERE {whereClause}";
                }
                else
                {
                    throw new ArgumentException("Unsupported operation. Use INSERT, UPDATE, or DELETE.");
                }

                // Execute the query
                using (SqlConnection conn = ConnOpen())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (var param in columnData)
                    {
                        cmd.Parameters.AddWithValue("@" + param.Key, param.Value ?? DBNull.Value);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public static int InsertDataId(string tableName, Dictionary<string, object> columnData)
        {
            try
            {
                // Build the column and parameter lists dynamically
                string columns = string.Join(", ", columnData.Keys);
                string parameters = string.Join(", ", columnData.Keys.Select(key => $"@{key}"));

                // Create the query
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters}); SELECT SCOPE_IDENTITY();";

                using (SqlConnection conn = ConnOpen())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters
                    foreach (var kvp in columnData)
                    {
                        cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value ?? DBNull.Value);
                    }
                    // Execute and return the new record ID
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error: {ex.Message}");
                return -1; // Indicate failure
            }
            finally { conn.Close(); }
        }
        public static DataTable RetrieveData(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (SqlConnection conn = ConnOpen()) // Ensure ConnOpen() returns an open SqlConnection
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    // Execute query and fill DataTable
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally { conn.Close(); }
        }
        public static DataTable Retrive(String query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally { conn.Close(); }
        }
        public static bool CheckIfCodeExistsInDatabase(string code)
        {
            try
            {
                bool exists = false;
                using (SqlConnection connection = ConnOpen())
                {
                    string query = "SELECT COUNT(*) FROM ProductTable WHERE MFR LIKE @Code";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        int count = (int)command.ExecuteScalar(); // Check if the code exists
                        exists = count > 0; // If count > 0, the code exists
                    }
                }
                return !exists; // Return true if the code is unique (not exists)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { conn.Close(); }
        }

        // Method to execute stored procedure and return DataTable
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            DataTable resultTable = new DataTable();

            try
            {
                using (SqlConnection connection = ConnOpen())
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        // Set command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command if any
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        // Create a data adapter to fill the DataTable
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            dataAdapter.Fill(resultTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }

            return resultTable;
        }

        public class Invoice
        {
            public string Date { get; set; }
            public string InvoiceNo { get; set; }
            public decimal AmountWithoutTax { get; set; }
            public decimal Tax { get; set; }
            public decimal AmountWithTax { get; set; }
            public List<Item> Items { get; set; }
        }

        public class Item
        {
            public string UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal NetAmount { get; set; }
            public decimal VatAmount { get; set; }
            public decimal GrossAmount { get; set; }
            public string Description { get; set; }
            public string Code { get; set; }
            public string SerialNumber { get; set; }
            public string VatCode { get; set; }
        }


        public static string GetInvoiceJson(string invoiceNo)
        {
            try
            {
                Invoice invoice = null;

                using (SqlConnection connection = ConnOpen())
                {
                    // Fetch Invoice Details
                    SqlCommand invoiceCommand = new SqlCommand("SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,AddedBy,Companyid," +
                        "Userid,InvoiceCode,NetTotal,ClientName,TotalVat,TotalDiscount,FreightShippingCharges,InvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName," +
                        "ConversionRate,QuotationValidUntill,SalePerson,ShipmentReceiveingPerson FROM InvoiceTable WHERE InvoiceNo = @InvoiceNo", connection);
                    invoiceCommand.Parameters.AddWithValue("@InvoiceNo", invoiceNo);

                    SqlDataReader invoiceReader = invoiceCommand.ExecuteReader();
                    if (invoiceReader.Read())
                    {
                        invoice = new Invoice
                        {
                            Date = Convert.ToDateTime(invoiceReader["invoicedate"]).ToString("yyyy-MM-dd"),
                            InvoiceNo = invoiceReader["InvoiceNo"].ToString(),
                            AmountWithoutTax = Convert.ToDecimal(invoiceReader["NetTotal"]) - Convert.ToDecimal(invoiceReader["TotalVat"]),
                            Tax = Convert.ToDecimal(invoiceReader["TotalVat"]),
                            AmountWithTax = Convert.ToDecimal(invoiceReader["NetTotal"]),
                            Items = new List<Item>()
                        };
                    }
                    invoiceReader.Close();

                    if (invoice == null)
                    {
                        throw new Exception($"No invoice found with InvoiceNo: {invoiceNo}");
                    }

                    // Fetch Invoice Items
                    SqlCommand itemsCommand = new SqlCommand("SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity,UnitSalePrice,ItemSerialNoid,ProductName,MFR," +
                        "ItemWiseDiscount,ItemWiseVAT,Warehouseid,PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice,PurchaseItemSalePrice,SystemSerialNoid,Unitid," +
                        "AddInventory,ItemAvailability,ItemTotal,IsSaleInvoice,PricePerMeter,LengthInMeter,ItemDescription,MinusInventory " +
                        "FROM InvoiceDetailsTable WHERE InvoiceNo = @InvoiceNo", connection);
                    itemsCommand.Parameters.AddWithValue("@InvoiceNo", invoiceNo);

                    SqlDataReader itemsReader = itemsCommand.ExecuteReader();
                    while (itemsReader.Read())
                    {
                        invoice.Items.Add(new Item
                        {
                            UnitPrice = itemsReader["UnitSalePrice"].ToString(),
                            Quantity = Convert.ToInt32(itemsReader["Quantity"]),
                            NetAmount = Convert.ToDecimal(itemsReader["ItemTotal"]) - Convert.ToDecimal(itemsReader["ItemWiseVAT"]),
                            VatAmount = Convert.ToDecimal(itemsReader["ItemWiseVAT"]),
                            GrossAmount = Convert.ToDecimal(itemsReader["ItemTotal"]),
                            Description = itemsReader["ProductName"].ToString(),
                            Code = itemsReader["MFR"].ToString(),
                            SerialNumber = null,
                            VatCode = "5"
                        });
                    }
                    itemsReader.Close();
                }

                // Convert the Invoice object to JSON
                return JsonConvert.SerializeObject(invoice, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public static DataTable Retrive(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = ConnOpen())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the command
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static bool ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection conn = ConnOpen())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Returns true if rows were affected
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error (e.g., Console.WriteLine or a logging library)
                Console.WriteLine($"Database error: {ex.Message}");
                return false;
            }
        }

        public static DataTable Retrive(string storedProcedure, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = ConnOpen())
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters.ToArray());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable result = new DataTable();
                    adapter.Fill(result);
                    return result;
                }
            }
        }


    }

}
