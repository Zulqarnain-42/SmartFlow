using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report
{
    public partial class DetailAccountWiseSale : Form
    {
        private DataTable _datainvoice;
        private DateTime _startdate;
        private DateTime _enddate;

        public DetailAccountWiseSale(DataTable datainvoice, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            _datainvoice = datainvoice;
            _startdate = startdate;
            _enddate = enddate;
        }

        private void DetailAccountWiseSale_Load(object sender, EventArgs e)
        {
            dgvlistinvoices.DataSource = _datainvoice;
            dgvlistinvoices.Columns["Particulars"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["Item Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["Invoice"].Visible = false;
            fromdatevaluelbl.Text = _startdate.ToString("dd-MM-yyyy");  // Format as needed
            todatevaluelbl.Text = _enddate.ToString("dd-MM-yyyy");
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal totalAmount = dgvlistinvoices.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["Amount"].Value != null)
                .Sum(row => Convert.ToDecimal(row.Cells["Amount"].Value));

            int totalQuantity = dgvlistinvoices.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["Qty."].Value != null)
                .Sum(row => Convert.ToInt32(row.Cells["Qty."].Value));

            totalqtyvaluelbl.Text = totalQuantity.ToString();
            totalamountvaluelbl.Text = totalAmount.ToString("N2");
        }
    }
}
