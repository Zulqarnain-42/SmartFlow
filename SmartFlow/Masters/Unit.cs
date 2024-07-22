using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class Unit : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public Unit()
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
                    query = "SELECT UnitID [ID],UnitName [Name],Description FROM UnitTable";
                }
                else
                {
                    query = "SELECT UnitID [ID],UnitName [Name],Description FROM UnitTable WHERE UnitName LIKE '%" + searchtxtbox.Text.Trim() + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        unitdatagridview.DataSource = dt;
                        unitdatagridview.Columns[0].Width = 100;
                        unitdatagridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        unitdatagridview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        unitdatagridview.DataSource = null;
                    }
                }
                else
                {
                    unitdatagridview.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < unitdatagridview.Rows.Count &&
                    currentCellIndex < unitdatagridview.Rows[currentRowIndex].Cells.Count)
                {
                    unitdatagridview.CurrentCell = unitdatagridview.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void Unit_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void Unit_KeyDown(object sender, KeyEventArgs e)
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
                if (unitdatagridview != null)
                {
                    if (unitdatagridview.Rows.Count > 0)
                    {
                        if (unitdatagridview.SelectedRows.Count == 1)
                        {
                            object cellValue = unitdatagridview.SelectedRows[0].Cells[0].Value;
                            if (cellValue != null)
                            {
                                label3.Text = cellValue.ToString();
                            }
                            object cellvalue2 = unitdatagridview.SelectedRows[0].Cells[1].Value;
                            if (cellvalue2 != null)
                            {
                                unitnametxtbox.Text = cellvalue2.ToString();
                            }
                            object cellvalue3 = unitdatagridview.SelectedRows[0].Cells[2].Value;
                            if (cellvalue3 != null)
                            {
                                unitdescription.Text = cellvalue3.ToString();
                            }

                            else
                            {
                                MessageBox.Show("Please Select One Row.");
                            }
                            savebtn.Text = "Update";
                        }
                        else
                        {
                            MessageBox.Show("No Record Available.");
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (savebtn.Text == "Update")
                {
                    errorProvider.Clear();
                    if (unitnametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(unitnametxtbox, "Please Enter Unit Name.");
                        unitnametxtbox.Focus();
                        return;
                    }

                    string query = string.Format("UPDATE UnitTable SET UnitName = '"+unitnametxtbox.Text.Trim()+"'" +
                        ",Description = '"+unitdescription.Text.Trim()+"',UpdatedAt = '"+ DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                        "UpdatedDay = '"+DateTime.Now.DayOfWeek+ "' WHERE UnitID = '"+label3.Text+"'");

                    bool result = DatabaseAccess.Update(query);
                    if (result)
                    {
                        MessageBox.Show("UPDATED Successfully!");
                        ResetData();
                        FillGrid("");
                    }
                    else
                    {
                        MessageBox.Show("Something is Wrong!");
                    }
                }
                else
                {
                    errorProvider.Clear();
                    if (unitnametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(unitnametxtbox, "Please Enter Unit Name.");
                        unitnametxtbox.Focus();
                        return;
                    }

                    string query = string.Format("INSERT INTO UnitTable (UnitName,Description,UnitCode,CreatedAt,CreatedDay) VALUES ('{0}','{1}','{2}','{3}','{4}')",
                        unitnametxtbox.Text.Trim(),
                        unitdescription.Text.Trim(),
                        Guid.NewGuid(),
                        DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"),
                        DateTime.Now.DayOfWeek);

                    bool result = DatabaseAccess.Insert(query);
                    if (result)
                    {
                        MessageBox.Show("Saved Successfully!");
                        FillGrid("");
                    }
                    else
                    {
                        MessageBox.Show("Something is Wrong!");
                    }
                }

            }
            catch (Exception ex) { throw ex; }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void unitdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (unitdatagridview != null)
                {
                    if (unitdatagridview.Rows.Count > 0)
                    {
                        if (unitdatagridview.SelectedRows.Count == 1)
                        {
                            object cellValue = unitdatagridview.SelectedRows[0].Cells[0].Value;
                            if (cellValue != null)
                            {
                                label3.Text = cellValue.ToString();
                            }
                            object cellvalue2 = unitdatagridview.SelectedRows[0].Cells[1].Value;
                            if (cellvalue2 != null)
                            {
                                unitnametxtbox.Text = cellvalue2.ToString();
                            }
                            object cellvalue3 = unitdatagridview.SelectedRows[0].Cells[2].Value;
                            if (cellvalue3 != null)
                            {
                                unitdescription.Text = cellvalue3.ToString();
                            }

                            else
                            {
                                MessageBox.Show("Please Select One Row.");
                            }
                            savebtn.Text = "Update";
                        }
                        else
                        {
                            MessageBox.Show("No Record Available.");
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void ResetData()
        {
            unitnametxtbox.Text = "";
            unitdescription.Text = "";
            savebtn.Text = "SAVE";
        }
        private void unitdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(unitdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(unitdatagridview);
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
        private void Unit_FormClosing(object sender, FormClosingEventArgs e)
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
