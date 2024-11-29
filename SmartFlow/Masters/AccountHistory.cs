using SmartFlow.Common;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AccountHistory : Form
    {
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
            account.MdiParent = this.MdiParent;
            account.FormClosed += delegate
            {
                FillGrid("");
            };
            CommonFunction.DisposeOnClose(account);
            account.Show();
        }
        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTable = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountSubControlTable.AccountSubControlID [ID],AccountSubControlTable.CodeAccount [Code]," +
                        "AccountSubControlTable.AccountSubControlName [Account Name]," +
                        "AccountSubControlTable.MobileNo [Mobile]," +
                        "AccountSubControlTable.Email [Email],AccountSubControlTable.CreatedAt [Created],AccountSubControlTable.CreatedDay [Day] " +
                        "FROM AccountSubControlTable " +
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
                        accountdatagridview.Columns[0].Width = 50;
                        accountdatagridview.Columns[1].Width = 150;
                        accountdatagridview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountdatagridview.Columns[3].Width = 100;
                        accountdatagridview.Columns[4].Width = 100;
                        accountdatagridview.Columns[5].Width = 100;
                        accountdatagridview.Columns[6].Width = 100;
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
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < accountdatagridview.Rows.Count &&
                    GlobalVariables.currentCellIndex < accountdatagridview.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    accountdatagridview.CurrentCell = accountdatagridview.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                            account.MdiParent = this.MdiParent;
                            account.FormClosed += delegate
                            {
                                GlobalVariables.currentRowIndex = accountdatagridview.CurrentCell.RowIndex;
                                GlobalVariables.currentCellIndex = accountdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            CommonFunction.DisposeOnClose(account);
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
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                            account.MdiParent = this.MdiParent;
                            account.FormClosed += delegate
                            {
                                GlobalVariables.currentRowIndex = accountdatagridview.CurrentCell.RowIndex;
                                GlobalVariables.currentCellIndex = accountdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            CommonFunction.DisposeOnClose(account);
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
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                GlobalVariables.currentRowIndex = firstVisibleRowIndex;
                GlobalVariables.currentCellIndex = firstVisibleCellIndex;
            }
        }

        private string BuildSearchQueryAccountSubControl(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT AccountSubControlTable.AccountSubControlID [ID],AccountSubControlTable.CodeAccount [Code], " +
                "AccountSubControlTable.AccountSubControlName [Account Name], AccountSubControlTable.MobileNo [Mobile]," +
                "AccountSubControlTable.Email [Email], " +
                "AccountSubControlTable.CreatedAt [Created], AccountSubControlTable.CreatedDay [Day] " +
                "FROM AccountSubControlTable INNER JOIN AccountControlTable ON AccountControlTable.AccountControlID = AccountSubControlTable.AccountControl_ID WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (AccountControlTable.AccountControlName LIKE '%{term}%' OR AccountSubControlTable.AccountSubControlName " +
                    $"LIKE '%{term}%' OR AccountSubControlTable.Email LIKE '%{term}%' OR AccountSubControlTable.MobileNo LIKE '%{term}%')");
            }

            // Note: RelevanceScore calculation and ORDER BY clause have been removed

            return queryBuilder.ToString();
        }
    }
}
