using SmartFlow.Common;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AccountHistory : Form
    {
        private int currentRowIndex = 0;
        private int currentCellIndex = 0;
        public AccountHistory()
        {
            InitializeComponent();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void AccountHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // If you want to perform an async task before closing the form, you can add it here.
                // For now, let's simulate an async delay.
                await Task.Delay(100); // Simulating async work if necessary

                this.Close();
                e.Handled = true;
            }
        }

        private async void newbtn_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.MdiParent = this.MdiParent;

            // Assuming you want to perform some asynchronous operation before showing the form
            await Task.Run(() =>
            {
                // Simulate async work (if needed)
                // For example, you could load data or wait for something
                // e.g., await SomeAsyncTask();
            });

            account.FormClosed += async delegate
            {
                await FillGridAsync("");
            };

            CommonFunction.DisposeOnClose(account);
            account.Show();
        }

        private async Task FillGridAsync(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTable = new DataTable();

                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountSubControlTable.AccountSubControlID [ID], AccountSubControlTable.CodeAccount [Code], " +
                            "AccountSubControlTable.AccountSubControlName [Account Name], AccountSubControlTable.CompanyName [Company Name], " +
                            "AccountSubControlTable.MobileNo [Mobile], AccountSubControlTable.Email [Email], " +
                            "AccountSubControlTable.CreatedAt [Created], AccountSubControlTable.CreatedDay [Day] " +
                            "FROM AccountSubControlTable";
                }
                else
                {
                    query = await BuildSearchQueryAccountSubControlAsync(searchvalue);
                }

                // Asynchronously retrieve data
                dataTable = await Task.Run(() => DatabaseAccess.RetriveAsync(query));

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        accountdatagridview.DataSource = dataTable;
                        accountdatagridview.Columns[0].Width = 50;
                        accountdatagridview.Columns[1].Width = 150;
                        accountdatagridview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountdatagridview.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        accountdatagridview.Columns[4].Width = 100;
                        accountdatagridview.Columns[5].Width = 100;
                        accountdatagridview.Columns[6].Width = 100;
                        accountdatagridview.Columns[7].Width = 100;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AccountHistory_Load(object sender, EventArgs e)
        {
            await FillGridAsync("");
        }
        private async void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            await FillGridAsync(searchtxtbox.Text.Trim());
        }
        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (accountdatagridview != null)
                {
                    if (accountdatagridview.Rows.Count > 0)
                    {
                        if (accountdatagridview.SelectedRows.Count == 1)
                        {
                            // Create the account object based on the selected row
                            Account account = new Account(Convert.ToInt32(accountdatagridview.CurrentRow.Cells[0].Value));
                            account.MdiParent = this.MdiParent;

                            // Handle the FormClosed event
                            account.FormClosed += async delegate
                            {
                                currentRowIndex = accountdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = accountdatagridview.CurrentCell.ColumnIndex;

                                // Call FillGrid asynchronously
                                await Task.Run(() => FillGridAsync(""));
                            };

                            // Dispose account when closed
                            CommonFunction.DisposeOnClose(account);

                            // Show the account form asynchronously
                            account.Show();

                            // Wait asynchronously if needed (e.g., awaiting any background tasks for the account form)
                            await Task.Delay(10); // Optional: delay if needed before continuing
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void accountdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (accountdatagridview != null)
                {
                    if (accountdatagridview.Rows.Count > 0)
                    {
                        if (accountdatagridview.SelectedRows.Count == 1)
                        {
                            // Create the account object based on the selected row
                            Account account = new Account(Convert.ToInt32(accountdatagridview.CurrentRow.Cells[0].Value));
                            account.MdiParent = this.MdiParent;

                            // Handle the FormClosed event asynchronously
                            account.FormClosed += async delegate
                            {
                                currentRowIndex = accountdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = accountdatagridview.CurrentCell.ColumnIndex;

                                // Call FillGrid asynchronously
                                await Task.Run(() => FillGridAsync(""));
                            };

                            // Dispose account when closed
                            CommonFunction.DisposeOnClose(account);

                            // Show the account form asynchronously
                            account.Show();

                            // Wait asynchronously if needed (e.g., awaiting any background tasks for the account form)
                            await Task.Delay(10); // Optional: delay if needed before continuing
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> GetFirstVisibleRowIndexAsync(DataGridView dataGridView)
        {
            return await Task.Run(() =>
            {
                int firstDisplayedRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
                int displayedRowCount = dataGridView.DisplayedRowCount(true); // Pass true to include partially displayed rows

                if (firstDisplayedRowIndex == -1 || displayedRowCount == 0)
                {
                    return -1; // DataGridView is not displaying any rows
                }

                return firstDisplayedRowIndex + displayedRowCount - 1;
            });
        }

        private async Task<int> GetFirstVisibleCellIndexAsync(DataGridView dataGridView)
        {
            return await Task.Run(() =>
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
            });
        }

        private async void accountdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            // Run both operations asynchronously in the background
            int firstVisibleRowIndex = await Task.Run(() => GetFirstVisibleRowIndexAsync(accountdatagridview));
            int firstVisibleCellIndex = await Task.Run(() => GetFirstVisibleCellIndexAsync(accountdatagridview));

            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }


        private async Task<string> BuildSearchQueryAccountSubControlAsync(string searchTerm)
        {
            return await Task.Run(() =>
            {
                string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder queryBuilder = new StringBuilder("SELECT AccountSubControlTable.AccountSubControlID [ID],AccountSubControlTable.CodeAccount [Code], " +
                    "AccountSubControlTable.AccountSubControlName [Account Name],AccountSubControlTable.CompanyName [Company Name],AccountSubControlTable.MobileNo [Mobile]," +
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
                    queryBuilder.Append($" (AccountControlTable.AccountControlName LIKE '%{term}%' OR AccountSubControlTable.CompanyName LIKE '%{term}%' OR AccountSubControlTable.AccountSubControlName " +
                        $"LIKE '%{term}%' OR AccountSubControlTable.Email LIKE '%{term}%' OR AccountSubControlTable.MobileNo LIKE '%{term}%')");
                }

                // Note: RelevanceScore calculation and ORDER BY clause have been removed

                return queryBuilder.ToString();
            });
        }

    }
}
