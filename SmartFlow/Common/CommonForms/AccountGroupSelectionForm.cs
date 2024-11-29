using System;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class AccountGroupSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public AccountGroupSelectionForm()
        {
            InitializeComponent();
        }
        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    dgvaccountgroupselection.Focus();
                    lastEnterPressTime = DateTime.MinValue;
                }
                else
                {
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetAccountGroupInfo(searchtxtbox.Text, dgvaccountgroupselection);
        }
        private void AccountGroupSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvaccountgroupselection.ClearSelection();
            CommonFunction.GetAccountGroupInfo("", dgvaccountgroupselection);
        }
        private void dgvaccountgroupselection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvaccountgroupselection != null && dgvaccountgroupselection.Rows.Count > 0)
                {
                    if (dgvaccountgroupselection.SelectedRows.Count == 1)
                    {
                        GlobalVariables.accountidglobal = Convert.ToInt32(dgvaccountgroupselection.CurrentRow.Cells[0].Value);
                        GlobalVariables.accountnameglobal = dgvaccountgroupselection.CurrentRow.Cells[1].Value.ToString();
                        GlobalVariables.accountheadidglobal = Convert.ToInt32(dgvaccountgroupselection.CurrentRow.Cells["AccountHead_ID"].Value);
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgvaccountgroupselection_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedRow = dgvaccountgroupselection.CurrentRow;
                    if (selectedRow != null)
                    {
                        GlobalVariables.accountidglobal = Convert.ToInt32(dgvaccountgroupselection.CurrentRow.Cells[0].Value);
                        GlobalVariables.accountnameglobal = dgvaccountgroupselection.CurrentRow.Cells[1].Value.ToString();
                        GlobalVariables.accountheadidglobal = Convert.ToInt32(dgvaccountgroupselection.CurrentRow.Cells["AccountHead_ID"].Value);
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void AccountGroupSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
