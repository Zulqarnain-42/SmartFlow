using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Customers : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public Customers()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
            createCustomer.FormClosed += delegate
            {
                FillGrid("");
            };
        }

        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT CustomerID [ID],CustomerName [Name],ContactNo [Mobile],Address,Description,Email,CreateAt [Creation] FROM CustomerTable";
                }
                else
                {
                    query = BuildSearchQueryCustomer(searchvalue);
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        customerdatagridview.DataSource = dt;
                        customerdatagridview.Columns[0].Width = 100;
                        customerdatagridview.Columns[1].Width = 250;
                        customerdatagridview.Columns[2].Width = 100;
                        customerdatagridview.Columns[3].Width = 100;
                        customerdatagridview.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        customerdatagridview.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        customerdatagridview.DataSource = null;
                    }
                }
                else
                {
                    customerdatagridview.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < customerdatagridview.Rows.Count &&
                    currentCellIndex < customerdatagridview.Rows[currentRowIndex].Cells.Count)
                {
                    customerdatagridview.CurrentCell = customerdatagridview.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            FillGrid(searchtxtbox.Text.Trim());
        }

        private void Customers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                FillGrid("");
                e.Handled = true;
            }

            if(e.Control && e.KeyCode == Keys.N)
            {
                Account account = new Account();
                account.Show();
                account.FormClosed += delegate
                {
                    FillGrid("");
                };
                e.Handled = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerdatagridview != null)
                {
                    if (customerdatagridview.Rows.Count > 0)
                    {
                        if (customerdatagridview.SelectedRows.Count == 1)
                        {
                            Account account = new Account(Convert.ToInt32(customerdatagridview.CurrentRow.Cells[0].Value));
                            account.FormClosed += delegate
                            {
                                currentRowIndex = customerdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = customerdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            account.Show();
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
            }
            catch(Exception ex) { throw ex; }
        }

        private void customerdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(customerdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(customerdatagridview);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
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

        private void customerdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (customerdatagridview != null)
                {
                    if (customerdatagridview.Rows.Count > 0)
                    {
                        if(customerdatagridview.SelectedRows.Count == 1)
                        {
                            Account account = new Account(Convert.ToInt32(customerdatagridview.CurrentRow.Cells[0].Value));
                            account.FormClosed += delegate
                            {
                                currentRowIndex = customerdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = customerdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            account.Show();
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Available");
                    }
                }
            }catch (Exception ex) { throw ex; }
        }

        private string BuildSearchQueryCustomer(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT CustomerID [ID], CustomerName [Name], ContactNo [Mobile], Address, Description, Email, CreateAt [Creation] FROM CustomerTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (CustomerName LIKE '%{term}%' OR ContactNo LIKE '%{term}%' OR Email LIKE '%{term}%')");
            }

            return queryBuilder.ToString();
        }

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
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
