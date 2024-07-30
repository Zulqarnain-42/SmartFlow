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
                    errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice No.");
                    invoicenotxtbox.Focus();
                    return;
                }

                if(invoicedatetxtbox.Text.Trim().Length > 0)
                {
                    errorProvider.SetError(invoicedatetxtbox,"Please Enter Invoice Date.");
                    invoicedatetxtbox.Focus();
                    return;
                }

                if (salequotationradio.Checked)
                {
                    string query = string.Empty;
                    query = "";

                    DataTable invoiceData = DatabaseAccess.Retrive(query);
                    if (invoiceData.Rows.Count > 0)
                    {

                    }
                }
                else if (saleorderradio.Checked)
                {
                    string query = string.Empty;
                    query = "";

                    DataTable invoiceData = DatabaseAccess.Retrive(query);
                    if (invoiceData.Rows.Count > 0)
                    {

                    }
                }
                else if (saleinvoiceradio.Checked)
                {
                    string query = string.Empty;
                    query = "";

                    DataTable invoiceData = DatabaseAccess.Retrive(query);
                    if (invoiceData.Rows.Count > 0)
                    {

                    }
                }
                else if(salereturnradio.Checked)
                {
                    string query = string.Empty;
                    query = "";

                    DataTable invoiceData = DatabaseAccess.Retrive(query);
                    if (invoiceData.Rows.Count > 0)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Select One Sale Type.");
                }
                

            }catch (Exception ex) { throw ex; }
        }
        private void FindSaleInvoiceForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
