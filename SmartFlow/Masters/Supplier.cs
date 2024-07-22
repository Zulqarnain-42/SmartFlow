using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Supplier : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public Supplier()
        {
            InitializeComponent();
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            CreateSupplier createSupplier = new CreateSupplier();
            createSupplier.Show();
            createSupplier.FormClosed += delegate
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
                    query = "SELECT SupplierID [ID],SupplierName [Name],ContactNo [Mobile],Address,Description,Email,CreatedAt [Created] FROM SupplierTable";
                }
                else
                {
                    query = BuildSearchQuerySupplier(searchvalue);
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        supplierdatagridview.DataSource = dt;
                        supplierdatagridview.Columns[0].Width = 120;
                        supplierdatagridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        supplierdatagridview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        supplierdatagridview.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        supplierdatagridview.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        supplierdatagridview.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        supplierdatagridview.DataSource = null;
                    }
                }
                else
                {
                    supplierdatagridview.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < supplierdatagridview.Rows.Count &&
                    currentCellIndex < supplierdatagridview.Rows[currentRowIndex].Cells.Count)
                {
                    supplierdatagridview.CurrentCell = supplierdatagridview.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void Supplier_Load(object sender, EventArgs e)
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
        private void Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (supplierdatagridview != null)
                {
                    if (supplierdatagridview.Rows.Count > 0)
                    {
                        if (supplierdatagridview.SelectedRows.Count == 1)
                        {
                            CreateSupplier createSupplier = new CreateSupplier(Convert.ToInt32(supplierdatagridview.CurrentRow.Cells[0].Value));
                            createSupplier.FormClosed += delegate
                            {
                                currentRowIndex = supplierdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = supplierdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            createSupplier.Show();
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
            }
            catch (Exception ex) { throw ex; }
        }
        private void supplierdatagridview_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(supplierdatagridview);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(supplierdatagridview);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }
        private void supplierdatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (supplierdatagridview != null)
                {
                    if (supplierdatagridview.Rows.Count > 0)
                    {
                        if (supplierdatagridview.SelectedRows.Count == 1)
                        {
                            CreateSupplier createSupplier = new CreateSupplier(Convert.ToInt32(supplierdatagridview.CurrentRow.Cells[0].Value));
                            createSupplier.FormClosed += delegate
                            {
                                currentRowIndex = supplierdatagridview.CurrentCell.RowIndex;
                                currentCellIndex = supplierdatagridview.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            createSupplier.Show();
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
            }
            catch (Exception ex) { throw ex; }
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
        private string BuildSearchQuerySupplier(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT SupplierID [ID], SupplierName [Name], ContactNo [Mobile], Address, Description, Email, CreatedAt [Created] FROM SupplierTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (SupplierID LIKE '%{term}%' OR SupplierName LIKE '%{term}%' OR ContactNo LIKE '%{term}%' OR Email LIKE '%{term}%')");
            }

            return queryBuilder.ToString();
        }
        private void Supplier_FormClosing(object sender, FormClosingEventArgs e)
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
