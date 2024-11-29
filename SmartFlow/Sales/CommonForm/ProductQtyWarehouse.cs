using SmartFlow.Common;
using SmartFlow.Sales.CommonForm;
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
    public partial class ProductQtyWarehouse : Form
    {
        private string _productmfr;
        private int _productid;
        public ProductQtyWarehouse(string productMfr,int productID)
        {
            InitializeComponent();
            _productmfr = productMfr;
            _productid = productID;
        }
        private void ProductQtyWarehouse_Load(object sender, EventArgs e)
        {
            CommonFunction.GetProductQtyWarehouse(dgvInventory, _productmfr, _productid);
        }
        private void dgvInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvInventory != null)
                {
                    if(dgvInventory.Rows.Count > 0)
                    {
                        if(dgvInventory.SelectedRows.Count == 1)
                        {
                            GlobalVariables.warehouseidglobal = Convert.ToInt32(dgvInventory.CurrentRow.Cells["ID"].Value);
                            GlobalVariables.warehousenameglobal = dgvInventory.CurrentRow.Cells["Warehouse Name"].Value.ToString();
                            /*if (Convert.ToInt32(dgvInventory.CurrentRow.Cells["Quantity"].Value) == 0)
                            {
                                AvailabilityForm availabilityForm = new AvailabilityForm();
                                availabilityForm.ShowDialog();
                            }
                            else
                            {
                                ItemSerialNo itemSerialNo = new ItemSerialNo(_productmfr, _productid);
                                itemSerialNo.ShowDialog();
                                GlobalVariables.availabilitystatus = "In Stock";
                            }*/
                            this.Close();
                        }
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void ProductQtyWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
        private void dgvInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                DataGridViewRow selectedRow = dgvInventory.CurrentRow;
                if (selectedRow != null) 
                {
                    GlobalVariables.warehouseidglobal = Convert.ToInt32(dgvInventory.CurrentRow.Cells["ID"].Value);
                    GlobalVariables.warehousenameglobal = dgvInventory.CurrentRow.Cells["Warehouse Name"].Value.ToString();
                    if (Convert.ToInt32(dgvInventory.CurrentRow.Cells["Quantity"].Value) == 0)
                    {
                        AvailabilityForm availabilityForm = new AvailabilityForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterScreen,
                        };

                        CommonFunction.DisposeOnClose(availabilityForm);
                        availabilityForm.ShowDialog();
                    }
                    else
                    {
                        GlobalVariables.availabilitystatus = "In Stock";
                    }
                    this.Close();
                }
            }
        }
        private void ProductQtyWarehouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransactionInfoProduct transactionInfoProduct = new TransactionInfoProduct(_productmfr, _productid)
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen,
            };
            CommonFunction.DisposeOnClose(transactionInfoProduct);
            transactionInfoProduct.ShowDialog();
        }
    }
}
