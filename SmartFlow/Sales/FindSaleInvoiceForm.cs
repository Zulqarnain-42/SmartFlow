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
    public partial class FindSaleInvoiceForm : Form
    {
        public FindSaleInvoiceForm()
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

                DataTable invoiceData = DatabaseAccess.Retrive(query);
                if (invoiceData.Rows.Count > 0)
                {

                }

            }catch (Exception ex) { throw ex; }
        }
        private void FindSaleInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
