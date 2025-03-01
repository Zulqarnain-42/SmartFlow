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
    public partial class ListMaterialIssue : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public ListMaterialIssue()
        {
            InitializeComponent();
        }

        private void ListMaterialIssue_Load(object sender, EventArgs e)
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

            string invoicePattern = "MIP-%";

            // Use parameterized SQL query to avoid issues with direct string concatenation
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
                ORDER BY InvoiceTable.InvoiceDate, InvoiceTable.InvoiceNo;";

            // Use SqlCommand to execute the parameterized query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters for the query
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@InvoicePattern", invoicePattern);
                command.Parameters.AddWithValue("@IsNewRecord", true); // Assuming 'true' is the correct value for your query

                connection.Open();
                DataTable dataInvoice = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataInvoice);
                }

                if (dataInvoice.Rows.Count > 0)
                {
                    this.Close();
                    DetailMaterialIssue detailMaterialIssue = new DetailMaterialIssue(dataInvoice, startDate, endDate);
                    detailMaterialIssue.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(detailMaterialIssue);
                    detailMaterialIssue.Show();
                }
            }
        }
    }
}
