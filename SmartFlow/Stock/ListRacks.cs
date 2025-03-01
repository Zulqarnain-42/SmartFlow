using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class ListRacks : Form
    {
        private int currentCellIndex = 0;
        private int currentRowIndex = 0;
        public ListRacks()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousetxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;
                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.Show();
                        }
                    }
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private async void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistunit = new DataTable();
                query = "SELECT RackTable.Rackid [ID],RackTable.RackCode [CODE],RackTable.WarehouseId [WAREHOUSEID],WarehouseTable.Name [WAREHOUSE NAME],Description [DESCRIPTION] FROM RackTable " +
                    "INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = RackTable.WarehouseId";
                dtlistunit = await DatabaseAccess.RetriveAsync(query);

                if (dtlistunit != null && dtlistunit.Rows.Count > 0)
                {
                    dgvListRack.DataSource = dtlistunit;
                    dgvListRack.Columns[0].Width = 50;
                    dgvListRack.Columns[1].Width = 50;
                    dgvListRack.Columns[2].Visible = false;
                    dgvListRack.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListRack.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvListRack.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }

                if (currentRowIndex >= 0 && currentCellIndex >= 0 && currentRowIndex < dgvListRack.Rows.Count &&
                    currentCellIndex < dgvListRack.Rows[currentRowIndex].Cells.Count)
                {
                    dgvListRack.CurrentCell = dgvListRack.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private async void UpdateWarehouseInfo(object sender, WarehouseData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int warehouseid = e.WarehouseId;
                    string warehousename = e.WarehouseName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        warehouseidlbl.Text = warehouseid.ToString();
                        selectwarehousetxtbox.Text = warehousename;
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (selectwarehousetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetxtbox, "Please Select Warehouse");
                    selectwarehousetxtbox.Focus();
                    return;
                }

                if (savebtn.Text == "Update")
                {
                    bool result = await UpdateRack();
                    if (result)
                    {
                        MessageBox.Show("Updated Successfully!");
                        FillGrid();
                        ResetControl();
                        rackcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
                    }
                }
                else
                {
                    bool isinserted = await InsertRack();
                    if (isinserted)
                    {
                        MessageBox.Show("Saved Successfully!");
                        FillGrid();
                        ResetControl();
                        rackcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private async Task<bool> InsertRack()
        {
            string tableName = "RackTable";
            var columnData = new Dictionary<string, object>()
            {
                { "WarehouseId", warehouseidlbl.Text },
                { "RackCode", rackcodetxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
            return isInserted;
        }

        private async Task<bool> UpdateRack()
        {
            string tableName = "RackTable";
            string whereClause = "Rackid = '" + rackidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "WarehouseId", warehouseidlbl.Text },
                { "RackCode", rackcodetxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            return isInserted;
        }

        private void ResetControl()
        {
            selectwarehousetxtbox.Text = string.Empty;
            savebtn.Text = "SAVE";
        }

        private async void ListRacks_Load(object sender, EventArgs e)
        {
            rackcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
            FillGrid();
        }

        private async Task<string> GenerateUniqueRandomCodeAsync()
        {
            Random random = new Random();
            string randomCode;
            bool exists;

            do
            {
                int number = random.Next(1000, 9999); // Generate a 4-digit number
                randomCode = $"R{number}"; // Prefix with "R"

                // Check if the code already exists in the database
                string query = "SELECT COUNT(*) FROM RackTable WHERE RackCode = @code";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@code", randomCode }
                };

                // Execute query asynchronously
                int count = Convert.ToInt32(await DatabaseAccess.ExecuteScalarAsync(query, parameters));

                exists = count > 0; // If count > 0, it means the code exists

            } while (exists); // Repeat until a unique code is found

            return randomCode;
        }

        private void ListRacks_KeyDown(object sender, KeyEventArgs e)
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
                if (dgvListRack != null && dgvListRack.Rows.Count > 0)
                {
                    if (dgvListRack.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedrow = dgvListRack.SelectedRows[0];
                        rackidlbl.Text = selectedrow.Cells["ID"].Value.ToString();
                        rackcodetxtbox.Text = selectedrow.Cells["CODE"].Value.ToString();
                        warehouseidlbl.Text = selectedrow.Cells["WAREHOUSEID"].Value.ToString();
                        selectwarehousetxtbox.Text = selectedrow.Cells["WAREHOUSE NAME"].Value.ToString();
                        descriptiontxtbox.Text = selectedrow.Cells["DESCRIPTION"].Value.ToString();
                        savebtn.Text = "Update";
                    }
                    else
                    {
                        MessageBox.Show("Select Only One Row.");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void dgvListRack_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedrow = dgvListRack.SelectedRows[0];
                    rackidlbl.Text = selectedrow.Cells["ID"].Value.ToString();
                    rackcodetxtbox.Text = selectedrow.Cells["CODE"].Value.ToString();
                    warehouseidlbl.Text = selectedrow.Cells["WAREHOUSEID"].Value.ToString();
                    selectwarehousetxtbox.Text = selectedrow.Cells["WAREHOUSE NAME"].Value.ToString();
                    descriptiontxtbox.Text = selectedrow.Cells["DESCRIPTION"].Value.ToString();
                    savebtn.Text = "Update";
                }
                savebtn.Text = "Update";
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

        private void dgvListRack_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvListRack);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvListRack);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }
    }
}
