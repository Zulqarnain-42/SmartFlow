using SmartFlow.Common;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class DetailSaleReturn : Form
    {
        private DataTable _invoiceData;
        private DateTime _startDate;
        private DateTime _endDate;

        public DetailSaleReturn(DataTable invoiceData, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            this._invoiceData = invoiceData;
            this._startDate = startDate;
            this._endDate = endDate;
        }

        private void DetailSaleReturn_Load(object sender, EventArgs e)
        {
            dgvlistinvoices.DataSource = _invoiceData;
            dgvlistinvoices.Columns["Particulars"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["Item Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistinvoices.Columns["Invoice"].Visible = false;
            fromdatevaluelbl.Text = _startDate.ToString("dd-MM-yyyy");  // Format as needed
            todatevaluelbl.Text = _endDate.ToString("dd-MM-yyyy");
            CalculateTotals();
        }

        private async void dgvlistinvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is double-clicked
            if (e.RowIndex >= 0)
            {
                // Get the InvoiceNo from the clicked row, assuming it's in the second column (index 1)
                var invoiceNo = dgvlistinvoices.Rows[e.RowIndex].Cells["Invoice"].Value.ToString();

                string query = string.Format("SELECT InvoiceTable.Invoiceid,InvoiceTable.InvoiceNo,InvoiceTable.invoicedate,InvoiceTable.ClientID," +
                        "InvoiceTable.CreatedAt,InvoiceTable.CreatedDay,InvoiceTable.UpdatedAt,InvoiceTable.UpdatedDay,InvoiceTable.AddedBy,InvoiceTable.Companyid," +
                        "InvoiceTable.Userid,InvoiceTable.InvoiceCode,InvoiceTable.NetTotal,InvoiceTable.ClientName,InvoiceTable.TotalVat,InvoiceTable.TotalDiscount," +
                        "InvoiceTable.FreightShippingCharges,InvoiceTable.InvoiceRefrence,InvoiceTable.IsPlanetInvoice,InvoiceTable.Currencyid,InvoiceTable.CurrencySymbol," +
                        "InvoiceTable.CurrencyName,InvoiceTable.ConversionRate,InvoiceTable.QuotationValidUntill,InvoiceTable.ShipmentReceiveingPerson," +
                        "InvoiceTable.SalePerson,AccountSubControlTable.MobileNo,AccountSubControlTable.Email,AccountSubControlTable.RefrencePersonName," +
                        "AccountSubControlTable.AccountSubControlName,AccountSubControlTable.CodeAccount,AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoiceNo + "'");

                DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                if (dataInvoice.Rows.Count > 0)
                {
                    string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.AddInventory,InvoiceDetailsTable.MinusInventory,InvoiceDetailsTable.Invoicecode," +
                    "InvoiceDetailsTable.Productid,InvoiceDetailsTable.Quantity,InvoiceDetailsTable.UnitSalePrice,InvoiceDetailsTable.ItemSerialNoid,InvoiceDetailsTable.ProductName,InvoiceDetailsTable.MFR,InvoiceDetailsTable.ItemWiseDiscount," +
                    "InvoiceDetailsTable.ItemWiseVAT,InvoiceDetailsTable.Warehouseid,InvoiceDetailsTable.PurchaseCostPrice,InvoiceDetailsTable.PurchaseLowestSalePrice,InvoiceDetailsTable.PurchaseStandardPrice," +
                    "InvoiceDetailsTable.PurchaseItemSalePrice,InvoiceDetailsTable.SystemSerialNoid,InvoiceDetailsTable.ItemTotal,InvoiceDetailsTable.Unitid,InvoiceDetailsTable.ItemAvailability,InvoiceDetailsTable.PricePerMeter," +
                    "InvoiceDetailsTable.LengthInMeter,InvoiceDetailsTable.ItemDescription,InvoiceDetailsTable.IsSaleInvoice,InvoiceDetailsTable.VatCode,InvoiceDetailsTable.IsNewRecord,InvoiceDetailsTable.DiscountType," +
                    "InvoiceDetailsTable.DiscountPercentage,UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                    "InvoiceDetailsTable.InvoiceNo = '" + invoiceNo + "'  AND InvoiceDetailsTable.IsNewRecord = '" + true + "'");

                    DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);
                    if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                    {
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
        }

        private async void dgvlistinvoices_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Ensure that a valid row is selected
                if (dgvlistinvoices.CurrentRow != null)
                {
                    // Get the InvoiceNo from the selected row
                    var invoiceNo = dgvlistinvoices.CurrentRow.Cells["Invoice"].Value.ToString();

                    // Query to get the main invoice details
                    string query = string.Format("SELECT InvoiceTable.Invoiceid, InvoiceTable.InvoiceNo, InvoiceTable.InvoiceDate, InvoiceTable.ClientID, " +
                        "InvoiceTable.CreatedAt, InvoiceTable.CreatedDay, InvoiceTable.UpdatedAt, InvoiceTable.UpdatedDay, InvoiceTable.AddedBy, InvoiceTable.Companyid, " +
                        "InvoiceTable.Userid, InvoiceTable.InvoiceCode, InvoiceTable.NetTotal, InvoiceTable.ClientName, InvoiceTable.TotalVat, InvoiceTable.TotalDiscount, " +
                        "InvoiceTable.FreightShippingCharges, InvoiceTable.InvoiceRefrence, InvoiceTable.IsPlanetInvoice, InvoiceTable.Currencyid,InvoiceTable.CurrencySymbol, " +
                        "InvoiceTable.CurrencyName, InvoiceTable.ConversionRate, InvoiceTable.QuotationValidUntill, InvoiceTable.ShipmentReceiveingPerson, " +
                        "InvoiceTable.SalePerson, AccountSubControlTable.MobileNo, AccountSubControlTable.Email, AccountSubControlTable.RefrencePersonName, " +
                        "AccountSubControlTable.AccountSubControlName, AccountSubControlTable.CodeAccount, AccountSubControlTable.CompanyName " +
                        "FROM InvoiceTable INNER JOIN AccountSubControlTable " +
                        "ON AccountSubControlTable.AccountSubControlID = InvoiceTable.ClientID WHERE InvoiceTable.InvoiceNo = '" + invoiceNo + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                    // Check if data is returned
                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT InvoiceDetailsTable.InvoiceDetailsId,InvoiceDetailsTable.InvoiceNo,InvoiceDetailsTable.AddInventory,InvoiceDetailsTable.MinusInventory,InvoiceDetailsTable.Invoicecode," +
                    "InvoiceDetailsTable.Productid,InvoiceDetailsTable.Quantity,InvoiceDetailsTable.UnitSalePrice,InvoiceDetailsTable.ItemSerialNoid,InvoiceDetailsTable.ProductName,InvoiceDetailsTable.MFR,InvoiceDetailsTable.ItemWiseDiscount," +
                    "InvoiceDetailsTable.ItemWiseVAT,InvoiceDetailsTable.Warehouseid,InvoiceDetailsTable.PurchaseCostPrice,InvoiceDetailsTable.PurchaseLowestSalePrice,InvoiceDetailsTable.PurchaseStandardPrice," +
                    "InvoiceDetailsTable.PurchaseItemSalePrice,InvoiceDetailsTable.SystemSerialNoid,InvoiceDetailsTable.ItemTotal,InvoiceDetailsTable.Unitid,InvoiceDetailsTable.ItemAvailability,InvoiceDetailsTable.PricePerMeter," +
                    "InvoiceDetailsTable.LengthInMeter,InvoiceDetailsTable.ItemDescription,InvoiceDetailsTable.IsSaleInvoice,InvoiceDetailsTable.VatCode,InvoiceDetailsTable.IsNewRecord,InvoiceDetailsTable.DiscountType," +
                    "InvoiceDetailsTable.DiscountPercentage,UnitTable.UnitName FROM InvoiceDetailsTable LEFT JOIN UnitTable ON UnitTable.UnitID = InvoiceDetailsTable.Unitid WHERE " +
                    "InvoiceDetailsTable.InvoiceNo = '" + invoiceNo + "'  AND InvoiceDetailsTable.IsNewRecord = '" + true + "'");

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);

                        // Open the Purchase Invoice form
                        if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
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
            }
        }

        private void CalculateTotals()
        {
            decimal totalAmount = dgvlistinvoices.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["Amount"].Value != null)
                .Sum(row => Convert.ToDecimal(row.Cells["Amount"].Value));

            int totalQuantity = dgvlistinvoices.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["Qty."].Value != null)
                .Sum(row => Convert.ToInt32(row.Cells["Qty."].Value));

            totalqtyvaluelbl.Text = totalQuantity.ToString();
            totalamountvaluelbl.Text = totalAmount.ToString("N2");
        }

        private void DetailSaleReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
