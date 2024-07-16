using SmartFlow.Common;
using SmartFlow.Common.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CreateCustomer : Form
    {
        public CreateCustomer()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brandsavebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(customernametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(customernametxtbox,"Please Enter Customer Name.");
                    customernametxtbox.Focus();
                    return;
                }

                if(selectaccountgrouptxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectaccountgrouptxtbox, "Please Select Cash Type");
                    selectaccountgrouptxtbox.Focus();
                    return;
                }

                if(mobiletxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(mobiletxtbox,"Please Select Mobile No");
                    mobiletxtbox.Focus();
                    return;
                }

                if(emailtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(emailtxtbox,"Please Enter Email.");
                    emailtxtbox.Focus();
                    return;
                }

                if(creditlimittxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(creditlimittxtbox,"Please Select Credit Limit");
                    creditlimittxtbox.Focus();
                    return;
                }

                if(discountpercentagetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(discountpercentagetxtbox,"Please Enter Discount Percentage");
                    discountpercentagetxtbox.Focus();
                    return;
                }

                string getaccounthead = "SELECT AccountControlID,AccountControlName,AccountHead_ID,AccountControlCode,Alias FROM AccountControlTable " +
                "WHERE AccountControlID = '" + selectaccountgrouptxtbox.Text + "'";
                DataTable accountcontrol = DatabaseAccess.Retrive(getaccounthead);
                if (accountcontrol != null)
                {
                    if(accountcontrol.Rows.Count > 0)
                    {
                        int accountHeadID = 0;
                        foreach (DataRow row in accountcontrol.Rows)
                        {
                            accountHeadID = Convert.ToInt32(row["AccountHead_ID"]);
                        }
                        string query = "INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID,AccountSubControlName,AccountSubControlCode,CreatedAt," +
                "CreatedDay,Address,Country,Email,MobileNo) VALUES ('" + accountHeadID + "','" + selectaccountgrouptxtbox.Text + "','" + customernametxtbox.Text + "'," +
                "'" + Guid.NewGuid() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + addressdetailstxtbox.Text + "','" + countrytxtbox.Text + "'," +
                "'" + emailtxtbox.Text + "','" + mobiletxtbox.Text + "')";

                        bool result = DatabaseAccess.Insert(query);

                        if (result)
                        {
                            if (result)
                            {
                                string addcustomer = "INSERT INTO CustomerTable (CustomerName,ContactNo,Address,Description,CustomerCode,CreateAt,CreatedDay,TIN,GSTNO,VATNO,Location," +
                                    "State,Country,PostalCode,Fax,Website,CreditLimit,PaymentTerm,DiscountPercentage,ContactPerson,ContactPersonMobile,ContactEmail,SalesManid,IsAllowedSms," +
                                    "IsAllowedEmail,Email) VALUES ('" + customernametxtbox.Text + "','" + mobiletxtbox.Text + "','" + addressdetailstxtbox.Text + "','" + descriptiontxtbox.Text + "'," +
                                    "'" + customercodetxtbox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + tintxtbox.Text + "','" + gstnotxtbox.Text + "'," +
                                    "'" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "','" + statetxtbox.Text + "','" + countrytxtbox.Text + "','" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "'," +
                                    "'" + creditlimittxtbox.Text + "','" + paymenttermtxtbox.Text + "','" + discountpercentagetxtbox.Text + "','" + contactpersontxtbox.Text + "','" + contcatperosnmobiletxtbox.Text + "'," +
                                    "'" + contcatpersonemailtxtbox.Text + "','" + selectsalesmantxtbox.Text + "','" + sendsmscheckbox.Checked + "','" + sendemailcheckbox.Checked + "','" + emailtxtbox.Text + "')";

                                bool customer = DatabaseAccess.Insert(addcustomer);
                                if (customer)
                                {
                                    MessageBox.Show("Saved Successfully!");
                                }
                                else
                                {
                                    MessageBox.Show("Something is wrong.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { throw ex; }
        }

        static string GenerateRandomCustomerCode()
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
                    serialNumber = GenerateRandomCustomerCode();
                }
            }
            return serialNumber = String.Concat("CU",serialNumber); ;
        }

        private void CreateCustomer_Load(object sender, EventArgs e)
        {
            customercodetxtbox.Text = GenerateRandomCustomerCode();
        }

        private void CreateCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        private void selectaccountgrouptxtbox_Enter(object sender, EventArgs e)
        {
            try
            {
                AccountSelectionForm account = new AccountSelectionForm();
                account.ShowDialog();
            }
            catch(Exception ex) { throw ex; }
        }

        private void selectaccountgrouptxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if (openForm == null)
                {
                    AccountSelectionForm selectionForm = new AccountSelectionForm();
                    selectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }catch(Exception ex) { throw ex; }
        }

        private void CreateCustomer_FormClosing(object sender, FormClosingEventArgs e)
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
