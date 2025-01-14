using SmartFlow.Common;
using System;
using System.Windows.Forms;
using SmartFlow.Common.Forms;
using System.Data;
using System.Collections.Generic;

namespace SmartFlow.Masters
{
    public partial class GroupingAccount : Form
    {
        public GroupingAccount()
        {
            InitializeComponent();
        }
        public GroupingAccount(int groupingaccountid)
        {
            InitializeComponent();
            this.groupingaccountidlbl.Text = groupingaccountid.ToString();
        }
        private void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if (openForm == null)
                {
                    AccountSelectionForm allaccountselection = new AccountSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };


                    allaccountselection.FormClosed += delegate
                    {
                        UpdateAccountInfo();
                    };
                    CommonFunction.DisposeOnClose(allaccountselection);
                    allaccountselection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
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
                if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm allAccountsSelection = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        allAccountsSelection.FormClosed += delegate
                        {
                            UpdateAccountInfo();
                        };
                        CommonFunction.DisposeOnClose(allAccountsSelection);
                        allAccountsSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
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

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                
                if(savebtn.Text == "UPDATE")
                {
                    bool isupdated = UpdateGrouping();
                    if (isupdated) 
                    { 
                        MessageBox.Show("Updated Successfully!"); 
                        ResetControl();
                    }
                }
                else
                {
                    bool isInserted = InsertGrouping();
                    if (isInserted) 
                    { 
                        MessageBox.Show("Saved Successfully!"); 
                        ResetControl();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetControl()
        {
            groupingnametxtbox.Text = string.Empty;
            descriptiontxtbox.Text = string.Empty;
            selectaccounttxtbox.Text = string.Empty;
            dgvgroupingaccount.Rows.Clear();
        }

        private bool UpdateGrouping()
        {
            // Update AccountGroupingTable
            string tableName = "AccountGroupingTable";
            string whereClause = "AccountGroupid = '" + groupingaccountidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "GroupName", groupingnametxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() }
            };

            // Call the common function for the update
            bool result = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);

            if (result)
            {
                string subTableName = "AccountGroupingDetailsTable";
                string delWhereClause = "AccountGroupId = @AccountGroupId";

                var parameter = new Dictionary<string, object>
                {
                    { "AccountGroupId", groupingaccountidlbl.Text }
                };

                bool isDeleted = DatabaseAccess.ExecuteQuery(subTableName, "DELETE", parameter, whereClause);
                if (isDeleted)
                {
                    string subaccounttable = "AccountGroupingDetailsTable";
                    // Insert into AccountGroupingDetailsTable for each DataGridView row
                    foreach (DataGridViewRow row in dgvgroupingaccount.Rows)
                    {

                        if (row.IsNewRow) continue;

                        int accountId = Convert.ToInt32(row.Cells["accountidcolumn"].Value);
                        string accountName = row.Cells["accountnamecolumn"].Value.ToString();

                        var detailData = new Dictionary<string, object>
                        {
                            { "AccountId", accountId },
                            { "AccountName", accountName },
                            { "AccountGroupId", groupingaccountidlbl.Text },
                        };

                        result = DatabaseAccess.ExecuteQuery(subaccounttable, "INSERT", detailData);
                    }
                }
                
                return result;
            }
            else
            {
                return false;
            }
        }

        private bool InsertGrouping()
        {
            // Update AccountGroupingTable
            string tableName = "AccountGroupingTable";

            var columnData = new Dictionary<string, object>
            {
                { "GroupName", groupingnametxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "GroupingCode", Guid.NewGuid().ToString() }
            };

            // Call the common function for the update
            int result = DatabaseAccess.InsertDataId(tableName, columnData);

            if (result > 0)
            {
                string subtableName = "AccountGroupingDetailsTable";
                // Insert into AccountGroupingDetailsTable for each DataGridView row
                foreach (DataGridViewRow row in dgvgroupingaccount.Rows)
                {
                    if (row.IsNewRow) continue;

                    int accountId = Convert.ToInt32(row.Cells["accountidcolumn"].Value);
                    string accountName = row.Cells["accountnamecolumn"].Value.ToString();

                    var detailData = new Dictionary<string, object>
                    {
                        { "AccountId", accountId },
                        { "AccountName", accountName },
                        { "AccountGroupId", result }
                    };

                    bool subresult = DatabaseAccess.ExecuteQuery(subtableName, "INSERT", detailData);
                }
                return true;
            }
            else
            {
                return false;
            }
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
        private void GroupingAccount_Load(object sender, EventArgs e)
        {
            string labeldata = groupingaccountidlbl.Text;
            bool isInteger = int.TryParse(labeldata, out int result);
            if (isInteger)
            {
                FindRecord(result);
            }
        }
        private void FindRecord(int groupingid)
        {
            try
            {
                string query = string.Format("SELECT AccountGroupid,GroupName,Description,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,CompanyId,AddedBy,UserId," +
                    "GroupingCode FROM AccountGroupingTable WHERE AccountGroupid = @AccountGroupid");

                var parameters = new Dictionary<string, object>
                {
                    { "AccountGroupid",groupingid }
                };

                DataTable dtlistgrouping = DatabaseAccess.RetrieveData(query, parameters);

                if (dtlistgrouping != null && dtlistgrouping.Rows.Count > 0)
                {
                    groupingnametxtbox.Text = dtlistgrouping.Rows[0]["GroupName"].ToString();
                    descriptiontxtbox.Text = dtlistgrouping.Rows[0]["Description"].ToString();
                    groupingaccountidlbl.Text = dtlistgrouping.Rows[0]["AccountGroupid"].ToString();
                    groupingcodelbl.Text = dtlistgrouping.Rows[0]["GroupingCode"].ToString();

                    string querydetails = string.Format("SELECT AccountId [accountidcolumn],AccountName [accountnamecolumn] FROM AccountGroupingDetailsTable " +
                        "WHERE AccountGroupId = '" + groupingid + "'");

                    DataTable dtlistdetails = DatabaseAccess.Retrive(querydetails);

                    if(dtlistdetails != null && dtlistdetails.Rows.Count > 0)
                    {
                        dgvgroupingaccount.Rows.Clear();

                        // Loop through each DataRow in the DataTable
                        foreach (DataRow row in dtlistdetails.Rows)
                        {
                            int rowIndex = dgvgroupingaccount.Rows.Add();
                            DataGridViewRow gridrow = dgvgroupingaccount.Rows[rowIndex];

                            gridrow.Cells[0].Value = row["accountidcolumn"];
                            gridrow.Cells[1].Value = row["accountnamecolumn"];
                        }
                    }

                    savebtn.Text = "UPDATE";
                }

            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void rEMOVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the current cell is not null and belongs to a valid row
                if (dgvgroupingaccount.CurrentCell != null && dgvgroupingaccount.CurrentCell.RowIndex >= 0)
                {
                    // Confirm deletion (optional)
                    var confirmResult = MessageBox.Show("Are you sure to delete this row?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // Remove the selected row
                        dgvgroupingaccount.Rows.RemoveAt(dgvgroupingaccount.CurrentCell.RowIndex);
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
