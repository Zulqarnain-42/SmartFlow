using SmartFlow.Common.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SmartFlow.Masters
{
    public partial class ProductSerialNo : Form
    {
        public ProductSerialNo()
        {
            InitializeComponent();
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

                    await CommonFunction.DisposeOnCloseAsync(productSelection);
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


                        await CommonFunction.DisposeOnCloseAsync(productSelection);
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
                        mfrlbl.Text = productmfr.ToString();
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
            if(!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) 
                && !string.IsNullOrEmpty(serialnotxtbox.Text) && !string.IsNullOrWhiteSpace(serialnotxtbox.Text))
            {
                string serialNo = serialnotxtbox.Text.ToUpper();
                string productmfr = mfrlbl.Text.ToUpper();
                string productid = productidlbl.Text;
                dgvItemSerialNo.Rows.Add(productid,productmfr, serialNo);
                serialnotxtbox.Text = string.Empty;
                mfrlbl.Text = string.Empty;
                productidlbl.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvItemSerialNo.Rows)
            {
                if(row.IsNewRow) continue;

                string serialNo = row.Cells["serialnocolumn"].Value?.ToString() ?? "";
                string mfr = mfrlbl.Text;
                int productid = Convert.ToInt32(productidlbl.Text);

                string tableName = "BoxSerialNoTable";

                var columnData = new Dictionary<string, object>
                {
                    {"ProductId", productid },
                    {"SerialNo", serialNo },
                    {"CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    {"CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                    {"ProductMfr", mfr }
                };

                bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                dgvItemSerialNo.Rows.Clear();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
