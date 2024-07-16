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
    public partial class SupplierSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public SupplierSelectionForm()
        {
            InitializeComponent();
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetSupplier(searchtxtbox.Text,dgvsupplier);
        }

        private void SupplierSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvsupplier.ClearSelection();
            CommonFunction.GetSupplier("",dgvsupplier);
        }

        private void dgvsupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvsupplier != null)
                {
                    if (dgvsupplier.Rows.Count > 0)
                    {
                        if(dgvsupplier.SelectedRows.Count == 1)
                        {
                            GlobalVariables.supplieridglobal = Convert.ToInt32(dgvsupplier.CurrentRow.Cells["ID"].Value);
                            GlobalVariables.suppliernameglobal = dgvsupplier.CurrentRow.Cells["NAME"].Value.ToString();
                            GlobalVariables.suppliercodeglobal = dgvsupplier.CurrentRow.Cells["CODE"].Value.ToString();
                            this.Close();
                        }
                    }
                }
            }catch(Exception ex) { throw ex; }
        }

        private void dgvsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) 
                {
                    DataGridViewRow selectedrow = dgvsupplier.CurrentRow;

                    if (selectedrow != null) 
                    {
                        GlobalVariables.supplieridglobal = Convert.ToInt32(dgvsupplier.CurrentRow.Cells["ID"].Value);
                        GlobalVariables.suppliernameglobal = dgvsupplier.CurrentRow.Cells["NAME"].Value.ToString();
                        GlobalVariables.suppliercodeglobal = dgvsupplier.CurrentRow.Cells["CODE"].Value.ToString();
                        this.Close();
                    }
                }
            }catch(Exception ex) { throw ex; }
        }

        private void SupplierSelectionForm_KeyDown(object sender, KeyEventArgs e)
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
                    dgvsupplier.Focus();
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
