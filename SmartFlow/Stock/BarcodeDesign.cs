
using SmartFlow.Common;
using SmartFlow.Common.Forms;
using System;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class BarcodeDesign : Form
    {
        public BarcodeDesign()
        {
            InitializeComponent();
        }
        private void BarcodeDesign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if (openForm == null) 
            { 
                ProductSelectionForm productSelection = new ProductSelectionForm();
                productSelection.ShowDialog();
                UpdateProductTextBox();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateProductTextBox()
        {
            selectproducttxtbox.Text = GlobalVariables.productnameglobal;
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
            productmfrlbl.Text = GlobalVariables.productmfrglobal.ToString();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectproducttxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectproducttxtbox,"Please Select a Product.");
                    selectproducttxtbox.Focus();
                    return;
                }

                if(qtybarcode.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtybarcode,"Please Enter QTY");
                    qtybarcode.Focus();
                    return;
                }

                string productid = productidlbl.Text;
                string productname = selectproducttxtbox.Text;
                string qty = qtybarcode.Text;
                string mfr = productmfrlbl.Text;

                selectproducttxtbox.Text = string.Empty;
                qtybarcode.Text = string.Empty;
                selectproducttxtbox.Focus();

                dgvbarcodeproducts.Rows.Add(productid, mfr, productname, qty);
            }catch (Exception ex) { throw ex; }
        }
        private void generatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbarcodeproducts.Rows.Count == 0 || dgvbarcodeproducts.Rows.Count == 1 && dgvbarcodeproducts.Rows[0].IsNewRow)
                {
                    return; // The DataGridView is empty
                }
                else
                {

                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void BarcodeDesign_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AreAnyTextBoxesFilled())
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                      "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                }
            }
        }
        private bool AreAnyTextBoxesFilled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true; // At least one TextBox is filled
                }
            }
            return false; // No TextBox is filled
        }
    }
}
