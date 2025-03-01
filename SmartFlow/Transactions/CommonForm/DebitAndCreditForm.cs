using SmartFlow.Common;
using System;
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
                // Clear previous errors before validation
                errorProvider.Clear();

                // Ensure the user selects either Debit or Credit
                if (!isdebitentrylbl.Checked && !iscreditentrylbl.Checked)
                {
                    errorProvider.SetError(isdebitentrylbl, "Please Select Debit Or Credit.");

                    // Focus should go to an interactive control
                    isdebitentrylbl.Focus();  // Change to a RadioButton or CheckBox if needed

                    return;
                }

                // Set global variables explicitly to avoid logical errors
                GlobalVariables.iscreditglobal = iscreditentrylbl.Checked;
                GlobalVariables.isdebitglobal = isdebitentrylbl.Checked;

                // Store short description in the global variable
                GlobalVariables.shortdescriptionglobal = shortdescriptiontxtbox.Text;

                // Close the form after setting global values
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
