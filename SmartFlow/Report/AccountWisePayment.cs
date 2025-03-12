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
using System.Data.SqlClient;
using System.Configuration;

namespace SmartFlow.Report
{
    public partial class AccountWisePayment : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public AccountWisePayment()
        {
            InitializeComponent();
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

        private void AccountWisePayment_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; // Current date and time
            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            invoicedatetxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

                    string invoicePattern = "PA-%";

                    // Define the query with parameters
                    string query = @"SELECT T.TransactionId, T.InvoiceNo, T.InvoiceNo AS HIDDENINVOICE, T.InvoiceDate, T.TransactionCode, 
                        T.LongDescription, T.CurrencyId, T.CurrencyName, T.CurrencySymbol,
                        T.ConversionRate, T.CreatedAt, T.UpdatedAt, T.CreatedDay, T.UpdatedDay, T.UserId, T.AddedBy, 
                        T.CompanyId, T.VoucherInfo, TD.TransactionDetailId, TD.TransactionId, TD.AccountId, 
                        TD.AccountName, TD.AccountCode, TD.IsDebit, TD.IsCredit, TD.ShortDescription, 
                        TD.DebitAmount, TD.CreditAmount, TD.InvoiceNo, TD.DebitOrCredit, TD.TransactionCode
                        FROM TransactionTable T
                        INNER JOIN TransactionDetailTable TD ON T.InvoiceNo = TD.InvoiceNo
                        WHERE T.InvoiceDate BETWEEN @StartDate AND @EndDate
                        AND T.InvoiceNo LIKE @InvoicePattern
                        AND IsNewRecord = @IsNewRecord
                        ORDER BY T.InvoiceDate, T.InvoiceNo, TD.TransactionDetailId";

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
    }
}
