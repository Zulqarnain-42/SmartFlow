using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
        private async void SearchData(string keyword)
        {
            // SQL query with a parameterized WHERE clause
            string query = "SELECT Invoiceid,InvoiceNo,invoicedate,ClientID,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,AddedBy,Companyid,Userid,InvoiceCode,NetTotal,ClientName," +
                "TotalVat,TotalDiscount,FreightShippingCharges,InvoiceRefrence,IsPlanetInvoice,Currencyid,CurrencyName,ConversionRate,QuotationValidUntill,SalePerson," +
                "ShipmentReceiveingPerson FROM InvoiceTable WHERE InvoiceNo LIKE '"+keyword+"'";

            try
            {
                DataTable dtinvoiceData = await DatabaseAccess.RetriveAsync(query);
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
        private async void LoadDataToArray(string VchCode)
        {
            try
            {
                string jsonString = await DatabaseAccess.GetInvoiceJsonAsync(searchKeyword);
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
            string searchKeyword = searchtxtbox.Text.Trim();
            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Invoice No is empty.");
            }
            else
            {
                generateToken(searchKeyword);
            }
        }

        private async void generateToken(string searchKeyword)
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
                        findTransaction(searchKeyword, tokenResponse);
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

        private async void findTransaction(string searchKeyword, AccessTokenResponse tokenResponse)
        {
            try
            {
                string apifindtransactionUrl = "https://frontoffice.tax.planetpayment.ae/services/transactions/api/v2/custom-mapping/find-transaction/receipt/" + searchKeyword;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenResponse.access_token);
                    HttpResponseMessage response = await client.GetAsync(apifindtransactionUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string findtransactionapiData = await response.Content.ReadAsStringAsync();
                        FindTransactionApiResponse apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<FindTransactionApiResponse>(findtransactionapiData);
                        QrCodeGenerate(apiResponse);
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QrCodeGenerate(FindTransactionApiResponse response)
        {
            try
            {
                string fileSavePath = ConfigurationManager.AppSettings["FileSavePath"];
                // Set the file path for the PDF document
                string pdfFilePath = "Sales - " + response.receiptNumber + " - planet.pdf";
                string fullPath = Path.Combine(fileSavePath, pdfFilePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                // Create a new document
                Document doc = new Document();
                // Create a PdfWriter for the document
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fullPath, FileMode.Create));
                // Open the document for writing
                doc.Open();
                // Create a table to layout the content
                PdfPTable table = new PdfPTable(2); // 3 columns
                table.WidthPercentage = 100;
                float[] mainwidths = new float[] { 2f, 2f };
                table.SetWidths(mainwidths);
                // Column 1: Image

                PdfPCell leftcell = new PdfPCell();
                PdfPCell rightcell = new PdfPCell();
                leftcell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                rightcell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                leftcell.HorizontalAlignment = Element.ALIGN_LEFT;
                rightcell.HorizontalAlignment = Element.ALIGN_RIGHT;

                PdfPTable nestedTable = new PdfPTable(2);
                nestedTable.WidthPercentage = 100;
                float[] widths = new float[] { 1f, 2f };
                nestedTable.SetWidths(widths);

                PdfPCell imageCell = new PdfPCell();
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("planetlogo.png"); // Replace with the path to your image
                image.ScaleAbsolute(70, 70); // Set the size of the image
                imageCell.AddElement(image);
                imageCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                imageCell.PaddingTop = 10;


                // Column 3: Paragraph
                PdfPCell paragraphCell = new PdfPCell();
                paragraphCell.HorizontalAlignment = Element.ALIGN_CENTER;
                Paragraph paragraph = new Paragraph();
                Chunk chunk1 = new Chunk("By using our service, you agree to our T&Cs and Privacy Policy - visit www.planetpayment.ae for full details. Planet has been authorised by the FTA", FontFactory.GetFont(FontFactory.HELVETICA, 7));
                paragraph.Add(chunk1);
                paragraph.Add(new Chunk(Environment.NewLine));
                Chunk chunk4 = new Chunk(response.taxRefundTagNumber, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                paragraph.Add(chunk4);
                paragraph.Add(new Chunk(Environment.NewLine));
                Chunk chunk5 = new Chunk("www.planetpayment.ae", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                paragraph.Add(chunk5);
                paragraphCell.AddElement(paragraph);
                paragraphCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                // Add cells to the table

                nestedTable.AddCell(imageCell);
                nestedTable.AddCell(paragraphCell);
                rightcell.AddElement(nestedTable);
                table.AddCell(leftcell);
                table.AddCell(rightcell);
                // Add the table to the document
                doc.Add(table);

                // Close the document
                doc.Close();
                MessageBox.Show("QR Code Generated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class FindTransactionApiResponse
        {
            public string transactionCode { get; set; }
            public string taxRefundQrCode { get; set; }
            public string taxRefundTagNumber { get; set; }
            public string transactionId { get; set; }
            public string receiptNumber { get; set; }
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

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            string searchKeyword = searchtxtbox.Text.Trim();
            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Invoice No is empty.");
            }
            else
            {
                generateCancelToken(searchKeyword);
            }
        }

        private async void generateCancelToken(string searchKeyword)
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
                        cancelTransaction(searchKeyword, tokenResponse);
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

        private async void cancelTransaction(string searchKeyword, AccessTokenResponse tokenResponse)
        {
            try
            {
                Dictionary<string, object> jsonData = new Dictionary<string, object>
                {
                    { "receipt", searchKeyword },
                    { "note", "" },
                };
                string jsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                string apicanceltransactionUrl = "https://frontoffice.tax.planetpayment.ae/services/transactions/api/v2/custom-mapping/cancel-transaction/receipt";
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenResponse.access_token);
                    HttpResponseMessage response = await client.PostAsync(apicanceltransactionUrl, content);
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
    }
}
