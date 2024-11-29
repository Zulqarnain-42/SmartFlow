using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ZXing;

namespace SmartFlow.Masters
{
    public partial class CreateRight : Form
    {
        public CreateRight()
        {
            InitializeComponent();
        }

        public CreateRight(int id)
        {
            InitializeComponent();
            rightsidlbl.Text = id.ToString();
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(rightnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(rightnametxtbox,"Please Enter Right Name.");
                    rightnametxtbox.Focus();
                    return;
                }

                if (dgvSelectedRoles.Rows.Count == 0)
                {
                    errorProvider.SetError(roleselectiontxtbox,"Please Select Roles.");
                    roleselectiontxtbox.Focus();
                    return;
                }

                if(savebtn.Text == "Update")
                {
                    bool isUpdated = UpdateUserRight();
                    if (isUpdated) 
                    {
                        MessageBox.Show("Updated Successfully!");
                        ResetControl();
                    }
                }
                else
                {
                    bool isInserted = InsertUserRight();
                    if (isInserted) 
                    {
                        MessageBox.Show("Saved Successfully!");
                        ResetControl();
                        
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetControl()
        {
            rightnametxtbox.Text = string.Empty;
            dgvSelectedRoles.Rows.Clear();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(roleselectiontxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(roleselectiontxtbox,"Please Select Role");
                    roleselectiontxtbox.Focus();
                    return;
                }

                int roleid = Convert.ToInt32(roleidlbl.Text);
                string roleName = roleselectiontxtbox.Text.Trim();

                bool productExists = false;

                foreach (DataGridViewRow row in dgvSelectedRoles.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["roleidcolumn"].Value != null && row.Cells["roleidcolumn"].Value.ToString() == roleidlbl.Text.ToString())
                        {
                            MessageBox.Show("Role Already Exist");
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvSelectedRoles.Rows.Add(roleid, roleName);
                }

                roleidlbl.Text = string.Empty;
                roleselectiontxtbox.Text = string.Empty;
                roleselectiontxtbox.Focus();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void roleselectiontxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(RoleSelectionForm));
            if(openForm == null)
            {
                RoleSelectionForm roleSelectionForm = new RoleSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                
                roleSelectionForm.FormClosed += delegate
                {
                    UpdateRoleInfo();
                };
                CommonFunction.DisposeOnClose(roleSelectionForm);
                roleSelectionForm.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void roleselectiontxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(RoleSelectionForm));
                if (openForm == null)
                {
                    RoleSelectionForm roleSelectionForm = new RoleSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    roleSelectionForm.FormClosed += delegate
                    {
                        UpdateRoleInfo();
                    };

                    CommonFunction.DisposeOnClose(roleSelectionForm);
                    roleSelectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private void UpdateRoleInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.rolenameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.rolenameglobal) && GlobalVariables.roleidglobal > 0)
            {
                roleidlbl.Text = GlobalVariables.roleidglobal.ToString();
                roleselectiontxtbox.Text = GlobalVariables.rolenameglobal.ToString();
            }
        }

        private void CreateRights_Load(object sender, EventArgs e)
        {
            string labeldata = rightsidlbl.Text;
            if (labeldata != "rightsidlbl")
            {
                FindRecord(Convert.ToInt32(rightsidlbl.Text));
            }
        }
        private void FindRecord(int id)
        {
            try
            {
                string query = @"SELECT RightId, RightName, RightCode, CreatedAt, CreatedDay, UpdatedAt, UpdatedDay, CompanyId, UserId 
                 FROM RightsTable WHERE RightId = @RightId";

                // Pass parameters properly to RetrieveData method
                var parameter = new Dictionary<string, object>
                {
                    { "@RightId", id } // Ensure parameter name matches the query
                };

                // Retrieve data with parameters
                DataTable dtRightdata = DatabaseAccess.RetrieveData(query, parameter);

                if (dtRightdata != null && dtRightdata.Rows.Count > 0)
                {
                    rightsidlbl.Text = dtRightdata.Rows[0]["RightId"].ToString();
                    rightnametxtbox.Text = dtRightdata.Rows[0]["RightName"].ToString();

                    string subquery = @"SELECT RoleRightTable.RoleRightId [RoleRightId], RoleRightTable.RoleId [roleidcolumn], RoleRightTable.RightId [RightId], RoleTable.RoleName [rolenamecolumn]
                        FROM RoleRightTable 
                        INNER JOIN RoleTable ON RoleTable.RoleId = RoleRightTable.RoleId 
                        WHERE RoleRightTable.RightId = @RightId";

                    var secondparameter = new Dictionary<string, object>
                    {
                        { "@RightId", id } // Ensure parameter name matches the subquery
                    };

                    // Retrieve data for roles
                    DataTable dtRoleData = DatabaseAccess.RetrieveData(subquery, secondparameter);

                    if (dtRoleData != null && dtRoleData.Rows.Count > 0)
                    {
                        foreach(DataRow dtrow in dtRoleData.Rows)
                        {
                            int rowIndex = dgvSelectedRoles.Rows.Add();
                            DataGridViewRow gridrow = dgvSelectedRoles.Rows[rowIndex];

                            gridrow.Cells[0].Value = dtrow["roleidcolumn"];
                            gridrow.Cells[1].Value = dtrow["rolenamecolumn"];
                        }
                    }
                }
                savebtn.Text = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool InsertUserRight()
        {
            string tableName = "RightsTable";

            var columnData = new Dictionary<string, object>
            {
                { "RightName", rightnametxtbox.Text },
                { "RightCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString() },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
            };

            int resultid = DatabaseAccess.InsertDataId(tableName, columnData);

            if (resultid > 0)
            {
                string subtableName = "RoleRightTable";
                foreach (DataGridViewRow row in dgvSelectedRoles.Rows)
                {
                    if (row.IsNewRow) continue;

                    int roleid = Convert.ToInt32(row.Cells["roleidcolumn"].Value);

                    var detailData = new Dictionary<string, object>
                    {
                        { "RoleId", roleid },
                        { "RightId", resultid },
                    };

                    bool subresult = DatabaseAccess.ExecuteQuery(subtableName,"INSERT",detailData);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdateUserRight()
        {
            string tableName = "RightsTable";
            string whereClause = "RightId = '" + rightsidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "RightName", rightnametxtbox.Text },
                { "UpdatedAt", DateTime.Now.ToString() },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() }
            };

            bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            if (isUpdated) 
            {
                string subTableName = "RoleRightTable";
                string delWhereClause = "RightId = @RightId";

                var parameter = new Dictionary<string, object>
                {
                    { "RightId", rightsidlbl.Text }
                };

                bool isDeleted = DatabaseAccess.ExecuteQuery(subTableName, "DELETE", parameter, whereClause);
                if (isDeleted) 
                {
                    string subtableName = "RoleRightTable";
                    foreach (DataGridViewRow row in dgvSelectedRoles.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int roleid = Convert.ToInt32(row.Cells["roleidcolumn"].Value);

                        var detailData = new Dictionary<string, object>
                        {
                            { "RoleId", roleid },
                            { "RightId", rightsidlbl.Text },
                        };

                        bool subresult = DatabaseAccess.ExecuteQuery(subtableName, "INSERT", detailData);
                    }  
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
