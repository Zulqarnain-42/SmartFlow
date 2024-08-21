using DocumentFormat.OpenXml.Bibliography;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Transactions.CommonForm;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class Payment : Form
    {
        private int invoiceCounter = 1;
        public Payment()
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

                string invoiceNo = invoicenotxtbox.Text;
                DateTime inoviceDate = DateTime.Parse(invoicedatetxtbox.Text);
                string transactionCode = Guid.NewGuid().ToString();
                string longdescription = CommonFunction.CleanText(longdescriptiontxtbox.Text);

                string query = string.Format("INSERT INTO TransactionTable (InvoiceNo,InvoiceDate,TransactionCode,LongDescription,CurrencyId,CurrencyName,CurrencySymbol," +
                    "ConversionRate,CreatedAt,CreatedDay) VALUES ('" + invoiceNo + "','" + inoviceDate + "','" + transactionCode + "','" + longdescription + "'," +
                    "'" + currencyidlbl.Text + "','" + currencynamelbl.Text + "','" + currencysymbollbl.Text + "','" + currencyconversionratelbl.Text + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "') SELECT SCOPE_IDENTITY();");
                int transactionid = DatabaseAccess.InsertId(query);

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
                        string shortdescription = row.Cells["shortnarationcolumn"].Value.ToString();
                        float debitamount = float.Parse(row.Cells["debitcolumn"].Value.ToString());
                        float creditamount = float.Parse(row.Cells["creditcolumn"].Value.ToString());
                        string debitorcredit = row.Cells["debitcreditcolumn"].Value.ToString();

                        string subquery = string.Format("INSERT INTO TransactionDetailTable (TransactionId,TransactionCode,AccountId,AccountCode,AccountName,IsDebit,IsCredit," +
                        "ShortDescription,DebitAmount,CreditAmount,DebitOrCredit) VALUES ('" + transactionid + "','" + transactionCode + "','" + accountid + "'," +
                        "'" + accountCode + "','" + accountName + "','" + isdebitentry + "','" + iscreditentry + "','" + shortdescription + "','" + debitamount + "'," +
                        "'" + creditamount + "','" + debitorcredit + "')");

                        bool result = DatabaseAccess.Insert(subquery);
                    }
                }
                else
                {
                    MessageBox.Show("Something is wrong!");
                }
            }
            catch (Exception ex) { throw ex; }
            
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            invoicenotxtbox.Text = GenerateNextInvoiceNumber();
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
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (accountnametxtbox.Text.Trim().Length > 0) { return true; }
            if (amounttxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private bool AreDataGridViewRowsEmpty()
        {
            foreach (DataGridViewRow row in dgvPayment.Rows)
            {
                // Skip the last row if it's the new row for adding data
                if (row.IsNewRow)
                {
                    continue;
                }

                bool isEmpty = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                if (!isEmpty)
                {
                    return false;
                }
            }

            return true;
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
            catch (Exception ex) { throw ex; }
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
                MessageBox.Show("Error: " + ex.Message);
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
            catch (Exception ex) { throw ex; }
        }
        private void accountnametxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(accountnametxtbox.Text) && !string.IsNullOrWhiteSpace(accountnametxtbox.Text) && 
                !string.IsNullOrEmpty(accountidlbl.Text) && !string.IsNullOrWhiteSpace(accountidlbl.Text))
            {
                if(currencynamelbl.Text == "currencynamelbl" && currencysymbollbl.Text == "currencysymbollbl" &&
                    currencyconversionratelbl.Text == "currencyconversionratelbl" && currencyconversionratelbl.Text == "currencyconversionratelbl")
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
                    if (openForm == null)
                    {
                        CurrencySelection currencySelection = new CurrencySelection();
                        currencySelection.ShowDialog();
                        UpdateCurrencyInfo();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }
        private void UpdateCurrencyInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.currencynameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencynameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.currencysymbolglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencysymbolglobal) && 
                GlobalVariables.currencyidglobal > 0 && GlobalVariables.currencyconversionrateglobal > 0)
            {
                currencyidlbl.Text = GlobalVariables.currencyidglobal.ToString();
                currencynamelbl.Text = GlobalVariables.currencynameglobal.ToString();
                currencysymbollbl.Text = GlobalVariables.currencysymbolglobal.ToString();
                currencyconversionratelbl.Text = GlobalVariables.currencyconversionrateglobal.ToString();
            } 
        }
        private void amounttxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(amounttxtbox.Text) && !string.IsNullOrWhiteSpace(amounttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(DebitAndCreditForm));
                if (openForm == null)
                {
                    DebitAndCreditForm debitAndCreditForm = new DebitAndCreditForm();
                    debitAndCreditForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }

                string transactionsymbol = null;
                int accountid = Convert.ToInt32(accountidlbl.Text);
                string accountname = accountnametxtbox.Text;
                string accountCode = accountcodetxtbox.Text;

                if(GlobalVariables.iscreditglobal == true)
                {
                    decimal paymentamountcredit = decimal.Parse(amounttxtbox.Text);
                    transactionsymbol = "C";
                    dgvPayment.Rows.Add(null,transactionsymbol, accountname,accountCode,accountid,GlobalVariables.isdebitglobal,GlobalVariables.iscreditglobal,
                        null,paymentamountcredit,GlobalVariables.shortdescriptionglobal);
                }

                else if(GlobalVariables.isdebitglobal == true)

                {
                    decimal paymentamountdebit = decimal.Parse(amounttxtbox.Text);
                    transactionsymbol = "D";
                    dgvPayment.Rows.Add(null,transactionsymbol, accountname,accountCode,accountid,GlobalVariables.isdebitglobal,GlobalVariables.iscreditglobal,
                        paymentamountdebit,null,GlobalVariables.shortdescriptionglobal);
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
        }
        private void accountnametxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
            if (openForm == null)
            {
                AccountSelectionForm accountSelectionForm = new AccountSelectionForm();
                accountSelectionForm.ShowDialog();
                UpdateAccountInfo();
            }
            else
            {
                openForm.BringToFront();
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
        private void dgvPayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPayment != null)
            {
                if (dgvPayment.Rows.Count > 0)
                {
                    if(dgvPayment.SelectedRows.Count == 1)
                    {
                        accountcodetxtbox.Text = dgvPayment.CurrentRow.Cells[0].Value.ToString();
                        accountnametxtbox.Text = dgvPayment.CurrentRow.Cells[""].Value.ToString();
                        amounttxtbox.Text = dgvPayment.CurrentRow.Cells[""].Value.ToString();
                    }
                }
            }
        }
        private void accountnametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountSelectionForm));
                if(openForm == null)
                {
                    AccountSelectionForm accountSelection = new AccountSelectionForm();
                    accountSelection.ShowDialog();
                    UpdateAccountInfo();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
    }
}
