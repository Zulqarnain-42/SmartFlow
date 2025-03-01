using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CurrencyList : Form
    {
        private int currentCellIndex = 0;
        private int currentRowIndex = 0;
        public CurrencyList()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtCurrencList = new DataTable();

                query = "SELECT CurrencyId [ID], Symbol [SYMBOL], Name [NAME], IsDefault [DEFAULT], CurrencyCode, CurrencyString FROM CurrencyTable";
                dtCurrencList = await DatabaseAccess.RetrieveAsync(query);

                if (dtCurrencList != null && dtCurrencList.Rows.Count > 0)
                {
                    dgvListcurrency.DataSource = dtCurrencList; // Set the DataTable as the DataSource
                    dgvListcurrency.Columns[0].Width = 50; // ID
                    dgvListcurrency.Columns[1].Width = 100; // SYMBOL
                    dgvListcurrency.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // NAME
                    dgvListcurrency.Columns[3].Width = 100; // DEFAULT
                    dgvListcurrency.Columns[4].Visible = false; // CurrencyCode
                    dgvListcurrency.Columns[5].Visible = false; // CurrencyString
                }

                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < dgvListcurrency.Rows.Count &&
                    currentCellIndex < dgvListcurrency.Rows[currentRowIndex].Cells.Count)
                {
                    dgvListcurrency.CurrentCell = dgvListcurrency.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CurrencyList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvListcurrency != null && dgvListcurrency.Rows.Count > 0)
                {
                    if(dgvListcurrency.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedRow = dgvListcurrency.Rows[0];
                        currencyidlbl.Text = selectedRow.Cells["ID"].Value.ToString();
                        currencycodelbl.Text = selectedRow.Cells["CurrencyCode"].Value.ToString();
                        symboltxtbox.Text = selectedRow.Cells["SYMBOL"].Value.ToString();
                        currencystringtxtbox.Text = selectedRow.Cells["CurrencyString"].Value.ToString();
                        currencynametxtbox.Text = selectedRow.Cells["NAME"].Value.ToString();
                        isdefaultchkbox.Checked = Convert.ToBoolean(selectedRow.Cells["DEFAULT"].Value.ToString());
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void dgvListcurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow viewRow = dgvListcurrency.Rows[e.RowIndex];
                    currencyidlbl.Text = viewRow.Cells["ID"].Value.ToString();
                    currencycodelbl.Text = viewRow.Cells["CurrencyCode"].Value.ToString();
                    symboltxtbox.Text = viewRow.Cells["SYMBOL"].Value.ToString();
                    currencystringtxtbox.Text = viewRow.Cells["CurrencyString"].Value.ToString();
                    currencynametxtbox.Text = viewRow.Cells["NAME"].Value.ToString();
                    isdefaultchkbox.Checked = Convert.ToBoolean(viewRow.Cells["DEFAULT"].Value.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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

        private void dgvListunit_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvListcurrency);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvListcurrency);
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
                if(symboltxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(symboltxtbox,"Please Enter Symbol.");
                    symboltxtbox.Focus();
                    return;
                }

                if(currencynametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencynametxtbox, "Please Enter Currency Name");
                    currencynametxtbox.Focus();
                    return;
                }

                if (savebtn.Text == "UPDATE")
                {
                    bool result = await UpdateCurrency();
                    if (result)
                    {
                        MessageBox.Show("Updated Successfuly!");
                        FillGrid();
                        ResetControl();
                    }
                }
                else
                {
                    bool isInserted = await InsertCurrency();
                    if (isInserted) 
                    {
                        MessageBox.Show("Saved Successfully!");
                        FillGrid();
                        ResetControl();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private async Task<bool> UpdateCurrency()
        {
            string tableName = "CurrencyTable";
            string whereClause = "CurrencyId = '" + currencyidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "Symbol", symboltxtbox.Text },
                { "CurrencyString", currencystringtxtbox.Text },
                { "Name", currencynametxtbox.Text },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CurrencyCode", currencycodelbl.Text },
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString() },
                { "IsDefault", isdefaultchkbox.Checked }
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            return isInserted;
        }

        private async Task<bool> InsertCurrency()
        {
            string currencyCode = Guid.NewGuid().ToString();
            string tableName = "CurrencyTable";
            var columnData = new Dictionary<string, object>
            {
                { "Symbol", symboltxtbox.Text },
                { "CurrencyString", currencystringtxtbox.Text },
                { "Name", currencynametxtbox.Text },
                { "CurrencyCode", currencyCode },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString() },
                { "IsDefault", isdefaultchkbox.Checked }
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
            return isInserted;
        }

        private void ResetControl()
        {
            currencyidlbl.Text = string.Empty;
            currencycodelbl.Text = string.Empty;
            symboltxtbox.Text = string.Empty;
            currencystringtxtbox.Text = string.Empty;
            currencynametxtbox.Text = string.Empty;
            isdefaultchkbox.Checked = false;
        }
    }
}
