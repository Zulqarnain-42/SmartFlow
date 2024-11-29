using System;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class StockLocationSelection : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public StockLocationSelection()
        {
            InitializeComponent();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetStockLocation(searchtxtbox.Text,dgvstocklocation);
        }
        private void StockLocationSelection_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvstocklocation.ClearSelection();
            CommonFunction.GetStockLocation("",dgvstocklocation);
        }
        private void dgvstocklocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvstocklocation != null)
                {
                    if (dgvstocklocation.Rows.Count > 0)
                    {
                        if (dgvstocklocation.SelectedRows.Count == 1)
                        {
                            GlobalVariables.stocklocationidglobal = Convert.ToInt32(dgvstocklocation.CurrentRow.Cells["ID"].Value);
                            GlobalVariables.stocklocationnameglobal = dgvstocklocation.CurrentRow.Cells["NAME"].Value.ToString();
                            GlobalVariables.stockracknumber = dgvstocklocation.CurrentRow.Cells["RACK NUMBER"].Value.ToString();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Select One Row Only.");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgvstocklocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedrow = dgvstocklocation.CurrentRow;
                    if (selectedrow != null) 
                    {
                        GlobalVariables.stocklocationidglobal = Convert.ToInt32(dgvstocklocation.CurrentRow.Cells["ID"].Value);
                        GlobalVariables.stocklocationnameglobal = dgvstocklocation.CurrentRow.Cells["NAME"].Value.ToString();
                        GlobalVariables.stockracknumber = dgvstocklocation.CurrentRow.Cells["RACK NUMBER"].Value.ToString();
                        this.Close();
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void StockLocationSelection_KeyDown(object sender, KeyEventArgs e)
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
                    dgvstocklocation.Focus();
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
    }
}
