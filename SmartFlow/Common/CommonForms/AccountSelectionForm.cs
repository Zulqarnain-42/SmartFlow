using System;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class AccountSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public event EventHandler<AccountData> AccountDataSelected;

        public AccountSelectionForm()
        {
            InitializeComponent();
        }

        private async void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            await CommonFunction.GetAccountInfoAsync(searchtxtbox.Text, dgvaccount);
        }

        private void AccountSelectionForm_Load(object sender, EventArgs e)
        {
            FocusSearchAndLoadAccountInfo();
        }

        private async void FocusSearchAndLoadAccountInfo()
        {
            try
            {
                // Check if the search text box is initialized
                if (searchtxtbox != null)
                {
                    searchtxtbox.Focus(); // Set focus to the search text box
                }
                else
                {
                    MessageBox.Show("Search TextBox is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure the DataGridView is initialized
                if (dgvaccount != null)
                {
                    dgvaccount.ClearSelection(); // Clear any existing selection
                }
                else
                {
                    MessageBox.Show("DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Load account information using the common function
                await CommonFunction.GetAccountInfoAsync("", dgvaccount);
            }
            catch (Exception ex)
            {
                // Catch and display any unexpected errors
                MessageBox.Show($"An error occurred while loading account information:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvaccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the DataGridView is not null
                if (dgvaccount != null)
                {
                    // Check if there are any rows in the DataGridView
                    if (dgvaccount.Rows.Count > 0)
                    {
                        // Ensure exactly one row is selected
                        if (dgvaccount.SelectedRows.Count == 1 && dgvaccount.CurrentRow != null)
                        {
                            DataGridViewRow selectedRow = dgvaccount.CurrentRow;

                            // Safe checks for each value and parsing
                            if (selectedRow != null)
                            {
                                // Parse supplier ID
                                if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int accountid))
                                {
                                    int accountheadid = Convert.ToInt32(selectedRow.Cells["HEADID"]?.Value ?? 0);
                                    // Raise the event with the data to pass to the parent form
                                    decimal credit = selectedRow.Cells["Credit"]?.Value != null ? Convert.ToDecimal(selectedRow.Cells["Credit"].Value) : 0;
                                    decimal debit = selectedRow.Cells["Debit"]?.Value != null ? Convert.ToDecimal(selectedRow.Cells["Debit"].Value) : 0;
                                    decimal amount = credit != 0 ? credit : debit; // Assign Credit if available, otherwise Debit.

                                    AccountDataSelected?.Invoke(this, new AccountData(
                                        accountid,
                                        selectedRow.Cells["Account Name"]?.Value?.ToString() ?? "Unknown",
                                        accountheadid,
                                        selectedRow.Cells["CodeAccount"]?.Value?.ToString() ?? "Unknown",
                                        amount // Assign either Credit or Debit, ensuring only one is selected.
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
                            MessageBox.Show("Please select exactly one row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The DataGridView contains no rows.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Catch and handle any unexpected errors
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvaccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Ensure the DataGridView is initialized and a row is selected
                    if (dgvaccount != null && dgvaccount.CurrentRow != null)
                    {
                        DataGridViewRow selectedRow = dgvaccount.CurrentRow;

                        // Safe checks for each value and parsing
                        if (selectedRow != null)
                        {
                            // Parse supplier ID
                            if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int accountid))
                            {
                                int accountheadid = Convert.ToInt32(selectedRow.Cells["HEADID"]?.Value ?? 0);
                                // Raise the event with the data to pass to the parent form
                                decimal credit = selectedRow.Cells["Credit"]?.Value != null ? Convert.ToDecimal(selectedRow.Cells["Credit"].Value) : 0;
                                decimal debit = selectedRow.Cells["Debit"]?.Value != null ? Convert.ToDecimal(selectedRow.Cells["Debit"].Value) : 0;
                                decimal amount = credit != 0 ? credit : debit; // Assign Credit if available, otherwise Debit.

                                AccountDataSelected?.Invoke(this, new AccountData(
                                    accountid,
                                    selectedRow.Cells["Account Name"]?.Value?.ToString() ?? "Unknown",
                                    accountheadid,
                                    selectedRow.Cells["CodeAccount"]?.Value?.ToString() ?? "Unknown",
                                    amount // Assign either Credit or Debit, ensuring only one is selected.
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
                        MessageBox.Show("No row is currently selected.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors gracefully
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AccountSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    // Attempt to close the form
                    this.Close();

                    // Mark the event as handled to prevent further processing
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors gracefully
                MessageBox.Show($"An error occurred while processing the Escape key:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dgvaccount.Focus();
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
