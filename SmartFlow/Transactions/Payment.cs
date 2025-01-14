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
        private void savebtn_Click(object sender, EventArgs e)
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

                    bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);

                    if (isUpdated)
                    {
                        UpdateTransactionDetailData(invoiceNo,transactionId);
                        PaymentReportView paymentReportView = new PaymentReportView(invoiceNo);
                        paymentReportView.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(paymentReportView);
                        paymentReportView.Show();
                    }
                }
                else
                {
                    string invoiceNo = CheckInvoiceBeforeInsert();
                    DateTime inoviceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string transactionCode = Guid.NewGuid().ToString();
                    string longdescription = longdescriptiontxtbox.Text;

                    string tableName = "TransactionTable";
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

                    int transactionid = DatabaseAccess.InsertDataId(tableName, columnData);

                    if (transactionid > 0)
                    {
                        foreach (DataGridViewRow row in dgvPayment.Rows)
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

                            bool isInserted = DatabaseAccess.ExecuteQuery(subTable, "INSERT", subColumnData);
                        }

                        PaymentReportView paymentReportView = new PaymentReportView(invoiceNo);
                        paymentReportView.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(paymentReportView);
                        paymentReportView.Show();
                    }
                    else
                    {
                        MessageBox.Show("Something is wrong!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateTransactionDetailData(string invoiceNo,int transactionid)
        {
            try
            {
                InsertTransactionDetail(invoiceNo,transactionid);
                DeleteTransactionData(invoiceNo);
                foreach (DataGridViewRow row in dgvPayment.Rows)
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

                    bool isInserted = DatabaseAccess.ExecuteQuery(subTable, "INSERT", subColumnData);
                }
            }
            catch(Exception ex) { throw ex; }
        }

        private void DeleteTransactionData(string invoiceNo)
        {
            try
            {
                string tableName = "TransactionDetailTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                DatabaseAccess.ExecuteQuery(tableName, "DELETE", columnData, whereClause);

            }
            catch (Exception ex) { throw ex; }
        }
        private void InsertTransactionDetail(string invoiceNo, int transactionid)
        {
            try
            {
                foreach (DataGridViewRow row in dgvPayment.Rows)
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

                    bool isInserted = DatabaseAccess.ExecuteQuery(subTable, "INSERT", subColumnData);
                }
            }
            catch(Exception ex) { throw ex; }
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            if(_dataInvoice != null && _dataInvoice.Rows.Count > 0 && _datatransactionTable != null && _datatransactionTable.Rows.Count > 0)
            {
                DataRow row = _dataInvoice.Rows[0];
                invoicedatetxtbox.Text = Convert.ToDateTime(row["Date"]).ToString("dd-MM-yyyy");
                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                longdescriptiontxtbox.Text = row["LongDescription"].ToString();
                voucherinfotxtbox.Text = row["VoucherInfo"].ToString();
                transactioncodelbl.Text = row["TransactionCode"].ToString();
                transactionidlbl.Text = row["TransactionId"].ToString();

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
                }

                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                invoicenotxtbox.Text = GenerateNextInvoiceNumber();
                string labeldata = paymentvoucheridlbl.Text;
                bool isInteger = int.TryParse(labeldata, out int result);
                if (isInteger)
                {
                    FindRecord(result);
                }
            }
            
        }
        private void FindRecord(int paymentid)
        {
            try
            {
                string query = string.Format("SELECT TransactionId,InvoiceNo,Date,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol,ConversionRate,CreatedAt," +
                    "UpdatedAt,CreatedDay,UpdatedDay,UserId,AddedBy,CompanyId FROM TransactionTable WHERE TransactionId = '" + paymentid + "'");
                DataTable dtpayment = DatabaseAccess.Retrive(query);

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
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (accountnametxtbox.Text.Trim().Length > 0) { return true; }
            if (amounttxtbox.Text.Trim().Length > 0) { return true; }
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
                string query = "SELECT TOP 1 InvoiceNo FROM TransactionTable WHERE InvoiceNo LIKE 'PA-%' ORDER BY InvoiceNo DESC";
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
        private void UpdateAccountInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.accountnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.accountnameglobal) && 
                GlobalVariables.accountidglobal > 0)
            {
                accountnametxtbox.Text = GlobalVariables.accountnameglobal;
                accountidlbl.Text = GlobalVariables.accountidglobal.ToString();
                accountcodetxtbox.Text = GlobalVariables.accountcodeglobal.ToString();
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
        private void accountnametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(accountnametxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                    if (openForm == null)
                    {
                        AccountSelectionForm accountSelection = new AccountSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        accountSelection.FormClosed += delegate
                        {
                            UpdateAccountInfo();
                        };

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
            if (dgvPayment.Rows.Count == 1) // First row
            {
                // Set the "Type" column (assuming "Type" is for Debit/Credit) to "Credit"
                dgvPayment.Rows[0].Cells["debitcreditcolumn"].Value = "C";
                dgvPayment.Rows[0].Cells["iscreditcolumn"].Value = true;

                // Disable editing for the "Type" column in the first row
                dgvPayment.Rows[0].Cells["iscreditcolumn"].ReadOnly = true;
            }
        }

        private void amounttxtbox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amounttxtbox.Text) && !string.IsNullOrWhiteSpace(amounttxtbox.Text))
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
                        foreach (DataGridViewRow row in dgvPayment.Rows)
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
                                dgvPayment.Rows.Add(null, transactionsymbol, accountname, accountCode, accountid, GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,
                                    null, paymentamountcredit, GlobalVariables.shortdescriptionglobal);
                            }

                            else if (GlobalVariables.isdebitglobal == true)

                            {
                                decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                                transactionsymbol = "D";
                                dgvPayment.Rows.Add(null, transactionsymbol, accountname, accountCode, accountid, GlobalVariables.isdebitglobal, GlobalVariables.iscreditglobal,
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

        private void ResetControl()
        {
            accountnametxtbox.Text = string.Empty;
            accountcodetxtbox.Text = string.Empty;
            amounttxtbox.Text = string.Empty;
            accountidlbl.Text = string.Empty;
            accountnametxtbox.Focus();
        }

        private void dgvPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                // Ensure the current row has a valid product ID.
                var productidCellValue = dgvPayment.CurrentRow?.Cells[1].Value;
                if (productidCellValue != null && int.TryParse(productidCellValue.ToString(), out int productid) && productid > 0)
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
    }
}
