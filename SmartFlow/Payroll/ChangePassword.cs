using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Payroll
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        private void ChangePassword_KeyDown(object sender, KeyEventArgs e)
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
        private bool AreAnyTextBoxesFilled()
        {
            if (oldpasswordtxtbox.Text.Trim().Length > 0) { return true; }
            if (newpasswordtxtbox.Text.Trim().Length > 0) { return true; }
            if (confirmpasswordtxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void savebtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(oldpasswordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(oldpasswordtxtbox,"Please Enter Old Password.");
                    oldpasswordtxtbox.Focus();
                    return;
                }

                if(newpasswordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(newpasswordtxtbox,"Please Enter New Password.");
                    newpasswordtxtbox.Focus();
                    return;
                }

                if(confirmpasswordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(confirmpasswordtxtbox,"Please Enter Confirm Password.");
                    confirmpasswordtxtbox.Focus();
                    return;
                }

                if(newpasswordtxtbox.Text != confirmpasswordtxtbox.Text)
                {
                    errorProvider.SetError(confirmpasswordtxtbox,"Password Does Not Matched.");
                    confirmpasswordtxtbox.Focus();
                    return;
                }


            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void oldpasswordtxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (oldpasswordtxtbox.Text.Trim().Length == 0)
                {
                    string query = string.Format("");
                    DataTable oldpassworddata = DatabaseAccess.Retrive(query);
                    if (oldpassworddata != null && oldpassworddata.Rows.Count > 0)
                    {

                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
