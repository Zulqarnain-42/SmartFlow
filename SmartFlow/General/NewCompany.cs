using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.General
{
    public partial class NewCompany : Form
    {
        private int companyid = 0;
        public NewCompany()
        {
            InitializeComponent();
        }
        public NewCompany(int companyID)
        {
            InitializeComponent();
            this.companyid = companyID;
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string[] companyData = new string[]
                {
                    companynametxtbox.Text,
                    mailingnametxtbox.Text,
                    addresstxtbox.Text,
                    address2txtbox.Text,
                    statetxtbox.Text,
                    countrytxtbox.Text,
                    telephonetxtbox.Text,
                    faxnumbertxtbox.Text,
                    emailtxtbox.Text,
                    pincodetxtbox.Text,
                    trntxtbox.Text,
                    licensenotxtbox.Text,
                    gstnotxtbox.Text,
                    vatnotxtbox.Text,
                    banknametxtbox.Text,
                    accountnotxtbox.Text,
                    branchtxtbox.Text,
                    // Add more text boxes as needed
                };

                string query = string.Empty;
                string companyCode = Guid.NewGuid().ToString();

                string tableName = "CompanyTable";
                var columnData = new Dictionary<string, object>
                {
                    { "CompnayCode", companyCode },
                    { "Name", companynametxtbox.Text },
                    { "MailingName", mailingnametxtbox.Text },
                    { "LisenceNo", licensenotxtbox.Text },
                    { "GSTNO", gstnotxtbox.Text },
                    { "VATNO", vatnotxtbox.Text },
                    { "Address1", addresstxtbox.Text },
                    { "Address2", address2txtbox.Text },
                    { "PostalCode", postalcodetxtbox.Text },
                    { "Country", countrytxtbox.Text },
                    { "Telephone", telephonetxtbox.Text },
                    { "FaxNumber", faxnumbertxtbox.Text },
                    { "EmailOne", emailtxtbox.Text },
                    { "PinCode", pincodetxtbox.Text },
                    { "BankName", banknametxtbox.Text },
                    { "AccNO", accountnotxtbox.Text },
                    { "BranchCode", branchtxtbox.Text },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    { "CreatedDay", DateTime.Now.DayOfWeek },
                    { "State", statetxtbox.Text }
                };

                bool isInserted = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                if (isInserted)
                {
                    string hashedPassword = CommonFunction.HashPassword(passwordtxtbox.Text);

                    tableName = "UserTable";
                    columnData = new Dictionary<string, object>
                    {
                        { "Email" , adminemailtxtbox.Text },
                        { "UserName" , usernametxtbox.Text },
                        { "Password" , hashedPassword },
                        { "UserCode" , Guid.NewGuid() },
                        { "CompanyID" , companyCode },
                        { "CreatedAt" , DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay" , DateTime.Now.DayOfWeek.ToString() }
                    };

                    bool useradded = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                    if (useradded)
                    {
                        SaveInputsToFile(companyData);
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
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void SaveInputsToFile(string[] inputs)
        {
            string filePath = "companyData.txt";

            // Write all inputs to the text file, each on a new line
            File.WriteAllLines(filePath, inputs);
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
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
