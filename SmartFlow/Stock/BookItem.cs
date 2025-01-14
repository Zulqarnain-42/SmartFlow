using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class BookItem : Form
    {
        public BookItem()
        {
            InitializeComponent();
        }
        public BookItem(int bookitem)
        {
            InitializeComponent();
            this.bookitemidlbl.Text = bookitem.ToString();
        }
        private void BookItem_Load(object sender, EventArgs e)
        {
            startdatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            enddatetxtbox.Text = DateTime.Now.AddDays(20).ToString("dd/MM/yyyy");
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox, "Please Enter Invoice No.");
                    invoicenotxtbox.Focus();
                    return;
                }
                else
                {
                    string query = string.Format("");
                    DataTable invoicedata = DatabaseAccess.Retrive(query);
                    if (invoicedata.Rows.Count > 0)
                    {

                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectwarehousetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetxtbox,"Please Select a Warehouse");
                    selectwarehousetxtbox.Focus();
                    return;
                }

                if(bookinglocationtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(bookinglocationtxtbox,"Please Select Booking Location.");
                    bookinglocationtxtbox.Focus();
                    return;
                }

                if(importantnotestxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(importantnotestxtbox,"Please Enter Description.");
                    importantnotestxtbox.Focus();
                    return;
                }

                string importantNotes = importantnotestxtbox.Text;

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousetxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                            warehouseSelection.MdiParent = this.MdiParent;

                            warehouseSelection.FormClosed += delegate
                            {
                                UpdateWarehouseTxtBox();
                            };
                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.Show();
                        }
                    }
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateWarehouseTxtBox()
        {
            selectwarehousetxtbox.Text = GlobalVariables.warehousenameglobal;
            warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
        }
        private void BookItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (bookinglocationtxtbox.Text.Trim().Length > 0) { return true; }
            if (importantnotestxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }

        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm();
                    productSelection.MdiParent = this.MdiParent;

                    productSelection.FormClosed += delegate
                    {
                        UpdateProductTextBox();
                    };
                    CommonFunction.DisposeOnClose(productSelection);
                    productSelection.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateProductTextBox()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) &&
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) &&
                GlobalVariables.productidglobal > 0)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal.ToString();
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
                mfrtxtbox.Text = GlobalVariables.productmfrglobal.ToString();
            }
        }

        private void addrowbtn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
