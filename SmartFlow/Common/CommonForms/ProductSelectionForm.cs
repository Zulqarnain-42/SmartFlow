using System;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class ProductSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public event EventHandler<ProductData> ProductDataSelected;
        public ProductSelectionForm()
        {
            InitializeComponent();
        }
        private async void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            await CommonFunction.GetProductAsync(searchtxtbox.Text,dgvproducts);
        }
        private async void ProductSelectionForm_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            await CommonFunction.GetProductAsync("",dgvproducts);
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

                        // Safe checks for each value and parsing
                        if (selectedRow != null)
                        {
                            // Parse supplier ID
                            if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int productid))
                            {
                                float productPrice = float.TryParse(selectedRow.Cells["PRICE"].Value?.ToString(), out float price) ? price : 0.0f;
                                // Raise the event with the data to pass to the parent form
                                ProductDataSelected?.Invoke(this, new ProductData(
                                    productid,
                                    selectedRow.Cells["MFR"]?.Value?.ToString() ?? "Unknown",
                                    selectedRow.Cells["TITLE"]?.Value?.ToString() ?? "Unknown",
                                    productPrice,
                                    selectedRow.Cells["UPC"]?.Value?.ToString() ?? "Unknown",
                                    selectedRow.Cells["Barcode"]?.Value?.ToString() ?? "Unknown"
                                ));

                                // Close the child form after passing the data
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Supplier ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        // Parse supplier ID
                        if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int productid))
                        {
                            float productPrice = float.TryParse(selectedRow.Cells["PRICE"].Value?.ToString(), out float price) ? price : 0.0f;
                            // Raise the event with the data to pass to the parent form
                            ProductDataSelected?.Invoke(this, new ProductData(
                                productid,
                                selectedRow.Cells["MFR"]?.Value?.ToString() ?? "Unknown",
                                selectedRow.Cells["TITLE"]?.Value?.ToString() ?? "Unknown",
                                productPrice,
                                selectedRow.Cells["UPC"]?.Value?.ToString() ?? "Unknown",
                                selectedRow.Cells["Barcode"]?.Value?.ToString() ?? "Unknown"
                            ));

                            // Close the child form after passing the data
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Supplier ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
