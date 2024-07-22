using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class ItemSerialNo : Form
    {
        public ItemSerialNo()
        {
            InitializeComponent();
        }
        public ItemSerialNo(DataTable searchdata)
        {
            InitializeComponent();
            DataTable data = searchdata;
            dgvserialno.DataSource = data;
        }
        private void dgvserialno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow selectedRow = dgvserialno.CurrentRow;
                if (selectedRow != null)
                {
                    GlobalVariables.productserialnoglobal = selectedRow.Cells["SerialNo"].Value.ToString();
                    GlobalVariables.productserialnoidglobal = Convert.ToInt32(selectedRow.Cells["SerialNOID"].Value.ToString());
                    this.Close();
                }
            }
        }
        private void ItemSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
    }
}
