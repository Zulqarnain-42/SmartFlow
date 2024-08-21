using SmartFlow.Common;
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
        private int accountheadid = 0;
        private string accountheadname = null;
        public AccountGroupHistory()
        {
            InitializeComponent();
        }
        private void AccountGroupHistory_KeyDown(object sender, KeyEventArgs e)
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
        private void FillGrid(string searchvalue)
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
                    query = "SELECT AccountControlID [ID],AccountHeadName [ACCOUNT HEAD],AccountControlName [ACCOUNT NAME],CreatedAt [CREATED],CreatedDay [DAY]," +
                        "AccountHead_ID [HEAD ID] FROM AccountControlTable WHERE AccountControlName LIKE '%" + searchvalue + "%'";

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
                errorProvider.Clear();

                if (groupnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(groupnametxtbox, "Please Enter Group Name");
                    groupnametxtbox.Focus();
                    return;
                }
                
                if(!rbassets.Checked && !rbequity.Checked && !rbexpense.Checked && !rbliabilities.Checked && !rbrevenue.Checked)
                {
                    errorProvider.SetError(rbassets,"Please Select One Radio");
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

                string groupname = groupnametxtbox.Text;
                string alias = aliastxtbox.Text;
                string query = string.Empty;
                query = string.Format("SELECT AccountControlName,AccountHead_ID,Alias,AccountHeadName FROM AccountControlTable " +
                    "WHERE AccountControlName LIKE '" + groupname + "'");
                DataTable dtdata = DatabaseAccess.Retrive(query);
                if (dtdata != null && dtdata.Rows.Count > 0)
                {
                    if (dtdata.Rows[0]["AccountControlName"].ToString() == groupname
                        && dtdata.Rows[0]["Alias"].ToString() == alias
                        && dtdata.Rows[0]["AccountHeadName"].ToString() == accountheadname)
                    {
                        MessageBox.Show("Account Already Exist");
                    }
                    else
                    {
                        if (savebtn.Text == "Update")
                        {
                            query = string.Format("UPDATE AccountControlTable SET AccountControlName = '" + groupname + "'" +
                                ",AccountHead_ID = '" + accountheadid + "'" +
                                ",UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "',Alias = '" + alias + "'," +
                                "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                                "AccountHeadName = '" + accountheadname+"'" +
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
                        else
                        {
                            query = string.Format("INSERT INTO AccountControlTable (AccountControlName,Alias,AccountHead_ID,AccountHeadName,AccountControlCode,CreatedAt,CreatedDay) VALUES " +
                                        "('" + groupname + "','" + alias + "','" + accountheadid + "','" + accountheadname + "','" + Guid.NewGuid() + "'," +
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
                else
                {
                    query = string.Format("INSERT INTO AccountControlTable (AccountControlName,Alias,AccountHead_ID,AccountHeadName,AccountControlCode,CreatedAt,CreatedDay) VALUES " +
                                        "('" + groupname + "','" + alias + "','" + accountheadid + "','" + accountheadname + "','" + Guid.NewGuid() + "'," +
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
        private bool AreAnyTextBoxesFilled()
        {
            if(groupnametxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void accountgroupdatagridview_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
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
                if (accountheadname == "ASSETS")
                {
                    rbassets.Checked = true;
                }else if(accountheadname == "LIABILITIES")
                {
                    rbliabilities.Checked = true;
                }else if(accountheadname == "EQUITY")
                {
                    rbequity.Checked = true;
                }else if(accountheadname == "EXPENSES")
                {
                    rbexpense.Checked = true;
                }else if(accountheadname == "REVENUE")
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
