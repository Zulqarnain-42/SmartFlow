using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class StockLocation : Form
    {
        public StockLocation()
        {
            InitializeComponent();
        }
        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT LocationTable.LocationID [ID],WarehouseTable.Name [Warehouse Name],LocationTable.WarehouseID," +
                        "LocationTable.LocationName [Location Name],LocationTable.RackNumber[Rack Number]," +
                        "LocationTable.ShortName[Short Name] FROM LocationTable " +
                        "INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = LocationTable.WarehouseID";
                }
                else
                {
                    query = "SELECT LocationTable.LocationID [ID],WarehouseTable.Name [Warehouse Name],LocationTable.WarehouseID," +
                        "LocationTable.LocationName [Location Name],LocationTable.RackNumber[Rack Number]," +
                        "LocationTable.ShortName[Short Name] FROM LocationTable " +
                        "INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = LocationTable.WarehouseID " +
                        "WHERE LocationTable.LocationName '%" + searchtxtbox.Text.Trim() + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        locationdatagridview.DataSource = dt;
                        locationdatagridview.Columns[0].Width = 100;
                        locationdatagridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        locationdatagridview.Columns[2].Visible = false;
                        locationdatagridview.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        locationdatagridview.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        locationdatagridview.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        locationdatagridview.DataSource = null;
                    }
                }
                else
                {
                    locationdatagridview.DataSource = null;
                }

                // Restore the cursor position
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < locationdatagridview.Rows.Count &&
                    GlobalVariables.currentCellIndex < locationdatagridview.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    locationdatagridview.CurrentCell = locationdatagridview.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void StockLocation_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void StockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (locationdatagridview != null)
                {
                    if (locationdatagridview.Rows.Count > 0)
                    {
                        if (locationdatagridview.SelectedRows.Count == 1)
                        {
                            object cellValue = locationdatagridview.SelectedRows[0].Cells[0].Value;
                            if (cellValue != null)
                            {
                                locationid.Text = cellValue.ToString();
                            }
                            object cellvalue2 = locationdatagridview.SelectedRows[0].Cells[1].Value;
                            if (cellvalue2 != null)
                            {
                                selectwarehousetxtbox.Text = cellvalue2.ToString();
                            }
                            object cellvalue1 = locationdatagridview.SelectedRows[0].Cells[2].Value;
                            if (cellvalue1 != null)
                            {
                                warehouseidlbl.Text = cellvalue1.ToString();
                            }

                            object cellvalue3 = locationdatagridview.SelectedRows[0].Cells[3].Value;
                            if (cellvalue3 != null)
                            {
                                locationnametxtbox.Text = cellvalue3.ToString();
                            }
                            object cellvalue4 = locationdatagridview.SelectedRows[0].Cells[4].Value;
                            if(cellvalue4 != null)
                            {
                                racknotxtbox.Text = cellvalue4.ToString();
                            }
                            object cellvalue5 = locationdatagridview.SelectedRows[0].Cells[5].Value;
                            if (cellvalue5 != null)
                            {
                                shortnametxtbox.Text = cellvalue5.ToString();
                            }

                            createlocationsavebtn.Text = "Update";
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Row.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available.");
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void locationdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (locationdatagridview != null)
                {
                    if (locationdatagridview.Rows.Count > 0)
                    {
                        if(locationdatagridview.SelectedRows.Count == 1)
                        {
                            object cellValue = locationdatagridview.SelectedRows[0].Cells[0].Value;
                            if (cellValue != null)
                            {
                                locationid.Text = cellValue.ToString();
                            }
                            object cellvalue2 = locationdatagridview.SelectedRows[0].Cells[1].Value;
                            if (cellvalue2 != null)
                            {
                                selectwarehousetxtbox.Text = cellvalue2.ToString();
                            }
                            object cellvalue1 = locationdatagridview.SelectedRows[0].Cells[2].Value;
                            if (cellvalue1 != null)
                            {
                                warehouseidlbl.Text = cellvalue1.ToString();
                            }
                            object cellvalue3 = locationdatagridview.SelectedRows[0].Cells[3].Value;
                            if (cellvalue3 != null)
                            {
                                locationnametxtbox.Text = cellvalue3.ToString();
                            }
                            object cellvalue4 = locationdatagridview.SelectedRows[0].Cells[4].Value;
                            if (cellvalue4 != null)
                            {
                                racknotxtbox.Text = cellvalue4.ToString();
                            }
                            object cellvalue5 = locationdatagridview.SelectedRows[0].Cells[5].Value;
                            if (cellvalue5 != null)
                            {
                                shortnametxtbox.Text = cellvalue5.ToString();
                            }

                            createlocationsavebtn.Text = "Update";
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Row.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available");
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void locationdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(locationdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(locationdatagridview);
            if (firstVisibleRowIndex >= 0)
            {
                GlobalVariables.currentRowIndex = firstVisibleRowIndex;
                GlobalVariables.currentCellIndex = firstVisibleCellIndex;
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
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void createlocationsavebtn_Click(object sender, EventArgs e)
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

                if (racknotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(racknotxtbox, "Please Enter Rack No");
                    locationnametxtbox.Focus();
                    return;
                }

                string duplicateinfo = CheckDuplicate();
                if (duplicateinfo != null) 
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (createlocationsavebtn.Text == "Update")
                    {
                        bool isUpdated = UpdateStockLocation();
                        if (isUpdated) 
                        {
                            MessageBox.Show("Updated Successfully.");
                            FillGrid("");
                            ResetData();
                        }
                    }
                    else
                    {
                        bool isInserted = InsertStocklocation();
                        if (isInserted)
                        {
                            MessageBox.Show("Saved Successfully.");
                            FillGrid("");
                            ResetData();
                        }
                    }
                }
                
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void ResetData()
        {
            selectwarehousetxtbox.Text = string.Empty;
            warehouseidlbl.Text = string.Empty;
            locationnametxtbox.Text = string.Empty;
            racknotxtbox.Text = string.Empty;
            shortnametxtbox.Text = string.Empty;
            createlocationsavebtn.Text = "Update";
        }
        private void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                            warehouseSelection.MdiParent = this.MdiParent;
                            
                            warehouseSelection.FormClosed += delegate
                            {
                                UpdateWarehouseTextBox();
                            };

                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.Show();
                        }
                    }
                    
                }
                else
                {
                    openForm.BringToFront();
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void UpdateWarehouseTextBox()
        {
            try
            {
                if(GlobalVariables.warehouseidglobal > 0 && GlobalVariables.warehousenameglobal != null)
                {
                    warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
                    selectwarehousetxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
                } 
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (locationnametxtbox.Text.Trim().Length > 0) { return true; }
            if (racknotxtbox.Text.Trim().Length > 0) { return true; }
            if (shortnametxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private string CheckDuplicate()
        {
            string query = string.Format(@"SELECT LocationID,WarehouseID,LocationName,RackNumber,ShortName,Code,CompanyID,CreatedAt,UpdatedAt,
                AddedBy,CreatedDay,UpdatedDay FROM LocationTable WHERE WarehouseID = @WarehouseID AND LocationName LIKE @LocationName AND RackNumber LIKE @RackNumber");

            var parameters = new Dictionary<string, object>
            {
                { "WarehouseID", warehouseidlbl.Text },
                { "LocationName", locationnametxtbox.Text },
                { "RackNumber", racknotxtbox.Text }
            };

            DataTable dt = DatabaseAccess.RetrieveData(query, parameters);
            if(dt!=null && dt.Rows.Count > 0)
            {
                return $"Duplicate found: Unit Name = {dt.Rows[0]["UnitName"].ToString()}.";
            }

            return null;
        }

        private bool InsertStocklocation()
        {
            string tablename = "LocationTable";
            var columnData = new Dictionary<string, object>
            {
                { "WarehouseID",warehouseidlbl.Text },
                { "LocationName",locationnametxtbox.Text },
                { "RackNumber", racknotxtbox.Text },
                { "ShortName",shortnametxtbox.Text},
                { "Code",Guid.NewGuid().ToString()},
                { "CreatedAt",DateTime.Now.ToString()},
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString()}
            };

            bool isInserted = DatabaseAccess.ExecuteQuery(tablename, "INSERT", columnData);
            return isInserted;
        }

        private bool UpdateStockLocation()
        {
            string tableName = "LocationTable";
            string whereClause = "LocationID = '" + locationid.Text + "'";
            var columnData = new Dictionary<string, object>
            {
                { "WarehouseID",warehouseidlbl.Text },
                { "LocationName",locationnametxtbox.Text },
                { "RackNumber", racknotxtbox.Text },
                { "ShortName",shortnametxtbox.Text},
                { "UpdatedAt",DateTime.Now.ToString()},
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString()}
            };

            bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            return isUpdated;
        }
    }
}
