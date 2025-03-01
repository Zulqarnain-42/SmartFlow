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

namespace SmartFlow.Stock
{
    public partial class DetailQtyUsingScanner : Form
    {
        private DataTable _invoiceData;
        private DateTime _startdate;
        private DateTime _enddate;
        public DetailQtyUsingScanner(DataTable invoiceData, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            _invoiceData = invoiceData;
            _startdate = startdate;
            _enddate = enddate;
        }

        private void DetailQtyUsingScanner_Load(object sender, EventArgs e)
        {
            dgvlistusingscanner.DataSource = _invoiceData;
            dgvlistusingscanner.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvlistusingscanner.Columns["Warehouse"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvlistusingscanner.Columns["Item Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlistusingscanner.Columns["ProductID"].Visible = false;
            dgvlistusingscanner.Columns["Warehouseid"].Visible = false;
            dgvlistusingscanner.Columns["Invoice"].Visible = false;
            dgvlistusingscanner.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            fromdatevaluelbl.Text = _startdate.ToString();
            todatevaluelbl.Text = _enddate.ToString();
        }

        private async void dgvlistusingscanner_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Ensure that a valid row is selected
                if (dgvlistusingscanner.CurrentRow != null)
                {
                    // Get the InvoiceNo from the selected row
                    var invoiceNo = dgvlistusingscanner.CurrentRow.Cells["Invoice"].Value.ToString();

                    // Query to get the main invoice details
                    string query = string.Format("SELECT CustomStockID,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,InvoiceNo,UserID,AddedBy,CompanyId,Description " +
                        "FROM StockCustomizedTable WHERE StockCustomizedTable.CustomStockID = '" + invoiceNo + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                    // Check if data is returned
                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT StockTable.StockID,StockTable.ProductID,StockTable.CreatedAt,StockTable.UpdatedAt,StockTable.AddedBy," +
                            "StockTable.CreatedDay,StockTable.LocationId,StockTable.TransferFromWarehouseID,StockTable.TransferToWarehouseID,StockTable.TransformQty," +
                            "StockTable.TransToQty, StockTable.DamageQty, StockTable.UpdatedDay, StockTable.StockCustom_ID, StockTable.AddInventory, StockTable.MinusInventory," +
                            "StockTable.Warehouseid, StockTable.AddOpenBoxQuantity, StockTable.MinusOpenBoxQuantity, StockTable.Quantity,StockTable.ProductMfr," +
                            "ProductTable.ProductName, ProductTable.MFR, ProductTable.UPC, ProductTable.Barcode, WarehouseTable.Name FROM StockTable " +
                            "INNER JOIN ProductTable ON ProductTable.ProductID = StockTable.ProductID " +
                            "INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = StockTable.Warehouseid WHERE StockCustom_ID = '" + invoiceNo + "'");

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);

                        // Open the Purchase Invoice form
                        if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            QtyUsingScanner qtyUsingScanner = new QtyUsingScanner(dataInvoice, dtInvoiceDetails);
                            qtyUsingScanner.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(qtyUsingScanner);
                            qtyUsingScanner.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
            }
        }

        private async void dgvlistusingscanner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is double-clicked
            if (e.RowIndex >= 0)
            {
                // Get the InvoiceNo from the selected row
                var invoiceNo = dgvlistusingscanner.CurrentRow.Cells["Invoice"].Value.ToString();

                // Query to get the main invoice details
                string query = string.Format("SELECT CustomStockID,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,InvoiceNo,UserID,AddedBy,CompanyId,Description " +
                    "FROM StockCustomizedTable WHERE StockCustomizedTable.CustomStockID = '" + invoiceNo + "'");

                DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                // Check if data is returned
                if (dataInvoice.Rows.Count > 0)
                {
                    string subquery = string.Format("SELECT StockTable.StockID,StockTable.ProductID,StockTable.CreatedAt,StockTable.UpdatedAt,StockTable.AddedBy," +
                            "StockTable.CreatedDay,StockTable.LocationId,StockTable.TransferFromWarehouseID,StockTable.TransferToWarehouseID,StockTable.TransformQty," +
                            "StockTable.TransToQty, StockTable.DamageQty, StockTable.UpdatedDay, StockTable.StockCustom_ID, StockTable.AddInventory, StockTable.MinusInventory," +
                            "StockTable.Warehouseid, StockTable.AddOpenBoxQuantity, StockTable.MinusOpenBoxQuantity, StockTable.Quantity,StockTable.ProductMfr," +
                            "ProductTable.ProductName, ProductTable.MFR, ProductTable.UPC, ProductTable.Barcode, WarehouseTable.Name FROM StockTable " +
                            "INNER JOIN ProductTable ON ProductTable.ProductID = StockTable.ProductID " +
                            "INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = StockTable.Warehouseid WHERE StockCustom_ID = '" + invoiceNo + "'");

                    DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);

                    // Open the Purchase Invoice form
                    if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                    {
                        QtyUsingScanner qtyUsingScanner = new QtyUsingScanner(dataInvoice, dtInvoiceDetails);
                        qtyUsingScanner.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(qtyUsingScanner);
                        qtyUsingScanner.Show();
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                }
            }
        }
    }
}
