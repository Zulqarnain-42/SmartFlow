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
        private async void searchbtn_Click(object sender, EventArgs e)
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
                string queryQuotation = @"SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID,InvoiceTable.CreatedAt,
                    InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid,InvoiceTable.Userid,InvoiceTable.InvoiceCode,
                    InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount,InvoiceTable.FreightShippingCharges,InvoiceTable.TotalQty,
                    InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid,InvoiceTable.CurrencyName,InvoiceTable.CurrencySymbol,InvoiceTable.ConversionRate,
                    InvoiceTable.IsSaleInvoice,InvoiceTable.IsTaxAble,InvoiceTable.QuotationValidUntill,InvoiceTable.SalePerson,InvoiceTable.ShipmentReceiveingPerson,
                    AccountSubControlTable.CompanyName,AccountSubControlTable.CodeAccount,AccountSubControlTable.MobileNo FROM InvoiceTable 
                    INNER JOIN AccountSubControlTable ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = @InvoiceNo";

                var parameters = new Dictionary<string, object>
                {
                    { "@InvoiceNo", quotationNo }
                };

                DataTable quotationData = await DatabaseAccess.RetriveAsync(queryQuotation, parameters);

                if (quotationData != null && quotationData.Rows.Count > 0)
                {
                    string subQueryQuotation = @"SELECT InvoiceDetailsId,InvoiceNo,Invoicecode,Productid,Quantity,UnitSalePrice,ItemSerialNoid,ProductName,MFR,ItemWiseDiscount,ItemWiseVAT,
                        Warehouseid,PurchaseCostPrice,PurchaseLowestSalePrice,PurchaseStandardPrice,PurchaseItemSalePrice,SystemSerialNoid,ItemTotal,Unitid,ItemAvailability,PricePerMeter,
                        LengthInMeter,ItemDescription,MinusInventory,IsSaleInvoice,AddInventory,VatCode,DiscountPercentage,DiscountType FROM InvoiceDetailsTable WHERE InvoiceNo = @InvoiceNo";

                    var subparameters = new Dictionary<string, object>
                    {
                        { "InvoiceNo", quotationNo }
                    };

                    DataTable quotationdetails = await DatabaseAccess.RetriveAsync(subQueryQuotation,subparameters);

                    if(quotationData.Rows.Count > 0 && quotationdetails.Rows.Count > 0)
                    {

                    }
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
