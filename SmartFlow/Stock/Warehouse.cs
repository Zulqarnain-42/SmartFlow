using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }
        private void Warehouse_KeyDown(object sender, KeyEventArgs e)
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
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void createwarehousesavebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(createwarehousesavebtn.Text == "Update")
                {
                    errorProvider.Clear();
                    if(warehousenametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(warehousenametxtbox,"Please Enter Warehouse Name");
                        warehousenametxtbox.Focus();
                        return;
                    }

                    if(addresstxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(addresstxtbox,"Please Enter Address");
                        addresstxtbox.Focus();
                        return;
                    }

                    if(citytxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(citytxtbox, "Please Enter City");
                        citytxtbox.Focus();
                        return;
                    }

                    string findwarehouse = "SELECT WarehouseID,Name,Address,City FROM WarehouseTable WHERE Name = '" + warehousenametxtbox.Text + "' " +
                        "AND Address = '" + addresstxtbox.Text + "' AND City = '" + citytxtbox.Text + "'";
                    DataTable warehousedata = DatabaseAccess.Retrive(findwarehouse);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            MessageBox.Show("Warehouse Already Registered.");
                        }
                        else
                        {
                            string updatewarehouse = "UPDATE WarehouseTable SET Name = '" + warehousenametxtbox.Text + "',Address = '" + addresstxtbox.Text + "',City = '" + citytxtbox.Text + "'," +
                                "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "',UpdatedDay = '" + DateTime.Now.DayOfWeek + "' WHERE WarehouseID = '" + warehouseid.Text + "'";
                            bool result = DatabaseAccess.Update(updatewarehouse);
                            if (result)
                            {
                                MessageBox.Show("Updated Successfully!");
                                ResetData();
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                }
                else
                {
                    errorProvider.Clear();
                    if(warehousenametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(warehousenametxtbox,"Please Enter Warehouse Name");
                        warehousenametxtbox.Focus();
                        return;
                    }

                    if(addresstxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(addresstxtbox,"Please Enter Address.");
                        addresstxtbox.Focus();
                        return;
                    }

                    if(citytxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(citytxtbox,"Please Enter City");
                        citytxtbox.Focus();
                        return;
                    }

                    string findwarehouse = "SELECT WarehouseID,Name,Address,City FROM WarehouseTable WHERE Name = '" + warehousenametxtbox.Text + "' " +
                        "AND Address = '" + addresstxtbox.Text + "' AND City = '" + citytxtbox.Text + "'";
                    DataTable warehousedata = DatabaseAccess.Retrive(findwarehouse);

                    if(warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            MessageBox.Show("Warehouse Already Registered");
                        }
                        else
                        {
                            string insertwarehouse = "INSERT INTO WarehouseTable (Name,Address,City,Code,CreatedAt,CreatedDay) VALUES " +
                                "('" + warehousenametxtbox.Text + "','" + addresstxtbox.Text + "','" + citytxtbox.Text + "','" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')";
                            bool result = DatabaseAccess.Insert(insertwarehouse);
                            if (result)
                            {
                                MessageBox.Show("Saved Successfully.");
                                ResetData();
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void ResetData()
        {
            warehousenametxtbox.Text = string.Empty;
            addresstxtbox.Text = string.Empty;
            citytxtbox.Text = string.Empty;
            createwarehousesavebtn.Text = "Update";
        }
        private bool AreAnyTextBoxesFilled()
        {
            if(warehousenametxtbox.Text.Trim().Length > 0) { return true; }
            if (addresstxtbox.Text.Trim().Length > 0) { return true; }
            if (citytxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
    }
}
