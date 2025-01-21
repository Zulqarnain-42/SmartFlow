using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartFlow.Masters.ReportViewer
{
    public partial class AccountGroupListReportViewer : Form
    {
        public AccountGroupListReportViewer()
        {
            InitializeComponent();
        }
        private void AccountGroupListReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(@"C:\Users\FABT\source\repos\SmartFlow\SmartFlow\Purchase\ReportViewer\Reports\PurchaseQuotationReport.rpt");

                // If using a DataSet
                // DataSet ds = GetYourDataSet();
                // reportDocument.SetDataSource(ds);

                // If using a direct database connection
                // reportDocument.SetDatabaseLogon("username", "password", "server", "database");

                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadCrystalReport(string invoiceNo)
        {
            try
            {
                // Create a new instance of the report
                ReportDocument reportDocument = new ReportDocument();

                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Sales\ReportViewer\Reports\SaleInvoiceReport.rpt");
                reportDocument.Load(reportPath);

                // Fetch data for a specific invoice
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetInvoiceDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "InvoiceDetailsTable");

                    // Set the data source for the report
                    reportDocument.SetDataSource(dataSet.Tables["InvoiceDetailsTable"]);
                }

                // Set the CrystalReportViewer's ReportSource
                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
