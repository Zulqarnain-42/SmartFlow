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
    public partial class SearchSaleInvoice : Form
    {
        public SearchSaleInvoice()
        {
            InitializeComponent();
        }
        private async void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear any previous error messages
                errorProvider.Clear();

                // Validate Sale Invoice input
                if (string.IsNullOrWhiteSpace(saleinvoicenotxtbox.Text))
                {
                    errorProvider.SetError(saleinvoicenotxtbox, "Please Enter Sale Invoice.");
                    saleinvoicenotxtbox.Focus();
                    return;
                }

                // Get the Sale Invoice number
                string saleNo = saleinvoicenotxtbox.Text.Trim();

                // Build the SQL query to fetch data
                string querysales = @"SELECT 
                                InvoiceTable.Invoiceid,
                                InvoiceTable.InvoiceNo,
                                InvoiceTable.invoicedate,
                                InvoiceTable.ClientID,
                                InvoiceTable.Narration,
                                InvoiceTable.CreatedAt,
                                InvoiceTable.CreatedDay,
                                InvoiceTable.UpdatedAt,
                                InvoiceTable.UpdatedDay,
                                InvoiceTable.AddedBy,
                                InvoiceTable.Companyid,
                                InvoiceTable.Userid,
                                InvoiceTable.InvoiceCode,
                                InvoiceTable.NetTotal,
                                InvoiceTable.ClientName,
                                InvoiceTable.TotalVat,
                                InvoiceTable.TotalDiscount,
                                InvoiceTable.FreightShippingCharges,
                                InvoiceTable.TotalQty,
                                InvoiceTable.InvoiceRefrence,
                                InvoiceTable.IsPlanetInvoice,
                                InvoiceTable.Currencyid,
                                InvoiceTable.CurrencyName,
                                InvoiceTable.CurrencySymbol,
                                InvoiceTable.ConversionRate,
                                CustomerTable.CustomerCode,
                                CustomerTable.ContactNo
                            FROM InvoiceTable 
                            INNER JOIN CustomerTable ON CustomerTable.CustomerID = InvoiceTable.ClientID 
                            WHERE InvoiceTable.InvoiceNo = @SaleNo";

                // Use parameters to prevent SQL injection
                var parameters = new Dictionary<string, object>
    {
        { "@SaleNo", saleNo }
    };

                // Retrieve data using parameterized query
                DataTable salesData = await DatabaseAccess.RetriveAsync(querysales, parameters);

                // Check if data was found
                if (salesData != null && salesData.Rows.Count > 0)
                {
                    // Data found, close the form
                    this.Close();
                }
                else
                {
                    // No data found, inform the user
                    MessageBox.Show("No Data Found For this Invoice No");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and display a user-friendly message
                // LogError(ex); // Optional: You can implement a logging mechanism here
                MessageBox.Show("An error occurred while processing the request. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SearchSaleInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    // Check if any text boxes are filled
                    if (AreAnyTextBoxesFilled())
                    {
                        // Prompt user with confirmation message
                        DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                              "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        // If user chooses "Yes", close the form
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                            e.Handled = true;  // Mark the event as handled to prevent further processing
                        }
                    }
                    else
                    {
                        // No unsaved changes, close the form directly
                        this.Close();
                        e.Handled = true;  // Mark the event as handled to prevent further processing
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process
                MessageBox.Show($"An error occurred while trying to close the form: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool AreAnyTextBoxesFilled()
        {
            // Return true if the TextBox is not empty or whitespace
            return !string.IsNullOrWhiteSpace(saleinvoicenotxtbox.Text);
        }
    }
}
