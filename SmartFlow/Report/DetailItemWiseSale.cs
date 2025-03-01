using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report.ReportViewer
{
    public partial class DetailItemWiseSale: Form
    {
        private DataTable _datainvoice;
        private DateTime _startdate;
        private DateTime _enddate;
        public DetailItemWiseSale(DataTable datainvoice, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            _datainvoice = datainvoice;
            _startdate = startdate;
            _enddate = enddate;
        }

        private void DetailItemWiseSale_Load(object sender, EventArgs e)
        {
            dgvlistitemwisesale.DataSource = _datainvoice;
            dgvlistitemwisesale.Columns["CUSTOMER NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistitemwisesale.Columns["COMPANY NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistitemwisesale.Columns["QUANTITY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistitemwisesale.Columns["Productid"].Visible = false;
            fromdatevaluelbl.Text = _startdate.ToString("dd-MM-yyyy");  // Format as needed
            todatevaluelbl.Text = _enddate.ToString("dd-MM-yyyy");
        }
    }
}
