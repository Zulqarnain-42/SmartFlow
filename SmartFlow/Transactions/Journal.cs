using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using SmartFlow.Transactions.CommonForm;
using SmartFlow.Transactions.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class Journal : Form
    {
        private int invoiceCounter = 1;
        public Journal()
        {
            InitializeComponent();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                string invoiceNo = CheckInvoiceBeforeInsert();
                DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                string transactionCode = Guid.NewGuid().ToString();
                string longdescription = longdescriptiontxtbox.Text;

                string tableName = "TransactionTable";
                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoicenotxtbox.Text },
                    { "InvoiceDate", invoicedatetxtbox.Text },
                    { "TransactionCode", transactionCode },
                    { "LongDescription", longdescription },
                    { "CurrencyId", currencyidlbl.Text },
                    { "CurrencyName", currencynamelbl.Text },
                    { "CurrencySymbol", currencysymbollbl.Text },
                    { "ConversionRate", currencyconversionratelbl.Text },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                    { "VoucherInfo", voucherinfotxtbox.Text }
                };

                int transactionid = DatabaseAccess.InsertDataId(tableName, columnData);
                if (transactionid > 0)
                {
                    foreach(DataGridViewRow row in dgvjournal.Rows)
                    {
                        if(row.IsNewRow) { continue; }

                        int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value.ToString());
                        string accountCode = row.Cells["accountcodecolumn"].Value.ToString();
                        string accountName = row.Cells["accountcolumn"].Value.ToString();
                        bool isdebitentry = Convert.ToBoolean(row.Cells["isdebitcolumn"].Value.ToString());
                        bool iscreditentry = Convert.ToBoolean(row.Cells["iscreditcolumn"].Value.ToString());
                        string shortdescription = row.Cells["shortnarationcolumn"].Value.ToString();
                        float debitamount = float.Parse(row.Cells["debitcolumn"].Value.ToString());
                        float creditamount = float.Parse(row.Cells["creditcolumn"].Value.ToString());
                        string debitorcredit = row.Cells["debitcreditcolumn"].Value.ToString();

                        string subTable = "TransactionDetailTable";
                        var subColumnData = new Dictionary<string, object>
                        {
                            { "TransactionId", transactionid },
                            { "TransactionCode", transactionCode },
                            { "AccountId", accountid },
                            { "AccountCode", accountCode },
                            { "AccountName", accountName },
                            { "IsDebit", isdebitentry },
                            { "IsCredit", iscreditentry },
                            { "ShortDescription", shortdescription },
                            { "DebitAmount", debitamount },
                            { "CreditAmount", creditamount }
                        };

                        bool isInserted = DatabaseAccess.ExecuteQuery(subTable, "INSERT", subColumnData);
                    }

                    JournalReportView journalReportView = new JournalReportView();
                    CommonFunction.DisposeOnClose(journalReportView);
                    journalReportView.Show();
                }
                else
                {
                    MessageBox.Show("Something is wrong!");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }
        private void Journal_Load(object sender, EventArgs e) 
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            invoicenotxtbox.Text = GenerateNextInvoiceNumber();
        }
        private void Journal_KeyDown(object sender, KeyEventArgs e)
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
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (amounttxtbox.Text.Trim().Length > 0) { return true; }
            if (longdescriptiontxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvjournal.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return GenerateNextInvoiceNumber();
                }
                else
                {
                    return invoicenotxtbox.Text;
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return null;
            }
        }
        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PI-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = DatabaseAccess.Retrive(query);
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInvoiceNumber;
        }
        private string GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (lastInvoiceNumber == null)
                {

                    // Generate the invoice number using the current date and a sequential number
                    string invoicepart = "JR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{sequentialPart}";

                    return newInvoiceNumber;
                    // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    string invoicepart = "JR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return null;
            }
        }
        private void amounttxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(amounttxtbox.Text) && !string.IsNullOrWhiteSpace(amounttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(DebitAndCreditForm));
                if (openForm == null)
                {
                    DebitAndCreditForm debitAndCreditForm = new DebitAndCreditForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    CommonFunction.DisposeOnClose(debitAndCreditForm);
                    debitAndCreditForm.FormClosed += delegate
                    {
                        string transactionsymbol = null;
                        int accountid = Convert.ToInt32(accountidlbl.Text);
                        string accountname = accountnametxtbox.Text;
                        string accountCode = accountcodetxtbox.Text;

                        bool productExists = false;
                        foreach (DataGridViewRow row in dgvjournal.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                if (row.Cells["accountidcolumn"].Value != null && row.Cells["accountidcolumn"].Value.ToString() == accountid.ToString())
                                {
                                    MessageBox.Show("Account Already Selected");
                                    productExists = true;
                                    break;
                                }
                            }
                        }

                        if (!productExists)
                        {
                            if (GlobalVariables.iscreditglobal == true)
                            {
                                decimal paymentamountcredit = decimal.Parse(amounttxtbox.Text);
                                transactionsymbol = "C";
                                dgvjournal.Rows.Add(null, transactionsymbol, accountname, accountCode, accountid, GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,
                                    null, paymentamountcredit, GlobalVariables.shortdescriptionglobal);
                            }

                            else if (GlobalVariables.isdebitglobal == true)

                            {
                                decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                                transactionsymbol = "D";
                                dgvjournal.Rows.Add(null, transactionsymbol, accountname, accountCode, accountid, GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,
                                    paymentamountdebit, null, GlobalVariables.shortdescriptionglobal);
                            }

                            accountcodetxtbox.Text = string.Empty;
                            accountnametxtbox.Text = string.Empty;
                            amounttxtbox.Text = string.Empty;
                            accountidlbl.Text = string.Empty;
                            GlobalVariables.iscreditglobal = false;
                            GlobalVariables.isdebitglobal = false;
                            GlobalVariables.shortdescriptionglobal = null;

                            accountnametxtbox.Focus();
                        }
                        
                    };
                    debitAndCreditForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void accountnametxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(accountnametxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if (openForm == null)
                {
                    AccountSelectionForm accountSelectionForm = new AccountSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    accountSelectionForm.FormClosed += delegate
                    {
                        UpdateAccountInfo();
                    };
                    CommonFunction.DisposeOnClose(accountSelectionForm);
                    accountSelectionForm.ShowDialog();

                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void accountnametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (string.IsNullOrEmpty(accountnametxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm accountSelectionForm = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountSelectionForm.FormClosed += delegate
                        {
                            UpdateAccountInfo();
                        };
                        CommonFunction.DisposeOnClose(accountSelectionForm);
                        accountSelectionForm.ShowDialog();

                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }
        private void UpdateAccountInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.accountnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.accountnameglobal) && 
                GlobalVariables.accountidglobal > 0)
            {
                accountnametxtbox.Text = GlobalVariables.accountnameglobal;
                accountidlbl.Text = GlobalVariables.accountidglobal.ToString();
            }
        }
    }
}
