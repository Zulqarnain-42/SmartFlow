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
    public partial class MaterialIssueReportView : Form
    {
        private string _invoiceNo = string.Empty;
        public MaterialIssueReportView(string invoiceNo)
        {
            InitializeComponent();
            this._invoiceNo = invoiceNo;
        }

        private void MaterialIssueReportView_Load(object sender, EventArgs e)
        {
            LoadCrystalReport(_invoiceNo);
        }

        private void LoadCrystalReport(string invoiceNo)
        {
            try
            {
                // Create a new instance of the report
                ReportDocument reportDocument = new ReportDocument();

                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Transactions\ReportViewer\Reports\MaterialIssueParty.rpt");
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
    }
}
