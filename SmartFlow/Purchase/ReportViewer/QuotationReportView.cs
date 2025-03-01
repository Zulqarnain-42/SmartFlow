using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartFlow.Purchase.ReportViewer
{
    public partial class QuotationReportView : Form
    {
        private string _invoiceNo = null;
        private ReportDocument reportDocument;
        public QuotationReportView(string invoiceNo)
        {
            InitializeComponent();
            _invoiceNo = invoiceNo;
        }

        private void QuotationReportView_Load(object sender, EventArgs e)
        {
            LoadCrystalReport(_invoiceNo);
        }

        private void LoadCrystalReport(string invoiceNo)
        {
            try
            {
                // Create a new instance of the report
                reportDocument = new ReportDocument();

                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Purchase\ReportViewer\Reports\PurchaseQuotationReport.rpt");
                reportDocument.Load(reportPath);

                // Fetch data for a specific invoice
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetInvoiceDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                    command.Parameters.AddWithValue("@IsNewRecord", true);

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

        private void QuotationReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeReport();
        }

        private void DisposeReport()
        {
            if (reportDocument != null)
            {
                reportDocument.Close();
                reportDocument.Dispose();
                reportDocument = null;
                GC.Collect(); // Force garbage collection
            }
        }
    }
}
