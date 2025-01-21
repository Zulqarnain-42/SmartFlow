using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class ListWarehouse : Form
    {
        private int currentRowIndex = 0;
        private int currentCellIndex = 0;
        public ListWarehouse()
        {
            InitializeComponent();
        }

        private void ListWarehouse_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private async void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistwarehouse = new DataTable();
                query = "SELECT WarehouseID,Name,Address,City FROM WarehouseTable";
                dtlistwarehouse = await DatabaseAccess.RetriveAsync(query);

                if (dtlistwarehouse != null && dtlistwarehouse.Rows.Count > 0) 
                {
                    dgvlistwarehouse.DataSource = dtlistwarehouse;

                    dgvlistwarehouse.Columns[0].Width = 50;
                    dgvlistwarehouse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistwarehouse.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistwarehouse.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < dgvlistwarehouse.Rows.Count &&
                    currentCellIndex < dgvlistwarehouse.Rows[currentRowIndex].Cells.Count)
                {
                    dgvlistwarehouse.CurrentCell = dgvlistwarehouse.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvlistwarehouse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvlistwarehouse.Rows[e.RowIndex];
                    warehousenametxtbox.Text = row.Cells[""].Value.ToString();
                    addresstxtbox.Text = row.Cells[""].Value.ToString();
                    citytxtbox.Text = row.Cells[""].Value.ToString();
                    warehouseidlbl.Text = row.Cells[""].Value.ToString();
                    warehousecodelbl.Text = row.Cells[""].Value.ToString();
                }
                createwarehousesavebtn.Text = "Update";
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvlistwarehouse != null && dgvlistwarehouse.Rows.Count > 0)
                {
                    if(dgvlistwarehouse.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedrow = new DataGridViewRow();
                        warehousenametxtbox.Text = selectedrow.Cells[""].Value.ToString();
                        addresstxtbox.Text = selectedrow.Cells[""].Value.ToString();
                        citytxtbox.Text = selectedrow.Cells[""].Value.ToString();
                        warehouseidlbl.Text = selectedrow.Cells[""].Value.ToString();
                        warehousecodelbl.Text = selectedrow.Cells[""].Value.ToString();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void createwarehousesavebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(warehousenametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(warehousenametxtbox,"Please Enter Warehouse Name.");
                    warehousenametxtbox.Focus();
                    return;
                }

                if(addresstxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(addresstxtbox,"Please Enter Address.");
                    addresstxtbox.Focus();
                    return;
                }

                if(citytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(citytxtbox,"Please Enter City Name.");
                    citytxtbox.Focus();
                    return;
                }

                string duplicateinfo = await CheckDuplicate();
                if (duplicateinfo != null)
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (createwarehousesavebtn.Text == "Update")
                    {
                        bool isUpdated = await UpdateWarehouse();
                        if (isUpdated)
                        {
                            MessageBox.Show("Updated Successfully.");
                            FillGrid();
                        }
                    }
                    else
                    {
                        bool isInserted = await InsertWarehouse();
                        if (isInserted) 
                        {
                            MessageBox.Show("Saved Successfully.");
                            FillGrid();
                        }
                    }
                }

            }catch(Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task<string> CheckDuplicate()
        {
            string query = string.Format("SELECT WarehouseID,Name,Address,City,Code,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay," +
                "UpdatedDay FROM WarehouseTable WHERE Name LIKE @Name AND Address LIKE @Address AND City LIKE @City");
            var parameters = new Dictionary<string, object>
            {
                { "Name",warehousenametxtbox.Text },
                { "Address",addresstxtbox.Text },
                { "City",citytxtbox.Text }
            };

            DataTable dt = await DatabaseAccess.RetrieveDataAsync(query, parameters);
            if(dt!=null&& dt.Rows.Count > 0)
            {
                return $"Duplicate found: Unit Name = {dt.Rows[0]["UnitName"].ToString()}.";
            }
            return null;
        }

        private async Task<bool> InsertWarehouse()
        {
            string tableName = "WarehouseTable";
            var columnData = new Dictionary<string, object>
            {
                { "Name",warehousenametxtbox.Text },
                { "Address",addresstxtbox.Text },
                { "City",citytxtbox.Text },
                { "CreatedAt",DateTime.Now.ToString() },
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString() },
                { "Code", Guid.NewGuid().ToString() }
            };

            bool IsInserted = await DatabaseAccess.ExecuteQueryAsync(tableName,"INSERT",columnData);
            return IsInserted;
        }

        private async Task<bool> UpdateWarehouse()
        {
            string tableName = "WarehouseTable";
            string whereClause = "WarehouseID = '" + warehouseidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "Name",warehousenametxtbox.Text },
                { "Address",addresstxtbox.Text },
                { "City",citytxtbox.Text },
                { "UpdatedAt",DateTime.Now.ToString() },
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            return isUpdated;
        }
    }
}
