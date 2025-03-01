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

namespace SmartFlow.Transactions
{
    public partial class ModifyPaymentVoucher : Form
    {
        public ModifyPaymentVoucher()
        {
            InitializeComponent();
        }

        private void invoicenotxtbox_TextChanged(object sender, EventArgs e)
        {
            string prefix = "PA-";
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
                        Payment payment = new Payment(dataInvoice, dtInvoiceDetails);
                        payment.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(payment);
                        payment.Show();
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

        private void ModifyPaymentVoucher_Load(object sender, EventArgs e)
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
