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

        private async void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm accountsSelection = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountsSelection.AccountDataSelected += UpdateAccountInfo;

                        await CommonFunction.DisposeOnCloseAsync(accountsSelection);
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

        private async void UpdateAccountInfo(object sender, AccountData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int accountid = e.AccountId;
                    string accountname = e.AccountName;
                    int accountheadid = e.AccountHeadId;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        /* supplieridlbl.Text = supplierId.ToString();
                         selectsuppliertxtbox.Text = supplierName;
                         suppliercodetxtbox.Text = supplierCode;
                         companytxtbox.Text = companyName;*/
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                    {
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                        if (openForm == null)
                        {
                            AccountSelectionForm accountsSelection = new AccountSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };
                            accountsSelection.AccountDataSelected += UpdateAccountInfo;

                            await CommonFunction.DisposeOnCloseAsync(accountsSelection);
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
