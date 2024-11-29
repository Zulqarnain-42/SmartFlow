using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CreateRole : Form
    {
        public CreateRole()
        {
            InitializeComponent();
        }

        public CreateRole(int roleid)
        {
            InitializeComponent();
            roleidlbl.Text = roleid.ToString();
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
                if(rolenametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(rolenametxtbox,"Please Enter Role Name.");
                    rolenametxtbox.Focus();
                    return;
                }

                string duplicateInfo = CheckDuplicate();
                if (duplicateInfo != null) 
                {
                    MessageBox.Show(duplicateInfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if(savebtn.Text == "Update")
                {
                    bool IsUpdated = UpdateRole();
                    if (IsUpdated) 
                    {
                        MessageBox.Show("Updated Successfully");
                        ResetControl();
                    }
                }
                else
                {
                    bool IsInserted = InsertRole();
                    if (IsInserted) 
                    {
                        MessageBox.Show("Saved Successfully!");
                        ResetControl();
                    }
                }
                
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CreateRole_Load(object sender, EventArgs e)
        {
            string labeldata = roleidlbl.Text;
            if (labeldata != "roleidlbl")
            {
                FindRecord(Convert.ToInt32(roleidlbl.Text));
            }
        }
        private void ResetControl()
        {
            rolenametxtbox.Text = string.Empty;
        }
        private void FindRecord(int id)
        {
            try
            {
                string query = string.Format("SELECT RoleId,RoleName,RoleCode,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,CompanyId,UserId " +
                    "FROM RoleTable WHERE RoleId = @RoleId");

                var parameters = new Dictionary<string, object>
                {
                    {"RoleId", id} 
                };

                DataTable dtRoledata = DatabaseAccess.RetrieveData(query, parameters);

                if (dtRoledata != null && dtRoledata.Rows.Count > 0)
                {
                    roleidlbl.Text = dtRoledata.Rows[0]["RoleId"].ToString();
                    rolenametxtbox.Text = dtRoledata.Rows[0]["RoleName"].ToString();
                }
                savebtn.Text = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool InsertRole()
        {
            string TableName = "RoleTable";
            var columnData = new Dictionary<string, object>
            {
                { "RoleName", rolenametxtbox.Text },
                { "RoleCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString() },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() }
            };

            bool InInserted = DatabaseAccess.ExecuteQuery(TableName,"INSERT",columnData);
            return InInserted;
        }

        private bool UpdateRole()
        {
            string tableName = "RoleTable";
            string whereClause = "RoleId = '"+ roleidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "RoleName", rolenametxtbox.Text }
            };

            bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            return isUpdated;
        }

        private string CheckDuplicate()
        {
            string query = string.Format(@"SELECT RoleId,RoleName,RoleCode,CreatedAt,CreatedDay FROM RoleTable WHERE RoleName LIKE @RoleName");

            var parameters = new Dictionary<string, object>
            {
                {"RoleName", rolenametxtbox.Text }
            };

            DataTable dt = DatabaseAccess.RetrieveData(query,parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return $"Duplicate found: Role Name = {dt.Rows[0]["RoleName"].ToString()}.";
            }

            return null;
        }
    }
}
