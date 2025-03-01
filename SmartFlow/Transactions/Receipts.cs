using SixLabors.Fonts;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
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
    public partial class Receipts : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dataInvoice;
        private DataTable _dataInvoiceDetails;
        public Receipts()
        {
            InitializeComponent();
        }

        public Receipts(DataTable dataInvoice,DataTable dataInvoicedetail)
        {
            InitializeComponent();
            this._dataInvoice = dataInvoice;
            this._dataInvoiceDetails = dataInvoicedetail;
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

                    // Define the custom date format and UK culture
                    string format = "dd/MM/yyyy";
                    var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture

                    // Parse startDate and endDate from the textboxes using the custom format
                    DateTime invoiceDate;

                    // Try parsing the dates from the textboxes with the exact format
                    if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out invoiceDate))
                    {
                        // Date parsing was successful
                        Console.WriteLine($"Start Date: {invoiceDate}");
                    }
                    else
                    {
                        invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    }

                    if (savebtn.Text == "UPDATE")
                    {
                        string invoiceNo = invoicenotxtbox.Text;
                        int transactionId = Convert.ToInt32(transactionidlbl.Text);
                        string transactionCode = transactioncodelbl.Text;
                        string longdescription = longdescriptiontxtbox.Text;
                        int currencyid = Convert.ToInt32(currencyidlbl.Text);
                        string currencyname = currencynamelbl.Text;
                        string currencysymbol = currencysymbollbl.Text;
                        string currencyconversionrate = currencyconversionratelbl.Text;
                        string voucherinfo = voucherinfotxtbox.Text;

                        string tableName = "TransactionTable";
                        string whereClause = "TransactionId = '" + transactionId + "'";
                        var columnData = new Dictionary<string, object>
                        {
                            { "InvoiceNo", invoiceNo },
                            { "InvoiceDate", invoiceDate },
                            { "TransactionCode", transactionCode },
                            { "LongDescription", longdescription },
                            { "CurrencyId", currencyid },
                            { "CurrencyName", currencyname},
                            { "CurrencySymbol", currencysymbol },
                            { "ConversionRate", currencyconversionrate },
                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "VoucherInfo", voucherinfo },
                            { "TransactionType", "Receipts" }
                        };

                        bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);

                        if (isUpdated)
                        {
                            UpdateTransactionDetailData(invoiceNo, transactionId, transactionCode,longdescription);
                        }
                    }
                    else
                    {
                        string invoiceNo = await CheckInvoiceBeforeInsert();
                        string transactionCode = Guid.NewGuid().ToString();
                        string longdescription = longdescriptiontxtbox.Text;
                        int currencyid = Convert.ToInt32(currencyidlbl.Text);
                        string currencyname = currencynamelbl.Text;
                        string currencysymbol = currencysymbollbl.Text;
                        string currencyconversionrate = currencyconversionratelbl.Text;
                        string voucherinfo = voucherinfotxtbox.Text;

                        string tableName = "TransactionTable";
                        var columnData = new Dictionary<string, object>
                        {
                            { "InvoiceNo", invoiceNo },
                            { "InvoiceDate", invoiceDate },
                            { "TransactionCode", transactionCode },
                            { "LongDescription", longdescription },
                            { "CurrencyId", currencyid },
                            { "CurrencyName", currencyname},
                            { "CurrencySymbol", currencysymbol },
                            { "ConversionRate", currencyconversionrate },
                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "VoucherInfo", voucherinfo },
                            { "TransactionType", "Receipts" }
                        };

                        int transactionid = await DatabaseAccess.InsertDataIdAsync(tableName, columnData);

                        if (transactionid > 0)
                        {
                            foreach (DataGridViewRow row in dgvReceipts.Rows)
                            {
                                if (row.IsNewRow) { continue; }

                                int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value?.ToString() ?? "0");
                                string accountCode = row.Cells["accountcodecolumn"].Value?.ToString() ?? "";
                                string accountName = row.Cells["accountcolumn"].Value?.ToString() ?? "";
                                bool isdebitentry = Convert.ToBoolean(row.Cells["isdebitcolumn"].Value?.ToString() ?? "false");
                                bool iscreditentry = Convert.ToBoolean(row.Cells["iscreditcolumn"].Value?.ToString() ?? "false");
                                decimal debitamount = decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal result) ? result : 0;
                                decimal creditamount = decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal resultcredit) ? resultcredit : 0;
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
                                    { "IsNewRecord", true },
                                };

                                bool isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                                await CommonFunction.InsertOrUpdateAccountStatementAsync(accountName, accountid, "Receipts", invoiceNo, "", longdescription, 0, debitamount, creditamount, "", isdebitentry, iscreditentry, "", "");
                            }

                            this.Close();
                            ReceiptReportView receiptReportView = new ReceiptReportView(invoiceNo, true, false);
                            receiptReportView.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(receiptReportView);
                            receiptReportView.Show();
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency!");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private bool ValidateDebitCreditBalance()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (DataGridViewRow row in dgvReceipts.Rows)
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

        private async void UpdateTransactionDetailData(string invoiceNo, int transactionid, string transactionCode,string longdescription)
        {
            try
            {
                bool isoldrecord = await UpdateTransactionData(invoiceNo);
                if (isoldrecord)
                {
                    bool isdeleted = await DeleteStatementData(invoiceNo);
                        foreach (DataGridViewRow row in dgvReceipts.Rows)
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
                            await CommonFunction.InsertOrUpdateAccountStatementAsync(accountName, accountid, "Receipts", invoiceNo, "", longdescription, 0, debitamount, creditamount, "", isdebitentry, iscreditentry, "", "");
                            await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                        }
                    

                    ReceiptReportView receiptReportView = new ReceiptReportView(invoiceNo, true, false);
                    receiptReportView.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(receiptReportView);
                    receiptReportView.Show();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Preserve original stack trace
            }
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
        private async void InsertTransactionDetail(string invoiceNo, int transactionid)
        {
            try
            {
                foreach (DataGridViewRow row in dgvReceipts.Rows)
                {
                    if (row.IsNewRow) { continue; }

                    int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value.ToString());
                    string accountCode = row.Cells["accountcodecolumn"].Value.ToString();
                    string accountName = row.Cells["accountcolumn"].Value.ToString();
                    bool isdebitentry = Convert.ToBoolean(row.Cells["isdebitcolumn"].Value.ToString());
                    bool iscreditentry = Convert.ToBoolean(row.Cells["iscreditcolumn"].Value.ToString());
                    float debitamount = float.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out float result) ? result : 0;
                    float creditamount = float.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out float resultcredit) ? resultcredit : 0;
                    string debitorcredit = row.Cells["debitcreditcolumn"].Value.ToString();

                    string subTable = "TransactionDetailBackUpTable";
                    var subColumnData = new Dictionary<string, object>
                            {
                                { "TransactionId", transactionid },
                                { "AccountId", accountid },
                                { "AccountCode", accountCode },
                                { "AccountName", accountName },
                                { "IsDebit", isdebitentry },
                                { "IsCredit", iscreditentry },
                                { "DebitAmount", debitamount },
                                { "CreditAmount", creditamount },
                                { "InvoiceNo", invoiceNo }
                            };

                    bool isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private async void Receipts_Load(object sender, EventArgs e)
        {
            if (_dataInvoice != null && _dataInvoice.Rows.Count > 0 || _dataInvoiceDetails != null && _dataInvoiceDetails.Rows.Count > 0) 
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

                foreach (DataRow transactiondetail in _dataInvoiceDetails.Rows)
                {
                    int detailsRowIndex = dgvReceipts.Rows.Add();
                    dgvReceipts.Rows[detailsRowIndex].Cells["debitcreditcolumn"].Value = transactiondetail["DebitOrCredit"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["accountcolumn"].Value = transactiondetail["AccountName"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["accountcodecolumn"].Value = transactiondetail["AccountCode"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["accountidcolumn"].Value = transactiondetail["AccountId"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["isdebitcolumn"].Value = transactiondetail["IsDebit"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["iscreditcolumn"].Value = transactiondetail["IsCredit"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["debitcolumn"].Value = transactiondetail["DebitAmount"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["creditcolumn"].Value = transactiondetail["CreditAmount"];
                    dgvReceipts.Rows[detailsRowIndex].Cells["shortnarationcolumn"].Value = transactiondetail["ShortDescription"];
                }

                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
            }
        }

        private void Receipts_KeyDown(object sender, KeyEventArgs e)
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
            if(accountnametxtbox.Text.Trim().Length > 0) { return true; }
            if(amounttxtbox.Text.Trim().Length > 0) { return true; }
            if(longdescriptiontxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvReceipts.Rows.Count > 0) { return true; }
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
                string query = "SELECT TOP 1 InvoiceNo FROM TransactionTable WHERE InvoiceNo LIKE 'RE-%' ORDER BY InvoiceNo DESC";
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
                    string invoicepart = "RE";
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
                    string invoicepart = "RE";
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
                    AccountSelectionForm accountsSelection = new AccountSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    accountsSelection.AccountDataSelected += UpdateAccountInfo;

                    CommonFunction.DisposeOnClose(accountsSelection);
                    accountsSelection.ShowDialog();
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
        private async void accountnametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(accountnametxtbox.Text))
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

        private void dgvReceipts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                // Ensure the current row has a valid product ID.
                var accountidCellValue = dgvReceipts.CurrentRow?.Cells["accountidcolumn"].Value;
                if (accountidCellValue != null && int.TryParse(accountidCellValue.ToString(), out int accountid) && accountid > 0)
                {
                    // Check if there are any selected rows.
                    if (dgvReceipts.SelectedRows.Count > 0)
                    {
                        // Collect rows to remove to avoid modifying the collection during iteration.
                        List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dgvReceipts.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                rowsToRemove.Add(row);
                            }
                        }

                        // Remove the rows after collecting them.
                        foreach (var row in rowsToRemove)
                        {
                            dgvReceipts.Rows.Remove(row);
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

        private void dgvReceipts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }

        private void dgvReceipts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal debitTotal = 0;
            decimal creditTotal = 0;

            // Check if DataGridView has rows (excluding the new row)
            bool hasRows = dgvReceipts.Rows.Cast<DataGridViewRow>().Any(row => !row.IsNewRow);

            foreach (DataGridViewRow row in dgvReceipts.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row

                if (decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal debit))
                {
                    debitTotal += debit;
                }

                if (decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal credit))
                {
                    creditTotal += credit;
                }
            }

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

        private void dgvReceipts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();

            // Check if there are any remaining credit or debit entries
            bool hasCredit = false;
            bool hasDebit = false;

            foreach (DataGridViewRow row in dgvReceipts.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row

                decimal debit = row.Cells["debitcolumn"].Value != null ? Convert.ToDecimal(row.Cells["debitcolumn"].Value) : 0;
                decimal credit = row.Cells["creditcolumn"].Value != null ? Convert.ToDecimal(row.Cells["creditcolumn"].Value) : 0;

                if (debit > 0)
                    hasDebit = true;
                if (credit > 0)
                    hasCredit = true;

                if (hasCredit && hasDebit) // If both exist, no need to continue checking
                    break;
            }

            // If no more Credit entries exist, check the Debit checkbox
            if (hasCredit)
            {
                debitamountradio.Checked = true;
                creditamountradio.Checked = false;
            }
            // If no more Debit entries exist, check the Credit checkbox
            else if (hasDebit)
            {
                creditamountradio.Checked = true;
                debitamountradio.Checked = false;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (creditamountradio.Checked)
            {
                // Set flags for the first entry (Credit)
                GlobalVariables.iscreditglobal = true;
                GlobalVariables.isdebitglobal = false;
            }
            else
            {
                // For subsequent entries, set Debit flag
                GlobalVariables.isdebitglobal = true;
                GlobalVariables.iscreditglobal = false;
            }

            int accountid = Convert.ToInt32(accountidlbl.Text);
            string accountname = accountnametxtbox.Text;
            string accountCode = accountcodetxtbox.Text;
            string shortnarationfrominvoice = shortnarationtxtbox.Text;

            bool productExists = false;

            if (!productExists)
            {
                if (creditamountradio.Checked)
                {
                    if (GlobalVariables.iscreditglobal)
                    {
                        decimal paymentamountcredit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "C"; // First transaction should be Credit
                        dgvReceipts.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,  null, paymentamountcredit,
                            shortnarationfrominvoice);

                        debitamountradio.Checked = true;
                    }
                    else
                    {
                        decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "D"; // Subsequent transactions should be Debit
                        dgvReceipts.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, paymentamountdebit, null,
                            shortnarationfrominvoice);

                        creditamountradio.Checked = true;
                    }
                }
                else
                {
                    // For subsequent entries, allow Debit or Credit based on flag
                    if (GlobalVariables.isdebitglobal)
                    {
                        decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "D"; // Subsequent transactions should be Debit
                        dgvReceipts.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, paymentamountdebit, null,
                            shortnarationfrominvoice);

                        creditamountradio.Checked = true;
                    }
                    else if (GlobalVariables.iscreditglobal)
                    {
                        decimal paymentamountcredit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "C";
                        dgvReceipts.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,  null, paymentamountcredit,
                            shortnarationfrominvoice);

                        debitamountradio.Checked = true;
                    }
                }

                // Reset controls after adding the row
                ResetControl();
            }

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
    }
}
