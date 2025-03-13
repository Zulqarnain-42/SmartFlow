using SmartFlow.Common;
using SmartFlow.Purchase;
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
    public partial class BookingLocation: Form
    {
        public BookingLocation()
        {
            InitializeComponent();
        }

        private async void BookingLocation_Load(object sender, EventArgs e)
        {
            bookingcodetxtbox.Text = await GenerateUniqueRandomCodeAsync();
        }

        private async Task<string> GenerateUniqueRandomCodeAsync()
        {
            Random random = new Random();
            string randomCode;
            bool exists;

            do
            {
                int number = random.Next(1000, 9999); // Generate a 4-digit number
                randomCode = $"B{number}"; // Prefix with "R"

                // Check if the code already exists in the database
                string query = "SELECT COUNT(*) FROM BookingLocation WHERE BLocationCode = @code";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@code", randomCode }
                };

                // Execute query asynchronously
                int count = Convert.ToInt32(await DatabaseAccess.ExecuteScalarAsync(query, parameters));

                exists = count > 0; // If count > 0, it means the code exists

            } while (exists); // Repeat until a unique code is found

            return randomCode;
        }

        private async void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousetxtbox.Text))
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = await DatabaseAccess.RetriveAsync(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterParent,
                            };

                            warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;
                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.Show();
                        }
                    }
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private async void UpdateWarehouseInfo(object sender, WarehouseData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int warehouseid = e.WarehouseId;
                    string warehousename = e.WarehouseName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        warehouseidlbl.Text = warehouseid.ToString();
                        selectwarehousetxtbox.Text = warehousename;
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
    }
}
