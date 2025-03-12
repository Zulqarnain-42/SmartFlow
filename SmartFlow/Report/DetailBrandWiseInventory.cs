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
    public partial class DetailBrandWiseInventory: Form
    {
        private DataTable _invoicedata;
        private DateTime _startdate;
        private DateTime _enddate;
        public DetailBrandWiseInventory(DataTable invoicedata, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            this._invoicedata = invoicedata;
            this._startdate = startdate;
            this._enddate = enddate;
        }
    }
}
