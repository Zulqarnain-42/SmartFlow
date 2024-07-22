using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.General;
using System;
using System.Data;
using System.Text.RegularExpressions;
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
            label1.Text = id.ToString();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(savebtn.Text == "Update")
                {
                    errorProvider.Clear();

                    if(nametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(nametxtbox,"Please Enter Name");
                        nametxtbox.Focus();
                        return;
                    }

                    if(printnametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(printnametxtbox,"Please Enter Print Name");
                        printnametxtbox.Focus(); 
                        return;
                    }


                    string accountname = nametxtbox.Text;
                    string printname = printnametxtbox.Text;
                    string address = addresstxtbox.Text;

                    accountname = Regex.Replace(accountname, "[^a-zA-Z0-9 ]", "");
                    printname = Regex.Replace(printname, "[^a-zA-Z0-9 ]", "");
                    address = Regex.Replace(address, "[^a-zA-Z0-9 ]", "");

                    string getaccountgroup = "SELECT AccountControlID,AccountControlName,AccountHead_ID,Alias FROM AccountControlTable " +
                         "WHERE AccountControlID = '" + selectaccountgrouptxtbox.Text + "'";
                    DataTable dataTableaccountgroup = DatabaseAccess.Retrive(getaccountgroup);

                    string query = string.Empty;
                    query = string.Format("SELECT AccountControl_ID,AccountSubControlName,PrintName,OpeningBalanceDebit,OpeningBalanceCredit," +
                        "Address,Country,Email,MobileNo FROM AccountSubControlTable WHERE AccountSubControlName = '" + accountname + "'");

                    DataTable dtdata = DatabaseAccess.Retrive(query);
                    if (dtdata != null)
                    {
                        if (dtdata.Rows.Count > 0)
                        {
                            if (dtdata.Rows[0]["AccountSubControlName"].ToString() == accountname 
                                && dtdata.Rows[0]["PrintName"].ToString() == printname
                                && dtdata.Rows[0]["Address"].ToString() == address
                                && dtdata.Rows[0]["Country"].ToString() == countrytxtbox.Text.Trim().ToString()
                                && dtdata.Rows[0]["Email"].ToString() == emailtxtbox.Text.Trim().ToString()
                                && dtdata.Rows[0]["MobileNo"].ToString() == mobilenotxtbox.Text.Trim().ToString()
                                && dtdata.Rows[0]["AccountControl_ID"].ToString() == selectaccountgrouptxtbox.Text.ToString())
                            {
                                MessageBox.Show("Account Already Exists");
                            }
                            else
                            {
                                    query = "UPDATE AccountSubControlTable SET AccountControl_ID = '" + selectaccountgrouptxtbox.Text + "'," +
                                        "AccountSubControlName = '" + accountname + "',AccountHead_ID = '" + dataTableaccountgroup.Rows[0]["AccountHead_ID"].ToString() +"'," +
                                        "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                        "PrintName = '" + printname + "'," +
                                        "Address = '" + address + "'," +
                                        "Country = '" + countrytxtbox.Text.Trim() + "'," +
                                        "Email = '" + emailtxtbox.Text.Trim() + "'," +
                                        "MobileNo = '" + mobilenotxtbox.Text.Trim() + "'," +
                                        "UpdatedDay = '" + DateTime.Now.DayOfWeek + "' WHERE AccountSubControlID = '" + label1.Text + "'";

                                bool result = DatabaseAccess.Update(query);
                                if (result)
                                {
                                    MessageBox.Show("Updated Successfully!");
                                }
                                else
                                {
                                    MessageBox.Show("Something is wrong");
                                }
                            }
                        }
                        else
                        {
                                query = "UPDATE AccountSubControlTable SET AccountControl_ID = '" + selectaccountgrouptxtbox.Text + "'," +
                                    "AccountSubControlName = '" + accountname + "',AccountHead_ID = '" + dataTableaccountgroup.Rows[0]["AccountHead_ID"].ToString() +"'," +
                                    "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                    "PrintName = '" + printname + "'," +
                                    "Address = '" + address + "'," +
                                    "Country = '" + countrytxtbox.Text.Trim() + "'," +
                                    "Email = '" + emailtxtbox.Text.Trim() + "'," +
                                    "MobileNo = '" + mobilenotxtbox.Text.Trim() + "'," +
                                    "UpdatedDay = '" + DateTime.Now.DayOfWeek + "' WHERE AccountSubControlID = '" + label1.Text + "'";

                            bool result = DatabaseAccess.Update(query);
                            if (result)
                            {
                                MessageBox.Show("Updated Successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong");
                            }
                        }
                    }
                    else
                    {
                            query = "UPDATE AccountSubControlTable SET AccountControl_ID = '" + selectaccountgrouptxtbox.Text + "'," +
                                "AccountSubControlName = '" + accountname + "',AccountHead_ID = '" + dataTableaccountgroup.Rows[0]["AccountHead_ID"].ToString() +"'," +
                                "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "PrintName = '" + printname + "'," +
                                "Address = '" + address + "'," +
                                "Country = '" + countrytxtbox.Text.Trim() + "'," +
                                "Email = '" + emailtxtbox.Text.Trim() + "'," +
                                "MobileNo = '" + mobilenotxtbox.Text.Trim() + "'," +
                                "UpdatedDay = '" + DateTime.Now.DayOfWeek + "' WHERE AccountSubControlID = '" + label1.Text + "'";

                        bool result = DatabaseAccess.Update(query);
                        if (result)
                        {
                            MessageBox.Show("Updated Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong");
                        }
                    }
                    
                }
                else
                {
                    errorProvider.Clear();

                    if (nametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(nametxtbox, "Please Enter Name.");
                        nametxtbox.Focus();
                        return;
                    }

                    if (printnametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(printnametxtbox, "Please Enter Print Name");
                        printnametxtbox.Focus();
                        return;
                    }

                    string accountname = nametxtbox.Text;
                    string printname = printnametxtbox.Text;
                    string address = addresstxtbox.Text;

                    accountname = Regex.Replace(accountname, "[^a-zA-Z0-9 ]", "");
                    printname = Regex.Replace(printname, "[^a-zA-Z0-9 ]", "");
                    address = Regex.Replace(address, "[^a-zA-Z0-9 ]","");

                    string getaccountgroup = "SELECT AccountControlID,AccountControlName,AccountHead_ID,Alias FROM AccountControlTable " +
                                             "WHERE AccountControlID = '" + selectaccountgrouptxtbox.Text + "'";
                    DataTable dataTableaccountgroup = DatabaseAccess.Retrive(getaccountgroup);

                    string query = string.Empty;
                    query = string.Format("SELECT AccountControl_ID,AccountSubControlName,PrintName,OpeningBalanceDebit,OpeningBalanceCredit," +
                        "Address,Country,Email,MobileNo FROM AccountSubControlTable WHERE AccountSubControlName = '" + accountname + "'");

                    DataTable dtdata = DatabaseAccess.Retrive(query);
                    if (dtdata != null)
                    {
                        if (dtdata.Rows.Count > 0)
                        {
                            if (dtdata.Rows[0]["AccountSubControlName"].ToString() == accountname
                                && dtdata.Rows[0]["PrintName"].ToString() == printname
                                && dtdata.Rows[0]["Address"].ToString() == address
                                && dtdata.Rows[0]["Country"].ToString() == countrytxtbox.Text.Trim().ToString()
                                && dtdata.Rows[0]["Email"].ToString() == emailtxtbox.Text.Trim().ToString()
                                && dtdata.Rows[0]["MobileNo"].ToString() == mobilenotxtbox.Text.Trim().ToString()
                                && dtdata.Rows[0]["AccountControl_ID"].ToString() == selectaccountgrouptxtbox.Text.ToString())
                            {
                                MessageBox.Show("Account Already Exists");
                            }
                            else
                            {

                                    query = string.Format("INSERT INTO AccountSubControlTable (AccountControl_ID,AccountSubControlName,AccountHead_ID," +
                                        "AccountSubControlCode,CreatedAt," +
                                    "CreatedDay,PrintName,Address,Country,Email," +
                                    "MobileNo) VALUES " +
                                    "('" + selectaccountgrouptxtbox.Text + "'," +
                                    "'" + accountname + "','" + dataTableaccountgroup.Rows[0]["AccountHead_ID"].ToString() +"'," +
                                    "'" + Guid.NewGuid() + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                    "'" + DateTime.Now.DayOfWeek + "','" + printname + "','" + address + "','" + countrytxtbox.Text.Trim() + "'," +
                                    "'" + emailtxtbox.Text.Trim() + "','" + mobilenotxtbox.Text.Trim() + "')");

                                bool result = DatabaseAccess.Insert(query);

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
                        else
                        {
                                query = string.Format("INSERT INTO AccountSubControlTable (AccountControl_ID,AccountSubControlName,AccountHead_ID," +
                                    "AccountSubControlCode,CreatedAt," +
                                "CreatedDay,PrintName,Address,Country,Email," +
                                "MobileNo) VALUES " +
                                "('" + selectaccountgrouptxtbox.Text + "'," +
                                "'" + accountname + "','"+ dataTableaccountgroup.Rows[0]["AccountHead_ID"].ToString() + "'," +
                                "'" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "','" + printname + "','" + address + "','" + countrytxtbox.Text.Trim() + "'," +
                                "'" + emailtxtbox.Text.Trim() + "','" + mobilenotxtbox.Text.Trim() + "')");
                          

                            bool result = DatabaseAccess.Insert(query);

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
                    else
                    {
                        query = string.Format("INSERT INTO AccountSubControlTable (AccountControl_ID,AccountSubControlName,AccountHead_ID,AccountSubControlCode,CreatedAt," +
                            "CreatedDay,PrintName,Address,Country,Email,MobileNo) VALUES " +
                            "('" + selectaccountgrouptxtbox.Text + "','" + accountname + "','"+dataTableaccountgroup.Rows[0]["AccountHead_ID"].ToString() +"'," +
                            "'" + Guid.NewGuid() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + printname + "'," +
                            "'" + address + "','" + countrytxtbox.Text.Trim() + "','" + emailtxtbox.Text.Trim() + "','" + mobilenotxtbox.Text.Trim() + "')");

                        bool result = DatabaseAccess.Insert(query);

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
        private void Account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void nametxtbox_TextChanged(object sender, EventArgs e)
        {
            printnametxtbox.Text = nametxtbox.Text.ToLower();
        }
        private void Account_Load(object sender, EventArgs e)
        {
            string labeldata = label1.Text;
            if(labeldata!= "label1")
            {
                FindRecord(Convert.ToInt32(label1.Text));
            }
        }
        private void FindRecord(int id)
        {
            try
            {
                string query = string.Format("SELECT AccountControl_ID,AccountSubControlName,PrintName," +
                    "Address,Country,Email,MobileNo FROM AccountSubControlTable WHERE AccountSubControlID = '" + id + "'");
                DataTable dataTable = new DataTable();
                dataTable = DatabaseAccess.Retrive(query);
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        nametxtbox.Text = dataTable.Rows[0]["AccountSubControlName"].ToString();
                        printnametxtbox.Text = dataTable.Rows[0]["PrintName"].ToString();
                        selectaccountgrouptxtbox.Text = dataTable.Rows[0]["AccountControl_ID"].ToString();
                        addresstxtbox.Text = dataTable.Rows[0]["Address"].ToString(); 
                        countrytxtbox.Text = dataTable.Rows[0]["Country"].ToString(); 
                        emailtxtbox.Text = dataTable.Rows[0]["Email"].ToString(); 
                        mobilenotxtbox.Text = dataTable.Rows[0]["MobileNo"].ToString();

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
            }
            catch (Exception ex) { throw ex; }
        }
        private void selectaccountgrouptxtbox_Enter(object sender, EventArgs e)
        {
            try
            {
                AccountSelectionForm selectionForm = new AccountSelectionForm();
                selectionForm.ShowDialog();
            }
            catch (Exception ex) { throw ex; }
        }
        private void Account_FormClosing(object sender, FormClosingEventArgs e)
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
