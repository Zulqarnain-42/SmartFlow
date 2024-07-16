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
    public partial class ItemWiseDescription : Form
    {
        public ItemWiseDescription()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(itemwisedescriptiontxtbox.Text.Trim().Length > 0)
                {
                    GlobalVariables.productitemwisedescriptiongloabl = itemwisedescriptiontxtbox.Text;
                    this.Close();
                }
            }
            catch(Exception ex) { throw ex; }
        }

        private void ItemWiseDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
