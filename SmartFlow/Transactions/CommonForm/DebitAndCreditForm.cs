using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions.CommonForm
{
    public partial class DebitAndCreditForm : Form
    {
        public DebitAndCreditForm()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (!isdebitentrylbl.Checked && !iscreditentrylbl.Checked)
                {
                    errorProvider.SetError(isdebitentrylbl,"Please Select Debit Or Credit.");
                    isdebitentrylbl.Focus();
                    return;
                }

                if (iscreditentrylbl.Checked) 
                {
                    GlobalVariables.iscreditglobal = true;
                }

                if (isdebitentrylbl.Checked)
                {
                    GlobalVariables.isdebitglobal = true;
                }

                if(!string.IsNullOrEmpty(shortnarationtxtbox.Text) && !string.IsNullOrWhiteSpace(shortnarationtxtbox.Text))
                {
                    GlobalVariables.shortdescriptionglobal = shortnarationtxtbox.Text;
                }

                this.Close();

            }
            catch(Exception ex) { throw ex; }
        }

        private void DebitAndCreditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) 
            {
                isdebitentrylbl.Checked = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.C) 
            {
                iscreditentrylbl.Checked = true;
                e.Handled = true;
            }
        }
    }
}
