using SmartFlow.Common.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;

namespace SmartFlow.Masters
{
    public partial class ProductSerialNo : Form
    {
        private int _productid = 0;
        private string _productmfr = string.Empty;
        private int invoiceCounter = 1;
        public ProductSerialNo()
        {
            InitializeComponent();
        }

        public ProductSerialNo(int productid)
        {
            InitializeComponent();
            this._productid = productid;
        }

        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

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
                            StartPosition = FormStartPosition.CenterParent,
                        };

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
                        productidlbl.Text = productid.ToString();
                        selectproducttxtbox.Text = productname.ToString();
                        productmfrlbl.Text = productmfr.ToString();
                        productupclbl.Text = productupc.ToString();
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            if(_productid > 0)
            {
                if (!string.IsNullOrEmpty(serialnotxtbox.Text) && !string.IsNullOrWhiteSpace(serialnotxtbox.Text))
                {
                    string serialNo = serialnotxtbox.Text.ToUpper();
                    string productmfr = productmfrlbl.Text.ToUpper();
                    string productid = productidlbl.Text;
                    dgvItemSerialNo.Rows.Add(productid, productmfr, serialNo);
                    serialnotxtbox.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                    serialnotxtbox.Focus();
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text)
                && !string.IsNullOrEmpty(serialnotxtbox.Text) && !string.IsNullOrWhiteSpace(serialnotxtbox.Text))
                {
                    string serialNo = serialnotxtbox.Text.ToUpper();
                    string productmfr = productmfrlbl.Text.ToUpper();
                    string productid = productidlbl.Text;
                    dgvItemSerialNo.Rows.Add(productid, productmfr, serialNo);
                    serialnotxtbox.Text = string.Empty;
                    productmfrlbl.Text = string.Empty;
                    productidlbl.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                }
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (DataGridViewRow row in dgvItemSerialNo.Rows)
            {
                if(row.IsNewRow) continue;

                string serialNo = row.Cells["serialnocolumn"].Value?.ToString() ?? "";
                string mfr = productmfrlbl.Text;
                int productid = int.TryParse(row.Cells["productidcolumn"].Value?.ToString(), out int tempProductId) ? tempProductId : 0;

                string tableName = "BoxSerialNoTable";

                var columnData = new Dictionary<string, object>
                {
                    {"ProductId", productid },
                    {"SerialNo", serialNo },
                    {"CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    {"CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                    {"ProductMfr", mfr },
                    {"InvoiceNo", productserialnoinvoicelbl.Text }
                };

                result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                
            }

            if (result)
            {
                MessageBox.Show("Saved Successfully!");
                dgvItemSerialNo.Rows.Clear();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ProductSerialNo_Load(object sender, EventArgs e)
        {
            if(_productid > 0)
            {
                selectproducttxtbox.Visible = false;
                addbtn.Visible = true;
                productidlbl.Text = _productid.ToString();
                productmfrlbl.Text = _productmfr.ToString();
                selectproductlbl.Visible = false;

                string query = "SELECT MFR FROM ProductTable WHERE ProductID = '" + _productid + "'";
                DataTable dt = await DatabaseAccess.RetriveAsync(query);
                if(dt.Rows.Count > 0)
                {
                    productmfrlbl.Text = dt.Rows[0]["MFR"].ToString();
                }
            }
            else
            {
                selectproducttxtbox.Visible = true;
                addbtn.Visible = true;
                productidlbl.Text = string.Empty;
                productmfrlbl.Text = string.Empty;
            }
            productserialnoinvoicelbl.Text = await GenerateNextInvoiceNumber();
        }

        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (lastInvoiceNumber == null)
                {

                    // Generate the invoice number using the current date and a sequential number
                    string invoicepart = "PSR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{sequentialPart}";

                    return newInvoiceNumber;
                    // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    string invoicepart = "PSR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM BoxSerialNoTable WHERE InvoiceNo LIKE 'PSR-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInvoiceNumber;
        }
    }
}
