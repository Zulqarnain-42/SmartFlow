using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (nametxtbox.Text.Trim().Length == 0 && nametxtbox.Enabled == true)
                {
                    errorProvider.SetError(nametxtbox, "Please Enter Name");
                    nametxtbox.Focus();
                    return;
                }

                if (selectaccountgrouptxtbox.Text.Trim().Length == 0 && selectaccountgrouptxtbox.Enabled == true)
                {
                    errorProvider.SetError(selectaccountgrouptxtbox, "Please Select Account Group.");
                    selectaccountgrouptxtbox.Focus();
                    return;
                }

                if(emailtxtbox.Text.Trim().Length == 0 && emailtxtbox.Enabled == true) 
                {
                    errorProvider.SetError(emailtxtbox,"Please Enter Email.");
                    emailtxtbox.Focus();
                    return;
                }

                if(mobilenotxtbox.Text.Trim().Length == 0 && mobilenotxtbox.Enabled == true)
                {
                    errorProvider.SetError(mobilenotxtbox,"Please Enter Mobile No.");
                    mobilenotxtbox.Focus();
                    return;
                }

                string duplicateinfo = await CheckDuplicateAsync();
                if (duplicateinfo != null) 
                {
                    MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (savebtn.Text == "Update")
                    {
                        bool isupdated = await UpdateAccountSubControlAsync();
                        if (isupdated) { MessageBox.Show("Updated Successfully"); }
                    }
                    else
                    {
                        bool isInserted = await InsertAccountSubControlAsync();
                        if (isInserted) { MessageBox.Show("Saved Successfully."); }
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static async Task<string> GenerateRandomAccountCodeAsync(string initializer)
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

            // Assuming 'DatabaseAccess.RetriveAsync' is an asynchronous method
            DataTable dt = await DatabaseAccess.RetriveAsync(query);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = await GenerateRandomAccountCodeAsync(initializer); // Recursive async call
                }
            }

            return string.Concat(initializer, serialNumber);
        }

        private async Task<bool> UpdateAccountSubControlAsync()
        {
            string tableName = "AccountSubControlTable";
            string whereClause = "AccountSubControlID = '" + accountidlbl.Text + "'";

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
                { "BankAccountNo", accountnotxtbox.Text },
                { "CompanyName", companynametxtbox.Text },
                { "IsCustomer", customerradio.Checked },
                { "IsSupplier", supplierradio.Checked },
                { "IsEmployee", employeeradio.Checked }
            };

            // Assuming ExecuteQueryAsync is an asynchronous method for executing the query
            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            if (compnamelbl.Text != "compnamelbl" && countrynamelbl.Text != "countrynamelbl" && companyaddresslbl.Text != "companyaddresslbl")
            {
                if (isUpdated)
                {
                    string companame = compnamelbl.Text;
                    string countryname = countrynamelbl.Text;
                    string companyaddress = companyaddresslbl.Text;
                    string subtablename = "CSCompanyTable";

                    var subcolumnData = new Dictionary<string, object>
                    {
                        { "CompanyName", companame },
                        { "Country", countryname },
                        { "Address", companyaddress },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "AccountSubControlCode", accountsubcontrolcode.Text }
                    };

                    await DatabaseAccess.ExecuteQueryAsync(subtablename, "INSERT", subcolumnData);
                }
            }
            return isUpdated;
        }


        private async Task<bool> InsertAccountSubControlAsync()
        {

            int accountheadid = string.IsNullOrEmpty(accountheadidlbl.Text) ? 0 : Convert.ToInt32(accountheadidlbl.Text);
            int accountcontrolid = string.IsNullOrEmpty(accountgroupidlbl.Text) ? 0 : Convert.ToInt32(accountgroupidlbl.Text);
            string accountname = string.IsNullOrEmpty(nametxtbox.Text) ? "N/A" : nametxtbox.Text;
            string accountsubcontrolcode = Guid.NewGuid().ToString();
            string codeaccount = string.IsNullOrEmpty(accountcodelbl.Text) ? "0000" : accountcodelbl.Text;
            string printname = string.IsNullOrEmpty(printnametxtbox.Text) ? "N/A" : printnametxtbox.Text;
            string address = string.IsNullOrEmpty(addresstxtbox.Text) ? "N/A" : addresstxtbox.Text;
            string country = string.IsNullOrEmpty(countrytxtbox.Text) ? "N/A" : countrytxtbox.Text;
            string State = string.IsNullOrEmpty(statetxtbox.Text) ? "N/A" : statetxtbox.Text;
            string email = string.IsNullOrEmpty(emailtxtbox.Text) ? "N/A" : emailtxtbox.Text;
            string MobileNo = string.IsNullOrEmpty(mobilenotxtbox.Text) ? "0000000000" : mobilenotxtbox.Text;
            string Area = string.IsNullOrEmpty(areatxtbox.Text) ? "N/A" : areatxtbox.Text;
            string Description = string.IsNullOrEmpty(descriptiontxtbox.Text) ? "N/A" : descriptiontxtbox.Text;
            string trn = string.IsNullOrEmpty(trntxtbox.Text) ? "N/A" : trntxtbox.Text;
            string gstno = string.IsNullOrEmpty(gstnotxtbox.Text) ? "N/A" : gstnotxtbox.Text;
            string vatno = string.IsNullOrEmpty(vatnotxtbox.Text) ? "N/A" : vatnotxtbox.Text;
            string location = string.IsNullOrEmpty(locationtxtbox.Text) ? "N/A" : locationtxtbox.Text;
            string postalcode = string.IsNullOrEmpty(postalcodetxtbox.Text) ? "0000" : postalcodetxtbox.Text;
            int paymentterm = string.IsNullOrEmpty(paymenttermstxtbox.Text) ? 0 : Convert.ToInt32(paymenttermstxtbox.Text);

            // Safe parsing for decimal values
            decimal creditlimit = decimal.TryParse(creditlimittxtbox.Text, out decimal tempCreditLimit) ? tempCreditLimit : 0;
            decimal discountpercentage = decimal.TryParse(discounttxtbox.Text, out decimal tempDiscount) ? tempDiscount : 0;


            string tableName = "AccountSubControlTable";

            var columnData = new Dictionary<string, object>
            {
                { "AccountHead_ID", accountheadid },
                { "AccountControl_ID", accountcontrolid },
                { "AccountSubControlName", accountname },
                { "AccountSubControlCode", accountsubcontrolcode },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "CodeAccount", codeaccount },
                { "PrintName", printname },
                { "Address", address },
                { "Country", country },
                { "State", State },
                { "Email", email },
                { "MobileNo", MobileNo },
                { "Area", Area },
                { "Description", Description },
                { "TRN", trn },
                { "GSTNO", gstno },
                { "VATNO", vatno },
                { "Location", location },
                { "PostalCode", postalcode },
                { "Fax", faxtxtbox.Text },
                { "Website", websitetxtbox.Text },
                { "CreditLimit", creditlimit },
                { "PaymentTerm", paymentterm },
                { "DiscountPercentage", discountpercentage },
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
                { "CompanyName", companynametxtbox.Text }
            };

            // Assuming ExecuteQueryAsync is an asynchronous method for executing the query
            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
            if(compnamelbl.Text != "compnamelbl" && countrynamelbl.Text != "countrynamelbl" && companyaddresslbl.Text != "companyaddresslbl")
            {
                if (isInserted)
                {
                    string companame = compnamelbl.Text;
                    string countryname = countrynamelbl.Text;
                    string companyaddress = companyaddresslbl.Text;
                    string subtablename = "CSCompanyTable";

                    var subcolumnData = new Dictionary<string, object>
                    {
                        { "CompanyName", companame },
                        { "Country", countryname },
                        { "Address", companyaddress },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "AccountSubControlCode", accountsubcontrolcode }
                    };

                    await DatabaseAccess.ExecuteQueryAsync(subtablename, "INSERT", subcolumnData);
                }
            }
           
            return isInserted;
        }


        private async Task<string> CheckDuplicateAsync()
        {
            string query = @"SELECT AccountSubControlID, AccountHead_ID, CompanyName, AccountControl_ID, User_ID, AccountSubControlName,
                     CompanyID, PrintName, Address, Country, Email, MobileNo, TRN, GSTNO, VATNO, Location, State, PostalCode, 
                     Fax, Website, EmiratesId, ServiceTaxNo, BankName, BankAccountNo 
                     FROM AccountSubControlTable 
                     WHERE AccountSubControlName = @AccountSubControlName";

            var parameters = new Dictionary<string, object>
            {
                { "AccountSubControlName", nametxtbox.Text }
            };

            // Assuming RetrieveDataAsync is an async method for fetching data from the database
            DataTable dt = await DatabaseAccess.RetrieveDataAsync(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
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
                string companyName = dt.Rows[0]["CompanyName"].ToString();


                if (nametxtbox.Text == accountName && addresstxtbox.Text == address && countrytxtbox.Text == country && emailtxtbox.Text == email &&
                    mobilenotxtbox.Text == mobileno && trntxtbox.Text == trn && gstnotxtbox.Text == gstno && vatnotxtbox.Text == vatno &&
                    emiratesidtxtbox.Text == emiratesid && companynametxtbox.Text == companyName)
                {
                    return $"Duplicate found: Account Name = {accountName}, Address = {address}, Country = {country}, Email = {email}, " +
                        $"Mobile No = {mobileno}, TRN = {trn}, GST NO = {gstno}, VAT NO = {vatno}, Emirates Id = {emiratesid}, Company Name = {companyName}.";
                }
            }
            return null;
        }


        private async void Account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (await AreAnyTextBoxesFilledAsync())  // Assuming AreAnyTextBoxesFilled is now async
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

        private async void Account_Load(object sender, EventArgs e)
        {
            string labeldata = accountidlbl.Text;
            if (labeldata != "accountidlbl")
            {
                // Try parsing the account ID to ensure it's a valid integer
                if (int.TryParse(accountidlbl.Text, out int accountId))
                {
                    // Call FindRecord asynchronously
                    await FindRecordAsync(accountId);
                }
                else
                {
                    MessageBox.Show("Invalid account ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task FindRecordAsync(int id)
        {
            try
            {
                // Validate the input ID
                if (id <= 0)
                {
                    MessageBox.Show("The AccountSubControlID cannot be null or empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SQL query for fetching data
                string query = "SELECT AccountSubControlID, AccountHead_ID, AccountControl_ID, User_ID, AccountSubControlName, AccountSubControlCode, CompanyID, " +
                               "CreatedAt, UpdatedAt, AddedBy, CreatedDay, UpdatedDay, PrintName, Address, Country, Email, MobileNo, OpeningBalanceCredit, OpeningBalanceDebit, " +
                               "CodeAccount, Area, Description, TRN, GSTNO, VATNO, Location, State, PostalCode, Fax, Website, CreditLimit, PaymentTerm, DiscountPercentage, " +
                               "RefrencePersonName, RefrencePersonMobile, RefrencePersonEmail, IsAllowedSMS, IsAllowedEmail, EmiratesId, ServiceTaxNo, BankName, BankAccountNo, " +
                               "IsCustomer, IsSupplier, IsEmployee, CompanyName FROM AccountSubControlTable WHERE AccountSubControlID = @AccountSubControlID";

                var parameters = new Dictionary<string, object>
                {
                    { "@AccountSubControlID", id }
                };

                // Use asynchronous method to retrieve data
                DataTable dataTable = await DatabaseAccess.RetrieveDataAsync(query, parameters);

                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the given AccountSubControlID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Map data to controls
                var row = dataTable.Rows[0];
                nametxtbox.Text = row["AccountSubControlName"].ToString();
                printnametxtbox.Text = row["PrintName"].ToString();
                accountheadidlbl.Text = row["AccountHead_ID"].ToString();

                int accountControlId;
                if (int.TryParse(row["AccountControl_ID"].ToString(), out accountControlId) && accountControlId > 0)
                {
                    // Fetch account group details asynchronously
                    string accountGroupQuery = "SELECT AccountControlName FROM AccountControlTable WHERE AccountControlID = @AccountControlID";
                    var accountGroupParams = new Dictionary<string, object>
                    {
                        { "@AccountControlID", accountControlId }
                    };
                    DataTable dtAccountGroup = await DatabaseAccess.RetrieveDataAsync(accountGroupQuery, accountGroupParams);

                    if (dtAccountGroup != null && dtAccountGroup.Rows.Count > 0)
                    {
                        selectaccountgrouptxtbox.Text = dtAccountGroup.Rows[0]["AccountControlName"].ToString();
                        selectaccountgrouptxtbox.Enabled = false;
                        accountgroupidlbl.Text = accountControlId.ToString();

                        switch (selectaccountgrouptxtbox.Text)
                        {
                            case "Customers":
                            case "Reseller":
                                customerradio.Checked = true;
                                break;
                            case "Suppliers":
                                supplierradio.Checked = true;
                                break;
                            case "Employee":
                                employeeradio.Checked = true;
                                break;
                            default:
                                accountcodelbl.Visible = true;
                                break;
                        }
                    }
                }

                // Populate other controls
                accountsubcontrolcode.Text = row["AccountSubControlCode"].ToString();
                addresstxtbox.Text = row["Address"].ToString();
                countrytxtbox.Text = row["Country"].ToString();
                emailtxtbox.Text = row["Email"].ToString();
                mobilenotxtbox.Text = row["MobileNo"].ToString();
                postalcodetxtbox.Text = row["PostalCode"].ToString();
                areatxtbox.Text = row["Area"].ToString();
                locationtxtbox.Text = row["Location"].ToString();
                trntxtbox.Text = row["TRN"].ToString();
                faxtxtbox.Text = row["Fax"].ToString();
                websitetxtbox.Text = row["Website"].ToString();
                creditlimittxtbox.Text = row["CreditLimit"].ToString();
                paymenttermstxtbox.Text = row["PaymentTerm"].ToString();
                gstnotxtbox.Text = row["GSTNO"].ToString();
                vatnotxtbox.Text = row["VATNO"].ToString();
                servicetaxnotxtbox.Text = row["ServiceTaxNo"].ToString();
                emiratesidtxtbox.Text = row["EmiratesId"].ToString();
                banknametxtbox.Text = row["BankName"].ToString();
                accountnotxtbox.Text = row["BankAccountNo"].ToString();
                discounttxtbox.Text = row["DiscountPercentage"].ToString();
                refrencepersonnametxtbox.Text = row["RefrencePersonName"].ToString();
                refrencepersonemailtxtbox.Text = row["RefrencePersonEmail"].ToString();
                refrencepersonmobiletxtbox.Text = row["RefrencePersonMobile"].ToString();
                issmsallowedcheckbox.Checked = Convert.ToBoolean(row["IsAllowedSMS"]);
                isemailallowedcheckbox.Checked = Convert.ToBoolean(row["IsAllowedEmail"]);
                descriptiontxtbox.Text = row["Description"].ToString();
                accountcodelbl.Visible = true;
                accountcodelbl.Text = row["CodeAccount"].ToString();
                companynametxtbox.Text = row["CompanyName"].ToString();

                // Update button text
                savebtn.Text = "Update";
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Data format error: {formatEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void selectaccountgrouptxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectaccountgrouptxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupSelection));
                    if (openForm == null)
                    {
                        AccountGroupSelection accountSelection = new AccountGroupSelection
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountSelection.AccountDataSelected += UpdateAccountInfo;

                        CommonFunction.DisposeOnClose(accountSelection);
                        await Task.Run(() => accountSelection.ShowDialog());  // Use async operation to show form asynchronously
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateAccountInfo(object sender, AccountData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int accountid = e.AccountId;
                    string accountname = e.AccountName;
                    int accountheadid = e.AccountHeadId;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        accountgroupidlbl.Text = accountid.ToString();
                        selectaccountgrouptxtbox.Text = accountname.ToString();
                        accountheadidlbl.Text = accountheadid.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> AreAnyTextBoxesFilledAsync()
        {
            return await Task.Run(() =>
            {
                var textBoxes = new List<TextBox>
                {
                    nametxtbox, printnametxtbox, selectaccountgrouptxtbox,
                    countrytxtbox, emiratesidtxtbox, areatxtbox, locationtxtbox, statetxtbox,
                    mobilenotxtbox, trntxtbox, faxtxtbox, gstnotxtbox, vatnotxtbox,
                    servicetaxnotxtbox, postalcodetxtbox, accountnotxtbox
                };

                // Check if any of the TextBoxes have text
                if (textBoxes.Any(txtBox => !string.IsNullOrWhiteSpace(txtBox.Text)))
                {
                    return true;
                }

                // Check if any of the checkboxes are checked
                if (issmsallowedcheckbox.Checked || isemailallowedcheckbox.Checked)
                {
                    return true;
                }

                return false; // No TextBox is filled or checkbox is checked
            });
        }

        private async void selectaccountgrouptxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectaccountgrouptxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupSelection));
                    if (openForm == null)
                    {
                        AccountGroupSelection accountSelection = new AccountGroupSelection
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountSelection.AccountDataSelected += UpdateAccountInfo;

                        CommonFunction.DisposeOnClose(accountSelection);

                        // Run ShowDialog() directly on the UI thread
                        accountSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private async void selectaccountgrouptxtbox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectaccountgrouptxtbox.Text) && !string.IsNullOrWhiteSpace(selectaccountgrouptxtbox.Text) &&
                accountgroupidlbl.Text != "accountgroupid")
            {
                if (selectaccountgrouptxtbox.Text == "Customers" || selectaccountgrouptxtbox.Text == "Reseller")
                {
                    string initialize = "CU";
                    accountcodelbl.Text = await GenerateRandomAccountCodeAsync(initialize);
                    customerradio.Checked = true;
                    accountcodelbl.Visible = true;
                }
                else if (selectaccountgrouptxtbox.Text == "Suppliers")
                {
                    string initialize = "SU";
                    accountcodelbl.Text = await GenerateRandomAccountCodeAsync(initialize);
                    supplierradio.Checked = true;
                    accountcodelbl.Visible = true;
                }
                else if (selectaccountgrouptxtbox.Text == "Employee")
                {
                    string initialize = "EM";
                    accountcodelbl.Text = await GenerateRandomAccountCodeAsync(initialize);
                    employeeradio.Checked = true;
                    accountcodelbl.Visible = true;
                }
                else
                {
                    string initialize = "AC";
                    accountcodelbl.Text = await GenerateRandomAccountCodeAsync(initialize);
                    accountcodelbl.Visible = true;
                    addresstxtbox.Enabled = false;
                    countrytxtbox.Enabled = false;
                    postalcodetxtbox.Enabled = false;
                    areatxtbox.Enabled = false;
                    locationtxtbox.Enabled = false;
                    statetxtbox.Enabled = false;
                    emailtxtbox.Enabled = false;
                    websitetxtbox.Enabled = false;
                    creditlimittxtbox.Enabled = false;
                    paymenttermstxtbox.Enabled = false;
                    gstnotxtbox.Enabled = false;
                    vatnotxtbox.Enabled = false;
                    servicetaxnotxtbox.Enabled = false;
                    trntxtbox.Enabled = false;
                    mobilenotxtbox.Enabled = false;
                    emiratesidtxtbox.Enabled = false;
                    faxtxtbox.Enabled = false;
                    companynametxtbox.Enabled = false;
                    banknametxtbox.Enabled = false;
                    accountnotxtbox.Enabled = false;
                    discounttxtbox.Enabled = false;
                    refrencepersonnametxtbox.Enabled = false;
                    refrencepersonemailtxtbox.Enabled = false;
                    refrencepersonmobiletxtbox.Enabled = false;
                    descriptiontxtbox.Enabled = false;
                }
            }
        }

        private void addcompanybtn_Click(object sender, EventArgs e)
        {
            AddCompany addCompany = new AddCompany();
            addCompany.DataUpdated += AddCompany_DataUpdated;
            addCompany.ShowDialog();
        }

        private void AddCompany_DataUpdated(string companyname,string countryname,string address)
        {
            compnamelbl.Text = companyname;
            countrynamelbl.Text = countryname;
            companyaddresslbl.Text = address;
        }
    }
}
