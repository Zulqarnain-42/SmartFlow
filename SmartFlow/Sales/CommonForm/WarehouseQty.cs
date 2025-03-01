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

namespace SmartFlow.Sales.CommonForm
{
    public partial class WarehouseQty : Form
    {
        private DataTable _stockData;
        private bool _isSaleInvoice = false;

        public WarehouseQty(DataTable stockdata, bool isSaleInvoice)
        {
            InitializeComponent();
            _stockData = stockdata;
            _isSaleInvoice = isSaleInvoice;
        }

        private void WarehouseQty_Load(object sender, EventArgs e)
        {
            try
            {
                // Ensure the data source is not null
                if (_stockData == null || _stockData.Rows.Count == 0)
                {
                    throw new InvalidOperationException("No stock data available to display.");
                }

                // Assign the data source to the DataGridView
                dgvWarehouse.DataSource = _stockData;

                // Validate and configure columns
                if (dgvWarehouse.Columns.Contains("WarehouseID"))
                {
                    dgvWarehouse.Columns["WarehouseID"].Width = 100;
                }
                else
                {
                    throw new ArgumentException("Column 'WarehouseID' not found in the data source.");
                }

                if (dgvWarehouse.Columns.Contains("Name"))
                {
                    dgvWarehouse.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    throw new ArgumentException("Column 'Name' not found in the data source.");
                }

                if (dgvWarehouse.Columns.Contains("TotalQuantity"))
                {
                    dgvWarehouse.Columns["TotalQuantity"].Width = 100;
                }
                else
                {
                    throw new ArgumentException("Column 'TotalQuantity' not found in the data source.");
                }
            }
            catch (Exception ex)
            {
                // Display the error message
                MessageBox.Show($"Error: {ex.Message}", "Data Binding Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is on a valid row (not header or empty row)
                if (e.RowIndex >= 0)
                {
                    // Get the selected row (the one clicked)
                    DataGridViewRow selectedRow = dgvWarehouse.Rows[e.RowIndex];

                    // Assuming "TotalQuantity" is the column name or index where the quantity is stored
                    int quantity = selectedRow.Cells["TotalQuantity"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["TotalQuantity"].Value) : 0;

                    // Check if the quantity is greater than zero
                    if (quantity > 0)
                    {
                        // Close the form after the selection and quantity check
                        GlobalVariables.warehouseidglobal = Convert.ToInt32(selectedRow.Cells["WarehouseID"].Value);
                        GlobalVariables.availabilitystatus = "IN STOCK";
                        this.Close();
                    }
                    else if (quantity < 0 && _isSaleInvoice == true) 
                    {
                        GlobalVariables.warehouseidglobal = Convert.ToInt32(selectedRow.Cells["WarehouseID"].Value);
                        GlobalVariables.availabilitystatus = "IN STOCK";
                        this.Close();
                        MessageBox.Show("Quantity is not greater than zero. if the item is available. Take Inventory First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Close the form after the selection and quantity check
                        GlobalVariables.warehouseidglobal = Convert.ToInt32(selectedRow.Cells["WarehouseID"].Value);
                        GlobalVariables.availabilitystatus = "IN STOCK";
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Check if the pressed key is Enter
                if (e.KeyCode == Keys.Enter)
                {
                    // Ensure a valid row is selected (not the header or an empty row)
                    if (dgvWarehouse.SelectedRows.Count > 0)
                    {
                        // Get the selected row (assuming it's the first selected row)
                        DataGridViewRow selectedRow = dgvWarehouse.SelectedRows[0];

                        // Assuming "TotalQuantity" is the column name where the quantity is stored
                        int quantity = selectedRow.Cells["TotalQuantity"].Value != DBNull.Value
                            ? Convert.ToInt32(selectedRow.Cells["TotalQuantity"].Value)
                            : 0;

                        // Check if the quantity is greater than zero
                        if (quantity > 0)
                        {
                            // Close the form
                            GlobalVariables.warehouseidglobal = Convert.ToInt32(selectedRow.Cells["WarehouseID"].Value);
                            GlobalVariables.availabilitystatus = "IN STOCK";
                            this.Close();
                        }
                        else if (quantity < 0 && _isSaleInvoice == true)
                        {
                            MessageBox.Show("Quantity is not greater than zero. if the item is available. Take Inventory First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Close the form after the selection and quantity check
                            GlobalVariables.warehouseidglobal = Convert.ToInt32(selectedRow.Cells["WarehouseID"].Value);
                            GlobalVariables.availabilitystatus = "IN STOCK";
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
