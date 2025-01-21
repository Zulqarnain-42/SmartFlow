using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class UpdateQuantity : Form
    {
        public UpdateQuantity()
        {
            InitializeComponent();
        }
        public UpdateQuantity(int prodid,string title,string mfr)
        {
            InitializeComponent();
            productid.Text = prodid.ToString();
            productname.Text = title;
            productmfr.Text = mfr;
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(savebtn.Text == "CLOSE")
                {
                    this.Close();
                }
                else
                {
                    errorProvider.Clear();

                    if (qtytxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(qtytxtbox, "Please Enter Quantity.");
                        qtytxtbox.Focus();
                        return;
                    }

                    string updateqty = string.Format("UPDATE ProductTable SET Quantity = '" + qtytxtbox.Text + "',WarehouseID = '" + warehouseidlbl.Text + "' " +
                        "WHERE ProductID = '" + productid.Text + "'");
                    bool result = false;

                    if (result)
                    {
                        int count = 0;
                        int diff = Convert.ToInt32(qtytxtbox.Text) - count;

                        if (diff > 0)
                        {
                            int start = 0;
                            while (start < diff)
                            {
                                string serialnumber = await GenerateRandomSerialNumber();
                                string query1 = string.Format("INSERT INTO SerialNoTable (ProductId,SerialNo,CreatedAt,CreatedDay) " +
                            "VALUES ('" + productid + "','" + serialnumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "'" + System.DateTime.Now.DayOfWeek + "')");

                                start++;
                            }
                        }
                        MessageBox.Show("Stock Updated");
                        this.Close();
                    }
                }
                

            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        static async Task<string> GenerateRandomSerialNumber()
        {
            Random random = new Random();
            const string chars = "0123456789";
            char[] serialChars = new char[10];

            for (int i = 0; i < serialChars.Length; i++)
            {
                serialChars[i] = chars[random.Next(chars.Length)];
            }

            string serialNumber = new string(serialChars);
            string query = "SELECT SerialNo FROM SerialNoTable WHERE SerialNo = '" + serialNumber + "'";
            DataTable dt = await DatabaseAccess.RetriveAsync(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = await GenerateRandomSerialNumber();
                }
            }
            return serialNumber;
        }
        private void UpdateQuantity_Load(object sender, EventArgs e)
        {
            if(openingstocklbl.Text != "OPENING STOCK - 0")
            {
                qtytxtbox.Visible = false;
                quantitylbl.Visible = false;
                selectwarehouselbl.Visible = false;
                selectwarehousetxtbox.Visible = false;
                savebtn.Text = "CLOSE";
            }
        }
        private void UpdateQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }
        private async void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
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
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                        warehouseSelection.MdiParent = this.MdiParent;

                        warehouseSelection.WarehouseDataSelected += UpdateWarehouseInfo;

                        await CommonFunction.DisposeOnCloseAsync(warehouseSelection);
                        warehouseSelection.Show();
                    }
                }

            }
            else
            {
                openForm.BringToFront();
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
                        /*supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        codetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;*/
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
        private bool AreAnyTextBoxesFilled()
        {
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (qtytxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
    }
}
