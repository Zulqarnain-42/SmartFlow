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
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public TransactionInfoProduct(string productmfr,int productid)
        {
            InitializeComponent();
            _productmfr = productmfr;
            _productid = productid;
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

            if (e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    // Double Enter detected
                    this.Close();
                    lastEnterPressTime = DateTime.MinValue; // Reset to prevent multiple triggers
                }
                else
                {
                    // First Enter press detected
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true; // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key press
            }

            if(e.Control && e.KeyCode == Keys.C)
            {

            }

            if(e.Control && e.KeyCode == Keys.A)
            {

            }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void currentcustomerdatabtn_Click(object sender, EventArgs e)
        {
            try
            {

            }catch (Exception ex) { throw ex; }
        }
        private void alltransactionbtn_Click(object sender, EventArgs e)
        {
            try
            {

            }catch(Exception ex) { throw ex; }
        }
        private void TransactionInfoProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            ItemWiseDescription itemWiseDescription = new ItemWiseDescription(_productid, _productmfr)
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen,
            };
            CommonFunction.DisposeOnClose(itemWiseDescription);
            itemWiseDescription.ShowDialog();
        }
    }
}
