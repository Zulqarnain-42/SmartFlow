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
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string terms = termstxtbox.Text;
                string insertterms = "INSERT INTO TermsConditionTable (TermsConditions) VALUES ('" + terms + "')";

                

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Terms_KeyDown(object sender, KeyEventArgs e)
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
            if (termstxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
    }
}
