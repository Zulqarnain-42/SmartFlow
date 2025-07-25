﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AccountGroupHistory : Form
    {

        private int accountheadid = 0;
        private string accountheadname = null;
        private int currentRowIndex = 0;
        private int currentCellIndex = 0;

        public AccountGroupHistory()
        {
            InitializeComponent();
        }

        private async void AccountGroupHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (await AreAnyTextBoxesFilledAsync())
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

        private async Task FillGridAsync(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTable = new DataTable();

                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountControlID [ID],AccountHeadName [ACCOUNT HEAD],AccountControlName [ACCOUNT NAME],CreatedAt [CREATED],CreatedDay [DAY]," +
                        "AccountHead_ID [HEAD ID] FROM AccountControlTable";
                }
                else
                {
                    query = await BuildSearchQueryAccountGroupAsync(searchvalue);
                }

                // Use Task.Run to run the synchronous method asynchronously if needed.
                dataTable = await Task.Run(() => DatabaseAccess.RetrieveAsync(query));  // Run the synchronous database retrieval async

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        accountgroupdatagridview.DataSource = dataTable;
                        accountgroupdatagridview.Columns[0].Width = 100;
                        accountgroupdatagridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountgroupdatagridview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountgroupdatagridview.Columns[3].Width = 100;
                        accountgroupdatagridview.Columns[4].Width = 100;
                        accountgroupdatagridview.Columns[5].Visible = false;
                    }
                    else
                    {
                        accountgroupdatagridview.DataSource = dataTable;
                    }
                }
                else
                {
                    accountgroupdatagridview.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < accountgroupdatagridview.Rows.Count &&
                    currentCellIndex < accountgroupdatagridview.Rows[currentRowIndex].Cells.Count)
                {
                    accountgroupdatagridview.CurrentCell = accountgroupdatagridview.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AccountGroupHistory_Load(object sender, EventArgs e)
        {
            await FillGridAsync("");
        }

        private async void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            await FillGridAsync(searchtxtbox.Text.Trim());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (accountgroupdatagridview != null)
                {
                    if(accountgroupdatagridview.Rows.Count > 0)
                    {
                        if(accountgroupdatagridview.SelectedRows.Count == 1)
                        {
                           
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available.");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task<int> GetFirstVisibleRowIndexAsync(DataGridView dataGridView)
        {
            // Simulate asynchronous behavior if needed (e.g., for future async operations)
            await Task.Yield(); // This just yields control back to the caller asynchronously

            int firstDisplayedRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            int displayedRowCount = dataGridView.DisplayedRowCount(true); // Pass true to include partially displayed rows

            if (firstDisplayedRowIndex == -1 || displayedRowCount == 0)
            {
                return -1; // DataGridView is not displaying any rows
            }

            return firstDisplayedRowIndex + displayedRowCount - 1;
        }

        private async Task<int> GetFirstVisibleCellIndexAsync(DataGridView dataGridView)
        {
            // Simulate async operation if necessary in future
            await Task.Yield(); // Placeholder for async code if needed

            int horizontalOffset = dataGridView.HorizontalScrollingOffset;
            int visibleWidth = dataGridView.ClientRectangle.Width;

            int totalWidth = 0;
            int columnIndex = 0;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                totalWidth += column.Width;

                if (totalWidth > horizontalOffset + visibleWidth)
                {
                    return columnIndex - 1; // Return the index of the last fully visible column
                }

                columnIndex++;
            }

            return dataGridView.Columns.Count - 1;
        }

        private async void accountgroupdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = await Task.Run(() => GetFirstVisibleRowIndexAsync(accountgroupdatagridview));
            int firstVisibleCellIndex = await Task.Run(() => GetFirstVisibleCellIndexAsync(accountgroupdatagridview));

            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (groupnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(groupnametxtbox, "Please Enter Group Name");
                    groupnametxtbox.Focus();
                    return;
                }

                if (!rbassets.Checked && !rbequity.Checked && !rbexpense.Checked && !rbliabilities.Checked && !rbrevenue.Checked)
                {
                    errorProvider.SetError(rbassets, "Please Select One Radio");
                    rbassets.Focus();
                    return;
                }

                if (rbassets.Checked)
                {
                    accountheadid = 1;
                    accountheadname = "ASSETS";
                }
                else if (rbliabilities.Checked)
                {
                    accountheadid = 2;
                    accountheadname = "LIABILITIES";
                }
                else if (rbequity.Checked)
                {
                    accountheadid = 3;
                    accountheadname = "EQUITY";
                }
                else if (rbexpense.Checked)
                {
                    accountheadid = 4;
                    accountheadname = "EXPENSES";
                }
                else if (rbrevenue.Checked)
                {
                    accountheadid = 5;
                    accountheadname = "REVENUE";
                }

                // If CheckDuplicate involves async I/O, use await here
                string duplicateinfo = await Task.Run(() => CheckDuplicateAsync(accountheadid));

                if (duplicateinfo != null)
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (savebtn.Text == "Update")
                    {
                        // If UpdateAccountGroup is an I/O bound task, use await here
                        bool result = await Task.Run(() => UpdateAccountGroupAsync(accountheadid, accountheadname));

                        if (result)
                        {
                            rbassets.Checked = false;
                            rbequity.Checked = false;
                            rbexpense.Checked = false;
                            rbliabilities.Checked = false;
                            rbrevenue.Checked = false;
                            MessageBox.Show("Updated Successfully!");
                            await FillGridAsync("");
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong");
                        }
                    }
                    else
                    {
                        // If InsertAccountGroup is an I/O bound task, use await here
                        bool result = await Task.Run(() => InsertAccountGroupAsync(accountheadid, accountheadname));

                        if (result)
                        {
                            MessageBox.Show("Saved Successfully!");
                            await FillGridAsync("");
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> CheckDuplicateAsync(int accountHeadId)
        {
            string query = string.Format(@"SELECT AccountControlName, AccountHead_ID, Alias, AccountHeadName 
                                  FROM AccountControlTable WHERE AccountControlName LIKE @AccountControlName");

            var parameters = new Dictionary<string, object>
            {
                { "AccountControlName", groupnametxtbox.Text }
            };

            // Await the asynchronous method for data retrieval
            DataTable dt = await Task.Run(() => DatabaseAccess.RetrieveDataAsync(query, parameters));

            if (dt != null && dt.Rows.Count > 0)
            {
                string accountcontrolname = dt.Rows[0]["AccountControlName"].ToString();
                int accountheadid = Convert.ToInt32(dt.Rows[0]["AccountHead_ID"].ToString());

                if (groupnametxtbox.Text == accountcontrolname && accountHeadId == accountheadid)
                {
                    return $"Duplicate found: Account Name = {accountcontrolname}, Account Head = {accountheadid}.";
                }
            }
            return null;
        }

        private async Task<bool> InsertAccountGroupAsync(int accountheadid, string accountheadname)
        {
            string TableName = "AccountControlTable";
            var columnData = new Dictionary<string, object>
            {
                { "AccountControlName", groupnametxtbox.Text },
                { "Alias", aliastxtbox.Text },
                { "AccountHead_ID", accountheadid },
                { "AccountHeadName", accountheadname },
                { "AccountControlCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() }
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(TableName, "INSERT", columnData);
            return isInserted;
        }

        private async Task<bool> UpdateAccountGroupAsync(int accountheadid, string accountheadname)
        {
            string TableName = "AccountControlTable";
            string whereClause = "AccountControlID = '" + accountgroupid.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "AccountControlName", groupnametxtbox.Text },
                { "Alias", aliastxtbox.Text },
                { "AccountHead_ID", accountheadid },
                { "AccountHeadName", accountheadname },
                { "AccountControlCode", Guid.NewGuid().ToString() },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() }
            };

            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(TableName, "Update", columnData, whereClause);
            return isUpdated;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void groupnametxtbox_TextChanged(object sender, EventArgs e)
        {
            // Simulate an async operation (for demonstration)
            await Task.Delay(100); // For example, to simulate a delay

            aliastxtbox.Text = groupnametxtbox.Text.ToLower();
        }

        private async Task<string> BuildSearchQueryAccountGroupAsync(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT AccountControlID [ID], AccountHeadName [Account Head], " +
                "AccountControlName [Account Name], CreatedAt [Created], CreatedDay [Day], AccountHead_ID [HEAD ID] FROM AccountControlTable " +
                "WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (AccountHeadName LIKE '%{term}%' OR AccountControlName LIKE '%{term}%')");
            }

            // Simulate some async operation if necessary
            await Task.Delay(100);  // This is just for demonstration. Remove if unnecessary.

            return queryBuilder.ToString();
        }

        private async Task<bool> AreAnyTextBoxesFilledAsync()
        {
            // Simulate some async operation (such as checking external sources or other async work)
            await Task.Delay(100); // Remove or modify this as needed.

            return groupnametxtbox.Text.Trim().Length > 0;
        }

        private async void accountgroupdatagridview_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rbassets.Enabled = false;
                rbequity.Enabled = false;
                rbexpense.Enabled = false;
                rbliabilities.Enabled = false;
                rbrevenue.Enabled = false;

                DataGridViewRow row = accountgroupdatagridview.Rows[e.RowIndex];
                accountgroupid.Text = row.Cells["ID"].Value.ToString();
                groupnametxtbox.Text = row.Cells["Account Name"].Value.ToString();
                accountheadname = row.Cells["ACCOUNT HEAD"].Value.ToString();

                // Simulate an async task if needed (e.g., fetching related data)
                await Task.Delay(100); // This is just a placeholder for async operations, you can replace or remove it.

                if (accountheadname == "ASSETS")
                {
                    rbassets.Checked = true;
                }
                else if (accountheadname == "LIABILITIES")
                {
                    rbliabilities.Checked = true;
                }
                else if (accountheadname == "EQUITY")
                {
                    rbequity.Checked = true;
                }
                else if (accountheadname == "EXPENSES")
                {
                    rbexpense.Checked = true;
                }
                else if (accountheadname == "REVENUE")
                {
                    rbrevenue.Checked = true;
                }
                else
                {
                    rbassets.Enabled = true;
                    rbequity.Enabled = true;
                    rbexpense.Enabled = true;
                    rbliabilities.Enabled = true;
                    rbrevenue.Enabled = true;
                }
                savebtn.Text = "Update";
            }
        }

    }
}
