using SmartFlow.Masters;
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
            CommonFunction.GetProduct("",dgvproducts);
        }
        private void dgvproducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if dgvproducts is not null and has rows
                if (dgvproducts != null && dgvproducts.Rows.Count > 0)
                {
                    // Check if exactly one row is selected
                    if (dgvproducts.SelectedRows.Count == 1)
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow = dgvproducts.CurrentRow;

                        // Validate and assign product details
                        if (selectedRow != null)
                        {
                            // Validate and safely parse product ID
                            if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int productId))
                            {
                                GlobalVariables.productidglobal = productId;
                            }
                            else
                            {
                                MessageBox.Show("Invalid product ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Assign product name
                            GlobalVariables.productnameglobal = selectedRow.Cells["TITLE"]?.Value?.ToString();

                            // Validate and assign manufacturer
                            GlobalVariables.productmfrglobal = selectedRow.Cells["MFR"]?.Value?.ToString() ?? "Unknown";

                            // Validate and parse product price
                            if (float.TryParse(selectedRow.Cells["PRICE"]?.Value?.ToString(), out float productPrice))
                            {
                                GlobalVariables.productpriceglobal = productPrice;
                            }
                            else
                            {
                                MessageBox.Show("Invalid product price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Assign product UPC and barcode
                            GlobalVariables.productupcglobal = selectedRow.Cells["UPC"]?.Value?.ToString();
                            GlobalVariables.productbarcodeglobal = selectedRow.Cells["BARCODE"]?.Value?.ToString();

                            // Close the form
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Only One Row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No data available in the product grid.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions and show the error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgvproducts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Ensure that the DataGridView has a current row selected
                    DataGridViewRow selectedRow = dgvproducts.CurrentRow;

                    if (selectedRow != null)
                    {
                        // Validate and safely parse product ID
                        if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int productId))
                        {
                            GlobalVariables.productidglobal = productId;
                        }
                        else
                        {
                            MessageBox.Show("Invalid product ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Assign product name and manufacturer, with null checks
                        GlobalVariables.productnameglobal = selectedRow.Cells["TITLE"]?.Value?.ToString() ?? "Unknown";
                        GlobalVariables.productmfrglobal = selectedRow.Cells["MFR"]?.Value?.ToString() ?? "Unknown";

                        // Validate and parse product price
                        if (float.TryParse(selectedRow.Cells["PRICE"]?.Value?.ToString(), out float productPrice))
                        {
                            GlobalVariables.productpriceglobal = productPrice;
                        }
                        else
                        {
                            MessageBox.Show("Invalid product price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Assign product UPC and barcode with null checks
                        GlobalVariables.productupcglobal = selectedRow.Cells["UPC"]?.Value?.ToString();
                        GlobalVariables.productbarcodeglobal = selectedRow.Cells["BARCODE"]?.Value?.ToString();

                        // Close the form
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No row selected.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions and display error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ProductSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    // Check if there are any selected rows in the DataGridView
                    if (dgvproducts.SelectedRows.Count > 0)
                    {
                        // Clear selection and reset global variables
                        dgvproducts.ClearSelection();
                        GlobalVariables.productidglobal = 0;
                        GlobalVariables.productnameglobal = null;
                        GlobalVariables.productmfrglobal = null;
                        GlobalVariables.productpriceglobal = 0;
                        GlobalVariables.productupcglobal = null;
                        GlobalVariables.productbarcodeglobal = null;
                    }
                    else
                    {
                        // Optional: You can add a message to inform the user if no row is selected
                        MessageBox.Show("No product selected to clear.", "Clear Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Close the form
                    this.Close();
                    e.Handled = true; // Prevent further processing of the key event
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
