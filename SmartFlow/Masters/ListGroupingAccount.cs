using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class ListGroupingAccount : Form
    {
        private int currentRowIndex = 0;
        private int currentCellIndex = 0;
        public ListGroupingAccount()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            GroupingAccount account = new GroupingAccount
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterParent,
            };
            account.FormClosed += delegate
            {
                FillGrid();
            };
            CommonFunction.DisposeOnClose(account);
            account.ShowDialog();
        }

        private void ListGroupingAccount_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private async void FillGrid()
        {
            try
            {
                string query = string.Empty;
                DataTable dtlistgroupingaccount = new DataTable();
                query = "SELECT AccountGroupid [ID],GroupName [GROUP NAME],Description [DESCRIPTION],CreatedAt [CREATION],CreatedDay [DAY] FROM AccountGroupingTable";
                dtlistgroupingaccount = await DatabaseAccess.RetriveAsync(query);
                if(dtlistgroupingaccount!=null && dtlistgroupingaccount.Rows.Count > 0)
                {
                    dgvlistgroupingaccount.DataSource = dtlistgroupingaccount;
                    dgvlistgroupingaccount.Columns[0].Width = 50;
                    dgvlistgroupingaccount.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistgroupingaccount.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvlistgroupingaccount.Columns[3].Width = 100;
                    dgvlistgroupingaccount.Columns[4].Width = 100;
                }

                // Restore the cursor position
                if (currentRowIndex >= 0 && currentCellIndex >= 0 &&
                    currentRowIndex < dgvlistgroupingaccount.Rows.Count &&
                    currentCellIndex < dgvlistgroupingaccount.Rows[currentRowIndex].Cells.Count)
                {
                    dgvlistgroupingaccount.CurrentCell = dgvlistgroupingaccount.Rows[currentRowIndex].Cells[currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvlistgroupingaccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvlistgroupingaccount != null && dgvlistgroupingaccount.Rows.Count > 0)
                {
                    if(dgvlistgroupingaccount.SelectedRows.Count == 1)
                    {
                        GroupingAccount groupingAccount = new GroupingAccount(Convert.ToInt32(dgvlistgroupingaccount.CurrentRow.Cells[0].Value)) 
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        groupingAccount.FormClosed += delegate
                        {
                            if(dgvlistgroupingaccount.CurrentCell.RowIndex > 0 && dgvlistgroupingaccount.CurrentCell.ColumnIndex > 0)
                            {
                                currentRowIndex = dgvlistgroupingaccount.CurrentCell.RowIndex;
                                currentCellIndex = dgvlistgroupingaccount.CurrentCell.ColumnIndex;
                            }
                            FillGrid();
                        };
                        CommonFunction.DisposeOnClose(groupingAccount);
                        groupingAccount.ShowDialog();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvlistgroupingaccount != null && dgvlistgroupingaccount.Rows.Count > 0)
                {
                    if(dgvlistgroupingaccount.SelectedRows.Count == 1)
                    {
                        GroupingAccount groupingAccount = new GroupingAccount(Convert.ToInt32(dgvlistgroupingaccount.CurrentRow.Cells[0].Value)) 
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        groupingAccount.FormClosed += delegate
                        {
                            if(dgvlistgroupingaccount.CurrentCell.RowIndex > 0 && dgvlistgroupingaccount.CurrentCell.ColumnIndex > 0)
                            {
                                currentRowIndex = dgvlistgroupingaccount.CurrentCell.RowIndex;
                                currentCellIndex = dgvlistgroupingaccount.CurrentCell.ColumnIndex;
                            }
                            FillGrid();
                        };
                        CommonFunction.DisposeOnClose(groupingAccount);
                        groupingAccount.ShowDialog();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
