using SmartFlow.Common;
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

namespace SmartFlow.Transactions
{
    public partial class ListPayment : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public ListPayment()
        {
            InitializeComponent();
        }

        private void ListPayment_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; // Current date and time
            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            invoicedatetxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            // Define the custom date format and UK culture
            string format = "dd/MM/yyyy";
            var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture

            // Parse startDate and endDate from the textboxes using the custom format
            DateTime startDate;
            DateTime endDate;

            // Check if both dates are valid based on the custom format
            if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out startDate) &&
                DateTime.TryParseExact(invoicedatetotxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out endDate))
            {
                // Date parsing was successful
                Console.WriteLine($"Start Date: {startDate.ToString(format)}");
                Console.WriteLine($"End Date: {endDate.ToString(format)}");
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

            // Create SQL connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the SQL command
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@InvoicePattern", invoicePattern);
                command.Parameters.AddWithValue("@IsNewRecord", true); // Assuming 'true' is the correct value for your query

                // Open the connection and execute the query
                connection.Open();
                DataTable dataInvoice = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataInvoice);
                }

                if (dataInvoice.Rows.Count > 0)
                {
                    this.Close();
                    DetailPayment detailPayment = new DetailPayment(dataInvoice);
                    detailPayment.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(detailPayment);
                    detailPayment.Show();
                }
            }
        }
    }
}
