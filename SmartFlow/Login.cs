using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class Login : Form
    {
        private Dashboard Dashboard;
        public Login()
        {
            InitializeComponent();
        }
        public Login(Dashboard dashboard)
        {
            InitializeComponent();
            this.Dashboard = dashboard;
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string companycode = null;
                errorProvider.Clear();

                if(usernametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(usernametxtbox,"Please Enter Username");
                    usernametxtbox.Focus();
                    return;
                }

                if(passwordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(passwordtxtbox,"Please Enter Password");
                    passwordtxtbox.Focus();
                    return;
                }

/*                foreach(DataRow row in companyData.Rows)
                {
                    companycode = row["CompnayCode"].ToString();
                }*/

                string query = string.Empty;

                query = "SELECT UserID,UserType_ID,FullName,Email,ContactNo,UserName,Password,UserCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay," +
                    "UpdatedDay FROM UserTable WHERE CompanyID = '" + companycode + "' AND UserName = '"+usernametxtbox.Text+"'";

                DataTable userdata = DatabaseAccess.Retrive(query);
                if (userdata != null)
                {
                    if (userdata.Rows.Count > 0)
                    {
                        foreach (DataRow row in userdata.Rows)
                        {
                            string hashedPassword = row["Password"].ToString();
                            bool matched = VerifyPassword(passwordtxtbox.Text,hashedPassword);
                            if (matched)
                            {
                                this.Hide();
                                Dashboard.tsbLogin.Visible = false;
                                Dashboard.tsbLogout.Visible = true;
                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Username and Password is Incorrect!");
                            }
                        }
                    }
                }

            }catch(Exception ex) { throw ex; }
        }

        /*private void companynamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(selectcompanytxtbox.Text.Trim().Length > 0)
                {
                    string getcompany = "SELECT CompanyId,CompnayCode,Name,MailingName,LisenceNo,GSTNO,VATNO,Address1,Address2,PostalCode,CountryId,Telephone,FaxNumber," +
                        "EmailOne,PinCode,TaxType,BankName,AccNO,BranchCode FROM CompanyTable WHERE CompanyId = '" + selectcompanytxtbox.Text + "'";
                    companyData = DatabaseAccess.Retrive(getcompany);
                }
            }catch(Exception ex) { throw ex; }
        }*/
        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Hash the input password and compare with the stored hashed password
            string hashedInputPassword = HashPassword(inputPassword);
            return string.Equals(hashedInputPassword, hashedPassword);
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
