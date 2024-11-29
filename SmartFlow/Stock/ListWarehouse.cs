using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class ListWarehouse : Form
    {
        public ListWarehouse()
        {
            InitializeComponent();
        }

        private void ListWarehouse_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistwarehouse = new DataTable();
                query = "SELECT WarehouseID,Name,Address,City FROM WarehouseTable";
                dtlistwarehouse = DatabaseAccess.Retrive(query);

                if (dtlistwarehouse != null && dtlistwarehouse.Rows.Count > 0) 
                {
                    dgvlistwarehouse.DataSource = dtlistwarehouse;

                    dgvlistwarehouse.Columns[0].Width = 50;
                    dgvlistwarehouse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistwarehouse.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistwarehouse.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Restore the cursor position
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < dgvlistwarehouse.Rows.Count &&
                    GlobalVariables.currentCellIndex < dgvlistwarehouse.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvlistwarehouse.CurrentCell = dgvlistwarehouse.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
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

        private void createwarehousesavebtn_Click(object sender, EventArgs e)
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

                string duplicateinfo = CheckDuplicate();
                if (duplicateinfo != null)
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (createwarehousesavebtn.Text == "Update")
                    {
                        bool isUpdated = UpdateWarehouse();
                        if (isUpdated)
                        {
                            MessageBox.Show("Updated Successfully.");
                            FillGrid();
                        }
                    }
                    else
                    {
                        bool isInserted = InsertWarehouse();
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

        private string CheckDuplicate()
        {
            string query = string.Format("SELECT WarehouseID,Name,Address,City,Code,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay," +
                "UpdatedDay FROM WarehouseTable WHERE Name LIKE @Name AND Address LIKE @Address AND City LIKE @City");
            var parameters = new Dictionary<string, object>
            {
                { "Name",warehousenametxtbox.Text },
                { "Address",addresstxtbox.Text },
                { "City",citytxtbox.Text }
            };

            DataTable dt = DatabaseAccess.RetrieveData(query, parameters);
            if(dt!=null&& dt.Rows.Count > 0)
            {
                return $"Duplicate found: Unit Name = {dt.Rows[0]["UnitName"].ToString()}.";
            }
            return null;
        }

        private bool InsertWarehouse()
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

            bool IsInserted = DatabaseAccess.ExecuteQuery(tableName,"INSERT",columnData);
            return IsInserted;
        }

        private bool UpdateWarehouse()
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

            bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            return isUpdated;
        }
    }
}
