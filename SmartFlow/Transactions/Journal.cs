using SixLabors.Fonts;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class Journal : Form
    {
        private int invoiceCounter = 1;
        private string transactionsymbol = string.Empty;
        private DataTable _dtInvoice;
        private DataTable _dtinvoicedetail;

        public Journal()
        {
            InitializeComponent();
        }

        public Journal(DataTable dtinvoice,DataTable dtinvoiceDetail)
        {
            InitializeComponent();
            this._dtInvoice = dtinvoice;
            this._dtinvoicedetail = dtinvoiceDetail;
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

                    string invoiceNo = string.Empty;
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
                        invoiceNo = invoicenotxtbox.Text;
                        string transactionCode = transactioncodelbl.Text;
                        string longdescription = longdescriptiontxtbox.Text;
                        int currencyid = Convert.ToInt32(currencyidlbl.Text);
                        string currencyname = currencynamelbl.Text;
                        string currencysymbol = currencysymbollbl.Text;
                        float currencyConversionRate = float.Parse(currencyconversionratelbl.Text);
                        int transactionId = Convert.ToInt32(transactionidlbl.Text);
                        string voucherInfo = voucherinfotxtbox.Text;

                        string transtableName = "TransactionTable";
                        string whereClause = "TransactionId = '" + transactionId + "'";
                        var columnData = new Dictionary<string, object>
                        {
                            { "InvoiceNo", invoiceNo },
                            { "InvoiceDate", invoiceDate },
                            { "TransactionCode", transactionCode },
                            { "LongDescription", longdescription },
                            { "CurrencyId", currencyidlbl.Text },
                            { "CurrencyName", currencynamelbl.Text },
                            { "CurrencySymbol", currencysymbollbl.Text },
                            { "ConversionRate", currencyconversionratelbl.Text },
                            { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                            { "UpdatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "VoucherInfo", voucherinfotxtbox.Text },
                            { "TransactionType", "Journal" }
                        };

                        bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(transtableName, "UPDATE", columnData, whereClause);
                        if (isUpdated)
                        {
                            bool isUpdatedSub = await UpdateTransactionDetailData(invoiceNo, transactionId, transactionCode, longdescription);
                            if (isUpdatedSub)
                            {
                                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                                longdescriptiontxtbox.Text = string.Empty;
                                voucherinfotxtbox.Text = string.Empty;
                                currencyidlbl.Text = string.Empty;
                                currencynamelbl.Text = string.Empty;
                                currencyconversionratelbl.Text = string.Empty;
                                currencysymbollbl.Text = string.Empty;

                                dgvjournal.Rows.Clear();
                                MessageBox.Show("Updated Successfully!");
                            }
                        }
                    }
                    else
                    {
                        invoiceNo = await CheckInvoiceBeforeInsert();
                        string transactionCode = Guid.NewGuid().ToString();
                        string longdescription = longdescriptiontxtbox.Text;

                        string tableName = "TransactionTable";
                        var columnData = new Dictionary<string, object>
                        {
                            { "InvoiceNo", invoiceNo },
                            { "InvoiceDate", invoiceDate },
                            { "TransactionCode", transactionCode },
                            { "LongDescription", longdescription },
                            { "CurrencyId", currencyidlbl.Text },
                            { "CurrencyName", currencynamelbl.Text },
                            { "CurrencySymbol", currencysymbollbl.Text },
                            { "ConversionRate", currencyconversionratelbl.Text },
                            { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "VoucherInfo", voucherinfotxtbox.Text },
                            { "TransactionType", "Journal" }
                        };

                        int transactionid = await DatabaseAccess.InsertDataIdAsync(tableName, columnData);
                        if (transactionid > 0)
                        {
                            bool isInserted = false;
                            foreach (DataGridViewRow row in dgvjournal.Rows)
                            {
                                if (row.IsNewRow) continue;

                                int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value?.ToString() ?? "0");
                                string accountCode = row.Cells["accountcodecolumn"].Value?.ToString() ?? "";
                                string accountName = row.Cells["accountcolumn"].Value?.ToString() ?? "";
                                bool isdebitentry = Convert.ToBoolean(row.Cells["isdebitcolumn"].Value?.ToString() ?? "false");
                                bool iscreditentry = Convert.ToBoolean(row.Cells["iscreditcolumn"].Value?.ToString() ?? "false");
                                decimal debitamount = decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal result) ? result : 0;
                                decimal creditamount = decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal resultcredit) ? resultcredit : 0;
                                string debitorcredit = row.Cells["debitcreditcolumn"].Value?.ToString() ?? "";
                                string shortnaration = row.Cells["narationcolumn"].Value?.ToString() ?? "";

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

                                bool insertResult = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                                await CommonFunction.InsertOrUpdateAccountStatementAsync(accountName, accountid, "Journal", invoiceNo, "", longdescription, 0, debitamount, creditamount, "", isdebitentry, iscreditentry, "", "");
                                if (insertResult)
                                {
                                    isInserted = true;
                                }
                            }
                            if (isInserted)
                            {
                                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
                                longdescriptiontxtbox.Text = string.Empty;
                                voucherinfotxtbox.Text = string.Empty;
                                currencyidlbl.Text = string.Empty;
                                currencynamelbl.Text = string.Empty;
                                currencyconversionratelbl.Text = string.Empty;
                                currencysymbollbl.Text = string.Empty;

                                dgvjournal.Rows.Clear();
                                MessageBox.Show("Saved Successfully!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Select Currency.");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private async Task<bool> UpdateTransactionDetailData(string invoiceNo, int transactionid, string transactionCode,string longdescription)
        {
            try
            {
                await DeleteTransactionData(invoiceNo);
                bool insertResult = false;

                List<Task<bool>> insertTasks = new List<Task<bool>>(); // Collect tasks for parallel execution

                foreach (DataGridViewRow row in dgvjournal.Rows)
                {
                    if (row.IsNewRow) { continue; }

                    int accountid = Convert.ToInt32(row.Cells["accountidcolumn"].Value.ToString());
                    string accountCode = row.Cells["accountcodecolumn"].Value.ToString();
                    string accountName = row.Cells["accountcolumn"].Value.ToString();

                    bool isdebitentry = bool.TryParse(row.Cells["isdebitcolumn"].Value.ToString(), out bool debitResult) && debitResult;
                    bool iscreditentry = bool.TryParse(row.Cells["iscreditcolumn"].Value.ToString(), out bool creditResult) && creditResult;

                    decimal debitamount = decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal result) ? result : 0;
                    decimal creditamount = decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal resultcredit) ? resultcredit : 0;
                    string debitorcredit = row.Cells["debitcreditcolumn"].Value.ToString();
                    string shortnaration = row.Cells["narationcolumn"].Value?.ToString() ?? "";

                    string subTable = "TransactionDetailTable";

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
                        { "InvoiceNo", invoiceNo },
                        { "DebitOrCredit", debitorcredit },
                        { "TransactionCode", transactionCode },
                        { "ShortDescription", shortnaration },
                        { "IsNewRecord", true }
                    };

                    insertResult = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                    await CommonFunction.InsertOrUpdateAccountStatementAsync(accountName, accountid, "Journal", invoiceNo, "", longdescription, 0, debitamount, creditamount, "", isdebitentry, iscreditentry, "", "");
                }

                // Wait for all insert queries to complete
                await Task.WhenAll(insertTasks);
                return insertResult;
            }
            catch (Exception ex) { throw ex; }
        }

        private async Task DeleteTransactionData(string invoiceNo)
        {
            try
            {
                string tableName = "TransactionDetailTable";
                string whereClause = "InvoiceNo = '" + invoiceNo + "'"; // Ensure parameterized query is correctly handled

                var columnData = new Dictionary<string, object>
                {
                    { "IsNewRecord", false } // Ensure parameter name matches placeholder
                };

                await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);
            }
            catch (Exception ex)
            {
                // Log the error instead of throwing it directly
                Console.WriteLine($"Error deleting transaction details: {ex.Message}");
                throw; // Rethrow to preserve original stack trace
            }
        }

        private async void Journal_Load(object sender, EventArgs e) 
        {
            if (_dtInvoice != null && _dtInvoice.Rows.Count > 0 || _dtinvoicedetail != null && _dtinvoicedetail.Rows.Count > 0)
            {
                DataRow row = _dtInvoice.Rows[0];

                // Safe conversion for date
                invoicedatetxtbox.Text = DateTime.TryParse(row["InvoiceDate"]?.ToString(), out DateTime invoiceDate)
                    ? invoiceDate.ToString("dd/MM/yyyy")
                    : DateTime.Now.ToString("dd/MM/yyyy");

                invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                longdescriptiontxtbox.Text = row["LongDescription"]?.ToString() ?? string.Empty;
                voucherinfotxtbox.Text = row["VoucherInfo"]?.ToString() ?? string.Empty;
                transactioncodelbl.Text = row["TransactionCode"]?.ToString() ?? string.Empty;
                transactionidlbl.Text = row["TransactionId"]?.ToString() ?? "0";
                currencyidlbl.Text = row["CurrencyId"]?.ToString() ?? "0";
                currencynamelbl.Text = row["CurrencyName"]?.ToString() ?? string.Empty;
                currencysymbollbl.Text = row["CurrencySymbol"]?.ToString() ?? string.Empty;
                currencyconversionratelbl.Text = row["ConversionRate"]?.ToString() ?? "0";
                currencylbl.Text = $"{currencynamelbl.Text} : {currencysymbollbl.Text}";

                foreach (DataRow transactiondetail in _dtinvoicedetail.Rows)
                {
                    int detailsRowIndex = dgvjournal.Rows.Add();
                    dgvjournal.Rows[detailsRowIndex].Cells["debitcreditcolumn"].Value = transactiondetail["DebitOrCredit"]?.ToString() ?? string.Empty;
                    dgvjournal.Rows[detailsRowIndex].Cells["accountcolumn"].Value = transactiondetail["AccountName"]?.ToString() ?? string.Empty;
                    dgvjournal.Rows[detailsRowIndex].Cells["accountcodecolumn"].Value = transactiondetail["AccountCode"]?.ToString() ?? string.Empty;
                    dgvjournal.Rows[detailsRowIndex].Cells["accountidcolumn"].Value = transactiondetail["AccountId"]?.ToString() ?? "0";
                    dgvjournal.Rows[detailsRowIndex].Cells["isdebitcolumn"].Value = Convert.ToBoolean(transactiondetail["IsDebit"] ?? false);
                    dgvjournal.Rows[detailsRowIndex].Cells["iscreditcolumn"].Value = Convert.ToBoolean(transactiondetail["IsCredit"] ?? false);
                    dgvjournal.Rows[detailsRowIndex].Cells["debitcolumn"].Value = float.TryParse(transactiondetail["DebitAmount"]?.ToString(), out float debit) ? debit : 0;
                    dgvjournal.Rows[detailsRowIndex].Cells["creditcolumn"].Value = float.TryParse(transactiondetail["CreditAmount"]?.ToString(), out float credit) ? credit : 0;
                    dgvjournal.Rows[detailsRowIndex].Cells["narationcolumn"].Value = transactiondetail["ShortDescription"];
                }

                dgvjournal.ResumeLayout();
                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
            }

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
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }

        private bool AreAnyTextBoxesFilled()
        {
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (amounttxtbox.Text.Trim().Length > 0) { return true; }
            if (longdescriptiontxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvjournal.Rows.Count > 0) { return true; }
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
                string query = "SELECT TOP 1 InvoiceNo FROM TransactionTable WHERE InvoiceNo LIKE 'JR-%' ORDER BY InvoiceNo DESC";
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

        private void ResetControl()
        {
            accountcodetxtbox.Text = string.Empty;
            accountnametxtbox.Text = string.Empty;
            amounttxtbox.Text = string.Empty;
            accountidlbl.Text = string.Empty;
            shortnarationtxtbox.Text = string.Empty;
            accountnametxtbox.Focus();
        }

        private bool ValidateDebitCreditBalance()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (DataGridViewRow row in dgvjournal.Rows)
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
        private async void accountnametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
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
                    string accountCode = e.AccountCode;
                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        accountidlbl.Text = accountid.ToString();
                        accountnametxtbox.Text = accountname.ToString();
                        accountcodetxtbox.Text = accountCode.ToString();
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

        private void dgvjournal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }

        private void dgvjournal_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Control key and D key are pressed
            if (e.Control && e.KeyCode == Keys.D)
            {
                // Check if at least one row is selected
                if (dgvjournal.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No row selected. Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure that the selected row has a valid product ID
                int productid = Convert.ToInt32(dgvjournal.CurrentRow.Cells["accountidcolumn"].Value);
                if (productid > 0)
                {
                    // Create a list to store rows to remove
                    var rowsToRemove = new List<DataGridViewRow>();

                    foreach (DataGridViewRow row in dgvjournal.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            rowsToRemove.Add(row);
                        }
                    }

                    // Remove rows outside of the loop to avoid modifying the collection while iterating
                    foreach (var row in rowsToRemove)
                    {
                        dgvjournal.Rows.Remove(row);
                    }
                }
                else
                {
                    MessageBox.Show("Select a valid product row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvjournal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            var row = dgvjournal.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvjournal.Columns["debitcolumn"].Index)
            {
                if (decimal.TryParse(row.Cells["debitcolumn"].Value?.ToString(), out decimal debit) && debit > 0)
                {
                    row.Cells["creditcolumn"].Value = "0"; // Set credit to zero if debit has value
                }
            }
            else if (e.ColumnIndex == dgvjournal.Columns["creditcolumn"].Index)
            {
                if (decimal.TryParse(row.Cells["creditcolumn"].Value?.ToString(), out decimal credit) && credit > 0)
                {
                    row.Cells["debitcolumn"].Value = "0"; // Set debit to zero if credit has value
                }
            }

            CalculateTotal();
        }

        private void dgvjournal_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();
        }

        private void dgvjournal_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal debitTotal = 0;
            decimal creditTotal = 0;

            foreach (DataGridViewRow row in dgvjournal.Rows)
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
            accountnametxtbox.Enabled = debitTotal != creditTotal;
            amounttxtbox.Enabled = debitTotal != creditTotal;
            shortnarationtxtbox.Enabled = debitTotal != creditTotal;
            debitamountradio.Enabled = debitTotal != creditTotal;
            creditamountradio.Enabled = debitTotal != creditTotal;
        }

        private void addbtn_Click(object sender, EventArgs e)
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

            int accountid = Convert.ToInt32(accountidlbl.Text);
            string accountname = accountnametxtbox.Text;
            string accountCode = accountcodetxtbox.Text;
            string shortnarationfrominvoice = shortnarationtxtbox.Text;

            bool productExists = false;

            if (!productExists)
            {
                // If it's the first entry, enforce debit
                if (debitamountradio.Checked)
                {
                    if (GlobalVariables.isdebitglobal)
                    {
                        decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "D";
                        dgvjournal.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, paymentamountdebit, null,
                            shortnarationfrominvoice);

                    }
                    else
                    {
                        decimal paymentamountcredit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "C";
                        dgvjournal.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, null, paymentamountcredit, shortnarationfrominvoice);

                    }
                }
                else
                {

                    // For subsequent entries, allow Debit or Credit based on flag
                    if (GlobalVariables.iscreditglobal)
                    {
                        decimal paymentamountcredit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "C";
                        dgvjournal.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, null, paymentamountcredit,
                            shortnarationfrominvoice);
                    }
                    else if (GlobalVariables.isdebitglobal)
                    {
                        decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                        GlobalVariables.transactionsymbol = "D";
                        dgvjournal.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid,
                            GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal, paymentamountdebit, null,
                            shortnarationfrominvoice);
                    }
                }

                // Reset controls after adding the row
                ResetControl();
            }
        }
    }
}
