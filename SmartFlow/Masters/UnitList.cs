using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class UnitList : Form
    {
        public UnitList()
        {
            InitializeComponent();
        }

        private void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistunit = new DataTable();
                query = "SELECT UnitID [ID],UnitName [UNIT NAME],Description [DESCRIPTION],UnitCode [CODE],IsDefault [DEFAULT] FROM UnitTable";
                dtlistunit = DatabaseAccess.Retrive(query);

                if (dtlistunit != null && dtlistunit.Rows.Count > 0) 
                {
                    dgvListunit.DataSource = dtlistunit;
                    dgvListunit.Columns[0].Width = 50;
                    dgvListunit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListunit.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListunit.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListunit.Columns[4].Width = 100;

                }

                if(GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 && GlobalVariables.currentRowIndex < dgvListunit.Rows.Count && 
                    GlobalVariables.currentCellIndex < dgvListunit.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvListunit.CurrentCell = dgvListunit.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void UnitList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void UnitList_KeyDown(object sender, KeyEventArgs e)
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
                if(dgvListunit != null && dgvListunit.Rows.Count > 0)
                {
                    if(dgvListunit.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedrow = dgvListunit.SelectedRows[0];
                        unitidlbl.Text = selectedrow.Cells["ID"].Value.ToString();
                        unitcodelbl.Text = selectedrow.Cells["CODE"].Value.ToString();
                        unitnametxtbox.Text = selectedrow.Cells["UNIT NAME"].Value.ToString();
                        descriptiontxtbox.Text = selectedrow.Cells["DESCRIPTION"].Value.ToString();
                        savebtn.Text = "Update";
                    }
                    else
                    {
                        MessageBox.Show("Select Only One Row.");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }

        private void dgvListunit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvListunit.Rows[e.RowIndex];
                    unitidlbl.Text = row.Cells["ID"].Value.ToString();
                    unitcodelbl.Text = row.Cells["CODE"].Value.ToString();
                    unitnametxtbox.Text = row.Cells["UNIT NAME"].Value.ToString();
                    descriptiontxtbox.Text = row.Cells["DESCRIPTION"].Value.ToString();
                }
                savebtn.Text = "Update";
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            unitnametxtbox.Text = "";
            descriptiontxtbox.Text = "";
            isdefaultchkbox.Checked = false;
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
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvListunit);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvListunit);
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
                if(unitnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(unitnametxtbox,"Please Enter Unit Name.");
                    unitnametxtbox.Focus();
                    return;
                }

                string duplicateinfo = CheckDuplicate();
                if (duplicateinfo != null) 
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (savebtn.Text == "Update")
                    {
                        bool result = UpdateUnit();
                        if (result)
                        {
                            MessageBox.Show("Updated Successfully!");
                            FillGrid();
                            ResetControl();
                        }
                    }
                    else
                    {
                        bool isinserted = InsertUnit();
                        if (isinserted)
                        {
                            MessageBox.Show("Saved Successfully!");
                            FillGrid();
                            ResetControl();
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string CheckDuplicate()
        {
            string query = string.Format("SELECT UnitID,UnitName,Description,UnitCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay,UpdatedDay," +
                "IsDefault FROM UnitTable WHERE UnitName = @UnitName");

            var parameters = new Dictionary<string, object>
            {
                { "UnitName", unitnametxtbox.Text }
            };

            DataTable dt = DatabaseAccess.RetrieveData(query, parameters);
            if(dt!=null && dt.Rows.Count > 0)
            {
                return $"Duplicate found: Unit Name = {dt.Rows[0]["UnitName"].ToString()}.";
            }
            return null;
        }

        private bool InsertUnit()
        {
            string tableName = "UnitTable";
            var columnData = new Dictionary<string, object>()
            {
                { "UnitName", unitnametxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "UnitCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString() },
                { "IsDefault", isdefaultchkbox.Checked }
            };

            bool isInserted = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);
            return isInserted;
        }

        private bool UpdateUnit()
        {
            string tableName = "UnitTable";
            string whereClause = "UnitID = '" + unitidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "UnitName", unitnametxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "UnitCode", Guid.NewGuid().ToString() },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString() },
                { "IsDefault", isdefaultchkbox.Checked }            
            };

            bool isInserted = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            return isInserted;
        }
    }
}
