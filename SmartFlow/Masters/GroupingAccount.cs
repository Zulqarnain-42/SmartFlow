using SmartFlow.Common;
using System;
using System.Windows.Forms;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using System.Data;
using System.Text.RegularExpressions;

namespace SmartFlow.Masters
{
    public partial class GroupingAccount : Form
    {
        public GroupingAccount()
        {
            InitializeComponent();
        }
        private void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
            if (openForm == null)
            {
                AccountSelectionForm allaccountselection = new AccountSelectionForm();
                allaccountselection.ShowDialog();
                UpdateAccountInfo();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateAccountInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.accountnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.accountnameglobal) &&
                GlobalVariables.accountidglobal > 0)
            {
                accountidlbl.Text = GlobalVariables.accountidglobal.ToString();
                selectaccounttxtbox.Text = GlobalVariables.accountnameglobal.ToString();
            }
        }
        private void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if (openForm == null) 
                {
                    AccountSelectionForm allAccountsSelection = new AccountSelectionForm();
                    allAccountsSelection.ShowDialog();
                    UpdateAccountInfo();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void GroupingAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectaccounttxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectaccounttxtbox,"Please Select Account.");
                    selectaccounttxtbox.Focus();
                    return;
                }

                int accountid = Convert.ToInt32(accountidlbl.Text);
                string accountName = selectaccounttxtbox.Text;

                bool productExists = false;
                foreach (DataGridViewRow row in dgvgroupingaccount.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["accountidcolumn"].Value != null && row.Cells["accountidcolumn"].Value.ToString() == accountidlbl.Text.ToString())
                        {
                            MessageBox.Show("Account Exist in Grouping");
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvgroupingaccount.Rows.Add(accountid, accountName);
                }

                accountidlbl.Text = string.Empty;
                selectaccounttxtbox.Text = string.Empty;
                selectaccounttxtbox.Focus();

            }catch (Exception ex) { throw ex; }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if(groupingnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(groupingnametxtbox, "Please Select Account.");
                    groupingnametxtbox.Focus();
                    return;
                }

                string groupingName = CommonFunction.CleanText(groupingnametxtbox.Text);

                DataTable dtgrouping = DatabaseAccess.Retrive("SELECT AccountGroupid,GroupName,Description FROM AccountGroupingTable WHERE GroupName " +
                    "LIKE '" + groupingName + "'");
                if(dtgrouping!=null && dtgrouping.Rows.Count > 0)
                {
                    MessageBox.Show("Group Already Exist.");
                }
                else
                {
                    bool result = false;
                    string groupingaccounttype = "Account Grouping";
                    string accountgroupcode = Guid.NewGuid().ToString();
                    string addgroup = string.Format("INSERT INTO AccountGroupingTable (GroupName,Description,CreatedAt,CreatedDay,GroupingCode,AccountGroupingType) " +
                        "VALUES ('" + groupingName + "','" + descriptiontxtbox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                        "'" + DateTime.Now.DayOfWeek + "','" + accountgroupcode + "','" + groupingaccounttype + "'); SELECT SCOPE_IDENTITY();");

                    int groupaccountid = DatabaseAccess.InsertId(addgroup);

                    if(groupaccountid > 0)
                    {
                        foreach(DataGridViewRow row in dgvgroupingaccount.Rows)
                        {
                            if(row.IsNewRow) { continue; }

                            int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value.ToString());
                            string accountname = row.Cells["accountnamecolumn"].Value.ToString();

                            string groupaccountdetail = string.Format("INSERT INTO AccountGroupingDetailsTable (AccountId,AccountName,AccountGroupId,AccountGroupCode) " +
                                "VALUES ('" + accountid + "','" + accountname + "','" + groupaccountid + "','" + accountgroupcode + "')");

                            result = DatabaseAccess.Insert(groupaccountdetail);
                        }

                        if (result)
                        {
                            MessageBox.Show("Saved Successfully.");
                        }
                    }
                }
            }catch (Exception ex) { throw ex; }
        }
        private void dgvgroupingaccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int accountid = Convert.ToInt32(dgvgroupingaccount.CurrentRow.Cells[0].Value);

                if (accountid > 0)
                {
                    foreach (DataGridViewRow row in dgvgroupingaccount.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvgroupingaccount.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (groupingnametxtbox.Text.Trim().Length > 0) { return true; }
            if (descriptiontxtbox.Text.Trim().Length > 0) { return true; }
            if (selectaccounttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvgroupingaccount.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
    }
}
