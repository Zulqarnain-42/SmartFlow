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
    public partial class DiscountForm : Form
    {
        private float _itemtotal = 0;
        private float _discount = 0;
        public DiscountForm()
        {
            InitializeComponent();
        }

        public DiscountForm(float itemtotal)
        {
            InitializeComponent();
            _itemtotal = itemtotal;
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            CommonFunction.FillUnitData(unitcombobox);
            label6.Text = _itemtotal.ToString("N2");
            discounttxtbox.Text = _discount.ToString("N2");
        }

        private void discounttxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void fixedamountradio_CheckedChanged(object sender, EventArgs e)
        {
            if (fixedamountradio.Checked)
            {
                discounttxtbox.Enabled = true;
            }
            else
            {
                discounttxtbox.Enabled = false;
            }
        }

        private void percentageradio_CheckedChanged(object sender, EventArgs e)
        {
            if (percentageradio.Checked)
            {
                discounttxtbox.Enabled = true;
            }
            else
            {
                discounttxtbox.Enabled = false;
            }
        }

        private void discounttxtbox_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(label6.Text, out decimal totalamount) && decimal.TryParse(discounttxtbox.Text, out decimal discount))
            {
                if (fixedamountradio.Checked)
                {
                    discountamountlbl.Text = discount.ToString("N2");
                    discountamountlbl.Visible = true;
                    decimal finalamount = totalamount - discount;
                    totalwithdiscountlbl.Text = finalamount.ToString("N2");
                    totalwithdiscountlbl.Visible = true;
                }
                else
                {
                    decimal discountamount = totalamount * (discount / 100);
                    discountamountlbl.Text = discountamount.ToString("N2");
                    discountamountlbl.Visible = true;
                    decimal finalamount = totalamount - discountamount;
                    totalwithdiscountlbl.Text = finalamount.ToString("N2");
                    totalwithdiscountlbl.Visible = true;
                }
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariables.unitid = Convert.ToInt32(unitcombobox.SelectedValue);
                if (fixedamountradio.Checked || percentageradio.Checked)
                {
                    GlobalVariables.isproductdiscounted = true;
                    if (percentageradio.Checked)
                    {
                        GlobalVariables.productdiscounttype = true;
                    }
                    GlobalVariables.productdiscountamountitemwise = decimal.Parse(discountamountlbl.Text);

                }
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = decimal.Parse(totalwithdiscountlbl.Text);
                this.Close();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
