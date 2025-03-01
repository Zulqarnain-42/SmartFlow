using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class ListBrands : Form
    {
        private int currentCellIndex = 0;
        private int currentRowIndex = 0;
        public ListBrands()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistunit = new DataTable();
                query = "SELECT BrandId [ID],BrandName [BRAND NAME],Description [DESCRIPTION],BrandCode [CODE] FROM BrandTable";
                dtlistunit = await DatabaseAccess.RetriveAsync(query);

                if (dtlistunit != null && dtlistunit.Rows.Count > 0)
                {
                    dgvListbrand.DataSource = dtlistunit;
                    dgvListbrand.Columns[0].Width = 50;
                    dgvListbrand.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListbrand.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvListbrand.Columns[3].Width = 100;

                }

                if (currentRowIndex >= 0 && currentCellIndex >= 0 && currentRowIndex < dgvListbrand.Rows.Count &&
                    currentCellIndex < dgvListbrand.Rows[currentRowIndex].Cells.Count)
                {
                    dgvListbrand.CurrentCell = dgvListbrand.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void ListBrands_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void ListBrands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListbrand != null && dgvListbrand.Rows.Count > 0)
                {
                    if (dgvListbrand.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedrow = dgvListbrand.SelectedRows[0];
                        brandidlbl.Text = selectedrow.Cells["ID"].Value.ToString();
                        brandcodelbl.Text = selectedrow.Cells["CODE"].Value.ToString();
                        brandnametxtbox.Text = selectedrow.Cells["BRAND NAME"].Value.ToString();
                        descriptiontxtbox.Text = selectedrow.Cells["DESCRIPTION"].Value.ToString();
                        savebtn.Text = "Update";
                    }
                    else
                    {
                        MessageBox.Show("Select Only One Row.");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void dgvListbrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvListbrand.Rows[e.RowIndex];
                    brandidlbl.Text = row.Cells["ID"].Value.ToString();
                    brandcodelbl.Text = row.Cells["CODE"].Value.ToString();
                    brandnametxtbox.Text = row.Cells["BRAND NAME"].Value.ToString();
                    descriptiontxtbox.Text = row.Cells["DESCRIPTION"].Value.ToString();
                }
                savebtn.Text = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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

        private void ResetControl()
        {
            brandnametxtbox.Text = string.Empty;
            descriptiontxtbox.Text = string.Empty;
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

        private void dgvListbrand_Scroll(object sender, ScrollEventArgs e)
        {
            int firstVisibleRowIndex = GetFirstVisibleRowIndex(dgvListbrand);
            int firstVisibleCellIndex = GetFirstVisibleCellIndex(dgvListbrand);
            if (firstVisibleRowIndex >= 0)
            {
                currentRowIndex = firstVisibleRowIndex;
                currentCellIndex = firstVisibleCellIndex;
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (brandnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(brandnametxtbox, "Please Enter Brand Name.");
                    brandnametxtbox.Focus();
                    return;
                }

                string duplicateinfo = await CheckDuplicate();
                if (duplicateinfo != null)
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (savebtn.Text == "Update")
                    {
                        bool result = await UpdateBrand();
                        if (result)
                        {
                            MessageBox.Show("Updated Successfully!");
                            FillGrid();
                            ResetControl();
                        }
                    }
                    else
                    {
                        bool isinserted = await InsertBrand();
                        if (isinserted)
                        {
                            MessageBox.Show("Saved Successfully!");
                            FillGrid();
                            ResetControl();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private async Task<string> CheckDuplicate()
        {
            string query = string.Format("SELECT BrandId,BrandName,Description,BrandCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay,UpdatedDay FROM BrandTable WHERE BrandName = @BrandName");

            var parameters = new Dictionary<string, object>
            {
                { "BrandName", brandnametxtbox.Text }
            };

            DataTable dt = await DatabaseAccess.RetrieveDataAsync(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return $"Duplicate found: Brand Name = {dt.Rows[0]["BrandName"].ToString()}.";
            }
            return null;
        }

        private async Task<bool> InsertBrand()
        {
            string tableName = "BrandTable";
            var columnData = new Dictionary<string, object>()
            {
                { "BrandName", brandnametxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "BrandCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
            return isInserted;
        }

        private async Task<bool> UpdateBrand()
        {
            string tableName = "BrandTable";
            string whereClause = "BrandId = '" + brandidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "BrandName", brandnametxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "BrandCode", Guid.NewGuid().ToString() },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay",DateTime.Now.DayOfWeek.ToString() },
            };

            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            return isInserted;
        }
    }
}
