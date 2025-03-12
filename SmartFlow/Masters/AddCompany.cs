using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class AddCompany : Form
    {
        public delegate void DataUpdatedHandler(string companyname, string countryname, string address);

        public event DataUpdatedHandler DataUpdated;

        public AddCompany()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if(companynametxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(companynametxtbox,"Please Enter Company Name.");
                companynametxtbox.Focus();
                return;
            }

            if(countrynametxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(countrynametxtbox,"Please Enter Country Name.");
                countrynametxtbox.Focus();
                return;
            }

            string companyname = string.IsNullOrEmpty(companynametxtbox.Text) ? "" : companynametxtbox.Text;
            string countryname = string.IsNullOrEmpty(countrynametxtbox.Text) ? "" : countrynametxtbox.Text;
            string address = string.IsNullOrEmpty(addresstxtbox.Text) ? "" : addresstxtbox.Text;


            // Trigger the event and pass updated data
            DataUpdated?.Invoke(companyname, countryname, address);
            // Close the form
            this.Close();
        }
    }
}
