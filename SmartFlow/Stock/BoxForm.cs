using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class BoxForm: Form
    {
        public BoxForm()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvpackinglist_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the first column (index 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Set the cell value to the row number (1-based index)
                e.Value = e.RowIndex + 1;
            }
        }

        private void dgvpackinglist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                try
                {
                    int productid = Convert.ToInt32(dgvpackinglist.CurrentRow.Cells["productid"].Value);
                    if (productid > 0)
                    {
                        foreach (DataGridViewRow row in dgvpackinglist.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                dgvpackinglist.Rows.Remove(row);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select One Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the selected rows: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if(invoicenotxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice No.");
                invoicenotxtbox.Focus();
                return;
            }

            if(boxnotxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(boxnotxtbox,"Please Enter Box No.");
                boxnotxtbox.Focus();
                return;
            }

            if(lengthtxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(lengthtxtbox,"Please Enter Length.");
                lengthtxtbox.Focus();
                return;
            }

            if(widthtxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(widthtxtbox,"Please Enter Width.");
                widthtxtbox.Focus();
                return;
            }

            if(heighttxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(heighttxtbox,"Please Enter Height.");
                heighttxtbox.Focus();
                return;
            }

            if(weighttxtbox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(weighttxtbox,"Please Enter Weight.");
                weighttxtbox.Focus();
                return;
            }


        }

        private void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            string invoiceNo = invoicenotxtbox.Text;


        }
    }
}
