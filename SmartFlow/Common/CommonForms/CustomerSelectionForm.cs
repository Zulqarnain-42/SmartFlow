using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class CustomerSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public CustomerSelectionForm()
        {
            InitializeComponent();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetCustomer(searchtxtbox.Text,dgvcustomer);
        }
        private void CustomerSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvcustomer.ClearSelection();
            CommonFunction.GetCustomer("",dgvcustomer);
        }
        private void dgvcustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvcustomer != null)
                {
                    if (dgvcustomer.Rows.Count > 0)
                    {
                        if (dgvcustomer.SelectedRows.Count == 1)
                        {
                            GlobalVariables.customeridglobal = Convert.ToInt32(dgvcustomer.CurrentRow.Cells["ID"].Value);
                            GlobalVariables.customernameglobal = dgvcustomer.CurrentRow.Cells["NAME"].Value.ToString();
                            GlobalVariables.customercodeglobal = dgvcustomer.CurrentRow.Cells["CODE"].Value.ToString();
                            GlobalVariables.customermobileglobal = dgvcustomer.CurrentRow.Cells["MOBILE"].Value.ToString();
                            GlobalVariables.customerrefrencegloba = dgvcustomer.CurrentRow.Cells["REF"].Value.ToString();
                            this.Close();
                        }
                    }
                }
            }
            catch(Exception ex) { throw ex; }
        }
        private void dgvcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedrow = dgvcustomer.CurrentRow;

                    if (selectedrow != null)
                    {
                        GlobalVariables.customeridglobal = Convert.ToInt32(dgvcustomer.CurrentRow.Cells["ID"].Value);
                        GlobalVariables.customernameglobal = dgvcustomer.CurrentRow.Cells["NAME"].Value.ToString();
                        GlobalVariables.customercodeglobal = dgvcustomer.CurrentRow.Cells["CODE"].Value.ToString();
                        GlobalVariables.customermobileglobal = dgvcustomer.CurrentRow.Cells["MOBILE"].Value.ToString();
                        GlobalVariables.customerrefrencegloba = dgvcustomer.CurrentRow.Cells["REF"].Value.ToString();
                        this.Close();
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void CustomerSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    // Double Enter detected
                    dgvcustomer.Focus();
                    lastEnterPressTime = DateTime.MinValue; // Reset to prevent multiple triggers
                }
                else
                {
                    // First Enter press detected
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true; // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key press
            }
        }
    }
}
