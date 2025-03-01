using Irony.Parsing.Construction;
using Microsoft.Identity.Client;
using SixLabors.Fonts;
using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Util;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Transactions
{
    public partial class ModifyJournalVoucher : Form
    {
        public ModifyJournalVoucher()
        {
            InitializeComponent();
        }

        private void invoicenotxtbox_TextChanged(object sender, EventArgs e)
        {
            string prefix = "JR-";
            if (!invoicenotxtbox.Text.StartsWith(prefix))
            {
                invoicenotxtbox.Text = prefix;
                invoicenotxtbox.SelectionStart = invoicenotxtbox.Text.Length; // Place the cursor at the end
            }
        }

        private async void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("SELECT TransactionId,InvoiceNo,InvoiceDate,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol," +
                    "ConversionRate,CreatedAt,UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId,VoucherInfo FROM TransactionTable WHERE InvoiceNo LIKE '" + invoicenotxtbox.Text + "'");

                DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                if (dataInvoice.Rows.Count > 0)
                {
                    string subquery = string.Format("SELECT TransactionDetailId,TransactionId,AccountId,AccountName,AccountCode,IsDebit,IsCredit,ShortDescription,DebitAmount,CreditAmount," +
                        "InvoiceNo,DebitOrCredit,TransactionCode FROM TransactionDetailTable WHERE InvoiceNo LIKE '" + invoicenotxtbox.Text + "' AND IsNewRecord = '" + true + "'");

                    DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                    if (dtInvoiceDetails != null || dtInvoiceDetails.Rows.Count > 0)
                    {
                        this.Close();
                        Journal journal = new Journal(dataInvoice, dtInvoiceDetails);
                        journal.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(journal);
                        journal.Show();
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyJournalVoucher_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private async void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string userinput = invoicenotxtbox.Text;
                if (userinput.Length > 0)
                {
                    // Using parameterized query to avoid SQL injection
                    string query = "SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo = @InvoiceNo";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@InvoiceNo", userinput }
                    };

                    DataTable invoiceData = await DatabaseAccess.RetriveAsync(query, parameters);

                    if (invoiceData.Rows.Count > 0)
                    {
                        DataRow row = invoiceData.Rows[0];
                        invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
