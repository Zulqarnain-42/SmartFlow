using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class ModifyPaymentVoucher : Form
    {
        public ModifyPaymentVoucher()
        {
            InitializeComponent();
        }

        private void invoicenotxtbox_TextChanged(object sender, EventArgs e)
        {
            string prefix = "PIS-";
            if (!invoicenotxtbox.Text.StartsWith(prefix))
            {
                invoicenotxtbox.Text = prefix;
                invoicenotxtbox.SelectionStart = invoicenotxtbox.Text.Length; // Place the cursor at the end
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {

        }

        private void ModifyPaymentVoucher_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
