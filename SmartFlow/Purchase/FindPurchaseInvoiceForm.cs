using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class FindPurchaseInvoiceForm : Form
    {
        public FindPurchaseInvoiceForm()
        {
            InitializeComponent();
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (invoicenotxtbox.Text.Trim().Length > 0)
                {
                    errorProvider.SetError(invoicenotxtbox,"");
                    invoicenotxtbox.Focus();
                    return;
                }

                if(invoicedatetxtbox.Text.Trim().Length > 0)
                {
                    errorProvider.SetError(invoicedatetxtbox,"");
                    invoicedatetxtbox.Focus();
                    return;
                }

                string query = string.Empty;
                query = "";

                DataTable dataInvoice = DatabaseAccess.Retrive(query);

                if (dataInvoice.Rows.Count > 0)
                {

                }

            }catch (Exception ex) { throw ex; }
        }
        private void FindPurchaseInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
