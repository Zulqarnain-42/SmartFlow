using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AccountHistory : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public AccountHistory()
        {
            InitializeComponent();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AccountHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            account.FormClosed += delegate
            {
                FillGrid("");
            };
        }
        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTable = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountSubControlTable.AccountSubControlID [ID],AccountControlTable.AccountControlName [Control Name]," +
                        "AccountSubControlTable.AccountSubControlName [Account Name],AccountSubControlTable.CreatedAt [Created]," +
                        "AccountSubControlTable.CreatedDay [Day]" +
                        ",AccountSubControlTable.Address [Address],AccountSubControlTable.Country [Country]" +
                        ",AccountSubControlTable.Email [Email],AccountSubControlTable.MobileNo [Mobile] FROM AccountSubControlTable " +
                        "INNER JOIN AccountControlTable ON AccountControlTable.AccountControlID = AccountSubControlTable.AccountControl_ID";
                }
                else
                {

                    query = BuildSearchQueryAccountSubControl(searchvalue);
                }

                dataTable = DatabaseAccess.Retrive(query);
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        accountdatagridview.DataSource = dataTable;
                        accountdatagridview.Columns[0].Width = 100;
                        accountdatagridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountdatagridview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountdatagridview.Columns[3].Width = 100;
                        accountdatagridview.Columns[4].Width = 100;
                        accountdatagridview.Columns[5].Width = 100;
                        accountdatagridview.Columns[6].Width = 100;
                        accountdatagridview.Columns[7].Width = 100;
                        accountdatagridview.Columns[8].Width = 100;
                    }
                    else
                    {
                        accountdatagridview.DataSource = dataTable;
                    }
                }
                else
                {
                    accountdatagridview.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < accountdatagridview.Rows.Count &&
                    currentCellIndex < accountdatagridview.Rows[currentRowIndex].Cells.Count)
                {
                    accountdatagridview.CurrentCell = accountdatagridview.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void AccountHistory_Load(object sender, EventArgs e)
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
                if (accountdatagridview != null)
                {
                    if(accountdatagridview.Rows.Count > 0)
                    {
                        if(accountdatagridview.SelectedRows.Count == 1)
                        {
                            Account account = new Account(Convert.ToInt32(accountdatagridview.CurrentRow.Cells[0].Value));
                            account.FormClosed += delegate
                            {
                                currentRowIndex = accountdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = accountdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            account.Show();
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
        private void accountdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (accountdatagridview != null)
                {
                    if(accountdatagridview.Rows.Count > 0)
                    {
                        if (accountdatagridview.SelectedRows.Count == 1)
                        {
                            Account account = new Account(Convert.ToInt32(accountdatagridview.CurrentRow.Cells[0].Value));
                            account.FormClosed += delegate
                            {
                                currentRowIndex = accountdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = accountdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            account.Show();
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
        private void accountdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(accountdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(accountdatagridview);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }
        private string BuildSearchQueryAccountSubControl(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT AccountSubControlTable.AccountSubControlID [ID],AccountControlTable.AccountControlName [Control Name],AccountSubControlTable.AccountSubControlName [Account Head],AccountSubControlTable.CreatedAt [Created],AccountSubControlTable.CreatedDay [Day],AccountSubControlTable.Address [Address],AccountSubControlTable.Country [Country],AccountSubControlTable.Email [Email],AccountSubControlTable.MobileNo [Mobile], (");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" + ");
                }
                queryBuilder.Append($"(CASE WHEN AccountControlTable.AccountControlName LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN AccountSubControlTable.AccountSubControlName LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN AccountSubControlTable.Email LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN AccountSubControlTable.MobileNo LIKE '%{term}%' THEN 1 ELSE 0 END)");
            }

            queryBuilder.Append(") AS RelevanceScore FROM AccountSubControlTable INNER JOIN AccountControlTable ON AccountControlTable.AccountControlID = AccountSubControlTable.AccountControl_ID WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (AccountControlTable.AccountControlName LIKE '%{term}%' OR AccountSubControlTable.AccountSubControlName LIKE '%{term}%' OR AccountSubControlTable.Email LIKE '%{term}%' OR AccountSubControlTable.MobileNo LIKE '%{term}%')");
            }

            queryBuilder.Append(" ORDER BY RelevanceScore DESC");

            return queryBuilder.ToString();
        }
        private void AccountHistory_FormClosing(object sender, FormClosingEventArgs e)
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
