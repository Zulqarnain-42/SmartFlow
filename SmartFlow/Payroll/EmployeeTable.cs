using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Payroll
{
    public partial class EmployeeTable : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public EmployeeTable()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            employee.FormClosed += delegate
            {
                FillGrid("");
            };
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if(string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT EmployeeID [ID],EmployeeCode [Code],Fullname [Name],Email,MobileNo [Mobile],Designation FROM EmployeeTable";
                }
                else
                {
                    query = "SELECT EmployeeID [ID],EmployeeCode [Code],Fullname [Name],Email,MobileNo [Mobile],Designation FROM EmployeeTable " +
                        "WHERE Fullname = '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        employeedgv.DataSource = dt;
                        employeedgv.Columns[0].Width = 150;
                        employeedgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        employeedgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        employeedgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        employeedgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        employeedgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    }
                    else
                    {
                        employeedgv.DataSource = null;
                    }
                }
                else
                {
                    employeedgv.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < employeedgv.Rows.Count &&
                    currentCellIndex < employeedgv.Rows[currentRowIndex].Cells.Count)
                {
                    employeedgv.CurrentCell = employeedgv.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void EmployeeTable_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }

        private void EmployeeTable_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }

            if(e.Control && e.KeyCode == Keys.R)
            {
                FillGrid("");
                e.Handled = true;
            }
        }

        private void employeedgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(employeedgv != null)
                {
                    if(employeedgv.Rows.Count > 0)
                    {
                        if(employeedgv.SelectedRows.Count == 1)
                        {
                            Employee employee = new Employee(Convert.ToInt32(employeedgv.CurrentRow.Cells[0].Value));
                            employee.FormClosed += delegate
                            {
                                currentRowIndex = employeedgv.CurrentCell.RowIndex;
                                currentCellIndex = employeedgv.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            employee.Show();
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available.");
                    }
                }
            }catch (Exception ex) { throw ex; }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (employeedgv != null)
                {
                    if(employeedgv.Rows.Count > 0)
                    {
                        if(employeedgv.SelectedRows.Count == 1)
                        {
                            Employee employee = new Employee(Convert.ToInt32(employeedgv.CurrentRow.Cells[0].Value));
                            employee.FormClosed += delegate
                            {
                                currentRowIndex = employeedgv.CurrentCell.RowIndex;
                                currentCellIndex = employeedgv.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            employee.Show();
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available.");
                    }
                }
            }catch (Exception ex) { throw ex; }
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            FillGrid(searchtxtbox.Text.Trim());

        }

        private void employeedgv_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(employeedgv);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(employeedgv);
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

        private void EmployeeTable_FormClosing(object sender, FormClosingEventArgs e)
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
