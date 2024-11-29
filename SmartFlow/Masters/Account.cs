using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }
        public Account(int id)
        {
            InitializeComponent();
            accountidlbl.Text = id.ToString();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (nametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(nametxtbox, "Please Enter Name");
                    nametxtbox.Focus();
                    return;
                }

                if (selectaccountgrouptxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectaccountgrouptxtbox, "Please Select Account Group.");
                    selectaccountgrouptxtbox.Focus();
                    return;
                }

                if(emailtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(emailtxtbox,"Please Enter Email.");
                    emailtxtbox.Focus();
                    return;
                }

                if(mobilenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(mobilenotxtbox,"Please Enter Mobile No.");
                    mobilenotxtbox.Focus();
                    return;
                }

                string duplicateinfo = CheckDuplicate();
                if (duplicateinfo != null) 
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (savebtn.Text == "Update")
                    {
                        bool isupdated = UpdateAccountSubControl();
                        if (isupdated) { MessageBox.Show("Updated Successfully"); }
                    }
                    else
                    {
                        bool isInserted = InsertAccountSubControl();
                        if (isInserted) { MessageBox.Show("Saved Successfully."); }
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static string GenerateRandomAccountCode(string intializer)
        {
            Random random = new Random();
            const string chars = "0123456789";
            char[] serialChars = new char[6];

            for (int i = 0; i < serialChars.Length; i++)
            {
                serialChars[i] = chars[random.Next(chars.Length)];
            }

            string serialNumber = new string(serialChars);
            string query = "SELECT CodeAccount FROM AccountSubControlTable WHERE CodeAccount = '" + serialNumber + "'";
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = GenerateRandomAccountCode(intializer);
                }
            }
            return serialNumber = String.Concat(intializer, serialNumber); ;
        }

        private bool UpdateAccountSubControl()
        {
            string tableName = "AccountSubControlTable";
            string whereClause = "AccountSubControlID = '"+ accountidlbl.Text + "'";

            var columnData = new Dictionary<string, object>
            {
                { "AccountHead_ID", accountheadidlbl.Text },
                { "AccountControl_ID", accountgroupidlbl.Text },
                { "AccountSubControlName", nametxtbox.Text },
                { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "UpdatedDay", DateTime.Now.DayOfWeek },
                { "PrintName", printnametxtbox.Text },
                { "Address", addresstxtbox.Text },
                { "Country", countrytxtbox.Text },
                { "State", statetxtbox.Text },
                { "Email", emailtxtbox.Text },
                { "MobileNo", mobilenotxtbox.Text },
                { "Area", areatxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "TRN", trntxtbox.Text },
                { "GSTNO", gstnotxtbox.Text },
                { "VATNO", vatnotxtbox.Text },
                { "Location", locationtxtbox.Text },
                { "PostalCode", postalcodetxtbox.Text },
                { "Fax", faxtxtbox.Text },
                { "Website", websitetxtbox.Text },
                { "CreditLimit", creditlimittxtbox.Text },
                { "PaymentTerm", paymenttermstxtbox.Text },
                { "DiscountPercentage", discounttxtbox.Text },
                { "RefrencePersonName", refrencepersonnametxtbox.Text },
                { "RefrencePersonMobile", refrencepersonmobiletxtbox.Text },
                { "RefrencePersonEmail", refrencepersonemailtxtbox.Text },
                { "IsAllowedSMS", issmsallowedcheckbox.Checked },
                { "IsAllowedEmail", isemailallowedcheckbox.Checked },
                { "EmiratesId", emiratesidtxtbox.Text },
                { "ServiceTaxNo", servicetaxnotxtbox.Text },
                { "BankName", banknametxtbox.Text },
                { "BankAccountNo", accountnotxtbox.Text }
            };

            bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
            return isUpdated;
        }

        private bool InsertAccountSubControl()
        {
            string tableName = "AccountSubControlTable";

            var columnData = new Dictionary<string, object>
            {
                { "AccountHead_ID", accountheadidlbl.Text },
                { "AccountControl_ID", accountgroupidlbl.Text },
                { "AccountSubControlName", nametxtbox.Text },
                { "AccountSubControlCode", Guid.NewGuid().ToString() },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "CodeAccount", accountcodelbl.Text },
                { "PrintName", printnametxtbox.Text },
                { "Address", addresstxtbox.Text },
                { "Country", countrytxtbox.Text },
                { "State", statetxtbox.Text },
                { "Email", emailtxtbox.Text },
                { "MobileNo", mobilenotxtbox.Text },
                { "Area", areatxtbox.Text },
                { "Description", descriptiontxtbox.Text },
                { "TRN", trntxtbox.Text },
                { "GSTNO", gstnotxtbox.Text },
                { "VATNO", vatnotxtbox.Text },
                { "Location", locationtxtbox.Text },
                { "PostalCode", postalcodetxtbox.Text },
                { "Fax", faxtxtbox.Text },
                { "Website", websitetxtbox.Text },
                { "CreditLimit", creditlimittxtbox.Text },
                { "PaymentTerm", paymenttermstxtbox.Text },
                { "DiscountPercentage", discounttxtbox.Text },
                { "RefrencePersonName", refrencepersonnametxtbox.Text },
                { "RefrencePersonMobile", refrencepersonmobiletxtbox.Text },
                { "RefrencePersonEmail", refrencepersonemailtxtbox.Text },
                { "IsAllowedSMS", issmsallowedcheckbox.Checked },
                { "IsAllowedEmail", isemailallowedcheckbox.Checked },
                { "EmiratesId", emiratesidtxtbox.Text },
                { "ServiceTaxNo", servicetaxnotxtbox.Text },
                { "BankName", banknametxtbox.Text },
                { "BankAccountNo", accountnotxtbox.Text },
                { "IsCustomer", customerradio.Checked },
                { "IsSupplier", supplierradio.Checked },
                { "IsEmployee", employeeradio.Checked },
            };

            bool isInserted = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);
            return isInserted;
        }

        private string CheckDuplicate()
        {
            string query = string.Format(@"SELECT AccountSubControlID,AccountHead_ID,AccountControl_ID,User_ID,AccountSubControlName,
            CompanyID,PrintName,Address,Country,Email,MobileNo,TRN,GSTNO,VATNO,Location,State,PostalCode,Fax,Website,
            EmiratesId,ServiceTaxNo,BankName,BankAccountNo FROM AccountSubControlTable WHERE AccountSubControlName = @AccountSubControlName");

            var parameters = new Dictionary<string, object>
            {
                { "AccountSubControlName", nametxtbox.Text }
            };

            DataTable dt = DatabaseAccess.RetrieveData(query, parameters);

            if(dt!=null && dt.Rows.Count > 0)
            {
                string accountName = dt.Rows[0]["AccountSubControlName"].ToString();
                string address = dt.Rows[0]["Address"].ToString();
                string country = dt.Rows[0]["Country"].ToString();
                string email = dt.Rows[0]["Email"].ToString();
                string mobileno = dt.Rows[0]["MobileNo"].ToString();
                string trn = dt.Rows[0]["TRN"].ToString();
                string gstno = dt.Rows[0]["GSTNO"].ToString();
                string vatno = dt.Rows[0]["VATNO"].ToString();
                string emiratesid = dt.Rows[0]["EmiratesId"].ToString();

                if(nametxtbox.Text == accountName && addresstxtbox.Text == address)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}.";
                }

                if(nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}.";
                }

                if(nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}.";
                }

                if(nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email && 
                    mobilenotxtbox.Text == mobileno)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}, " +
                        $"Mobile No = {mobileno}.";
                }

                if(nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email && 
                    mobilenotxtbox.Text == mobileno && trntxtbox.Text == trn)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}, " +
                        $"Mobile No = {mobileno}, TRN = {trn}.";
                }

                if (nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email &&
                    mobilenotxtbox.Text == mobileno && trntxtbox.Text == trn && gstnotxtbox.Text == gstno)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}, " +
                        $"Mobile No = {mobileno}, TRN = {trn}, GST NO = {gstno}.";
                }

                if (nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email &&
                    mobilenotxtbox.Text == mobileno && trntxtbox.Text == trn && gstnotxtbox.Text == gstno && vatnotxtbox.Text == vatno)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}, " +
                        $"Mobile No = {mobileno}, TRN = {trn}, GST NO = {gstno}, VAT NO = {vatno}.";
                }

                if (nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email &&
                   mobilenotxtbox.Text == mobileno && trntxtbox.Text == trn && gstnotxtbox.Text == gstno && vatnotxtbox.Text == vatno 
                   && emiratesidtxtbox.Text == emiratesid)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}, " +
                        $"Mobile No = {mobileno}, TRN = {trn}, GST NO = {gstno}, VAT NO = {vatno}, Emirates Id = {emiratesid}.";
                }
            }
            return null;
        }

        private void Account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }
        private void nametxtbox_TextChanged(object sender, EventArgs e)
        {
            printnametxtbox.Text = nametxtbox.Text.ToLower();
        }
        private void Account_Load(object sender, EventArgs e)
        {
            string labeldata = accountidlbl.Text;
            if(labeldata!= "accountidlbl")
            {
                FindRecord(Convert.ToInt32(accountidlbl.Text));
            }
        }
        private void FindRecord(int id)
        {
            try
            {
                string query = string.Format("SELECT AccountSubControlID,AccountHead_ID,AccountControl_ID,User_ID,AccountSubControlName,AccountSubControlCode,CompanyID," +
                    "CreatedAt,UpdatedAt,AddedBy,CreatedDay,UpdatedDay,PrintName,Address,Country,Email,MobileNo,OpeningBalanceCredit,OpeningBalanceDebit,CodeAccount,Area," +
                    "Description,TRN,GSTNO,VATNO,Location,State,PostalCode,Fax,Website,CreditLimit,PaymentTerm,DiscountPercentage,RefrencePersonName,RefrencePersonMobile," +
                    "RefrencePersonEmail,IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee " +
                    "FROM AccountSubControlTable WHERE AccountSubControlID = @AccountSubControlID");

                var parameters = new Dictionary<string, object>
                {
                    { "AccountSubControlID", id }
                };

                DataTable dataTable = DatabaseAccess.RetrieveData(query, parameters);

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        nametxtbox.Text = dataTable.Rows[0]["AccountSubControlName"].ToString();
                        printnametxtbox.Text = dataTable.Rows[0]["PrintName"].ToString();
                        int accountcontrolid = Convert.ToInt32(dataTable.Rows[0]["AccountControl_ID"].ToString());
                        accountheadidlbl.Text = dataTable.Rows[0]["AccountHead_ID"].ToString();
                        if (accountcontrolid > 0)
                        {
                            DataTable dtaccountgroup = DatabaseAccess.Retrive("SELECT AccountControlName FROM AccountControlTable " +
                                "WHERE AccountControlID = '"+ accountcontrolid + "'");
                            if (dtaccountgroup != null && dtaccountgroup.Rows.Count > 0)
                            {
                                selectaccountgrouptxtbox.Text = dtaccountgroup.Rows[0]["AccountControlName"].ToString();
                                selectaccountgrouptxtbox.Enabled = false;
                                accountgroupidlbl.Text = accountcontrolid.ToString();
                                
                            } 
                        }
                        addresstxtbox.Text = dataTable.Rows[0]["Address"].ToString(); 
                        countrytxtbox.Text = dataTable.Rows[0]["Country"].ToString(); 
                        emailtxtbox.Text = dataTable.Rows[0]["Email"].ToString(); 
                        mobilenotxtbox.Text = dataTable.Rows[0]["MobileNo"].ToString();
                        postalcodetxtbox.Text = dataTable.Rows[0]["PostalCode"].ToString();
                        areatxtbox.Text = dataTable.Rows[0]["Area"].ToString();
                        locationtxtbox.Text = dataTable.Rows[0]["Location"].ToString();
                        trntxtbox.Text = dataTable.Rows[0]["TRN"].ToString();
                        faxtxtbox.Text = dataTable.Rows[0]["Fax"].ToString();
                        websitetxtbox.Text = dataTable.Rows[0]["Website"].ToString();
                        creditlimittxtbox.Text = dataTable.Rows[0]["CreditLimit"].ToString();
                        paymenttermstxtbox.Text = dataTable.Rows[0]["PaymentTerm"].ToString();
                        gstnotxtbox.Text = dataTable.Rows[0]["GSTNO"].ToString();
                        vatnotxtbox.Text = dataTable.Rows[0]["VATNO"].ToString();
                        servicetaxnotxtbox.Text = dataTable.Rows[0]["ServiceTaxNo"].ToString();
                        emiratesidtxtbox.Text = dataTable.Rows[0]["EmiratesId"].ToString();
                        banknametxtbox.Text = dataTable.Rows[0]["BankName"].ToString();
                        accountnotxtbox.Text = dataTable.Rows[0]["BankAccountNo"].ToString();
                        discounttxtbox.Text = dataTable.Rows[0]["DiscountPercentage"].ToString();
                        refrencepersonnametxtbox.Text = dataTable.Rows[0]["RefrencePersonName"].ToString();
                        refrencepersonemailtxtbox.Text = dataTable.Rows[0]["RefrencePersonEmail"].ToString();
                        refrencepersonmobiletxtbox.Text = dataTable.Rows[0]["RefrencePersonMobile"].ToString();
                        issmsallowedcheckbox.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsAllowedSMS"]);
                        isemailallowedcheckbox.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsAllowedEmail"]);
                        descriptiontxtbox.Text = dataTable.Rows[0]["Description"].ToString();
                        accountcodelbl.Visible = true;
                        accountcodelbl.Text = dataTable.Rows[0]["CodeAccount"].ToString();
                        
                    }
                    savebtn.Text = "Update";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void selectaccountgrouptxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountGroupSelectionForm));
                if(openForm == null)
                {
                    AccountGroupSelectionForm accountSelection = new AccountGroupSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    accountSelection.FormClosed += delegate
                    {
                        UpdateAccountInfo();
                    };
                    CommonFunction.DisposeOnClose(accountSelection);
                    accountSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void UpdateAccountInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.accountnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.accountnameglobal) 
                && GlobalVariables.accountidglobal > 0 && GlobalVariables.accountheadidglobal > 0)
            {
                selectaccountgrouptxtbox.Text = GlobalVariables.accountnameglobal;
                accountgroupidlbl.Text = GlobalVariables.accountidglobal.ToString();
                accountheadidlbl.Text = GlobalVariables.accountheadidglobal.ToString();
            }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (nametxtbox.Text.Trim().Length > 0) { return true; }
            if (printnametxtbox.Text.Trim().Length > 0) { return true; }
            if (selectaccountgrouptxtbox.Text.Trim().Length > 0) { return true; }
            if (addresstxtbox.Text.Trim().Length > 0) { return true; }
            if (countrytxtbox.Text.Trim().Length > 0) { return true; }
            if (emiratesidtxtbox.Text.Trim().Length > 0) { return true; }
            if (areatxtbox.Text.Trim().Length > 0) { return true; }
            if (locationtxtbox.Text.Trim().Length > 0) { return true; }
            if (statetxtbox.Text.Trim().Length > 0) { return true; }
            if (mobilenotxtbox.Text.Trim().Length > 0) { return true; }
            if (trntxtbox.Text.Trim().Length > 0) { return true; }
            if (faxtxtbox.Text.Trim().Length > 0) { return true; }
            if (gstnotxtbox.Text.Trim().Length > 0) { return true; }
            if (vatnotxtbox.Text.Trim().Length > 0) { return true; }
            if (servicetaxnotxtbox.Text.Trim().Length > 0) { return true; }
            if (postalcodetxtbox.Text.Trim().Length > 0) { return true; }
            if (trntxtbox.Text.Trim().Length > 0) { return true; }
            if (accountnotxtbox.Text.Trim().Length > 0) { return true; }

            if (issmsallowedcheckbox.Checked) {  return true; }
            if (isemailallowedcheckbox.Checked) { return true; }
            return false; // No TextBox is filled
        }
        private void selectaccountgrouptxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountGroupSelectionForm));
                if (openForm == null)
                {
                    AccountGroupSelectionForm accountSelection = new AccountGroupSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    accountSelection.FormClosed += delegate
                    {
                        UpdateAccountInfo();
                    };
                    CommonFunction.DisposeOnClose(accountSelection);
                    accountSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void selectaccountgrouptxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(selectaccountgrouptxtbox.Text) && !string.IsNullOrWhiteSpace(selectaccountgrouptxtbox.Text) && 
                accountgroupidlbl.Text != "accountgroupid")
            {
                if (selectaccountgrouptxtbox.Text == "Customers" || selectaccountgrouptxtbox.Text == "Reseller")
                {
                    string initialize = "CU";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                    customerradio.Checked = true;
                    accountcodelbl.Visible = true;
                }
                else if (selectaccountgrouptxtbox.Text == "Suppliers")
                {
                    string initialize = "SU";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                    supplierradio.Checked = true;
                    accountcodelbl.Visible = true;
                }
                else if(selectaccountgrouptxtbox.Text == "Employee")
                {
                    string initialize = "EM";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                    employeeradio.Checked = true;
                    accountcodelbl.Visible = true;
                }
                else
                {
                    string initialize = "AC";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                    accountcodelbl.Visible = true;
                }
            }
        }
    }
}
