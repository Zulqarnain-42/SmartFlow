using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using SmartFlow.Transactions.CommonForm;
using SmartFlow.Transactions.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
                errorProvider.Clear();

                if(savebtn.Text == "UPDATE")
                {
                    string invoiceNo = invoicenotxtbox.Text;
                    int transactionId = Convert.ToInt32(transactionidlbl.Text);
                    DateTime inoviceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string transactionCode = transactioncodelbl.Text;
                    string longdescription = longdescriptiontxtbox.Text;


                    string tableName = "TransactionTable";
                    string whereClause = "TransactionId = '" + transactionId + "'";
                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "Date", inoviceDate },
                        { "TransactionCode", transactionCode },
                        { "LongDescription", longdescription },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "VoucherInfo", voucherinfotxtbox.Text }
                    };

                    bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);

                    if (isUpdated)
                    {
                        UpdateTransactionDetailData(invoiceNo, transactionId);
                        PaymentReportView paymentReportView = new PaymentReportView(invoiceNo);
                        paymentReportView.MdiParent = Application.OpenForms["Dashboard"];
                        await CommonFunction.DisposeOnCloseAsync(paymentReportView);
                        paymentReportView.Show();
                    }
                }
                else
                {
                    string invoiceNo = await CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string transactionCode = Guid.NewGuid().ToString();
                    string longdescription = longdescriptiontxtbox.Text;

                    string tableName = "TransactionTable";
                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceNo },
                        { "Date", invoiceDate },
                        { "TransactionCode", transactionCode },
                        { "LongDescription", longdescription },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "VoucherInfo", voucherinfotxtbox.Text }
                    };

                    int transactionid = await DatabaseAccess.InsertDataIdAsync(tableName, columnData);
                    if (transactionid > 0)
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
                                { "InvoiceNo", invoiceNo }
                            };

                            bool isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);

                        }

                        ReceiptReportView receiptReportView = new ReceiptReportView(invoiceNo);
                        receiptReportView.MdiParent = Application.OpenForms["Dashboard"];
                        await CommonFunction.DisposeOnCloseAsync(receiptReportView);
                        receiptReportView.Show();
                    }
                    else
                    {
                        MessageBox.Show("Something is wrong!");
                    }
                }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }
        private async void UpdateTransactionDetailData(string invoiceNo, int transactionid)
        {
            try
            {
                InsertTransactionDetail(invoiceNo, transactionid);
                DeleteTransactionData(invoiceNo);
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
                                { "InvoiceNo", invoiceNo }
                            };

                    bool isInserted = await DatabaseAccess.ExecuteQueryAsync(subTable, "INSERT", subColumnData);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private async void DeleteTransactionData(string invoiceNo)
        {
            try
            {
                string tableName = "TransactionDetailTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

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
            if (_dataInvoice != null && _dataInvoice.Rows.Count > 0 && _dataInvoiceDetails != null && _dataInvoiceDetails.Rows.Count > 0) 
            {
                DataRow row = _dataInvoice.Rows[0];
                invoicedatetxtbox.Text = Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy");
                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                longdescriptiontxtbox.Text = row["LongDescription"].ToString();
                voucherinfotxtbox.Text = row["VoucherInfo"].ToString();
                transactioncodelbl.Text = row["TransactionCode"].ToString();
                transactionidlbl.Text = row["TransactionId"].ToString();

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
        
        private async void amounttxtbox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amounttxtbox.Text) && !string.IsNullOrWhiteSpace(amounttxtbox.Text)) { 
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(DebitAndCreditForm));
                
                if (openForm == null)
                {
                    DebitAndCreditForm debitAndCreditForm = new DebitAndCreditForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    await CommonFunction.DisposeOnCloseAsync(debitAndCreditForm);
                    debitAndCreditForm.FormClosed += delegate
                    {
                        int accountid = Convert.ToInt32(accountidlbl.Text);
                        string accountname = accountnametxtbox.Text;
                        string accountCode = accountcodetxtbox.Text;

                        bool productExists = false;
                        foreach (DataGridViewRow row in dgvReceipts.Rows)
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
                                GlobalVariables.transactionsymbol = "C";
                                dgvReceipts.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid, GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,
                                    null, paymentamountcredit, GlobalVariables.shortdescriptionglobal);
                            }

                            else if (GlobalVariables.isdebitglobal == true)

                            {
                                decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                                GlobalVariables.transactionsymbol = "D";
                                dgvReceipts.Rows.Add(null, GlobalVariables.transactionsymbol, accountname, accountCode, accountid, GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,
                                    paymentamountdebit, null, GlobalVariables.shortdescriptionglobal);
                            }

                            accountcodetxtbox.Text = string.Empty;
                            accountnametxtbox.Text = string.Empty;
                            amounttxtbox.Text = string.Empty;
                            accountidlbl.Text = string.Empty;

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

                    await CommonFunction.DisposeOnCloseAsync(accountsSelection);
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

        private void dgvReceipts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                // Ensure the current row has a valid product ID.
                var productidCellValue = dgvReceipts.CurrentRow?.Cells[1].Value;
                if (productidCellValue != null && int.TryParse(productidCellValue.ToString(), out int productid) && productid > 0)
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
    }
}
