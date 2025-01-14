using Newtonsoft.Json;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class TaxPlanet : Form
    {
        string searchKeyword = string.Empty;
        string client_id = ConfigurationManager.AppSettings["client_id"];
        string client_secret = ConfigurationManager.AppSettings["client_secret"];
        public TaxPlanet()
        {
            InitializeComponent();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            // Get the search keyword from the TextBox
            searchKeyword = searchtxtbox.Text.Trim();
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
            string query = "SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName," +
                "TotalVat,TotalDiscount,FreightShippingCharges,InvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,ConversionRate,QuotationValidUntill,SalePerson," +
                "ShipmentReceiveingPerson FROM InvoiceTable WHERE InvoiceNo LIKE '"+keyword+"'";

            try
            {
                DataTable dtinvoiceData = DatabaseAccess.Retrive(query);
                dgvTaxPlanet.DataSource = dtinvoiceData;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTaxPlanet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the data rows (not header or empty row)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the data of the selected row
                DataGridViewRow selectedRow = dgvTaxPlanet.Rows[e.RowIndex];
                string VchCode = Convert.ToString(selectedRow.Cells["Invoiceid"].Value);
                DateTime date = Convert.ToDateTime(selectedRow.Cells["invoicedate"].Value);
                string VchNo = Convert.ToString(selectedRow.Cells["InvoiceNo"].Value);
                string mastercode = Convert.ToString(selectedRow.Cells["InvoiceCode"].Value);
                double AmtWithVat = Convert.ToDouble(selectedRow.Cells["NetTotal"].Value);
                double AmtSalePurc = Convert.ToDouble(selectedRow.Cells["NetTotal"].Value) - Convert.ToDouble(selectedRow.Cells["TotalVat"].Value);

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
            try
            {
                string jsonString = DatabaseAccess.GetInvoiceJson(searchKeyword);
                planetTokenAsync(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void planetTokenAsync(string data)
        {
            try
            {
                string apitokenhUrl = "https://auth.tax.planetpayment.ae/auth/realms/planet/protocol/openid-connect/token";

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void planetnewtransaction(string data, AccessTokenResponse tokenResponse)
        {
            try
            {
                string apitransactionUrl = "https://frontoffice.tax.planetpayment.ae/services/transactions/api/v2/custom-mapping/new-transaction";
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenResponse.access_token);
                    HttpResponseMessage response = await client.PostAsync(apitransactionUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        TransactionApiResponseModel apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TransactionApiResponseModel>(result);
                        string redirectUrl = apiResponse.url;
                        System.Diagnostics.Process.Start(redirectUrl);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class TransactionApiResponseModel
        {
            public string url { get; set; }
            public string transactionCode { get; set; }
            public string transactionId { get; set; }
            public string receiptNumber { get; set; }
        }

        public class AccessTokenResponse
        {
            public string access_token { get; set; }
            // Add other properties as needed
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
