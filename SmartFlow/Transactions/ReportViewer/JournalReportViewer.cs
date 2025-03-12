using CrystalDecisions.CrystalReports.Engine;
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

namespace SmartFlow.Transactions.ReportViewer
{
    public partial class JournalReportViewer: Form
    {
        private string _invoiceNo = string.Empty;
        public JournalReportViewer(string invoiceNo)
        {
            InitializeComponent();
            _invoiceNo = invoiceNo;
        }

        private void JournalReportViewer_Load(object sender, EventArgs e)
        {
            LoadCrystalReport(_invoiceNo);
        }

        private void LoadCrystalReport(string invoiceNo)
        {
            try
            {
                // Create a new instance of the report
                ReportDocument reportDocument = new ReportDocument();

                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Transactions\ReportViewer\Reports\JournalReport.rpt");
                reportDocument.Load(reportPath);

                // Fetch data for a specific invoice
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetTransactionDetailsByInvoiceNo", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                    command.Parameters.AddWithValue("@IsNewRecord", true);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "TransactionDetails");

                    // Set the data source for the report
                    reportDocument.SetDataSource(dataSet.Tables["TransactionDetails"]);
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
