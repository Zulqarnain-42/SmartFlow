using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class DetailProductSerial: Form
    {
        private DataTable _invoiceData;
        private DateTime _startdate;
        private DateTime _enddate;

        public DetailProductSerial(DataTable invoiceData, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            _invoiceData = invoiceData;
            _startdate = startdate;
            _enddate = enddate;
        }

        private void DetailProductSerial_Load(object sender, EventArgs e)
        {
            dgvlistproductserial.DataSource = _invoiceData;
            dgvlistproductserial.Columns["Vch/Bill No"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvlistproductserial.Columns["Item Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistproductserial.Columns["Product ID"].Visible = false;
            dgvlistproductserial.Columns["Invoice"].Visible = false;
            fromdatevaluelbl.Text = _startdate.ToString();
            todatevaluelbl.Text = _enddate.ToString();
        }

        private void dgvlistproductserial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
