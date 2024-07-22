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
    public partial class AccountSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public AccountSelectionForm()
        {
            InitializeComponent();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetAccountInfo(searchtxtbox.Text, dgvaccount);
        }
        private void AccountSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvaccount.ClearSelection();
            CommonFunction.GetAccountInfo("", dgvaccount);
        }
        private void dgvaccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvaccount != null)
                {
                    if (dgvaccount.Rows.Count > 0)
                    {
                        if (dgvaccount.SelectedRows.Count == 1)
                        {
                            GlobalVariables.accountidglobal = Convert.ToInt32(dgvaccount.CurrentRow.Cells[0].Value);
                            GlobalVariables.accountnameglobal = dgvaccount.CurrentRow.Cells[1].Value.ToString();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void dgvaccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedRow = dgvaccount.CurrentRow;
                    if (selectedRow != null)
                    {
                        GlobalVariables.accountidglobal = Convert.ToInt32(selectedRow.Cells[0].Value);
                        GlobalVariables.accountnameglobal = selectedRow.Cells[1].Value.ToString();
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void AccountSelectionForm_KeyDown(object sender, KeyEventArgs e)
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
                    dgvaccount.Focus();
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
