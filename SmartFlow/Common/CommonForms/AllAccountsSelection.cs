using System;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class AllAccountsSelection : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public AllAccountsSelection()
        {
            InitializeComponent();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetAllAccountInfo(searchtxtbox.Text, dgvallaccountselection);
        }
        private void AllAccountsSelection_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvallaccountselection.ClearSelection();
            CommonFunction.GetAllAccountInfo("",dgvallaccountselection);
        }
        private void dgvallaccountselection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvallaccountselection != null)
                {
                    if (dgvallaccountselection.Rows.Count > 0)
                    {
                        if(dgvallaccountselection.SelectedRows.Count == 1)
                        {
                            this.Close();
                        }
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgvallaccountselection_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedRow = dgvallaccountselection.CurrentRow;
                    if (selectedRow != null)
                    {
                        this.Close();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void AllAccountsSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    dgvallaccountselection.Focus();
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
    }
}
