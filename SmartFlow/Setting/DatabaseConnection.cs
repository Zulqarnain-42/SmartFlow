using System;
using System.Windows.Forms;

namespace SmartFlow.Setting
{
    public partial class DatabaseConnection : Form
    {
        public DatabaseConnection()
        {
            InitializeComponent();
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
                if(servernametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(servernametxtbox,"Please Enter Server Name");
                    servernametxtbox.Focus();
                    return;
                }

                if(databasenametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(databasenametxtbox,"Please Enter Database Name");
                    databasenametxtbox.Focus();
                    return;
                }

                if(usernametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(usernametxtbox,"Please Enter Username");
                    usernametxtbox.Focus();
                    return;
                }

                if(passwordtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(passwordtxtbox,"Please Enter Password.");
                    passwordtxtbox.Focus();
                    return;
                }

                string serverName = servernametxtbox.Text;
                string dbName = databasenametxtbox.Text;

                string query = string.Format("");
                
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (servernametxtbox.Text.Trim().Length > 0) { return true; }
            if (databasenametxtbox.Text.Trim().Length > 0) { return true; }
            if (usernametxtbox.Text.Trim().Length > 0) { return true; }
            if (passwordtxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void DatabaseConnection_KeyDown(object sender, KeyEventArgs e)
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
