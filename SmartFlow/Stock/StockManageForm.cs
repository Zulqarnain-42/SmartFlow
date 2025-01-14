using Newtonsoft.Json;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class StockManageForm : Form
    {
        private OleDbConnection connection;
        private OleDbDataAdapter dataAdapter;
        private DataTable dataTable;
        string client_id = ConfigurationManager.AppSettings["client_id"];
        string client_secret = ConfigurationManager.AppSettings["client_secret"];

        public StockManageForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.AppSettings["MyConnectionString"]; ;
            connection = new OleDbConnection(connectionString);

            // Initialize the DataTable and bind it to the DataGridView
            dataTable = new DataTable();
            searchdataGridView.DataSource = dataTable;
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            // Get the search keyword from the TextBox
            string searchKeyword = searchtxtbox.Text.Trim();
            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Invoice No is empty.");
            }
            else if (!saleinvoiceradio.Checked && !salereturnradio.Checked && !revisedradio.Checked)
            {
                MessageBox.Show("Select Radio Button");
            }
            else
            {
                // Perform the search
                SearchData(searchKeyword);
            }
        }

        private void SearchData(string keyword)
        {
            // SQL query with a parameterized WHERE clause
            string query = "SELECT Date,VchCode,VchNo,VchAmtBaseCur,VchSalePurcAmt,MasterCode1 FROM Tran1 WHERE VchNo LIKE @Keyword";

            try
            {
                // Open the connection
                connection.Open();
                // Create a command object with a parameter
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add a parameter to the command
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    // Create a data adapter and fill the DataTable
                    dataAdapter = new OleDbDataAdapter(command);
                    dataTable.Clear(); // Clear existing data
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void searchdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            searchdataGridView.Enabled = false;
            try
            {
                // Check if the clicked cell is in the data rows (not header or empty row)
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the data of the selected row
                    DataGridViewRow selectedRow = searchdataGridView.Rows[e.RowIndex];
                    string VchCode = Convert.ToString(selectedRow.Cells["VchCode"].Value);
                    DateTime date = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                    string VchNo = Convert.ToString(selectedRow.Cells["VchNo"].Value);
                    string mastercode = Convert.ToString(selectedRow.Cells["MasterCode1"].Value);
                    double AmtWithVat = Convert.ToDouble(selectedRow.Cells["VchAmtBaseCur"].Value);
                    double AmtSalePurc = Convert.ToDouble(selectedRow.Cells["VchSalePurcAmt"].Value);
                    if (AmtWithVat != AmtSalePurc)
                    {
                        LoadDataToArray(VchCode);
                    }
                    else
                    {
                        MessageBox.Show("Action is not completed yet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                // Optionally re-enable the DataGridView after some delay or a specific condition
                searchdataGridView.Enabled = true;
            }

        }

        private void LoadDataToArray(string VchCode)
        {
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();
            // SQL query
            string query = "SELECT Tran1.VchNo AS InvoiceNo," +
                "Tran1.VchAmtBaseCur AS AmountWithTax," +
                "Tran1.VchSalePurcAmt AS AmountWithoutTax," +
                "Tran1.Date,VchVATSum.TaxAmt AS Tax," +
                "Tran2.D1 AS quantity," +
                "Tran2.D2 AS unitPrice," +
                "Tran2.MasterCode1," +
                "Tran2.D5 As grossAmount," +
                "Tran2.D11 As vatAmount," +
                "Tran2.D12 As vatCode " +
                "FROM ((Tran1 " +
                "INNER JOIN VchVATSum ON VchVATSum.VchCode=Tran1.VchCode) " +
                "INNER JOIN Tran2 ON Tran2.VchCode = Tran1.VchCode)" +
                "WHERE Tran1.VchCode like @Keyword " +
                "GROUP BY Tran1.VchNo,Tran1.VchAmtBaseCur,Tran1.VchSalePurcAmt,Tran1.Date,VchVATSum.TaxAmt," +
                "Tran2.MasterCode1,Tran2.D1,Tran2.D2,Tran2.D5,Tran2.D11,Tran2.D12";

            try
            {
                // Open the connection

                connection.Open();

                // Create a command object
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add a parameter to the command
                    command.Parameters.AddWithValue("@Keyword", "" + VchCode + "");

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> rowData = new Dictionary<string, object>();
                            // Populate the dictionary with data from the reader
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowData.Add(reader.GetName(i), reader[i]);
                            }
                            // Add the dictionary to the list
                            dataList.Add(rowData);
                        }
                        getMasterData(dataList);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                // Close the connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        private void getMasterData(List<Dictionary<string, object>> dataList)
        {
            List<Dictionary<string, object>> masterdataList = new List<Dictionary<string, object>>();
            string jsonString = null;
            foreach (var dataItem in dataList)
            {
                double unitprice = Convert.ToDouble(dataItem["unitPrice"]);
                double tax = Convert.ToDouble(dataItem["Tax"]);

                if (unitprice > 0 && tax > 0)
                {
                    int mastercode = Convert.ToInt32(dataItem["MasterCode1"]);
                    int quantity = Math.Abs(Convert.ToInt32(dataItem["quantity"]));
                    int vatCode = Convert.ToInt32(dataItem["vatCode"]);
                    double netAmount = System.Math.Round(Convert.ToDouble(dataItem["unitPrice"]) * quantity, 2);
                    string query = "SELECT Alias As code,PrintName As description FROM Master1 WHERE Code Like @Keyword";
                    try
                    {
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Keyword", "" + mastercode + "");
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Dictionary<string, object> itemsData = new Dictionary<string, object>();
                                    string code = reader.GetString(0);
                                    string description = reader.GetString(1);
                                    itemsData.Add("unitPrice", dataItem["unitPrice"]);
                                    itemsData.Add("quantity", quantity);
                                    itemsData.Add("netAmount", netAmount);
                                    itemsData.Add("vatAmount", dataItem["vatAmount"]);
                                    itemsData.Add("grossAmount", dataItem["grossAmount"]);
                                    itemsData.Add("description", description);
                                    itemsData.Add("code", code);
                                    itemsData.Add("serialNumber", "");
                                    itemsData.Add("vatCode", vatCode);
                                    masterdataList.Add(itemsData);
                                }
                            }
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                string invoiceNo = dataItem["InvoiceNo"].ToString();
                invoiceNo = invoiceNo.Replace(" ", "");
                Dictionary<string, object> jsonData = new Dictionary<string, object>
                {
                    { "Date", dataItem["Date"] },
                    { "InvoiceNo", invoiceNo },
                    { "AmountWithoutTax", dataItem["AmountWithoutTax"] },
                    { "Tax", dataItem["Tax"] },
                    { "AmountWithTax", dataItem["AmountWithTax"] },
                    { "items", masterdataList }
                };

                jsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            }
            inventorynewtransaction(jsonString);
        }

        private void inventorynewtransaction(string invoiceData)
        {
            try
            {
                bool resultstatus = false;
                int totalQty = 0;
                // Deserialize JSON to Invoice object
                Invoice invoice = JsonConvert.DeserializeObject<Invoice>(invoiceData);

                string tableName = "StockCustomizedTable";
                var columnData = new Dictionary<string, object>
                {
                    { "Code", Guid.NewGuid().ToString() },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                    { "InvoiceNo", invoice.InvoiceNo },
                };

                int stockcustomid = DatabaseAccess.InsertDataId(tableName, columnData);

                // Extract the 'code' values from each item
                foreach (var item in invoice.items)
                {
                    if (saleinvoiceradio.Checked)
                    {
                        string checkstock = string.Format("SELECT MIN(CreatedAt) AS StockCreation,ProductMfr, SUM(Quantity) AS TotalQuantity FROM StockTable " +
                            "WHERE ProductMfr = '" + item.code + "' GROUP BY ProductMfr;");

                        DataTable stockqty = DatabaseAccess.Retrive(checkstock);
                        if (stockqty.Rows.Count > 0 && stockqty != null)
                        {
                            DateTime latestStockCreation = Convert.ToDateTime(stockqty.Rows[0]["StockCreation"]);
                            totalQty = Convert.ToInt32(stockqty.Rows[0]["TotalQuantity"].ToString());
                            DateTime invoiceDate = DateTime.Parse(invoice.Date);
                            if (latestStockCreation <= invoiceDate)
                            {
                                if (totalQty > 0)
                                {
                                    resultstatus = minusinventoryData(item, stockcustomid);
                                }
                            }    
                        }
                    }
                    else if(salereturnradio.Checked)
                    {
                        resultstatus = addinventoryData(item, stockcustomid);
                    }else if (revisedradio.Checked)
                    {
                        resultstatus = false;
                    }
                    else
                    {
                        MessageBox.Show("Something is wrong.");
                    }
                }

                if (resultstatus) 
                {
                    MessageBox.Show("Saved Successfully!");
                }
                else
                {
                    string delquery = string.Format("DELETE FROM StockCustomizedTable WHERE CustomStockID = '" + stockcustomid + "' " +
                        "And InvoiceNo = '" + invoice.InvoiceNo + "'");
                    bool delresult = false;
                    if (delresult) 
                    {
                        MessageBox.Show("Not Taken Inventory to this date.");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool minusinventoryData(InvoiceItem item,int stockcustomid)
        {
            bool allSuccess = true;
            DataTable productData = DatabaseAccess.Retrive("SELECT ProductID,ProductName,SaleUnitPrice,LowestPrice,WholeSalePrice,StandardPrice,Description," +
                        "StockTrasholdQty,StockCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay,UPC,EAN,Length,Width,Height,Weight,MFR,Barcode,ProductCode," +
                        "DiscountPercentage,UpdatedDay,IsBundle,HSCode,SecondMFr,Quantity,COO,WarehouseID FROM ProductTable WHERE MFR LIKE '" + item.code + "'");
            if(productData.Rows.Count > 0)
            {
                if (stockcustomid > 0)
                {
                    foreach (DataRow row in productData.Rows)
                    {
                        string tableName = "StockTable";
                        int productid = Convert.ToInt32(row["ProductID"].ToString());
                        string productMfr = row["MFR"].ToString();

                        var tableData = new Dictionary<string, object>
                        {
                            { "ProductID", productid },
                            { "ProductMfr", productMfr },
                            { "Quantity", item.quantity },
                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "StockCustom_ID", stockcustomid },
                            { "MinusInventory", true },
                            { "AddInventory",false }
                        };

                        bool result = DatabaseAccess.ExecuteQuery(tableName, "INSERT", tableData);
                        if (!result) // If any insert fails, set the flag to false
                        {
                            allSuccess = false; 
                        }
                    }
                    return allSuccess;
                }
            }
            else
            {
                string query = string.Format("INSERT INTO ProductBackupTable (ProductName,CreatedAt,CreatedDay,MFR) VALUES ('" + item.description + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + item.code + "')");
                bool addproduct = false;
                if (!addproduct)
                {
                    allSuccess = false;
                }
            }
            return allSuccess;
        }

        private bool addinventoryData(InvoiceItem item, int stockcustomid)
        {
            bool allSuccess = true;
            DataTable productData = DatabaseAccess.Retrive("SELECT ProductID,ProductName,SaleUnitPrice,LowestPrice,WholeSalePrice,StandardPrice,Description," +
                        "StockTrasholdQty,StockCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay,UPC,EAN,Length,Width,Height,Weight,MFR,Barcode,ProductCode," +
                        "DiscountPercentage,UpdatedDay,IsBundle,HSCode,SecondMFr,Quantity,COO,WarehouseID FROM ProductTable WHERE MFR LIKE '" + item.code + "'");
            if (productData.Rows.Count > 0)
            {
                if (stockcustomid > 0)
                {
                    foreach (DataRow row in productData.Rows)
                    {
                        string addinvoicequery = string.Format("INSERT INTO StockTable (ProductID,ProductMfr,Quantity,CreatedAt,CreatedDay,StockCustom_ID) VALUES " +
                            "('" + row["ProductID"].ToString() + "','" + row["MFR"].ToString() + "','" + item.quantity + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "'" + System.DateTime.Now.DayOfWeek + "','" + stockcustomid + "')");

                        bool result = false;
                        if (!result) // If any insert fails, set the flag to false
                        {
                            allSuccess = false;
                        }
                    }
                    return allSuccess;
                }
            }
            return allSuccess;
        }
    }
}
