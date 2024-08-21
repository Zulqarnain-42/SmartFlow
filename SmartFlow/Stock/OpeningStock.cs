using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class OpeningStock : Form
    {
        private int currentRowIndex;
        private int currentCellIndex;
        public OpeningStock()
        {
            InitializeComponent();
        }
        private void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                
                if(string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = string.Format("SELECT ProductID [ID],ProductName [TITLE],StandardPrice [PRICE],CreatedAt [CREATED],UPC,MFR,Barcode [BARCODE],Quantity [QUANTITY] " +
                        "FROM ProductTable");
                }
                else
                {

                    query = BuildSearchQuery(searchvalue);
                }

                DataTable datatableProduct = DatabaseAccess.Retrive(query);
                if (datatableProduct.Rows.Count > 0)
                {
                    dgvProducts.DataSource = datatableProduct;
                    dgvProducts.Columns[0].Width = 100;
                    dgvProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvProducts.Columns[2].Width = 150;
                    dgvProducts.Columns[3].Width = 150;
                    dgvProducts.Columns[4].Width = 200;
                    dgvProducts.Columns[5].Width = 200;
                    dgvProducts.Columns[6].Width = 200;
                    dgvProducts.Columns[7].Width = 200;
                }
                else
                {
                    MessageBox.Show("Something is wrong");
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < dgvProducts.Rows.Count &&
                    currentCellIndex < dgvProducts.Rows[currentRowIndex].Cells.Count)
                {
                    dgvProducts.CurrentCell = dgvProducts.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void OpeningStock_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProducts.Rows.Count > 0)
                {
                    if(dgvProducts.SelectedRows.Count == 1)
                    {
                        UpdateQuantity updateQuantity = new UpdateQuantity(Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value), 
                            dgvProducts.CurrentRow.Cells[1].Value.ToString(), dgvProducts.CurrentRow.Cells[5].Value.ToString(), 
                            Convert.ToInt32(dgvProducts.CurrentRow.Cells[7].Value));
                        updateQuantity.FormClosed += delegate
                        {
                            currentRowIndex = dgvProducts.CurrentCell.RowIndex;
                            currentCellIndex = dgvProducts.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        updateQuantity.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row.");
                    }
                }
            }catch (Exception ex) { throw ex; }
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            FillGrid(searchtxtbox.Text);
        }
        private void dgvProducts_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvProducts);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvProducts);
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
        private void OpeningStock_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
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
    }
}
