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
    public partial class DetailStockTransfer : Form
    {
        private DataTable _invoiceData;
        private DateTime _startdate;
        private DateTime _enddate;
        public DetailStockTransfer(DataTable invoiceData, DateTime startdate, DateTime enddate)
        {
            InitializeComponent();
            _invoiceData = invoiceData;
            _startdate = startdate;
            _enddate = enddate;
        }

        private void DetailStockTransfer_Load(object sender, EventArgs e)
        {
            dgvlisttransfer.DataSource = _invoiceData;
            dgvlisttransfer.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvlisttransfer.Columns["Transfer From Warehouse"].DefaultCellStyle.WrapMode= DataGridViewTriState.True;
            dgvlisttransfer.Columns["Transfer To Warehouse"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvlisttransfer.Columns["Item Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlisttransfer.Columns["ProductID"].Visible = false;
            dgvlisttransfer.Columns["TransferFromWarehouseID"].Visible = false;
            dgvlisttransfer.Columns["TransferToWarehouseID"].Visible = false;
            dgvlisttransfer.Columns["Invoice"].Visible = false;
            dgvlisttransfer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            fromdatevaluelbl.Text = _startdate.ToString();
            todatevaluelbl.Text = _enddate.ToString();
        }

        private async void dgvlisttransfer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is double-clicked
            if (e.RowIndex >= 0)
            {
                // Get the InvoiceNo from the selected row
                var invoiceNo = dgvlisttransfer.CurrentRow.Cells["Invoice"].Value.ToString();

                // Query to get the main invoice details
                string query = string.Format("SELECT CustomStockID,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,InvoiceNo,UserID,AddedBy,CompanyId,Description " +
                    "FROM StockCustomizedTable WHERE StockCustomizedTable.CustomStockID = '" + invoiceNo + "'");

                DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                // Check if data is returned
                if (dataInvoice.Rows.Count > 0)
                {
                    string subquery = string.Format("SELECT s.StockID, s.ProductID, s.CreatedAt, s.UpdatedAt, s.AddedBy, s.CreatedDay, s.LocationId, " +
                  "s.TransferFromWarehouseID, s.TransferToWarehouseID, s.TransformQty, s.TransToQty, s.DamageQty, s.UpdatedDay, " +
                  "s.StockCustom_ID, s.AddInventory, s.MinusInventory, s.Warehouseid, s.AddOpenBoxQuantity, s.MinusOpenBoxQuantity, s.Quantity, " +
                  "s.ProductMfr, p.ProductName, p.MFR, p.UPC, p.Barcode, wFrom.Name AS WarehouseTransferFrom, wTo.Name AS WarehouseTransferTo " +
                  "FROM StockTable s " +
                  "INNER JOIN ProductTable p ON p.ProductID = s.ProductID " +
                  "JOIN WarehouseTable AS wFrom ON wFrom.WarehouseID = s.TransferFromWarehouseID " +
                  "JOIN WarehouseTable AS wTo ON wTo.WarehouseID = s.TransferToWarehouseID " +
                  "WHERE s.StockCustom_ID = '" + invoiceNo + "'");

                    DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);

                    // Open the Purchase Invoice form
                    if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                    {
                        StockTransfer stockTransfer = new StockTransfer(dataInvoice, dtInvoiceDetails);
                        stockTransfer.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(stockTransfer);
                        stockTransfer.Show();
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                }
            }
        }

        private async void dgvlisttransfer_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Ensure that a valid row is selected
                if (dgvlisttransfer.CurrentRow != null)
                {
                    // Get the InvoiceNo from the selected row
                    var invoiceNo = dgvlisttransfer.CurrentRow.Cells["Invoice"].Value.ToString();

                    // Query to get the main invoice details
                    string query = string.Format("SELECT CustomStockID,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,InvoiceNo,UserID,AddedBy,CompanyId,Description " +
                        "FROM StockCustomizedTable WHERE StockCustomizedTable.CustomStockID = '" + invoiceNo + "'");

                    DataTable dataInvoice = await DatabaseAccess.RetriveAsync(query);

                    // Check if data is returned
                    if (dataInvoice.Rows.Count > 0)
                    {
                        string subquery = string.Format("SELECT s.StockID, s.ProductID, s.CreatedAt, s.UpdatedAt, s.AddedBy, s.CreatedDay, s.LocationId, " +
                  "s.TransferFromWarehouseID, s.TransferToWarehouseID, s.TransformQty, s.TransToQty, s.DamageQty, s.UpdatedDay, " +
                  "s.StockCustom_ID, s.AddInventory, s.MinusInventory, s.Warehouseid, s.AddOpenBoxQuantity, s.MinusOpenBoxQuantity, s.Quantity, " +
                  "s.ProductMfr, p.ProductName, p.MFR, p.UPC, p.Barcode, wFrom.Name AS WarehouseTransferFrom, wTo.Name AS WarehouseTransferTo " +
                  "FROM StockTable s " +
                  "INNER JOIN ProductTable p ON p.ProductID = s.ProductID " +
                  "JOIN WarehouseTable AS wFrom ON wFrom.WarehouseID = s.TransferFromWarehouseID " +
                  "JOIN WarehouseTable AS wTo ON wTo.WarehouseID = s.TransferToWarehouseID " +
                  "WHERE s.StockCustom_ID = '" + invoiceNo + "'");

                        DataTable dtInvoiceDetails = await DatabaseAccess.RetriveAsync(subquery);

                        // Open the Purchase Invoice form
                        if (dataInvoice != null && dataInvoice.Rows.Count > 0 || dtInvoiceDetails != null && dtInvoiceDetails.Rows.Count > 0)
                        {
                            StockTransfer stockTransfer = new StockTransfer(dataInvoice, dtInvoiceDetails);
                            stockTransfer.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(stockTransfer);
                            stockTransfer.Show();
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
}
