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
    public partial class DetailPayment : Form
    {
        private DataTable _invoiceData;
        public DetailPayment()
        {
            InitializeComponent();
        }

        public DetailPayment(DataTable invoiceData)
        {
            InitializeComponent();
            _invoiceData = invoiceData;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailPayment_Load(object sender, EventArgs e)
        {
            DataTable formattedTable = FormatTransactionData(_invoiceData);

            dgvlistinvoices.DataSource = formattedTable;
            dgvlistinvoices.Columns["Vch/Bill No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["HIDDENINVOICE"].Visible = false;

            decimal totalDebit = formattedTable.AsEnumerable()
                .Where(row => !string.IsNullOrEmpty(row["Debit(AED)"].ToString()))
                .Sum(row => Convert.ToDecimal(row["Debit(AED)"]));

            decimal totalCredit = formattedTable.AsEnumerable()
                .Where(row => !string.IsNullOrEmpty(row["Credit(AED)"].ToString()))
                .Sum(row => Convert.ToDecimal(row["Credit(AED)"]));

            totaldebitvaluelbl.Text = totalDebit.ToString("N2") + " AED";
            totalcreditvaluelbl.Text = totalCredit.ToString("N2") + " AED";
        }

        private DataTable FormatTransactionData(DataTable dt)
        {
            DataTable formattedTable = new DataTable();
            formattedTable.Columns.Add("Date", typeof(string));
            formattedTable.Columns.Add("Vch/Bill No", typeof(string));
            formattedTable.Columns.Add("Account", typeof(string));
            formattedTable.Columns.Add("Debit(AED)", typeof(string));
            formattedTable.Columns.Add("Credit(AED)", typeof(string));
            formattedTable.Columns.Add("Notes", typeof(string));
            formattedTable.Columns.Add("HIDDENINVOICE", typeof(string));

            string lastInvoiceNo = "";
            string lastDate = "";

            foreach (DataRow row in dt.Rows)
            {
                string invoiceDate = Convert.ToDateTime(row["InvoiceDate"]).ToString("dd-MM-yyyy");
                string invoiceNo = row["InvoiceNo"].ToString();
                string account = row["AccountName"].ToString();
                // Convert Debit and Credit Amount, replacing "0.00" with an empty string
                decimal debitValue = row["DebitAmount"] != DBNull.Value ? Convert.ToDecimal(row["DebitAmount"]) : 0;
                decimal creditValue = row["CreditAmount"] != DBNull.Value ? Convert.ToDecimal(row["CreditAmount"]) : 0;

                string debitAmount = debitValue == 0 ? "" : debitValue.ToString("N2");
                string creditAmount = creditValue == 0 ? "" : creditValue.ToString("N2");

                string hiddeninvoice = row["HIDDENINVOICE"].ToString();
                string notes = row["ShortDescription"].ToString();

                // Show Invoice Date and No only once per transaction
                if (invoiceNo != lastInvoiceNo)
                {
                    formattedTable.Rows.Add(invoiceDate, invoiceNo, account, debitAmount, creditAmount, notes, hiddeninvoice);
                    lastInvoiceNo = invoiceNo;
                    lastDate = invoiceDate;
                }
                else
                {
                    formattedTable.Rows.Add("", "", account, debitAmount, creditAmount, notes, hiddeninvoice);
                }
            }

            return formattedTable;
        }

        private async void dgvlistinvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var invoiceNo = dgvlistinvoices.Rows[e.RowIndex].Cells["HIDDENINVOICE"].Value.ToString();

                string query = string.Format("SELECT TransactionId,InvoiceNo,InvoiceDate,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol," +
                    "ConversionRate,CreatedAt,UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId,VoucherInfo FROM TransactionTable WHERE InvoiceNo LIKE '" + invoiceNo + "'");

                DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                if (dataInvoice.Rows.Count > 0)
                {
                    string subquery = string.Format("SELECT TransactionDetailId,TransactionId,AccountId,AccountName,AccountCode,IsDebit,IsCredit,ShortDescription,DebitAmount,CreditAmount," +
                        "InvoiceNo,DebitOrCredit,TransactionCode FROM TransactionDetailTable WHERE InvoiceNo LIKE '" + invoiceNo + "' AND IsNewRecord = '" + true + "'");

                    DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                    if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
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
        }

        private async void dgvlistinvoices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvlistinvoices.CurrentRow != null)
                {
                    var invoiceNo = dgvlistinvoices.CurrentRow.Cells["HIDDENINVOICE"].Value.ToString();

                    string query = string.Format("SELECT TransactionId,InvoiceNo,InvoiceDate,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol," +
                        "ConversionRate,CreatedAt,UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId,VoucherInfo FROM TransactionTable WHERE InvoiceNo LIKE '" + invoiceNo + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT TransactionDetailId,TransactionId,AccountId,AccountName,AccountCode,IsDebit,IsCredit,ShortDescription,DebitAmount,CreditAmount," +
                            "InvoiceNo,DebitOrCredit,TransactionCode FROM TransactionDetailTable WHERE InvoiceNo LIKE '" + invoiceNo + "' AND IsNewRecord = '" + true + "'");

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                        if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
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
            }
        }
    }
}
