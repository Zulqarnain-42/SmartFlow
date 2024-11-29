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
    }
}
