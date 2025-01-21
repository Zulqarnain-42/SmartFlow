using System;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class CustomerSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public event EventHandler<CustomerData> CustomerDataSelected;

        public CustomerSelectionForm()
        {
            InitializeComponent();
        }
        private async void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            await CommonFunction.GetCustomerAsync(searchtxtbox.Text,dgvcustomer);
        }
        private void CustomerSelectionForm_Load(object sender, EventArgs e)
        {
            FocusSearchAndLoadCustomerInfo();
        }

        private async void FocusSearchAndLoadCustomerInfo()
        {
            try
            {
                // Ensure the search text box is not null and focus it
                if (searchtxtbox != null)
                {
                    searchtxtbox.Focus();
                }
                else
                {
                    MessageBox.Show("Search TextBox is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure the DataGridView is not null and clear any existing selection
                if (dgvcustomer != null)
                {
                    dgvcustomer.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Customer DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Load customer information using the common function
                await CommonFunction.GetCustomerAsync("", dgvcustomer);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors gracefully
                MessageBox.Show($"An error occurred while loading customer information:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvcustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the DataGridView is not null
                if (dgvcustomer != null)
                {
                    // Check if there are rows in the DataGridView
                    if (dgvcustomer.Rows.Count > 0)
                    {
                        // Ensure exactly one row is selected
                        if (dgvcustomer.SelectedRows.Count == 1 && dgvcustomer.CurrentRow != null)
                        {
                            DataGridViewRow selectedRow = dgvcustomer.CurrentRow;

                            // Safe checks for each value and parsing
                            if (selectedRow != null)
                            {
                                // Parse supplier ID
                                if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int customerId))
                                {
                                    // Raise the event with the data to pass to the parent form
                                    CustomerDataSelected?.Invoke(this, new CustomerData(
                                        customerId,
                                        selectedRow.Cells["Account Name"]?.Value?.ToString() ?? "Unknown",
                                        selectedRow.Cells["CODE"]?.Value?.ToString() ?? "Unknown",
                                        selectedRow.Cells["Company Name"]?.Value?.ToString() ?? "Unknown",
                                        selectedRow.Cells["Mobile"]?.Value?.ToString() ?? "Unknown"
                                    ));

                                    // Close the child form after passing the data
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Customer ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            MessageBox.Show("Please select exactly one row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The customer list is empty.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The customer DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and display them
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgvcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Ensure the DataGridView is not null
                    if (dgvcustomer != null)
                    {
                        // Check if there are rows in the DataGridView
                        if (dgvcustomer.Rows.Count > 0)
                        {
                            // Ensure exactly one row is selected
                            if (dgvcustomer.SelectedRows.Count == 1 && dgvcustomer.CurrentRow != null)
                            {
                                DataGridViewRow selectedRow = dgvcustomer.CurrentRow;

                                // Safe checks for each value and parsing
                                if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int customerId))
                                {
                                    // Raise the event with the data to pass to the parent form
                                    CustomerDataSelected?.Invoke(this, new CustomerData(
                                        customerId,
                                        selectedRow.Cells["Account Name"]?.Value?.ToString() ?? "Unknown",
                                        selectedRow.Cells["CODE"]?.Value?.ToString() ?? "Unknown",
                                        selectedRow.Cells["Mobile"]?.Value?.ToString() ?? "Unknown",
                                        selectedRow.Cells["Company Name"]?.Value?.ToString() ?? "Unknown"
                                    ));

                                    // Close the child form after passing the data
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Customer ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select exactly one row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The customer list is empty.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The customer DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors and display the exception message
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CustomerSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    // Ask the user for confirmation before closing
                    var result = MessageBox.Show("Are you sure you want to close this window?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Close(); // Close the form
                        e.Handled = true; // Prevent further processing of the key event
                    }
                    else
                    {
                        e.Handled = false; // Allow further processing if the user cancels
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors gracefully
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
                    dgvcustomer.Focus();
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
