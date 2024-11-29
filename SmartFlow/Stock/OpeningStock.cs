using SmartFlow.Common;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class OpeningStock : Form
    {
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
                    query = string.Format("SELECT ProductID [ID],ProductName [TITLE],UPC,EAN,MFR,Barcode [BARCODE] FROM ProductTable");
                }
                else
                {

                    query = BuildSearchQuery(searchvalue);
                }

                DataTable datatableProduct = DatabaseAccess.Retrive(query);
                if (datatableProduct.Rows.Count > 0)
                {
                    dgvProducts.DataSource = datatableProduct;
                    dgvProducts.Columns[0].Width = 50;
                    dgvProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvProducts.Columns[2].Width = 100;
                    dgvProducts.Columns[3].Width = 100;
                    dgvProducts.Columns[4].Width = 100;
                    dgvProducts.Columns[5].Width = 80;
                }
                else
                {
                    MessageBox.Show("Something is wrong");
                }

                // Restore the cursor position
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < dgvProducts.Rows.Count &&
                    GlobalVariables.currentCellIndex < dgvProducts.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvProducts.CurrentCell = dgvProducts.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                        int productid = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
                        string producttitle = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                        string mfr = dgvProducts.CurrentRow.Cells[4].Value.ToString();

                        UpdateQuantity updateQuantity = new UpdateQuantity(productid,producttitle,mfr)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        }; 

                        updateQuantity.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvProducts.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvProducts.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        CommonFunction.DisposeOnClose(updateQuantity);
                        updateQuantity.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row.");
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                GlobalVariables.currentRowIndex = firstVisibleRowIndex;
                GlobalVariables.currentCellIndex = firstVisibleCellIndex;
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
    }
}
