using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report
{
    public partial class DetailAccountStatement : Form
    {
        private DataTable _datainvoice;
        private DateTime _startdate;
        private DateTime _enddate;
        private string _companyName;
        public DetailAccountStatement(DataTable datainvoice, DateTime startdate, DateTime enddate, string companyName)
        {
            InitializeComponent();
            _datainvoice = datainvoice;
            _startdate = startdate;
            _enddate = enddate;
            _companyName = companyName;
        }

        private void DetailAccountStatement_Load(object sender, EventArgs e)
        {
            dgvlistinvoices.DataSource = _datainvoice;
            accountnamevaluelbl.Text = _companyName;
            dgvlistinvoices.Columns["Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["Vch/Bill No"].Width = 160;
            dgvlistinvoices.Columns["Short Narration"].Width = 200;
            fromdatevaluelbl.Text = _startdate.ToString("dd-MM-yyyy");  // Format as needed
            todatevaluelbl.Text = _enddate.ToString("dd-MM-yyyy");
            CalculateTotalDebitAndCredit(dgvlistinvoices, totaldebitvaluelbl, totalcreditvaluelbl);
            GetLastBalance();
        }

        private void GetLastBalance()
        {
            // Loop through the rows to get the last non-empty value from the Balance column
            string lastBalance = string.Empty;
            foreach (DataGridViewRow row in dgvlistinvoices.Rows)
            {
                // Check if the row is not empty and the Balance column is not empty
                if (row.Cells["Balance(AED)"].Value != null && !string.IsNullOrEmpty(row.Cells["Balance(AED)"].Value.ToString()))
                {
                    lastBalance = row.Cells["Balance(AED)"].Value.ToString();
                }
            }

            // Set the value in the label
            closingbalanceamtlbl.Text = string.IsNullOrEmpty(lastBalance) ? "AED 0" : $"AED {lastBalance}";
        }
        private void CalculateTotalDebitAndCredit(DataGridView dgv, Label lblTotalDebit, Label lblTotalCredit)
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Debit(AED)"].Value != null &&
                    decimal.TryParse(row.Cells["Debit(AED)"].Value.ToString().Replace(" Dr", "").Trim(), out decimal debit))
                {
                    totalDebit += debit;
                }

                if (row.Cells["Credit(AED)"].Value != null &&
                    decimal.TryParse(row.Cells["Credit(AED)"].Value.ToString().Replace(" Cr", "").Trim(), out decimal credit))
                {
                    totalCredit += credit;
                }
            }

            // Display totals in labels with AED currency
            lblTotalDebit.Text = $"Total Debit: AED {totalDebit:N2}";
            lblTotalCredit.Text = $"Total Credit: AED {totalCredit:N2}";
        }


    }
}
