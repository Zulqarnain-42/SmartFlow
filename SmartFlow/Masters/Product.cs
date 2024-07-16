using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Product : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public Product()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
            createProduct.FormClosed += delegate
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
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT ProductID [ID],ProductName [Title],StandardPrice [Price],UPC,EAN,MFR,Barcode FROM ProductTable";
                }
                else
                {

                    query = BuildSearchQuery(searchvalue);
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        productsGridView.DataSource = dt;
                        productsGridView.Columns[0].Width = 100;
                        productsGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        productsGridView.Columns[2].Width = 100;
                        productsGridView.Columns[3].Width = 100;
                        productsGridView.Columns[4].Width = 100;
                    }
                    else
                    {
                        productsGridView.DataSource = null;
                    }
                }
                else
                {
                    productsGridView.DataSource = null;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < productsGridView.Rows.Count &&
                    currentCellIndex < productsGridView.Rows[currentRowIndex].Cells.Count)
                {
                    productsGridView.CurrentCell = productsGridView.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            FillGrid(searchtxtbox.Text.Trim());
        }

        private void Product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }

            if(e.KeyCode == Keys.R)
            {
                FillGrid("");
                e.Handled = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsGridView != null)
                {
                    if (productsGridView.Rows.Count > 0)
                    {
                        if (productsGridView.SelectedRows.Count == 1)
                        {
                            CreateProduct createProduct = new CreateProduct(Convert.ToInt32(productsGridView.CurrentRow.Cells[0].Value));
                            createProduct.FormClosed += delegate
                            {
                                currentRowIndex = productsGridView.CurrentCell.RowIndex;
                                currentCellIndex = productsGridView.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            createProduct.Show();
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void productsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (productsGridView != null)
                {
                    if (productsGridView.Rows.Count > 0)
                    {
                        if (productsGridView.SelectedRows.Count == 1)
                        {
                            CreateProduct createProduct = new CreateProduct(Convert.ToInt32(productsGridView.CurrentRow.Cells[0].Value));
                            createProduct.FormClosed += delegate
                            {
                                currentRowIndex = productsGridView.CurrentCell.RowIndex;
                                currentCellIndex = productsGridView.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            createProduct.Show();
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

        private void productsGridView_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(productsGridView);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(productsGridView);
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsGridView != null)
                {
                    if (productsGridView.Rows.Count > 0)
                    {
                        if (productsGridView.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are you sure you want to delete selected record!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                currentRowIndex = productsGridView.CurrentCell.RowIndex;
                                currentCellIndex = productsGridView.CurrentCell.ColumnIndex;
                                string query = "DELETE FROM ProductTable WHERE ProductID = '"+ Convert.ToInt32(productsGridView.CurrentRow.Cells[0].Value) + "'";
                                DatabaseAccess.Delete(query);
                                FillGrid("");
                            }
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
            catch (Exception ex) { throw ex; }
        }

        private string BuildSearchQuery(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT ProductID [ID],ProductName [Title],StandardPrice [Price],UPC,EAN,MFR,Barcode, (");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" + ");
                }
                queryBuilder.Append($"(CASE WHEN ProductName LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN MFR LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN UPC LIKE '%{term}%' THEN 1 ELSE 0 END)");
            }

            queryBuilder.Append(") AS RelevanceScore FROM ProductTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (ProductName LIKE '%{term}%' OR MFR LIKE '%{term}%' OR UPC LIKE '%{term}%')");
            }

            queryBuilder.Append(" ORDER BY RelevanceScore DESC");

            return queryBuilder.ToString();
        }

        private void Product_FormClosing(object sender, FormClosingEventArgs e)
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
