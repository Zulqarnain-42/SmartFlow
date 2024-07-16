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
    public partial class TransactionInfoProduct : Form
    {
        private string _productmfr;
        private int _productid;

        public TransactionInfoProduct(string productmfr,int productid)
        {
            InitializeComponent();
            _productmfr = productmfr;
            _productid = productid;
        }

        private void TransactionInfoProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            ItemWiseDescription itemWiseDescription = new ItemWiseDescription();
            itemWiseDescription.ShowDialog();
        }

        private void TransactionInfoProduct_Load(object sender, EventArgs e)
        {
            CommonFunction.GetTransactionInfoProduct(dgvTransactionInfo,_productmfr,_productid);
        }

        private void TransactionInfoProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void currentcustomerdatabtn_Click(object sender, EventArgs e)
        {

        }
    }
}
