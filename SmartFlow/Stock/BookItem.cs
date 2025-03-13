using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Threading.Tasks;
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

                if(bookinglocationcombo.SelectedIndex > 0)
                {
                    errorProvider.SetError(bookinglocationcombo, "Please Select Booking Location.");
                    bookinglocationcombo.Focus();
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
        private async void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousetxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;
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

        private async void UpdateWarehouseInfo(object sender, WarehouseData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int warehouseid = e.WarehouseId;
                    string warehousename = e.WarehouseName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        warehouseidlbl.Text = warehouseid.ToString();
                        selectwarehousetxtbox.Text = warehousename;
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (bookinglocationcombo.SelectedIndex > 0) { return true; }
            if (importantnotestxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }

        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm();
                    productSelection.MdiParent = this.MdiParent;

                    productSelection.ProductDataSelected += UpdateProductTextBox;

                    CommonFunction.DisposeOnClose(productSelection);
                    productSelection.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private async void UpdateProductTextBox(object sender, ProductData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int productid = e.ProductId;
                    string productname = e.ProductName;
                    string productmfr = e.ProductMfr;
                    string productupc = e.ProductUPC;
                    float productprice = e.ProductPrice;
                    string productbarcode = e.ProductBarcode;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        selectproducttxtbox.Text = productname.ToString();
                        productidlbl.Text = productid.ToString();
                        productmfrlbl.Text = productmfr.ToString();
                        productupclbl.Text = productupc.ToString();
                        productpricelbl.Text = productprice.ToString();
                        productbarcodelbl.Text = productbarcode.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addrowbtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool productExists = false;
                foreach (DataGridViewRow row in dgvbookingitem.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["productidcolumn"].Value != null && row.Cells["productidcolumn"].Value.ToString() == productidlbl.Text)
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["productquantity"].Value);
                            row.Cells["productquantity"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvbookingitem.Rows.Add(productidlbl.Text, productmfrlbl.Text, selectproducttxtbox.Text, productupclbl.Text, productbarcodelbl.Text,
                        qtytxtbox.Text);
                }

                ResetLabelData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetLabelData()
        {
            selectproducttxtbox.Text = string.Empty;
            qtytxtbox.Text = string.Empty;
            productpricelbl.Text = string.Empty;
            productbarcodelbl.Text = string.Empty;
            productidlbl.Text = string.Empty;
            productmfrlbl.Text = string.Empty;
            productupclbl.Text = string.Empty;
            selectproducttxtbox.Focus();
        }

        private async void selectwarehousetxtbox_Leave(object sender, EventArgs e)
        {
            int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
            if (warehouseid > 0)
            {
                await CommonFunction.PopulateBookingLocationComboBoxAsync(bookinglocationcombo, warehouseid);
            }
        }
    }
}
