using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class ListSaleType : Form
    {
        public ListSaleType()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            SaleType saleType = new SaleType
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterParent,
            };
            CommonFunction.DisposeOnClose(saleType);
            saleType.ShowDialog();
        }

        private void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistsaletype = new DataTable();
                query = "SELECT SaleTypeID,Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable FROM SaleTypeTable";
                dtlistsaletype = DatabaseAccess.Retrive(query);
                if(dtlistsaletype != null && dtlistsaletype.Rows.Count > 0)
                {
                    dgvlistsaletype.DataSource = dtlistsaletype;
                    dgvlistsaletype.Columns[0].Width = 50;
                    dgvlistsaletype.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistsaletype.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistsaletype.Columns[3].Width = 150;
                    dgvlistsaletype.Columns[4].Width = 150;
                    dgvlistsaletype.Columns[5].Width = 100;
                    dgvlistsaletype.Columns[6].Width = 100;
                }

                // Restore the cursor position
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < dgvlistsaletype.Rows.Count &&
                    GlobalVariables.currentCellIndex < dgvlistsaletype.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvlistsaletype.CurrentCell = dgvlistsaletype.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ListSaleType_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dgvlistsaletype_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvlistsaletype != null && dgvlistsaletype.Rows.Count > 0)
                {
                    if(dgvlistsaletype.SelectedRows.Count == 1)
                    {
                        SaleType saleType = new SaleType(Convert.ToInt32(dgvlistsaletype.CurrentRow.Cells[0].Value));
                        saleType.FormClosed += delegate
                        {
                            GlobalVariables.currentCellIndex = dgvlistsaletype.CurrentCell.ColumnIndex;
                            GlobalVariables.currentRowIndex = dgvlistsaletype.CurrentCell.RowIndex;
                            FillGrid();
                        };
                        CommonFunction.DisposeOnClose(saleType);
                        saleType.Show();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvlistsaletype != null && dgvlistsaletype.Rows.Count > 0)
                {
                    if(dgvlistsaletype.SelectedRows.Count == 1)
                    {
                        SaleType saleType = new SaleType(Convert.ToInt32(dgvlistsaletype.CurrentRow.Cells[0].Value));
                        saleType.FormClosed += delegate
                        {
                            GlobalVariables.currentCellIndex = dgvlistsaletype.CurrentCell.ColumnIndex;
                            GlobalVariables.currentRowIndex = dgvlistsaletype.CurrentCell.RowIndex;
                            FillGrid();
                        };
                        CommonFunction.DisposeOnClose(saleType);
                        saleType.Show();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
