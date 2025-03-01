using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report
{
    public partial class AccountWiseSale : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public AccountWiseSale()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string accountData = selectaccounttxtbox.Text;
                int clientid = Convert.ToInt32(accountidlbl.Text);

                if (clientid > 0)
                {
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

                    string invoicePattern = "_____";

                    // Now create a parameterized query
                    string query = @"SELECT CASE WHEN ROW_NUMBER() OVER (PARTITION BY InvoiceTable.InvoiceNo ORDER BY InvoiceDetailsTable.ProductName) = 1 
                    THEN InvoiceTable.InvoiceDate ELSE NULL END AS [Date],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY InvoiceTable.InvoiceNo ORDER BY InvoiceDetailsTable.ProductName) = 1 
                    THEN InvoiceTable.InvoiceNo ELSE NULL END AS [Vch/Bill No],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY InvoiceTable.InvoiceNo ORDER BY InvoiceDetailsTable.ProductName) = 1 
                    THEN InvoiceTable.ClientName ELSE NULL END AS [Particulars],
                    InvoiceDetailsTable.ProductName AS [Item Details],
                    InvoiceDetailsTable.Quantity AS [Qty.],
                    UnitTable.UnitName AS [Unit],
                    InvoiceDetailsTable.UnitSalePrice AS [Price],
                    InvoiceDetailsTable.ItemTotal AS [Amount],
                    InvoiceTable.InvoiceNo AS [Invoice] 
                    FROM InvoiceTable 
                    JOIN InvoiceDetailsTable ON InvoiceTable.InvoiceNo = InvoiceDetailsTable.InvoiceNo 
                    JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid 
                    WHERE InvoiceTable.InvoiceDate BETWEEN @StartDate AND @EndDate 
                    AND InvoiceTable.InvoiceNo LIKE @InvoicePattern 
                    AND InvoiceDetailsTable.IsNewRecord = @IsNewRecord 
                    AND InvoiceTable.ClientID = @ClientId
                    ORDER BY InvoiceTable.InvoiceDate, InvoiceTable.InvoiceNo;";

                    // Use a parameterized query to avoid issues with direct string concatenation

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);

                        // Add the parameters for the query
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@InvoicePattern", invoicePattern);
                        command.Parameters.AddWithValue("@IsNewRecord", true);  // Assuming the value is true for your query
                        command.Parameters.AddWithValue("@ClientId", clientid);

                        connection.Open();
                        DataTable dataInvoice = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataInvoice);
                        }

                        if (dataInvoice.Rows.Count > 0)
                        {
                            this.Close();
                            DetailAccountWiseSale detailAccountWiseSale = new DetailAccountWiseSale(dataInvoice, startDate, endDate);
                            detailAccountWiseSale.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(detailAccountWiseSale);
                            detailAccountWiseSale.Show();
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private async void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm accountsSelection = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountsSelection.AccountDataSelected += UpdateAccountInfo;

                        CommonFunction.DisposeOnClose(accountsSelection);
                        accountsSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private async void UpdateAccountInfo(object sender, AccountData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int accountid = e.AccountId;
                    string accountname = e.AccountName;
                    int accountheadid = e.AccountHeadId;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        accountidlbl.Text = accountid.ToString();
                        selectaccounttxtbox.Text = accountname;
                        accountheadidlbl.Text = accountheadid.ToString();
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

        private async void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                    {
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                        if (openForm == null)
                        {
                            AccountSelectionForm accountsSelection = new AccountSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };
                            accountsSelection.AccountDataSelected += UpdateAccountInfo;

                            CommonFunction.DisposeOnClose(accountsSelection);
                            accountsSelection.ShowDialog();
                        }
                        else
                        {
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void AccountWiseSale_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; // Current date and time
            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            invoicedatetxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
