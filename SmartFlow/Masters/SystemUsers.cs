using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class SystemUsers : Form
    {
        public SystemUsers()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterParent,
            };

            createUser.FormClosed += delegate
            {
                FillGrid("");
            };
            CommonFunction.DisposeOnClose(createUser);
            createUser.ShowDialog();
        }

        private void SystemUsers_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }

        private void FillGrid(string searchValue) 
        {
            try
            {
                string query = string.Empty;
                DataTable dtusers = new DataTable();
                if (string.IsNullOrEmpty(searchValue) && string.IsNullOrWhiteSpace(searchValue)) 
                {
                    query = "SELECT UserID,UserType,UserName,CreatedAt,CreatedDay FROM UserTable";
                }
                else
                {
                    query = "SELECT UserID,UserType,UserName,CreatedAt,CreatedDay FROM UserTable WHERE " +
                        "UserName LIKE '%" + searchValue + "%'";
                }

                dtusers = DatabaseAccess.Retrive(query);
                if (dtusers.Rows.Count > 0)
                {
                    dgvUserLists.DataSource = dtusers;
                    dgvUserLists.Columns[0].Width = 50;
                    dgvUserLists.Columns[1].Width = 100;
                    dgvUserLists.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvUserLists.Columns[3].Width = 100;
                    dgvUserLists.Columns[4].Width = 100;
                }

                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                   GlobalVariables.currentRowIndex < dgvUserLists.Rows.Count &&
                   GlobalVariables.currentCellIndex < dgvUserLists.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvUserLists.CurrentCell = dgvUserLists.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvUserLists!=null && dgvUserLists.Rows.Count > 0)
                {
                    if (dgvUserLists.SelectedRows.Count == 1)
                    {
                        CreateUser createUser = new CreateUser(Convert.ToInt32(dgvUserLists.CurrentRow.Cells[0].Value));
                        createUser.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvUserLists.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvUserLists.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        CommonFunction.DisposeOnClose(createUser);
                        createUser.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvUserLists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvUserLists!=null && dgvUserLists.Rows.Count > 0)
                {
                    CreateUser createUser = new CreateUser(Convert.ToInt32(dgvUserLists.CurrentRow.Cells[0].Value));
                    createUser.FormClosed += delegate
                    {
                        GlobalVariables.currentRowIndex = dgvUserLists.CurrentCell.RowIndex;
                        GlobalVariables.currentCellIndex = dgvUserLists.CurrentCell.ColumnIndex;
                        FillGrid("");
                    };
                    CommonFunction.DisposeOnClose(createUser);
                    createUser.Show();
                }
                else
                {
                    MessageBox.Show("Please Select One Row");
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
