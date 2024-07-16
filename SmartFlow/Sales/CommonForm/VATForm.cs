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
    public partial class VATForm : Form
    {
        private float _itemtotal = 0;
        private float _vatPercentage = 0;
        private float _discount = 0;
        public VATForm(float totalitemwise)
        {
            InitializeComponent();
            _itemtotal = totalitemwise;
        }

        private void VATForm_Load(object sender, EventArgs e)
        {
            label6.Text = _itemtotal.ToString("N2");
            vattxtbox.Text = _vatPercentage.ToString("N2");
            discounttxtbox.Text = _discount.ToString("N2");
            vattxtbox.Focus();
            CommonFunction.FillUnitData(unitcombobox);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                float vat = float.Parse(vattxtbox.Text);
                if(vat == 0)
                {
                    errorProvider.SetError(vattxtbox,"Please Enter Vat.");
                    vattxtbox.Focus();
                    return;
                }

                GlobalVariables.productitemwisevatpercentage = decimal.Parse(vattxtbox.Text);
                GlobalVariables.productitemwisevatamount = decimal.Parse(vatamountlbl.Text);
                GlobalVariables.producttotalwithvatitemwise = decimal.Parse(totalwithvatlbl.Text);
                GlobalVariables.unitid = Convert.ToInt32(unitcombobox.SelectedValue);
                if(fixedamountradio.Checked || percentageradio.Checked)
                {
                    GlobalVariables.isproductdiscounted = true;
                    if (percentageradio.Checked)
                    {
                        GlobalVariables.productdiscounttype = true;
                    }
                    GlobalVariables.productdiscountamountitemwise = decimal.Parse(discountamountlbl.Text);
                    
                }
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = decimal.Parse(totalwithvatanddiscountlbl.Text);
                this.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        private void vattxtbox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void vattxtbox_TextChanged(object sender, EventArgs e)
        {
            if(decimal.TryParse(label6.Text,out decimal price) && decimal.TryParse(vattxtbox.Text,out decimal vatRate))
            {
                decimal vatAmount = price * (vatRate / 100);
                decimal totalAmountWithVat = price + vatAmount;
                vatamountlbl.Text = vatAmount.ToString("N2");
                vatamountlbl.Visible = true;
                totalwithvatlbl.Text = totalAmountWithVat.ToString("N2");
                totalwithvatanddiscountlbl.Text = totalAmountWithVat.ToString("N2");
                totalwithvatanddiscountlbl.Visible = true;
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
            if(decimal.TryParse(totalwithvatlbl.Text,out decimal totalwithVat) && decimal.TryParse(discounttxtbox.Text,out decimal discount))
            {
                if (fixedamountradio.Checked)
                {
                    discountamountlbl.Text = discount.ToString("N2");
                    discountamountlbl.Visible = true;
                    decimal finalamount = totalwithVat - discount;
                    totalwithvatanddiscountlbl.Text = finalamount.ToString("N2");
                }
                else
                {
                    decimal discountamount = totalwithVat * (discount / 100);
                    discountamountlbl.Text = discountamount.ToString("N2");
                    discountamountlbl.Visible = true;
                    decimal finalamount = totalwithVat - discountamount;
                    totalwithvatanddiscountlbl.Text = finalamount.ToString("N2");
                    totalwithvatanddiscountlbl.Visible = true;
                }
            }
        }
    }
}
