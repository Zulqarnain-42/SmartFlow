using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        public CreateUser(int userid)
        {
            InitializeComponent();
            systemuseridlbl.Text = userid.ToString();
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string hashedPassword = null;
                errorProvider.Clear();
                if (usernametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(usernametxtbox,"Please Enter Username.");
                    usernametxtbox.Focus();
                    return;
                }

                if(passwordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(passwordtxtbox,"Please Enter Password.");
                    passwordtxtbox.Focus();
                    return;
                }

                if(confirmpasswordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(confirmpasswordtxtbox,"Please Confirm Your Password.");
                    confirmpasswordtxtbox.Focus();
                    return;
                }

                if(passwordtxtbox.Text != confirmpasswordtxtbox.Text)
                {
                    errorProvider.SetError(confirmpasswordtxtbox,"Password Not Matched.");
                    confirmpasswordtxtbox.Focus();
                    return;
                }

                string duplicateinfo = CheckDuplicate();
                if (duplicateinfo != null) 
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                hashedPassword = CommonFunction.HashPassword(passwordtxtbox.Text);
                if (savebtn.Text == "Update")
                {
                    bool isUpdated = UpdateSystemUser(hashedPassword);
                    if (isUpdated) 
                    {
                        MessageBox.Show("Updated Successfully!");
                        ResetControl();
                    }
                }
                else
                {
                    
                    bool isInserted = InsertSystemUser(hashedPassword);
                    if (isInserted) 
                    {
                        MessageBox.Show("Saved Successfully!");
                        ResetControl();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetControl()
        {
            usertypecombo.SelectedIndex = 0;
            usernametxtbox.Text = string.Empty;
            passwordtxtbox.Text = string.Empty;
            confirmpasswordtxtbox.Text = string.Empty;
            employeeCombo.SelectedIndex = 0;
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            CommonFunction.FillUserType(usertypecombo);
            CommonFunction.FillEmployeeData(employeeCombo);
            if (systemuseridlbl.Text != "systemuseridlbl")
            {
                FindRecord(Convert.ToInt32(systemuseridlbl.Text));
            }
        }

        private bool InsertSystemUser(string password)
        {
            string tableName = "UserTable";
            int usertypeid = Convert.ToInt32(usertypecombo.SelectedValue);
            int employeeid = Convert.ToInt32(employeeCombo.SelectedValue);

            var columnData = new Dictionary<string, object>
            {
                { "UserType", usertypeid },
                { "UserName", usernametxtbox.Text },
                { "Password", password },
                { "UserCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString() },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "EmployeeId", employeeid },
            };

            bool IsInserted = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);
            return IsInserted;
        }

        private bool UpdateSystemUser(string password)
        {
            string tableName = "UserTable";
            string whereClause = "UserID = '" + systemuseridlbl.Text + "'";
            int usertypeid = Convert.ToInt32(usertypecombo.SelectedValue);
            int employeeid = Convert.ToInt32(employeeCombo.SelectedValue);

            var columnData = new Dictionary<string, object>
            {
                { "UserType", usertypeid },
                { "UserName", usernametxtbox.Text },
                { "Password", password },
                { "UserCode", Guid.NewGuid().ToString() },
                { "UpdatedAt", DateTime.Now.ToString() },
                { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "EmployeeId", employeeid },
            };

            bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            return isUpdated;
        }

        private string CheckDuplicate()
        {
            string query = @"SELECT UserID,UserType,UserName,Password,UserCode,CompanyID,CreatedAt,
                UpdatedAt,AddedBy,CreatedDay,UpdatedDay,EmployeeId FROM UserTable WHERE UserName LIKE @UserName";

            var parameters = new Dictionary<string, object>
            {
                { "UserName", usernametxtbox.Text},
            };

            DataTable dt = DatabaseAccess.RetrieveData(query, parameters);
            if(dt!=null && dt.Rows.Count > 0)
            {
                return $"Duplicate found: Username = {dt.Rows[0]["UserName"].ToString()}.";
            }
            return null;
        }

        private void FindRecord(int id)
        {
            try
            {
                string query = @"SELECT UserID,UserType,UserName,Password,UserCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay,
                    UpdatedDay,EmployeeId FROM UserTable WHERE UserID = @UserID";

                var parameter = new Dictionary<string, object>
                {
                    { "UserID", id }
                };

                DataTable dtsystemUser = DatabaseAccess.RetrieveData(query, parameter);
                if (dtsystemUser != null && dtsystemUser.Rows.Count > 0) 
                {
                    usernametxtbox.Text = dtsystemUser.Rows[0]["UserName"].ToString();
                    usertypecombo.SelectedValue = Convert.ToInt32(dtsystemUser.Rows[0]["UserType"]);
                    employeeCombo.SelectedValue = Convert.ToInt32(dtsystemUser.Rows[0]["EmployeeId"]);
                }
                savebtn.Text = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
