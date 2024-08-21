using SmartFlow.Common;
using System;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Currency : Form
    {
        public Currency()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(currencysymboltxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencysymboltxtbox,"Please Enter Currency Symbol.");
                    currencysymboltxtbox.Focus();
                    return;
                }

                if(currencystrintxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencystrintxtbox,"Please Enter Currency String");
                    currencystrintxtbox.Focus();
                    return;
                }

                if(currencynametxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(currencynametxtbox,"Please Enter Currency Name");
                    currencynametxtbox.Focus();
                    return;
                }

                string currencyName = CommonFunction.CleanText(currencynametxtbox.Text.Trim());

                string currencycode = Guid.NewGuid().ToString();
                string query = string.Format("INSERT INTO CurrencyTable (CurrencyCode,Symbol,CurrencyString,Name,CreatedAt,CreatedDay) VALUES ('" + currencycode + "'," +
                    "'" + currencysymboltxtbox.Text + "','" + currencystrintxtbox.Text + "','" + currencyName + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                    "'" + DateTime.Now.DayOfWeek + "')");

                bool result = DatabaseAccess.Insert(query);
                if (result) 
                {
                    MessageBox.Show("Inserted Successfully!");
                }

            }catch(Exception ex) { throw ex; }
        }
        private void currencysymboltxtbox_TextChanged(object sender, EventArgs e)
        {
            currencystrintxtbox.Text = currencysymboltxtbox.Text.Trim();
        }
        private void Currency_KeyDown(object sender, KeyEventArgs e)
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
            if (currencysymboltxtbox.Text.Trim().Length > 0) { return true; }
            if (currencystrintxtbox.Text.Trim().Length > 0) { return true; }
            if (currencynametxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
    }
}
