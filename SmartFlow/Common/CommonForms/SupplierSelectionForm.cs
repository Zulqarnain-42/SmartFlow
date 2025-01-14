using System;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class SupplierSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public SupplierSelectionForm()
        {
            InitializeComponent();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetSupplier(searchtxtbox.Text,dgvsupplier);
        }
        private void SupplierSelectionForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Set focus to the search text box
                searchtxtbox.Focus();

                // Clear selection in the DataGridView
                dgvsupplier.ClearSelection();

                // Call the function to load or refresh supplier data
                CommonFunction.GetSupplier("", dgvsupplier);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors and display an error message
                MessageBox.Show($"An error occurred while refreshing supplier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgvsupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the DataGridView is not null and has rows
                if (dgvsupplier != null && dgvsupplier.Rows.Count > 0)
                {
                    // Check if exactly one row is selected
                    if (dgvsupplier.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedRow = dgvsupplier.CurrentRow;

                        // Safe checks for each value and parsing
                        if (selectedRow != null)
                        {
                            // Parse supplier ID
                            if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int supplierId))
                            {
                                GlobalVariables.supplieridglobal = supplierId;
                            }
                            else
                            {
                                MessageBox.Show("Invalid Supplier ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Get supplier name
                            GlobalVariables.suppliernameglobal = selectedRow.Cells["Account Name"]?.Value?.ToString() ?? "Unknown";

                            // Get supplier code
                            GlobalVariables.suppliercodeglobal = selectedRow.Cells["CODE"]?.Value?.ToString() ?? "Unknown";

                            // Get supplier company name
                            GlobalVariables.suppliercompanyName = selectedRow.Cells["Company Name"]?.Value?.ToString() ?? "Unknown";

                            // Close the form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Message if no row or more than one row is selected
                        MessageBox.Show("Please select exactly one row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No supplier data available.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors and display a message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgvsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Ensure there's a valid current row
                    DataGridViewRow selectedRow = dgvsupplier.CurrentRow;

                    if (selectedRow != null)
                    {
                        // Safe checks and conversion with proper exception handling
                        if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int supplierId))
                        {
                            GlobalVariables.supplieridglobal = supplierId;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Supplier ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Safely retrieve other values from the selected row
                        GlobalVariables.suppliernameglobal = selectedRow.Cells["Account Name"]?.Value?.ToString() ?? "Unknown";
                        GlobalVariables.suppliercodeglobal = selectedRow.Cells["CODE"]?.Value?.ToString() ?? "Unknown";
                        GlobalVariables.suppliercompanyName = selectedRow.Cells["Company Name"]?.Value?.ToString() ?? "Unknown";

                        // Close the form after selection
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No row selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SupplierSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    // Prompt the user for confirmation before closing the form
                    var result = MessageBox.Show("Are you sure you want to close the form?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Close(); // Close the form if the user confirms
                    }

                    e.Handled = true; // Prevent further processing of the key event
                }
            }
            catch (Exception ex)
            {
                // Log the exception and show a user-friendly message
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
                    dgvsupplier.Focus();
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
