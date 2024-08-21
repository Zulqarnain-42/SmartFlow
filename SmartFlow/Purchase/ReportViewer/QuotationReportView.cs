using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Windows.Forms;

namespace SmartFlow.Purchase.ReportViewer
{
    public partial class QuotationReportView : Form
    {
        public QuotationReportView()
        {
            InitializeComponent();
        }

        private void QuotationReportView_Load(object sender, EventArgs e)
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
    }
}
