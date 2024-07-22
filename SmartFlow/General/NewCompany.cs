using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.General
{
    public partial class NewCompany : Form
    {
        public NewCompany()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (companynametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(companynametxtbox, "Please Enter Company Name.");
                    companynametxtbox.Focus();
                    return;
                }

                if (mailingnametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(mailingnametxtbox, "Please Enter Mail Name.");
                    mailingnametxtbox.Focus();
                    return;
                }

                if (licensenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(licensenotxtbox, "Please Enter License No.");
                    licensenotxtbox.Focus();
                    return;
                }

                if (vatnotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(vatnotxtbox, "Please Enter Vat No.");
                    vatnotxtbox.Focus();
                    return;
                }

                if (addresstxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(addresstxtbox, "Please Enter Address");
                    addresstxtbox.Focus();
                    return;
                }

                if (statetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(statetxtbox, "Please Enter State");
                    statetxtbox.Focus();
                    return;
                }

                if (countrytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(countrytxtbox, "Please Enter Country");
                    countrytxtbox.Focus();
                    return;
                }

                if (telephonetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(telephonetxtbox, "Please Enter Telephone");
                    telephonetxtbox.Focus();
                    return;
                }

                if (emailtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(emailtxtbox, "Please Enter Email");
                    emailtxtbox.Focus();
                    return;
                }

                if (banknametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(banknametxtbox, "Please Enter Bank Name");
                    banknametxtbox.Focus();
                    return;
                }

                if (accountnotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(accountnotxtbox, "Please Enter Account No");
                    accountnotxtbox.Focus();
                    return;
                }

                if (branchtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(branchtxtbox, "Please Enter Branch");
                    branchtxtbox.Focus();
                    return;
                }

                if (usernametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(usernametxtbox, "Please Enter Username");
                    usernametxtbox.Focus();
                    return;
                }

                if (passwordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(passwordtxtbox, "Please Enter Password.");
                    passwordtxtbox.Focus();
                    return;
                }

                if (confirmpasswordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(confirmpasswordtxtbox, "Please Enter Confirm Password");
                    confirmpasswordtxtbox.Focus();
                    return;
                }

                if (adminemailtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(adminemailtxtbox, "Please Enter Admin Email");
                    adminemailtxtbox.Focus();
                    return;
                }

                if(passwordtxtbox.Text != confirmpasswordtxtbox.Text)
                {
                    errorProvider.SetError(confirmpasswordtxtbox, "Password Did Not Matched!");
                    confirmpasswordtxtbox.Focus();
                    return;
                }

                string query = string.Empty;
                string companyCode = Guid.NewGuid().ToString();
                query = "INSERT INTO CompanyTable (CompnayCode,Name,MailingName,LisenceNo,GSTNO,VATNO,Address1,Address2," +
                    "CountryId,Telephone,FaxNumber,EmailOne,PinCode,BankName,AccNO,BranchCode,CreatedAt,CreatedDay) VALUES " +
                    "('" + companyCode + "','" + companynametxtbox.Text + "','" + mailingnametxtbox.Text + "','" + licensenotxtbox.Text + "'," +
                    "'" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + addresstxtbox.Text + "','" + address2txtbox.Text + "'," +
                    "'" + pincodetxtbox.Text + "','" + countrytxtbox.Text + "','" + telephonetxtbox.Text + "','" + faxnumbertxtbox.Text + "'," +
                    "'" + emailtxtbox.Text + "','" + banknametxtbox.Text + "','" + accountnotxtbox.Text + "','" + branchtxtbox.Text + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')";

                bool result = DatabaseAccess.Insert(query);
                if (result)
                {
                    string hashedPassword = HashPassword(passwordtxtbox.Text);
                    string adduserquery = "INSERT INTO UserTable (Email,UserName,Password,UserCode,CompanyID,CreatedAt,CreatedDay) VALUES " +
                        "('" + adminemailtxtbox.Text + "','" + usernametxtbox.Text + "','" + hashedPassword + "','" + Guid.NewGuid() + "','" + companyCode + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')";
                    bool useradded = DatabaseAccess.Insert(adduserquery);

                    if (useradded)
                    {
                        MessageBox.Show("Company Created Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Something is wrong.");
                    }
                }
                else
                {
                    MessageBox.Show("Something is Wrong.");
                }
            }
            catch (Exception ex) { throw ex; }
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
        private void companynametxtbox_TextChanged(object sender, EventArgs e)
        {
            mailingnametxtbox.Text = companynametxtbox.Text;
        }
        private void NewCompany_FormClosing(object sender, FormClosingEventArgs e)
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
