using System;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class AccountGroupSelectionForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public AccountGroupSelectionForm()
        {
            InitializeComponent();
        }
        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            HandleEnterKeyPress(e);
        }

        private void HandleEnterKeyPress(KeyEventArgs e)
        {
            try
            {
                // Ensure the pressed key is Enter
                if (e.KeyCode == Keys.Enter)
                {
                    // Get the current time
                    DateTime currentTime = DateTime.Now;

                    // Calculate the time difference since the last Enter press
                    TimeSpan timeDiff = currentTime - lastEnterPressTime;

                    // Check if the Enter key was pressed twice within the threshold
                    if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                    {
                        // Ensure DataGridView is not null before setting focus
                        if (dgvaccountgroupselection != null)
                        {
                            dgvaccountgroupselection.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Data grid view is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Reset lastEnterPressTime to prevent multiple triggers
                        lastEnterPressTime = DateTime.MinValue;
                    }
                    else
                    {
                        // Update lastEnterPressTime with the current time
                        lastEnterPressTime = currentTime;
                    }

                    // Suppress the default behavior for the Enter key
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                // Log the error and provide feedback to the user
                MessageBox.Show($"An error occurred while processing the Enter key press:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetAccountGroupInfo(searchtxtbox.Text, dgvaccountgroupselection);
        }
        private void AccountGroupSelectionForm_Load(object sender, EventArgs e)
        {
            FocusSearchAndLoadAccountGroupInfo();
        }

        private void FocusSearchAndLoadAccountGroupInfo()
        {
            try
            {
                // Set focus to the search text box
                if (searchtxtbox != null)
                {
                    searchtxtbox.Focus();
                }
                else
                {
                    MessageBox.Show("Search TextBox is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Clear the selection in the DataGridView
                if (dgvaccountgroupselection != null)
                {
                    dgvaccountgroupselection.ClearSelection();
                }
                else
                {
                    MessageBox.Show("DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Fetch and load account group information
                CommonFunction.GetAccountGroupInfo("", dgvaccountgroupselection);
            }
            catch (Exception ex)
            {
                // Handle and log unexpected errors
                MessageBox.Show($"An error occurred while processing account group information:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvaccountgroupselection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if DataGridView is initialized and has rows
                if (dgvaccountgroupselection != null && dgvaccountgroupselection.Rows.Count > 0)
                {
                    // Ensure exactly one row is selected
                    if (dgvaccountgroupselection.SelectedRows.Count == 1)
                    {
                        // Validate and assign account ID
                        if (int.TryParse(dgvaccountgroupselection.CurrentRow.Cells[0]?.Value?.ToString(), out int accountId))
                        {
                            GlobalVariables.accountidglobal = accountId;
                        }
                        else
                        {
                            MessageBox.Show("Invalid account ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validate and assign account name
                        string accountName = dgvaccountgroupselection.CurrentRow.Cells[1]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(accountName))
                        {
                            GlobalVariables.accountnameglobal = accountName;
                        }
                        else
                        {
                            MessageBox.Show("Account name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validate and assign account head ID
                        if (int.TryParse(dgvaccountgroupselection.CurrentRow.Cells["AccountHead_ID"]?.Value?.ToString(), out int accountHeadId))
                        {
                            GlobalVariables.accountheadidglobal = accountHeadId;
                        }
                        else
                        {
                            MessageBox.Show("Invalid account head ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("No rows available in the DataGridView.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Log and display any unexpected errors
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgvaccountgroupselection_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Ensure the DataGridView is initialized and the current row is not null
                    if (dgvaccountgroupselection != null && dgvaccountgroupselection.CurrentRow != null)
                    {
                        DataGridViewRow selectedRow = dgvaccountgroupselection.CurrentRow;

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

                        // Validate and assign account head ID
                        if (int.TryParse(selectedRow.Cells["AccountHead_ID"]?.Value?.ToString(), out int accountHeadId))
                        {
                            GlobalVariables.accountheadidglobal = accountHeadId;
                        }
                        else
                        {
                            MessageBox.Show("Invalid account head ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Handle unexpected errors and log the exception
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AccountGroupSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    // Close the current form
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
    }
}
