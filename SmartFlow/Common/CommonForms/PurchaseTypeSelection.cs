using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class PurchaseTypeSelection : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public PurchaseTypeSelection()
        {
            InitializeComponent();
        }

        private void PurchaseTypeSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetPurchaseTypeInfo(searchtxtbox.Text,dgvpurchasetypeselection);
        }

        private void PurchaseTypeSelection_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvpurchasetypeselection.ClearSelection();
            CommonFunction.GetPurchaseTypeInfo("",dgvpurchasetypeselection);
        }

        private void dgvpurchasetypeselection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvpurchasetypeselection != null)
                {
                    if (dgvpurchasetypeselection.Rows.Count > 0)
                    {
                        if(dgvpurchasetypeselection.SelectedRows.Count == 1)
                        {
                            this.Close();
                        }
                    }
                }
            }catch (Exception ex) { throw ex; }
        }

        private void dgvpurchasetypeselection_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedrow = dgvpurchasetypeselection.CurrentRow;
                    if (selectedrow != null)
                    {
                        this.Close();
                    }
                }
            }catch (Exception ex) { throw ex; }
        }

        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime-lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    dgvpurchasetypeselection.Focus();
                    lastEnterPressTime = DateTime.MinValue;
                }
                else
                {
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
