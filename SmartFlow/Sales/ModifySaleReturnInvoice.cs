using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class ModifySaleReturnInvoice : Form
    {
        public ModifySaleReturnInvoice()
        {
            InitializeComponent();
        }

        private void invoicenotxtbox_TextChanged(object sender, EventArgs e)
        {
            string prefix = "SR-";
            if (!invoicenotxtbox.Text.StartsWith(prefix))
            {
                invoicenotxtbox.Text = prefix;
                invoicenotxtbox.SelectionStart = invoicenotxtbox.Text.Length; // Place the cursor at the end
            }
        }

        private async void searchbtn_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill,InvoiceTable.CurrencySymbol," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoicenotxtbox.Text + "'");

            DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

            if (dataInvoice.Rows.Count > 0)
            {
                string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.AddInventory,InvoiceDetailsTable.MinusInventory,InvoiceDetailsTable.Invoicecode," +
                    "InvoiceDetailsTable.Productid,InvoiceDetailsTable.Quantity,InvoiceDetailsTable.UnitSalePrice,InvoiceDetailsTable.ItemSerialNoid,InvoiceDetailsTable.ProductName,InvoiceDetailsTable.MFR,InvoiceDetailsTable.ItemWiseDiscount," +
                    "InvoiceDetailsTable.ItemWiseVAT,InvoiceDetailsTable.Warehouseid,InvoiceDetailsTable.PurchaseCostPrice,InvoiceDetailsTable.PurchaseLowestSalePrice,InvoiceDetailsTable.PurchaseStandardPrice," +
                    "InvoiceDetailsTable.PurchaseItemSalePrice,InvoiceDetailsTable.SystemSerialNoid,InvoiceDetailsTable.ItemTotal,InvoiceDetailsTable.Unitid,InvoiceDetailsTable.ItemAvailability,InvoiceDetailsTable.PricePerMeter," +
                    "InvoiceDetailsTable.LengthInMeter,InvoiceDetailsTable.ItemDescription,InvoiceDetailsTable.IsSaleInvoice,InvoiceDetailsTable.VatCode,InvoiceDetailsTable.IsNewRecord,InvoiceDetailsTable.DiscountType," +
                    "InvoiceDetailsTable.DiscountPercentage,UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                    "InvoiceDetailsTable.InvoiceNo = '" + invoicenotxtbox.Text + "'  AND InvoiceDetailsTable.IsNewRecord = '" + true + "'");

                DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                {
                    this.Close();
                    SaleReturnInvoice saleReturnInvoice = new SaleReturnInvoice(dataInvoice, dtInvoiceDetails);
                    saleReturnInvoice.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(saleReturnInvoice);
                    saleReturnInvoice.Show();
                }
            }
            else
            {
                MessageBox.Show("No Record Found.");
            }
        }

        private void ModifySaleReturnInvoice_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private async void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string userinput = invoicenotxtbox.Text;
                if (userinput.Length > 0)
                {
                    // Using parameterized query to avoid SQL injection
                    string query = "SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo = @InvoiceNo";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@InvoiceNo", userinput }
                    };

                    DataTable invoiceData = await DatabaseAccess.RetriveAsync(query, parameters);

                    if (invoiceData.Rows.Count > 0)
                    {
                        DataRow row = invoiceData.Rows[0];
                        invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
