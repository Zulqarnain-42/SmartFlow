using System;
using System.Windows.Forms;

namespace SmartFlow.Common.Forms
{
    public partial class AccountSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public AccountSelectionForm()
        {
            InitializeComponent();
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetAccountInfo(searchtxtbox.Text, dgvaccount);
        }
        private void AccountSelectionForm_Load(object sender, EventArgs e)
        {
            FocusSearchAndLoadAccountInfo();
        }

        private void FocusSearchAndLoadAccountInfo()
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
                CommonFunction.GetAccountInfo("", dgvaccount);
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
                            // Validate and assign account ID
                            if (int.TryParse(dgvaccount.CurrentRow.Cells[0]?.Value?.ToString(), out int accountId))
                            {
                                GlobalVariables.accountidglobal = accountId;
                            }
                            else
                            {
                                MessageBox.Show("Invalid account ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Validate and assign account name
                            string accountName = dgvaccount.CurrentRow.Cells[1]?.Value?.ToString();
                            if (!string.IsNullOrWhiteSpace(accountName))
                            {
                                GlobalVariables.accountnameglobal = accountName;
                            }
                            else
                            {
                                MessageBox.Show("Account name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Validate and assign account code
                            string accountCode = dgvaccount.CurrentRow.Cells[4]?.Value?.ToString();
                            if (!string.IsNullOrWhiteSpace(accountCode))
                            {
                                GlobalVariables.accountcodeglobal = accountCode;
                            }
                            else
                            {
                                MessageBox.Show("Account code cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Close the form after successful assignment
                            this.Close();
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

                        // Validate and assign account ID
                        if (int.TryParse(selectedRow.Cells[0]?.Value?.ToString(), out int accountId))
                        {
                            GlobalVariables.accountidglobal = accountId;
                        }
                        else
                        {
                            MessageBox.Show("Invalid account ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validate and assign account name
                        string accountName = selectedRow.Cells[1]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(accountName))
                        {
                            GlobalVariables.accountnameglobal = accountName;
                        }
                        else
                        {
                            MessageBox.Show("Account name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Close the form after successful assignment
                        this.Close();
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
