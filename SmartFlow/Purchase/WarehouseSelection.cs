using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class WarehouseSelection : Form
    {
        public event EventHandler<WarehouseData> WarehouseDataSelected;

        public WarehouseSelection()
        {
            InitializeComponent();
        }

        public WarehouseSelection(DataTable warehousedata)
        {
            InitializeComponent();
            DataTable datawarehouse = warehousedata;
            dgvwarehouseselection.DataSource = datawarehouse;
            dgvwarehouseselection.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvwarehouseselection.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvwarehouseselection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataGridViewRow selectedrow = dgvwarehouseselection.CurrentRow;
                if (selectedrow != null)
                {
                    // Parse supplier ID
                    if (int.TryParse(selectedrow.Cells["WarehouseID"]?.Value?.ToString(), out int warehouseid))
                    {
                        // Raise the event with the data to pass to the parent form
                        WarehouseDataSelected?.Invoke(this, new WarehouseData(
                            warehouseid,
                            selectedrow.Cells["Name"]?.Value?.ToString() ?? "Unknown"
                        ));

                        // Close the child form after passing the data
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Warehouse ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void dgvwarehouseselection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvwarehouseselection != null)
            {
                if (dgvwarehouseselection.Rows.Count > 0)
                {
                    if (dgvwarehouseselection.SelectedRows.Count == 1)
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow = dgvwarehouseselection.CurrentRow;

                        // Safe checks for each value and parsing
                        if (selectedRow != null)
                        {
                            // Parse supplier ID
                            if (int.TryParse(selectedRow.Cells["WarehouseID"]?.Value?.ToString(), out int warehouseid))
                            {
                                // Raise the event with the data to pass to the parent form
                                WarehouseDataSelected?.Invoke(this, new WarehouseData(
                                    warehouseid,
                                    selectedRow.Cells["Name"]?.Value?.ToString() ?? "Unknown"
                                ));

                                // Close the child form after passing the data
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Warehouse ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
