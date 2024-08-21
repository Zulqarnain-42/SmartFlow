using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock.ReportViewer
{
    public partial class BookItemViewer : Form
    {
        public BookItemViewer()
        {
            InitializeComponent();
        }

        private void BookItemViewer_Load(object sender, EventArgs e)
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
