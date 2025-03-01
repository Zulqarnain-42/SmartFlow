using SmartFlow.Common.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartFlow.Report.ReportViewer;
using System.Data.SqlClient;
using System.Configuration;

namespace SmartFlow.Report
{
    public partial class ItemHistory: Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public ItemHistory()
        {
            InitializeComponent();
        }

        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    try
                    {
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                        if (openForm == null)
                        {
                            ProductSelectionForm productSelection = new ProductSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };
                            productSelection.ProductDataSelected += UpdateProductTextBox;

                            CommonFunction.DisposeOnClose(productSelection);
                            productSelection.Show();
                        }
                        else
                        {
                            openForm.BringToFront();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while opening the product selection form: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
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

        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return; // Early return if the key is not Enter

            if (!string.IsNullOrEmpty(selectproducttxtbox.Text)) return; // Early return if TextBox is not empty

            // Check if ProductSelectionForm is already open
            Form existingForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));

            if (existingForm == null)
            {
                // Open the form if it's not already open
                ProductSelectionForm productSelection = new ProductSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                productSelection.ProductDataSelected += UpdateProductTextBox;

                CommonFunction.DisposeOnClose(productSelection);
                productSelection.Show();
            }
            else
            {
                // Bring the form to front if it's already open
                existingForm.BringToFront();
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (selectproducttxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(selectproducttxtbox, "Please Select Product.");
                selectproducttxtbox.Focus();
                return;
            }

            int productid = Convert.ToInt32(productidlbl.Text);
            // Define the custom date format and UK culture
            string format = "dd/MM/yyyy";
            var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture

            // Parse startDate and endDate from the textboxes using the custom format
            DateTime startDate;
            DateTime endDate;

            // Try parsing the dates from the textboxes with the exact format
            if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out startDate) &&
                DateTime.TryParseExact(invoicedatetotxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out endDate))
            {
                // Date parsing was successful
                Console.WriteLine($"Start Date: {startDate}");
                Console.WriteLine($"End Date: {endDate}");
            }
            else
            {
                startDate = DateTime.Parse(invoicedatetxtbox.Text);
                endDate = DateTime.Parse(invoicedatetotxtbox.Text);
            }

            // Now create a parameterized query
            string query = @"SELECT InvoiceDetailsTable.InvoiceNo [INVOICE NO],InvoiceTable.ClientName [CUSTOMER NAME],AccountSubControlTable.CompanyName [COMPANY NAME],
                InvoiceDetailsTable.Productid,InvoiceDetailsTable.Quantity [QUANTITY] 
                FROM InvoiceDetailsTable INNER JOIN InvoiceTable ON InvoiceTable.InvoiceNo = InvoiceDetailsTable.InvoiceNo 
                AND (@StartDate IS NULL OR InvoiceTable.InvoiceDate >= @StartDate) AND (@EndDate IS NULL OR InvoiceTable.InvoiceDate <= @EndDate) 
                AND (@IsNewRecord IS NULL OR InvoiceDetailsTable.IsNewRecord = @IsNewRecord) AND InvoiceDetailsTable.Productid = @Productid 
                INNER JOIN AccountSubControlTable ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID";

            // Use a parameterized query to avoid issues with direct string concatenation

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters for the query
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@IsNewRecord", true);  // Assuming the value is true for your query
                command.Parameters.AddWithValue("@Productid", productid);

                connection.Open();
                DataTable dataInvoice = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataInvoice);
                }

                if (dataInvoice.Rows.Count > 0)
                {
                    this.Close();
                    DetailItemHistory detailItemHistory = new DetailItemHistory(dataInvoice, startDate, endDate);
                    detailItemHistory.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(detailItemHistory);
                    detailItemHistory.Show();
                }
            }
        }

        private void ItemHistory_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; // Current date and time
            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            invoicedatetxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
