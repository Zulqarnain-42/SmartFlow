using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Setting
{
    public partial class Terms : Form
    {
        public Terms()
        {
            InitializeComponent();
        }
        private void Terms_Load(object sender, EventArgs e)
        {
            CheckTerms();
        }
        private void CheckTerms()
        {
            try
            {
                string getterms = "SELECT TermsConditions FROM TermsConditionTable";
                DataTable terms = DatabaseAccess.Retrive(getterms);

                if (terms != null)
                {
                    if (terms.Rows.Count > 0)
                    {
                        foreach (DataRow row in terms.Rows)
                        {
                            termstxtbox.Text = row["TermsConditions"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string insertterms = "INSERT INTO TermsConditionTable (TermsConditions) VALUES ('"+termstxtbox.Text+"')";

                bool result = DatabaseAccess.Insert(insertterms);
                if (result)
                {
                    MessageBox.Show("Saved Successfully!");
                }
                else
                {
                    MessageBox.Show("Something is wrong.");
                }

            }catch (Exception ex) { throw ex; }
        }
        private void Terms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void Terms_FormClosing(object sender, FormClosingEventArgs e)
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
