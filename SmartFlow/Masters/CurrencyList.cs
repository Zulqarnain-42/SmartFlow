using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CurrencyList : Form
    {
        public CurrencyList()
        {
            InitializeComponent();
        }

        private void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistcurrency = new DataTable();
                query = "SELECT CurrencyId [ID],CurrencyCode [CODE],Symbol [SYMBOL],CurrencyString [CURRENCY STRING],Name [NAME],CreatedAt [CREATED]," +
                    "IsDefault [DEFAULT] FROM CurrencyTable";
                dtlistcurrency = DatabaseAccess.Retrive(query);

                if(dtlistcurrency != null && dtlistcurrency.Rows.Count > 0)
                {
                    dgvListcurrency.DataSource = dtlistcurrency;
                    dgvListcurrency.Columns[0].Width = 50;
                    dgvListcurrency.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListcurrency.Columns[2].Width = 100;
                    dgvListcurrency.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListcurrency.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListcurrency.Columns[5].Width = 100;
                    dgvListcurrency.Columns[6].Width = 100;

                }

                // Restore the cursor position
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < dgvListcurrency.Rows.Count &&
                    GlobalVariables.currentCellIndex < dgvListcurrency.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvListcurrency.CurrentCell = dgvListcurrency.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CurrencyList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void CurrencyList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvListcurrency != null && dgvListcurrency.Rows.Count > 0)
                {
                    if(dgvListcurrency.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedRow = dgvListcurrency.SelectedRows[0];
                        currencyidlbl.Text = selectedRow.Cells["ID"].Value.ToString();
                        currencycodelbl.Text = selectedRow.Cells["CODE"].Value.ToString();
                        currencynametxtbox.Text = selectedRow.Cells["NAME"].Value.ToString();
                        currencysymboltxtbox.Text = selectedRow.Cells["SYMBOL"].Value.ToString();
                        currencystrintxtbox.Text = selectedRow.Cells["CURRENCY STRING"].Value.ToString();
                        savebtn.Text = "Update";
                    }
                    else
                    {
                        MessageBox.Show("Select One Row Only.");
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvListcurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvListcurrency.Rows[e.RowIndex];
                    currencyidlbl.Text = row.Cells["ID"].Value.ToString();
                    currencycodelbl.Text = row.Cells["CODE"].Value.ToString();
                    currencynametxtbox.Text = row.Cells["NAME"].Value.ToString();
                    currencysymboltxtbox.Text = row.Cells["SYMBOL"].Value.ToString();
                    currencystrintxtbox.Text = row.Cells["CURRENCY STRING"].Value.ToString();
                }
                savebtn.Text = "Update";
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void ResetControl()
        {
            currencynametxtbox.Text = "";
            currencysymboltxtbox.Text = "";
            currencystrintxtbox.Text = "";
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

        private void dgvListcurrency_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvListcurrency);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvListcurrency);
            if (firstVisibleRowIndex >= 0)
            {
                GlobalVariables.currentRowIndex = firstVisibleRowIndex;
                GlobalVariables.currentCellIndex = firstVisibleCellIndex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (currencysymboltxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencysymboltxtbox,"Please Enter Symbol.");
                    currencysymboltxtbox.Focus();
                    return;
                }

                if(currencystrintxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencystrintxtbox,"Please Enter Currency String.");
                    currencystrintxtbox.Focus();
                    return;
                }

                if(currencynametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencynametxtbox,"Please Enter Currency Name.");
                    currencynametxtbox.Focus();
                    return;
                }

                string duplicateinfo = CheckDuplicate();
                if (duplicateinfo != null) 
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(savebtn.Text == "Update")
                    {
                        bool result = UpdateCurrency();
                        if (result) 
                        {
                            MessageBox.Show("Updated Successfully!");
                            FillGrid();
                            ResetControl();
                        }
                    }
                    else
                    {
                        bool isinserted = InsertCurrency();
                        if (isinserted)
                        {
                            MessageBox.Show("Saved Successfully.");
                            FillGrid();
                            ResetControl();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string CheckDuplicate()
        {
            string query = string.Format(@"SELECT CurrencyId,CurrencyCode,Symbol,CurrencyString,Name,UserId,CompanyId,CreatedAt,CreatedDay,
            UpdatedAt,UpdatedDay,IsDefault FROM CurrencyTable WHERE Symbol LIKE @Symbol AND CurrencyString LIKE @CurrencyString AND Name LIKE @Name");

            var parameters = new Dictionary<string, object>
            {
                { "Symbol", currencysymboltxtbox.Text },
                { "CurrencyString", currencystrintxtbox.Text },
                { "Name", currencynametxtbox.Text }
            };

            DataTable dt = DatabaseAccess.RetrieveData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                string currencysymbol = dt.Rows[0]["Symbol"].ToString();
                string currencystring = dt.Rows[0]["CurrencyString"].ToString();
                string currencyname = dt.Rows[0]["Name"].ToString();

                if (currencynametxtbox.Text == currencyname && currencystrintxtbox.Text == currencystring && currencysymboltxtbox.Text == currencysymbol)
                {
                    return $"Duplicate found: Currency Symbol = {currencysymbol}, Currency String = {currencystring}, Currency Name = {currencyname}.";
                }
            }
            return null;
        }

        private bool InsertCurrency()
        {
            string TableName = "CurrencyTable";
            var columnData = new Dictionary<string, object>
            {
                { "CurrencyCode", Guid.NewGuid().ToString() },
                { "Symbol", currencysymboltxtbox.Text },
                { "CurrencyString", currencystrintxtbox.Text },
                { "Name", currencynametxtbox.Text },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "IsDefault",  isdefaultchkbox.Checked }
            };

            bool isInserted = DatabaseAccess.ExecuteQuery(TableName, "INSERT", columnData);
            return isInserted;
        }

        private bool UpdateCurrency()
        {
            string TableName = "CurrencyTable";
            string whereClause = "CurrencyId = '" + currencyidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "Symbol", currencysymboltxtbox.Text },
                { "CurrencyString", currencystrintxtbox.Text },
                { "Name", currencynametxtbox.Text },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "IsDefault",  isdefaultchkbox.Checked }
            };

            bool isInserted = DatabaseAccess.ExecuteQuery(TableName, "UPDATE", columnData, whereClause);
            return isInserted;
        }
    }
}
