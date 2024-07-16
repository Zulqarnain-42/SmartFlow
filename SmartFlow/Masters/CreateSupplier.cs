using SmartFlow.Common;
using SmartFlow.Common.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CreateSupplier : Form
    {
        public CreateSupplier()
        {
            InitializeComponent();
        }

        public CreateSupplier(int id)
        {
            InitializeComponent();
            label1.Text = id.ToString();
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
            }catch(Exception ex) { throw ex; }
        }

        static string GenerateRandomSupplierCode()
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
                    serialNumber = GenerateRandomSupplierCode();
                }
            }
            return serialNumber = String.Concat("SU", serialNumber); ;
        }

        private void CreateSupplier_Load(object sender, EventArgs e)
        {
            suppliercodetxtbox.Text = GenerateRandomSupplierCode();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateData()
        {
            errorProvider.Clear();
            if (suppliernametxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(suppliernametxtbox, "Please Enter Supplier Name.");
                suppliernametxtbox.Focus();
                return;
            }

            if (selectaccountgrouptxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(selectaccountgrouptxtbox, "Please Select Cash Type");
                selectaccountgrouptxtbox.Focus();
                return;
            }

            if (creditlimittxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(creditlimittxtbox, "Please Enter Credit Limit");
                creditlimittxtbox.Focus();
                return;
            }

            if (paymenttermtxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(paymenttermtxtbox, "Please Enter Payment Term");
                paymenttermtxtbox.Focus();
                return;
            }
        }

        private void AddData()
        {
            errorProvider.Clear();
            if (suppliernametxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(suppliernametxtbox, "Please Enter Supplier Name.");
                suppliernametxtbox.Focus();
                return;
            }

            if(selectaccountgrouptxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(selectaccountgrouptxtbox,"Please Select Account Group");
                selectaccountgrouptxtbox.Focus();
                return;
            }

            if (creditlimittxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(creditlimittxtbox, "Please Enter Credit Limit.");
                creditlimittxtbox.Focus();
                return;
            }

            if (paymenttermtxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(paymenttermtxtbox, "Please Enter Payment Term.");
                paymenttermtxtbox.Focus();
                return;
            }

            string getaccounthead = "SELECT AccountControlID,AccountControlName,AccountHead_ID,AccountControlCode,Alias FROM AccountControlTable " +
                "WHERE AccountControlID = '"+selectaccountgrouptxtbox.Text+"'";
            DataTable accountcontrol = DatabaseAccess.Retrive(getaccounthead);

            if (accountcontrol != null)
            {
                if (accountcontrol.Rows.Count > 0)
                {
                    int accountHeadID = 0;
                    foreach (DataRow row in accountcontrol.Rows)
                    {
                        accountHeadID = Convert.ToInt32(row["AccountHead_ID"]);
                    }
                    string query = "INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID,AccountSubControlName,AccountSubControlCode,CreatedAt," +
                "CreatedDay,Address,Country,Email,MobileNo) VALUES ('" + accountHeadID + "','" + selectaccountgrouptxtbox.Text + "','" + suppliernametxtbox.Text + "'," +
                "'" + Guid.NewGuid() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + addressdetailstxtbox.Text + "','" + countrytxtbox.Text + "'," +
                "'" + emailtxtbox.Text + "','" + mobiletxtbox.Text + "')";

                    bool result = DatabaseAccess.Insert(query);

                    if (result)
                    {
                        string addsupplier = "INSERT INTO SupplierTable (SupplierName,ContactNo,Address,Email,Description,SupplierCode,CreatedAt,CreatedDay,AccountControl_ID,TIN,GSTNO," +
                            "VATNO,Location,State,Country,PostalCode,FAX,Website,CreditLimit,PaymentTerm,DiscountPercentage,ContactPerson,Mobile,EmailContact,IsAllowedSMS,IsAllowedEmail) " +
                            "VALUES ('" + suppliernametxtbox.Text + "','" + mobiletxtbox.Text + "','" + addressdetailstxtbox.Text + "','" + emailtxtbox.Text + "','" + descriptiontxtbox.Text + "'," +
                            "'" + suppliercodetxtbox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + selectaccountgrouptxtbox.Text + "'," +
                            "'" + tintxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "','" + statetxtbox.Text + "','" + countrytxtbox.Text + "','" + postalcodetxtbox.Text + "'," +
                            "'" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "','" + paymenttermtxtbox.Text + "','" + discountpercentagetxtbox.Text + "','" + contactpersontxtbox.Text + "'," +
                            "'" + contcatperosnmobiletxtbox.Text + "','" + contcatpersonemailtxtbox.Text + "','" + sendsmscheckbox.Checked + "','" + sendemailcheckbox.Checked + "')";

                        bool supplier = DatabaseAccess.Insert(addsupplier);
                        if (supplier)
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

        private void CreateSupplier_KeyDown(object sender, KeyEventArgs e)
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
                AccountSelectionForm form = new AccountSelectionForm();
                form.ShowDialog();
            }catch (Exception ex) { throw ex; }
        }

        private void selectaccountgrouptxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if(openForm == null)
                {
                    AccountSelectionForm accountSelection = new AccountSelectionForm();
                    accountSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }catch (Exception ex) { throw ex; }
        }

        private void CreateSupplier_FormClosing(object sender, FormClosingEventArgs e)
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
