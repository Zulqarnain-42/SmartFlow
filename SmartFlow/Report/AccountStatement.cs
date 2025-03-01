using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report
{
    public partial class AccountStatement : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string accountname = string.Empty;
        public AccountStatement()
        {
            InitializeComponent();
        }

        private async void selectaccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                {
                    try
                    {
                        // Check if the AccountSelectionForm is already open
                        Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                        if (openForm == null)
                        {
                            // Create and show AccountSelectionForm if not already open
                            AccountSelectionForm accountsSelection = new AccountSelectionForm
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            accountsSelection.AccountDataSelected += UpdateAccountInfo;

                            // Dispose on form close
                            CommonFunction.DisposeOnClose(accountsSelection);

                            // Show the form as a dialog
                            accountsSelection.ShowDialog();
                        }
                        else
                        {
                            openForm.BringToFront(); // Bring the existing form to the front
                        }
                    }
                    catch (Exception formEx)
                    {
                        // Handle any exceptions that occur while checking or opening the form
                        MessageBox.Show($"Error occurred while opening the account selection form: {formEx.Message}", "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // General exception handling for unexpected issues
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UpdateAccountInfo(object sender, AccountData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int accountid = e.AccountId;
                    accountname = e.AccountName;
                    int accountheadid = e.AccountHeadId;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        accountidlbl.Text = accountid.ToString();
                        selectaccounttxtbox.Text = accountname;
                        accountheadidlbl.Text = accountheadid.ToString();
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void selectaccounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(selectaccounttxtbox.Text))
                    {
                        try
                        {
                            // Check if the AccountSelectionForm is already open
                            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountSelectionForm));
                            if (openForm == null)
                            {
                                // Create and show AccountSelectionForm if not already open
                                AccountSelectionForm accountsSelection = new AccountSelectionForm
                                {
                                    WindowState = FormWindowState.Normal,
                                    StartPosition = FormStartPosition.CenterParent,
                                };
                                accountsSelection.AccountDataSelected += UpdateAccountInfo;

                                // Dispose on form close
                                CommonFunction.DisposeOnClose(accountsSelection);

                                // Show the form as a dialog
                                accountsSelection.ShowDialog();
                            }
                            else
                            {
                                openForm.BringToFront(); // Bring existing form to front
                            }
                        }
                        catch (Exception formEx)
                        {
                            // Handle any exceptions that occur while checking or opening the form
                            MessageBox.Show($"An error occurred while opening the account selection form: {formEx.Message}", "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // General exception handling for any unexpected issues
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string accountData = selectaccounttxtbox.Text;
                int clientid = Convert.ToInt32(accountidlbl.Text);

                if (clientid > 0)
                {
                    // Define the custom date format and UK culture
                    string format = "dd/MM/yyyy";
                    var cultureInfo = new System.Globalization.CultureInfo("en-GB"); // UK culture

                    // Parse startDate and endDate from the textboxes using the custom format
                    DateTime startDate;
                    DateTime endDate;

                    // Try parsing the dates from the textboxes with the exact format
                    if (DateTime.TryParseExact(invoicedatetxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out startDate) &&
                        DateTime.TryParseExact(invoicedatetotxtbox.Text, format, cultureInfo, System.Globalization.DateTimeStyles.None, out endDate))
                    {
                        // Date parsing was successful
                        Console.WriteLine($"Start Date: {startDate}");
                        Console.WriteLine($"End Date: {endDate}");
                    }
                    else
                    {
                        // If parsing fails, attempt to parse the dates without the exact format
                        try
                        {
                            startDate = DateTime.Parse(invoicedatetxtbox.Text);
                            endDate = DateTime.Parse(invoicedatetotxtbox.Text);
                        }
                        catch (FormatException dateEx)
                        {
                            MessageBox.Show($"Error: The date format is invalid. Please use the correct date format (dd/MM/yyyy). {dateEx.Message}", "Date Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit the method if date parsing fails
                        }
                    }

                    // Use a parameterized query to avoid issues with direct string concatenation
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand("GetAccountStatementSummary", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure; // Ensure it's a stored procedure

                                // Add parameters for the stored procedure
                                command.Parameters.AddWithValue("@ClientId", clientid);
                                command.Parameters.AddWithValue("@FromDate", startDate.ToString());
                                command.Parameters.AddWithValue("@ToDate", endDate.ToString());

                                connection.Open();
                                DataTable dataInvoice = new DataTable();
                                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataInvoice);
                                }

                                if (dataInvoice.Rows.Count > 0)
                                {
                                    this.Close();
                                    DetailAccountStatement accountStatement = new DetailAccountStatement(dataInvoice, startDate, endDate, accountname);
                                    accountStatement.MdiParent = Application.OpenForms["Dashboard"];
                                    CommonFunction.DisposeOnClose(accountStatement);
                                    accountStatement.Show();
                                }
                                else
                                {
                                    MessageBox.Show("No data found for the specified date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Database error occurred: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid client ID. Please enter a valid client ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BalanceSheet_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; // Current date and time
            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            invoicedatetxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
