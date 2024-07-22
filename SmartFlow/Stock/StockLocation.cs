using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class StockLocation : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
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
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < locationdatagridview.Rows.Count &&
                    currentCellIndex < locationdatagridview.Rows[currentRowIndex].Cells.Count)
                {
                    locationdatagridview.CurrentCell = locationdatagridview.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch(Exception ex) { throw ex; }
        }
        private void StockLocation_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void StockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }

            if(e.Control && e.KeyCode == Keys.R)
            {
                FillGrid("");
                e.Handled = true;
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
            catch(Exception ex) { throw ex; }
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
            }catch (Exception ex) { throw ex; }
        }
        private void locationdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(locationdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(locationdatagridview);
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
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void createlocationsavebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (createlocationsavebtn.Text == "Update")
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

                    string query = string.Format("SELECT LocationID,WarehouseID,LocationName,RackNumber,ShortName FROM LocationTable " +
                        "WHERE WarehouseID = '" + warehouseidlbl.Text + "' AND RackNumber = '" + racknotxtbox.Text + "'");
                    DataTable dataTablelocation = DatabaseAccess.Retrive(query);
                    if (dataTablelocation != null)
                    {
                        if (dataTablelocation.Rows.Count > 0)
                        {
                            if (dataTablelocation.Rows[0]["WarehouseID"].ToString() == warehouseidlbl.Text.ToString()
                                && dataTablelocation.Rows[0]["RackNumber"].ToString() == racknotxtbox.Text
                                && dataTablelocation.Rows[0]["LocationName"].ToString() == locationnametxtbox.Text
                                && dataTablelocation.Rows[0]["ShortName"].ToString() == shortnametxtbox.Text)
                            {
                                MessageBox.Show("Location Already Exist!");
                            }
                            else
                            {
                                query = string.Format("UPDATE LocationTable SET " +
                                    "WarehouseID = '{0}' ," +
                                    "LocationName = '{1}'," +
                                    "RackNumber = '{2}'," +
                                    "ShortName = '{3}'," +
                                    "UpdatedAt = '{4}'," +
                                    "UpdatedDay = '{5}' " +
                                    "WHERE  LocationID = '{6}'",
                                    warehouseidlbl.Text,
                                    locationnametxtbox.Text.Trim(),
                                    racknotxtbox.Text.Trim(),
                                    shortnametxtbox.Text.Trim(),
                                    DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"),
                                    DateTime.Now.DayOfWeek,
                                    locationid.Text);

                                bool result = DatabaseAccess.Update(query);
                                if (result)
                                {
                                    MessageBox.Show("Updated Successfully!");
                                    ResetData();
                                    FillGrid("");
                                }
                                else
                                {
                                    MessageBox.Show("Something is Wrong!");
                                }
                            }
                        }
                        else
                        {
                            query = string.Format("UPDATE LocationTable SET " +
                                    "WarehouseID = '{0}' ," +
                                    "LocationName = '{1}'," +
                                    "RackNumber = '{2}'," +
                                    "ShortName = '{3}'," +
                                    "UpdatedAt = '{4}'," +
                                    "UpdatedDay = '{5}' " +
                                    "WHERE  LocationID = '{6}'",
                                    warehouseidlbl.Text,
                                    locationnametxtbox.Text.Trim(),
                                    racknotxtbox.Text.Trim(),
                                    shortnametxtbox.Text.Trim(),
                                    DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"),
                                    DateTime.Now.DayOfWeek,
                                    locationid.Text);

                            bool result = DatabaseAccess.Update(query);
                            if (result)
                            {
                                MessageBox.Show("Updated Successfully!");
                                ResetData();
                                FillGrid("");
                            }
                            else
                            {
                                MessageBox.Show("Something is Wrong!");
                            }
                        }
                    }

                }
                else
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

                    string query = string.Format("SELECT LocationID,WarehouseID,LocationName,RackNumber,ShortName FROM LocationTable " +
                        "WHERE WarehouseID = '" + warehouseidlbl.Text + "' AND RackNumber = '" + racknotxtbox.Text + "'");
                    DataTable dataTablelocation = DatabaseAccess.Retrive(query);

                    if (dataTablelocation != null)
                    {
                        if (dataTablelocation.Rows.Count > 0)
                        {
                            MessageBox.Show("Location Already Exist");
                        }
                        else
                        {
                            query = string.Format("INSERT INTO LocationTable " +
                        "(WarehouseID,LocationName,RackNumber,ShortName,Code,CreatedAt,CreatedDay) VALUES " +
                        "('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        warehouseidlbl.Text, locationnametxtbox.Text.Trim(),
                        racknotxtbox.Text.Trim(), shortnametxtbox.Text.Trim(), Guid.NewGuid(),
                        DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"), DateTime.Now.DayOfWeek);

                            bool result = DatabaseAccess.Insert(query);
                            if (result)
                            {
                                MessageBox.Show("Saved Successfully!");
                                ResetData();
                                FillGrid("");
                            }
                            else
                            {
                                MessageBox.Show("Something is Wrong!");
                            }
                        }
                    }
                    else
                    {
                        query = string.Format("INSERT INTO LocationTable " +
                        "(WarehouseID,LocationName,RackNumber,ShortName,Code,CreatedAt,CreatedDay) VALUES " +
                        "('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        warehouseidlbl.Text, locationnametxtbox.Text.Trim(),
                        racknotxtbox.Text.Trim(), shortnametxtbox.Text.Trim(), Guid.NewGuid(),
                        DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"), DateTime.Now.DayOfWeek);

                        bool result = DatabaseAccess.Insert(query);
                        if (result)
                        {
                            MessageBox.Show("Saved Successfully!");
                            ResetData();
                            FillGrid("");
                        }
                        else
                        {
                            MessageBox.Show("Something is Wrong!");
                        }
                    }
                }
            }catch (Exception ex) { throw ex; }
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
                            warehouseSelection.ShowDialog();
                            UpdateWarehouseTextBox();
                        }
                    }
                    
                }
                else
                {
                    openForm.BringToFront();
                }
            }catch (Exception ex) { throw ex; }
        }
        private void UpdateWarehouseTextBox()
        {
            try
            {
                warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
                selectwarehousetxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
            }catch (Exception ex) { throw ex; }
        }
        private void StockLocation_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
