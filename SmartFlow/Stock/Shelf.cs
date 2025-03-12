using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Stock
{
    public partial class Shelf: Form
    {
        private int currentCellIndex = 0;
        private int currentRowIndex = 0;
        public Shelf()
        {
            InitializeComponent();
        }

        private async Task<string> GenerateUniqueRandomCodeAsync()
        {
            Random random = new Random();
            string randomCode;
            bool exists;

            do
            {
                int number = random.Next(1000, 9999); // Generate a 4-digit number
                randomCode = $"SH{number}"; // Prefix with "R"

                // Check if the code already exists in the database
                string query = "SELECT COUNT(*) FROM ShelfTable WHERE ShelfCode = @code";
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

        private async void Shelf_Load(object sender, EventArgs e)
        {
            shelfcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
            await CommonFunction.PopulateRackComboBoxAsync(selectrackcombo);
            FillGrid();
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (selectrackcombo.SelectedIndex == 0)
                {
                    errorProvider.SetError(selectrackcombo, "Please Select Rack");
                    selectrackcombo.Focus();
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
                        shelfcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
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
                        shelfcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void ResetControl()
        {
            selectrackcombo.SelectedIndex = 0;
            savebtn.Text = "SAVE";
        }

        private async Task<bool> InsertRack()
        {
            int rackid = selectrackcombo.SelectedIndex;
            string tableName = "ShelfTable";
            var columnData = new Dictionary<string, object>()
            {
                { "ShelfCode", shelfcodetxtbox.Text },
                { "RackId", rackid },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
            return isInserted;
        }

        private async Task<bool> UpdateRack()
        {
            int rackid = selectrackcombo.SelectedIndex;
            string tableName = "ShelfTable";
            string whereClause = "ShelfId = '" + shelfidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "ShelfCode", shelfcodetxtbox.Text },
                { "RackId", rackid },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            return isInserted;
        }

        private async void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistshelf = new DataTable();
                query = "SELECT ShelfTable.ShelfId [ID],ShelfTable.ShelfCode [SHELF CODE],ShelfTable.RackId [RackId],RackTable.RackCode [RACK CODE] FROM ShelfTable " +
                    "INNER JOIN RackTable ON RackTable.Rackid = ShelfTable.RackId";
                dtlistshelf = await DatabaseAccess.RetriveAsync(query);

                if (dtlistshelf != null && dtlistshelf.Rows.Count > 0)
                {
                    dgvListShelf.DataSource = dtlistshelf;
                    dgvListShelf.Columns[0].Width = 50;
                    dgvListShelf.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListShelf.Columns[2].Visible = false;
                    dgvListShelf.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (currentRowIndex >= 0 && currentCellIndex >= 0 && currentRowIndex < dgvListShelf.Rows.Count &&
                    currentCellIndex < dgvListShelf.Rows[currentRowIndex].Cells.Count)
                {
                    dgvListShelf.CurrentCell = dgvListShelf.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListShelf != null && dgvListShelf.Rows.Count > 0)
                {
                    if (dgvListShelf.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedrow = dgvListShelf.SelectedRows[0];
                        shelfidlbl.Text = selectedrow.Cells["ID"].Value.ToString();
                        shelfcodetxtbox.Text = selectedrow.Cells["SHELF CODE"].Value.ToString();
                        rackidlbl.Text = selectedrow.Cells["RackId"].Value.ToString();
                        selectrackcombo.SelectedIndex = Convert.ToInt32(selectedrow.Cells["RackId"].Value.ToString());
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

        private void dgvListShelf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedrow = dgvListShelf.SelectedRows[0];
                    shelfidlbl.Text = selectedrow.Cells["ID"].Value.ToString();
                    shelfcodetxtbox.Text = selectedrow.Cells["SHELF CODE"].Value.ToString();
                    rackidlbl.Text = selectedrow.Cells["RackId"].Value.ToString();
                    selectrackcombo.SelectedIndex = Convert.ToInt32(selectedrow.Cells["RackId"].Value.ToString());
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

        private void dgvListShelf_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvListShelf);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvListShelf);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }

        private async void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListShelf.SelectedRows.Count > 0) // Check if a row is selected
            {
                // Get the ID of the selected record (assuming the ID is in the first column)
                int recordId = Convert.ToInt32(dgvListShelf.SelectedRows[0].Cells[0].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string tableName = "ShelfTable";
                        string whereClause = "ShelfId = @ShelfId";

                        var columnData = new Dictionary<string, object>
                        {
                            { "ShelfId", recordId }
                        };

                        await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

                        // Remove the row from DataGridView
                        dgvListShelf.Rows.RemoveAt(dgvListShelf.SelectedRows[0].Index);

                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
