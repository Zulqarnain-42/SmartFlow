using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class TaxPlanet : Form
    {
/*        string client_id = ConfigurationManager.AppSettings["client_id"];
        string client_secret = ConfigurationManager.AppSettings["client_secret"];*/
        public TaxPlanet()
        {
            InitializeComponent();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            // Get the search keyword from the TextBox
            string searchKeyword = searchtxtbox.Text.Trim();
            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Invoice No is empty.");
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
                /*// Open the connection
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
                }*/
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
               /* if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }*/
            }
        }

        private void dgvTaxPlanet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the data rows (not header or empty row)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the data of the selected row
                DataGridViewRow selectedRow = dgvTaxPlanet.Rows[e.RowIndex];
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
                    MessageBox.Show("You Cannot make Planet for this invoice because tax is not mentioned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                /*// Open the connection

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
                }*/
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
               /* // Close the connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }*/
            }

        }
        private async void planetTokenAsync(string data)
        {
            try
            {
               /* string apitokenhUrl = "https://auth.tax.planetpayment.ae/auth/realms/planet/protocol/openid-connect/token";

                var formData = new Dictionary<string, string>
                {
                    { "client_id", client_id },
                    { "client_secret", client_secret },
                    { "grant_type", "client_credentials" }
                };


                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(formData);

                    HttpResponseMessage response = await client.PostAsync(apitokenhUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the response content
                        string result = await response.Content.ReadAsStringAsync();
                        AccessTokenResponse tokenResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(result);
                        planetnewtransaction(data, tokenResponse);

                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findtransactionbtn_Click(object sender, EventArgs e)
        {

        }

        private bool AreAnyTextBoxesFilled()
        {
            if (searchtxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }

        private void TaxPlanet_KeyDown(object sender, KeyEventArgs e)
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
        }
    }
}
