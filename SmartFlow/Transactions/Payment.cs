using Microsoft.Identity.Client;
using SixLabors.Fonts;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Masters;
using SmartFlow.Sales;
using SmartFlow.Transactions.CommonForm;
using SmartFlow.Transactions.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class Payment : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dataInvoice;
        private DataTable _datatransactionTable;
        public Payment()
        {
            InitializeComponent();
        }
        public Payment(DataTable dataInvoice,DataTable datatransaction)
        {
            InitializeComponent();
            this._dataInvoice = dataInvoice;
            this._datatransactionTable = datatransaction;
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(currencyidlbl.Text) && currencyidlbl.Text != currencyidlbl.Name
                    && !string.IsNullOrEmpty(currencynamelbl.Text) && currencynamelbl.Text != currencynamelbl.Name
                    && !string.IsNullOrEmpty(currencysymbollbl.Text) && currencysymbollbl.Text != currencysymbollbl.Name
                    && !string.IsNullOrEmpty(currencyconversionratelbl.Text) && currencyconversionratelbl.Text != currencyconversionratelbl.Name)
                {
                    errorProvider.Clear();

                    if (!ValidateDebitCreditBalance())
                    {
                        MessageBox.Show("Debit And Credit Amount are not balanced!");
                        return;
                    }

                    string format = "dd/MM/yyyy";
                    var cultureInfo = new System.Globalization.CultureInfo("en-GB");
                    DateTime invoiceDate;

                    try
                    {
                        if (!DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                        {
                            invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid date format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        if (savebtn.Text == "UPDATE")
                        {
                            int transactionId = int.Parse(transactionidlbl.Text);
                            int currencyid = int.Parse(currencyidlbl.Text);

                            string tableName = "TransactionTable";
                            string whereClause = "TransactionId = '" + transactionId + "'";
                            string longdescription = longdescriptiontxtbox.Text;
                            var columnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoicenotxtbox.Text },
                                { "InvoiceDate", invoiceDate },
                                { "TransactionCode", transactioncodelbl.Text },
                                { "LongDescription",  longdescription},
                                { "CurrencyId", currencyid },
                                { "CurrencyName", currencynamelbl.Text },
                                { "CurrencySymbol", currencysymbollbl.Text },
                                { "ConversionRate", currencyconversionratelbl.Text },
                                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                { "VoucherInfo", voucherinfotxtbox.Text },
                                { "TransactionType", "Payment" }
                            };

                            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                            if (isUpdated)
                            {
                                UpdateTransactionDetailData(invoicenotxtbox.Text, transactionId, transactioncodelbl.Text, longdescription);
                                MessageBox.Show("Updated Successfully!");
                                this.Close();
                            }
                        }
                        else
                        {
                            string invoiceNo = await CheckInvoiceBeforeInsert();
                            string transactionCode = Guid.NewGuid().ToString();
                            int currencyid = int.Parse(currencyidlbl.Text);
                            string longdescription = longdescriptiontxtbox.Text;

                            var columnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceNo },
                                { "InvoiceDate", invoiceDate },
                                { "TransactionCode", transactionCode },
                                { "LongDescription", longdescription },
                                { "CurrencyId", currencyid },
                                { "CurrencyName", currencynamelbl.Text },
                                { "CurrencySymbol", currencysymbollbl.Text },
                                { "ConversionRate", currencyconversionratelbl.Text },
                                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                { "VoucherInfo", voucherinfotxtbox.Text },
                                { "TransactionType", "Payment" }
                            };

                            int transactionid = await DatabaseAccess.InsertDataIdAsync("TransactionTable", columnData);

                            if (transactionid > 0)
                            {
                                foreach (DataGridViewRow row in dgvPayment.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    try
                                    {
                                        int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value ?? "0");
                                        decimal debitamount = decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal result) ? result : 0;
                                        decimal creditamount = decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal resultcredit) ? resultcredit : 0;
                                        string accountcode = row.Cells["accountcodecolumn"].Value?.ToString() ?? "";
                                        string accountName = row.Cells["accountcolumn"].Value?.ToString() ?? "";
                                        bool isdebit = Convert.ToBoolean(row.Cells["isdebitcolumn"].Value ?? false);
                                        bool iscredit = Convert.ToBoolean(row.Cells["iscreditcolumn"].Value ?? false);
                                        string isdebitorcredit = row.Cells["debitcreditcolumn"].Value?.ToString() ?? "";
                                        string shortdescription = row.Cells["shortnarationcolumn"].Value?.ToString() ?? "";

                                        var subColumnData = new Dictionary<string, object>
                                        {
                                            { "TransactionId", transactionid },
                                            { "TransactionCode", transactionCode },
                                            { "AccountId", accountid },
                                            { "AccountCode", accountcode },
                                            { "AccountName", accountName },
                                            { "IsDebit", isdebit },
                                            { "IsCredit", iscredit },
                                            { "DebitAmount", debitamount },
                                            { "CreditAmount", creditamount },
                                            { "InvoiceNo", invoiceNo },
                                            { "DebitOrCredit", isdebitorcredit },
                                            { "ShortDescription", shortdescription },
                                            { "IsNewRecord", true } 
                                        };

                                        await DatabaseAccess.ExecuteQueryAsync("TransactionDetailTable", "INSERT", subColumnData);

                                        await CommonFunction.InsertOrUpdateAccountStatementAsync(accountName, accountid, "Payment", invoiceNo, "", longdescription, 0, debitamount,creditamount, "", isdebit, iscredit, "", "");

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error inserting transaction details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                this.Close();
                                var paymentReportView = new PaymentReportView(invoiceNo, false, true)
                                {
                                    MdiParent = Application.OpenForms["Dashboard"]
                                };
                                CommonFunction.DisposeOnClose(paymentReportView);
                                paymentReportView.Show();
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong while saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database operation failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UpdateTransactionDetailData(string invoiceNo, int transactionid, string transactionCode,string longdescription)
        {
            try
            {
                bool isolddata = await UpdateTransactionData(invoiceNo);
                if (isolddata) 
                {
                    bool isdeleted = await DeleteStatementData(invoiceNo);
                        foreach (DataGridViewRow row in dgvPayment.Rows)
                        {
                            if (row.IsNewRow) { continue; }

                            int accountid = row.Cells["accountidcolumn"].Value != null ? Convert.ToInt32(row.Cells["accountidcolumn"].Value) : 0;
                            string accountCode = row.Cells["accountcodecolumn"].Value?.ToString() ?? "";
                            string accountName = row.Cells["accountcolumn"].Value?.ToString() ?? "";
                            bool isdebitentry = bool.TryParse(row.Cells["isdebitcolumn"].Value?.ToString(), out bool debitResult) && debitResult;
                            bool iscreditentry = bool.TryParse(row.Cells["iscreditcolumn"].Value?.ToString(), out bool creditResult) && creditResult;
                            decimal debitamount = decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal debit) ? debit : 0;
                            decimal creditamount = decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal credit) ? credit : 0;
                            string debitorcredit = row.Cells["debitcreditcolumn"].Value?.ToString() ?? "";
                            string shortnaration = row.Cells["shortnarationcolumn"].Value?.ToString() ?? "";

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
                            { "DebitAmount", debitamount },
                            { "CreditAmount", creditamount },
                            { "InvoiceNo", invoiceNo },
                            { "DebitOrCredit", debitorcredit },
                            { "ShortDescription", shortnaration },
                            { "IsNewRecord", true }

                        };

                            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                            await CommonFunction.InsertOrUpdateAccountStatementAsync(accountName, accountid, "Payment", invoiceNo, "", longdescription, 0, debitamount, creditamount, "", isdebitentry, iscreditentry, "", "");

                        }
                   
                    

                    PaymentReportView paymentReportView = new PaymentReportView(invoiceNo, false, true);
                    paymentReportView.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(paymentReportView);
                    paymentReportView.Show();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Preserves stack trace
            }
        }


        private async Task<bool> UpdateTransactionData(string invoiceNo)
        {
            try
            {
                bool isoldrecord = false;
                string tableName = "TransactionDetailTable";
                string whereClause = "InvoiceNo = '" + invoiceNo + "'";

                var columnData = new Dictionary<string, object>
                {
                    { "IsNewRecord", false }
                };

                isoldrecord = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
                return isoldrecord;
            }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> DeleteStatementData(string invoiceNo)
        {
            try
            {
                bool isoldrecord = false;
                string tableName = "AccountStatementTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                isoldrecord = await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);
                return isoldrecord;
            }
            catch (Exception ex) { throw ex; }
        }

        private async void Payment_Load(object sender, EventArgs e)
        {
            try
            {
                if ((_dataInvoice != null && _dataInvoice.Rows.Count > 0) || (_datatransactionTable != null && _datatransactionTable.Rows.Count > 0))
                {
                    if (_dataInvoice != null && _dataInvoice.Rows.Count > 0)
                    {
                        try
                        {
                            DataRow row = _dataInvoice.Rows[0];
                            invoicedatetxtbox.Text = Convert.ToDateTime(row["InvoiceDate"]).ToString("dd-MM-yyyy");
                            invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                            longdescriptiontxtbox.Text = row["LongDescription"].ToString();
                            voucherinfotxtbox.Text = row["VoucherInfo"].ToString();
                            transactioncodelbl.Text = row["TransactionCode"].ToString();
                            transactionidlbl.Text = row["TransactionId"].ToString();
                            currencyidlbl.Text = row["CurrencyId"].ToString();
                            currencynamelbl.Text = row["CurrencyName"].ToString();
                            currencysymbollbl.Text = row["CurrencySymbol"].ToString();
                            currencyconversionratelbl.Text = row["ConversionRate"].ToString();
                            currencylbl.Text = $"{currencynamelbl.Text} : {currencysymbollbl.Text}";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error processing invoice data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (_datatransactionTable != null && _datatransactionTable.Rows.Count > 0)
                    {
                        try
                        {
                            foreach (DataRow transactiondetail in _datatransactionTable.Rows)
                            {
                                int detailsRowIndex = dgvPayment.Rows.Add();
                                dgvPayment.Rows[detailsRowIndex].Cells["debitcreditcolumn"].Value = transactiondetail["DebitOrCredit"];
                                dgvPayment.Rows[detailsRowIndex].Cells["accountcolumn"].Value = transactiondetail["AccountName"];
                                dgvPayment.Rows[detailsRowIndex].Cells["accountcodecolumn"].Value = transactiondetail["AccountCode"];
                                dgvPayment.Rows[detailsRowIndex].Cells["accountidcolumn"].Value = transactiondetail["AccountId"];
                                dgvPayment.Rows[detailsRowIndex].Cells["isdebitcolumn"].Value = transactiondetail["IsDebit"];
                                dgvPayment.Rows[detailsRowIndex].Cells["iscreditcolumn"].Value = transactiondetail["IsCredit"];
                                dgvPayment.Rows[detailsRowIndex].Cells["debitcolumn"].Value = transactiondetail["DebitAmount"];
                                dgvPayment.Rows[detailsRowIndex].Cells["creditcolumn"].Value = transactiondetail["CreditAmount"];
                                dgvPayment.Rows[detailsRowIndex].Cells["shortnarationcolumn"].Value = transactiondetail["ShortDescription"];
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error processing transaction data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    savebtn.Text = "UPDATE";
                }
                else
                {
                    try
                    {
                        invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        invoicenotxtbox.Text = await GenerateNextInvoiceNumber();

                        if (int.TryParse(paymentvoucheridlbl.Text, out int result))
                        {
                            FindRecord(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing new invoice entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private bool ValidateDebitCreditBalance()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (DataGridViewRow row in dgvPayment.Rows)
            {
                if (row.Cells["debitcolumn"].Value != null)
                {
                    decimal debit;
                    if (decimal.TryParse(row.Cells["debitcolumn"].Value.ToString(), out debit))
                    {
                        totalDebit += debit;
                    }
                }

                if (row.Cells["creditcolumn"].Value != null)
                {
                    decimal credit;
                    if (decimal.TryParse(row.Cells["creditcolumn"].Value.ToString(), out credit))
                    {
                        totalCredit += credit;
                    }
                }
            }

            return totalDebit == totalCredit;
        }

        private async void FindRecord(int paymentid)
        {
            try
            {
                string query = string.Format("SELECT TransactionId,InvoiceNo,Date,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol,ConversionRate,CreatedAt," +
                    "UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId FROM TransactionTable WHERE TransactionId = '" + paymentid + "'");
                DataTable dtpayment = await DatabaseAccess.RetriveAsync(query);

                if (dtpayment != null && dtpayment.Rows.Count > 0)
                {
                    paymentvoucheridlbl.Text = dtpayment.Rows[0]["TransactionId"].ToString();
                    invoicedatetxtbox.Text = dtpayment.Rows[0]["Date"].ToString();
                    invoicenotxtbox.Text = dtpayment.Rows[0]["InvoiceNo"].ToString();
                    longdescriptiontxtbox.Text = dtpayment.Rows[0]["LongDescription"].ToString();
                    transactioncodelbl.Text = dtpayment.Rows[0]["TransactionCode"].ToString();
                }

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Payment_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.C)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.DataSent += currencySelection_DataSent;
                currencySelection.ShowDialog();
            }
        }

        private void currencySelection_DataSent(CurrencyData receivedCurrency)
        {
            // Use the received data (e.g., display it in a label)
            currencylbl.Text = receivedCurrency.Name + (" : ") + receivedCurrency.Symbol;
            currencyidlbl.Text = receivedCurrency.CurrencyId.ToString();
            currencynamelbl.Text = receivedCurrency.Name.ToString();
            currencysymbollbl.Text = receivedCurrency.Symbol.ToString();
            currencystringlbl.Text = receivedCurrency.CurrencyString.ToString();
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (accountnametxtbox.Text.Trim().Length > 0) { return true; }
            if (amounttxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }

        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
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
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM TransactionTable WHERE InvoiceNo LIKE 'PA-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
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
        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (lastInvoiceNumber == null)
                {

                    // Generate the invoice number using the current date and a sequential number
                    string invoicepart = "PA";
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
                    string invoicepart = "PA";
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
        private async void accountnametxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(accountnametxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                if (openForm == null)
                {
                    AccountSelectionForm accountSelectionForm = new AccountSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    accountSelectionForm.AccountDataSelected += UpdateAccountInfo;

                    CommonFunction.DisposeOnClose(accountSelectionForm);
                    accountSelectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
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
                    string accountcode = e.AccountCode;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        accountidlbl.Text = accountid.ToString();
                        accountnametxtbox.Text = accountname.ToString();
                        accountheadidlbl.Text = accountheadid.ToString();
                        accountcodetxtbox.Text = accountcode.ToString();
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
        private void dgvPayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPayment != null)
            {
                if (dgvPayment.Rows.Count > 0)
                {
                    if(dgvPayment.SelectedRows.Count == 1)
                    {
                        accountcodetxtbox.Text = dgvPayment.CurrentRow.Cells[0].Value.ToString();
                        accountnametxtbox.Text = dgvPayment.CurrentRow.Cells["accountcolumn"].Value.ToString();
                        amounttxtbox.Text = dgvPayment.CurrentRow.Cells["debitcolumn"].Value.ToString();
                    }
                }
            }
        }
        private async void accountnametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(accountnametxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm accountSelection = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountSelection.AccountDataSelected += UpdateAccountInfo;

                        CommonFunction.DisposeOnClose(accountSelection);
                        accountSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private void dgvPayment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotal();
        }

        private void ResetControl()
        {
            accountnametxtbox.Text = string.Empty;
            accountcodetxtbox.Text = string.Empty;
            amounttxtbox.Text = string.Empty;
            accountidlbl.Text = string.Empty;
            shortnarationtxtbox.Text = string.Empty;
            accountnametxtbox.Focus();
        }

        private void dgvPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                // Ensure the current row has a valid product ID.
                var accountidCellValue = dgvPayment.CurrentRow?.Cells["accountidcolumn"].Value;
                if (accountidCellValue != null && int.TryParse(accountidCellValue.ToString(), out int accountid) && accountid > 0)
                {
                    // Check if there are any selected rows.
                    if (dgvPayment.SelectedRows.Count > 0)
                    {
                        // Collect rows to remove to avoid modifying the collection during iteration.
                        List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dgvPayment.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                rowsToRemove.Add(row);
                            }
                        }

                        // Remove the rows after collecting them.
                        foreach (var row in rowsToRemove)
                        {
                            dgvPayment.Rows.Remove(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select one or more rows to delete.", "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid row with a valid Product ID.", "Invalid Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    if (debitamountradio.Checked)
                    {
                        // Set flags for the first entry (Debit)
                        GlobalVariables.isdebitglobal = true;
                        GlobalVariables.iscreditglobal = false;
                    }
                    else
                    {
                        // For subsequent entries, set Credit flag
                        GlobalVariables.iscreditglobal = true;
                        GlobalVariables.isdebitglobal = false;
                    }
                }
                catch (Exception radioEx)
                {
                    MessageBox.Show($"Error selecting Debit/Credit: {radioEx.Message}", "Radio Button Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int accountid;
                decimal paymentAmount = 0;

                try
                {
                    // Parse account ID safely
                    if (!int.TryParse(accountidlbl.Text, out accountid))
                    {
                        MessageBox.Show("Invalid account ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Parse amount safely
                    if (!decimal.TryParse(amounttxtbox.Text, out paymentAmount) || paymentAmount <= 0)
                    {
                        MessageBox.Show("Invalid payment amount. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception parseEx)
                {
                    MessageBox.Show($"Error parsing input values: {parseEx.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string accountname = accountnametxtbox.Text;
                string accountCode = accountcodetxtbox.Text;
                string shortnarationfrominvoice = shortnarationtxtbox.Text;

                bool productExists = false;

                if (!productExists)
                {
                    try
                    {
                        // If it's the first entry, enforce debit
                        if (debitamountradio.Checked)
                        {
                            if (GlobalVariables.isdebitglobal)
                            {
                                GlobalVariables.transactionsymbol = "D";
                                dgvPayment.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                                    GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, paymentAmount, null,
                                    shortnarationfrominvoice);

                                creditamountradio.Checked = true;
                            }
                            else
                            {
                                GlobalVariables.transactionsymbol = "C";
                                dgvPayment.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                                    GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, null, paymentAmount,
                                    shortnarationfrominvoice);

                                debitamountradio.Checked = true;
                            }
                        }
                        else
                        {
                            // For subsequent entries, allow Debit or Credit based on flag
                            if (GlobalVariables.iscreditglobal)
                            {
                                GlobalVariables.transactionsymbol = "C";
                                dgvPayment.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                                    GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, null, paymentAmount,
                                    shortnarationfrominvoice);
                                debitamountradio.Checked = true;
                            }
                            else if (GlobalVariables.isdebitglobal)
                            {
                                GlobalVariables.transactionsymbol = "D";
                                dgvPayment.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                                    GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, paymentAmount, null,
                                    shortnarationfrominvoice);

                                creditamountradio.Checked = true;
                            }
                        }
                    }
                    catch (Exception dgvEx)
                    {
                        MessageBox.Show($"Error adding data to DataGridView: {dgvEx.Message}", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Reset controls after adding the row
                    try
                    {
                        ResetControl();
                    }
                    catch (Exception resetEx)
                    {
                        MessageBox.Show($"Error resetting controls: {resetEx.Message}", "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPayment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }

        private void dgvPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return; // Ignore header row

                if (e.RowIndex >= dgvPayment.Rows.Count)
                {
                    MessageBox.Show("Invalid row index.", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvPayment.Rows[e.RowIndex];

                if (e.ColumnIndex == dgvPayment.Columns["debitcolumn"].Index)
                {
                    try
                    {
                        if (decimal.TryParse(row.Cells["debitcolumn"]?.Value?.ToString(), out decimal debit) && debit > 0)
                        {
                            row.Cells["creditcolumn"].Value = "0"; // Set credit to zero if debit has value
                        }
                    }
                    catch (Exception debitEx)
                    {
                        MessageBox.Show($"Error processing debit value: {debitEx.Message}", "Debit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (e.ColumnIndex == dgvPayment.Columns["creditcolumn"].Index)
                {
                    try
                    {
                        if (decimal.TryParse(row.Cells["creditcolumn"]?.Value?.ToString(), out decimal credit) && credit > 0)
                        {
                            row.Cells["debitcolumn"].Value = "0"; // Set debit to zero if credit has value
                        }
                    }
                    catch (Exception creditEx)
                    {
                        MessageBox.Show($"Error processing credit value: {creditEx.Message}", "Credit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                try
                {
                    CalculateTotal();
                }
                catch (Exception calcEx)
                {
                    MessageBox.Show($"Error calculating total: {calcEx.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvPayment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total: {ex.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool hasCredit = false;
            bool hasDebit = false;

            try
            {
                foreach (DataGridViewRow row in dgvPayment.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row

                    if (row.Cells["debitcolumn"]?.Value != null &&
                        decimal.TryParse(row.Cells["debitcolumn"].Value.ToString(), out decimal debit) &&
                        debit > 0)
                    {
                        hasDebit = true;
                    }

                    if (row.Cells["creditcolumn"]?.Value != null &&
                        decimal.TryParse(row.Cells["creditcolumn"].Value.ToString(), out decimal credit) &&
                        credit > 0)
                    {
                        hasCredit = true;
                    }

                    if (hasCredit && hasDebit)
                        break; // Exit early if both are found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment data: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (hasCredit)
                {
                    debitamountradio.Checked = true;
                    creditamountradio.Checked = false;
                }
                else if (hasDebit)
                {
                    creditamountradio.Checked = true;
                    debitamountradio.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating radio button selection: {ex.Message}", "UI Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CalculateTotal()
        {
            try
            {
                decimal debitTotal = 0;
                decimal creditTotal = 0;

                // Check if DataGridView has rows (excluding the new row)
                bool hasRows = dgvPayment.Rows.Cast<DataGridViewRow>().Any(row => !row.IsNewRow);

                foreach (DataGridViewRow row in dgvPayment.Rows)
                {
                    try
                    {
                        if (row.IsNewRow) continue; // Skip the new row

                        // Process Debit Column
                        if (row.Cells["debitcolumn"].Value != null && decimal.TryParse(row.Cells["debitcolumn"].Value.ToString(), out decimal debit))
                        {
                            debitTotal += debit;
                        }

                        // Process Credit Column
                        if (row.Cells["creditcolumn"].Value != null && decimal.TryParse(row.Cells["creditcolumn"].Value.ToString(), out decimal credit))
                        {
                            creditTotal += credit;
                        }
                    }
                    catch (Exception rowEx)
                    {
                        MessageBox.Show($"Error processing row data: {rowEx.Message}", "Row Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                try
                {
                    totaldebitvaluelbl.Text = $"{debitTotal:N2}";
                    totalcreditvaluelbl.Text = $"{creditTotal:N2}";

                    // Enable textboxes and radio buttons if DataGridView is empty OR if totals do not match
                    bool enableControls = !hasRows || (debitTotal != creditTotal);
                    accountnametxtbox.Enabled = enableControls;
                    amounttxtbox.Enabled = enableControls;
                    shortnarationtxtbox.Enabled = enableControls;
                    debitamountradio.Enabled = enableControls;
                    creditamountradio.Enabled = enableControls;
                }
                catch (Exception controlEx)
                {
                    MessageBox.Show($"Error updating UI controls: {controlEx.Message}", "UI Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
