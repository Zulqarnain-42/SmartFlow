using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AccountHead : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public AccountHead()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(savebtn.Text == "Update")
                {
                    errorProvider.Clear();
                    if(accountheadtxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(accountheadtxtbox,"Please Enter Account Head");
                        accountheadtxtbox.Focus();
                        return;
                    }

                    string findheadupdate = "SELECT AccountHeadID,AccountHeadName,User_ID,AccountHeadCode,CompanyID,CreatedAt,UpdatedAt," +
                        "AddedBy,CreatedDay,UpdatedDay FROM AccountHeadTable WHERE AccountHeadName LIKE '" + accountheadtxtbox.Text.Trim() + "'";
                    DataTable dataheadupdate = DatabaseAccess.Retrive(findheadupdate);

                    if(dataheadupdate != null )
                    {
                        if(dataheadupdate.Rows.Count > 0)
                        {
                            MessageBox.Show("Account Head Already Exist");
                        }
                        else
                        {
                            string updatehead = "UPDATE AccountHeadTable SET AccountHeadName = '" + accountheadtxtbox.Text.Trim() + "'," +
                                "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "',UpdatedDay = '" + DateTime.Now.DayOfWeek + "' " +
                                "WHERE AccountHeadID = '"+accountid.Text+"'";

                            bool result = DatabaseAccess.Update(updatehead);
                            if (result)
                            {
                                MessageBox.Show("Updated Successfully!");
                                ResetData();
                                FillGrid("");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong");
                            }
                        }
                    }
                }
                else
                {
                    errorProvider.Clear();
                    if (accountheadtxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(accountheadtxtbox, "Please Enter Account Head");
                        accountheadtxtbox.Focus();
                        return;
                    }

                    string findhead = "SELECT AccountHeadID,AccountHeadName,User_ID,AccountHeadCode,CompanyID,CreatedAt,UpdatedAt," +
                        "AddedBy,CreatedDay,UpdatedDay FROM AccountHeadTable WHERE AccountHeadName LIKE '" + accountheadtxtbox.Text.Trim() + "'";
                    DataTable datahead = DatabaseAccess.Retrive(findhead);

                    if (datahead != null)
                    {
                        if (datahead.Rows.Count > 0)
                        {
                            MessageBox.Show("Account Head Already Exist");
                        }
                        else
                        {
                            string addhead = "INSERT INTO AccountHeadTable (AccountHeadName,AccountHeadCode,CreatedAt,CreatedDay)" +
                                " VALUES ('" + accountheadtxtbox.Text.Trim() + "','" + Guid.NewGuid() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "')";
                            bool result = DatabaseAccess.Insert(addhead);
                            if (result)
                            {
                                MessageBox.Show("Saved Successfully!");
                                ResetData();
                                FillGrid("");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                }
                
            }catch (Exception ex) { throw ex; }
        }
        private void ResetData()
        {
            accountheadtxtbox.Text = "";
            savebtn.Text = "SAVE";
        }
        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if(string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountHeadID [ID],AccountHeadCode [Code],AccountHeadName [Account Head] FROM AccountHeadTable";
                }
                else
                {
                    query = "SELECT AccountHeadID [ID],AccountHeadCode [Code],AccountHeadName [Account Head] FROM AccountHeadTable WHERE AccountHeadName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if( dt != null )
                {
                    if(dt.Rows.Count > 0)
                    {
                        dgvaccounthead.DataSource = dt;
                        dgvaccounthead.Columns[0].Width = 100;
                        dgvaccounthead.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvaccounthead.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        dgvaccounthead.DataSource = null;
                    }
                }
                else
                {
                    dgvaccounthead.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < dgvaccounthead.Rows.Count &&
                    currentCellIndex < dgvaccounthead.Rows[currentRowIndex].Cells.Count)
                {
                    dgvaccounthead.CurrentCell = dgvaccounthead.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void AccountHead_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AccountHead_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvaccounthead != null)
                {
                    if (dgvaccounthead.Rows.Count > 0)
                    {
                        if(dgvaccounthead.SelectedRows.Count == 1)
                        {
                            object cellValue = dgvaccounthead.SelectedRows[0].Cells[0].Value;
                            if (cellValue != null)
                            {
                                accountid.Text = cellValue.ToString();
                            }

                            object cellvalue1 = dgvaccounthead.SelectedRows[0].Cells[2].Value;
                            if(cellvalue1 != null)
                            {
                                accountheadtxtbox.Text = cellvalue1.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Please Select One Row");
                            }

                            savebtn.Text = "Update";
                        }
                        else
                        {
                            MessageBox.Show("No Record Available.");
                        }
                    }
                }
            }catch (Exception ex) { throw ex;}
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
        private void dgvaccounthead_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvaccounthead);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvaccounthead);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }
        private void AccountHead_FormClosing(object sender, FormClosingEventArgs e)
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
