using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using System;
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

                string accountname = nametxtbox.Text;
                string printname = printnametxtbox.Text;
                string address = addresstxtbox.Text;
                int salemanid = 0;
                bool result = false;

                string query = string.Empty;
                query = string.Format("SELECT AccountSubControlID,AccountHead_ID,AccountControl_ID,User_ID,AccountSubControlName," +
                    "AccountSubControlCode,CompanyID,CreatedAt,UpdatedAt,AddedBy,CreatedDay,UpdatedDay,PrintName,Address,Country," +
                    "Email,MobileNo,OpeningBalanceCredit,OpeningBalanceDebit,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location," +
                    "State,PostalCode,Fax,Website,CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile," +
                    "RefrencePersonEmail,IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo " +
                    "FROM AccountSubControlTable WHERE AccountSubControlName = '" + accountname + "'");

                DataTable dtdata = DatabaseAccess.Retrive(query);
                if (dtdata != null && dtdata.Rows.Count > 0)
                {
                    if (dtdata.Rows[0]["AccountSubControlName"].ToString() == accountname
                        && dtdata.Rows[0]["PrintName"].ToString() == printname
                        && dtdata.Rows[0]["Address"].ToString() == address
                        && dtdata.Rows[0]["AccountControl_ID"].ToString() == accountgroupidlbl.Text
                        && dtdata.Rows[0]["Country"].ToString() == countrytxtbox.Text
                        && dtdata.Rows[0]["PostalCode"].ToString() == postalcodetxtbox.Text
                        && dtdata.Rows[0]["Area"].ToString() == areatxtbox.Text
                        && dtdata.Rows[0]["Location"].ToString() == locationtxtbox.Text
                        && dtdata.Rows[0]["TRN"].ToString() == trntxtbox.Text
                        && dtdata.Rows[0]["Fax"].ToString() == faxtxtbox.Text
                        && dtdata.Rows[0]["Website"].ToString() == websitetxtbox.Text
                        && dtdata.Rows[0]["CreditLimit"].ToString() == creditlimittxtbox.Text
                        && dtdata.Rows[0]["PaymentTerms"].ToString() == paymenttermstxtbox.Text
                        && dtdata.Rows[0]["GSTNO"].ToString() == gstnotxtbox.Text
                        && dtdata.Rows[0]["VATNO"].ToString() == vatnotxtbox.Text
                        && dtdata.Rows[0]["ServiceTaxNo"].ToString() == servicetaxnotxtbox.Text
                        && dtdata.Rows[0]["EmiratesId"].ToString() == emiratesidtxtbox.Text
                        && dtdata.Rows[0]["BankAccountNo"].ToString() == accountnotxtbox.Text
                        && dtdata.Rows[0]["DiscountPercentage"].ToString() == discounttxtbox.Text
                        && dtdata.Rows[0]["RefrencePersonName"].ToString() == refrencepersonnametxtbox.Text
                        && dtdata.Rows[0]["RefrencePersonEmail"].ToString() == refrencepersonemailtxtbox.Text
                        && dtdata.Rows[0]["RefrencePersonMobile"].ToString() == refrencepersonmobiletxtbox.Text
                        && dtdata.Rows[0]["Description"].ToString() == descriptiontxtbox.Text
                        && dtdata.Rows[0]["Country"].ToString() == countrytxtbox.Text.Trim().ToString()
                        && dtdata.Rows[0]["Email"].ToString() == statetxtbox.Text.Trim().ToString()
                        && dtdata.Rows[0]["MobileNo"].ToString() == mobilenotxtbox.Text.Trim().ToString())
                    {
                        MessageBox.Show("Account Already Exists");
                    }

                    else
                    {
                        if (savebtn.Text == "Update")
                        {
                            query = "UPDATE AccountSubControlTable SET AccountHead_ID = '" + accountheadidlbl.Text + "'," +
                                "AccountControl_ID = '" + accountgroupidlbl.Text + "'," +
                                "AccountSubControlName = '" + accountname + "'," +
                                "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                                "PrintName = '" + printname + "'," +
                                "Address = '" + address + "'," +
                                "Country = '" + countrytxtbox.Text + "'," +
                                "Email = '" + statetxtbox.Text + "'," +
                                "MobileNo = '" + mobilenotxtbox.Text + "'," +
                                "Area = '" + areatxtbox.Text + "'," +
                                "Description = '" + descriptiontxtbox.Text + "'," +
                                "TRN = '" + trntxtbox.Text + "'," +
                                "GSTNO = '" + gstnotxtbox.Text + "'," +
                                "VATNO = '" + vatnotxtbox.Text + "'," +
                                "Location = '" + locationtxtbox.Text + "'," +
                                "PostalCode = '" + postalcodetxtbox.Text + "'," +
                                "Fax = '" + faxtxtbox.Text + "'," +
                                "Website = '" + websitetxtbox.Text + "'," +
                                "CreditLimit = '" + creditlimittxtbox.Text + "'," +
                                "PaymentTerms = '" + paymenttermstxtbox.Text + "'," +
                                "DiscountPercentage = '" + discounttxtbox.Text + "'," +
                                "RefrencePersonName = '" + refrencepersonnametxtbox.Text + "'," +
                                "RefrencePersonMobile = '" + refrencepersonmobiletxtbox.Text + "'," +
                                "RefrencePersonEmail = '" + refrencepersonemailtxtbox.Text + "'," +
                                "IsAllowedSMS = '" + issmsallowedcheckbox.Checked + "'," +
                                "IsAllowedEmail = '" + isemailallowedcheckbox.Checked + "'," +
                                "EmiratesId = '" + emiratesidtxtbox.Text + "'," +
                                "ServiceTaxNo = '" + servicetaxnotxtbox.Text + "'," +
                                "BankName = '" + banknametxtbox.Text + "'," +
                                "BankAccountNo =  '" + accountnotxtbox.Text + "'" +
                                "WHERE AccountSubControlID = '" + accountidlbl.Text + "'";

                            result = DatabaseAccess.Update(query);
                            if (result)
                            {
                                MessageBox.Show("Updated Successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong");
                            }
                        }
                        else
                        {
                            if (selectaccountgrouptxtbox.Text == "Customers" || selectaccountgrouptxtbox.Text == "Reseller")
                            {
                                string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                    "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                    "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                    "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                    "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                    "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                    "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                    "'" + areatxtbox.Text + "'," +
                                    "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                    "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                    "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                    "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                    "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                    "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + true + "','" + false + "','" + false + "')");
                                result = DatabaseAccess.Insert(subquery);
                            }
                            else if (selectaccountgrouptxtbox.Text == "Suppliers")
                            {
                                string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                    "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                    "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                    "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                    "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                    "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                    "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                    "'" + areatxtbox.Text + "'," +
                                    "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                    "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                    "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                    "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                    "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                     "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + false + "','" + true + "','" + false + "')");
                                result = DatabaseAccess.Insert(subquery);
                            }
                            else if (selectaccountgrouptxtbox.Text == "Employee")
                            {
                                string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                    "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                    "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                    "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                    "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                    "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                    "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                    "'" + areatxtbox.Text + "'," +
                                    "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                    "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                    "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                    "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                    "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                    "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + false + "','" + false + "','" + true + "')");
                                result = DatabaseAccess.Insert(subquery);
                            }
                            else
                            {
                                string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                    "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                    "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                    "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                    "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                    "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                    "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                    "'" + areatxtbox.Text + "'," +
                                    "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                    "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                    "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                    "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                    "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                    "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + false + "','" + false + "','" + false + "')");
                                result = DatabaseAccess.Insert(subquery);
                            }
                            
                            if (result)
                            {
                                MessageBox.Show("Saved Successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                }
                else
                {
                    if (savebtn.Text == "Update")
                    {
                        query = "UPDATE AccountSubControlTable SET AccountHead_ID = ," +
                            "AccountControl_ID = ," +
                            "AccountSubControlName = '" + accountname + "'," +
                            "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                            "PrintName = '" + printname + "'," +
                            "Address = '" + address + "'," +
                            "Country = '" + countrytxtbox.Text + "'," +
                            "Email = '" + statetxtbox.Text + "'," +
                            "MobileNo = '" + mobilenotxtbox.Text + "'," +
                            "CodeAccount = ," +
                            "Area = '" + areatxtbox.Text + "'," +
                            "Description = '" + descriptiontxtbox.Text + "'," +
                            "TRN = '" + trntxtbox.Text + "'," +
                            "GSTNO = '" + gstnotxtbox.Text + "'," +
                            "VATNO = '" + vatnotxtbox.Text + "'," +
                            "Location = '" + locationtxtbox.Text + "'," +
                            "PostalCode = '" + postalcodetxtbox.Text + "'," +
                            "Fax = '" + faxtxtbox.Text + "'," +
                            "Website = '" + websitetxtbox.Text + "'," +
                            "CreditLimit = '" + creditlimittxtbox.Text + "'," +
                            "PaymentTerms = '" + paymenttermstxtbox.Text + "'," +
                            "DiscountPercentage = '" + discounttxtbox.Text + "'," +
                            "RefrencePersonName = '" + refrencepersonnametxtbox.Text + "'," +
                            "RefrencePersonMobile = '" + refrencepersonmobiletxtbox.Text + "'," +
                            "RefrencePersonEmail = '" + refrencepersonemailtxtbox.Text + "'," +
                            "IsAllowedSMS = '" + issmsallowedcheckbox.Checked + "'," +
                            "IsAllowedEmail = '" + isemailallowedcheckbox.Checked + "'," +
                            "EmiratesId = '" + emiratesidtxtbox.Text + "'," +
                            "ServiceTaxNo = '" + servicetaxnotxtbox.Text + "'," +
                            "BankName = '" + trntxtbox.Text + "'," +
                            "BankAccountNo =  '" + accountnotxtbox.Text + "'" +
                            "WHERE ";

                        result = DatabaseAccess.Update(query);
                        if (result)
                        {
                            MessageBox.Show("Updated Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong");
                        }
                    }
                    else
                    {
                        if (selectaccountgrouptxtbox.Text == "Customers" || selectaccountgrouptxtbox.Text == "Reseller")
                        {
                            string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                "'" + areatxtbox.Text + "'," +
                                "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + true + "','" + false + "','" + false + "')");
                            result = DatabaseAccess.Insert(subquery);
                        }
                        else if (selectaccountgrouptxtbox.Text == "Suppliers")
                        {
                            string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                "'" + areatxtbox.Text + "'," +
                                "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                 "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + false + "','" + true + "','" + false + "')");
                            result = DatabaseAccess.Insert(subquery);
                        }
                        else if (selectaccountgrouptxtbox.Text == "Employee")
                        {
                            string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                "'" + areatxtbox.Text + "'," +
                                "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + false + "','" + false + "','" + true + "')");
                            result = DatabaseAccess.Insert(subquery);
                        }
                        else
                        {
                            string subquery = string.Format("INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID," +
                                "AccountSubControlName,AccountSubControlCode,CreatedAt,CreatedDay,PrintName,Address,Country," +
                                "Email,MobileNo,CodeAccount,Area,Description,TRN,GSTNO,VATNO,Location,PostalCode,Fax,Website," +
                                "CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile,RefrencePersonEmail," +
                                "IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee) VALUES " +
                                "('" + accountheadidlbl.Text + "','" + accountgroupidlbl.Text + "','" + nametxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                                "'" + address + "','" + countrytxtbox.Text + "','" + statetxtbox.Text + "','" + mobilenotxtbox.Text + "','" + accountcodelbl.Text + "'," +
                                "'" + areatxtbox.Text + "'," +
                                "'" + descriptiontxtbox.Text + "','" + trntxtbox.Text + "','" + gstnotxtbox.Text + "','" + vatnotxtbox.Text + "','" + locationtxtbox.Text + "'," +
                                "'" + postalcodetxtbox.Text + "','" + faxtxtbox.Text + "','" + websitetxtbox.Text + "','" + creditlimittxtbox.Text + "'," +
                                "'" + paymenttermstxtbox.Text + "','" + discounttxtbox.Text + "','" + refrencepersonnametxtbox.Text + "'," +
                                "'" + refrencepersonmobiletxtbox.Text + "','" + refrencepersonemailtxtbox.Text + "'," +
                                "'" + issmsallowedcheckbox.Checked + "','" + isemailallowedcheckbox.Checked + "','" + emiratesidtxtbox.Text + "'," +
                                "'" + servicetaxnotxtbox.Text + "','" + trntxtbox.Text + "','" + accountnotxtbox.Text + "','" + false + "','" + false + "','" + false + "')");
                            result = DatabaseAccess.Insert(subquery);
                        }

                        
                        if (result)
                        {
                            MessageBox.Show("Saved Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    "Description,TRN,GSTNO,VATNO,Location,State,PostalCode,Fax,Website,CreditLimit,PaymentTerms,DiscountPercentage,RefrencePersonName,RefrencePersonMobile," +
                    "RefrencePersonEmail,IsAllowedSMS,IsAllowedEmail,EmiratesId,ServiceTaxNo,BankName,BankAccountNo,IsCustomer,IsSupplier,IsEmployee " +
                    "FROM AccountSubControlTable WHERE AccountSubControlID = '" + id + "'");
                DataTable dataTable = new DataTable();
                dataTable = DatabaseAccess.Retrive(query);
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
                        paymenttermstxtbox.Text = dataTable.Rows[0]["PaymentTerms"].ToString();
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
                        issmsallowedcheckbox.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsAllowedSMS"].ToString());
                        isemailallowedcheckbox.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsAllowedEmail"].ToString());
                        descriptiontxtbox.Text = dataTable.Rows[0]["Description"].ToString();
                        accountcodelbl.Text = dataTable.Rows[0]["CodeAccount"].ToString();
                    }
                    savebtn.Text = "Update";
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void selectaccountgrouptxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountGroupSelectionForm));
                if(openForm == null)
                {
                    AccountGroupSelectionForm accountSelection = new AccountGroupSelectionForm();
                    accountSelection.ShowDialog();
                    UpdateAccountInfo();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
            catch (Exception ex) { throw ex; }
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
                    AccountGroupSelectionForm accountSelection = new AccountGroupSelectionForm();
                    accountSelection.ShowDialog();
                    UpdateAccountInfo();
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
                }
                else if (selectaccountgrouptxtbox.Text == "Suppliers")
                {
                    string initialize = "SU";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                }
                else if(selectaccountgrouptxtbox.Text == "Employee")
                {
                    string initialize = "EM";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                }
                else
                {
                    string initialize = "AC";
                    accountcodelbl.Text = GenerateRandomAccountCode(initialize);
                }
            }
        }
    }
}
