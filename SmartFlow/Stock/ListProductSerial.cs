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

namespace SmartFlow.Stock
{
    public partial class ListProductSerial: Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public ListProductSerial()
        {
            InitializeComponent();
        }

        private void ListProductSerial_Load(object sender, EventArgs e)
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

            string invoicePattern = "PSR-%";

            // Now create a parameterized query
            string query = @"SELECT CASE WHEN ROW_NUMBER() OVER (PARTITION BY BoxSerialNoTable.InvoiceNo ORDER BY BoxSerialNoTable.ProductId) = 1
                THEN FORMAT(BoxSerialNoTable.CreatedAt, 'dd-MM-yyyy') ELSE NULL END AS [Date],
                CASE WHEN ROW_NUMBER() OVER (PARTITION BY BoxSerialNoTable.InvoiceNo ORDER BY BoxSerialNoTable.ProductId) = 1
                THEN BoxSerialNoTable.InvoiceNo ELSE NULL END AS [Vch/Bill No],
                BoxSerialNoTable.BoxSerialNoId AS [Box Serial ID],
                BoxSerialNoTable.ProductId AS [Product ID],
                ProductTable.ProductName AS [Item Details],
                BoxSerialNoTable.ProductMfr AS [MFR],
                BoxSerialNoTable.SerialNo AS [Serial No],
                BoxSerialNoTable.IsSold AS [Is Sold],
                BoxSerialNoTable.InvoiceNo AS [Invoice]
                FROM BoxSerialNoTable
                JOIN ProductTable ON ProductTable.ProductID = BoxSerialNoTable.ProductId
                WHERE BoxSerialNoTable.CreatedAt BETWEEN @StartDate AND @EndDate
                AND BoxSerialNoTable.InvoiceNo LIKE @InvoicePattern
                ORDER BY BoxSerialNoTable.InvoiceNo";

            // Use a parameterized query to avoid issues with direct string concatenation

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters for the query
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@InvoicePattern", invoicePattern);

                connection.Open();
                DataTable dataInvoice = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataInvoice);
                }

                if (dataInvoice.Rows.Count > 0)
                {
                    this.Close();
                    DetailProductSerial detailProductSerial = new DetailProductSerial(dataInvoice, startDate, endDate);
                    detailProductSerial.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(detailProductSerial);
                    detailProductSerial.Show();
                }
            }
        }
    }
}
