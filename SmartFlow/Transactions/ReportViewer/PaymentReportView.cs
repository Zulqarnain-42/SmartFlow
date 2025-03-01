using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
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
    public partial class PaymentReportView : Form
    {
        private string _invoiceNo = string.Empty;
        private bool _iscredit = false;
        private bool _isdebit = false;
        public PaymentReportView(string invoiceNo,bool iscredit,bool isdebit)
        {
            InitializeComponent();
            this._invoiceNo = invoiceNo;
            this._iscredit = iscredit;
            this._isdebit = isdebit;
        }

        private void PaymentReportView_Load(object sender, EventArgs e)
        {
            LoadCrystalReport(_invoiceNo);
        }

        private void LoadCrystalReport(string invoiceNo)
        {
            try
            {
                // Create a new instance of the report
                ReportDocument reportDocument = new ReportDocument();

                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Transactions\ReportViewer\Reports\PaymentReport.rpt");
                reportDocument.Load(reportPath);

                // Fetch data for a specific invoice
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetTransactionDetailsByInvoice", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                    command.Parameters.AddWithValue("@IsCredit", _iscredit);
                    command.Parameters.AddWithValue("@IsDebit", _isdebit);

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
