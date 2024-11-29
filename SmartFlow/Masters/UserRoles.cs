using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class UserRoles : Form
    {
        public UserRoles()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CreateRole createRole = new CreateRole();
            createRole.FormClosed += delegate
            {
                FillGrid("");
            };
            CommonFunction.DisposeOnClose(createRole);
            createRole.Show();
        }

        private void UserRoles_Load(object sender, EventArgs e)
        {
            FillGrid("");
        }

        private void FillGrid(string searchValue)
        {
            try
            {
                string query = string.Empty;
                DataTable dataTableRoles = new DataTable();
                if(string.IsNullOrEmpty(searchValue) && string.IsNullOrWhiteSpace(searchValue))
                {
                    query = "SELECT RoleId [Id],RoleName [Name],RoleCode [Code],CreatedAt [Creation],CreatedDay [Day] FROM RoleTable";
                }
                else
                {
                    query = "SELECT RoleId [Id],RoleName [Name],RoleCode [Code],CreatedAt [Creation],CreatedDay [Day] FROM RoleTable " +
                        "WHERE RoleName LIKE '%" + searchValue + "%'";
                }

                dataTableRoles = DatabaseAccess.Retrive(query);
                if(dataTableRoles.Rows.Count > 0)
                {
                    dgvRoleslist.DataSource = dataTableRoles;
                    dgvRoleslist.Columns[0].Width = 50;
                    dgvRoleslist.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvRoleslist.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvRoleslist.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvRoleslist.Columns[4].Width = 100;
                }

                if (GlobalVariables.currentRowIndex >= 0 && GlobalVariables.currentCellIndex >= 0 &&
                   GlobalVariables.currentRowIndex < dgvRoleslist.Rows.Count &&
                   GlobalVariables.currentCellIndex < dgvRoleslist.Rows[GlobalVariables.currentRowIndex].Cells.Count)
                {
                    dgvRoleslist.CurrentCell = dgvRoleslist.Rows[GlobalVariables.currentRowIndex].Cells[GlobalVariables.currentCellIndex];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvRoleslist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRoleslist != null && dgvRoleslist.Rows.Count > 0)
                {
                    if(dgvRoleslist.SelectedRows.Count == 1)
                    {
                        CreateRole createRole = new CreateRole(Convert.ToInt32(dgvRoleslist.CurrentRow.Cells[0].Value));
                        createRole.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvRoleslist.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvRoleslist.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        CommonFunction.DisposeOnClose(createRole);
                        createRole.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record.");
                    }
                }
                
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoleslist != null && dgvRoleslist.Rows.Count > 0)
                {
                    if(dgvRoleslist.SelectedRows.Count == 1)
                    {
                        CreateRole createRole = new CreateRole(Convert.ToInt32(dgvRoleslist.CurrentRow.Cells[0].Value));
                        createRole.FormClosed += delegate
                        {
                            GlobalVariables.currentRowIndex = dgvRoleslist.CurrentCell.RowIndex;
                            GlobalVariables.currentCellIndex = dgvRoleslist.CurrentCell.ColumnIndex;
                            FillGrid("");
                        };
                        CommonFunction.DisposeOnClose(createRole);
                        createRole.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record.");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
