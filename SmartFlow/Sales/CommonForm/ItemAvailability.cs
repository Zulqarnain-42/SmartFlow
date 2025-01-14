using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class ItemAvailability : Form
    {
        public ItemAvailability()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear(); // Clear previous errors

                // Validate the availability input
                if (string.IsNullOrWhiteSpace(availabilitytxtbox.Text))
                {
                    errorProvider.SetError(availabilitytxtbox, "Please Enter Availability.");
                    availabilitytxtbox.Focus();  // Set focus to the invalid field
                    return; // Exit the method if validation fails
                }

                // Assign the value to the global variable if validation passes
                GlobalVariables.availabilitystatus = availabilitytxtbox.Text;

                // Close the current form (only if validation succeeds)
                this.Close();
            }
            catch (Exception ex)
            {
                // Log or display the exception message to help with debugging
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
