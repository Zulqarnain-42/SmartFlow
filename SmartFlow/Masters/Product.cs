using SmartFlow.Common;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Product : Form
    {
        private int currentRowIndex = 0;
        private int currentCellIndex = 0;

        public Product()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.MdiParent = this.MdiParent;
            createProduct.FormClosed += delegate
            {
                FillGrid("");
            };
            CommonFunction.DisposeOnClose(createProduct);
            createProduct.Show();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FillGrid(string searchvalue) 
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT ProductID [ID],ProductName [Title],UPC,EAN,MFR,Barcode FROM ProductTable";
                }
                else
                {

                    query = BuildSearchQuery(searchvalue);
                }

                dt = await DatabaseAccess.RetriveAsync(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        productsGridView.DataSource = dt;
                        productsGridView.Columns[0].Width = 50;
                        productsGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        productsGridView.Columns[2].Width = 100;
                        productsGridView.Columns[3].Width = 100;
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
                if (currentRowIndex >= 0 && currentRowIndex >= 0 &&
                    currentRowIndex < productsGridView.Rows.Count &&
                    currentCellIndex < productsGridView.Rows[currentRowIndex].Cells.Count)
                {
                    productsGridView.CurrentCell = productsGridView.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                            createProduct.MdiParent = this.MdiParent;
                            createProduct.FormClosed += delegate
                            {
                                if (productsGridView.CurrentCell.RowIndex > 0 && productsGridView.CurrentCell.ColumnIndex > 0)
                                {
                                    currentRowIndex = productsGridView.CurrentCell.RowIndex;
                                    currentCellIndex = productsGridView.CurrentCell.ColumnIndex;
                                }
                                FillGrid("");
                            };
                            CommonFunction.DisposeOnClose(createProduct);
                            createProduct.ShowDialog();
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            // Check if the CurrentRow is not null
                            if (productsGridView.CurrentRow != null && productsGridView.CurrentRow.Cells[0].Value != null)
                            {
                                CreateProduct createProduct = new CreateProduct(Convert.ToInt32(productsGridView.CurrentRow.Cells[0].Value));
                                createProduct.MdiParent = this.MdiParent;
                                createProduct.FormClosed += delegate
                                {
                                    // Check if CurrentCell is not null
                                    if (productsGridView.CurrentCell != null &&
                                        productsGridView.CurrentCell.RowIndex > 0 &&
                                        productsGridView.CurrentCell.ColumnIndex > 0)
                                    {
                                        currentRowIndex = productsGridView.CurrentCell.RowIndex;
                                        currentCellIndex = productsGridView.CurrentCell.ColumnIndex;
                                    }
                                    FillGrid("");
                                };
                                CommonFunction.DisposeOnClose(createProduct);
                                createProduct.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid row data.");
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
                else
                {
                    MessageBox.Show("The Grid View is null.");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private string BuildSearchQuery(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT ProductID [ID], ProductName [Title], UPC, EAN, MFR," +
                " Barcode FROM ProductTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (ProductName LIKE '%{term}%' OR MFR LIKE '%{term}%' OR UPC LIKE '%{term}%')");
            }

            // Note: RelevanceScore calculation and ORDER BY clause have been removed

            return queryBuilder.ToString();
        }

        private void productDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsGridView != null)
                {
                    if (productsGridView.Rows.Count > 0)
                    {
                        if (productsGridView.SelectedRows.Count == 1)
                        {
                            string title = "Product Details";
                            CreateProduct createProduct = new CreateProduct(Convert.ToInt32(productsGridView.CurrentRow.Cells[0].Value),title);
                            createProduct.MdiParent = this.MdiParent;
                            createProduct.FormClosed += delegate
                            {
                                currentRowIndex = productsGridView.CurrentCell.RowIndex;
                                currentCellIndex = productsGridView.CurrentCell.ColumnIndex;
                                FillGrid("");
                            };
                            CommonFunction.DisposeOnClose(createProduct);
                            createProduct.ShowDialog();
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
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
