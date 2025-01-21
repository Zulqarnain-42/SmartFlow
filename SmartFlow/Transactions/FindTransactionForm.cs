using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class FindTransactionForm : Form
    {
        public FindTransactionForm()
        {
            InitializeComponent();
        }
        private void FindTransactionForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private async void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string invoiceNo = invoicenotxtbox.Text;
                if (string.IsNullOrEmpty(invoiceNo)) 
                {
                    MessageBox.Show("Invoice Is Empty");
                    return;
                }

                if (paymentradiobtn.Checked)
                {
                    string query = string.Format("SELECT TransactionId,InvoiceNo,Date,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol,ConversionRate," +
                        "CreatedAt,UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId,VoucherInfo FROM TransactionTable WHERE InvoiceNo LIKE '" + invoiceNo + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT TransactionDetailId,TransactionId,AccountId,AccountName,AccountCode,IsDebit,IsCredit,ShortDescription," +
                            "DebitAmount,CreditAmount,InvoiceNo,DebitOrCredit FROM TransactionDetailTable WHERE InvoiceNo LIKE '" + invoiceNo + "'");

                        DataTable dataTransactionTable = await DatabaseAccess.RetriveAsync(subquery);
                        if(dataTransactionTable != null && dataTransactionTable.Rows.Count > 0)
                        {
                            this.Close();
                            Payment payment = new Payment(dataInvoice, dataTransactionTable);
                            payment.MdiParent = Application.OpenForms["Dashboard"];
                            await CommonFunction.DisposeOnCloseAsync(payment);
                            payment.Show();
                        }
                    }
                }
                else if (receiptradiobtn.Checked)
                {
                    string query = string.Format("SELECT TransactionId,InvoiceNo,Date,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol,ConversionRate," +
                        "CreatedAt,UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId,VoucherInfo FROM TransactionTable WHERE InvoiceNo LIKE '" + invoiceNo + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT TransactionDetailId,TransactionId,AccountId,AccountName,AccountCode,IsDebit,IsCredit,ShortDescription," +
                            "DebitAmount,CreditAmount,InvoiceNo,DebitOrCredit FROM TransactionDetailTable WHERE InvoiceNo LIKE '" + invoiceNo + "'");

                        DataTable dataTransactionTable = await DatabaseAccess.RetriveAsync(subquery);
                        if (dataTransactionTable != null && dataTransactionTable.Rows.Count > 0)
                        {
                            this.Close();
                            Receipts receipts = new Receipts(dataInvoice, dataTransactionTable);
                            receipts.MdiParent = Application.OpenForms["Dashboard"];
                            await CommonFunction.DisposeOnCloseAsync(receipts);
                            receipts.Show();
                        }
                    }
                }
            }catch (Exception ex) { throw ex; }
        }
    }
}
