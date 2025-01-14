using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class SearchQuotationForm : Form
    {
        public SearchQuotationForm()
        {
            InitializeComponent();
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear previous errors
                errorProvider.Clear();

                // Validate the Quotation No input
                if (string.IsNullOrWhiteSpace(quotationnotxtbox.Text))
                {
                    errorProvider.SetError(quotationnotxtbox, "Please Enter Quotation No");
                    quotationnotxtbox.Focus();
                    return;
                }

                string quotationNo = quotationnotxtbox.Text;

                // Using parameterized query to avoid SQL injection
                string queryQuotation = @"SELECT InvoiceTable.Invoiceid, InvoiceTable.InvoiceNo, InvoiceTable.Invoicedate, InvoiceTable.ClientID,
                                    InvoiceTable.Narration, InvoiceTable.CreatedAt, InvoiceTable.CreatedDay, InvoiceTable.UpdatedAt,
                                    InvoiceTable.UpdatedDay, InvoiceTable.AddedBy, InvoiceTable.Companyid, InvoiceTable.Userid,
                                    InvoiceTable.InvoiceCode, InvoiceTable.NetTotal, InvoiceTable.ClientName, InvoiceTable.TotalVat,
                                    InvoiceTable.TotalDiscount, InvoiceTable.FreightShippingCharges, InvoiceTable.TotalQty,
                                    InvoiceTable.InvoiceRefrence, InvoiceTable.IsPlanetInvoice, InvoiceTable.Currencyid,
                                    InvoiceTable.CurrencyName, InvoiceTable.CurrencySymbol, InvoiceTable.ConversionRate,
                                    CustomerTable.CustomerCode, CustomerTable.ContactNo
                              FROM InvoiceTable
                              INNER JOIN CustomerTable ON CustomerTable.CustomerID = InvoiceTable.ClientID
                              WHERE InvoiceTable.InvoiceNo = @InvoiceNo";

                var parameters = new Dictionary<string, object>
                {
                    { "@InvoiceNo", quotationNo }
                };

                DataTable quotationData = DatabaseAccess.Retrive(queryQuotation, parameters);

                if (quotationData != null && quotationData.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No data found for this Quotation No.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Log the error or display it for debugging purposes
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            return !string.IsNullOrWhiteSpace(quotationnotxtbox.Text);
        }
        private void SearchQuotationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    var result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                  "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    e.Handled = true; // Stop further processing after handling the Escape key.
                }
                else
                {
                    this.Close();
                    e.Handled = true; // Stop further processing.
                }
            }

        }
    }
}
