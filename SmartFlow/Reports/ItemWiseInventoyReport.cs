using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;
using SmartFlow.Common.Forms;

namespace SmartFlow.Reports
{
    public partial class ItemWiseInventoyReport : Form
    {
        public ItemWiseInventoyReport()
        {
            InitializeComponent();
        }

        private void itemselectiontxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if (openForm == null)
            {
                ProductSelectionForm productSelection = new ProductSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterScreen,
                };

                productSelection.FormClosed += delegate
                {
                    UpdateProductSelection();
                };
                CommonFunction.DisposeOnClose(productSelection);
                productSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void UpdateProductSelection()
        {
            try
            {
                if (!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) &&
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) &&
                GlobalVariables.productidglobal > 0)
                {
                    itemselectiontxtbox.Text = GlobalVariables.productnameglobal.ToString();
                    productidlbl.Text = GlobalVariables.productidglobal.ToString();
                    mfrtxtbox.Text = GlobalVariables.productmfrglobal.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(itemselectiontxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(itemselectiontxtbox,"Select a product.");
                    itemselectiontxtbox.Focus();
                    return;
                }

                string retrivestockdata = string.Format("");

                DataTable productstockData = DatabaseAccess.Retrive("");
                if (productstockData != null && productstockData.Rows.Count > 0) 
                {

                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
