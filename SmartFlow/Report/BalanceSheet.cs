using SmartFlow.Common;
using SmartFlow.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report
{
    public partial class BalanceSheet : Form
    {
        public BalanceSheet()
        {
            InitializeComponent();
        }

        private void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm accountsSelection = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountsSelection.FormClosed += delegate
                        {
                            UpdateAccountInfo();
                        };
                        CommonFunction.DisposeOnClose(accountsSelection);
                        accountsSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void UpdateAccountInfo()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.accountnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.accountnameglobal) &&
                GlobalVariables.accountidglobal > 0)
            {
                accountidlbl.Text = GlobalVariables.accountidglobal.ToString();
                selectaccounttxtbox.Text = GlobalVariables.accountnameglobal.ToString();
            }
        }

        private void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                    {
                        Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                        if (openForm == null)
                        {
                            AccountSelectionForm accountsSelection = new AccountSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };
                            accountsSelection.FormClosed += delegate
                            {
                                UpdateAccountInfo();
                            };
                            CommonFunction.DisposeOnClose(accountsSelection);
                            accountsSelection.ShowDialog();
                        }
                        else
                        {
                            openForm.BringToFront();
                        }
                    }
                }
            }
            catch(Exception ex) { throw ex; }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string accountData = selectaccounttxtbox.Text;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
