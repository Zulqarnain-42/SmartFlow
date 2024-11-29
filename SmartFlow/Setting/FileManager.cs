using System;
using System.Windows.Forms;

namespace SmartFlow.Setting
{
    public partial class FileManager : Form
    {
        public FileManager()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(basepathtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(basepathtxtbox,"Please Enter Base Path.");
                    basepathtxtbox.Focus();
                    return;
                }


            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (basepathtxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void FileManager_KeyDown(object sender, KeyEventArgs e)
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
