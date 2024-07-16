using SmartFlow.Masters;
using SmartFlow.Sales;
using System;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class ProductSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public ProductSelectionForm()
        {
            InitializeComponent();
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetProduct(searchtxtbox.Text,dgvproducts);
        }

        private void ProductSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvproducts.ClearSelection();
            CommonFunction.GetProduct("",dgvproducts);
        }

        private void dgvproducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvproducts != null)
                {
                    if (dgvproducts.Rows.Count > 0)
                    {
                        if (dgvproducts.SelectedRows.Count == 1)
                        {
                            GlobalVariables.productidglobal = Convert.ToInt32(dgvproducts.CurrentRow.Cells["ID"].Value);
                            GlobalVariables.productnameglobal = dgvproducts.CurrentRow.Cells["TITLE"].Value.ToString();
                            GlobalVariables.productmfrglobal = dgvproducts.CurrentRow.Cells["MFR"].Value.ToString();
                            GlobalVariables.productpriceglobal = float.Parse(dgvproducts.CurrentRow.Cells["PRICE"].Value.ToString());
                            GlobalVariables.productupcglobal = dgvproducts.CurrentRow.Cells["UPC"].Value.ToString();
                            GlobalVariables.productbarcodeglobal = dgvproducts.CurrentRow.Cells["BARCODE"].Value.ToString();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Select Only One Row.");
                        }
                    }
                }
            }
            catch(Exception ex) { throw ex; }
        }

        private void dgvproducts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedrow = dgvproducts.CurrentRow;
                    if (selectedrow != null)
                    {
                        GlobalVariables.productidglobal = Convert.ToInt32(dgvproducts.CurrentRow.Cells["ID"].Value);
                        GlobalVariables.productnameglobal = dgvproducts.CurrentRow.Cells["TITLE"].Value.ToString();
                        GlobalVariables.productmfrglobal = dgvproducts.CurrentRow.Cells["MFR"].Value.ToString();
                        GlobalVariables.productpriceglobal = float.Parse(dgvproducts.CurrentRow.Cells["PRICE"].Value.ToString());
                        GlobalVariables.productupcglobal = dgvproducts.CurrentRow.Cells["UPC"].Value.ToString();
                        GlobalVariables.productbarcodeglobal = dgvproducts.CurrentRow.Cells["BARCODE"].Value.ToString();
                        this.Close();
                    }
                }
            }catch(Exception ex) { throw ex; }
        }

        private void ProductSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    // Double Enter detected
                    dgvproducts.Focus();
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
        }

        private void newproductbtn_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CreateProduct));
            if (openForm == null)
            {
                CreateProduct createProduct = new CreateProduct();
                createProduct.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void customproductbtn_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CustomProductForm));
            if (openForm == null)
            {
                CustomProductForm customProductForm = new CustomProductForm();
                customProductForm.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }
    }
}
