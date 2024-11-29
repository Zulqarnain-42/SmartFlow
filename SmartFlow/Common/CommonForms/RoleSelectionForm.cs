using System;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class RoleSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public RoleSelectionForm()
        {
            InitializeComponent();
        }

        private void RoleSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvRolesList.ClearSelection();
            CommonFunction.GetRoleInfo("", dgvRolesList);
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetRoleInfo(searchtxtbox.Text, dgvRolesList);
        }

        private void dgvRolesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRolesList != null)
                {
                    if (dgvRolesList.Rows.Count > 0)
                    {
                        if (dgvRolesList.SelectedRows.Count == 1)
                        {
                            GlobalVariables.roleidglobal = Convert.ToInt32(dgvRolesList.CurrentRow.Cells[0].Value);
                            GlobalVariables.rolenameglobal = dgvRolesList.CurrentRow.Cells[1].Value.ToString();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvRolesList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedRow = dgvRolesList.CurrentRow;
                    if (selectedRow != null)
                    {
                        GlobalVariables.roleidglobal = Convert.ToInt32(dgvRolesList.CurrentRow.Cells[0].Value);
                        GlobalVariables.rolenameglobal = dgvRolesList.CurrentRow.Cells[1].Value.ToString();
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RoleSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
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
                    dgvRolesList.Focus();
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
