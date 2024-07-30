using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class ItemSerialNo : Form
    {
        private string _productmfr;
        private int _productId;
        public ItemSerialNo(string productmfr,int productid)
        {
            InitializeComponent();
            _productmfr = productmfr;
            _productId = productid;
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

        private void ItemSerialNo_Load(object sender, EventArgs e)
        {
            try
            {
                CommonFunction.GetItemSerialNo(_productmfr, _productId, dgvserialno);
            }catch(Exception ex) { throw ex; }
        }
    }
}
