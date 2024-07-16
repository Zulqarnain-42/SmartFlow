using SmartFlow.Common;
using SmartFlow.Common.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Payroll
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        public Employee(int employeid)
        {
            InitializeComponent();
            employeidmain.Text = employeid.ToString();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(savebtn.Text == "Update")
                {
                    UpdateData();
                }
                else
                {
                    AddData();
                }
            }
            catch (Exception ex) { throw ex; }
            
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Employee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        static string GenerateRandomEmployeCode()
        {
            Random random = new Random();
            const string chars = "0123456789";
            char[] serialChars = new char[6];

            for (int i = 0; i < serialChars.Length; i++)
            {
                serialChars[i] = chars[random.Next(chars.Length)];
            }

            string serialNumber = new string(serialChars);
            string query = "SELECT CustomerCode FROM CustomerTable WHERE CustomerCode = '" + serialNumber + "'";
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = GenerateRandomEmployeCode();
                }
            }
            return serialNumber = String.Concat("EM", serialNumber); ;
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            employeeidtxtbox.Text = GenerateRandomEmployeCode();
            string labeldata = employeidmain.Text;
            if (labeldata != "employeid")
            {
                selectaccountgrouptxtbox.Enabled = false;
                FindRecord(Convert.ToInt32(employeidmain.Text));
            }
        }

        private void FindRecord(int id)
        {
            try
            {
                string query = string.Format("SELECT EmployeeID,EmployeeBarcode,Fullname,Email,Department,EmployeeCode,CreatedAt,UpdatedAt,MobileNo,Designation,AddedBy," +
                    "CreatedDay,UpdatedDay,Gender,DOB,Nationality,Education,DOjoining,ContractType,ContractExpiry,Address,City,IsSalesMan,Comission FROM EmployeeTable " +
                    "WHERE EmployeeID = '" + id + "'");
                DataTable dataTable = new DataTable();
                dataTable = DatabaseAccess.Retrive(query);
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        employeeidtxtbox.Text = dataTable.Rows[0]["EmployeeCode"].ToString();
                        employeenametxtbox.Text = dataTable.Rows[0]["Fullname"].ToString();
                        /*dobpicker.Text = dataTable.Rows[0]["DOB"].ToString();*/
                        nationalitytxtbox.Text = dataTable.Rows[0]["Nationality"].ToString();
                        educationtxtbox.Text = dataTable.Rows[0]["Education"].ToString();
                        /*dojpicker.Text = dataTable.Rows[0]["DOjoining"].ToString();*/
                        designationtxtbox.Text = dataTable.Rows[0]["Designation"].ToString();
                        departmenttxtbox.Text = dataTable.Rows[0]["Department"].ToString();
                        contracttypetxtbox.Text = dataTable.Rows[0]["ContractType"].ToString();
                        /*contractexpirypicker.Text = dataTable.Rows[0]["ContractExpiry"].ToString();*/
                        addresstxtbox.Text = dataTable.Rows[0]["Address"].ToString();
                        citytxtbox.Text = dataTable.Rows[0]["City"].ToString();
                        contactnumbertxtbox.Text = dataTable.Rows[0]["MobileNo"].ToString();
                        emailtxtbox.Text = dataTable.Rows[0]["Email"].ToString();
                        employeidmain.Text = dataTable.Rows[0]["EmployeeID"].ToString();
                    }
                    savebtn.Text = "Update";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void UpdateData()
        {
            errorProvider.Clear();

            if (employeenametxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(employeenametxtbox, "Please Enter Employee Name.");
                employeenametxtbox.Focus();
                return;
            }

            if (selectaccountgrouptxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(selectaccountgrouptxtbox, "Please Select Account Group.");
                selectaccountgrouptxtbox.Focus();
                return;
            }

            if (departmenttxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(departmenttxtbox, "Please Enter Department.");
                departmenttxtbox.Focus();
                return;
            }

            if (designationtxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(designationtxtbox, "Please Enter Designation.");
                designationtxtbox.Focus();
                return;
            }

            if (contactnumbertxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(contactnumbertxtbox, "Please Enter Contact Number.");
                contactnumbertxtbox.Focus();
                return;
            }

            string query = string.Format("UPDATE EmployeeTable SET Fullname = '" + employeenametxtbox.Text.Trim() + "',Email = '" + emailtxtbox.Text.Trim() + "'," +
                        "Department = '" + departmenttxtbox.Text + "',EmployeeCode = '" + employeeidtxtbox.Text.Trim() + "',UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                        "MobileNo = '" + contactnumbertxtbox.Text.Trim() + "',Designation = '" + designationtxtbox.Text.Trim() + "',UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                        "DOB = '" + null + "',Nationality = '" + nationalitytxtbox.Text.Trim() + "'," +
                        "Education = '" + educationtxtbox.Text.Trim() + "',DOjoining = '" + null + "',ContractType = '" + contracttypetxtbox.Text.Trim() + "'," +
                        "ContractExpiry = '" + null + "',Address = '" + addresstxtbox.Text.Trim() + "',City = '" + citytxtbox.Text.Trim() + "'," +
                        " WHERE EmployeeID = '" + employeidmain.Text + "'");

            bool result = DatabaseAccess.Insert(query);
            if (result)
            {
                MessageBox.Show("Saved Successfully!");
            }
            else
            {
                MessageBox.Show("Something is Wrong.");
            }
        }

        private void AddData()
        {
            errorProvider.Clear();

            if(employeenametxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(employeenametxtbox,"Please Enter Employee Name.");
                employeenametxtbox.Focus();
                return;
            }

            if(selectaccountgrouptxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(selectaccountgrouptxtbox,"Please Select Account Group.");
                selectaccountgrouptxtbox.Focus();
                return;
            }

            if(departmenttxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(departmenttxtbox,"Please Enter Department.");
                departmenttxtbox.Focus();
                return;
            }

            if(designationtxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(designationtxtbox,"Please Enter Designation.");
                designationtxtbox.Focus();
                return;
            }

            if(contactnumbertxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(contactnumbertxtbox,"Please Enter Contact Number.");
                contactnumbertxtbox.Focus();
                return;
            }

            string getaccounthead = "SELECT AccountControlID,AccountControlName,AccountHead_ID,AccountControlCode,Alias FROM AccountControlTable " +
                "WHERE AccountControlID = '" + selectaccountgrouptxtbox.Text + "'";
            DataTable accountcontrol = DatabaseAccess.Retrive(getaccounthead);

            if (accountcontrol != null )
            {
                if (accountcontrol.Rows.Count > 0)
                {
                    int accountHeadID = 0;
                    foreach (DataRow row in accountcontrol.Rows)
                    {
                        accountHeadID = Convert.ToInt32(row["AccountHead_ID"]);
                    }

                    string addcontrolquery = "INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID,AccountSubControlName,AccountSubControlCode,CreatedAt," +
                "CreatedDay,Address,Country,Email,MobileNo) VALUES ('" + accountHeadID + "','" + selectaccountgrouptxtbox.Text + "','" + employeenametxtbox.Text + "'," +
                "'" + Guid.NewGuid() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + addresstxtbox.Text + "','" + countrytxtbox.Text + "'," +
                "'" + emailtxtbox.Text + "','" + contactnumbertxtbox.Text + "')";

                    bool accountsubcontrol = DatabaseAccess.Insert(addcontrolquery);

                    if (accountsubcontrol)
                    {
                        string query = string.Format("INSERT INTO EmployeeTable (Fullname,Email,Department,EmployeeCode,CreatedAt,MobileNo,Designation,CreatedDay,DOB," +
                    "Nationality,Education,DOjoining,ContractType,ContractExpiry,Address,City,Country,AccountGroup_ID) VALUES ('" + employeenametxtbox.Text.Trim() + "'," +
                    "'" + emailtxtbox.Text.Trim() + "','" + departmenttxtbox.Text + "','" + employeeidtxtbox.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                    "'" + contactnumbertxtbox.Text.Trim() + "','" + designationtxtbox.Text.Trim() + "','" + DateTime.Now.DayOfWeek + "','" + null + "'," +
                    "'" + nationalitytxtbox.Text.Trim() + "','" + educationtxtbox.Text.Trim() + "','" + null + "','" + contracttypetxtbox.Text.Trim() + "'," +
                    "'" + null + "','" + addresstxtbox.Text.Trim() + "','" + citytxtbox.Text.Trim() + "'," +
                    "'" + countrytxtbox.Text + "','" + selectaccountgrouptxtbox.Text + "')");

                        bool result = DatabaseAccess.Insert(query);
                        if (result)
                        {
                            MessageBox.Show("Saved Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Something is Wrong.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something wrong with accounts");
                    }
                }
            }
        }

        private void selectaccountgrouptxtbox_Enter(object sender, EventArgs e)
        {
            try
            {
                AccountSelectionForm accountSelectionForm = new AccountSelectionForm();
                accountSelectionForm.ShowDialog();
            }
            catch (Exception ex) { throw ex; }
        }

        private void selectaccountgrouptxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if (openForm == null)
                {
                    AccountSelectionForm accountSelection = new AccountSelectionForm();
                    accountSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AreAnyTextBoxesFilled())
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                      "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                }
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true; // At least one TextBox is filled
                }
            }
            return false; // No TextBox is filled
        }
    }
}
