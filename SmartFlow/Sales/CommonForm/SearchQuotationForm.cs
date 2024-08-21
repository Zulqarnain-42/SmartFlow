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
                errorProvider.Clear();
                if (quotationnotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(quotationnotxtbox,"Please Enter Quotation No");
                    quotationnotxtbox.Focus();
                    return;
                }

                string quotationNo = quotationnotxtbox.Text;
                string queryQuotation = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                    "InvoiceTable.Narration,InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy," +
                    "InvoiceTable.Companyid,InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat," +
                    "InvoiceTable.TotalDiscount,InvoiceTable.FreightShippingCharges,InvoiceTable.TotalQty,InvoiceTable.PurchaseInvoiceRefrence," +
                    "InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid,InvoiceTable.CurrencyName,InvoiceTable.CurrencySymbol,InvoiceTable.ConversionRate," +
                    "CustomerTable.CustomerCode,CustomerTable.ContactNo FROM InvoiceTable INNER JOIN CustomerTable ON CustomerTable.CustomerID = InvoiceTable.ClientID WHERE " +
                    "InvoiceTable.InvoiceNo = '" + quotationNo + "'");
                DataTable quotationData = DatabaseAccess.Retrive(queryQuotation);
                if (quotationData != null && quotationData.Rows.Count > 0) 
                {

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Data Found For this Quotation No");
                }
            }catch (Exception ex) { throw ex; }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (quotationnotxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void SearchQuotationForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
