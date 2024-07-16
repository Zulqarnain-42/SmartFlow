using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AccountGroupHistory : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public AccountGroupHistory()
        {
            InitializeComponent();
        }

        private void AccountGroupHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }

            if(e.Control && e.KeyCode == Keys.R)
            {
                FillGrid("");
                e.Handled = true;
            }
        }

        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTable = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountControlTable.AccountControlID [ID],AccountHeadTable.AccountHeadName [Account Head]," +
                        "AccountControlTable.AccountControlName [Account Name]," +
                        "AccountControlTable.CreatedAt [Created],AccountControlTable.CreatedDay [Day]" +
                        "FROM AccountControlTable INNER JOIN AccountHeadTable ON AccountHeadTable.AccountHeadID = AccountControlTable.AccountHead_ID";
                }
                else
                {
                    /*query = "SELECT AccountControlTable.AccountControlID,AccountControlTable.AccountControlName," +
                        "AccountHeadTable.AccountHeadName,AccountControlTable.CreatedAt,AccountControlTable.CreatedDay " +
                        "FROM AccountControlTable INNER JOIN AccountHeadTable ON AccountHeadTable.AccountHeadID = AccountControlTable.AccountHead_ID " +
                        "WHERE AccountControlTable.AccountControlName LIKE '%" + searchtxtbox.Text.Trim()+"%'";*/

                    query = BuildSearchQueryAccountGroup(searchvalue);
                }

                dataTable = DatabaseAccess.Retrive(query);
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
            catch (Exception ex) { throw ex; }
        }

        private void AccountGroupHistory_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            FillGrid(searchtxtbox.Text.Trim());
        }

        private void accountgroupdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(accountgroupdatagridview != null)
                {
                    if (accountgroupdatagridview.Rows.Count > 0)
                    {
                        if(accountgroupdatagridview.SelectedRows.Count == 1)
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available.");
                    }
                }
            }catch (Exception ex) { throw ex; }
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
            }catch(Exception ex) { throw ex; }
        }

        private int GetFirstVisibleRowIndex(DataGridView dataGridView)
        {
            int firstDisplayedRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            int displayedRowCount = dataGridView.DisplayedRowCount(true); // Pass true to include partially displayed rows

            if (firstDisplayedRowIndex == -1 || displayedRowCount == 0)
            {
                return -1; // DataGridView is not displaying any rows
            }

            return firstDisplayedRowIndex + displayedRowCount - 1;
        }

        private int GetFirstVisibleCellIndex(DataGridView dataGridView)
        {
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

        private void accountgroupdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(accountgroupdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(accountgroupdatagridview);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (savebtn.Text == "Update")
                {
                    errorProvider.Clear();

                    if (groupnametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(groupnametxtbox, "Please Enter Group Name");
                        groupnametxtbox.Focus();
                        return;
                    }

                    if (aliastxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(aliastxtbox, "Please Enter Alias");
                        aliastxtbox.Focus();
                        return;
                    }

                    if (selectprimarygrouptxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(selectprimarygrouptxtbox, "");
                        selectprimarygrouptxtbox.Focus();
                        return;
                    }

                    string groupname = groupnametxtbox.Text;
                    string alias = aliastxtbox.Text;

                    groupname = Regex.Replace(groupname, "[^a-zA-Z0-9 ]", "");
                    alias = Regex.Replace(alias, "[^a-zA-Z0-9 ]", "");

                    string query = string.Empty;
                    query = string.Format("SELECT AccountControlName,AccountHead_ID,Alias FROM AccountControlTable " +
                        "WHERE AccountControlName LIKE '" + groupname + "'");
                    DataTable dtdata = DatabaseAccess.Retrive(query);
                    if (dtdata != null)
                    {
                        if (dtdata.Rows.Count > 0)
                        {
                            if (dtdata.Rows[0]["AccountControlName"].ToString() == groupname
                                && dtdata.Rows[0]["AccountHead_ID"].ToString() == selectprimarygrouptxtbox.Text.ToString()
                                && dtdata.Rows[0]["Alias"].ToString() == alias)
                            {
                                MessageBox.Show("Account Already Exist");
                            }
                            else
                            {
                                query = string.Format("UPDATE AccountControlTable SET AccountControlName = '" + groupname + "'" +
                        ",AccountHead_ID = '" + selectprimarygrouptxtbox.Text + "'" +
                        ",UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "',Alias = '" + alias + "',UpdatedDay = '" + DateTime.Now.DayOfWeek + "'" +
                        " WHERE AccountControlID = '" + accountgroupid.Text + "'");

                                bool result = DatabaseAccess.Update(query);
                                if (result)
                                {
                                    MessageBox.Show("Updated Successfully!");
                                    FillGrid("");
                                }
                                else
                                {
                                    MessageBox.Show("Something is wrong");
                                }
                            }
                        }
                        else
                        {
                            query = string.Format("UPDATE AccountControlTable SET AccountControlName = '" + groupname + "'" +
                        ",AccountHead_ID = '" + selectprimarygrouptxtbox.Text + "'" +
                        ",UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "',Alias = '" + alias + "',UpdatedDay = '" + DateTime.Now.DayOfWeek + "'" +
                        " WHERE AccountControlID = '" + accountgroupid.Text + "'");

                            bool result = DatabaseAccess.Update(query);
                            if (result)
                            {
                                MessageBox.Show("Updated Successfully!");
                                FillGrid("");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong");
                            }
                        }
                    }
                    else
                    {
                        query = string.Format("UPDATE AccountControlTable SET AccountControlName = '" + groupname + "'" +
                      ",AccountHead_ID = '" + selectprimarygrouptxtbox.Text + "'" +
                      ",UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "',Alias = '" + alias + "',UpdatedDay = '" + DateTime.Now.DayOfWeek + "'" +
                      " WHERE AccountControlID = '" + accountgroupid.Text + "'");

                        bool result = DatabaseAccess.Update(query);
                        if (result)
                        {
                            MessageBox.Show("Updated Successfully!");
                            FillGrid("");
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong");
                        }
                    }

                }
                else
                {
                    errorProvider.Clear();

                    if (groupnametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(groupnametxtbox, "Please Enter Group Name.");
                        groupnametxtbox.Focus();
                        return;
                    }

                    if (aliastxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(aliastxtbox, "Please Enter Alias.");
                        aliastxtbox.Focus();
                        return;
                    }

                    if (selectprimarygrouptxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(selectprimarygrouptxtbox, "Please Select Primary Group.");
                        selectprimarygrouptxtbox.Focus();
                        return;
                    }


                    string groupname = groupnametxtbox.Text;
                    string alias = aliastxtbox.Text;

                    groupname = Regex.Replace(groupname, "[^a-zA-Z0-9 ]", "");
                    alias = Regex.Replace(alias, "[^a-zA-Z0-9 ]", "");

                    string query = string.Empty;
                    query = string.Format("SELECT AccountControlName,AccountHead_ID,Alias FROM AccountControlTable " +
                        "WHERE AccountControlName LIKE '" + groupname + "'");
                    DataTable dtdata = DatabaseAccess.Retrive(query);
                    if (dtdata != null)
                    {
                        if (dtdata.Rows.Count > 0)
                        {
                            if (dtdata.Rows[0]["AccountControlName"].ToString() == groupname
                                && dtdata.Rows[0]["AccountHead_ID"].ToString() == selectprimarygrouptxtbox.Text.ToString()
                                && dtdata.Rows[0]["Alias"].ToString() == alias)
                            {
                                MessageBox.Show("Account Already Exist");
                            }
                            else
                            {
                                query = string.Format("INSERT INTO AccountControlTable (AccountControlName,Alias,AccountHead_ID,AccountControlCode,CreatedAt,CreatedDay) VALUES " +
                                        "('" + groupname + "','" + alias + "','" + selectprimarygrouptxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                                bool result = DatabaseAccess.Insert(query);

                                if (result)
                                {
                                    MessageBox.Show("Saved Successfully!");
                                    FillGrid("");
                                }
                                else
                                {
                                    MessageBox.Show("Something is wrong.");
                                }
                            }
                        }
                        else
                        {
                            query = string.Format("INSERT INTO AccountControlTable (AccountControlName,Alias,AccountHead_ID,AccountControlCode,CreatedAt,CreatedDay) VALUES " +
                                    "('" + groupname + "','" + alias + "','" + selectprimarygrouptxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                            bool result = DatabaseAccess.Insert(query);

                            if (result)
                            {
                                MessageBox.Show("Saved Successfully!");
                                FillGrid("");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                    else
                    {
                        query = string.Format("INSERT INTO AccountControlTable (AccountControlName,Alias,AccountHead_ID,AccountControlCode,CreatedAt,CreatedDay) VALUES " +
                                "('" + groupname + "','" + alias + "','" + selectprimarygrouptxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                        bool result = DatabaseAccess.Insert(query);

                        if (result)
                        {
                            MessageBox.Show("Saved Successfully!");
                            FillGrid("");
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
                throw ex;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupnametxtbox_TextChanged(object sender, EventArgs e)
        {
            aliastxtbox.Text = groupnametxtbox.Text.ToLower();
        }

        private string BuildSearchQueryAccountGroup(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT AccountControlTable.AccountControlID [ID],AccountHeadTable.AccountHeadName [Account Head],AccountControlTable.AccountControlName [Account Name],AccountControlTable.CreatedAt [Created],AccountControlTable.CreatedDay [Day], (");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" + ");
                }
                queryBuilder.Append($"(CASE WHEN AccountControlTable.AccountControlName LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN AccountHeadTable.AccountHeadName LIKE '%{term}%' THEN 1 ELSE 0 END)");
            }

            queryBuilder.Append(") AS RelevanceScore FROM AccountControlTable INNER JOIN AccountHeadTable ON AccountControlTable.AccountHead_ID = AccountHeadTable.AccountHeadID WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (AccountHeadTable.AccountHeadName LIKE '%{term}%' OR AccountControlTable.AccountControlName LIKE '%{term}%')");
            }

            queryBuilder.Append(" ORDER BY RelevanceScore DESC");

            return queryBuilder.ToString();
        }

        private void AccountGroupHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AreAnyTextBoxesFilled())
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                      "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                }
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true; // At least one TextBox is filled
                }
            }
            return false; // No TextBox is filled
        }
    }
}
