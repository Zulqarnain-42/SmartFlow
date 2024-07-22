using SmartFlow.Common.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartFlow.Common.CommonForms;

namespace SmartFlow.Masters
{
    public partial class GroupingAccount : Form
    {
        public GroupingAccount()
        {
            InitializeComponent();
        }
        private void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AllAccountsSelection));
            if (openForm == null)
            {
                AllAccountsSelection allaccountselection = new AllAccountsSelection();
                allaccountselection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AllAccountsSelection));
                if (openForm == null) 
                {
                    AllAccountsSelection allAccountsSelection = new AllAccountsSelection();
                    allAccountsSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void AddGroupAccount()
        {
            try
            {

            }
            catch (Exception ex) { throw ex; }
        }
        private void GroupingAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
