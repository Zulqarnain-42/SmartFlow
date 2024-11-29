using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class ListPurchaseType : Form
    {
        public ListPurchaseType()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            PurchaseType purchaseType = new PurchaseType
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterParent,
            };
            CommonFunction.DisposeOnClose(purchaseType);
            purchaseType.ShowDialog();
        }

        private void ListPurchaseType_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistpurchasetype = new DataTable();
                query = "SELECT PurchaseTpeID [ID],Name [NAME],Code [CODE],CreatedAt [CREATION],CreatedDay [DAY],IsActive [ACTIVE],IsTaxable [TAXABLE] FROM PurchaseTypeTable";
                dtlistpurchasetype = DatabaseAccess.Retrive(query);
                if(dtlistpurchasetype!=null&& dtlistpurchasetype.Rows.Count > 0)
                {
                    dgvlistpurchasetype.DataSource = dtlistpurchasetype;
                    dgvlistpurchasetype.Columns[0].Width = 50;
                    dgvlistpurchasetype.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistpurchasetype.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistpurchasetype.Columns[3].Width = 100;
                    dgvlistpurchasetype.Columns[4].Width = 100;
                    dgvlistpurchasetype.Columns[5].Width = 100;
                    dgvlistpurchasetype.Columns[6].Width = 100;
                }

                // Restore the cursor position
                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                    GlobalVariables.currentRowIndex < dgvlistpurchasetype.Rows.Count &&
                    GlobalVariables.currentCellIndex < dgvlistpurchasetype.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvlistpurchasetype.CurrentCell = dgvlistpurchasetype.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvlistpurchasetype_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvlistpurchasetype != null && dgvlistpurchasetype.Rows.Count > 0)
                {
                    if(dgvlistpurchasetype.SelectedRows.Count == 1)
                    {
                        PurchaseType purchaseType = new PurchaseType(Convert.ToInt32(dgvlistpurchasetype.CurrentRow.Cells[0].Value));
                        purchaseType.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvlistpurchasetype.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvlistpurchasetype.CurrentCell.ColumnIndex;
                            FillGrid();
                        };
                        CommonFunction.DisposeOnClose(purchaseType);
                        purchaseType.Show();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvlistpurchasetype != null && dgvlistpurchasetype.Rows.Count > 0)
                {
                    if(dgvlistpurchasetype.SelectedRows.Count == 1)
                    {
                        PurchaseType purchaseType= new PurchaseType(Convert.ToInt32(dgvlistpurchasetype.CurrentRow.Cells[0].Value));
                        purchaseType.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvlistpurchasetype.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvlistpurchasetype.CurrentCell.ColumnIndex;
                            FillGrid();
                        };
                        CommonFunction.DisposeOnClose(purchaseType);
                        purchaseType.Show();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
