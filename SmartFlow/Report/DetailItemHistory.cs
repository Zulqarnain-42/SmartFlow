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
    public partial class DetailItemHistory: Form
    {
        private DataTable _datainvoice;
        private DateTime _startdate;
        private DateTime _enddate;
        public DetailItemHistory(DataTable datainvoice, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            _datainvoice = datainvoice;
            _startdate = startdate;
            _enddate = enddate;
        }

        private void DetailItemHistory_Load(object sender, EventArgs e)
        {
            dgvlistitemwisehistory.DataSource = _datainvoice;
            dgvlistitemwisehistory.Columns["CUSTOMER NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistitemwisehistory.Columns["COMPANY NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistitemwisehistory.Columns["QUANTITY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistitemwisehistory.Columns["Productid"].Visible = false;
            fromdatevaluelbl.Text = _startdate.ToString("dd-MM-yyyy");  // Format as needed
            todatevaluelbl.Text = _enddate.ToString("dd-MM-yyyy");
        }
    }
}
