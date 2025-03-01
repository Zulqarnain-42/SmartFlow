using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Stock.Reports;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

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
                        /* supplieridlbl.Text = supplierId.ToString();
                         selectsuppliertxtbox.Text = supplierName;
                         suppliercodetxtbox.Text = supplierCode;
                         companytxtbox.Text = companyName;*/
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

                bool productExists = false;

                foreach (DataGridViewRow row in dgvbarcodeproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["productid"].Value != null && row.Cells["productid"].Value.ToString() == productidlbl.Text.ToString())
                        {
                            MessageBox.Show("Product Exist Already.");
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists) 
                {
                    dgvbarcodeproducts.Rows.Add(productid, mfr, productname, qty);
                }

                selectproducttxtbox.Text = string.Empty;
                qtybarcode.Text = string.Empty;
                selectproducttxtbox.Focus();

                
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private async void generatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbarcodeproducts.Rows.Count == 0 || dgvbarcodeproducts.Rows.Count == 1 && dgvbarcodeproducts.Rows[0].IsNewRow)
                {
                    MessageBox.Show("Please Select Item.");
                    return; // The DataGridView is empty
                }
                else
                {
                    foreach(DataGridViewRow row in dgvbarcodeproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        string productmfr = row.Cells["productmfr"].Value.ToString();
                        string producttitle = row.Cells["productname"].Value.ToString();
                        int productqty = Convert.ToInt32(row.Cells["barcodeqty"].Value.ToString());

                        string getbarcodeProduct = string.Format("SELECT Barcode FROM ProductTable WHERE ProductName LIKE '%" + producttitle + "%' " +
                            "AND MFR LIKE '" + productmfr + "' " +
                            "AND ProductID = '" + productid + "'");
                        DataTable dtproductdata = await DatabaseAccess.RetriveAsync(getbarcodeProduct);

                        if(dtproductdata!=null && dtproductdata.Rows.Count > 0)
                        {
                            dtproductdata.Columns.Add("BarcodeImage", typeof(byte[]));
                            GenerateBarcodes(dtproductdata);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void GenerateBarcodes(DataTable dataTable)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 100,
                    Width = 300
                }
            };

            foreach (DataRow row in dataTable.Rows)
            {
                string productCode = row["Barcode"].ToString();
                using (Bitmap barcodeBitmap = writer.Write(productCode))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        barcodeBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        row["BarcodeImage"] = ms.ToArray(); // Store image as byte array
                    }
                }
            }

            this.Close();
            PrintedBarcodeViewer printedBarcode = new PrintedBarcodeViewer(dataTable);
            CommonFunction.DisposeOnClose(printedBarcode);
            printedBarcode.Show();
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if(qtybarcode.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelection = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterScreen,
                        };

                        productSelection.ProductDataSelected += UpdateProductTextBox;

                        CommonFunction.DisposeOnClose(productSelection);
                        productSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
                
            }
        }
    }
}
