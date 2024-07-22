using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Purchase
{
    public partial class WarehouseSelection : Form
    {
        public WarehouseSelection()
        {
            InitializeComponent();
        }
        public WarehouseSelection(DataTable warehousedata)
        {
            InitializeComponent();
            DataTable datawarehouse = warehousedata;
            dgvwarehouseselection.DataSource = datawarehouse;
            dgvwarehouseselection.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void dgvwarehouseselection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataGridViewRow selectedrow = dgvwarehouseselection.CurrentRow;
                if (selectedrow != null)
                {
                    GlobalVariables.warehouseidglobal = Convert.ToInt32(selectedrow.Cells["WarehouseID"].Value.ToString());
                    GlobalVariables.warehousenameglobal = selectedrow.Cells["Name"].Value.ToString();
                    this.Close();
                }
            }
        }
        private void WarehouseSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
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
                        GlobalVariables.warehouseidglobal = Convert.ToInt32(dgvwarehouseselection.CurrentRow.Cells["WarehouseID"].Value);
                        GlobalVariables.warehousenameglobal = dgvwarehouseselection.CurrentRow.Cells["Name"].Value.ToString();
                        this.Close();
                    }
                }
            }
        }
    }
}
