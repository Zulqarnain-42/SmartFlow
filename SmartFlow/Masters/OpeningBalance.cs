using SmartFlow.Stock;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class OpeningBalance : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public OpeningBalance()
        {
            InitializeComponent();
        }
        private void OpeningBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTable = new DataTable();
                if(string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountSubControlID [ID],AccountSubControlName [ACCOUNT],OpeningBalanceDebit [DEBIT],OpeningBalanceCredit [CREDIT] " +
                        "FROM AccountSubControlTable";
                }
                else
                {
                    query = BuildSearchQueryAccounts(searchvalue);
                }

                dataTable = DatabaseAccess.Retrive(query);

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridViewopeningbalance.DataSource = dataTable;
                        dataGridViewopeningbalance.Columns[0].Width = 100;
                        dataGridViewopeningbalance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridViewopeningbalance.Columns[2].Width = 200;
                        dataGridViewopeningbalance.Columns[3].Width = 200;
                    }
                    else
                    {
                        dataGridViewopeningbalance.DataSource = null;
                    }
                }
                else
                {
                    dataGridViewopeningbalance.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < dataGridViewopeningbalance.Rows.Count &&
                    currentCellIndex < dataGridViewopeningbalance.Rows[currentRowIndex].Cells.Count)
                {
                    dataGridViewopeningbalance.CurrentCell = dataGridViewopeningbalance.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch(Exception ex) { throw ex; }
        }
        private void OpeningBalance_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void dataGridViewopeningbalance_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dataGridViewopeningbalance);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dataGridViewopeningbalance);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
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
        private string BuildSearchQueryAccounts(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT AccountSubControlID [ID], AccountSubControlName [Name], " +
                "OpeningBalanceDebit [DEBIT], OpeningBalanceCredit [CREDIT] FROM AccountSubControlTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (AccountSubControlName LIKE '%{term}%')");
            }

            return queryBuilder.ToString();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            FillGrid(searchtxtbox.Text);
        }
        private void OpeningBalance_FormClosing(object sender, FormClosingEventArgs e)
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
        private void dataGridViewopeningbalance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewopeningbalance.Rows.Count > 0)
                {
                    if (dataGridViewopeningbalance.SelectedRows.Count == 1)
                    {
                        UpdateOpeningBalance updateOpening = new UpdateOpeningBalance(Convert.ToInt32(dataGridViewopeningbalance.CurrentRow.Cells[0].Value),
                            dataGridViewopeningbalance.CurrentRow.Cells[1].Value.ToString());
                        updateOpening.FormClosed += delegate
                        {
                            currentRowIndex = dataGridViewopeningbalance.CurrentCell.RowIndex;
                            currentCellIndex = dataGridViewopeningbalance.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        updateOpening.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row.");
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
