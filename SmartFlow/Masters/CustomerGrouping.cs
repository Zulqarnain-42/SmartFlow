using SmartFlow.Common;
using SmartFlow.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class CustomerGrouping : Form
    {
        public CustomerGrouping()
        {
            InitializeComponent();
        }
        private void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
            if (openForm == null) 
            {
                CustomerSelectionForm customerSelection = new CustomerSelectionForm();
                customerSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
                if (openForm == null) 
                {
                    CustomerSelectionForm customerSelection = new CustomerSelectionForm();
                    customerSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void CustomerGrouping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
