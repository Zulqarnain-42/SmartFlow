using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class ModifySaleInvoice : Form
    {
        public ModifySaleInvoice()
        {
            InitializeComponent();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {

        }

        private void ModifySaleInvoice_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
