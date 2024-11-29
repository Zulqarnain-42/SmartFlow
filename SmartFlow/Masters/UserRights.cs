using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class UserRights : Form
    {
        public UserRights()
        {
            InitializeComponent();
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            CreateRight createRights = new CreateRight
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen,
            };
            
            createRights.FormClosed += delegate
            {
                FillGrid("");
            };
            CommonFunction.DisposeOnClose(createRights);
            createRights.ShowDialog();
        }
        private void UserRights_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }
        private void FillGrid(string searchValue)
        {
            try
            {
                string query = string.Empty;
                DataTable dtrights = new DataTable();
                if (string.IsNullOrEmpty(searchValue) && string.IsNullOrWhiteSpace(searchValue))
                {
                    query = "SELECT RightId [Id],RightName [Name],RightCode [Code],CreatedAt [Created],CreatedDay [Day] FROM RightsTable";
                }
                else
                {
                    query = "SELECT RightId [Id],RightName [Name],RightCode [Code],CreatedAt [Created],CreatedDay [Day] FROM RightsTable " +
                        "WHERE RightName LIKE '%" + searchValue + "%'";
                }

                dtrights = DatabaseAccess.Retrive(query);
                if (dtrights.Rows.Count > 0) 
                {
                    dgvUserRights.DataSource = dtrights;
                    dgvUserRights.Columns[0].Width = 50;
                    dgvUserRights.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvUserRights.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvUserRights.Columns[3].Width = 100;
                    dgvUserRights.Columns[4].Width = 100;
                }

                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                   GlobalVariables.currentRowIndex < dgvUserRights.Rows.Count &&
                   GlobalVariables.currentCellIndex < dgvUserRights.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvUserRights.CurrentCell = dgvUserRights.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgvUserRights_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvUserRights != null && dgvUserRights.Rows.Count > 0)
                {
                    if (dgvUserRights.SelectedRows.Count == 1)
                    {
                        CreateRight createRights = new CreateRight(Convert.ToInt32(dgvUserRights.CurrentRow.Cells[0].Value));
                        createRights.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvUserRights.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvUserRights.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        CommonFunction.DisposeOnClose(createRights);
                        createRights.Show();
                    }
                    else
                    {
                        MessageBox.Show("Select One Row Only.");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvUserRights != null && dgvUserRights.Rows.Count > 0)
                {
                    if(dgvUserRights.SelectedRows.Count == 1)
                    {
                        CreateRight createRights = new CreateRight(Convert.ToInt32(dgvUserRights.CurrentRow.Cells[0].Value));
                        createRights.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvUserRights.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvUserRights.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        CommonFunction.DisposeOnClose(createRights);
                        createRights.Show();
                    }
                    else
                    {
                        MessageBox.Show("Select One Row Only");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
