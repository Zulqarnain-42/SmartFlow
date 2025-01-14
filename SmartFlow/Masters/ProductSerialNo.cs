using SmartFlow.Common.Forms;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class ProductSerialNo : Form
    {
        public ProductSerialNo()
        {
            InitializeComponent();
        }

        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelection = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

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

        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelection = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

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
        }

        private void UpdateProductTextBox()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) &&
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) &&
                GlobalVariables.productidglobal > 0)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal.ToString();
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
                mfrlbl.Text = GlobalVariables.productmfrglobal.ToString();
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

        private void savebtn_Click(object sender, EventArgs e)
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

                bool result = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);
                dgvItemSerialNo.Rows.Clear();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
