using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class UpdateOpeningBalance : Form
    {
        public UpdateOpeningBalance(int accountid, string accounttitle)
        {
            InitializeComponent();
            accountidlbl.Text = accountid.ToString();
            accountnamelbl.Text = accounttitle.ToString();
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(amounttxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(amounttxtbox,"Please Enter Opening Amount");
                    amounttxtbox.Focus();
                    return;
                }

                if(!debitamountradio.Checked && !creditamountradio.Checked)
                {
                    errorProvider.SetError(debitamountradio, "Please Select Radio.");
                    debitamountradio.Focus();
                    return;
                }

                if (debitamountradio.Checked)
                {
                    string querydebitamount = string.Format("UPDATE AccountSubControlTable SET OpeningBalanceDebit = '" + amounttxtbox.Text + "' " +
                        "WHERE AccountSubControlID = '" + accountidlbl.Text + "'");

                    string tableName = "AccountSubControlTable";
                    string whereClause = "AccountSubControlID = '" + accountidlbl.Text + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "OpeningBalanceDebit", amounttxtbox.Text }
                    };

                    bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        this.Close();
                    }
                }

                if (creditamountradio.Checked)
                {
                    string querycreditamount = string.Format("UPDATE AccountSubControlTable SET OpeningBalanceCredit = '" + amounttxtbox.Text + "' " +
                        "WHERE AccountSubControlID = '" + accountidlbl.Text + "'");

                    string tableName = "AccountSubControlTable";
                    string whereClause = "AccountSubControlID = '" + accountidlbl.Text + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "OpeningBalanceCredit", amounttxtbox.Text }
                    };

                    bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        this.Close();
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (amounttxtbox.Text.Trim().Length > 0) { return true; }
            if (debitamountradio.Checked) {  return true; }
            if (creditamountradio.Checked) { return true; }
            return false; // No TextBox is filled
        }
        private void UpdateOpeningBalance_KeyDown(object sender, KeyEventArgs e)
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
    }
}
