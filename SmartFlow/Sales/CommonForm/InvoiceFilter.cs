using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class InvoiceFilter : Form
    {
        public InvoiceFilter()
        {
            InitializeComponent();
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(startdatetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(startdatetxtbox,"Please Enter Start date");
                    startdatetxtbox.Focus();
                    return;
                }

                if(enddatetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(enddatetxtbox,"Please Enter End date");
                    enddatetxtbox.Focus();
                    return;
                }


            }catch (Exception ex) { throw ex; }
        }
    }
}
